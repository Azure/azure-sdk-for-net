// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: restore the legacy tracked-resource-style constructor over the generated compute data shape.
    public partial class MachineLearningComputeData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningComputeData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningComputeData(AzureLocation location)
            : base(location)
        {
        }
    }
}
