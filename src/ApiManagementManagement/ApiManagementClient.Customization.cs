using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.Azure.Management.ApiManagement
{
    public partial class ApiManagementClient
    {
        public static ApiManagementClient Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            var credentials = ConfigurationHelper.GetCredentials<SubscriptionCloudCredentials>(settings);

            Uri baseUri = ConfigurationHelper.GetUri(settings, "BaseUri", false);

            return baseUri != null ?
                new ApiManagementClient(credentials, baseUri) :
                new ApiManagementClient(credentials);
        }

        public override ApiManagementClient WithHandler(DelegatingHandler handler)
        {
            return (ApiManagementClient)WithHandler(new ApiManagementClient(), handler);
        }
    }
}
