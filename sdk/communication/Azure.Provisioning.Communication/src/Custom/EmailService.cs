// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Communication
{
    // Preserve the previously shipped provisioning type name. The TypeSpec
    // generator aligns with the management SDK and would otherwise emit
    // EmailServiceResource.
    [CodeGenType("EmailServiceResource")]
    public partial class EmailService
    {
    }
}
