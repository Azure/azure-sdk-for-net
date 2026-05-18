// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Management.Visitors
{
    internal class ConstructorCompatibilityVisitor : ScmLibraryVisitor
    {
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelProvider model)
            {
                AddLegacyConstructorOverloads(model);
            }

            return base.VisitType(type);
        }

        internal static void AddLegacyConstructorOverloads(ModelProvider model)
        {
            var previousConstructors = model.LastContractView?.Constructors;
            if (previousConstructors is null || previousConstructors.Count == 0)
            {
                return;
            }

            var currentConstructors = model.Constructors.ToList();
            var fullConstructor = model.FullConstructor;
            var fullParameters = fullConstructor.Signature.Parameters;
            var added = false;

            foreach (var previousConstructor in previousConstructors)
            {
                var previousSignature = previousConstructor.Signature;
                var previousParameters = previousSignature.Parameters;
                if (!previousSignature.Modifiers.HasFlag(MethodSignatureModifiers.Internal)
                    || previousParameters.Count != fullParameters.Count
                    || HasConstructorWithSameParameterTypes(currentConstructors, previousParameters)
                    || !TryBuildCurrentConstructorArguments(previousParameters, fullParameters, out var initializerArguments)
                    || HasSameParameterOrder(previousParameters, fullParameters))
                {
                    continue;
                }

                var signature = new ConstructorSignature(
                    model.Type,
                    previousSignature.Description,
                    previousSignature.Modifiers,
                    previousParameters,
                    previousSignature.Attributes,
                    new ConstructorInitializer(false, initializerArguments));
                currentConstructors.Add(new ConstructorProvider(signature, MethodBodyStatement.Empty, model));
                added = true;
            }

            if (added)
            {
                model.Update(constructors: currentConstructors);
            }
        }

        private static bool HasConstructorWithSameParameterTypes(IEnumerable<ConstructorProvider> constructors, IReadOnlyList<ParameterProvider> parameters)
        {
            return constructors.Any(constructor =>
                constructor.Signature.Parameters.Count == parameters.Count
                && constructor.Signature.Parameters.Zip(parameters).All(pair => pair.First.Type.AreNamesEqual(pair.Second.Type)));
        }

        private static bool HasSameParameterOrder(IReadOnlyList<ParameterProvider> previousParameters, IReadOnlyList<ParameterProvider> fullParameters)
        {
            return previousParameters.Zip(fullParameters).All(pair =>
                string.Equals(pair.First.Name, pair.Second.Name, StringComparison.OrdinalIgnoreCase)
                && pair.First.Type.AreNamesEqual(pair.Second.Type));
        }

        private static bool TryBuildCurrentConstructorArguments(
            IReadOnlyList<ParameterProvider> previousParameters,
            IReadOnlyList<ParameterProvider> fullParameters,
            [NotNullWhen(true)] out IReadOnlyList<ValueExpression>? initializerArguments)
        {
            var arguments = new List<ValueExpression>(fullParameters.Count);
            var usedPreviousParameterIndexes = new HashSet<int>();
            foreach (var fullParameter in fullParameters)
            {
                var previousParameterIndex = FindMatchingParameter(previousParameters, fullParameter, usedPreviousParameterIndexes);
                if (previousParameterIndex < 0)
                {
                    initializerArguments = null;
                    return false;
                }

                usedPreviousParameterIndexes.Add(previousParameterIndex);
                arguments.Add(previousParameters[previousParameterIndex]);
            }

            initializerArguments = arguments;
            return true;
        }

        private static int FindMatchingParameter(
            IReadOnlyList<ParameterProvider> previousParameters,
            ParameterProvider fullParameter,
            IReadOnlySet<int> usedPreviousParameterIndexes)
        {
            for (int i = 0; i < previousParameters.Count; i++)
            {
                if (!usedPreviousParameterIndexes.Contains(i)
                    && string.Equals(previousParameters[i].Name, fullParameter.Name, StringComparison.OrdinalIgnoreCase)
                    && previousParameters[i].Type.AreNamesEqual(fullParameter.Type))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
