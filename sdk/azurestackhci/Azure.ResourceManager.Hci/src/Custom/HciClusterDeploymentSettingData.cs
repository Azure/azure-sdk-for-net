// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Hci.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    [CodeGenSuppress("ArcNodeResourceIds")]
    [CodeGenSuppress("DeploymentMode")]
    public partial class HciClusterDeploymentSettingData
    {
        /// <summary> Azure resource ids of Arc machines to be part of cluster. </summary>
        [Obsolete("This property is obsolete. Use Properties.ArcNodeResourceIds with type IList<string> instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.arcNodeResourceIds")]
        public IList<ResourceIdentifier> ArcNodeResourceIds
            => throw new NotSupportedException("This property is obsolete. Use Properties.ArcNodeResourceIds instead.");

        /// <summary> The deployment mode for cluster deployment. </summary>
        [Obsolete("This property is obsolete. Use Properties.DeploymentMode with type EceDeploymentMode instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.deploymentMode")]
        public EceDeploymentMode? DeploymentMode
        {
            get => throw new NotSupportedException("This property is obsolete. Use Properties.DeploymentMode instead.");
            set => throw new NotSupportedException("This property is obsolete. Use Properties.DeploymentMode instead.");
        }
    }
}
