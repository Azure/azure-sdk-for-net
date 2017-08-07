// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    internal partial class UsageImpl 
    {
        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in the
        /// subscription.
        /// </summary>
        int Microsoft.Azure.Management.Storage.Fluent.IStorageUsage.Limit
        {
            get
            {
                return this.Limit();
            }
        }

        /// <summary>
        /// Gets the name of the type of usage.
        /// </summary>
        Models.UsageName Microsoft.Azure.Management.Storage.Fluent.IStorageUsage.Name
        {
            get
            {
                return this.Name() as Models.UsageName;
            }
        }

        /// <summary>
        /// Gets the current count of the allocated resources in the subscription.
        /// </summary>
        int Microsoft.Azure.Management.Storage.Fluent.IStorageUsage.CurrentValue
        {
            get
            {
                return this.CurrentValue();
            }
        }

        /// <summary>
        /// Gets the unit of measurement. Possible values include: 'Count',
        /// 'Bytes', 'Seconds', 'Percent', 'CountsPerSecond', 'BytesPerSecond'.
        /// </summary>
        Models.UsageUnit Microsoft.Azure.Management.Storage.Fluent.IStorageUsage.Unit
        {
            get
            {
                return this.Unit();
            }
        }
    }
}