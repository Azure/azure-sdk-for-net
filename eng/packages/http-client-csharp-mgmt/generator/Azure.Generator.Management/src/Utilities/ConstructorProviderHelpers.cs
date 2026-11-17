// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Utilities
{
    internal static class ConstructorProviderHelpers
    {
        // Work around MTG dropping historical constructor overloads that differ by value-type nullability.
        // https://github.com/microsoft/typespec/issues/12407
        internal static IReadOnlyList<ConstructorProvider> RestoreValueTypeNullabilityOverloads(
            ModelProvider model,
            IReadOnlyList<ConstructorProvider> originalConstructors,
            IReadOnlyList<ConstructorProvider> restoredConstructors)
        {
            if (model.LastContractView is not { Constructors.Count: > 0 } contract)
            {
                return restoredConstructors;
            }

            // Custom constructor bodies and initializers are not represented by the generated providers.
            if (model.CustomCodeView is { Constructors.Count: > 0 })
            {
                return restoredConstructors;
            }

            var affectedSignatures = contract.Constructors.Where(h => h.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                && !ModelCompatibilityValidator.IsConstructorRemovalAccepted(model, h.Signature)
                && restoredConstructors.Any(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                    && HaveSameParameters(h.Signature, c.Signature, ignoreNullable: true)
                    && !HaveSameParameters(h.Signature, c.Signature))).Select(c => c.Signature).ToArray();
            var initializers = new List<(ConstructorProvider Constructor, ConstructorInitializer Initializer)>();
            foreach (var existing in restoredConstructors)
            {
                if (existing.Signature.Initializer is not { IsBase: false } initializer
                    || !affectedSignatures.Any(s => AcceptsArgumentCount(s, initializer.Arguments.Count)))
                {
                    continue;
                }

                var targets = restoredConstructors.Where(c => c != existing
                    && AcceptsArgumentCount(c.Signature, initializer.Arguments.Count)).ToArray();
                if (targets.Length != 1 || targets[0].Signature.Parameters.Count != initializer.Arguments.Count
                    || targets[0].Signature.Parameters.Any(p => p.IsParams || p.IsRef || p.IsOut || p.IsIn)
                    || initializer.Arguments.Any(a => a is PositionalParameterReferenceExpression or ArgumentExpression))
                {
                    return restoredConstructors;
                }

                // Preserve target typing before adding an overload: this(default) must not change null to zero.
                var arguments = initializer.Arguments.Select((argument, i) =>
                    (ValueExpression)new CastExpression(argument, targets[0].Signature.Parameters[i].Type)).ToArray();
                initializers.Add((existing, new ConstructorInitializer(false, arguments)));
            }

            var constructors = restoredConstructors.ToList();
            var changed = false;
            foreach (var constructor in restoredConstructors.Where(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)))
            {
                // Upstream signature matching ignores T versus T?. Retain both CLR overloads
                // by forwarding to a constructor that can represent every historical null value.
                var previous = contract.Constructors.Where(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                    && !ModelCompatibilityValidator.IsConstructorRemovalAccepted(model, c.Signature)
                    && HaveSameParameters(c.Signature, constructor.Signature, ignoreNullable: true)).ToArray();
                if (previous.Length == 0)
                {
                    continue;
                }

                var parameters = constructor.Signature.Parameters;
                var isRestored = !originalConstructors.Contains(constructor);
                var nullableParameters = parameters.Select((p, i) => p.Type.IsValueType && !p.Type.IsNullable
                    && previous.Any(c => c.Signature.Parameters[i].Type.IsNullable)).ToArray();
                if (parameters.Where((_, i) => nullableParameters[i]).Any(p => !isRestored
                    || p.Property is not FlattenedPropertyProvider { Type.IsNullable: true }
                    || constructor.Signature.Initializer?.Arguments.OfType<VariableExpression>()
                        .Any(a => a.Declaration.RequestedName == p.Name) == true))
                {
                    continue;
                }

                // Keep the existing parameter instances: the restored assignment body refers to them.
                for (int i = 0; i < parameters.Count; i++)
                {
                    if (nullableParameters[i])
                    {
                        parameters[i].Update(type: parameters[i].Type.WithNullable(true));
                        changed = true;
                    }
                }
                if (isRestored && !previous.Any(c => HaveSameParameters(c.Signature, constructor.Signature)))
                {
                    constructor.Signature.Update(modifiers: MethodSignatureModifiers.Internal);
                }

                foreach (var historical in previous)
                {
                    if (constructors.Concat(model.CustomCodeView?.Constructors ?? [])
                        .Any(c => HaveSameParameters(c.Signature, historical.Signature)))
                    {
                        continue;
                    }

                    var forwardingParameters = historical.Signature.Parameters.Select(p => BackCompatHelper.CloneParameter(p)).ToArray();
                    var arguments = forwardingParameters.Select((p, i) => p.Type.Equals(parameters[i].Type)
                        ? (ValueExpression)p
                        : new CastExpression(p, parameters[i].Type)).ToArray();
                    var signature = new ConstructorSignature(model.Type, historical.Signature.Description,
                        historical.Signature.Modifiers, forwardingParameters, historical.Signature.Attributes,
                        new ConstructorInitializer(false, arguments));
                    constructors.Add(new ConstructorProvider(signature, MethodBodyStatement.Empty, model));
                    changed = true;
                }
            }
            if (changed)
            {
                foreach (var (constructor, initializer) in initializers)
                {
                    var signature = constructor.Signature;
                    constructor.Update(signature: new ConstructorSignature(signature.Type, signature.Description,
                        signature.Modifiers, signature.Parameters, signature.Attributes, initializer));
                }
            }
            return constructors;
        }

        private static bool AcceptsArgumentCount(ConstructorSignature signature, int count)
            => (signature.Parameters.LastOrDefault()?.IsParams == true && count >= signature.Parameters.Count - 1)
                || (signature.Parameters.Count >= count && signature.Parameters.Skip(count).All(p => p.DefaultValue is not null));

        private static bool HaveSameParameters(ConstructorSignature first, ConstructorSignature second, bool ignoreNullable = false)
            => first.Parameters.Count == second.Parameters.Count
                && first.Parameters.Zip(second.Parameters).All(pair => pair.First.Name == pair.Second.Name
                    && pair.First.Type.HasSamePublicType(pair.Second.Type,
                        ignoreNullable: ignoreNullable || !pair.First.Type.IsValueType));

        /// <summary>
        /// Builds a constructor for the enclosing type for mocking purposes.
        /// </summary>
        /// <param name="enclosingType">The type provider to build the constructor for.</param>
        public static ConstructorProvider BuildMockingConstructor(TypeProvider enclosingType)
        {
            return new ConstructorProvider(
                new ConstructorSignature(enclosingType.Type, $"Initializes a new instance of {enclosingType.Name} for mocking.", MethodSignatureModifiers.Protected, []),
                new MethodBodyStatement[] { MethodBodyStatement.Empty },
                enclosingType);
        }
    }
}
