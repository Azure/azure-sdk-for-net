using Microsoft.WindowsAzure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Microsoft.Azure.Management.WebSites
{
    public partial class WebSiteManagementClient
    {
        /// <summary>
        /// Get an instance of the EventsClient class that uses the handler while initiating web requests.
        /// </summary>
        /// <param name="handler">the handler</param>
        public override WebSiteManagementClient WithHandler(DelegatingHandler handler)
        {
            return WithHandler(new WebSiteManagementClient(), handler);
        }

        protected override void Clone(ServiceClient<WebSiteManagementClient> client)
        {
            base.Clone(client);

            WebSiteManagementClient webSiteManagementClient = client as WebSiteManagementClient;
            if (webSiteManagementClient != null)
            {
                webSiteManagementClient._credentials = Credentials;
                webSiteManagementClient._baseUri = BaseUri;
                webSiteManagementClient.Credentials.InitializeServiceClient(webSiteManagementClient);
            }
        }
    }
}
