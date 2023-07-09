using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationDemo
{
    public abstract class CreditCard : Enumeration<CreditCard>
    {
        public CreditCard(int value,string name):base(value,name) { }

        public abstract double Discount { get;}

        public static readonly CreditCard Gold = new GoldCreditCard();
        public static readonly CreditCard Silver = new SilverCreditCard();
        public static readonly CreditCard Standard = new StandardCreditCard();
        public static readonly CreditCard None = new NoneCreditCard();

        public sealed class GoldCreditCard : CreditCard
        {
            public GoldCreditCard() : base(3, nameof(Gold)) { }

            public override double Discount => 0.2;
        }
        
        public sealed class SilverCreditCard : CreditCard
        {
            public SilverCreditCard() : base(2, nameof(Silver)) { }

            public override double Discount => 0.1;
        }
        public sealed class StandardCreditCard : CreditCard
        {
            public StandardCreditCard() : base(1, nameof(Standard)) { }

            public override double Discount => 0.1;
        }
        public sealed class NoneCreditCard : CreditCard
        {
            public NoneCreditCard() : base(0, nameof(None)) { }

            public override double Discount => 0.05;
        }




    }
}
