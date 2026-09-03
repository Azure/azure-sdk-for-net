// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.AppContainers
{
    // This resource is available only in a preview API version. Use the resource-specific suffix to avoid the generic Builder name.
    [CodeGenType("Builder")]
    [Experimental("AZPROVISION001")]
    public partial class BuilderResource
    {
    }
}
