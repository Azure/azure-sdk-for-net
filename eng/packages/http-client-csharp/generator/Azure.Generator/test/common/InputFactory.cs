// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;

namespace Azure.Generator.Tests.Common
{
    /// <summary>
    /// Provider methods to construct intput test data
    /// </summary>
    public static class InputFactory
    {
        /// <summary>
        /// Primitive input data types
        /// </summary>
        public static class Primitive
        {
            /// <summary>
            /// Construct string input data
            /// </summary>
            /// <param name="name"></param>
            /// <param name="crossLanguageDefinitionId"></param>
            /// <param name="encode"></param>
            /// <returns></returns>
            public static InputPrimitiveType String(string? name = null, string? crossLanguageDefinitionId = null, string? encode = null)
            {
                return new InputPrimitiveType(InputPrimitiveTypeKind.String, name ?? string.Empty, crossLanguageDefinitionId ?? string.Empty, encode);
            }
        }

        /// <summary>
        /// Construct input enum types
        /// </summary>
        public static class EnumMember
        {
            /// <summary>
            /// Construct input enum type value for int32
            /// </summary>
            /// <param name="name"></param>
            /// <param name="value"></param>
            /// <param name="enumType"></param>
            /// <returns></returns>
            public static InputEnumTypeValue Int32(string name, int value, InputEnumType enumType)
            {
                return new InputEnumTypeValue(name, value, InputPrimitiveType.Int32, "", $"{name} description", enumType);
            }

            /// <summary>
            /// Construct input enum type value for float32
            /// </summary>
            /// <param name="name"></param>
            /// <param name="value"></param>
            /// <param name="enumType"></param>
            /// <returns></returns>
            public static InputEnumTypeValue Float32(string name, float value, InputEnumType enumType)
            {
                return new InputEnumTypeValue(name, value, InputPrimitiveType.Float32, "", $"{name} description", enumType);
            }

            /// <summary>
            /// Construct input enum type value for string
            /// </summary>
            /// <param name="name"></param>
            /// <param name="value"></param>
            /// <param name="enumType"></param>
            /// <returns></returns>
            public static InputEnumTypeValue String(string name, string value, InputEnumType enumType)
            {
                return new InputEnumTypeValue(name, value, InputPrimitiveType.String, "", $"{name} description", enumType);
            }
        }

        /// <summary>
        /// Construct input literal types
        /// </summary>
        public static class Literal
        {
            /// <summary>
            /// Construct input literal type value for string
            /// </summary>
            /// <param name="value"></param>
            /// <param name="name"></param>
            /// <param name="namespace"></param>
            /// <returns></returns>
            public static InputLiteralType String(string value, string? name = null, string? @namespace = null)
            {
                return new InputLiteralType(name ?? string.Empty, @namespace ?? string.Empty, InputPrimitiveType.String, value);
            }

            /// <summary>
            /// Construct input enum type value for any
            /// </summary>
            /// <param name="value"></param>
            /// <param name="name"></param>
            /// <param name="namespace"></param>
            /// <returns></returns>
            public static InputLiteralType Int32(int value, string? name = null, string? @namespace = null)
            {
                return new InputLiteralType(name ?? string.Empty, @namespace ?? string.Empty, InputPrimitiveType.Int32, value);
            }
        }

        /// <summary>
        /// Construct input constants
        /// </summary>
        public static class Constant
        {
            /// <summary>
            /// Construct input constnat for string
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static InputConstant String(string value)
            {
                return new InputConstant(value, InputPrimitiveType.String);
            }

            /// <summary>
            /// Construct input constnat for int64
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static InputConstant Int64(long value)
            {
                return new InputConstant(value, InputPrimitiveType.Int64);
            }
        }

        /// <summary>
        /// Construct input parameter with content type
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static InputHeaderParameter ContentTypeParameter(string contentType)
            => HeaderParameter(
                "contentType",
                Literal.String(contentType),
                isRequired: true,
                defaultValue: Constant.String(contentType),
                serializedName: "Content-Type",
                isContentType: true,
                scope: InputParameterScope.Constant);

