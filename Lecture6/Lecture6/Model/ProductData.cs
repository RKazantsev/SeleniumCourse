namespace Lecture6
{
    public class ProductData
    {
        public GeneralTabProduct generalTab;
        public InformationTabProduct informationTab;
        public PricesTabProduct pricesTab;

        public ProductData(string status, string name, string code, string categories, string defaultCategory,
            string productGroup, string quantity, string quantityUnit, string deliveryStatus, string soldOutStatus,
            string productImageURL, string dateValidFrom, string dateValidTo, string manufacturer, string supplier,
            string keywords, string shortDescription, string description, string headTitle, string metaDescription,
            string purchasePrice, string currency, string taxClass, string priceUSD, string priceEUR)
        {
            generalTab = new GeneralTabProduct(status, name, code, categories, defaultCategory, productGroup, 
                quantity, quantityUnit, deliveryStatus, soldOutStatus, productImageURL,  dateValidFrom, dateValidTo);
            informationTab = new InformationTabProduct(manufacturer, supplier, keywords, shortDescription, 
                description, headTitle, metaDescription);
            pricesTab = new PricesTabProduct(purchasePrice, currency, taxClass, priceUSD, priceEUR);
        }        
    }
}
