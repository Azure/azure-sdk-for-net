// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;

namespace Microsoft.Azure.Management.AppService.Fluent
{
    public class AppServiceManager : ManagerBase, IAppServiceManager
    {
        private IKeyVaultManager keyVaultManager;
        private string tenantId;
        private RestClient restClient;

        #region SDK clients
        private WebSiteManagementClient client;
        #endregion

        #region Fluent private collections
        private IAppServicePlans appServicePlans;
        private IWebApps webApps;
        private IAppServiceDomains appServiceDomains;
        private IAppServiceCertificates appServiceCertificates;
        private IAppServiceCertificateOrders appServiceCertificateOrders;
        #endregion

        #region ctrs

        public AppServiceManager(RestClient restClient, string subscriptionId, string tenantId) : base(restClient, subscriptionId)
        {
            client = new WebSiteManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.SubscriptionId = subscriptionId;
            keyVaultManager = KeyVaultManager.Authenticate(RestClient.Configure()
                .WithBaseUri(restClient.BaseUri)
                .WithCredentials(restClient.Credentials)
                .Build(), subscriptionId, tenantId);
            this.tenantId = tenantId;
            this.restClient = restClient;
        }

        #endregion

        #region App Service Manager builder

        public static IAppServiceManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new AppServiceManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .Build(), subscriptionId, credentials.TenantId);
        }

        public static IAppServiceManager Authenticate(RestClient restClient, string subscriptionId, string tenantId)
        {
            return new AppServiceManager(restClient, subscriptionId, tenantId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IAppServiceManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IAppServiceManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new AppServiceManager(BuildRestClient(credentials), subscriptionId, credentials.TenantId);
            }
        }

        #endregion

        #region IAppServiceManager implementation 

        public IAppServicePlans AppServicePlans
        {
            get
            {
                return null;
            }
        }

        public IWebApps WebApps
        {
            get
            {
                return null;
            }
        }

        public IAppServiceDomains AppServiceDomains
        {
            get
            {
                return null;
            }
        }

        public IAppServiceCertificates AppServiceCertificates
        {
            get
            {
                return null;
            }
        }

        public IAppServiceCertificateOrders AppServiceCertificateOrders
        {
            get
            {
                return null;
            }
        }
        
        #endregion
    }

    public interface IAppServiceManager : IManagerBase
    {
        IAppServicePlans AppServicePlans { get; }
        IWebApps WebApps { get; }
        IAppServiceDomains AppServiceDomains { get; }
        IAppServiceCertificates AppServiceCertificates { get; }
        IAppServiceCertificateOrders AppServiceCertificateOrders { get; }
    }
}
