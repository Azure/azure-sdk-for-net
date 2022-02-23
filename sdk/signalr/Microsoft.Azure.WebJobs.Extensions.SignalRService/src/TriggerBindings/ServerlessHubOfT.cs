// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "https://github.com/Azure/azure-sdk-for-net/issues/17164")]
    public abstract class ServerlessHub<T> where T : class
    {
        private static readonly Lazy<JwtSecurityTokenHandler> JwtSecurityTokenHandler = new(() => new());
        private readonly ServiceHubContext<T> _hubContext;

        /// <summary>
        /// Gets an object that can be used to invoke methods on the clients connected to this hub.
        /// </summary>
        public IHubClients<T> Clients => _hubContext.Clients;

        /// <summary>
        /// Get the group manager of this hub.
        /// </summary>
        public GroupManager Groups => _hubContext.Groups;

        /// <summary>
        /// Get the user group manager of this hub.
        /// </summary>
        public UserGroupManager UserGroups => _hubContext.UserGroups;

        /// <summary>
        /// Get the client manager of this hub.
        /// </summary>
        public ClientManager ClientManager => _hubContext.ClientManager;

        /// <summary>
        /// Get the name of the hub.
        /// </summary>
        public string HubName => GetType().Name;

        /// <summary>
        /// Initializes an instance of serverless hub. This constructor is ususally used in test codes.
        /// </summary>
        /// <param name="serviceHubContext">Injects a service hub context.</param>
        protected ServerlessHub(ServiceHubContext<T> serviceHubContext)
        {
            _hubContext = serviceHubContext ?? throw new ArgumentNullException(nameof(serviceHubContext));
        }

        /// <summary>
        /// Initializes an instance of serverless hub and let the SignalR extension to handle the intialization job. Please use this constructor in your functions production codes.
        /// </summary>
        protected ServerlessHub()
        {
            _hubContext = GetHubContext(StaticServiceHubContextStore.ServiceManagerStore);
        }

        // test only
        internal ServerlessHub(IServiceManagerStore serviceManagerStore)
        {
            _hubContext = GetHubContext(serviceManagerStore);
        }

        /// <summary>
        /// Gets client endpoint access information object for SignalR hub connections to connect to Azure SignalR Service
        /// </summary>
        protected async Task<SignalRConnectionInfo> NegotiateAsync(NegotiationOptions options)
        {
            var negotiateResponse = await _hubContext.NegotiateAsync(options).ConfigureAwait(false);
            return new SignalRConnectionInfo
            {
                Url = negotiateResponse.Url,
                AccessToken = negotiateResponse.AccessToken
            };
        }

        /// <summary>
        /// Get claim list from a JWT.
        /// </summary>
        protected IList<Claim> GetClaims(string jwt)
        {
            if (jwt.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                jwt = jwt.Substring("Bearer ".Length).Trim();
            }
            return JwtSecurityTokenHandler.Value.ReadJwtToken(jwt).Claims.ToList();
        }

        private ServiceHubContext<T> GetHubContext(IServiceManagerStore serviceManagerStore)
        {
            var connectionName = SignalRTriggerUtils.GetConnectionNameFromAttribute(GetType()) ?? Constants.AzureSignalRConnectionStringName;
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            return serviceManagerStore.GetOrAddByConnectionStringKey(connectionName).GetAsync<T>(HubName).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }
    }
}
