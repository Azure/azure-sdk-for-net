// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("_name")]
    public partial class TrackedResourceWithSettableIdOptionalLocation : NetworkTrackedResourceData
    {
        // The generated member intentionally preserves the service wire shape while hiding an inherited ARM member.
        // TODO: Revisit duplicated inherited metadata, optional location and settable ID together
        // after https://github.com/Azure/azure-sdk-for-net/issues/60023 is fixed.
        private protected new string _name;
    }
}
