// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    /// <summary> A class to add extension methods to <see cref="ArmClient"/>. </summary>
    public partial class MockableSecurityCenterArmClient
    {
        /// <summary> Gets an object representing a <see cref="AdaptiveApplicationControlGroupResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AdaptiveApplicationControlGroupResource"/> object. </returns>
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AdaptiveApplicationControlGroupResource GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        /// <summary> Gets an object representing a <see cref="AdaptiveNetworkHardeningResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="AdaptiveNetworkHardeningResource"/> object. </returns>
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AdaptiveNetworkHardeningResource GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        /// <summary> Gets an object representing a <see cref="CustomAssessmentAutomationResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CustomAssessmentAutomationResource"/> object. </returns>
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual CustomAssessmentAutomationResource GetCustomAssessmentAutomationResource(ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        /// <summary> Gets an object representing a <see cref="CustomEntityStoreAssignmentResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CustomEntityStoreAssignmentResource"/> object. </returns>
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual CustomEntityStoreAssignmentResource GetCustomEntityStoreAssignmentResource(ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        /// <summary> Gets an object representing a <see cref="SecurityCloudConnectorResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SecurityCloudConnectorResource"/> object. </returns>
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SecurityCloudConnectorResource GetSecurityCloudConnectorResource(ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
        /// <summary> Gets an object representing a <see cref="SoftwareInventoryResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SoftwareInventoryResource"/> object. </returns>
        [ForwardsClientCalls]
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SoftwareInventoryResource GetSoftwareInventoryResource(ResourceIdentifier id) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
