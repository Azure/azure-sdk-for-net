// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Deployment properties with additional details. </summary>
    [CodeGenSuppress("DebugSettingDetailLevel")]
    public partial class ArmDeploymentPropertiesExtended
    {
        /// <summary> Specifies the type of information to log for debugging. The permitted values are none, requestContent, responseContent, or both requestContent and responseContent separated by a comma. The default is none. When setting this value, carefully consider the type of information you are passing in during deployment. By logging information about the request or response, you could potentially expose sensitive data that is retrieved through the deployment operations. </summary>
        public string DebugSettingDetailLevel
        {
            get => DebugSetting?.DetailLevel;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => DebugSetting.DetailLevel = value;
        }

        /// <summary>
        /// Array of provisioned resources.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("outputResources")]
        public IReadOnlyList<SubResource> OutputResources
            => OutputResourceDetails.Select(d => ResourceManagerModelFactory.SubResource(d.Id != null ? new ResourceIdentifier(d.Id) : null)).ToArray();

        /// <summary>
        /// Array of validated resources.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("validatedResources")]
        public IReadOnlyList<SubResource> ValidatedResources
            => ValidatedResourceDetails.Select(d => ResourceManagerModelFactory.SubResource(d.Id != null ? new ResourceIdentifier(d.Id) : null)).ToArray();
    }
}
