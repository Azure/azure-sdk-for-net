namespace AzureSamples.Security.KeyVault.Proxy
{
    public partial class KeyVaultProxy : Azure.Core.Pipeline.HttpPipelinePolicy, System.IDisposable
    {
        public KeyVaultProxy(System.TimeSpan? ttl = default(System.TimeSpan?)) { }
        public System.TimeSpan Ttl { get { throw null; } }
        public void Clear() { }
        public override void Process(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { throw null; }
        void System.IDisposable.Dispose() { }
    }
}
