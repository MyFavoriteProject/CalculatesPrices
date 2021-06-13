using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatesPrices.Model
{
    public class ProductModel : BaseModel
    {
        private int id;
        private string title;
        private double netCost;

        public int Id 
        { 
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            } 
        }
        public string Title 
        { 
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public double NetCost
        {
            get => netCost;
            set
            {
                netCost = value;
                OnPropertyChanged();
            }
        }
    }
}
