// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.ApiCenter.Models;

namespace Azure.ResourceManager.ApiCenter
{
    public partial class ApiCenterServiceData
    {
        /// <summary> Provisioning state of the service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ApiCenterProvisioningState? ApiCenterServiceProvisioningState
        {
            get => Properties?.ProvisioningState;
        }
    }
}
