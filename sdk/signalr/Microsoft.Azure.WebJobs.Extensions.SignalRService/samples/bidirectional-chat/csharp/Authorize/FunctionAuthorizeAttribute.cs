using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace FunctionApp
{
    /// <summary>
    /// It's an example to demonstrate using SignalRFilterAttribute to implement an Authorization attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    internal class FunctionAuthorizeAttribute: SignalRFilterAttribute
    {
        private const string AdminKey = "admin";

        public override Task FilterAsync(InvocationContext invocationContext, CancellationToken cancellationToken)
        {
            if (invocationContext.Claims.TryGetValue(AdminKey, out var value) &&
                bool.TryParse(value, out var isAdmin) &&
                isAdmin)
            {
                return Task.CompletedTask;
            }

            throw new Exception($"{invocationContext.ConnectionId} doesn't have admin role");
        }
    }
}
