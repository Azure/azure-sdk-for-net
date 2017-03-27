﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    public class TrafficManager : Manager<ITrafficManagerManagementClient>, ITrafficManager
    {
        #region Fluent private collections
        private ITrafficManagerProfiles profiles;
        #endregion

        public TrafficManager(RestClient restClient, string subscriptionId) : 
            base(restClient, subscriptionId, new TrafficManagerManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
        }

        #region DnsZoneManager builder

        public static ITrafficManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new TrafficManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .Build(), subscriptionId);
        }

        public static ITrafficManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new TrafficManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            ITrafficManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public ITrafficManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new TrafficManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public ITrafficManagerProfiles Profiles
        {
            get
            {
                if (profiles == null)
                {
                    profiles = new TrafficManagerProfilesImpl(this);
                }
                return profiles;
            }
        }
    }

    public interface ITrafficManager : IManager<ITrafficManagerManagementClient>
    {
        ITrafficManagerProfiles Profiles { get; }
    }
}