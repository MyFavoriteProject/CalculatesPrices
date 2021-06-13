using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace CalculatesPrices.ViewModel
{
    public class LocatorViewModel
    {
        public LocatorViewModel()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<CalculatPriceViewModel>();
        }

        public CalculatPriceViewModel CalculatPriceViewModel => ServiceLocator.Current.GetInstance<CalculatPriceViewModel>();
    }
}
