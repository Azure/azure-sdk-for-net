using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

[assembly: FunctionsStartup(typeof(FunctionApp.Startup))]
namespace FunctionApp
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
            };
        }
    }
}
