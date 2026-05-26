// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
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
            if (!type.IsFrameworkType)
                return true;
            return typeof(ProvisionableConstruct).IsAssignableFrom(type.FrameworkType);
        }

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
        /// Builds the argument list for DefineProperty/DefineModelProperty/DefineListProperty/DefineDictionaryProperty calls.
        /// isOutput and isRequired are independent flags and only emitted when true, using named arguments.
        /// </summary>
        public static ValueExpression[] BuildDefinePropertyArgs(
            string propertyName, string[] bicepPath, bool isOutput, bool isRequired, string? defaultValue = null)
        {
            var args = new List<ValueExpression>
            {
                Nameof(Identifier(propertyName)),
                New.Array(typeof(string), [.. bicepPath.Select(Literal)])
            };
            if (isOutput)
            {
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
            return [.. args];
        }
    }
}
