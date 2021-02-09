// ------------------------------------------------------------------------------------------------
// <copyright file="ClientFactory.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace DnsResolver.Tests.Helpers
{
    using Microsoft.Azure.Management.DnsResolver;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;

    public static class ClientFactory
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler">Delegating Handler to get the client.</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static ResourceManagementClient GetResourcesClient(
            MockContext context,
            RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        /// <summary>
        /// Default constructor for management clients using the TestSupport Infrastructure.
        /// </summary>
        /// <param name="handler">Delegating Handler to get the client.</param>
        /// <returns>A DnsResolver management client, created from the current context (environment variables)</returns>
        public static DnsResolverManagementClient GetDnsResolverClient(
            MockContext context,
            RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<DnsResolverManagementClient>(handlers: handler);
            return client;
        }

        /// <summary> 
        /// Default constructor for Network management clients,
        ///  using the TestSupport Infrastructure
        /// </summary>
        /// <param name="handler">Delegating Handler to get the client.</param>
        /// <returns>A Network management client, created from the current context (environment variables)</returns>
        public static NetworkManagementClient GetNetworkClient(
            MockContext context,
            RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;

            var nrpSimulatorUri = Environment.GetEnvironmentVariable(Constants.NrpSimulatorUriEnvironmentVariableName);

            // If there environment variable does not present, uses the default nrp client uri.
            if (string.IsNullOrEmpty(nrpSimulatorUri))
            {
                return context.GetServiceClient<NetworkManagementClient>(handlers: handler);
            }
            else 
            {
                var testEnv = TestEnvironmentFactory.GetTestEnvironment();
                var credentials = testEnv.TokenInfo[TokenAudience.Graph];
                var client = context.GetServiceClientWithCredentials<NetworkManagementClient>(testEnv, credentials, new Uri(nrpSimulatorUri), internalBaseUri: false, handlers: handler);
                return client;
            }
        }
    }
}