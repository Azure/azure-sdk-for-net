// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Utilities
{
    internal static class BackCompatHelper
    {
        private static readonly Type ForwardsClientCallsAttributeType = typeof(ForwardsClientCallsAttribute);
        private const string CancellationTokenAnalyzerRule = "AZC0002";
        private const string CancellationTokenSuppressionJustification =
            "Back-compat overload preserves the previous method signature where CancellationToken was the trailing parameter. " +
            "Making it optional would introduce an ambiguous call with the new method.";
        private const string IfMatch = "If-Match";
        private const string IfNoneMatch = "If-None-Match";
        private const string IfModifiedSince = "If-Modified-Since";
        private const string IfUnmodifiedSince = "If-Unmodified-Since";
        private static readonly Dictionary<string, string> ConditionalHeaderProperties = new(StringComparer.OrdinalIgnoreCase)
        {
            [IfMatch.ToIdentifierName()] = nameof(RequestConditions.IfMatch),
            [IfNoneMatch.ToIdentifierName()] = nameof(RequestConditions.IfNoneMatch),
            [IfModifiedSince.ToIdentifierName()] = nameof(RequestConditions.IfModifiedSince),
            [IfUnmodifiedSince.ToIdentifierName()] = nameof(RequestConditions.IfUnmodifiedSince)
        };

        private static void AddETagBackwardCompatibilityMethods(
            TypeProvider enclosingType,
            List<MethodProvider> methods,
            Dictionary<string, List<MethodSignature>> existingSignatures,
            IEnumerable<MethodProvider> currentMethods,
            IReadOnlyList<MethodProvider> previousMethods)
        {
            var candidates = new Dictionary<string, List<MethodProvider>>(StringComparer.Ordinal);
            foreach (var method in currentMethods.Concat(enclosingType.CustomCodeView?.Methods ?? []))
            {
                if (IsPublicApi(method.Signature.Modifiers))
                {
                    if (!candidates.TryGetValue(method.Signature.Name, out var methodsWithName))
                    {
                        methodsWithName = [];
                        candidates.Add(method.Signature.Name, methodsWithName);
                    }

                    methodsWithName.Add(method);
                }
            }

            if (candidates.Count == 0)
            {
                return;
            }

            foreach (var previousMethod in previousMethods)
            {
                if (!IsPublicApi(previousMethod.Signature.Modifiers)
                    || existingSignatures.TryGetValue(previousMethod.Signature.Name, out var existingMethods)
                        && existingMethods.Any(signature => MethodSignature.MethodSignatureComparer.Equals(previousMethod.Signature, signature))
                    || IsMethodRemovalAcceptedInBaseline(enclosingType, previousMethod.Signature))
                {
                    continue;
                }

                MethodProvider? currentMethod = null;
                foreach (var transformedSignature in TransformConditionalHeaderParameters(previousMethod.Signature))
                {
                    if (candidates.TryGetValue(transformedSignature.Name, out var methodsWithName))
                    {
                        currentMethod = methodsWithName.FirstOrDefault(method => SignaturesMatch(transformedSignature, method.Signature));
                        if (currentMethod is not null)
                        {
                            break;
                        }
                    }
                }

                if (currentMethod is null)
                {
                    continue;
                }

                var overload = BuildStringToETagOverload(enclosingType, previousMethod, currentMethod);
                if (overload is null)
                {
                    continue;
                }

                methods.Add(overload);
                if (!existingSignatures.TryGetValue(overload.Signature.Name, out existingMethods))
                {
                    existingMethods = [];
                    existingSignatures.Add(overload.Signature.Name, existingMethods);
                }

                existingMethods.Add(overload.Signature);
            }
        }

        /// <summary>
        /// Applies management back-compat decorations and adds management-specific overloads.
        /// </summary>
        /// <param name="backCompatMethods">The full method list produced by the base back-compat generation.</param>
        /// <param name="originalMethods">The methods that existed before the base synthesized the compatibility overloads.</param>
        /// <returns>The complete list of decorated back-compat methods.</returns>
        internal static IReadOnlyList<MethodProvider> DecorateBackwardCompatibilityMethods(
            IReadOnlyList<MethodProvider> backCompatMethods,
            IEnumerable<MethodProvider> originalMethods)
        {
            if (backCompatMethods.Count == 0)
            {
                return backCompatMethods;
            }

            var originalMethodSet = new HashSet<MethodProvider>(originalMethods, ReferenceEqualityComparer.Instance);
            var methods = new List<MethodProvider>(backCompatMethods);
            var existingSignatures = backCompatMethods
                .Select(method => method.Signature)
                .GroupBy(signature => signature.Name)
                .ToDictionary(group => group.Key, group => group.ToList(), StringComparer.Ordinal);

            var enclosingType = backCompatMethods[0].EnclosingType;
            if (enclosingType.CustomCodeView is { } customCodeView)
            {
                foreach (var signature in customCodeView.Methods.Select(method => method.Signature))
                {
                    if (!existingSignatures.TryGetValue(signature.Name, out var methodsWithName))
                    {
                        methodsWithName = [];
                        existingSignatures.Add(signature.Name, methodsWithName);
                    }

                    methodsWithName.Add(signature);
                }
            }

            if (enclosingType.LastContractView?.Methods is { Count: > 0 } previousMethods)
            {
                AddETagBackwardCompatibilityMethods(
                    enclosingType,
                    methods,
                    existingSignatures,
                    originalMethodSet,
                    previousMethods);
            }

            foreach (var method in methods)
            {
                if (!originalMethodSet.Contains(method))
                {
                    DecorateBackwardCompatibilityMethod(method);
                }
            }

            return methods;
        }

        private static bool SignaturesMatch(MethodSignature left, MethodSignature right)
        {
            if (left.Name != right.Name
                || left.Parameters.Count != right.Parameters.Count
                || (left.GenericArguments?.Count ?? 0) != (right.GenericArguments?.Count ?? 0)
                || left.Modifiers.HasFlag(MethodSignatureModifiers.Static) != right.Modifiers.HasFlag(MethodSignatureModifiers.Static))
            {
                return false;
            }

            for (var i = 0; i < left.Parameters.Count; i++)
            {
                var leftParameter = left.Parameters[i];
                var rightParameter = right.Parameters[i];
                if (leftParameter.Name != rightParameter.Name
                    || leftParameter.IsRef != rightParameter.IsRef
                    || leftParameter.IsOut != rightParameter.IsOut
                    || !leftParameter.Type.Equals(rightParameter.Type))
                {
                    return false;
                }
            }

            return true;
        }

        private static void DecorateBackwardCompatibilityMethod(MethodProvider method)
        {
            var signature = method.Signature;

            var hasForwardsClientCalls = signature.Attributes.Any(attribute =>
                attribute.Type is { IsFrameworkType: true } && attribute.Type.FrameworkType == ForwardsClientCallsAttributeType);
            if (!hasForwardsClientCalls)
            {
                signature.Update(attributes: [.. signature.Attributes, new AttributeStatement(ForwardsClientCallsAttributeType)]);
            }

            var hasCancellationTokenSuppression = method.Suppressions.Any(suppression =>
                suppression.Code is ScopedApi { Original: LiteralExpression { Literal: string code } }
                && code == CancellationTokenAnalyzerRule);
            if (EndsWithRequiredCancellationToken(signature) && !hasCancellationTokenSuppression)
            {
                method.Update(suppressions:
                [
                    .. method.Suppressions,
                    new SuppressionStatement(
                        inner: null,
                        code: Literal(CancellationTokenAnalyzerRule),
                        justification: CancellationTokenSuppressionJustification)
                ]);
            }
        }

        internal static bool EndsWithRequiredCancellationToken(MethodSignature signature)
        {
            if (signature.Parameters.Count == 0)
            {
                return false;
            }

            var lastParameter = signature.Parameters[signature.Parameters.Count - 1];
            return lastParameter.DefaultValue is null && lastParameter.Type.Equals(typeof(CancellationToken));
        }

        private static IReadOnlyList<MethodSignature> TransformConditionalHeaderParameters(MethodSignature signature)
        {
            var conditionalParameters = new List<ParameterProvider>();
            var etagParameters = new List<ParameterProvider>(signature.Parameters.Count);
            var hasETagParameter = false;
            var hasModificationCondition = false;
            foreach (var parameter in signature.Parameters)
            {
                if (parameter.IsRef || parameter.IsOut)
                {
                    return [];
                }

                if (!ConditionalHeaderProperties.TryGetValue(parameter.Name, out var propertyName))
                {
                    etagParameters.Add(parameter);
                    continue;
                }

                conditionalParameters.Add(parameter);
                hasModificationCondition |= propertyName is nameof(RequestConditions.IfModifiedSince) or nameof(RequestConditions.IfUnmodifiedSince);
                if (propertyName is nameof(RequestConditions.IfMatch) or nameof(RequestConditions.IfNoneMatch)
                    && parameter.Type.Equals(typeof(string)))
                {
                    etagParameters.Add(CloneParameter(parameter, type: new CSharpType(typeof(ETag), isNullable: true)));
                    hasETagParameter = true;
                }
                else
                {
                    etagParameters.Add(parameter);
                }
            }

            if (!hasETagParameter)
            {
                return [];
            }

            var transformedSignatures = new List<MethodSignature>(3)
            {
                new(
                    signature.Name,
                    signature.Description,
                    signature.Modifiers,
                    signature.ReturnType,
                    signature.ReturnDescription,
                    etagParameters,
                    Attributes: signature.Attributes,
                    GenericArguments: signature.GenericArguments,
                    GenericParameterConstraints: signature.GenericParameterConstraints,
                    ExplicitInterface: signature.ExplicitInterface,
                    NonDocumentComment: signature.NonDocumentComment)
            };

            if (!hasModificationCondition)
            {
                transformedSignatures.Add(new(
                    signature.Name,
                    signature.Description,
                    signature.Modifiers,
                    signature.ReturnType,
                    signature.ReturnDescription,
                    CreateGroupedParameters(signature, conditionalParameters, "matchConditions", typeof(MatchConditions)),
                    Attributes: signature.Attributes,
                    GenericArguments: signature.GenericArguments,
                    GenericParameterConstraints: signature.GenericParameterConstraints,
                    ExplicitInterface: signature.ExplicitInterface,
                    NonDocumentComment: signature.NonDocumentComment));
            }

            transformedSignatures.Add(new(
                signature.Name,
                signature.Description,
                signature.Modifiers,
                signature.ReturnType,
                signature.ReturnDescription,
                CreateGroupedParameters(signature, conditionalParameters, "requestConditions", typeof(RequestConditions)),
                Attributes: signature.Attributes,
                GenericArguments: signature.GenericArguments,
                GenericParameterConstraints: signature.GenericParameterConstraints,
                ExplicitInterface: signature.ExplicitInterface,
                NonDocumentComment: signature.NonDocumentComment));

            return transformedSignatures;
        }

        private static IReadOnlyList<ParameterProvider> CreateGroupedParameters(
            MethodSignature signature,
            IReadOnlyList<ParameterProvider> conditionalParameters,
            string name,
            Type type)
        {
            var transformedParameter = CloneParameter(
                conditionalParameters[0],
                name: name,
                type: new CSharpType(type, isNullable: true));
            var addedTransformedParameter = false;
            var parameters = new List<ParameterProvider>(signature.Parameters.Count - conditionalParameters.Count + 1);
            foreach (var parameter in signature.Parameters)
            {
                if (!ConditionalHeaderProperties.ContainsKey(parameter.Name))
                {
                    parameters.Add(parameter);
                }
                else if (!addedTransformedParameter)
                {
                    parameters.Add(transformedParameter);
                    addedTransformedParameter = true;
                }
            }

            return parameters;
        }

        private static MethodProvider? BuildStringToETagOverload(
            TypeProvider enclosingType,
            MethodProvider previousMethod,
            MethodProvider currentMethod)
        {
            var previousSignature = previousMethod.Signature;
            var currentSignature = currentMethod.Signature;
            ParameterProvider? currentConditionalParameter = null;
            foreach (var parameter in currentSignature.Parameters)
            {
                if (IsConditionsParameter(parameter) || IsETagParameter(parameter))
                {
                    currentConditionalParameter = parameter;
                    break;
                }
            }
            if (currentConditionalParameter is null)
            {
                return null;
            }

            var previousReturnsVoid = previousSignature.ReturnType is null
                || (previousSignature.ReturnType is { IsFrameworkType: true, FrameworkType: { } previousReturnType } && previousReturnType == typeof(void));
            var currentReturnsVoid = currentSignature.ReturnType is null
                || (currentSignature.ReturnType is { IsFrameworkType: true, FrameworkType: { } currentReturnType } && currentReturnType == typeof(void));
            if (previousReturnsVoid != currentReturnsVoid
                || !previousReturnsVoid && !previousSignature.ReturnType!.AreNamesEqual(currentSignature.ReturnType!))
            {
                return null;
            }

            var firstConvertedParameter = 0;
            for (var i = 0; i < previousSignature.Parameters.Count; i++)
            {
                if (ConditionalHeaderProperties.ContainsKey(previousSignature.Parameters[i].Name))
                {
                    firstConvertedParameter = i;
                    break;
                }
            }

            var removeLeadingDefaults = currentConditionalParameter.DefaultValue is not null;
            var parameters = previousSignature.Parameters
                .Select((parameter, index) => CloneParameter(parameter, removeDefault: removeLeadingDefaults && index <= firstConvertedParameter))
                .ToArray();
            var parameterIndexes = parameters
                .Select((parameter, index) => (parameter.Name, index))
                .ToDictionary(item => item.Name, item => item.index);
            var arguments = new ValueExpression[currentSignature.Parameters.Count];
            for (var i = 0; i < currentSignature.Parameters.Count; i++)
            {
                var currentParameter = currentSignature.Parameters[i];
                ValueExpression value;
                if (IsConditionsParameter(currentParameter))
                {
                    value = BuildConditionsArgument(currentParameter, parameters);
                }
                else
                {
                    if (!parameterIndexes.TryGetValue(currentParameter.Name, out var parameterIndex))
                    {
                        return null;
                    }

                    var parameter = parameters[parameterIndex];
                    value = parameter.Type.Equals(currentParameter.Type)
                        ? parameter
                        : new TernaryConditionalExpression(
                            parameter.NotEqual(Null),
                            New.Instance(typeof(ETag), parameter),
                            new CastExpression(Null, currentParameter.Type));

                    if (parameter.IsRef || parameter.IsOut)
                    {
                        value = value.AsArgument(isRef: parameter.IsRef, isOut: parameter.IsOut);
                    }
                }

                arguments[i] = value;
            }

            var invocationTarget = currentSignature.Modifiers.HasFlag(MethodSignatureModifiers.Static)
                ? Static(enclosingType.Type)
                : This;
            var invocation = invocationTarget.Invoke(currentSignature.Name, arguments);
            MethodBodyStatement body = previousReturnsVoid ? invocation.Terminate() : Return(invocation);

            var hasEditorBrowsable = previousSignature.Attributes.Any(attribute =>
                attribute.Type is { IsFrameworkType: true } && attribute.Type.FrameworkType == typeof(EditorBrowsableAttribute));
            var attributes = hasEditorBrowsable
                ? previousSignature.Attributes
                : [.. previousSignature.Attributes, new AttributeStatement(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))];

            var signature = new MethodSignature(
                previousSignature.Name,
                previousSignature.Description,
                previousSignature.Modifiers & ~MethodSignatureModifiers.Async,
                previousSignature.ReturnType,
                previousSignature.ReturnDescription,
                parameters,
                Attributes: attributes,
                GenericArguments: previousSignature.GenericArguments,
                GenericParameterConstraints: previousSignature.GenericParameterConstraints,
                ExplicitInterface: previousSignature.ExplicitInterface,
                NonDocumentComment: previousSignature.NonDocumentComment);

            var previousXmlDocs = previousMethod.XmlDocs;
            var xmlDocs = new XmlDocProvider(
                previousXmlDocs.Summary,
                parameters.Select(parameter => new XmlDocParamStatement(parameter)).ToArray(),
                previousXmlDocs.Exceptions,
                previousXmlDocs.Returns,
                previousXmlDocs.Inherit);
            return new MethodProvider(signature, body, enclosingType, xmlDocs);
        }

        private static ValueExpression BuildConditionsArgument(
            ParameterProvider currentParameter,
            IReadOnlyList<ParameterProvider> previousParameters)
        {
            var propertyInitializers = new Dictionary<ValueExpression, ValueExpression>();
            ScopedApi<bool>? allNull = null;
            var hasRequiredCondition = false;
            foreach (var parameter in previousParameters)
            {
                if (!ConditionalHeaderProperties.TryGetValue(parameter.Name, out var propertyName))
                {
                    continue;
                }

                propertyInitializers.Add(
                    new MemberExpression(null, propertyName),
                    IsETagConditionalHeader(parameter) && parameter.Type.Equals(typeof(string))
                        ? new TernaryConditionalExpression(
                            parameter.NotEqual(Null),
                            New.Instance(typeof(ETag), parameter),
                            new CastExpression(Null, new CSharpType(typeof(ETag), isNullable: true)))
                        : parameter);
                if (parameter.Type.IsValueType && !parameter.Type.IsNullable)
                {
                    hasRequiredCondition = true;
                }
                else
                {
                    allNull = allNull is null
                        ? parameter.Is(Null)
                        : allNull.And(parameter.Is(Null));
                }
            }

            var conditions = New.Instance(currentParameter.Type, propertyInitializers);
            return hasRequiredCondition || allNull is null
                ? conditions
                : new TernaryConditionalExpression(
                    allNull,
                    new CastExpression(Null, currentParameter.Type),
                    conditions);
        }

        private static ParameterProvider CloneParameter(
            ParameterProvider parameter,
            bool removeDefault = false,
            string? name = null,
            CSharpType? type = null)
        {
            if (name is null
                && type is null
                && !(removeDefault && parameter.DefaultValue is not null))
            {
                return parameter;
            }

            return new(
                name ?? parameter.Name,
                parameter.Description,
                type ?? parameter.Type,
                defaultValue: removeDefault ? null : parameter.DefaultValue,
                isRef: parameter.IsRef,
                isOut: parameter.IsOut,
                isIn: parameter.IsIn,
                isParams: parameter.IsParams,
                attributes: parameter.Attributes,
                property: parameter.Property,
                field: parameter.Field,
                initializationValue: parameter.InitializationValue,
                location: parameter.Location,
                wireInfo: parameter.WireInfo,
                validation: parameter.Validation,
                inputParameter: parameter.InputParameter)
            {
                SpreadSource = parameter.SpreadSource
            };
        }

        private static bool IsETagConditionalHeader(ParameterProvider parameter)
            => ConditionalHeaderProperties.TryGetValue(parameter.Name, out var propertyName)
                && propertyName is nameof(RequestConditions.IfMatch) or nameof(RequestConditions.IfNoneMatch);

        private static bool IsETagParameter(ParameterProvider parameter)
            => IsETagConditionalHeader(parameter)
                && parameter.Type.Equals(new CSharpType(typeof(ETag), isNullable: true));

        private static bool IsConditionsParameter(ParameterProvider parameter)
            => parameter.Type is { IsFrameworkType: true, FrameworkType: { } type }
                && (type == typeof(MatchConditions) && parameter.Name == "matchConditions"
                    || type == typeof(RequestConditions) && parameter.Name == "requestConditions");

        private static bool IsPublicApi(MethodSignatureModifiers modifiers)
            => (modifiers.HasFlag(MethodSignatureModifiers.Public) || modifiers.HasFlag(MethodSignatureModifiers.Protected))
                && !modifiers.HasFlag(MethodSignatureModifiers.Private);

        private static bool IsMethodRemovalAcceptedInBaseline(TypeProvider enclosingType, MethodSignature previousSignature)
        {
            var parameterTypes = previousSignature.Parameters.Select(parameter => parameter.Type).ToArray();
            return CodeModelGenerator.Instance.SourceInputModel?.ApiCompatBaseline.IsMethodRemovalSuppressed(
                enclosingType.Type.FullyQualifiedName,
                previousSignature.Name,
                parameterTypes) == true;
        }
    }
}
