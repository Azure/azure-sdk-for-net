// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore URI constructor overloads whose legacy parameter shapes differ from the discriminator-first constructors emitted by TypeSpec.
    public partial class MachineLearningFlowModelJobInput
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningFlowModelJobInput"/>. </summary>
        public MachineLearningFlowModelJobInput(Uri uri) : base(JobInputType.MlflowModel)
        {
            Uri = uri;
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningFlowModelJobInput"/>. </summary>
        public MachineLearningFlowModelJobInput(string uri) : this(uri is null ? null : new Uri(uri))
        {
        }
    }
}
