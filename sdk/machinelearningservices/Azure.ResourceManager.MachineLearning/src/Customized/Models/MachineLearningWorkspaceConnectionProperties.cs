// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary>
    /// The MachineLearningWorkspaceConnectionProperties.
    /// Please note <see cref="MachineLearningWorkspaceConnectionProperties"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="MachineLearningManagedIdentityAuthTypeWorkspaceConnection"/>, <see cref="MachineLearningNoneAuthTypeWorkspaceConnection"/>, <see cref="MachineLearningPatAuthTypeWorkspaceConnection"/>, <see cref="MachineLearningSasAuthTypeWorkspaceConnection"/> and <see cref="MachineLearningUsernamePasswordAuthTypeWorkspaceConnection"/>.
    /// </summary>
    public abstract partial class MachineLearningWorkspaceConnectionProperties
    {
        /// <summary> Value details of the workspace connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Value { get; set; }
        /// <summary> format for the workspace connection value. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningValueFormat? ValueFormat { get; set; }
    }
}
