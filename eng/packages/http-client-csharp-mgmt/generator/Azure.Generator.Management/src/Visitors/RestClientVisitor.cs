// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Management.Visitors;

internal class RestClientVisitor : ScmLibraryVisitor
{
    protected override ScmMethodProvider? VisitCreateRequestMethod(InputServiceMethod serviceMethod, RestClientProvider enclosingType, ScmMethodProvider? createRequestMethodProvider)
    {
        var client = ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(serviceMethod)!;
        var apiVersionParameter = serviceMethod.Operation.Parameters.FirstOrDefault(p => p.IsApiVersion);
        if (createRequestMethodProvider?.BodyStatements is null || !client.HasOperationApiVersionDefaults || apiVersionParameter is not InputQueryParameter apiVersionQuery)
        {
            return createRequestMethodProvider;
        }

        var resources = ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas
            .Where(r => r.Methods.Any(m => ReferenceEquals(m.InputMethod, serviceMethod))).ToArray();
        // A literal parameter is authoritative in the base input model, which deliberately
        // omits clientDefaultValue for constants. Preserve it in mixed clients as well.
        var wireDefault = apiVersionParameter.Type is InputLiteralType literal
            ? literal.Value
            : apiVersionParameter.DefaultValue?.Value;
        ValueExpression defaultVersion = Literal(wireDefault as string ?? client.CurrentApiVersion);
        // SetApiVersion is targeted to the operation's resource type, never to the owning
        // client/RP or extension scope. Truly non-resource operations have no such runtime key.
        var effectiveVersion = resources.Length == 0
            ? defaultVersion
            : ((ManagementClientProvider)enclosingType.ClientProvider).ApiVersionResolverField.As<Func<Azure.Core.ResourceType, string>>()
                .Invoke("Invoke", BuildResourceTypeExpression(resources, serviceMethod, createRequestMethodProvider)).NullCoalesce(defaultVersion);

        var statements = new List<MethodBodyStatement>();
        foreach (var statement in createRequestMethodProvider.BodyStatements)
        {
            // The base emitter can mark a client-scoped version optional. Its generated
            // null guard is unnecessary here: every operation has a non-null default.
            var queryStatement = statement is IfStatement conditional && conditional.Body.Count() == 1
                ? conditional.Body.Single()
                : statement;
            if (queryStatement is ExpressionStatement
                { Expression: InvokeMethodExpression { MethodName: "AppendQuery", Arguments: [ScopedApi { Original: LiteralExpression { Literal: var name } }, _, ..] } invocation }
                && Equals(name, apiVersionQuery.SerializedName))
            {
                invocation.Update(arguments: [invocation.Arguments[0], effectiveVersion, .. invocation.Arguments.Skip(2)]);
                statements.Add(queryStatement);
            }
            else
            {
                statements.Add(statement);
            }
        }
        createRequestMethodProvider.Update(bodyStatements: statements);
        return createRequestMethodProvider;
    }

    private static ValueExpression BuildResourceTypeExpression(ArmResourceMetadata[] resources, InputServiceMethod serviceMethod, MethodProvider requestMethod)
    {
        var resourceType = resources[0].ResourceType;
        if (resources.All(r => r.ResourceType.Equals(resourceType)) && resourceType.All(segment => segment.IsConstant))
        {
            return Literal(resourceType.SerializedResourceType);
        }

        // An expanded resource can reuse one REST method for several concrete types.
        // Recover its dynamic type segments from the request parameters rather than
        // choosing the first metadata entry. Truncate action suffixes to the resource path.
        var path = new RequestPathPattern(new RequestPathPattern(serviceMethod.Operation.Path).Take(resources[0].ResourceIdPattern.Count));
        ValueExpression? result = null;
        foreach (var segment in path.ResourceType)
        {
            ValueExpression value;
            if (segment.IsConstant)
            {
                value = Literal(segment.Value);
            }
            else
            {
                var parameter = requestMethod.Signature.Parameters.FirstOrDefault(p => p.WireInfo.SerializedName == segment.VariableName)
                    ?? throw new InvalidOperationException($"Cannot resolve the API-version resource type for '{serviceMethod.Name}': missing path parameter '{segment.VariableName}'.");
                value = parameter.Type.IsEnum ? parameter.Type.ToSerial(parameter) : parameter;
            }
            result = result is null ? value : new BinaryOperatorExpression("+", new BinaryOperatorExpression("+", result, Literal("/")), value);
        }
        return result ?? throw new InvalidOperationException($"Cannot resolve the API-version resource type for '{serviceMethod.Name}'.");
    }

    /// <inheritdoc/>
    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (type is ClientProvider client)
        {
            // Management output discovery uses the convenience methods before visitors run.
            // Replace them with request methods only after that discovery is complete.
            type.Update(
                methods: [.. client.RestClient.Methods],
                modifiers: TransformPublicModifiersToInternal(type));

            if (client.ClientOptions is not null)
            {
                foreach (var property in type.Properties)
                {
                    if (property.Modifiers.HasFlag(MethodSignatureModifiers.Virtual))
                    {
                        property.Update(modifiers: property.Modifiers & ~MethodSignatureModifiers.Virtual);
                    }
                }
            }
        }

        if (type is RestClientProvider)
        {
            return null;
        }

        return type;
    }

    private static TypeSignatureModifiers TransformPublicModifiersToInternal(TypeProvider type)
    {
        var modifiers = type.DeclarationModifiers;
        if (modifiers.HasFlag(TypeSignatureModifiers.Public))
        {
            modifiers &= ~TypeSignatureModifiers.Public;
            modifiers |= TypeSignatureModifiers.Internal;
        }

        return modifiers;
    }
}
