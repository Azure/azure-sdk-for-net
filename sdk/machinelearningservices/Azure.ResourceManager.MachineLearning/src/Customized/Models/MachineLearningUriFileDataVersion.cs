// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore URI constructor overloads whose legacy parameter shapes differ from the discriminator-first constructors emitted by TypeSpec.
    public partial class MachineLearningUriFileDataVersion
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningUriFileDataVersion"/>. </summary>
        public MachineLearningUriFileDataVersion(Uri dataUri) : base(MachineLearningDataType.UriFile, dataUri)
        {
        }
    }
}
