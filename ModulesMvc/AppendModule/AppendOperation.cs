using Autofac;
using Autofac.Core;
using ModulesContracts;

namespace AppendModule
{
    public class AppendOperation: ModuleBase
    {
        public override string ToString()
        {
            return "The operation returns the sum of the two numbers"; 
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
            return x + y;
        }

        public string Name { get { return "Append"; } }
    }
}
