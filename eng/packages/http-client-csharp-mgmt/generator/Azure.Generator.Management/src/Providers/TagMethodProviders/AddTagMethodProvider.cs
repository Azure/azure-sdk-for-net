// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using Microsoft.TypeSpec.Generator.Expressions;
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
        }

        private MethodSignature CreateSignature()
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
            var keyParameter = new ParameterProvider("key", $"The tag key.", new CSharpType(typeof(string)), validation: ParameterValidationType.AssertNotNull);
            var valueParameter = new ParameterProvider("value", $"The tag value.", new CSharpType(typeof(string)), validation: ParameterValidationType.AssertNotNull);
            var cancellationTokenParameter = new ParameterProvider("cancellationToken", $"The cancellation token to use.", new CSharpType(typeof(CancellationToken)), defaultValue: Default);

            return [keyParameter, valueParameter, cancellationTokenParameter];
        }

        private MethodBodyStatement[] BuildBodyStatements()
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

            // Create if-else statement with primary path in if block and secondary path in else block
            var ifElseStatement = new IfElseStatement(
                canUseTagResourceCondition,
                BuildIfStatement(keyParam, valueParam, cancellationTokenParam),
                BuildElseStatement(keyParam, valueParam, cancellationTokenParam)
            );

            tryStatements.Add(ifElseStatement);

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

        private List<MethodBodyStatement> BuildIfStatement(ParameterProvider keyParam, ParameterProvider valueParam, ParameterProvider cancellationTokenParam)
        {
            // Primary path (if branch)
            var primaryPath = new List<MethodBodyStatement>
            {
                // var originalTags = GetTagResource().Get(cancellationToken);
                Declare("originalTags", new CSharpType(typeof(Azure.Response<>), typeof(Azure.ResourceManager.Resources.TagResource)), This.Invoke("GetTagResource").Invoke("Get", [cancellationTokenParam]), out var originalTagsVar),

                // originalTags.Value.Data.TagValues[key] = value;
                new IndexerExpression(originalTagsVar.Property("Value").Property("Data").Property("TagValues"), keyParam)
                    .Assign(valueParam).Terminate(),

                // GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                This.Invoke("GetTagResource").Invoke("CreateOrUpdate", [
                    Static(typeof(Azure.WaitUntil)).Property("Completed"),
                    originalTagsVar.Property("Value").Property("Data"),
                    cancellationTokenParam
                ]).Terminate(),

                // RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                Declare("context", typeof(Azure.RequestContext), New.Instance(typeof(Azure.RequestContext)), out var contextVar),

                // context.CancellationToken = cancellationToken;
                contextVar.Property("CancellationToken").Assign(cancellationTokenParam).Terminate(),

                // HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Declare("message", typeof(Azure.Core.HttpMessage),
                    _resourceClientProvider.GetRestClientField().Invoke("CreateGetRequest", [
                        Static(typeof(Guid)).Invoke("Parse", [This.Property("Id").Property("SubscriptionId")]),
                        This.Property("Id").Property("ResourceGroupName"),
                        This.Property("Id").Property("Name"),
                        contextVar
                    ]), out var messageVar),

                // Response result = Pipeline.ProcessMessage(message, context);
                Declare("result", typeof(Azure.Response),
                    This.Property("Pipeline").Invoke("ProcessMessage", [messageVar, contextVar]), out var originalResultVar),

                // Response<ResourceData> response = Response.FromValue((ResourceData)originalResult, originalResult);
                Declare("response", new CSharpType(typeof(Azure.Response<>), _resourceClientProvider.ResourceData.Type),
                    Static(typeof(Azure.Response)).Invoke("FromValue", [
                        originalResultVar.CastTo(_resourceClientProvider.ResourceData.Type),
                        originalResultVar
                    ]), out var originalResponseVar),

                // return Response.FromValue(new ResourceType(Client, response.Value), response.GetRawResponse());
                Return(Static(typeof(Azure.Response)).Invoke("FromValue", [
                    New.Instance(_resourceClientProvider.ResourceClientCSharpType, [
                        This.Property("Client"),
                        originalResponseVar.Property("Value")
                    ]),
                    originalResponseVar.Invoke("GetRawResponse")
                ]))
            };

            return primaryPath;
        }

        private List<MethodBodyStatement> BuildElseStatement(ParameterProvider keyParam, ParameterProvider valueParam, ParameterProvider cancellationTokenParam)
        {
            // Secondary path (else branch)
            var secondaryPath = new List<MethodBodyStatement>
            {
                // var current = Get(cancellationToken: cancellationToken).Value.Data;
                Declare("current", _resourceClientProvider.ResourceData.Type, This.Invoke("Get", [cancellationTokenParam])
                        .Property("Value").Property("Data"), out var currentVar),

                // current.Tags[key] = value;
                new IndexerExpression(currentVar.Property("Tags"), keyParam)
                    .Assign(valueParam).Terminate(),

                // var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                Declare("result", new CSharpType(typeof(Azure.ResourceManager.ArmOperation<>), _resourceClientProvider.ResourceClientCSharpType), This.Invoke("Update", [
                        Static(typeof(Azure.WaitUntil)).Property("Completed"),
                        currentVar,
                        cancellationTokenParam
                    ]), out var resultVar),

                // return Response.FromValue(result.Value, result.GetRawResponse());
                Return(Static(typeof(Azure.Response)).Invoke("FromValue", [
                    resultVar.Property("Value"),
                    resultVar.Invoke("GetRawResponse")
                ]))
            };

            return secondaryPath;
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
