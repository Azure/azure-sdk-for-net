﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Dns.Fluent
{
    public class DnsZoneManager : Manager<IDnsManagementClient>, IDnsZoneManager
    {
        #region Fluent private collections
        private IDnsZones dnsZones;
        #endregion


        public DnsZoneManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new DnsManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
        }

        #region DnsZoneManager builder

        public static IDnsZoneManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new DnsZoneManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
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
                    dnsZones = new DnsZonesImpl(this);
                }
                return dnsZones;
            }
        }
    }

    public interface IDnsZoneManager : IManager<IDnsManagementClient>
    {
        IDnsZones Zones { get; }
    }
}
