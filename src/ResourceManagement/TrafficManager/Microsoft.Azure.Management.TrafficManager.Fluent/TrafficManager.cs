using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.TrafficManager.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    public class TrafficManager : ManagerBase, ITrafficManager
    {
        #region SDK clients
        private ITrafficManagerManagementClient client;
        #endregion

        #region Fluent private collections
        private ITrafficManagerProfiles profiles;
        #endregion


        public TrafficManager(RestClient restClient, string subscriptionId) : base(restClient, subscriptionId)
        {
            client = new TrafficManagerManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.SubscriptionId = subscriptionId;
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
                    profiles = new TrafficManagerProfilesImpl(this.client, this);
                }
                return profiles;
            }
        }
    }

    public interface ITrafficManager : IManagerBase
    {
        ITrafficManagerProfiles Profiles { get; }
    }
}