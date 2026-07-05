// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.IotOperations.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.IotOperations
{
    public partial class IotOperationsAkriConnectorData : ResourceData
    {
        /// <summary> The status of the last operation. </summary>
        public IotOperationsProvisioningState? IotOperationsAkriConnectorProvisioningState
        {
            get => Properties is null ? default : Properties.ProvisioningState;
        }
    }
}
