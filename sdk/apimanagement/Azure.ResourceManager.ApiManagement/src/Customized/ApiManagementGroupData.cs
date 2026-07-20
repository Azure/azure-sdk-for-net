// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementGroupData
    {
        // Old SDK property was GroupType; @@clientName(GroupContractProperties.type) renames it to
        // ApiManagementGroupType (matching the enum type name). Can't change that clientName
        // because it would break the property name on GroupContractProperties itself.

        /// <summary> Group type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.type")]
        public ApiManagementGroupType? GroupType
        {
            get => ApiManagementGroupType;
            set => ApiManagementGroupType = value;
        }
    }
}
