using ModulesContracts;

namespace ModulesMvc.Infrastructure.Modules
{
    public class InternalModule : ModuleBase
    {
        public override string Name
        {
            get { return GetType().Name; }
        }
    }
}