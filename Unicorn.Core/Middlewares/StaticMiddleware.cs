using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Unicorn.Core.Middlewares
{
    public class StaticMiddleware : OwinMiddleware
    {
        public StaticMiddleware(OwinMiddleware next) : base(next)
        {
        }
        public override Task Invoke(IOwinContext context)
        {
            var response = "Hello World! It is " + DateTime.Now;
            context.Response.Write(response);
            return Next.Invoke(context);
        }
    }
}