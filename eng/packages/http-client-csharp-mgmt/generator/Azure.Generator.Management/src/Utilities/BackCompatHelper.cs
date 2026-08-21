// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
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

        private static void AddETagBackwardCompatibilityMethods(
            TypeProvider enclosingType,
            List<MethodProvider> methods,
            IReadOnlyList<MethodProvider> currentMethods,
            IReadOnlyList<MethodProvider> previousMethods)
        {
            var customMethods = enclosingType.CustomCodeView?.Methods;
            var candidateList = new List<MethodProvider>(currentMethods.Count + (customMethods?.Count ?? 0));
            candidateList.AddRange(currentMethods);
            if (customMethods is not null)
            {
                candidateList.AddRange(customMethods);
            }

            foreach (var previousMethod in previousMethods)
            {
                if (!IsPublicApi(previousMethod.Signature.Modifiers)
                    || candidateList.Any(candidate => MethodSignature.MethodSignatureComparer.Equals(candidate.Signature, previousMethod.Signature))
                    || IsMethodRemovalAcceptedInBaseline(enclosingType, previousMethod.Signature))
                {
                    continue;
                }

                var currentMethod = candidateList.FirstOrDefault(candidate => IsStringToETagMatch(previousMethod.Signature, candidate.Signature));
                if (currentMethod is null)
                {
                    continue;
                }

                var overload = BuildStringToETagOverload(enclosingType, previousMethod, currentMethod);
                DecorateBackwardCompatibilityMethod(overload);
                methods.Add(overload);
                candidateList.Add(overload);
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
            var originalMethodList = originalMethods as IReadOnlyList<MethodProvider> ?? [.. originalMethods];
            var originalMethodSet = new HashSet<MethodProvider>(originalMethodList, ReferenceEqualityComparer.Instance);
            var methods = new List<MethodProvider>(backCompatMethods.Count);

            foreach (var method in backCompatMethods)
            {
                methods.Add(method);
                if (!originalMethodSet.Contains(method))
                {
                    DecorateBackwardCompatibilityMethod(method);
                }
            }

            if (originalMethodList.Count > 0
                && originalMethodList[0].EnclosingType.LastContractView?.Methods is { Count: > 0 } previousMethods)
            {
                AddETagBackwardCompatibilityMethods(
                    originalMethodList[0].EnclosingType,
                    methods,
                    originalMethodList,
                    previousMethods);
            }

            return methods;
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

        private static bool IsStringToETagMatch(MethodSignature previousSignature, MethodSignature currentSignature)
        {
            if (previousSignature.Name != currentSignature.Name
                || previousSignature.Parameters.Count != currentSignature.Parameters.Count
                || previousSignature.Modifiers.HasFlag(MethodSignatureModifiers.Static) != currentSignature.Modifiers.HasFlag(MethodSignatureModifiers.Static)
                || !IsPublicApi(currentSignature.Modifiers)
                || !TypesMatch(previousSignature.ReturnType, currentSignature.ReturnType))
            {
                return false;
            }

            var hasETagChange = false;
            for (var i = 0; i < previousSignature.Parameters.Count; i++)
            {
                var previousParameter = previousSignature.Parameters[i];
                var currentParameter = currentSignature.Parameters[i];
                if (previousParameter.Name != currentParameter.Name
                    || previousParameter.IsRef != currentParameter.IsRef
                    || previousParameter.IsOut != currentParameter.IsOut
                    || previousParameter.IsIn != currentParameter.IsIn)
                {
                    return false;
                }

                if (previousParameter.Type.Equals(currentParameter.Type))
                {
                    continue;
                }

                if (!IsConditionalMatchParameter(previousParameter)
                    || previousParameter.Type is not { IsFrameworkType: true, FrameworkType: { } previousFrameworkType }
                    || previousFrameworkType != typeof(string)
                    || currentParameter.Type is not { IsFrameworkType: true, IsNullable: true, FrameworkType: { } frameworkType }
                    || frameworkType != typeof(ETag)
                    || previousParameter.IsRef
                    || previousParameter.IsOut)
                {
                    return false;
                }

                hasETagChange = true;
            }

            return hasETagChange;
        }

        private static MethodProvider BuildStringToETagOverload(
            TypeProvider enclosingType,
            MethodProvider previousMethod,
            MethodProvider currentMethod)
        {
            var previousSignature = previousMethod.Signature;
            var currentSignature = currentMethod.Signature;
            var firstConvertedParameter = -1;
            for (var i = 0; i < previousSignature.Parameters.Count; i++)
            {
                if (!previousSignature.Parameters[i].Type.Equals(currentSignature.Parameters[i].Type)
                    && firstConvertedParameter < 0)
                {
                    firstConvertedParameter = i;
                }
            }

            var removeLeadingDefaults = currentSignature.Parameters[firstConvertedParameter].DefaultValue is not null;
            var parameters = previousSignature.Parameters
                .Select((parameter, index) => CloneParameter(parameter, removeDefault: removeLeadingDefaults && index <= firstConvertedParameter))
                .ToArray();
            var arguments = new ValueExpression[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                ValueExpression value = parameters[i];
                if (!previousSignature.Parameters[i].Type.Equals(currentSignature.Parameters[i].Type))
                {
                    value = new TernaryConditionalExpression(
                        parameters[i].NotEqual(Null),
                        New.Instance(typeof(ETag), parameters[i]),
                        new CastExpression(Null, currentSignature.Parameters[i].Type));
                }

                arguments[i] = parameters[i].IsRef || parameters[i].IsOut
                    ? value.AsArgument(isRef: parameters[i].IsRef, isOut: parameters[i].IsOut)
                    : value;
            }

            var invocationTarget = currentSignature.Modifiers.HasFlag(MethodSignatureModifiers.Static)
                ? Static(enclosingType.Type)
                : This;
            var invocation = invocationTarget.Invoke(currentSignature.Name, arguments);
            var returnsVoid = currentSignature.ReturnType is null
                || currentSignature.ReturnType is { IsFrameworkType: true, FrameworkType: { } returnType } && returnType == typeof(void);
            MethodBodyStatement body = returnsVoid ? invocation.Terminate() : Return(invocation);

            var signature = new MethodSignature(
                previousSignature.Name,
                previousSignature.Description,
                previousSignature.Modifiers & ~MethodSignatureModifiers.Async,
                previousSignature.ReturnType,
                previousSignature.ReturnDescription,
                parameters,
                Attributes: [.. previousSignature.Attributes, new AttributeStatement(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))],
                GenericArguments: previousSignature.GenericArguments,
                GenericParameterConstraints: previousSignature.GenericParameterConstraints,
                ExplicitInterface: previousSignature.ExplicitInterface,
                NonDocumentComment: previousSignature.NonDocumentComment);

            return new MethodProvider(signature, body, enclosingType, previousMethod.XmlDocs);
        }

        private static ParameterProvider CloneParameter(ParameterProvider parameter, bool removeDefault)
            => new(
                parameter.Name,
                parameter.Description,
                parameter.Type,
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

        private static bool IsConditionalMatchParameter(ParameterProvider parameter)
            => parameter.Name is "ifMatch" or "ifNoneMatch";

        private static bool IsPublicApi(MethodSignatureModifiers modifiers)
            => (modifiers.HasFlag(MethodSignatureModifiers.Public) || modifiers.HasFlag(MethodSignatureModifiers.Protected))
                && !modifiers.HasFlag(MethodSignatureModifiers.Private);

        private static bool TypesMatch(CSharpType? previousType, CSharpType? currentType)
        {
            if (previousType is null || currentType is null)
            {
                return previousType is null && currentType is null;
            }

            return previousType.Equals(currentType);
        }

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
