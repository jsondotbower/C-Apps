using System;
using System.Windows;
using System.Windows.Controls;
using System.Web.Script.Serialization;
using log4net;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;
using SpecialOrderTaxUtility.Classes;

namespace SpecialOrderTaxUtility.Pages
{
    public partial class SpecialOrderTax : Page
    {
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly DataTable _dt = new DataTable();
        private string taxValue;

        public SpecialOrderTax()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            LblStore.Content = LoadStore.StoreName(LblStore.Content.ToString());
            TxtName.Focus();
        }

        private void BtnAuthorize_Click(object sender, RoutedEventArgs e)
        {
            string name = TxtName.Text;
            CheckName.CheckUserName(name);
            Authorize();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            FillGrid();
            LblSODID.IsEnabled = true;
            TxtSODID.IsEnabled = true;
            BtnFix.IsEnabled = true;
            TxtSODID.Focus();
        }

        private void BtnFix_Click(object sender, RoutedEventArgs e)
        {
            Log.Info(DateTime.Now + " | Fix is being executed.");

            try
            {
                string id = TxtSODID.Text.Trim();
                string originalAmount = Queries.TaxAmount(id);
                taxValue = Db.Query(originalAmount).ToString();
                
                Log.Info(DateTime.Now + " | Original amount: " + taxValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem getting the original tax amount: " + ex.Message);
                Log.Info(DateTime.Now + " | There was a problem getting the original tax amount: " + ex.Message);
            }

            try
            {
                string id = TxtSODID.Text.Trim();
                string query = Queries.ResetTaxAmount(id);
                Db.NonQuery(query);
                //Instantiate new Audit object for SendToAzure method
                Audit audit = new Audit();
                audit.Column_Modified = "TaxAmount";
                audit.Table_Modified = "SpecialOrderDetailTax";
                audit.ID_Changed = Convert.ToInt32(TxtSODID.Text);
                audit.RTG_Employee = TxtName.Text;
                audit.Utility_Name = "Special Order Detail Tax";
                audit.Previous_Value = taxValue;
                Log.Info(DateTime.Now + " | Original value: " + taxValue);
                audit.New_Value = "0";
                Log.Info(DateTime.Now + " | New value: 0.");
                audit.Date_Modified = DateTime.Now;
                audit.Store_Name = LblStore.Content.ToString();
                //Method where I am sending the object for serialization and sending to service
                SendToAzure(audit);

                FillGrid();

                Log.Info(DateTime.Now + " | Fix executed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error updating the record: " + ex.Message);
                Log.Info(DateTime.Now + " | There was an error updating the record: " + ex.Message);
            }

            try
            {
                string id = TxtSODID.Text.Trim();
                string newAmount = Queries.TaxAmount(id);
                Db.NonQuery(newAmount);
                Log.Info(DateTime.Now + " | New amount: 0.0000");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem getting the new tax amount: " + ex.Message);
                Log.Info(DateTime.Now + " | There was a problem getting the new tax amount: " + ex.Message);
            }
        }

        private void Authorize()
        {
            BtnAuthorize.IsEnabled = false;
            LblUpc.IsEnabled = true;
            TxtUpc.IsEnabled = true;
            BtnSearch.IsEnabled = true;
            TxtUpc.Focus();
        }

        private void FillGrid()
        {
            _dt.Rows.Clear();
            try
            {
                string upc = TxtUpc.Text.Trim();
                string query = Queries.GetSpecialOrder(upc);
                var adapter = new SqlDataAdapter(query, Db.GetConn());
                adapter.Fill(_dt);
                DataGrid.ItemsSource = _dt.AsDataView();
                DataGrid.IsEnabled = true;
                Log.Info(DateTime.Now + " | FillGrid() executed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Info(DateTime.Now + " | There was a problem filling the grid: " + ex.Message);
            }
        }

        private void SendToAzure(Audit au)
        {
            //This method should just be able to copy and paste into any utility, except a reference will be
            // needed for System.Web.Extension this is needed for the serialization of the object.
            try
            {
                var httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://utilitylogging.azurewebsites.net/AzureLoggingService.svc/InsertAudit");
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.Accept = "application/json; charset=utf-8";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(au);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        string resultText = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(DateTime.Now + " | There was a problem sending to Azure: " + ex.Message);
                Log.Info(DateTime.Now + " | There was a problem sending to Azure: " + ex.Message);
            }           
        }
    }
}