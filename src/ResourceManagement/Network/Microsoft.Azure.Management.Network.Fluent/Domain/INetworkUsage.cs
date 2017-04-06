// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure compute resource usage info object.
    /// </summary>
    public interface INetworkUsage  :
        IHasInner<Models.Usage>
    {
        /// <summary>
        /// Gets the unit of measurement.
        /// </summary>
        Models.NetworkUsageUnit Unit { get; }

        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the
        /// subscription.
        /// </summary>
        long Limit { get; }

        /// <summary>
        /// Gets the name of the type of usage.
        /// </summary>
        Models.UsageName Name { get; }

        /// <summary>
        /// Gets the current count of the allocated resources in the subscription.
        /// </summary>
        long CurrentValue { get; }
    }
}