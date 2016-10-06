// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Resource.Fluent.Core;
    /// <summary>
    /// An immutable client-side representation of an Azure storage resource usage info object.
    /// </summary>
    public interface IStorageUsage  :
        IWrapper<Management.Storage.Fluent.Models.UsageInner>
    {
        /// <returns>the unit of measurement. Possible values include: 'Count',</returns>
        /// <returns>'Bytes', 'Seconds', 'Percent', 'CountsPerSecond', 'BytesPerSecond'.</returns>
        Management.Storage.Fluent.Models.UsageUnit Unit { get; }

        /// <returns>the current count of the allocated resources in the subscription</returns>
        int CurrentValue { get; }

        /// <returns>the maximum count of the resources that can be allocated in the</returns>
        /// <returns>subscription</returns>
        int Limit { get; }

        /// <returns>the name of the type of usage</returns>
        Management.Storage.Fluent.Models.UsageName Name { get; }

    }
}