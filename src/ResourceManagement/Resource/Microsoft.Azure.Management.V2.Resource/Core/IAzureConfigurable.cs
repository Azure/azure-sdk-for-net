using Microsoft.Rest.TransientFaultHandling;
using System.Net.Http;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public interface IAzureConfigurable<T> where T : IAzureConfigurable<T>
    {
        T withUserAgent(string product, string version);
        T withRetryPolicy(RetryPolicy retryPolicy);
        T withDelegatingHandler(DelegatingHandler delegatingHandler);
        T withLogLevel(HttpLoggingDelegatingHandler.Level level);
    }
}
