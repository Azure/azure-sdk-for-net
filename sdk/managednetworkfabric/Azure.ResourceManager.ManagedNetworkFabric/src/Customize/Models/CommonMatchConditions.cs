// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class CommonMatchConditions
    {
        /// <summary> IP condition that needs to be matched. </summary>
        public IPMatchCondition IPCondition
        {
            get => IpCondition;
            set => IpCondition = value;
        }
    }
}
