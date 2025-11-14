namespace Azure.AI.Language.QuestionAnswering.Authoring
{
    public partial class AuthoringClient
    {
        protected AuthoringClient() { }
        public AuthoringClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.QuestionAnswering.Authoring.AuthoringClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class AuthoringClientOptions : Azure.Core.ClientOptions
    {
        public AuthoringClientOptions(Azure.AI.Language.QuestionAnswering.Authoring.Generated.AuthoringClientOptions.ServiceVersion version = Azure.AI.Language.QuestionAnswering.Authoring.Generated.AuthoringClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}