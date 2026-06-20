// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ApiManagement.Models
{
    public partial class ApiManagementBackendPatch
    {
        // Old SDK name was BackendType; generated name is TypePropertiesType
        // (from @@clientName(BackendBaseParameters.type, "typePropertiesType")).
        // Can't change that clientName because BackendBaseParameters is shared
        // with BackendContractProperties, which needs the current name.

        /// <summary> Type of the backend. A backend can be either Single or Pool. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.type")]
        public BackendType? BackendType
        {
            get => TypePropertiesType;
            set => TypePropertiesType = value;
        }
    }
}
