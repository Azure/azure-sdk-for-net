// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy enum member casing alias; @@clientName does not affect generated extensible-union value member names.
    public readonly partial struct ImageType
    {
        /// <summary> Gets the AzureML. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ImageType AzureML => Azureml;
    }
}
