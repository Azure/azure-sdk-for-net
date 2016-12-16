// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class ComputeUsageImpl 
    {
        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the
        /// subscription.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IComputeUsage.Limit
        {
            get
            {
                return this.Limit();
            }
        }

        /// <summary>
        /// Gets the name of the type of usage.
        /// </summary>
        Models.UsageName Microsoft.Azure.Management.Compute.Fluent.IComputeUsage.Name
        {
            get
            {
                return this.Name() as Models.UsageName;
            }
        }

        /// <summary>
        /// Gets the current count of the allocated resources in the subscription.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IComputeUsage.CurrentValue
        {
            get
            {
                return this.CurrentValue();
            }
        }

        /// <summary>
        /// Gets the unit of measurement.
        /// </summary>
        Models.ComputeUsageUnit Microsoft.Azure.Management.Compute.Fluent.IComputeUsage.Unit
        {
            get
            {
                return this.Unit() as Models.ComputeUsageUnit;
            }
        }
    }
}