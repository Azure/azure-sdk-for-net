// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy enum member casing aliases; @@clientName does not affect generated extensible-union value member names.
    public readonly partial struct MachineLearningStorageAccountType
    {
        /// <summary> Gets the PremiumLrs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningStorageAccountType PremiumLrs => PremiumLRS;

        /// <summary> Gets the StandardLrs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningStorageAccountType StandardLrs => StandardLRS;
    }
}
