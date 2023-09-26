using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Castle.Core.Logging;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{
    [TestFixture]
    public class AuthenticationEventBindingTests
    {
        [Test]
        [TestCaseSource(nameof(TestPayloadScenarios))]
        public void TestRequestJsonPayload(object testObject, string message, bool success, string exceptionMessage)
        {
            Microsoft.Extensions.Logging.ILoggerFactory loggerFactory = new LoggerFactory();
            //Microsoft.Extensions.Logging.ILogger logger = loggerFactory.CreateLogger<AuthenticationEventConfigProvider>();
            AuthenticationEventConfigProvider config = new AuthenticationEventConfigProvider(loggerFactory);
            string payload = testObject.ToString();
            if (success == false)
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:7278/");
                request.Content = new StringContent(string.Empty);
                var authEventBinding = new AuthenticationEventBinding(new AuthenticationEventsTriggerAttribute(), config, null);
                var ex = Assert.Throws<RequestValidationException>(async () => await authEventBinding.BindAsync(request, null));
                Assert.AreEqual(exceptionMessage, ex.Message);
            }
            else
            {
                Assert.DoesNotThrow(() => AuthenticationEventMetadataLoader.GetEventMetadata(payload));
            }
        }

        private static IEnumerable<object[]> TestPayloadScenarios()
        {
#region Invalid
            yield return new TestCaseStructure()
            {
                Test = string.Empty,
                Message = "Testing request without payload throws an error",
                ExceptionMessage = "Invalid Type of payload"
            }.ToArray;
#endregion
        }
    }
}
