using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AgentFramework.Integration.Tests
{
    public class AgentFrameworkAdapterFixture<T> : IClassFixture<WebApplicationFactory<T>> where T : class
    {
        protected readonly WebApplicationFactory<T> _factory;

        public AgentFrameworkAdapterFixture(WebApplicationFactory<T> factory)
        {
            LoadEnvironmentVariables();
            _factory = factory;
        }

        private void LoadEnvironmentVariables()
        {
            var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), "environment_variables.json");
            if (File.Exists(envFilePath))
            {
                var json = File.ReadAllText(envFilePath);
                var dict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                if (dict != null)
                {
                    foreach (var kvp in dict)
                    {
                        if (!string.IsNullOrEmpty(kvp.Value))
                        {
                            Environment.SetEnvironmentVariable(kvp.Key, kvp.Value);
                        }
                    }
                }
            }
        }
    }
}
