namespace Azure.Quantum.Jobs
{
    public partial class QuantumJobsClient
    {
        protected QuantumJobsClient() { }
        public QuantumJobsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public QuantumJobsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Quantum.Jobs.QuantumJobsClientOptions options) { }
        public virtual Azure.Response<Azure.Quantum.Jobs.Models.SecretBundle> GetSecret(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Quantum.Jobs.Models.SecretBundle>> GetSecretAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuantumJobsClientOptions : Azure.Core.ClientOptions
    {
        public QuantumJobsClientOptions(Azure.Quantum.Jobs.QuantumJobsClientOptions.ServiceVersion version = Azure.Quantum.Jobs.QuantumJobsClientOptions.ServiceVersion.V7_0) { }
        public enum ServiceVersion
        {
            V7_0 = 1,
        }
    }
}
namespace Azure.Quantum.Jobs.Models
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
