// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    internal class NextLinkPagingVisitor : ScmLibraryVisitor
    {
        protected override ScmMethodProviderCollection? Visit(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods)
        {
            if (methods == null || serviceMethod is not InputPagingServiceMethod { PagingMetadata.NextLink: not null } pagingMethod)
            {
                return methods;
            }

            var tokens = serviceMethod.Operation.Parameters.Where(p =>
                p.Decorators.Any(d => d.Name == "TypeSpec.@continuationToken")
                || ReferenceEquals(p, pagingMethod.PagingMetadata.ContinuationToken?.Parameter))
                .Select(p => new ParameterProvider(p)).ToArray();
            return tokens.Length == 0 ? methods : new NextLinkMethodCollection(serviceMethod, client, methods, tokens);
        }

        private sealed class NextLinkMethodCollection(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection methods,
            IReadOnlyList<ParameterProvider> tokens) : ScmMethodProviderCollection(serviceMethod, client)
        {
            protected override IReadOnlyList<ScmMethodProvider> BuildMethods()
            {
                var result = new List<ScmMethodProvider>();
                foreach (var method in methods)
                {
                    var removed = method.Signature.Parameters.Where(p => tokens.Any(t =>
                        t.WireInfo.SerializedName == p.WireInfo.SerializedName
                        && t.Location == p.Location)).ToArray();
                    if (removed.Length == 0)
                    {
                        result.Add(method);
                        continue;
                    }

                    var previousMethods = (client.LastContractView?.Methods ?? []).Where(previous =>
                    {
                        var signature = previous.Signature;
                        return signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                            && !signature.Modifiers.HasFlag(MethodSignatureModifiers.Static)
                            && signature.Name == method.Signature.Name
                            && signature.ReturnType is { } returnType
                            && returnType.AreNamesEqual(method.Signature.ReturnType!)
                            && removed.Any(t => signature.Parameters.Any(p => p.Name == t.Name))
                            && signature.Parameters.All(p => method.Signature.Parameters.Any(
                                current => current.Name == p.Name && current.Type.AreNamesEqual(p.Type)))
                            && method.Signature.Parameters.All(p => p.DefaultValue != null
                                || p.InputParameter?.IsRequired == false
                                || signature.Parameters.Any(previousParameter => previousParameter.Name == p.Name));
                    }).ToArray();

                    var parameters = method.Signature.Parameters.Except(removed).ToArray();
                    if (previousMethods.Length > 0)
                    {
                        // Keep the original request body in one method, preserving earlier visitor customizations.
                        // Forwarders must not call the tokenless overload, which would discard a saved bare token.
                        result.Add(CreateForwarder(method, parameters));
                        bool hasFullSignature = false;
                        AttributeStatement[] attributes =
                        [
                            .. method.Signature.Attributes,
                            new(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))
                        ];
                        foreach (var previous in previousMethods)
                        {
                            var legacyParameters = previous.Signature.Parameters.Select(p =>
                                method.Signature.Parameters.Single(current => current.Name == p.Name)).ToArray();
                            int lastToken = System.Array.FindLastIndex(legacyParameters, p => removed.Any(t => t.Name == p.Name));
                            legacyParameters = legacyParameters.Select((p, i) => i <= lastToken ? RequiredParameter(p) : p).ToArray();
                            ScmMethodProvider overload;
                            if (legacyParameters.Length == method.Signature.Parameters.Count && !hasFullSignature)
                            {
                                method.Signature.Update(parameters: legacyParameters, attributes: attributes);
                                hasFullSignature = true;
                                overload = method;
                            }
                            else
                            {
                                overload = CreateForwarder(method, legacyParameters, attributes);
                                result.Add(overload);
                            }
                            for (int i = lastToken + 1; i < legacyParameters.Length; i++)
                            {
                                overload.Signature.Parameters[i].DefaultValue = previous.Signature.Parameters[i].DefaultValue;
                            }
                        }
                        if (!hasFullSignature)
                        {
                            method.Signature.Update(modifiers: MethodSignatureModifiers.Private);
                        }
                        result.Add(method);
                        continue;
                    }

                    method.Signature.Update(parameters: parameters);
                    method.Update(bodyStatements: WithDefaults(method, removed));
                    method.XmlDocs.Update(parameters: [.. parameters.Select(p => new XmlDocParamStatement(p))]);
                    result.Add(method);
                }
                return result;
            }

            private static ScmMethodProvider CreateForwarder(
                ScmMethodProvider target,
                IReadOnlyList<ParameterProvider> parameters,
                IReadOnlyList<AttributeStatement>? attributes = null)
            {
                parameters = [.. parameters.Select(p => new ParameterProvider(
                    p.Name, p.Description, p.Type, p.DefaultValue, attributes: p.Attributes,
                    location: p.Location, wireInfo: p.WireInfo, validation: p.Validation, inputParameter: p.InputParameter))];
                var signature = new MethodSignature(
                    target.Signature.Name, target.Signature.Description, target.Signature.Modifiers,
                    target.Signature.ReturnType, target.Signature.ReturnDescription, parameters);
                signature.Update(attributes: attributes ?? target.Signature.Attributes);
                var body = Return(This.Invoke(target.Signature, [.. target.Signature.Parameters.Select(p =>
                    PositionalReference(p.Name,
                        parameters.FirstOrDefault(parameter => parameter.Name == p.Name) is { } parameter ? parameter : Default))]));
                return new ScmMethodProvider(signature, body, target.EnclosingType, target.Kind, serviceMethod: target.ServiceMethod);
            }

            private static MethodBodyStatement WithDefaults(ScmMethodProvider method, IEnumerable<ParameterProvider> parameters)
                => new MethodBodyStatements(
                [
                    .. parameters.Select(p => new DeclarationExpression(p).Assign(Default).Terminate()),
                    method.BodyStatements!
                ]);

            private static ParameterProvider RequiredParameter(ParameterProvider parameter)
            {
                parameter.DefaultValue = null;
                return parameter;
            }
        }
    }
}
