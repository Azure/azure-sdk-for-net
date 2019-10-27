// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Samples.Infrastructure.Means
{
    /// <summary>
    ///   Provides a well-known means of executing an EventHubs sample.
    /// </summary>
    ///
    public interface IIndigo
    {
        /// <summary>
        ///   Allows for executing the sample.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace"></param>
        /// <param name="eventHubName"></param>
        /// <param name="tenantId"></param>
        /// <param name="clientId"></param>
        /// <param name="secret"></param>
        ///
        public Task RunAsync(string fullyQualifiedNamespace,
                             string eventHubName,
                             string tenantId,
                             string clientId,
                             string secret);
    }
}
