using System;
using System.Windows;
using log4net;

namespace SpecialOrderTaxUtility.Classes
{
    public static class CheckName
    {
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string CheckUserName(string name)
        {
            string value = name.ToLower();
            string[] names = { "chris", "ricky", "angie", "ryan", "kyle", "joe", "jason", "matt", "jorgan", "beth", "eric" };
            int pos = Array.IndexOf(names, value);

            if (pos > -1)
            {
                Log.Info(DateTime.Now + " | " + names[pos] + " is using this utility.");
            }
            else if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("You must enter a name to use this utility!");
                Log.Info(DateTime.Now + " | User did not enter a name. Application is shutting down.");
                Application.Current.Shutdown();
            }
            else
            {
                MessageBox.Show("You are not authorized to use this utility!");
                Log.Info(DateTime.Now + " | " + value +
                         " was entered and is not authorized to use this utility.  Application is shutting down.");
                Application.Current.Shutdown();
            }
            return name;
        }
    }
}