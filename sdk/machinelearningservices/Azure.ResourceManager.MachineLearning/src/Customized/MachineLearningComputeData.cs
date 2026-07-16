// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: restore the GA location-only constructor; without it ApiCompat treats the generated
    // TypeSpec model as effectively sealed because it only has an internal deserialization constructor.
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
