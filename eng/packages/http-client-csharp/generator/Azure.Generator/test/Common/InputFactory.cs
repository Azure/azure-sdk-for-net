// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Generator.CSharp.Input;

namespace Azure.Generator.Tests.Common
{
    public static class InputFactory
    {
        public static class Primitive
        {
            public static InputPrimitiveType String(string? name = null, string? crossLanguageDefinitionId = null, string? encode = null)
            {
                return new InputPrimitiveType(InputPrimitiveTypeKind.String, name ?? string.Empty, crossLanguageDefinitionId ?? string.Empty, encode);
            }
        }

        public static class EnumMember
        {
            public static InputEnumTypeValue Int32(string name, int value)
            {
                return new InputEnumTypeValue(name, value, InputPrimitiveType.Int32, $"{name} description");
            }

            public static InputEnumTypeValue Float32(string name, float value)
            {
                return new InputEnumTypeValue(name, value, InputPrimitiveType.Float32, $"{name} description");
            }

            public static InputEnumTypeValue String(string name, string value)
            {
                return new InputEnumTypeValue(name, value, InputPrimitiveType.String, $"{name} description");
            }
        }

        public static class Literal
        {
            public static InputLiteralType String(string value)
            {
                return new InputLiteralType(InputPrimitiveType.String, value);
            }

            public static InputLiteralType Any(object value)
            {
                return new InputLiteralType(InputPrimitiveType.Any, value);
            }
        }

        public static class Constant
        {
            public static InputConstant String(string value)
            {
                return new InputConstant(value, InputPrimitiveType.String);
            }

            public static InputConstant Int64(long value)
            {
                return new InputConstant(value, InputPrimitiveType.Int64);
            }
        }

        public static InputParameter ContentTypeParameter(string contentType)
            => Parameter(
                "contentType",
                Literal.String(contentType),
                location: RequestLocation.Header,
                isRequired: true,
                defaultValue: Constant.String(contentType),
                nameInRequest: "Content-Type",
                isContentType: true,
                kind: InputOperationParameterKind.Constant);

        public static InputParameter Parameter(
            string name,
            InputType type,
            string? nameInRequest = null,
            InputConstant? defaultValue = null,
            RequestLocation location = RequestLocation.Body,
            bool isRequired = false,
            InputOperationParameterKind kind = InputOperationParameterKind.Method,
            bool isEndpoint = false,
            bool isResourceParameter = false,
            bool isContentType = false)
        {
            return new InputParameter(
                name,
                nameInRequest ?? name,
                $"{name} description",
                type,
                location,
                defaultValue,
                kind,
                isRequired,
                false,
                isResourceParameter,
                isContentType,
                isEndpoint,
                false,
                false,
                null,
                null);
        }

        public static InputNamespace Namespace(string name, IEnumerable<InputModelType>? models = null, IEnumerable<InputClient>? clients = null)
        {
            return new InputNamespace(
                name,
                [],
                [],
                models is null ? [] : [.. models],
                clients is null ? [] : [.. clients],
                new InputAuth());
        }

        public static InputEnumType Enum(
            string name,
            InputPrimitiveType underlyingType,
            string access = "public",
            InputModelTypeUsage usage = InputModelTypeUsage.Output | InputModelTypeUsage.Input,
            IEnumerable<InputEnumTypeValue>? values = null,
            bool isExtensible = false)
        {
            return new InputEnumType(
                name,
                name,
                access,
                null,
                $"{name} description",
                usage,
                underlyingType,
                values is null ? [new InputEnumTypeValue("Value", 1, InputPrimitiveType.Int32, "Value description")] : [.. values],
                isExtensible);
        }

        public static InputModelProperty Property(
            string name,
            InputType type,
            bool isRequired = false,
            bool isReadOnly = false,
            bool isDiscriminator = false,
            string? wireName = null,
            string? description = null)
        {
            return new InputModelProperty(
                name,
                wireName ?? name,
                description ?? $"Description for {name}",
                type,
                isRequired,
                isReadOnly,
                isDiscriminator,
                null);
        }

        public static InputModelType Model(
            string name,
            string access = "public",
            InputModelTypeUsage usage = InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
            IEnumerable<InputModelProperty>? properties = null,
            InputModelType? baseModel = null,
            bool modelAsStruct = false,
            string? discriminatedKind = null,
            InputType? additionalProperties = null,
            IDictionary<string, InputModelType>? discriminatedModels = null,
            IEnumerable<InputModelType>? derivedModels = null)
        {
            IEnumerable<InputModelProperty> propertiesList = properties ?? [Property("StringProperty", InputPrimitiveType.String)];
            return new InputModelType(
                name,
                name,
                access,
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
                modelAsStruct);
        }

        public static InputType Array(InputType elementType)
        {
            return new InputArrayType("list", "list", elementType);
        }

        public static InputType Dictionary(InputType valueType, InputType? keyType = null)
        {
            return new InputDictionaryType("dictionary", keyType ?? InputPrimitiveType.String, valueType);
        }

        public static InputType Union(IList<InputType> types)
        {
            return new InputUnionType("union", [.. types]);
        }

        public static InputOperation Operation(
            string name,
            string access = "public",
            IEnumerable<InputParameter>? parameters = null,
            IEnumerable<OperationResponse>? responses = null,
            IEnumerable<string>? requestMediaTypes = null)
        {
            return new InputOperation(
                name,
                null,
                $"{name} description",
                null,
                access,
                parameters is null ? [] : [.. parameters],
                responses is null ? [OperationResponse()] : [.. responses],
                "GET",
                BodyMediaType.Json,
                "",
                "",
                null,
                requestMediaTypes is null ? null : [.. requestMediaTypes],
                false,
                null,
                null,
                true,
                true,
                name);
        }

        public static OperationResponse OperationResponse(IEnumerable<int>? statusCodes = null, InputType? bodytype = null)
        {
            return new OperationResponse(
                statusCodes is null ? [200] : [.. statusCodes],
                bodytype,
                BodyMediaType.Json,
                [],
                false,
                ["application/json"]);
        }

        public static InputClient Client(string name, IEnumerable<InputOperation>? operations = null, IEnumerable<InputParameter>? parameters = null, string? parent = null)
        {
            return new InputClient(
                name,
                $"{name} description",
                operations is null ? [] : [.. operations],
                parameters is null ? [] : [.. parameters],
                parent);
        }
    }
}
