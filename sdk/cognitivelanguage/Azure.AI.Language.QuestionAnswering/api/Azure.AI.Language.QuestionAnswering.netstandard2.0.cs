namespace Azure.AI.Language.QuestionAnswering
{
    public partial class QuestionAnsweringClient
    {
        protected QuestionAnsweringClient() { }
        public QuestionAnsweringClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class QuestionAnsweringClientOptions : Azure.Core.ClientOptions
    {
        public QuestionAnsweringClientOptions(Azure.AI.Language.QuestionAnswering.Generated.QuestionAnsweringClientOptions.ServiceVersion version = Azure.AI.Language.QuestionAnswering.Generated.QuestionAnsweringClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}