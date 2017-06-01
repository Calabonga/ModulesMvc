using Autofac;
using ModulesContracts;

namespace MinusModule
{
    public class MinusOperation: ModuleBase
    {
        public override string ToString()
        {
            return "The operation returns the result minus of the two numbers";
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CalculatorOperation>().As<ICalculatorOperation>();
        }

    }

    public class CalculatorOperation: ICalculatorOperation
    {
        public int Calculate(int x, int y)
        {
            return x - y;
        }

        public string Name
        {
            get { return "Minus"; }
        }
    }
}
