// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// When a class derived from <see cref="ServerlessHub"/>,
    /// all the methods in the class are identified as using class based model.
    /// <b>HubName</b> is resolved from class name.
    /// <b>Event</b> is resolved from method name.
    /// <b>Category</b> is determined by the method name. Only <b>OnConnected</b> and <b>OnDisconnected</b> will
    /// be considered as Connections and others will be Messages.
    /// <b>ParameterNames</b> will be automatically resolved by all the parameters of the method in order, except the
    /// parameter which belongs to a binding parameter, or has the type of <see cref="Microsoft.Extensions.Logging.ILogger"/> or
    /// <see cref="System.Threading.CancellationToken"/>, or marked by <see cref="SignalRIgnoreAttribute"/>.
    /// Note that <see cref="SignalRTriggerAttribute"/> MUST use parameterless constructor in class based model.
    /// </summary>
    public abstract class ServerlessHub : IDisposable
    {
        private static readonly Lazy<JwtSecurityTokenHandler> JwtSecurityTokenHandler = new Lazy<JwtSecurityTokenHandler>(() => new JwtSecurityTokenHandler());
        private bool _disposed;

        /// <summary>
        /// Might be converted from <see cref="IServiceHubContext"/>, don't forget to test null before use it.
        /// </summary>
        private readonly ServiceHubContext _hubContext;
        private readonly IServiceManager _serviceManager;

        /// <summary>
        /// Leave the parameters to be null when called by Azure Function infrastructure.
        /// Or you can pass in your parameters in testing.
        /// </summary>
        protected ServerlessHub(IServiceHubContext hubContext = null, IServiceManager serviceManager = null)
        {
            var hubContextAttribute = GetType().GetCustomAttribute<SignalRConnectionAttribute>(true);
            var connectionString = hubContextAttribute?.Connection ?? Constants.AzureSignalRConnectionStringName;
            HubName = GetType().Name;
            hubContext = hubContext ?? StaticServiceHubContextStore.Get(connectionString).GetAsync(HubName).GetAwaiter().GetResult();
            _serviceManager = serviceManager ?? StaticServiceHubContextStore.Get(connectionString).ServiceManager;
            Clients = hubContext.Clients;
            Groups = hubContext.Groups;
            UserGroups = hubContext.UserGroups;
            _hubContext = hubContext as ServiceHubContext;
            ClientManager = _hubContext?.ClientManager;
        }

        /// <summary>
        /// Customized settings to be passed into the serverless hub context.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        protected internal class SignalRConnectionAttribute : Attribute, IConnectionProvider
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SignalRConnectionAttribute"/> class.
            /// </summary>
            /// <param name="connectionStringSetting">Gets or sets the app setting name that contains the Azure SignalR connection string.</param>
            public SignalRConnectionAttribute(string connectionStringSetting)
            {
                Connection = connectionStringSetting;
            }

            /// <summary>
            /// Gets or sets the app setting name that contains the Azure SignalR connection string.
            /// </summary>
            public string Connection { get; set; } = Constants.AzureSignalRConnectionStringName;
        }

        /// <summary>
        /// Gets an object that can be used to invoke methods on the clients connected to this hub.
        /// </summary>
        public IHubClients Clients { get; }

        /// <summary>
        /// Get the group manager of this hub.
        /// </summary>
        public IGroupManager Groups { get; }

        /// <summary>
        /// Get the user group manager of this hub.
        /// </summary>
        public IUserGroupManager UserGroups { get; }

        /// <summary>
        /// Get the client manager of this hub.
        /// </summary>
        public ClientManager ClientManager { get; }

        /// <summary>
        /// Get the hub name of this hub.
        /// </summary>
        public string HubName { get; }

        /// <summary>
        /// Gets client endpoint access information object for SignalR hub connections to connect to Azure SignalR Service
        /// </summary>
        protected SignalRConnectionInfo Negotiate(string userId = null, IList<Claim> claims = null, TimeSpan? lifetime = null)
        {
            return NegotiateAsync(new NegotiationOptions
            {
                UserId = userId,
                Claims = claims,
                TokenLifetime = lifetime.GetValueOrDefault(TimeSpan.FromHours(1))
            }).Result;
        }

        /// <summary>
        /// Gets client endpoint access information object for SignalR hub connections to connect to Azure SignalR Service
        /// </summary>
        protected async Task<SignalRConnectionInfo> NegotiateAsync(NegotiationOptions options)
        {
            if (_hubContext != null)
            {
                var negotiateResponse = await _hubContext.NegotiateAsync(options).ConfigureAwait(false);
                return new SignalRConnectionInfo
                {
                    Url = negotiateResponse.Url,
                    AccessToken = negotiateResponse.AccessToken
                };
            }
            else
            {
                //fall back to single endpoint negotiation
                return new SignalRConnectionInfo
                {
                    Url = _serviceManager.GetClientEndpoint(HubName),
                    AccessToken = _serviceManager.GenerateClientAccessToken(HubName, options.UserId, options.Claims, options.TokenLifetime)
                };
            }
        }

        /// <summary>
        /// Get claim list from a JWT.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Breaking change")]
        protected IList<Claim> GetClaims(string jwt)
        {
            if (jwt.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                jwt = jwt.Substring("Bearer ".Length).Trim();
            }
            return JwtSecurityTokenHandler.Value.ReadJwtToken(jwt).Claims.ToList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposed = true;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}