namespace LUIS.Runtime.Tests
{
    using System;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public abstract class BaseTest
    {
        private const HttpRecorderMode mode = HttpRecorderMode.Playback;

        protected const string appId = "0894d430-8f00-4bcd-8153-45e06a1feca1";
        protected const string subscriptionKey = "00000000000000000000000000000000";

        private Type TypeName => GetType();

        private ILUISRuntimeClient GetClient(DelegatingHandler handler, string subscriptionKey = subscriptionKey)
        {
            var client = new LUISRuntimeClient(new ApiKeyServiceClientCredentials(subscriptionKey), handlers: handler);
            client.Endpoint = "https://westus.api.cognitive.microsoft.com";
            return client;
        }

        protected async void UseClientFor(Func<ILUISRuntimeClient, Task> doTest, Type typeName = null, [CallerMemberName] string methodName = "")
        {
            using (MockContext context = MockContext.Start(typeName ?? TypeName, methodName))
            {
                HttpMockServer.Initialize(typeName ?? TypeName, methodName, mode);
                ILUISRuntimeClient client = GetClient(HttpMockServer.CreateInstance());
                await doTest(client);
                context.Stop();
            }
        }
    }
}
