// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore constructor overloads for legacy parameter ordering and formerly public simple constructors that TypeSpec generation normalized.
    public partial class MachineLearningJobProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningJobProperties"/>. </summary>
        public MachineLearningJobProperties()
            : this(default)
        {
        }
    }
}