        /// <summary>
        /// Construct input model property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="isRequired"></param>
        /// <param name="isReadOnly"></param>
        /// <param name="isDiscriminator"></param>
        /// <param name="isHttpMetadata"></param>
        /// <param name="isApiVersion"></param>
        /// <param name="defaultValue"></param>
        /// <param name="wireName"></param>
        /// <param name="summary"></param>
        /// <param name="serializedName"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static InputModelProperty Property(
            string name,
            InputType type,
            bool isRequired = false,
            bool isReadOnly = false,
            bool isDiscriminator = false,
            bool isHttpMetadata = false,
            bool isApiVersion = false,
            InputConstant? defaultValue = null,
            string? wireName = null,
            string? summary = null,
            string? serializedName = null,
            string? doc = null)
        {
            return new InputModelProperty(
                name: name,
                summary: summary,
                doc: doc ?? $"Description for {name}",
                type: type,
                isRequired: isRequired,
                isReadOnly: isReadOnly,
                isApiVersion: isApiVersion,
                defaultValue: defaultValue,
                isHttpMetadata: isHttpMetadata,
                access: null,
                isDiscriminator: isDiscriminator,
                serializedName: serializedName ?? wireName ?? name.ToVariableName(),
                serializationOptions: new(json: new(wireName ?? name.ToVariableName())));
        }

        public static InputHeaderParameter HeaderParameter(
           string name,
           InputType type,
           bool isRequired = false,
           bool isReadOnly = false,
           bool isApiVersion = false,
           bool isContentType = false,
           string? summary = null,
           string? doc = null,
           string? collectionFormat = null,
           string? serializedName = null,
           InputConstant? defaultValue = null,
           InputParameterScope scope = InputParameterScope.Method)
        {
            return new InputHeaderParameter(
                name: name,
                summary: summary,
                doc: doc ?? $"{name} description",
                type: type,
                isRequired: isRequired,
                isReadOnly: isReadOnly,
                isApiVersion: isApiVersion,
                isContentType: isContentType,
                access: null,
                defaultValue: defaultValue,
                collectionFormat: collectionFormat,
                scope: scope,
                arraySerializationDelimiter: null,
                serializedName: serializedName ?? name);
        }

        public static InputQueryParameter QueryParameter(
            string name,
            InputType type,
            bool isRequired = false,
            bool isReadOnly = false,
            bool isApiVersion = false,
            InputConstant? defaultValue = null,
            string? summary = null,
            string? doc = null,
            string? collectionFormat = null,
            string? serializedName = null,
            bool explode = false,
            InputParameterScope scope = InputParameterScope.Method,
            string? delimiter = null)
        {
            return new InputQueryParameter(
                name: name,
                summary: summary,
                doc: doc ?? $"{name} description",
                type: type,
                isRequired: isRequired,
                isReadOnly: isReadOnly,
                isApiVersion: isApiVersion,
                defaultValue: defaultValue,
                scope: scope,
                arraySerializationDelimiter: delimiter,
                access: null,
                serializedName: serializedName ?? name,
                collectionFormat: collectionFormat,
                explode: explode);
        }

        public static InputPathParameter PathParameter(
            string name,
            InputType type,
            bool isRequired = false,
            bool isReadOnly = false,
            bool isApiVersion = false,
            InputConstant? defaultValue = null,
            string? summary = null,
            string? doc = null,
            string? serializedName = null,
            bool allowReserved = false,
            bool explode = false,
            bool skipUrlEncoding = false,
            string? serverUrlTemplate = null,
            InputParameterScope scope = InputParameterScope.Method)
        {
            return new InputPathParameter(
                name: name,
                summary: summary,
                doc: doc ?? $"{name} description",
                type: type,
                isRequired: isRequired,
                isReadOnly: isReadOnly,
                isApiVersion: isApiVersion,
                explode: explode,
                defaultValue: defaultValue,
                scope: scope,
                skipUrlEncoding: skipUrlEncoding,
                serverUrlTemplate: serverUrlTemplate,
                access: null,
                serializedName: serializedName ?? name,
                allowReserved: allowReserved);
        }

        public static InputEndpointParameter EndpointParameter(
            string name,
            InputType type,
            bool isRequired = false,
            bool isReadOnly = false,
            bool isApiVersion = false,
            InputConstant? defaultValue = null,
            string? summary = null,
            string? doc = null,
            string? serializedName = null,
            bool skipUrlEncoding = false,
            bool isEndpoint = true,
            string? serverUrlTemplate = null,
            InputParameterScope scope = InputParameterScope.Client)
        {
            return new InputEndpointParameter(
                name: name,
                summary: summary,
                doc: doc ?? $"{name} description",
                type: type,
                isRequired: isRequired,
                isReadOnly: isReadOnly,
                isApiVersion: isApiVersion,
                defaultValue: defaultValue,
                scope: scope,
                skipUrlEncoding: skipUrlEncoding,
                serverUrlTemplate: serverUrlTemplate,
                isEndpoint: isEndpoint,
                access: null,
                serializedName: serializedName ?? name);
        }

