// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.Input;

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
                return new InputEnumTypeValue(name, value, InputPrimitiveType.Int32, enumType, "", $"{name} description");
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
                return new InputEnumTypeValue(name, value, InputPrimitiveType.Float32, enumType, "", $"{name} description");
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
                return new InputEnumTypeValue(name, value, InputPrimitiveType.String, enumType, "", $"{name} description");
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
        public static InputParameter ContentTypeParameter(string contentType)
            => Parameter(
                "contentType",
                Literal.String(contentType),
                location: InputRequestLocation.Header,
                isRequired: true,
                defaultValue: Constant.String(contentType),
                nameInRequest: "Content-Type",
                isContentType: true,
                kind: InputParameterKind.Constant);

        /// <summary>
        /// Construct input paraemter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="nameInRequest"></param>
        /// <param name="defaultValue"></param>
        /// <param name="location"></param>
        /// <param name="isRequired"></param>
        /// <param name="kind"></param>
        /// <param name="isEndpoint"></param>
        /// <param name="isContentType"></param>
        /// <returns></returns>
        public static InputParameter Parameter(
            string name,
            InputType type,
            string? nameInRequest = null,
            InputConstant? defaultValue = null,
            InputRequestLocation location = InputRequestLocation.Body,
            bool isRequired = false,
            InputParameterKind kind = InputParameterKind.Method,
            bool isEndpoint = false,
            bool isContentType = false)
        {
            return new InputParameter(
                name,
                nameInRequest ?? name,
                null,
                $"{name} description",
                type,
                location,
                defaultValue,
                kind,
                isRequired,
                false,
                isContentType,
                isEndpoint,
                false,
                false,
                null,
                null);
        }

        /// <summary>
        /// Construct input model property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="isRequired"></param>
        /// <param name="isReadOnly"></param>
        /// <param name="isDiscriminator"></param>
        /// <param name="wireName"></param>
        /// <param name="summary"></param>
        /// <param name="description"></param>
        /// <param name="serializedName"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static InputModelProperty Property(
            string name,
            InputType type,
            bool isRequired = false,
            bool isReadOnly = false,
            bool isDiscriminator = false,
            string? wireName = null,
            string? summary = null,
            string? description = null,
            string? serializedName = null,
            InputModelPropertyKind kind = InputModelPropertyKind.Property)
        {
            return new InputModelProperty(
                name,
                kind,
                summary,
                description ?? $"Description for {name}",
                type,
                isRequired,
                isReadOnly,
                isDiscriminator,
                serializedName,
                new(json: new(wireName ?? name)));
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
        /// <returns></returns>
        public static InputBasicServiceMethod BasicServiceMethod(
            string name,
            InputOperation operation,
            string access = "public",
            IReadOnlyList<InputParameter>? parameters = null,
            InputServiceMethodResponse? response = null,
            InputServiceMethodResponse? exception = null)
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
                string.Empty);
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
           IReadOnlyList<InputParameter>? parameters = null,
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
                clientChildren
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
    }
}
