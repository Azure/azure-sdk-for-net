// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy enum member casing aliases; @@clientName does not affect generated extensible-union value member names.
    public readonly partial struct MachineLearningEndpointAuthMode
    {
        /// <summary> Gets the AadToken. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningEndpointAuthMode AadToken => AADToken;

        /// <summary> Gets the AmlToken. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningEndpointAuthMode AmlToken => AMLToken;
    }
}
