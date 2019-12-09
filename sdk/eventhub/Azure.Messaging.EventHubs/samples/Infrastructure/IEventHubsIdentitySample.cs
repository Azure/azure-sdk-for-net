// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Samples.Infrastructure
{
    /// <summary>
    ///   Provides a well-known means of executing an EventHubsClient with Azure.Identity.
    /// </summary>
    ///
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity" />
    ///
    public interface IEventHubsIdentitySample : ISample
    {
        /// <summary>
        ///   Allows for executing the sample.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace"> The fully qualified Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that the sample should run against.</param>
        /// <param name="tenantId">The Azure Active Directory tenant that holds the service principal.</param>
        /// <param name="clientId">The Azure Active Directory client identifier of the service principal.</param>
        /// <param name="secret">The Azure Active Directory secret of the service principal.</param>
        ///
        public Task RunAsync(string fullyQualifiedNamespace,
                             string eventHubName,
                             string tenantId,
                             string clientId,
                             string secret);
    }
}
