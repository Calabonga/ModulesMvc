using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ModulesContracts;

namespace ModulesMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEnumerable<ICalculatorOperation> _operations;
        private const int X = 12;
        private const int Y = 41;

        public HomeController(ILogger logger, IEnumerable<ICalculatorOperation> operations)
        {
            _logger = logger;
            _operations = operations;
        }

        public ActionResult Index()
        {
            var modules = DependencyResolver.Current.GetServices<IMvcModule>();
            _logger.Log("Loaded {0} modules", modules.Count());
            return View(modules);
        }

        public ActionResult Calculator()
        {
            _logger.Log("Calculator loaded...");
            ViewBag.X = X;
            ViewBag.Y = Y;
            ViewBag.Operations = _operations;
            return View();
        }

        [HttpPost]
        [ActionName("Calculator")]
        public ActionResult CalculatorExecute(int x, int y, string operation)
        {
            if (string.IsNullOrEmpty(operation)) throw new NullReferenceException("operation is null");
            var method = _operations.SingleOrDefault(m => m.Name == operation);

            if (method != null)
            {
                ViewBag.Operations = _operations;
                var summa = method.Calculate(x, y);
                _logger.Log("The result of the operations {2} {0} {3} is {1}", method.Name, summa, x, y);
            }
            ViewBag.X = x;
            ViewBag.Y = y;
            return View();
        }
    }
}