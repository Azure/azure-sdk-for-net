using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.Azure.Management.RedisCache
{
    public partial class RedisCacheManagementClient
    {
        public static RedisCacheManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            SubscriptionCloudCredentials credentials = ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new RedisCacheManagementClient(credentials, baseUri) :
                new RedisCacheManagementClient(credentials);
        }

        public override RedisCacheManagementClient WithHandler(DelegatingHandler handler)
        {
            return (RedisCacheManagementClient)WithHandler(new RedisCacheManagementClient(), handler);
        }
    }
}
