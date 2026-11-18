// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;

namespace Test.Extensions.Plugin;

// Local subset of the Azure generator's test InputFactory.
internal static class InputFactory
{
    public static InputModelProperty Property(string name, InputType type, bool isRequired, string wireName)
        => new(
            name: name,
            summary: null,
            doc: $"Description for {name}",
            type: type,
            isRequired: isRequired,
            isReadOnly: false,
            access: null,
            isDiscriminator: false,
            serializedName: wireName,
            isHttpMetadata: false,
            isApiVersion: false,
            defaultValue: null,
            serializationOptions: new(json: new(wireName)));

    public static InputModelType Model(string name, string clientNamespace, IReadOnlyList<InputModelProperty> properties)
        => new(
            name: name,
            @namespace: clientNamespace,
            crossLanguageDefinitionId: name,
            access: "public",
            deprecation: null,
            summary: null,
            doc: $"{name} description",
            usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
            properties: properties,
            baseModel: null,
            derivedModels: [],
            discriminatorValue: null,
            discriminatorProperty: null,
            discriminatedSubtypes: new Dictionary<string, InputModelType>(),
            additionalProperties: null,
            modelAsStruct: false,
            serializationOptions: new(),
            isDynamicModel: false);
}
