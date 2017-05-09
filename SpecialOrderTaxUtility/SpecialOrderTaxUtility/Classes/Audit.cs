using System;

namespace SpecialOrderTaxUtility.Classes
{
    public class Audit
    {
        public string RTG_Employee { get; set; }
        public string Utility_Name { get; set; }
        public string Store_Name { get; set; }
        public string Table_Modified { get; set; }
        public string Column_Modified { get; set; }
        public Int64 ID_Changed { get; set; }
        public string Previous_Value { get; set; }
        public string New_Value { get; set; }
        public DateTime Date_Modified { get; set; }
    }
}