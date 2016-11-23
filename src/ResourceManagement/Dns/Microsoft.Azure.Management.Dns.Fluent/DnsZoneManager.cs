// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Dns.Fluent
{
    public class DnsZoneManager : ManagerBase, IDnsZoneManager
    {
        #region SDK clients
        private DnsManagementClient client;
        #endregion

        #region Fluent private collections
        private IDnsZones dnsZones;
        #endregion


        public DnsZoneManager(RestClient restClient, string subscriptionId)  : base(restClient, subscriptionId)
        {
            client = new DnsManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.SubscriptionId = subscriptionId;
        }

        #region DnsZoneManager builder

        public static IDnsZoneManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new DnsZoneManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .Build(), subscriptionId);
        }

        public static IDnsZoneManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new DnsZoneManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IDnsZoneManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IDnsZoneManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new DnsZoneManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public IDnsZones Zones
        {
            get
            {
                if (dnsZones == null)
                {
                    dnsZones = new DnsZonesImpl(this.client, this);
                }
                return dnsZones;
            }
        }
    }

    public interface IDnsZoneManager : IManagerBase
    {
        IDnsZones Zones { get; }
    }
}
