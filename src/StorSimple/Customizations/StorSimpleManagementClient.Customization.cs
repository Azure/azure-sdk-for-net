using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.Azure
{
    public static class StorSimpleManagementDiscoveryExtensions
    {
        public static StorSimpleManagementClient CreateStorSimpleManagementClient(this CloudClients clients,
            SubscriptionCloudCredentials credentials)
        {
            return new StorSimpleManagementClient(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, credentials);
        }

        public static StorSimpleManagementClient CreateStorSimpleManagementClient(this CloudClients clients,
            SubscriptionCloudCredentials credentials, Uri baseUri)
        {
            return new StorSimpleManagementClient(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, credentials, baseUri);
        }

        public static StorSimpleManagementClient CreateStorSimpleManagementClient(this CloudClients clients)
        {
            return ConfigurationHelper.CreateFromSettings<StorSimpleManagementClient>(StorSimpleManagementClient.Create);
        }
    }
}

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    public partial class StorSimpleManagementClient
    {
        public static StorSimpleManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }


            SubscriptionCloudCredentials credentials =
                ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);


            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);


            return baseUri != null
                ? new StorSimpleManagementClient(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, credentials, baseUri)
                : new StorSimpleManagementClient(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, credentials);

        }

        public override StorSimpleManagementClient WithHandler(DelegatingHandler handler)
        {
            return (StorSimpleManagementClient) WithHandler(new StorSimpleManagementClient(), handler);
        }
    }
}