// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// Preserve enum ordinals shipped by the reflection-based provisioning generator.
[assembly: CodeGenEnumValue("KeyVaultSecretStatus", "Unknown", 0)]
[assembly: CodeGenEnumValue("PublicCertificateLocation", "Unknown", 0)]
