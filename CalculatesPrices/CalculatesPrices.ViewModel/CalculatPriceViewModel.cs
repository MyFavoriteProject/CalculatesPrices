using CalculatesPrices.Model;
using CalculatesPrices.Model.Enums;
using GalaSoft.MvvmLight.Command;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CalculatesPrices.ViewModel
{
    public class CalculatPriceViewModel : BaseViewModel
    {
        private double tax;
        private double productMargin;
        private double totalPrice;

        public CalculatPriceViewModel()
        {
            var products = new ObservableCollection<ProductModel>();
            products.Add(new ProductModel
            {
                Id = 1,
                Title = "Product 1",
                NetCost = 100
            });
            products.Add(new ProductModel
            {
                Id = 2,
                Title = "Product 2",
                NetCost = 200
            });
            InputDataModel = new InputDataModel()
            {
                Products = products,
                Tax = 0.1,
                Margin = 0.2
            };

            PurchaseModel = new PurchaseModel()
            {
                Products = new ObservableCollection<ProductModel>()
            };


            AddCartCommand = new RelayCommand<ProductModel>(AddCartExecute);
            RemoveCartCommand = new RelayCommand<ProductModel>(RemoveCartExecute);
            CalculatePriceCommand = new RelayCommand<CalculateState>(CalculatePriceExecute);
        }

        #region Properties

        public RelayCommand<ProductModel> AddCartCommand { get; }
        public RelayCommand<ProductModel> RemoveCartCommand { get; }
        public RelayCommand<CalculateState> CalculatePriceCommand { get; }
        public InputDataModel InputDataModel { get; set; }
        public PurchaseModel PurchaseModel { get; set; } = new PurchaseModel()
        {
            Products = new ObservableCollection<ProductModel>()
        };

        #endregion

        #region Methods

        private void AddCartExecute(ProductModel product)
        {
            PurchaseModel.Products.Add(product);
        }

        private void RemoveCartExecute(ProductModel product)
        {
            PurchaseModel.Products.Remove(product);
        }

        private void CalculatePriceExecute(CalculateState value)
        {
            if (value == CalculateState.Tax)
            {
                var sumAllPurchase = PurchaseModel.Products.Select(c => c.NetCost).Sum();

                PurchaseModel.TotalPrice = sumAllPurchase * InputDataModel.Tax;
            }
            else if (value == CalculateState.Margin)
            {
                var sumAllPurchase = PurchaseModel.Products.Select(c => c.NetCost).Sum();

                var tax = (sumAllPurchase * InputDataModel.Tax);

                PurchaseModel.TotalPrice = (sumAllPurchase - tax) * InputDataModel.Margin;
            }
            else if (value == CalculateState.AllPrice)
            {
                PurchaseModel.TotalPrice = PurchaseModel.Products.Select(c => c.NetCost).Sum();
            }
        }

        #endregion
    }
}