        public static InputBodyParameter BodyParameter(
            string name,
            InputType type,
            bool isRequired = false,
            bool isReadOnly = false,
            bool isApiVersion = false,
            InputConstant? defaultValue = null,
            string? summary = null,
            string? doc = null,
            string? serializedName = null,
            string[]? contentTypes = null,
            string? defaultContentType = null,
            InputParameterScope scope = InputParameterScope.Method)
        {
            return new InputBodyParameter(
                name: name,
                summary: summary,
                doc: doc ?? $"{name} description",
                type: type,
                isRequired: isRequired,
                isReadOnly: isReadOnly,
                isApiVersion: isApiVersion,
                defaultValue: defaultValue,
                defaultContentType: defaultContentType ?? "application/json",
                contentTypes: contentTypes ?? ["application/json"],
                scope: scope,
                access: null,
                serializedName: serializedName ?? name);
        }

        public static InputMethodParameter MethodParameter(
            string name,
            InputType type,
            bool isRequired = false,
            bool isReadOnly = false,
            bool isApiVersion = false,
            InputConstant? defaultValue = null,
            string? summary = null,
            string? doc = null,
            string? serializedName = null,
            InputRequestLocation location = InputRequestLocation.Body,
            InputParameterScope scope = InputParameterScope.Method)
        {
            return new InputMethodParameter(
                name: name,
                summary: summary,
                doc: doc ?? $"{name} description",
                type: type,
                isRequired: isRequired,
                isReadOnly: isReadOnly,
                isApiVersion: isApiVersion,
                defaultValue: defaultValue,
                scope: scope,
                access: null,
                location: location,
                serializedName: serializedName ?? name);
        }

        /// <summary>
        /// Construct input model type
        /// </summary>
        /// <param name="name"></param>
        /// <param name="clientNamespace"></param>
        /// <param name="access"></param>
        /// <param name="usage"></param>
        /// <param name="properties"></param>
        /// <param name="baseModel"></param>
        /// <param name="modelAsStruct"></param>
        /// <param name="discriminatedKind"></param>
        /// <param name="additionalProperties"></param>
        /// <param name="discriminatedModels"></param>
        /// <param name="derivedModels"></param>
        /// <param name="decorators"></param>
        /// <returns></returns>
        public static InputModelType Model(
            string name,
            string clientNamespace = "Samples.Models",
            string access = "public",
            InputModelTypeUsage usage = InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
            IEnumerable<InputModelProperty>? properties = null,
            InputModelType? baseModel = null,
            bool modelAsStruct = false,
            string? discriminatedKind = null,
            InputType? additionalProperties = null,
            IDictionary<string, InputModelType>? discriminatedModels = null,
            IEnumerable<InputModelType>? derivedModels = null,
            IReadOnlyList<InputDecoratorInfo>? decorators = null)
        {
            IEnumerable<InputModelProperty> propertiesList = properties ?? [Property("StringProperty", InputPrimitiveType.String)];
            var model = new InputModelType(
                name,
                clientNamespace,
                name,
                access,
                null,
                null,
                $"{name} description",
                usage,
                [.. propertiesList],
                baseModel,
                derivedModels is null ? [] : [.. derivedModels],
                discriminatedKind,
                propertiesList.FirstOrDefault(p => p.IsDiscriminator),
                discriminatedModels is null ? new Dictionary<string, InputModelType>() : discriminatedModels.AsReadOnly(),
                additionalProperties,
                modelAsStruct,
                new());
            if (decorators is not null)
            {
                var decoratorProperty = typeof(InputModelType).GetProperty(nameof(InputModelType.Decorators));
                var setDecoratorMethod = decoratorProperty?.GetSetMethod(true);
                setDecoratorMethod!.Invoke(model, [decorators]);
            }
            return model;
        }

        /// <summary>
        /// Construct basic service method
        /// </summary>
        /// <param name="name"></param>
        /// <param name="operation"></param>
        /// <param name="access"></param>
        /// <param name="parameters"></param>
        /// <param name="response"></param>
        /// <param name="exception"></param>
        /// <param name="crossLanguageDefinitionId"></param>
        /// <returns></returns>
        public static InputBasicServiceMethod BasicServiceMethod(
            string name,
            InputOperation operation,
            string access = "public",
            IReadOnlyList<InputMethodParameter>? parameters = null,
            InputServiceMethodResponse? response = null,
            InputServiceMethodResponse? exception = null,
            string? crossLanguageDefinitionId = null)
        {
            return new InputBasicServiceMethod(
                name,
                access,
                [],
                null,
                null,
                operation,
                parameters ?? [],
                response ?? ServiceMethodResponse(null, null),
                exception,
                false,
                true,
                true,
                crossLanguageDefinitionId ?? string.Empty);
        }

