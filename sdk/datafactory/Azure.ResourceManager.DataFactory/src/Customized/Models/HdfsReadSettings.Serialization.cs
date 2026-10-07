// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // The MPG generator emits <ExternalType>.Deserialize<ExternalType>(element, options) for properties whose
    // type is an Azure.Core.Expressions.DataFactory type (mapped via @@alternateType identity), but those static
    // Deserialize overloads do not exist (CS0117). Each property below redirects deserialization to a shared,
    // correct ModelReaderWriter-based reader via [CodeGenSerialization].
    // TODO: remove once the generator emits correct deserialization for identity-aliased types (#59298).
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(Recursive), DeserializationValueHook = nameof(ReadRecursive))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(WildcardFolderPath), DeserializationValueHook = nameof(ReadWildcardFolderPath))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(WildcardFileName), DeserializationValueHook = nameof(ReadWildcardFileName))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(FileListPath), DeserializationValueHook = nameof(ReadFileListPath))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(EnablePartitionDiscovery), DeserializationValueHook = nameof(ReadEnablePartitionDiscovery))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(PartitionRootPath), DeserializationValueHook = nameof(ReadPartitionRootPath))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(DeleteFilesAfterCompletion), DeserializationValueHook = nameof(ReadDeleteFilesAfterCompletion))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(ModifiedDatetimeStart), DeserializationValueHook = nameof(ReadModifiedDatetimeStart))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(ModifiedDatetimeEnd), DeserializationValueHook = nameof(ReadModifiedDatetimeEnd))]
    public partial class HdfsReadSettings
    {
        internal static void ReadRecursive(JsonProperty property, ref DataFactoryElement<bool> value)
            => value = DataFactoryExpressionSerialization.ReadElement<bool>(property);

        internal static void ReadWildcardFolderPath(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadWildcardFileName(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadFileListPath(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadEnablePartitionDiscovery(JsonProperty property, ref DataFactoryElement<bool> value)
            => value = DataFactoryExpressionSerialization.ReadElement<bool>(property);

        internal static void ReadPartitionRootPath(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadDeleteFilesAfterCompletion(JsonProperty property, ref DataFactoryElement<bool> value)
            => value = DataFactoryExpressionSerialization.ReadElement<bool>(property);

        internal static void ReadModifiedDatetimeStart(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadModifiedDatetimeEnd(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);
    }
}
