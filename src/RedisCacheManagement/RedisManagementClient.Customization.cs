using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.Azure.Management.Redis
{
    public partial class RedisManagementClient
    {
        public static RedisManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            SubscriptionCloudCredentials credentials = ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new RedisManagementClient(credentials, baseUri) :
                new RedisManagementClient(credentials);
        }

        public override RedisManagementClient WithHandler(DelegatingHandler handler)
        {
            return (RedisManagementClient)WithHandler(new RedisManagementClient(), handler);
        }
    }
}
