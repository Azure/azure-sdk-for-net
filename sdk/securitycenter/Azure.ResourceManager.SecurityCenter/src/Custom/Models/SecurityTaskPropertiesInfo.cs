// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class SecurityTaskPropertiesInfo
    {
        // SecurityTaskData exposes SecurityTaskParameters as a settable flattened GA property. The
        // generated properties container is internal and output-shaped, so this targeted setter lets
        // the flattened custom property round-trip without broadening TypeSpec model usage.
        /// <summary> Changing set of properties, depending on the task type that is derived from the name field. </summary>
        public SecurityTaskProperties SecurityTaskParameters { get; set; }
    }
}
