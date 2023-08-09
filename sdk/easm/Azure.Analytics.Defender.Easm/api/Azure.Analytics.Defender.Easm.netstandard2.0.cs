namespace Azure.Analytics.Defender.Easm
{
    public partial class EasmClient
    {
        protected EasmClient() { }
        public EasmClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Defender.Easm.EasmClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class EasmClientOptions : Azure.Core.ClientOptions
    {
        public EasmClientOptions(Azure.Analytics.Defender.Easm.Generated.EasmClientOptions.ServiceVersion version = Azure.Analytics.Defender.Easm.Generated.EasmClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}