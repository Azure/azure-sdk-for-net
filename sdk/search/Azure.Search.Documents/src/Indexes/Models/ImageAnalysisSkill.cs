// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Search.Documents.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenType("ImageAnalysisSkill")]
    public partial class ImageAnalysisSkill
    {
        /// <summary> A list of visual features. </summary>
        public IList<VisualFeature> VisualFeatures { get; }

        /// <summary> A string indicating which domain-specific details to return. </summary>
        public IList<ImageDetail> Details { get; }
    }
}
