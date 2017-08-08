namespace Lecture6
{
    public class GeneralTabProduct
    {
        private string status;
        private string name;
        private string code;
        private string categories;
        private string defaultCategory;
        private string genderProductGroup;
        private string quantity;
        private string quantityUnit;
        private string deliveryStatus;
        private string soldOutStatus;
        private string imageProduct;
        private string dateValidFrom;
        private string dateValidTo;

        public GeneralTabProduct(string status, string name, string code, string categories,
                           string defaultCategory, string genderProductGroup, string quantity, string quantityUnit,
                           string deliveryStatus, string soldOutStatus, string productImageURL, string dateValidFrom, string dateValidTo)
        {
            this.status = status;
            this.name = name;
            this.code = code;
            this.categories = categories;
            this.defaultCategory = defaultCategory;
            this.genderProductGroup = genderProductGroup;
            this.quantity = quantity;
            this.quantityUnit = quantityUnit;
            this.deliveryStatus = deliveryStatus;
            this.soldOutStatus = soldOutStatus;
            this.imageProduct = productImageURL;
            this.dateValidFrom = dateValidFrom;
            this.dateValidTo = dateValidTo;
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }
        public string Categories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
            }
        }
        public string DefaultCategory
        {
            get
            {
                return defaultCategory;
            }
            set
            {
                defaultCategory = value;
            }
        }
        public string Gender
        {
            get
            {
                return genderProductGroup;
            }
            set
            {
                genderProductGroup = value;
            }
        }
        public string Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
        public string QuantityUnit
        {
            get
            {
                return quantityUnit;
            }
            set
            {
                quantityUnit = value;
            }
        }
        public string DeliveryStatus
        {
            get
            {
                return deliveryStatus;
            }
            set
            {
                deliveryStatus = value;
            }
        }
        public string SoldOutStatus
        {
            get
            {
                return soldOutStatus;
            }
            set
            {
                soldOutStatus = value;
            }
        }
        public string ProductImageURL
        {
            get
            {
                return imageProduct;
            }
            set
            {
                imageProduct = value;
            }
        }
        public string DateValidFrom
        {
            get
            {
                return dateValidFrom;
            }
            set
            {
                dateValidFrom = value;
            }
        }
        public string DateValidTo
        {
            get
            {
                return dateValidTo;
            }
            set
            {
                dateValidTo = value;
            }
        }
    }
}