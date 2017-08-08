namespace Lecture6
{
    public class InformationTabProduct
    {
        private string manufacturer;
        private string supplier;
        private string keywords;
        private string shortDescription;
        private string description;
        private string headTitle;
        private string metaDescription;        

        public InformationTabProduct(string manufacturer, string supplier, string keywords, string shortDescription,
                           string description, string headTitle, string metaDescription)
        {
            this.manufacturer = manufacturer;
            this.supplier = supplier;
            this.keywords = keywords;
            this.shortDescription = shortDescription;
            this.description = description;
            this.headTitle = headTitle;
            this.metaDescription = metaDescription;          
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = value;
            }
        }
        public string Supplier
        {
            get
            {
                return supplier;
            }
            set
            {
                supplier = value;
            }
        }
        public string Keywords
        {
            get
            {
                return keywords;
            }
            set
            {
                keywords = value;
            }
        }
        public string ShortDescription
        {
            get
            {
                return shortDescription;
            }
            set
            {
                shortDescription = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public string HeadTitle
        {
            get
            {
                return headTitle;
            }
            set
            {
                headTitle = value;
            }
        }
        public string MetaDescription
        {
            get
            {
                return metaDescription;
            }
            set
            {
                metaDescription = value;
            }
        }       
    }
}