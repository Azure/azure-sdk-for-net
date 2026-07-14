// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore URI constructor overloads whose legacy parameter shapes differ from the discriminator-first constructors emitted by TypeSpec.
    public partial class MachineLearningUriFolderJobInput
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningUriFolderJobInput"/>. </summary>
        public MachineLearningUriFolderJobInput(Uri uri) : base(JobInputType.UriFolder)
        {
            Uri = uri;
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningUriFolderJobInput"/>. </summary>
        public MachineLearningUriFolderJobInput(string uri) : this(uri is null ? null : new Uri(uri))
        {
        }
    }
}
