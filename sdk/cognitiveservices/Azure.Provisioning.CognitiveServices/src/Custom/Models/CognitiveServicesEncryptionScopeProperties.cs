// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CognitiveServices
{
    // Provisioning intentionally flattens regular TypeSpec inheritance. This custom base
    // restores the 1.2.0 CLR hierarchy for migration compatibility. The generator still
    // sees the TypeSpec base properties while flattening, so suppress the members already
    // supplied by ServiceAccountEncryptionProperties rather than teaching the generator
    // to infer duplicate properties from an arbitrary custom hierarchy.
    [CodeGenSuppress("KeyVaultProperties")]
    [CodeGenSuppress("KeySource")]
    public partial class CognitiveServicesEncryptionScopeProperties : global::Azure.Provisioning.CognitiveServices.ServiceAccountEncryptionProperties
    {
    }
}
