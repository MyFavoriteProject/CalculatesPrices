using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CalculatesPrices.Model
{
    public class PurchaseModel : BaseModel
    {
        private double totalPrice;

        public ObservableCollection<ProductModel> Products { get; set; }
        public double TotalPrice 
        { 
            get => totalPrice;
            set
            {
                totalPrice = value;
                OnPropertyChanged();
            }
        }
    }
}
