// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;

namespace Microsoft.Azure
{
    /// <summary>
    /// Base class for credentials associated with a particular subscription.
    /// </summary>
    public abstract class SubscriptionCloudCredentials
        : ServiceClientCredentials
    {
        /// <summary>
        /// Gets subscription ID which uniquely identifies Microsoft Azure 
        /// subscription. The subscription ID forms part of the URI for 
        /// every call that you make to the Service Management API.
        /// </summary>
        public abstract string SubscriptionId { get; }
    }
}
