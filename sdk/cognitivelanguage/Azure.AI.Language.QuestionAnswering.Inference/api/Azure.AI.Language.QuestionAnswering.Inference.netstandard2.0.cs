namespace Azure.AI.Language.QuestionAnswering.Inference
{
    public partial class InferenceClient
    {
        protected InferenceClient() { }
        public InferenceClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.QuestionAnswering.Inference.InferenceClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class InferenceClientOptions : Azure.Core.ClientOptions
    {
        public InferenceClientOptions(Azure.AI.Language.QuestionAnswering.Inference.Generated.InferenceClientOptions.ServiceVersion version = Azure.AI.Language.QuestionAnswering.Inference.Generated.InferenceClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}