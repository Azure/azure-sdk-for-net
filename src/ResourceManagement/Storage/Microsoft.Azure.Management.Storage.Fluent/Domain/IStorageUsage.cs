// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure storage resource usage info object.
    /// </summary>
    public interface IStorageUsage  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.Usage>
    {
        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the
        /// subscription.
        /// </summary>
        int Limit { get; }

        /// <summary>
        /// Gets the unit of measurement. Possible values include: 'Count',
        /// 'Bytes', 'Seconds', 'Percent', 'CountsPerSecond', 'BytesPerSecond'.
        /// </summary>
        Models.UsageUnit Unit { get; }

        /// <summary>
        /// Gets the name of the type of usage.
        /// </summary>
        Models.UsageName Name { get; }

        /// <summary>
        /// Gets the current count of the allocated resources in the subscription.
        /// </summary>
        int CurrentValue { get; }
    }
}