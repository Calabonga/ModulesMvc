using Autofac.Core;

namespace ModulesContracts
{
    public interface IMvcModule: IModule
    {
        string Name { get; } 
    }
}