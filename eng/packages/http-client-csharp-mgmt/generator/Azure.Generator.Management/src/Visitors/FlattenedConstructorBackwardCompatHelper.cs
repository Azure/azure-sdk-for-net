// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors
{
    internal static class FlattenedConstructorBackwardCompatHelper
    {
        // A flattened property's shared AsParameter cannot represent both historical T and T?
        // signatures. Once ordinary restoration has produced the T? overload, restore T by
        // forwarding to it. Never take the reverse path: T? -> T could discard a null value.
        internal static void RestoreNonNullableOverloads(ModelProvider model)
        {
            // Custom constructors may participate in this(default) binding or own the
            // initializer themselves. Do not change their overload set or rewrite their
            // behavior based on the incomplete generated-only constructor view.
            if (model.LastContractView is not { } lastContract
                || model.CustomCodeView?.Constructors.Count is > 0)
            {
                return;
            }

            var flattenedParameterNames = model.CanonicalView.Properties.OfType<FlattenedPropertyProvider>()
                .Select(p => p.AsParameter.Name).ToHashSet();
            if (flattenedParameterNames.Count == 0)
            {
                return;
            }

            var constructors = model.Constructors.ToList();
            foreach (var previous in lastContract.Constructors)
            {
                var signature = previous.Signature;
                if (!signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                    || ModelCompatibilityValidator.IsConstructorRemovalAccepted(model, signature)
                    || constructors.Any(c => HasSameSignature(c.Signature, signature)))
                {
                    continue;
                }

                var target = constructors.FirstOrDefault(c => CanForwardTo(signature, c.Signature, flattenedParameterNames));
                if (target is null || !TryPreserveDefaultInitializerBindings(constructors, signature))
                {
                    continue;
                }

                // Each overload owns its parameters; do not mutate either the historical
                // contract or the flattened property's shared parameter to change nullability.
                var parameters = signature.Parameters.Select((p, i) => new ParameterProvider(
                    p.Name, target.Signature.Parameters[i].Description, p.Type,
                    defaultValue: p.DefaultValue, attributes: p.Attributes,
                    property: target.Signature.Parameters[i].Property)).ToArray();
                var arguments = parameters.Select((p, i) => p.Type.HasSamePublicType(target.Signature.Parameters[i].Type)
                    ? (ValueExpression)p
                    // Select the nullable overload explicitly, rather than recursively calling this one.
                    : ((ValueExpression)p).CastTo(target.Signature.Parameters[i].Type)).ToArray();
                var restoredSignature = new ConstructorSignature(
                    model.Type, target.Signature.Description, signature.Modifiers, parameters,
                    [new AttributeStatement(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))],
                    new ConstructorInitializer(false, arguments));
                constructors.Add(new ConstructorProvider(restoredSignature, MethodBodyStatement.Empty, model));
            }

            if (constructors.Count != model.Constructors.Count)
            {
                model.Update(constructors: constructors);
            }
        }

        private static bool TryPreserveDefaultInitializerBindings(
            IReadOnlyList<ConstructorProvider> constructors, ConstructorSignature addedSignature)
        {
            var updates = new List<(ConstructorSignature Signature, ConstructorInitializer Initializer)>();
            foreach (var constructor in constructors)
            {
                if (constructor.Signature.Initializer is not { IsBase: false } initializer
                    || !initializer.Arguments.Any(IsUntypedDefault)
                    || !CanAcceptArgumentCount(addedSignature, initializer.Arguments.Count))
                {
                    continue;
                }

                // MTG's restored parameterless constructor uses this(default, ...). Adding
                // T alongside T? can rebind that call and turn null into default(T). Pin its
                // original target only when arity identifies it uniquely; do not guess an
                // overload binding when other constructors or params arrays could compete.
                var targets = constructors.Where(c => c != constructor
                    && CanAcceptArgumentCount(c.Signature, initializer.Arguments.Count)).ToArray();
                if (targets.Length != 1 || targets[0].Signature.Parameters.Any(p => p.IsParams))
                {
                    return false;
                }

                var arguments = initializer.Arguments.Select((argument, i) => IsUntypedDefault(argument)
                    ? argument.CastTo(targets[0].Signature.Parameters[i].Type)
                    : argument).ToArray();
                updates.Add((constructor.Signature, new ConstructorInitializer(false, arguments)));
            }

            foreach (var (signature, initializer) in updates)
            {
                signature.Update(initializer: initializer);
            }
            return true;
        }

        private static bool IsUntypedDefault(ValueExpression expression)
            => expression is KeywordExpression { Keyword: "default", Expression: null };

        private static bool CanAcceptArgumentCount(ConstructorSignature signature, int argumentCount)
            => signature.Parameters.LastOrDefault()?.IsParams == true
                ? argumentCount >= signature.Parameters.Count - 1
                : argumentCount <= signature.Parameters.Count
                    && signature.Parameters.Skip(argumentCount).All(p => p.DefaultValue is not null);

        private static bool HasSameSignature(ConstructorSignature left, ConstructorSignature right)
            => left.Parameters.Count == right.Parameters.Count
                && left.Parameters.Zip(right.Parameters).All(pair => pair.First.Type.HasSamePublicType(pair.Second.Type));

        private static bool CanForwardTo(
            ConstructorSignature previous, ConstructorSignature target, HashSet<string> flattenedParameterNames)
        {
            if (!target.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                || previous.Parameters.Count != target.Parameters.Count)
            {
                return false;
            }

            var widensFlattenedParameter = false;
            foreach (var (source, destination) in previous.Parameters.Zip(target.Parameters))
            {
                if (source.Name != destination.Name
                    || source.IsRef || source.IsOut || source.IsIn || source.IsParams
                    || destination.IsRef || destination.IsOut || destination.IsIn || destination.IsParams)
                {
                    return false;
                }

                if (source.Type.HasSamePublicType(destination.Type))
                {
                    continue;
                }

                if (!flattenedParameterNames.Contains(source.Name)
                    || !source.Type.IsValueType || source.Type.IsNullable || !destination.Type.IsNullable
                    || !source.Type.HasSamePublicType(destination.Type, ignoreNullable: true))
                {
                    return false;
                }

                widensFlattenedParameter = true;
            }

            return widensFlattenedParameter;
        }
    }
}
