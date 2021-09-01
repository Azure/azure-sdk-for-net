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

        protected readonly Guid GlobalAppId = new Guid("87c4b1be-ad31-42cd-9906-2faf9cb6e5cd");
        protected const string GlobalVersionId = "0.1";
        protected readonly Guid GlobalAppIdError = new Guid("86226c53-b7a6-416f-876b-226b2b5ab07d");
        protected readonly Guid GlobalNoneId = new Guid("19cda7e1-5c22-4b9b-bbb2-2a1a47c94a41");
        protected const string AuthoringKey = "321c7c949ed745bf987b80702945c694";
        protected readonly string OwnerEmail = "a-xxxx@microsoft.com";


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
