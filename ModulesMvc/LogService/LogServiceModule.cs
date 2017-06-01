using System;
using System.Web;
using Autofac;
using ModulesContracts;

namespace LogServiceModule
{
    public class LogServiceModule : ModuleBase, ILogger
    {
        private readonly HttpContextBase _context;

        public LogServiceModule(HttpContextBase context)
        {
            _context = context;
        }

        public void Log(string message)
        {
            LogInternal(message);
        }

        public void Log(string message, params object[] args)
        {
            LogInternal(string.Format(message, args));
        }

        private void LogInternal(string message)
        {
            var result = string.Format("<p><b>{0}></b>: {1}</p>", DateTime.Now, message);

            if (_context.IsDebuggingEnabled)
            {
                _context.Response.Output.WriteLineAsync(result);
            }
        }

        public override string ToString()
        {
            return "Log service for system messages";
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogServiceModule>().As<ILogger>().PreserveExistingDefaults();
            builder.RegisterType<HtmlTraceListener>().As<ITraceListener>();
        }
    }
}
