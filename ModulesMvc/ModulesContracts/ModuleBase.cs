using Autofac;

namespace ModulesContracts
{
    public abstract class ModuleBase : Module, IMvcModule
    {
        public virtual string Name
        {
            get { return GetType().Name; }
        }
    }
}