namespace LUIS.Tests
{
    using System;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Microsoft.Azure.CognitiveServices.Language.LUIS;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public abstract class BaseTest
    {
        private const HttpRecorderMode mode = HttpRecorderMode.Playback;

        protected const AzureRegions region = AzureRegions.Westus;
        protected const string appId = "86226c53-b7a6-416f-876b-226b2b5ab07b";
        protected const string subscriptionKey = "00000000000000000000000000000000";

        private string ClassName => GetType().FullName;

        private ILuisRuntimeAPI GetClient(DelegatingHandler handler, string subscriptionKey = subscriptionKey)
        {
            return new LuisRuntimeAPI(new ApiKeyServiceClientCredentials(subscriptionKey), handlers: handler)
            {
                AzureRegion = region
            };
        }

        protected async void UseClientFor(Func<ILuisRuntimeAPI, Task> doTest, string className = null, [CallerMemberName] string methodName = "")
        {
            using (MockContext context = MockContext.Start(className ?? ClassName, methodName))
            {
                HttpMockServer.Initialize(className ?? ClassName, methodName, mode);
                ILuisRuntimeAPI client = GetClient(HttpMockServer.CreateInstance());
                await doTest(client);
                context.Stop();
            }
        }
    }
}
