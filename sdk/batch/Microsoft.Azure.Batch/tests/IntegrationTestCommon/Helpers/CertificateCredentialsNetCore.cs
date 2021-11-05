using Microsoft.Rest;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Batch.IntegrationTestCommon.Tests.Helpers
{
#if !FullNetFx
    /// <summary>
    /// Work around due being unavailable in .netcore
    /// </summary>
    class CertificateCredentialsNetCore : ServiceClientCredentials
    {
        private readonly X509Certificate2 cert;
        public CertificateCredentialsNetCore(X509Certificate2 cert)
        {
            this.cert = cert;
        }
        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
            HttpClientHandler handler = client.HttpMessageHandlers.FirstOrDefault(h => h is HttpClientHandler) as HttpClientHandler;
            handler.ClientCertificates.Add(cert);
        }
    }
#endif
}
