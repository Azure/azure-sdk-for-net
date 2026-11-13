// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Compute.Recommender.Models
{
    public partial class ComputeRecommenderGenerateContent
    {
        /// <summary> Initializes a new instance of <see cref="ComputeRecommenderGenerateContent"/>. </summary>
        public ComputeRecommenderGenerateContent() : this(Array.Empty<ComputeRecommenderResourceSize>())
        {
        }
    }
}
