// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors;

/// <summary>
/// Repairs model constructor calls in generated deserialization methods after visitors finalize model shape.
/// </summary>
internal static class SerializationConstructorCallHelper
{
    internal static void FixConstructorCalls(IReadOnlyList<MethodProvider> methods)
    {
        foreach (var method in methods)
        {
            if (method.BodyStatements is null || !method.Signature.Name.StartsWith("Deserialize", StringComparison.Ordinal))
            {
                continue;
            }

            var updatedBodyStatements = new List<MethodBodyStatement>();
            var bodyUpdated = false;
            var unusedLocalVariables = new HashSet<VariableExpression>();
            foreach (var statement in method.BodyStatements)
            {
                if (statement is ExpressionStatement { Expression: KeywordExpression { Expression: NewInstanceExpression newInstanceExpression } }
                    && TryRebuildNewInstanceFromNamedArguments(newInstanceExpression, out var updatedArguments, out var unusedArguments))
                {
                    foreach (var unusedArgument in unusedArguments)
                    {
                        if (unusedArgument is VariableExpression unusedVariable)
                        {
                            unusedLocalVariables.Add(unusedVariable);
                        }
                    }
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
                if (unusedLocalVariables.Count > 0)
                {
                    updatedBodyStatements.RemoveAll(statement => IsUnusedLocalDeclaration(statement, unusedLocalVariables));
                }
                method.Update(bodyStatements: updatedBodyStatements);
            }
        }
    }

    private static bool IsUnusedLocalDeclaration(MethodBodyStatement statement, IReadOnlySet<VariableExpression> unusedLocalVariables)
        => statement is ExpressionStatement { Expression: AssignmentExpression { Variable: DeclarationExpression declaration } }
            && unusedLocalVariables.Contains(declaration.Variable);

    private static bool TryRebuildNewInstanceFromNamedArguments(
        NewInstanceExpression newInstanceExpression,
        [NotNullWhen(true)] out IReadOnlyList<ValueExpression>? updatedArguments,
        out IReadOnlyList<ValueExpression> unusedArguments)
    {
        updatedArguments = null;
        unusedArguments = [];
        if (newInstanceExpression.Type is null || !TryGetModelProvider(newInstanceExpression.Type, out var modelProvider))
        {
            return false;
        }

        var constructorParameters = modelProvider.FullConstructor.Signature.Parameters;
        var argumentsByName = new Dictionary<string, ValueExpression>(StringComparer.Ordinal);
        foreach (var argument in newInstanceExpression.Parameters)
        {
            if (!TryGetArgumentName(argument, out var argumentName))
            {
                return false;
            }

            // Serialization bodies can be built before inherited duplicate properties are removed from the final
            // constructor. Keep the first matching local for the current constructor slot and let stale duplicates drop.
            argumentsByName.TryAdd(argumentName, argument);
        }

        var arguments = new List<ValueExpression>(constructorParameters.Count);
        var usedArguments = new HashSet<ValueExpression>();
        var changed = constructorParameters.Count != newInstanceExpression.Parameters.Count;
        foreach (var constructorParameter in constructorParameters)
        {
            if (TryGetArgumentByName(argumentsByName, constructorParameter, out var argument))
            {
                arguments.Add(argument);
                usedArguments.Add(argument);
                var index = arguments.Count - 1;
                if (!changed && !ReferenceEquals(argument, newInstanceExpression.Parameters[index]))
                {
                    changed = true;
                }
            }
            else
            {
                arguments.Add(GetDefaultArgument(constructorParameter));
                changed = true;
            }
        }

        unusedArguments = newInstanceExpression.Parameters.Where(argument => !usedArguments.Contains(argument)).ToArray();
        updatedArguments = changed ? arguments : null;
        return changed;
    }

    private static bool TryGetArgumentByName(
        IReadOnlyDictionary<string, ValueExpression> argumentsByName,
        ParameterProvider constructorParameter,
        [NotNullWhen(true)] out ValueExpression? argument)
    {
        if (argumentsByName.TryGetValue(constructorParameter.Name, out argument))
        {
            return true;
        }

        argument = null;
        foreach (var candidate in argumentsByName)
        {
            if (!string.Equals(candidate.Key, constructorParameter.Name, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (argument is not null)
            {
                argument = null;
                return false;
            }

            argument = candidate.Value;
        }

        if (argument is not null)
        {
            return true;
        }

        if (constructorParameter.Property is not { } property ||
            !ManagementClientGenerator.Instance.DateTimePropertyMatcher.IsMtgRenamedDateTimeProperty(property))
        {
            return false;
        }

        foreach (var candidate in argumentsByName.Values)
        {
            if (!ManagementClientGenerator.Instance.DateTimePropertyMatcher.HasSameSourceProperty(property, candidate))
            {
                continue;
            }

            if (argument is not null)
            {
                argument = null;
                return false;
            }

            argument = candidate;
        }

        return argument is not null;
    }

    private static bool TryGetArgumentName(ValueExpression argument, [NotNullWhen(true)] out string? name)
    {
        switch (argument)
        {
            case VariableExpression variable:
                name = variable.Declaration.RequestedName;
                return true;
            case PositionalParameterReferenceExpression positional:
                name = positional.ParameterName;
                return true;
            case BinaryOperatorExpression binary:
                return TryGetArgumentName(binary.Left, out name);
            default:
                name = null;
                return false;
        }
    }

    private static ValueExpression GetDefaultArgument(ParameterProvider parameter)
        // Emit typed defaults when a parameter has no explicit default. Bare `default` can become ambiguous
        // when a generated model exposes multiple constructors with the same arity.
        => parameter.DefaultValue ?? Default.CastTo(parameter.Type);

    private static bool TryGetModelProvider(CSharpType type, [NotNullWhen(true)] out ModelProvider? modelProvider)
    {
        if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(type, out var typeProvider) && typeProvider is ModelProvider model)
        {
            modelProvider = model;
            return true;
        }
        foreach (var mappedProvider in ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.Values)
        {
            if (mappedProvider is ModelProvider mappedModel && mappedModel.Type.AreNamesEqual(type))
            {
                modelProvider = mappedModel;
                return true;
            }
        }
        foreach (var inputModel in ManagementClientGenerator.Instance.InputLibrary.InputNamespace.Models)
        {
            if (ManagementClientGenerator.Instance.TypeFactory.CreateModel(inputModel) is { } inputModelProvider
                && inputModelProvider.Type.AreNamesEqual(type))
            {
                modelProvider = inputModelProvider;
                return true;
            }
        }
        foreach (var outputModel in ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ModelProvider>())
        {
            if (outputModel.Type.AreNamesEqual(type))
            {
                modelProvider = outputModel;
                return true;
            }
        }
        modelProvider = null;
        return false;
    }
}
