using System.Diagnostics;
using System.Web;

namespace LogServiceModule
{
    public class HtmlTraceListener : ITraceListener
    {
        private readonly HttpContextBase _context;

        public HtmlTraceListener(HttpContextBase context)
        {
            _context = context;
        }

        public void Write(string message)
        {
            _context.Response.Write(message);
        }

        public void WriteLine(string message)
        {
            _context.Response.Write(string.Concat(message,"<br/>"));
        }
    }
}