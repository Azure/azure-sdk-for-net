// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using Microsoft.TypeSpec.Generator.Expressions;
using Azure.Core;
using Azure.ResourceManager;
using System;
using System.Collections.Generic;
using System.Threading;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.TagMethodProviders
{
    /// <summary>
    /// Provider for building add tag methods.
    /// </summary>
    internal class AddTagMethodProvider
    {
        private readonly MethodSignature _signature;
        private readonly MethodBodyStatement[] _bodyStatements;
        private readonly TypeProvider _enclosingType;
        private readonly ResourceClientProvider _resourceClientProvider;

        public AddTagMethodProvider(ResourceClientProvider resourceClientProvider)
        {
            _resourceClientProvider = resourceClientProvider;
            _enclosingType = resourceClientProvider;
            _signature = CreateSignature();            _bodyStatements = BuildBodyStatements();
        }        private MethodSignature CreateSignature()
        {
            var returnType = new CSharpType(typeof(Azure.Response<>), _resourceClientProvider.ResourceClientCSharpType);
            return new MethodSignature(
                "AddTag",
                $"Add a tag to a {_resourceClientProvider.SpecName}",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                returnType,
                null,
                BuildParameters(),
                null,
                null,
                null,
                null,
                null);
        }

        private ParameterProvider[] BuildParameters()
        {
            var keyParameter = new ParameterProvider("key", $"The tag key.", new CSharpType(typeof(string)));
            var valueParameter = new ParameterProvider("value", $"The tag value.", new CSharpType(typeof(string)));
            var cancellationTokenParameter = new ParameterProvider("cancellationToken", $"The cancellation token to use.", new CSharpType(typeof(CancellationToken)), defaultValue: Default);

            return [keyParameter, valueParameter, cancellationTokenParameter];
        }        private MethodBodyStatement[] BuildBodyStatements()
        {
            var keyParam = _signature.Parameters[0];
            var valueParam = _signature.Parameters[1];
            var cancellationTokenParam = _signature.Parameters[2];

            var statements = new List<MethodBodyStatement>();

            // using var scope = _clientDiagnostics.CreateScope("ResourceName.AddTag");
            var clientDiagnosticsField = _resourceClientProvider.GetClientDiagnosticsField();
            var scopeDeclaration = UsingDeclare(
                "scope",
                typeof(Azure.Core.Pipeline.DiagnosticScope),
                clientDiagnosticsField.Invoke("CreateScope", [Literal($"{_resourceClientProvider.Name}.AddTag")]),
                out var scopeVariable);
            statements.Add(scopeDeclaration);

            // scope.Start();
            statements.Add(scopeVariable.Invoke("Start").Terminate());

            // Build try block
            var tryStatements = new List<MethodBodyStatement>();

            // if (CanUseTagResource(cancellationToken: cancellationToken))
            var canUseTagResourceCondition = This.Invoke("CanUseTagResource", [cancellationTokenParam]);

            // Primary path (if branch)
            var primaryPath = new List<MethodBodyStatement>
            {
                // var originalTags = GetTagResource().Get(cancellationToken);
                Declare("originalTags", out var originalTagsVar,
                    This.Invoke("GetTagResource").Invoke("Get", [cancellationTokenParam])),
                
                // originalTags.Value.Data.TagValues[key] = value;
                new IndexExpression(originalTagsVar.Property("Value").Property("Data").Property("TagValues"), keyParam)
                    .Assign(valueParam).Terminate(),
                
                // GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                This.Invoke("GetTagResource").Invoke("CreateOrUpdate", [
                    Static(typeof(Azure.WaitUntil)).Property("Completed"),
                    originalTagsVar.Property("Value").Property("Data"),
                    cancellationTokenParam
                ]).Terminate(),
                
                // var originalResponse = _restClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                Declare("originalResponse", out var originalResponseVar,
                    _resourceClientProvider.GetRestClientField().Invoke("Get", [
                        This.Property("Id").Property("SubscriptionId"),
                        This.Property("Id").Property("ResourceGroupName"),
                        This.Property("Id").Property("Name"),
                        cancellationTokenParam
                    ])),
                
                // return Response.FromValue(new ResourceType(Client, originalResponse.Value), originalResponse.GetRawResponse());
                Return(Static(typeof(Azure.Response)).Invoke("FromValue", [
                    New.Instance(_resourceClientProvider.ResourceClientCSharpType, [
                        This.Property("Client"),
                        originalResponseVar.Property("Value")
                    ]),
                    originalResponseVar.Invoke("GetRawResponse")
                ]))
            };

            // Secondary path (else branch)
            var secondaryPath = new List<MethodBodyStatement>
            {
                // var current = Get(cancellationToken: cancellationToken).Value.Data;
                Declare("current", out var currentVar,
                    This.Invoke("Get", [cancellationTokenParam])
                        .Property("Value").Property("Data")),
                
                // current.Tags[key] = value;
                new IndexExpression(currentVar.Property("Tags"), keyParam)
                    .Assign(valueParam).Terminate(),
                
                // var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                Declare("result", out var resultVar,
                    This.Invoke("Update", [
                        Static(typeof(Azure.WaitUntil)).Property("Completed"),
                        currentVar,
                        cancellationTokenParam
                    ])),
                
                // return Response.FromValue(result.Value, result.GetRawResponse());
                Return(Static(typeof(Azure.Response)).Invoke("FromValue", [
                    resultVar.Property("Value"),
                    resultVar.Invoke("GetRawResponse")
                ]))
            };

            var ifStatement = new IfStatement(canUseTagResourceCondition, primaryPath, secondaryPath);

            tryStatements.Add(ifStatement);

            // Build catch block
            var catchBlock = Catch(
                Declare("e", typeof(Exception), out var exceptionVar),
                [
                    scopeVariable.Invoke("Failed", [exceptionVar]).Terminate(),
                    Throw()
                ]);

            // Add try-catch statement
            statements.Add(new TryCatchFinallyStatement(
                new TryExpression(tryStatements),
                catchBlock));

            return [.. statements];
        }

        private ValueExpression[] BuildGetMethodParameters(ParameterProvider cancellationTokenParam)
        {
            var parameters = new List<ValueExpression>();
            // Add subscription ID
            parameters.Add(This.Property("Id").Property("SubscriptionId"));
            // Add resource group name
            parameters.Add(This.Property("Id").Property("ResourceGroupName"));
            // Add resource name
            parameters.Add(This.Property("Id").Property("Name"));
            // Add cancellation token
            parameters.Add(cancellationTokenParam);
            return [.. parameters];
        }

        public static implicit operator MethodProvider(AddTagMethodProvider addTagMethodProvider)
        {
            return new MethodProvider(
                addTagMethodProvider._signature,
                addTagMethodProvider._bodyStatements,
                addTagMethodProvider._enclosingType);
        }
    }
}
