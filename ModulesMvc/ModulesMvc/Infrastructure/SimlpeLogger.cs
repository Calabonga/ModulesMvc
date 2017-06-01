using System.Diagnostics;
using ModulesContracts;

namespace ModulesMvc.Infrastructure
{
    public class SimlpeLogger: ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }

        public void Log(string message, params object[] args)
        {
            Debug.WriteLine(message, args);
        }
    }
}