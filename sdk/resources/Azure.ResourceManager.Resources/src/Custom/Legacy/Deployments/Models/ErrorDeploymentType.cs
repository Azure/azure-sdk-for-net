// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> The deployment on error behavior type. Possible values are LastSuccessful and SpecificDeployment. </summary>
    [Obsolete("Use Azure.ResourceManager.Resources.Deployments.Models.ErrorDeploymentType instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ErrorDeploymentType
    {
        /// <summary> LastSuccessful. </summary>
        LastSuccessful,
        /// <summary> SpecificDeployment. </summary>
        SpecificDeployment
    }
}
