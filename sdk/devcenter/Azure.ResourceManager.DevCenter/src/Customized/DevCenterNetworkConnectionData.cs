// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.DevCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DevCenter
{
    // Backward compatibility: DomainJoinType was Nullable in the baseline SDK
    public partial class DevCenterNetworkConnectionData
    {
        /// <summary> AAD Join type. </summary>
        public DomainJoinType? DomainJoinType
        {
            get
            {
                return Properties is null ? default(DomainJoinType?) : Properties.DomainJoinType;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkProperties();
                }
                if (value.HasValue)
                {
                    Properties.DomainJoinType = value.Value;
                }
            }
        }
    }
}
