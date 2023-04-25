using Sat.Recruitment.Db.Models.Enums;

namespace Sat.Recruitment.Db.Models
{
    public interface IPriceAdapter
    {
        public decimal GetPrice(decimal price);
    }
    public class NormalUser : IPriceAdapter
    {
        public decimal GetPrice(decimal price)
        {
            var Invoice = 0M;
            if (price > 100)
                Invoice = price * 0.12M;
            else if (price > 10)
                Invoice = price * 0.8M;
            return price + Invoice;
        }
    }
    public class SuperUser : IPriceAdapter
    {
        public decimal GetPrice(decimal price)
        {
            var Invoice = 0M;
            if (price > 100)
                Invoice = price * 0.20M;
            return price + Invoice;
        }
    }
    public class PremiumUser : IPriceAdapter
    {
        public decimal GetPrice(decimal price)
        {
            var Invoice = 0M;
            if (price > 100)
                Invoice = price * 2;
            return price + Invoice;
        }
    }

    public class PriceCalculator
    {
        private readonly IPriceAdapter _priceAdapter;

        public PriceCalculator(IPriceAdapter priceAdapter)
        {
            _priceAdapter = priceAdapter;
        }

        public decimal Calculate(decimal price)
        {
            return _priceAdapter.GetPrice(price);
        }
    }
}