        /// <summary>
        /// Construct service method response
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resultSegments"></param>
        /// <returns></returns>
        public static InputServiceMethodResponse ServiceMethodResponse(InputType? type, IReadOnlyList<string>? resultSegments)
        {
            return new InputServiceMethodResponse(type, resultSegments);
        }

        /// <summary>
        /// Construct paging service method
        /// </summary>
        /// <param name="name"></param>
        /// <param name="operation"></param>
        /// <param name="access"></param>
        /// <param name="parameters"></param>
        /// <param name="response"></param>
        /// <param name="exception"></param>
        /// <param name="pagingMetadata"></param>
        /// <returns></returns>
        public static InputPagingServiceMethod PagingServiceMethod(
           string name,
           InputOperation operation,
           string access = "public",
           IReadOnlyList<InputMethodParameter>? parameters = null,
           InputServiceMethodResponse? response = null,
           InputServiceMethodResponse? exception = null,
           InputPagingServiceMetadata? pagingMetadata = null)
        {
            return new InputPagingServiceMethod(
                name,
                access,
                [],
                null,
                null,
                operation,
                parameters ?? [],
                response ?? ServiceMethodResponse(null, null),
                exception,
                false,
                true,
                true,
                string.Empty,
                pagingMetadata ?? PagingMetadata([], null, null));
        }

        /// <summary>
        /// Construct paging metadata
        /// </summary>
        /// <param name="itemPropertySegments"></param>
        /// <param name="nextLink"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static InputPagingServiceMetadata PagingMetadata(IReadOnlyList<string> itemPropertySegments, InputNextLink? nextLink, InputContinuationToken? continuationToken)
        {
            return new InputPagingServiceMetadata(itemPropertySegments, nextLink, continuationToken);
        }

        /// <summary>
        /// Construct paging service method
        /// </summary>
        /// <param name="name"></param>
        /// <param name="operation"></param>
        /// <param name="access"></param>
        /// <param name="parameters"></param>
        /// <param name="response"></param>
        /// <param name="exception"></param>
        /// <param name="longRunningServiceMetadata"></param>
        /// <returns></returns>
        public static InputLongRunningServiceMethod LongRunningServiceMethod(
            string name,
            InputOperation operation,
            string access = "public",
            IReadOnlyList<InputMethodParameter>? parameters = null,
            InputServiceMethodResponse? response = null,
            InputServiceMethodResponse? exception = null,
            InputLongRunningServiceMetadata? longRunningServiceMetadata = null)
        {
            return new InputLongRunningServiceMethod(
                name,
                access,
                [],
                null,
                null,
                operation,
                parameters ?? [],
                response ?? ServiceMethodResponse(null, null),
                exception,
                false,
                true,
                true,
                string.Empty,
                longRunningServiceMetadata ?? LongRunningServiceMetadata(1, OperationResponse(), null));
        }

        /// <summary>
        /// Construct paging metadata
        /// </summary>
        /// <param name="finalState"></param>
        /// <param name="finalResponse"></param>
        /// <param name="resultPath"></param>
        /// <returns></returns>
        public static InputLongRunningServiceMetadata LongRunningServiceMetadata(int finalState, InputOperationResponse finalResponse, string? resultPath)
        {
            return new InputLongRunningServiceMetadata(finalState, finalResponse, resultPath);
        }

        /// <summary>
        /// Construct input operation
        /// </summary>
        /// <param name="name"></param>
        /// <param name="access"></param>
        /// <param name="parameters"></param>
        /// <param name="responses"></param>
        /// <param name="requestMediaTypes"></param>
        /// <param name="path"></param>
        /// <param name="decorators"></param>
        /// <returns></returns>
        public static InputOperation Operation(
            string name,
            string access = "public",
            IEnumerable<InputParameter>? parameters = null,
            IEnumerable<InputOperationResponse>? responses = null,
            IEnumerable<string>? requestMediaTypes = null,
            string? path = null,
            IReadOnlyList<InputDecoratorInfo>? decorators = null)
        {
            var operation = new InputOperation(
                name,
                null,
                "",
                $"{name} description",
                null,
                access,
                parameters is null ? [] : [.. parameters],
                responses is null ? [OperationResponse()] : [.. responses],
                "GET",
                string.Empty,
                path ?? string.Empty,
                null,
                requestMediaTypes is null ? null : [.. requestMediaTypes],
                false,
                true,
                true,
                name);
            if (decorators is not null)
            {
                var decoratorProperty = typeof(InputOperation).GetProperty(nameof(InputOperation.Decorators));
                var setDecoratorMethod = decoratorProperty?.GetSetMethod(true);
                setDecoratorMethod!.Invoke(operation, [decorators]);
            }
            return operation;
        }

