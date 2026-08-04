// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Cdn
{
    /// <summary>
    /// Renames the generated <c>Profile</c> resource to <c>CdnProfile</c> to avoid
    /// the AZC0012 too-generic-name analyzer warning and to preserve the public
    /// type name used by the previous (reflection-based) provisioning generator.
    /// </summary>
    [CodeGenType("Profile")]
    public partial class CdnProfile
    {
    }
}
