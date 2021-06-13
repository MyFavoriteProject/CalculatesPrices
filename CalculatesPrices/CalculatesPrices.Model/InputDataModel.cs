using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CalculatesPrices.Model
{
    public class InputDataModel : BaseModel
    {
        private double tax;
        private double margin;

        public ObservableCollection<ProductModel> Products { get; set; }
        public double Tax 
        { 
            get => tax;
            set
            { 
                tax = value;
                OnPropertyChanged();
            }
        }
        public double Margin 
        { 
            get => margin;
            set
            {
                margin = value;
                OnPropertyChanged();
            }
        }
    }
}
