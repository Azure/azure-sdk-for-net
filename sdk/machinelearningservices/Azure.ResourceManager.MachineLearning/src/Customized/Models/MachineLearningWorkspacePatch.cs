// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The parameters for updating a machine learning workspace. </summary>
    public partial class MachineLearningWorkspacePatch
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