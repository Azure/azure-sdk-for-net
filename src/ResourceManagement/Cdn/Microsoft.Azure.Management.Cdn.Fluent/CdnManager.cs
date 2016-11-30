// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Cdn.Fluent
{
    public class CdnManager : ManagerBase, ICdnManager
    {
        #region SDK clients
        private ICdnManagementClient client;
        #endregion

        #region Fluent private collections
        private ICdnProfiles profiles;
        #endregion


        public CdnManager(RestClient restClient, string subscriptionId) : base(restClient, subscriptionId)
        {
            client = new CdnManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.SubscriptionId = subscriptionId;
        }

        #region DnsZoneManager builder

        public static ICdnManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new CdnManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .Build(), subscriptionId);
        }

        public static ICdnManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new CdnManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            ICdnManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public ICdnManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new CdnManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public ICdnProfiles Profiles
        {
            get
            {
                if (profiles == null)
                {
                    profiles = new CdnProfilesImpl(this.client, this);
                }
                return profiles;
            }
        }
    }

    public interface ICdnManager : IManagerBase
    {
        ICdnProfiles Profiles { get; }
    }
}
