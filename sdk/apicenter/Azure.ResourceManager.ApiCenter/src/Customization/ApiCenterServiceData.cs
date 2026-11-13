// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.ApiCenter.Models;

namespace Azure.ResourceManager.ApiCenter
{
    /*
     * Backward-compatibility shim for the ApiCenterServiceData.
     *
     * In the 1.0.0 GA release (AutoRest-generated), the generator "flattened"
     * ServiceProperties.ProvisioningState into ApiCenterServiceData as a direct property
     * named ApiCenterServiceProvisioningState, and kept the Properties property as internal.
     *
     * After migrating to the TypeSpec MPG generator, the Properties property is now public
     * (exposing ApiCenterServiceProperties), but the flattened ProvisioningState accessor
     * is no longer generated.
     *
     * This custom property preserves the old flattened access pattern for 1.0.0 GA backward
     * compatibility. Users can access ProvisioningState either via this property or via
     * the new Properties.ProvisioningState path.
     */
    public partial class ApiCenterServiceData
    {
        /// <summary>
        /// Provisioning state of the service.
        /// <para>Backward-compat: In old AutoRest-generated code, this was a generated property that
        /// flattened Properties.ProvisioningState onto the data class directly. The new MPG
        /// generator exposes Properties as public but does not generate this flattened accessor.</para>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ApiCenterProvisioningState? ApiCenterServiceProvisioningState
        {
            get => Properties?.ProvisioningState;
        }
    }
}
