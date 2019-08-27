namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public abstract class BaseTest
    {
        private const HttpRecorderMode mode = HttpRecorderMode.Playback;

        protected readonly Guid GlobalAppId = new Guid("3327b33c-35df-40d0-a661-c9ade29da239");
        protected const string GlobalVersionId = "0.1";
        protected readonly Guid GlobalAppIdError = new Guid("86226c53-b7a6-416f-876b-226b2b5ab07d");
        protected readonly Guid GlobalNoneId = new Guid("ac04c5c6-2c0c-4af8-ba3f-5db090fa7de5");
        protected const string AuthoringKey = "00000000000000000000000000000000";
        protected readonly string OwnerEmail = "a-omsami@microsoft.com";


        private Type TypeName => GetType();

        private ILUISAuthoringClient GetClient(DelegatingHandler handler)
        {
            var client = new LUISAuthoringClient(new ApiKeyServiceClientCredentials(AuthoringKey), handlers: handler);
            client.Endpoint = "https://westus.api.cognitive.microsoft.com";
            return client;

        }

        protected async void UseClientFor(Func<ILUISAuthoringClient, Task> doTest, Type typeName = null, [CallerMemberName] string methodName = "")
        {
            using (MockContext context = MockContext.Start(typeName ?? TypeName, methodName))
            {
                HttpMockServer.Initialize(typeName ?? TypeName, methodName, mode);
                ILUISAuthoringClient client = GetClient(HttpMockServer.CreateInstance());
                
                await doTest(client);
                context.Stop();
            }
        }
    }
}
