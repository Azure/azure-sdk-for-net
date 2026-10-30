// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Provisioning.Providers;
using Azure.Generator.Provisioning.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning.Visitors
{
    internal class ExperimentalFlattenedPropertyVisitor : ScmLibraryVisitor
    {
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            foreach (var property in type.Properties)
            {
                if (property is not ProvisioningPropertyProvider
                    && property.WireInfo is not null
                    && !property.Attributes.Any(ApiVersionHelpers.IsExperimental)
                    && FindExperimentalAttribute(property, new HashSet<PropertyProvider>()) is { } attribute)
                {
                    property.Update(attributes: [.. property.Attributes, attribute]);
                }
            }

            return base.VisitType(type);
        }

        private static AttributeStatement? FindExperimentalAttribute(PropertyProvider property, HashSet<PropertyProvider> visited)
        {
            if (!visited.Add(property))
            {
                return null;
            }

            var attribute = property.Attributes.FirstOrDefault(ApiVersionHelpers.IsExperimental)
                ?? property.EnclosingType.Attributes.FirstOrDefault(ApiVersionHelpers.IsExperimental)
                ?? property.EnclosingType.CustomCodeView?.Attributes.FirstOrDefault(ApiVersionHelpers.IsExperimental);
            if (attribute is not null)
            {
                return attribute;
            }

            if (property is ProvisioningPropertyProvider || GetForwardedMember(property.Body) is not
                { Inner: MemberExpression { Inner: null } outerMember } forwarded)
            {
                return null;
            }

            // The management flattening provider is internal to the pinned dependency. Its
            // public getter AST retains the forwarding path, including nested flattening.
            // Follow that path without changing attributes on shared stable leaf providers.
            var outer = property.EnclosingType.Properties
                .Concat(property.EnclosingType.CustomCodeView?.Properties ?? [])
                .FirstOrDefault(candidate =>
                ReferenceEquals((MemberExpression)candidate, outerMember));
            if (outer is null)
            {
                return null;
            }

            attribute = FindExperimentalAttribute(outer, visited);
            if (attribute is not null)
            {
                return attribute;
            }

            if (ProvisioningGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(outer.Type, out var innerType)
                && innerType is not null)
            {
                return innerType.Attributes.FirstOrDefault(ApiVersionHelpers.IsExperimental)
                    ?? innerType.CustomCodeView?.Attributes.FirstOrDefault(ApiVersionHelpers.IsExperimental)
                    ?? (innerType.CanonicalView.Properties.FirstOrDefault(candidate =>
                        candidate.Name == forwarded.MemberName) is { } inner
                        ? FindExperimentalAttribute(inner, visited)
                        : null);
            }

            return null;
        }

        private static MemberExpression? GetForwardedMember(PropertyBody body)
        {
            if (body is not MethodPropertyBody methodBody)
            {
                return null;
            }

            var statement = methodBody.Getter is MethodBodyStatements statements
                ? statements.Statements.LastOrDefault()
                : methodBody.Getter;
            if (statement is not ExpressionStatement { Expression: KeywordExpression { Keyword: "return" } returned })
            {
                return null;
            }

            var expression = returned.Expression is TernaryConditionalExpression conditional
                ? conditional.Alternative
                : returned.Expression;
            return expression as MemberExpression;
        }
    }
}
