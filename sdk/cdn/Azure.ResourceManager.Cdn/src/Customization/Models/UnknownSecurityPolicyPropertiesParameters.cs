// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    // we have this customization because despite this is an internal class
    // it is still used as a parameter in an attribute, therefore its name should not change
    // comparing with the last stable release.
    // this customization is changing the name back.
    [CodeGenModel("UnknownSecurityPolicyPropertiesParameters")]
    internal partial class UnknownSecurityPolicyProperties
    {
    }
}
