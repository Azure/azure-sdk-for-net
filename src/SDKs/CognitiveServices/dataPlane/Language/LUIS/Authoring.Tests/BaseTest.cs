namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public abstract class BaseTest
    {
        private const HttpRecorderMode mode = HttpRecorderMode.Playback;

        protected readonly Guid appId = new Guid("86226c53-b7a6-416f-876b-226b2b5ab07b");
        protected readonly Guid appId_error = new Guid("86226c53-b7a6-416f-876b-226b2b5ab07d");
        protected readonly Guid noneId = new Guid("76c92d38-2e8e-46f0-9645-5c5040c1bab1");
        protected const string subscriptionKey = "00000000000000000000000000000000";

        private string ClassName => GetType().FullName;

        private ILUISAuthoringClient GetClient(DelegatingHandler handler)
        {
            var client = new LUISAuthoringClient(new ApiKeyServiceClientCredentials(subscriptionKey), handlers: handler);
            client.Endpoint = "https://westus.api.cognitive.microsoft.com";
            return client;

        }

        protected async void UseClientFor(Func<ILUISAuthoringClient, Task> doTest, string className = null, [CallerMemberName] string methodName = "")
        {
            using (MockContext context = MockContext.Start(className ?? ClassName, methodName))
            {
                HttpMockServer.Initialize(className ?? ClassName, methodName, mode);
                ILUISAuthoringClient client = GetClient(HttpMockServer.CreateInstance());
                
                await doTest(client);
                context.Stop();
            }
        }
    }
}
