// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward compatibility: the v1.15.0 SDK exposed this type as `NetAppSecretPasswordKeyVaultPatchProperties`.
    // The TypeSpec generator emits it as `SecretPasswordKeyVaultPropertiesUpdate` (synthesized by the
    // `Azure.ResourceManager.Foundations.ResourceUpdateModel<>` template, which produces an
    // anonymous templated model that is not directly addressable by name in TypeSpec — so
    // `@@clientName(... , "csharp")` cannot target it). [CodeGenType] is used to alias the
    // generated type back to the old public name on the C# side.
    //
    // The IJsonModel/IPersistableModel stubs satisfy the `ValidateModelReaderWriterPattern`
    // test (every public Models class must implement those interfaces). They throw because
    // these alias types have no functional body of their own — production code uses the
    // generated `SecretPasswordKeyVaultPropertiesUpdate` directly, and the test compatibility layer
    // (tests/Compatibility/NetAppSampleCompatibility.cs) bridges the v1.15.0 names via
    // `global using` aliases pointing at the generated type. The shim's serialization is
    // therefore never exercised at runtime. This matches the existing precedent in
    // src/Custom/Models/NetAppVolumePatch.cs.
    [CodeGenType("SecretPasswordKeyVaultPropertiesUpdate")]
    public partial class NetAppSecretPasswordKeyVaultPatchProperties : IJsonModel<NetAppSecretPasswordKeyVaultPatchProperties>, IPersistableModel<NetAppSecretPasswordKeyVaultPatchProperties>
    {
        NetAppSecretPasswordKeyVaultPatchProperties IJsonModel<NetAppSecretPasswordKeyVaultPatchProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("Deprecated type.");
        void IJsonModel<NetAppSecretPasswordKeyVaultPatchProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("Deprecated type.");
        NetAppSecretPasswordKeyVaultPatchProperties IPersistableModel<NetAppSecretPasswordKeyVaultPatchProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("Deprecated type.");
        string IPersistableModel<NetAppSecretPasswordKeyVaultPatchProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetAppSecretPasswordKeyVaultPatchProperties>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("Deprecated type.");
    }
}
