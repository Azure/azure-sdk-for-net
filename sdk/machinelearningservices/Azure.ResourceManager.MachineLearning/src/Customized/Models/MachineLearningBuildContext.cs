// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore URI constructor overloads whose legacy parameter shapes differ from the discriminator-first constructors emitted by TypeSpec.
    public partial class MachineLearningBuildContext
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningBuildContext"/>. </summary>
        public MachineLearningBuildContext(Uri contextUri)
        {
            ContextUri = contextUri;
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningBuildContext"/>. </summary>
        public MachineLearningBuildContext(string contextUri) : this(contextUri is null ? null : new Uri(contextUri))
        {
        }
    }
}