        /// <summary>
        /// Construct input operation response
        /// </summary>
        /// <param name="statusCodes"></param>
        /// <param name="bodytype"></param>
        /// <returns></returns>
        public static InputOperationResponse OperationResponse(IEnumerable<int>? statusCodes = null, InputType? bodytype = null)
        {
            return new InputOperationResponse(
                statusCodes is null ? [200] : [.. statusCodes],
                bodytype,
                [],
                false,
                ["application/json"]);
        }

        private static readonly Dictionary<InputClient, IList<InputClient>> _childClientsCache = new();
        /// <summary>
        /// Construct input client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="clientNamespace"></param>
        /// <param name="doc"></param>
        /// <param name="methods"></param>
        /// <param name="parameters"></param>
        /// <param name="parent"></param>
        /// <param name="decorators"></param>
        /// <param name="crossLanguageDefinitionId"></param>
        /// <returns></returns>
        public static InputClient Client(string name, string clientNamespace = "Samples", string? doc = null, IEnumerable<InputServiceMethod>? methods = null, IEnumerable<InputParameter>? parameters = null, InputClient? parent = null, IReadOnlyList<InputDecoratorInfo>? decorators = null, string? crossLanguageDefinitionId = null)
        {
            // when this client has parent, we add the constructed client into the `children` list of the parent
            var clientChildren = new List<InputClient>();
            var client = new InputClient(
                name,
                clientNamespace,
                crossLanguageDefinitionId ?? $"{clientNamespace}.{name}",
                string.Empty,
                doc ?? $"{name} description",
                methods is null ? [] : [.. methods],
                parameters is null ? [] : [.. parameters],
                parent,
                clientChildren,
                []
                );
            _childClientsCache[client] = clientChildren;
            // when we have a parent, we need to find the children list of this parent client and update accordingly.
            if (parent != null && _childClientsCache.TryGetValue(parent, out var children))
            {
                children.Add(client);
            }

            if (decorators is not null)
            {
                var decoratorProperty = typeof(InputClient).GetProperty(nameof(InputClient.Decorators));
                var setDecoratorMethod = decoratorProperty?.GetSetMethod(true);
                setDecoratorMethod!.Invoke(client, [decorators]);
            }
            return client;
        }

        public static InputPagingServiceMetadata ContinuationTokenPagingMetadata(InputParameter parameter, string itemPropertyName, string continuationTokenName, InputResponseLocation continuationTokenLocation)
        {
            return new InputPagingServiceMetadata(
                [itemPropertyName],
                null,
                continuationToken: new InputContinuationToken(parameter, [continuationTokenName], continuationTokenLocation));
        }

        public static InputType Array(InputType elementType)
        {
            return new InputArrayType("list", "list", elementType);
        }

        public static InputPagingServiceMetadata NextLinkPagingMetadata(string itemPropertyName, string nextLinkName, InputResponseLocation nextLinkLocation, IReadOnlyList<InputParameter>? reinjectedParameters = null)
        {
            return PagingMetadata(
                [itemPropertyName],
                new InputNextLink(null, [nextLinkName], nextLinkLocation, reinjectedParameters),
                null);
        }

        public static InputEnumType StringEnum(
            string name,
            IEnumerable<(string Name, string Value)> values,
            string access = "public",
            InputModelTypeUsage usage = InputModelTypeUsage.Input | InputModelTypeUsage.Output,
            bool isExtensible = false,
            string clientNamespace = "Sample.Models")
        {
            var enumValues = new List<InputEnumTypeValue>();
            var enumType = Enum(
                name,
                InputPrimitiveType.String,
                enumValues,
                access: access,
                usage: usage,
                isExtensible: isExtensible,
                clientNamespace: clientNamespace);

            foreach (var (valueName, value) in values)
            {
                enumValues.Add(EnumMember.String(valueName, value, enumType));
            }

            return enumType;
        }

        private static InputEnumType Enum(
            string name,
            InputPrimitiveType underlyingType,
            IReadOnlyList<InputEnumTypeValue> values,
            string access = "public",
            InputModelTypeUsage usage = InputModelTypeUsage.Output | InputModelTypeUsage.Input,
            bool isExtensible = false,
            string clientNamespace = "Sample.Models")
            => new InputEnumType(
                name,
                clientNamespace,
                name,
                access,
                null,
                "",
                $"{name} description",
                usage,
                underlyingType,
                values,
                isExtensible);
    }
}
