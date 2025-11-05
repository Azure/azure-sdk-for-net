using dotenv.net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AgentFramework.Integration.Tests
{
    public class AgentFrameworkAdapterFixture<T> : IClassFixture<WebApplicationFactory<T>> where T : class
    {
        protected readonly WebApplicationFactory<T> _factory;

        public AgentFrameworkAdapterFixture(WebApplicationFactory<T> factory)
        {
            DotEnv.Load();
            _factory = factory;
        }
    }
}
