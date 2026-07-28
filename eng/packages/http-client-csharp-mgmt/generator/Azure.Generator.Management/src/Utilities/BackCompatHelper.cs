// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Applies the management back-compat decorations to the overloads that were added on top of <paramref name="originalMethods"/>.
        /// </summary>
        /// <param name="backCompatMethods">The full method list produced by the base back-compat generation.</param>
        /// <param name="originalMethods">The methods that existed before the base synthesized the compatibility overloads.</param>
        /// <returns>The same <paramref name="backCompatMethods"/> list, with the synthesized overloads decorated.</returns>
        internal static IReadOnlyList<MethodProvider> DecorateBackwardCompatibilityMethods(
            IReadOnlyList<MethodProvider> backCompatMethods,
            IEnumerable<MethodProvider> originalMethods)
        {
            var originalMethodSet = new HashSet<MethodProvider>(originalMethods, ReferenceEqualityComparer.Instance);

            foreach (var method in backCompatMethods)
            {
                if (originalMethodSet.Contains(method))
                {
                    continue;
                }

                DecorateBackwardCompatibilityMethod(method);
            }

            return backCompatMethods;
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

        internal static void DisambiguateOptionalOverloads(
            IReadOnlyList<MethodProvider> generatedMethods,
            IReadOnlyList<MethodProvider> customMethods)
        {
            foreach (var generatedMethod in generatedMethods)
            {
                foreach (var customMethod in customMethods)
                {
                    var generatedParameters = generatedMethod.Signature.Parameters;
                    var customParameters = customMethod.Signature.Parameters;
                    int requiredParameterCount = GetRequiredParameterCount(generatedParameters);
                    if (generatedMethod.Signature.Name != customMethod.Signature.Name ||
                        customParameters.Count >= generatedParameters.Count ||
                        requiredParameterCount != GetRequiredParameterCount(customParameters))
                    {
                        continue;
                    }

                    if (!TryGetFirstExtraParameterIndex(generatedParameters, customParameters, out int firstExtraParameterIndex))
                    {
                        firstExtraParameterIndex = requiredParameterCount;
                    }

                    for (int i = 0; i <= firstExtraParameterIndex; i++)
                    {
                        generatedParameters[i].DefaultValue = null;
                    }
                    for (int i = firstExtraParameterIndex + 1; i < generatedParameters.Count; i++)
                    {
                        if (generatedParameters[i].Type.Equals(typeof(CancellationToken)))
                        {
                            generatedParameters[i].DefaultValue ??= Default;
                        }
                    }
                    break;
                }
            }
        }

        private static int GetRequiredParameterCount(IReadOnlyList<ParameterProvider> parameters)
        {
            for (int i = 0; i < parameters.Count; i++)
            {
                if (parameters[i].DefaultValue is not null)
                {
                    return i;
                }
            }
            return parameters.Count;
        }

        private static bool TryGetFirstExtraParameterIndex(
            IReadOnlyList<ParameterProvider> generatedParameters,
            IReadOnlyList<ParameterProvider> customParameters,
            out int firstExtraParameterIndex)
        {
            int customIndex = 0;
            firstExtraParameterIndex = -1;

            for (int generatedIndex = 0; generatedIndex < generatedParameters.Count; generatedIndex++)
            {
                if (customIndex < customParameters.Count &&
                    generatedParameters[generatedIndex].Type.Equals(customParameters[customIndex].Type))
                {
                    customIndex++;
                }
                else if (firstExtraParameterIndex < 0)
                {
                    firstExtraParameterIndex = generatedIndex;
                }
            }

            return customIndex == customParameters.Count && firstExtraParameterIndex >= 0;
        }
    }
}
