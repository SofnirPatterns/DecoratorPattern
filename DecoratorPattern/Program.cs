using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage = new DarkTea();
            beverage = new Sugar(beverage);
            beverage = new Milk(beverage);
            beverage = new Discount(beverage);

            Console.WriteLine(beverage.Cost());
            Console.WriteLine(beverage.GetDescription());
            Console.ReadKey();
        }

        public abstract class Beverage
        {            
            public Beverage() { }

            public abstract double Cost();
            public abstract string GetDescription();
        }

        public class CondimentDecorator : Beverage
        {
            protected Beverage Beverage;

            public CondimentDecorator(Beverage beverage)
            {
                this.Beverage = beverage;
            }

            public override double Cost()
            {
                return this.Cost();
            }

            public override string GetDescription()
            {
                return this.Beverage.GetDescription();
            }
        }

        public class DarkTea: Beverage
        {
            public DarkTea() { }

            public override double Cost()
            {
                return 1;
            }

            public override string GetDescription()
            {
                return "Dark tea";
            }
        }

        class Coffee : Beverage
        {
            public Coffee() { }

            public override double Cost()
            {
                return 2;
            }

            public override string GetDescription()
            {
                return "Coffee";
            }
        }

        class Sugar: CondimentDecorator
        {            
            public Sugar(Beverage beverage) : base(beverage) { }

            public override double Cost()
            {
                return this.Beverage.Cost() + 0.1;
            }

            public override string GetDescription()
            {
                return this.Beverage.GetDescription() +", sugar";
            }
        }

        class Milk : CondimentDecorator
        {            
            public Milk(Beverage beverage) : base(beverage) { }

            public override double Cost()
            {
                return this.Beverage.Cost() + 0.4;
            }

            public override string GetDescription()
            {
                return this.Beverage.GetDescription() + ", milk";
            }
        }

        class Discount : CondimentDecorator
        {            
            public Discount(Beverage beverage) : base(beverage) { }

            public override double Cost()
            {
                return this.Beverage.Cost() * 0.9;
            }

            public override string GetDescription()
            {
                return this.Beverage.GetDescription() + ", 10% discount";
            }
        }
    }
}
