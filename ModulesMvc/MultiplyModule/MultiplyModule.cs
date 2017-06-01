using Autofac;
using ModulesContracts;

namespace MultiplyModule
{
    public class MultiplyModule: ModuleBase
    {
        public override string ToString()
        {
            return "This module multiply two numbers";
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CalculatorOperation>().As<ICalculatorOperation>();
        }
    }

    public class CalculatorOperation : ICalculatorOperation
    {
        public int Calculate(int x, int y)
        {
            return x * y;
        }

        public string Name
        {
            get { return "Multiply"; }
        }
    }
}
