// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Rename generated operation parameter model that is not declared in service TypeSpec.
    [CodeGenType("PrivateLinkParameters")]
    public partial class SecurityPrivateLinkInfo
    {
        /// <summary> Converts the parameter model to the private link name. </summary>
        /// <param name="value"> The private link parameters. </param>
        public static implicit operator string(SecurityPrivateLinkInfo value) => value?.PrivateLinkName;
    }
}
