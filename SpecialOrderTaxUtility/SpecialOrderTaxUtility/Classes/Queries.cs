namespace SpecialOrderTaxUtility.Classes
{
    public static class Queries
    {
        public static string StoreName = @"select StoreName from CompanyStore";

        public static string GetSpecialOrder(string upc)
        {
            return @"SELECT c.LastName, c.FirstName, sod.UPC, sod.[Description], sod.RegularPrice, sod.Cost, sod.COGSAmount, 
                    sodt.TaxAmount, sod.SpecialOrderDetailID, sod.Active
                    FROM dbo.SpecialOrderDetail sod
                    JOIN dbo.SpecialOrderDetailTax sodt ON sodt.SpecialOrderDetailID = sod.SpecialOrderDetailID
                    JOIN dbo.SpecialOrder so ON so.SpecialOrderID = sod.SpecialOrderID
                    JOIN dbo.Customer c ON c.CustomerID = so.CustomerID
                    WHERE sod.UPC LIKE '" + upc + "%' AND sod.Active = 0";
        }

        public static string TaxAmount(string specialOrderDetailId)
        {
            return  @"SELECT TaxAmount FROM dbo.SpecialOrderDetailTax WHERE SpecialOrderDetailID = " + specialOrderDetailId;
        }

        public static string ResetTaxAmount(string specialOrderDetailId)
        {
            return @"UPDATE dbo.SpecialOrderDetailTax SET TaxAmount = 0 WHERE SpecialOrderDetailID = " + specialOrderDetailId;
        }
    }
}