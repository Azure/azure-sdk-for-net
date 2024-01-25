// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.MachineLearning.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A class representing the MachineLearningWorkspace data model.
    /// An object that represents a machine learning workspace.
    /// </summary>
    public partial class MachineLearningWorkspaceData : TrackedResourceData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPublicNetworkAccess? PublicNetworkAccess
        {
            get
            {
                return PublicNetworkAccessType.ToString();
            }
            set
            {
                PublicNetworkAccessType = value.ToString();
            }
        }
    }
}
