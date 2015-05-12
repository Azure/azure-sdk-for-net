using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Azure.KeyVault.Internal
{
    public class TestKeyVaultCredential : KeyVaultCredential
    {
        public TestKeyVaultCredential(KeyVaultClient.AuthenticationCallback authenticationCallback) : base(authenticationCallback)
        {
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                return base.ProcessHttpRequestAsync(request, cancellationToken);
            }
            else
            {
                return Task.Run(() => { return; });
            }
        }
    }
}
