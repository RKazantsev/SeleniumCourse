namespace Lecture6
{
    public class PricesTabProduct
    {
        private string purchasePrice;        
        private string currency;
        private string taxClass;
        private string priceUSD;
        private string priceEUR;        

        public PricesTabProduct(string purchasePrice, string currency, string taxClass, string priceUSD, string priceEUR)
        {
            this.purchasePrice = purchasePrice;            
            this.currency = currency;
            this.taxClass = taxClass;
            this.priceUSD = priceUSD;
            this.priceEUR = priceEUR;            
        }

        public string PurchasePrice
        {
            get
            {
                return purchasePrice;
            }
            set
            {
                purchasePrice = value;
            }
        }
        public string Currency
        {
            get
            {
                return currency;
            }
            set
            {
                currency = value;
            }
        }
        public string TaxClass
        {
            get
            {
                return taxClass;
            }
            set
            {
                taxClass = value;
            }
        }
        public string PriceUSD
        {
            get
            {
                return priceUSD;
            }
            set
            {
                priceUSD = value;
            }
        }
        public string PriceEUR
        {
            get
            {
                return priceEUR;
            }
            set
            {
                priceEUR = value;
            }
        }
    }
}