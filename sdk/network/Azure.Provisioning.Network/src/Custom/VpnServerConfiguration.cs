// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

// Match management by hiding the nested name/etag projections, not the top-level resource metadata.
[CodeGenSuppress("NamePropertiesName")]
[CodeGenSuppress("PropertiesETag")]
public partial class VpnServerConfiguration
{
}
