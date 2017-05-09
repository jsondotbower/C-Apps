using System;
using System.Windows;

namespace SpecialOrderTaxUtility.Classes
{
    public static class LoadStore
    {
        public static string StoreName(string storeName)
        {
            try
            {
                var storename = Queries.StoreName;
                storeName = Db.Query(storename).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return storeName;
        }
    }
}