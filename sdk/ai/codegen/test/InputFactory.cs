// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
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

    public static InputQueryParameter QueryParameter(string name, InputType type, string wireName, bool isExactName = false)
    {
        var parameter = new InputQueryParameter(
            name, summary: null, doc: $"Description for {name}", type, isRequired: false,
            isReadOnly: false, access: null, serializedName: wireName, collectionFormat: null,
            explode: false, isApiVersion: false, defaultValue: null, scope: InputParameterScope.Method,
            arraySerializationDelimiter: null);
        if (isExactName)
        {
            SetIsExactName(parameter, true);
        }

        return parameter;
    }

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_IsExactName")]
    private static extern void SetIsExactName(InputProperty property, bool value);

    public static InputBasicServiceMethod QueryMethod(string name, IReadOnlyList<InputQueryParameter> queryParameters, bool omitFirstFromConvenience)
    {
        var operation = new InputOperation(
            name, summary: null, doc: $"Description for {name}", deprecated: null, accessibility: "public",
            parameters: queryParameters, responses: [new([200], null, [], false, [], null)],
            httpMethod: "GET", uri: "https://example.com", path: "/widgets", externalDocsUrl: null,
            requestMediaTypes: null, bufferResponse: true, generateProtocolMethod: true,
            generateConvenienceMethod: true, crossLanguageDefinitionId: name, ns: null);
        var parameters = new List<InputMethodParameter>();
        foreach (var query in queryParameters.Skip(omitFirstFromConvenience ? 1 : 0))
        {
            var parameter = new InputMethodParameter(
                query.Name, query.Summary, query.Doc, query.Type, query.IsRequired, query.IsReadOnly,
                query.Access, query.SerializedName, query.IsApiVersion, query.DefaultValue,
                InputParameterScope.Method, InputRequestLocation.Query);
            if (query.IsExactName)
            {
                SetIsExactName(parameter, true);
            }

            query.Update(methodParameterSegments: [parameter]);
            parameters.Add(parameter);
        }

        return new InputBasicServiceMethod(
            name, "public", [], null, null, operation, parameters, new InputServiceMethodResponse(null, null),
            exception: null, isOverride: false, generateConvenient: true, generateProtocol: true,
            crossLanguageDefinitionId: name);
    }
}
