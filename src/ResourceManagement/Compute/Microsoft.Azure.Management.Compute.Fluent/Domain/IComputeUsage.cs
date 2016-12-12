// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure compute resource usage info object.
    /// </summary>
    public interface IComputeUsage :
        IWrapper<Models.Usage>          // Note: C# AutoRest code gen is not generating UsageInner so
                                        // changing IWrapper<Models.UsageInner> -> IWrapper<Models.Usage>
    {
        /// <return>The unit of measurement.</return>
        Models.ComputeUsageUnit Unit { get; }

        /// <return>
        /// The maximum count of the resources that can be allocated in the
        /// subscription.
        /// </return>
        int Limit { get; }

        /// <return>The name of the type of usage.</return>
        Models.UsageName Name { get; }

        /// <return>The current count of the allocated resources in the subscription.</return>
        int CurrentValue { get; }
    }
}