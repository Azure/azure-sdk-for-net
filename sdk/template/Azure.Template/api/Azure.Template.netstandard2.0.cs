namespace Azure.Template
{
    public partial class MiniSecretClient
    {
        protected MiniSecretClient() { }
        public MiniSecretClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public MiniSecretClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Template.MiniSecretsClientOptions options) { }
        public virtual Azure.Response<Azure.Template.Models.SecretBundle> GetSecret(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Template.Models.SecretBundle>> GetSecretAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MiniSecretsClientOptions : Azure.Core.ClientOptions
    {
        public MiniSecretsClientOptions(Azure.Template.MiniSecretsClientOptions.ServiceVersion version = Azure.Template.MiniSecretsClientOptions.ServiceVersion.V7_0) { }
        public enum ServiceVersion
        {
            V7_0 = 1,
        }
    }
}
namespace Azure.Template.Models
{
    public partial class SecretBundle
    {
        internal SecretBundle() { }
        public string ContentType { get { throw null; } }
        public string Id { get { throw null; } }
        public string Kid { get { throw null; } }
        public bool? Managed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } }
    }
}
