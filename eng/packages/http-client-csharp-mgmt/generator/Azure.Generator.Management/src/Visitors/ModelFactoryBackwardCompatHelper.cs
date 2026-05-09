// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors
{
    internal static class ModelFactoryBackwardCompatHelper
    {
        internal static void FixModelFactoryBackwardCompatOverloads(IReadOnlyList<MethodProvider> methods)
        {
            var primaryMethods = new Dictionary<string, MethodProvider>();
            foreach (var method in methods)
            {
                if (!IsBackwardCompatMethod(method))
                {
                    var key = method.Signature.Name;
                    if (!primaryMethods.TryGetValue(key, out var existing) || method.Signature.Parameters.Count > existing.Signature.Parameters.Count)
                    {
                        primaryMethods[key] = method;
                    }
                }
            }

            foreach (var method in methods)
            {
                if (!IsBackwardCompatMethod(method) || method.BodyStatements is null)
                {
                    continue;
                }

                var updatedBodyStatements = new List<MethodBodyStatement>();
                var bodyUpdated = false;
                foreach (var statement in method.BodyStatements)
                {
                    if (TryUpdatePrimaryMethodInvocation(statement, primaryMethods, out var updatedInvocation))
                    {
                        updatedBodyStatements.Add(updatedInvocation);
                        bodyUpdated = true;
                    }
                    else if (statement is ExpressionStatement { Expression: KeywordExpression { Expression: NewInstanceExpression newInstanceExpression } }
                        && TryUpdateNewInstanceArguments(method, newInstanceExpression, out var updatedArguments, out var matchedParameters))
                    {
                        updatedBodyStatements.RemoveAll(s => IsNullCoalescingAssignmentToMatchedParameter(s, matchedParameters));
                        updatedBodyStatements.Add(Return(New.Instance(newInstanceExpression.Type!, updatedArguments)));
                        bodyUpdated = true;
                    }
                    else
                    {
                        updatedBodyStatements.Add(statement);
                    }
                }

                if (bodyUpdated)
                {
                    method.Update(signature: method.Signature, bodyStatements: updatedBodyStatements);
                }
            }
        }

        internal static bool IsBackwardCompatMethod(MethodProvider method)
        {
            return method.Signature.Attributes.Any(a =>
                a.Type is { IsFrameworkType: true } && a.Type.FrameworkType == typeof(System.ComponentModel.EditorBrowsableAttribute));
        }

        private static bool TryUpdatePrimaryMethodInvocation(
            MethodBodyStatement statement,
            IReadOnlyDictionary<string, MethodProvider> primaryMethods,
            [NotNullWhen(true)] out MethodBodyStatement? updatedStatement)
        {
            updatedStatement = null;
            if (statement is not ExpressionStatement expressionStatement
                || (expressionStatement.Expression as KeywordExpression)?.Expression is not InvokeMethodExpression invokeExpression
                || (invokeExpression.MethodName ?? invokeExpression.MethodSignature?.Name) is not string calledMethodName
                || !primaryMethods.TryGetValue(calledMethodName, out var primaryMethod))
            {
                return false;
            }

            var primaryParams = primaryMethod.Signature.Parameters;
            var invokeArgs = invokeExpression.Arguments;
            var invokeSignatureParams = invokeExpression.MethodSignature?.Parameters;

            if (invokeSignatureParams is null || invokeSignatureParams.Count != invokeArgs.Count)
            {
                return false;
            }

            // Compatibility overloads may call the current primary overload using an older parameter order.
            // Rebuild the call by parameter name so old overload arguments continue to flow to their matching
            // current parameters, and any parameters not present in the old overload keep a named default value.
            var argsByName = new Dictionary<string, ValueExpression>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < invokeSignatureParams.Count; i++)
            {
                argsByName[invokeSignatureParams[i].Name] = invokeArgs[i];
            }

            var newArgs = new List<ValueExpression>(primaryParams.Count);
            var changed = false;
            for (int i = 0; i < primaryParams.Count; i++)
            {
                if (argsByName.TryGetValue(primaryParams[i].Name, out var arg))
                {
                    newArgs.Add(arg);
                    if (!changed && (i >= invokeArgs.Count || !ReferenceEquals(arg, invokeArgs[i])))
                    {
                        changed = true;
                    }
                }
                else
                {
                    newArgs.Add(Snippet.PositionalReference(primaryParams[i], primaryParams[i].DefaultValue ?? Default));
                    changed = true;
                }
            }

            if (!changed)
            {
                return false;
            }

            updatedStatement = Return(new InvokeMethodExpression(null, primaryMethod.Signature, newArgs));
            return true;
        }

        private static bool TryUpdateNewInstanceArguments(
            MethodProvider method,
            NewInstanceExpression newInstanceExpression,
            [NotNullWhen(true)] out IReadOnlyList<ValueExpression>? updatedArguments,
            [NotNullWhen(true)] out IReadOnlyList<ParameterProvider>? matchedParameters)
        {
            updatedArguments = null;
            matchedParameters = null;
            if (newInstanceExpression.Type is null || !TryGetModelProvider(newInstanceExpression.Type, out var modelProvider))
            {
                return false;
            }

            var constructorParameters = modelProvider.FullConstructor.Signature.Parameters;
            if (constructorParameters.Count != newInstanceExpression.Parameters.Count)
            {
                return false;
            }

            if (HasNamedArgumentMismatchingFullConstructor(newInstanceExpression.Parameters, constructorParameters))
            {
                return false;
            }

            List<ValueExpression>? arguments = null;
            List<ParameterProvider>? matched = null;
            for (int i = 0; i < newInstanceExpression.Parameters.Count; i++)
            {
                var currentArgument = newInstanceExpression.Parameters[i];
                if (!IsDefaultExpression(currentArgument))
                {
                    continue;
                }

                if (TryBuildCompatibilityArgument(method, constructorParameters[i], [], wrapWithNullCheck: true, out var replacement))
                {
                    arguments ??= [.. newInstanceExpression.Parameters];
                    matched ??= [];
                    arguments[i] = replacement.Argument;
                    matched.AddRange(replacement.MatchedParameters);
                }
            }

            updatedArguments = arguments;
            matchedParameters = matched;
            return arguments is not null;
        }

        private static bool HasNamedArgumentMismatchingFullConstructor(IReadOnlyList<ValueExpression> arguments, IReadOnlyList<ParameterProvider> constructorParameters)
        {
            for (int i = 0; i < arguments.Count; i++)
            {
                if (TryGetNamedArgumentName(arguments[i], out var argumentName)
                    && !string.Equals(argumentName, constructorParameters[i].Name, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool TryGetNamedArgumentName(ValueExpression argument, [NotNullWhen(true)] out string? name)
        {
            name = null;
            var text = argument.ToDisplayString();
            var colonIndex = text.IndexOf(':');
            if (colonIndex <= 0)
            {
                return false;
            }

            var candidate = text[..colonIndex].Trim();
            if (candidate.Length == 0 || candidate.Any(c => !char.IsLetterOrDigit(c) && c != '_' && c != '@'))
            {
                return false;
            }

            name = candidate[0] == '@' ? candidate[1..] : candidate;
            return name.Length > 0;
        }

        private static bool IsNullCoalescingAssignmentToMatchedParameter(
            MethodBodyStatement statement,
            IReadOnlyList<ParameterProvider> parameters)
        {
            var text = statement.ToDisplayString();
            return parameters.Any(parameter => text.StartsWith($"{parameter.Name} ??=", StringComparison.Ordinal));
        }

        private static bool TryBuildCompatibilityArgument(
            MethodProvider method,
            ParameterProvider constructorParameter,
            List<CSharpType> visitedTypes,
            bool wrapWithNullCheck,
            [NotNullWhen(true)] out CompatibilityArgument? argument)
        {
            if (TryGetMethodParameter(method, constructorParameter.Name, constructorParameter.Type, out var directParameter))
            {
                argument = new CompatibilityArgument(BuildParameterArgument(directParameter, constructorParameter.Type), [directParameter]);
                return true;
            }

            if (visitedTypes.Any(type => type.AreNamesEqual(constructorParameter.Type)))
            {
                argument = null;
                return false;
            }

            visitedTypes.Add(constructorParameter.Type);

            if (!TryGetModelProvider(constructorParameter.Type, out var nestedModel))
            {
                argument = null;
                visitedTypes.Remove(constructorParameter.Type);
                return false;
            }

            var nestedConstructorParameters = nestedModel.FullConstructor.Signature.Parameters;
            var nestedArguments = new List<ValueExpression>(nestedConstructorParameters.Count);
            var matchedParameters = new List<ParameterProvider>();
            foreach (var nestedParameter in nestedConstructorParameters)
            {
                if (TryGetNestedCompatibilityArgument(method, constructorParameter.Property, nestedParameter, visitedTypes, out var nestedArgument))
                {
                    nestedArguments.Add(nestedArgument.Argument);
                    matchedParameters.AddRange(nestedArgument.MatchedParameters);
                }
                else
                {
                    nestedArguments.Add(nestedParameter.DefaultValue ?? Default);
                }
            }

            if (matchedParameters.Count == 0)
            {
                argument = null;
                visitedTypes.Remove(constructorParameter.Type);
                return false;
            }

            var newInstance = New.Instance(constructorParameter.Type, nestedArguments);
            var condition = wrapWithNullCheck ? BuildAllNullCondition(matchedParameters) : null;
            var expression = condition is null
                ? newInstance
                : new TernaryConditionalExpression(condition, Default, newInstance);
            argument = new CompatibilityArgument(expression, matchedParameters);
            visitedTypes.Remove(constructorParameter.Type);
            return true;
        }

        private static bool TryGetNestedCompatibilityArgument(MethodProvider method, PropertyProvider? parentProperty, ParameterProvider nestedParameter, List<CSharpType> visitedTypes, [NotNullWhen(true)] out CompatibilityArgument? argument)
        {
            if (parentProperty is not null && nestedParameter.Property is not null)
            {
                var combinedName = PropertyHelpers.GetCombinedPropertyName(nestedParameter.Property, parentProperty).ToVariableName();
                if (TryGetMethodParameter(method, combinedName, nestedParameter.Type, out var combinedParameter))
                {
                    argument = new CompatibilityArgument(BuildParameterArgument(combinedParameter, nestedParameter.Type), [combinedParameter]);
                    return true;
                }
            }

            if (TryGetMethodParameter(method, nestedParameter.Name, nestedParameter.Type, out var directParameter))
            {
                argument = new CompatibilityArgument(BuildParameterArgument(directParameter, nestedParameter.Type), [directParameter]);
                return true;
            }

            return TryBuildCompatibilityArgument(method, nestedParameter, visitedTypes, wrapWithNullCheck: false, out argument);
        }

        private static bool TryGetMethodParameter(MethodProvider method, string name, CSharpType expectedType, [NotNullWhen(true)] out ParameterProvider? parameter)
        {
            parameter = method.Signature.Parameters.FirstOrDefault(p =>
                string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase)
                && AreCompatibleParameterTypes(p.Type, expectedType));
            return parameter is not null;
        }

        private static bool AreCompatibleParameterTypes(CSharpType parameterType, CSharpType expectedType)
            => parameterType.AreNamesEqual(expectedType)
            || parameterType.InputType.AreNamesEqual(expectedType.InputType)
            || AreCompatibleListTypes(parameterType, expectedType);

        private static bool AreCompatibleListTypes(CSharpType parameterType, CSharpType expectedType)
            => parameterType.IsList
            && expectedType.IsList
            && parameterType.Arguments.Count == expectedType.Arguments.Count
            && parameterType.Arguments.Zip(expectedType.Arguments).All(pair => pair.First.AreNamesEqual(pair.Second));

        private static ValueExpression BuildParameterArgument(ParameterProvider parameter, CSharpType expectedType)
        {
            if (AreCompatibleListTypes(parameter.Type, expectedType) && !parameter.Type.AreNamesEqual(expectedType))
            {
                return parameter.NullCoalesce(New.Instance(ManagementClientGenerator.Instance.TypeFactory.ListInitializationType.MakeGenericType(parameter.Type.Arguments))).ToList();
            }

            if (parameter.Type.IsValueType && parameter.Type.IsNullable && expectedType.IsValueType && !expectedType.IsNullable)
            {
                return parameter.Invoke(nameof(Nullable<int>.GetValueOrDefault));
            }

            return parameter;
        }

        private static ScopedApi<bool>? BuildAllNullCondition(IEnumerable<ParameterProvider> parameters)
        {
            ScopedApi<bool>? result = null;
            foreach (var parameter in parameters)
            {
                if (parameter.Type.IsValueType && !parameter.Type.IsNullable)
                {
                    continue;
                }

                result = result is null
                    ? parameter.Is(Null)
                    : result.And(parameter.Is(Null));
            }
            return result;
        }

        private static bool IsDefaultExpression(ValueExpression expression)
        {
            var displayString = expression.ToDisplayString();
            return displayString == "default" || displayString.StartsWith("default(", StringComparison.Ordinal);
        }

        private static bool TryGetModelProvider(CSharpType type, [NotNullWhen(true)] out ModelProvider? modelProvider)
        {
            if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(type, out var typeProvider) && typeProvider is ModelProvider model)
            {
                modelProvider = model;
                return true;
            }
            modelProvider = null;
            return false;
        }

        private record CompatibilityArgument(ValueExpression Argument, IReadOnlyList<ParameterProvider> MatchedParameters);
    }
}
