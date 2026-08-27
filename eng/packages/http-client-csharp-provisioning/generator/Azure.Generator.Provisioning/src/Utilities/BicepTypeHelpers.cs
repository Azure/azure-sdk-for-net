// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Provisioning.Utilities
{
    /// <summary>
    /// Utility methods for classifying and inspecting BicepValue/BicepList/BicepDictionary CSharpTypes.
    /// </summary>
    internal static class BicepTypeHelpers
    {
        /// <summary>
        /// Returns true if the type represents a provisioning model (uses DefineModelProperty + AssignOrReplace).
        /// A type is a "model" if it is either a custom type (from our providers) or a framework type
        /// that inherits from <see cref="ProvisionableConstruct"/>.
        /// </summary>
        public static bool IsModelType(CSharpType type)
        {
            if (IsBicepValueType(type) || IsBicepListType(type) || IsBicepDictionaryType(type))
                return false;
            if (type.IsEnum)
                return false;
            if (!type.IsFrameworkType)
                return true;
            return typeof(ProvisionableConstruct).IsAssignableFrom(type.FrameworkType);
        }

        /// <summary>
        /// Returns true if the type derives from <see cref="ProvisionableResource"/>.
        /// </summary>
        public static bool IsResourceType(CSharpType type)
            => type.IsFrameworkType
                ? typeof(ProvisionableResource).IsAssignableFrom(type.FrameworkType)
                : type.BaseType is not null && IsResourceType(type.BaseType);

        /// <summary>
        /// Returns true if the type is already represented as a provisioning type.
        /// </summary>
        public static bool IsProvisioningType(CSharpType type)
            => IsBicepValueType(type)
               || IsBicepListType(type)
               || IsBicepDictionaryType(type)
               || IsModelType(type);

        /// <summary>
        /// Returns true if the type is <see cref="BicepValue{T}"/>.
        /// </summary>
        public static bool IsBicepValueType(CSharpType type)
            => type.IsFrameworkType && type.FrameworkType.IsGenericType
               && type.FrameworkType.GetGenericTypeDefinition() == typeof(BicepValue<>);

        /// <summary>
        /// Returns true if the type is <see cref="BicepList{T}"/>.
        /// </summary>
        public static bool IsBicepListType(CSharpType type)
            => type.IsFrameworkType && type.FrameworkType.IsGenericType
               && type.FrameworkType.GetGenericTypeDefinition() == typeof(BicepList<>);

        /// <summary>
        /// Returns true if the type is <see cref="BicepDictionary{T}"/>.
        /// </summary>
        public static bool IsBicepDictionaryType(CSharpType type)
            => type.IsFrameworkType && type.FrameworkType.IsGenericType
               && type.FrameworkType.GetGenericTypeDefinition() == typeof(BicepDictionary<>);

        /// <summary>
        /// Gets the first generic type argument of a CSharpType, or <c>typeof(object)</c> if none.
        /// </summary>
        public static CSharpType GetGenericArgument(CSharpType type)
            => type.Arguments.Count > 0 ? type.Arguments[0] : typeof(object);

        /// <summary>
        /// Builds the value assigned to an inherited discriminator property.
        /// </summary>
        public static ValueExpression BuildDiscriminatorValueExpression(
            InputModelType model,
            PropertyProvider discriminatorProperty)
        {
            var discriminatorValue = model.DiscriminatorValue
                ?? throw new InvalidOperationException($"Model {model.Name} does not define a discriminator value.");

            if (model.BaseModel?.DiscriminatorProperty?.Type is InputEnumType inputEnum)
            {
                var enumProvider = ProvisioningGenerator.Instance.TypeFactory.CreateEnum(inputEnum)
                    ?? throw new InvalidOperationException($"Unable to create discriminator enum {inputEnum.Name}.");
                var enumMember = enumProvider.EnumValues.FirstOrDefault(
                    member => string.Equals(member.Value?.ToString(), discriminatorValue, StringComparison.Ordinal))
                    ?? throw new InvalidOperationException(
                        $"Discriminator value {discriminatorValue} was not found in enum {inputEnum.Name}.");
                var enumType = GetGenericArgument(discriminatorProperty.Type);
                return Static(enumType).Property(enumMember.Name);
            }

            return Literal(discriminatorValue);
        }

        /// <summary>
        /// Builds the argument list for DefineProperty/DefineModelProperty/DefineListProperty/DefineDictionaryProperty calls.
        /// isOutput and isRequired are independent flags and only emitted when true, using named arguments.
        /// </summary>
        public static ValueExpression[] BuildDefinePropertyArgs(
            CSharpType propertyType,
            string propertyName,
            string[] bicepPath,
            bool isOutput,
            bool isRequired,
            string? defaultValue = null,
            string? format = null)
        {
            var args = new List<ValueExpression>
            {
                Nameof(Identifier(propertyName)),
                New.Array(typeof(string), [.. bicepPath.Select(Literal)])
            };
            if (IsResourceType(propertyType))
            {
                // The identifier is derived from the property so that multiple properties of the same
                // resource type on one construct do not share the same bicep identifier.
                args.Add(New.Instance(propertyType, [Literal(propertyName.ToVariableName())]));
            }
            if (isOutput)
            {
                // Output applies to this property occurrence, not recursively to the shared model/resource type.
                // Setter availability is determined once per generated type from all of its usages. Deep per-usage
                // read-only APIs would require separate input/output types or wrappers for both models and resources.
                args.Add(new PositionalParameterReferenceExpression("isOutput", Literal(true)));
            }
            if (isRequired)
            {
                args.Add(new PositionalParameterReferenceExpression("isRequired", Literal(true)));
            }
            if (defaultValue is not null)
            {
                args.Add(new PositionalParameterReferenceExpression("defaultValue", Literal(defaultValue)));
            }
            if (format is not null)
            {
                args.Add(new PositionalParameterReferenceExpression("format", Literal(format)));
            }
            return [.. args];
        }

        /// <summary>
        /// Gets the format metadata used to serialize a provisioning literal value.
        /// </summary>
        public static string? GetLiteralFormat(SerializationFormat? serializationFormat)
        {
            return serializationFormat switch
            {
                // Match the management generator's TypeFormatters contract. Some tokens, including D, U, and T,
                // have generator-defined semantics and must not be passed directly to standard .NET formatters.
                SerializationFormat.DateTime_RFC1123 or
                SerializationFormat.DateTime_RFC7231 => "R",
                SerializationFormat.DateTime_RFC3339 or
                SerializationFormat.DateTime_ISO8601 => "O",
                SerializationFormat.DateTime_Unix => "U",
                SerializationFormat.Date_ISO8601 => "D",
                SerializationFormat.Duration_ISO8601 => "P",
                SerializationFormat.Duration_Constant => "c",
                // Numeric durations have no .NET format specifier, so retain both the unit and wire precision.
                SerializationFormat.Duration_Seconds => "seconds",
                SerializationFormat.Duration_Seconds_Int64 => "seconds-int64",
                SerializationFormat.Duration_Seconds_Float => "seconds-float",
                SerializationFormat.Duration_Seconds_Double => "seconds-double",
                SerializationFormat.Duration_Milliseconds => "milliseconds",
                SerializationFormat.Duration_Milliseconds_Int64 => "milliseconds-int64",
                SerializationFormat.Duration_Milliseconds_Float => "milliseconds-float",
                SerializationFormat.Duration_Milliseconds_Double => "milliseconds-double",
                SerializationFormat.Time_ISO8601 => "T",
                SerializationFormat.Bytes_Base64 => "base64",
                SerializationFormat.Bytes_Base64Url => "base64url",
                SerializationFormat.Int_String => "string",
                // Array delimiters describe HTTP parameter transport rather than ARM resource-body literals.
                _ => null
            };
        }
    }
}
