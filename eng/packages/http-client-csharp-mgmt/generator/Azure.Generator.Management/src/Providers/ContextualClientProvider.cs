// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.Generator.Management.Visitors;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// Represents a base type for providers that hold contextual operations with an associated Id.
    /// This class provides functionality for managing contextual parameters, validating resource identifiers,
    /// and populating arguments for requests based on the context of the operation.
    /// </summary>
    internal abstract class ContextualClientProvider : TypeProvider
    {
        internal const string ValidateResourceIdMethodName = "ValidateResourceId";
        internal const string TryGetApiVersionMethodName = "TryGetApiVersion";

        private readonly RequestPathPattern _contextualRequestPattern;

        protected ContextualClientProvider(RequestPathPattern contextualRequestPattern) : base()
        {
            _contextualRequestPattern = contextualRequestPattern;
        }

        private IReadOnlyList<ContextualParameter>? _contextualParameters;
        internal IReadOnlyList<ContextualParameter> ContextualParameters => _contextualParameters ??= ContextualParameterBuilder.BuildContextualParameters(_contextualRequestPattern);

        private IReadOnlyDictionary<string, ContextualParameter>? _contextualParameterMap;
        internal bool TryGetContextualParameter(string parameterName, [NotNullWhen(true)] out ContextualParameter? contextualParameter)
        {
            _contextualParameterMap ??= ContextualParameters.ToDictionary(p => p.VariableName);
            return _contextualParameterMap.TryGetValue(parameterName, out contextualParameter);
        }

        private protected MethodProvider BuildValidateResourceIdMethod(ValueExpression resourceType)
        {
            var idParameter = new ParameterProvider("id", $"", typeof(ResourceIdentifier));
            var signature = new MethodSignature(
                ValidateResourceIdMethodName,
                null,
                MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
                null,
                null,
                [idParameter],
                [new AttributeStatement(typeof(ConditionalAttribute), Literal("DEBUG"))]);
            var bodyStatements = new IfStatement(idParameter.As<ResourceIdentifier>().ResourceType().NotEqual(resourceType))
            {
                Throw(New.ArgumentException(idParameter, StringSnippets.Format(Literal("Invalid resource type {0} expected {1}"), idParameter.As<ResourceIdentifier>().ResourceType(), resourceType), false))
            };
            return new MethodProvider(signature, bodyStatements, this);
        }

        internal IReadOnlyList<ValueExpression> PopulateArguments(
            IReadOnlyList<ParameterProvider> requestParameters,
            VariableExpression contextVariable,
            IReadOnlyList<ParameterProvider> methodParameters,
            InputOperation operation)
        {
            var idProperty = This.Property("Id").As<ResourceIdentifier>();
            var arguments = new List<ValueExpression>();
            // here we always assume that the parameter name matches the parameter name in the request path.
            foreach (var parameter in requestParameters)
            {
                // find the corresponding contextual parameter in the contextual parameter list
                if (TryGetContextualParameter(parameter.Name, out var contextualParameter))
                {
                    arguments.Add(Convert(contextualParameter.BuildValueExpression(idProperty), typeof(string), parameter.Type));
                }
                else if (parameter.Type.Equals(typeof(RequestContent)))
                {
                    if (methodParameters.Count > 0)
                    {
                        // find the body parameter in the method parameters
                        var bodyParameter = methodParameters.Single(p => p.Location == ParameterLocation.Body);
                        arguments.Add(Static(bodyParameter.Type).Invoke(SerializationVisitor.ToRequestContentMethodName, [bodyParameter]));
                    }
                }
                else if (parameter.Type.Equals(typeof(RequestContext)))
                {
                    arguments.Add(contextVariable);
                }
                else
                {
                    arguments.Add(methodParameters.Single(p => p.Name == parameter.Name));
                }
            }
            return [.. arguments];
        }

        private static ValueExpression Convert(ValueExpression expression, CSharpType fromType, CSharpType toType)
        {
            if (fromType.Equals(toType))
            {
                return expression; // No conversion needed
            }

            if (toType.IsFrameworkType && toType.FrameworkType == typeof(Guid))
            {
                return Static<Guid>().Invoke(nameof(Guid.Parse), expression);
            }

            // other unhandled cases, we will add when we need them in the future.
            return expression;
        }
    }
}
