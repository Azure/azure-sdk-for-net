// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;

namespace Extensions.Plugin.Visitors
{
    /// <summary>
    /// Opts generated model implementations into experimental members without making otherwise-stable
    /// constructors or serialization entry points experimental for consumers.
    /// </summary>
    public class ExperimentalImplementationVisitor : ScmLibraryVisitor
    {
        private const string Justification = "The implementation handles experimental model members without exposing them in its signature.";

        protected override TypeProvider VisitType(TypeProvider type)
        {
            // Work from model metadata only. In particular, do not build the ModelReaderWriterContext or
            // inspect CanonicalView here: doing so can cache declarations before their warning wrappers exist.
            if (type is not ModelProvider model || GetDiagnosticId(type.Attributes) is not null
                || GetDiagnosticId(type.CustomCodeView?.Attributes ?? []) is not null)
            {
                return type;
            }

            Dictionary<string, string[]> propertyDiagnostics = [];
            foreach (PropertyProvider property in model.Properties)
            {
                string id = GetDiagnosticId(property.Attributes);
                if (id is not null)
                {
                    propertyDiagnostics[property.Name] = new[] { id }.Concat(GetOpenAIDiagnosticIds(property.Type)).Distinct().ToArray();
                }
            }

            foreach (ConstructorProvider constructor in model.Constructors)
            {
                if (GetDiagnosticId(constructor.Signature.Attributes) is not null || constructor.BodyStatements is null)
                {
                    continue;
                }

                // Generated model constructors assign properties directly. Only opt in constructors that
                // actually initialize an experimental property, not every constructor on the stable model.
                IEnumerable<string> diagnostics = constructor.BodyStatements
                    .OfType<ExpressionStatement>()
                    .Select(statement => GetAssignedMember(statement.Expression))
                    .Where(name => name is not null && propertyDiagnostics.ContainsKey(name))
                    .SelectMany(name => propertyDiagnostics[name]);
                constructor.Update(suppressions: AddSuppressions(constructor.Suppressions, diagnostics));
            }

            string[] writeDiagnostics = model.Properties
                .Select(property => GetDiagnosticId(property.Attributes))
                .Where(id => id is not null)
                .Concat(model.Properties.Where(property => property.Type.IsCollection)
                    .SelectMany(property => GetOpenAIDiagnosticIds(property.Type)))
                .Distinct()
                .ToArray();
            string[] readDiagnostics = model.Constructors.Select(constructor => GetDiagnosticId(constructor.Signature.Attributes))
                .Where(id => id is not null)
                .Concat(model.Properties.SelectMany(property => GetOpenAIDiagnosticIds(property.Type)))
                .Distinct()
                .ToArray();
            string[] derivedDiagnostics = model.DerivedModels
                .Where(derived => derived.DiscriminatorValue is not null)
                .Select(derived => GetDiagnosticId(derived.Attributes))
                .Where(id => id is not null)
                .Distinct()
                .ToArray();

            foreach (TypeProvider serialization in model.SerializationProviders)
            {
                foreach (MethodProvider method in serialization.Methods)
                {
                    if (GetDiagnosticId(method.Signature.Attributes) is not null)
                    {
                        continue;
                    }

                    // These are the implementation methods that access properties, construct collection
                    // elements, and dispatch to experimental derived models. The MRW forwarding methods
                    // and public conversion operators do not need opt-ins.
                    IEnumerable<string> diagnostics = method.Signature.Name == "JsonModelWriteCore"
                        ? writeDiagnostics
                        : method.Signature.Name == $"Deserialize{model.Name}"
                            ? readDiagnostics.Concat(derivedDiagnostics)
                            : [];
                    method.Update(suppressions: AddSuppressions(method.Suppressions, diagnostics));
                }
            }

            return type;
        }

        private static string GetAssignedMember(ValueExpression expression)
        {
            if (expression is not AssignmentExpression assignment)
            {
                return null;
            }

            ValueExpression variable = assignment.Variable;
            while (variable is ScopedApi scoped)
            {
                variable = scoped.Original;
            }
            return variable switch
            {
                MemberExpression member when member.Inner is null => member.MemberName,
                VariableExpression member => member.Declaration.RequestedName,
                _ => null
            };
        }

        private static string GetDiagnosticId(IEnumerable<AttributeStatement> attributes)
        {
            foreach (AttributeStatement attribute in attributes)
            {
                if (!attribute.Type.Equals(typeof(ExperimentalAttribute)) || attribute.Arguments.Count == 0)
                {
                    continue;
                }
                ValueExpression argument = attribute.Arguments[0];
                while (argument is ScopedApi scoped)
                {
                    argument = scoped.Original;
                }
                if (argument is LiteralExpression { Literal: string id })
                {
                    return id;
                }
            }
            return null;
        }

        private static IEnumerable<string> GetOpenAIDiagnosticIds(CSharpType type)
        {
            type = type.GetNestedElementType();
            foreach (string id in OpenAIExperimentalCatalog.Instance.GetDiagnosticIds(type.FullyQualifiedName))
            {
                yield return id;
            }
            foreach (CSharpType argument in type.Arguments)
            {
                foreach (string argumentId in GetOpenAIDiagnosticIds(argument))
                {
                    yield return argumentId;
                }
            }
        }

        private static IEnumerable<SuppressionStatement> AddSuppressions(
            IReadOnlyList<SuppressionStatement> existing, IEnumerable<string> diagnostics)
        {
            return existing.Concat(diagnostics.Distinct().Where(id => !existing.Any(suppression =>
                suppression.Code is ScopedApi { Original: LiteralExpression { Literal: string code } } && code == id))
                .Select(id => new SuppressionStatement(null, Snippet.Literal(id), Justification))).ToArray();
        }
    }
}
