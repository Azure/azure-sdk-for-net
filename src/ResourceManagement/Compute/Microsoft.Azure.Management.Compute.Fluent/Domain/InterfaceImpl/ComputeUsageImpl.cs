// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class ComputeUsageImpl
    {
        /// <return>
        /// The maximum count of the resources that can be allocated in the
        /// subscription.
        /// </return>
        int Microsoft.Azure.Management.Compute.Fluent.IComputeUsage.Limit
        {
            get
            {
                return this.Limit();
            }
        }

        /// <return>The name of the type of usage.</return>
        Models.UsageName Microsoft.Azure.Management.Compute.Fluent.IComputeUsage.Name
        {
            get
            {
                return this.Name() as Models.UsageName;
            }
        }

        /// <return>The current count of the allocated resources in the subscription.</return>
        int Microsoft.Azure.Management.Compute.Fluent.IComputeUsage.CurrentValue
        {
            get
            {
                return this.CurrentValue();
            }
        }

        /// <return>The unit of measurement.</return>
        Models.ComputeUsageUnit Microsoft.Azure.Management.Compute.Fluent.IComputeUsage.Unit
        {
            get
            {
                return this.Unit() as Models.ComputeUsageUnit;
            }
        }
    }
}