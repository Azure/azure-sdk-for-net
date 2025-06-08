// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using Microsoft.TypeSpec.Generator.Expressions;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Snippets;
using System.Collections.Generic;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.TagMethodProviders
{
    internal class AddTagMethodProvider : BaseTagMethodProvider
    {
        public AddTagMethodProvider(
            ResourceClientProvider resourceClientProvider,
            bool isAsync)
            : base(resourceClientProvider, isAsync)
        {
        }

        protected override MethodSignature CreateMethodSignature()
        {
            var methodName = _isAsync ? "AddTagAsync" : "AddTag";
            return CreateMethodSignatureCore(methodName, $"Add a tag to the current resource.");
        }

        protected override ParameterProvider[] BuildParameters()
        {
            var keyParameter = CreateKeyParameter();
            var valueParameter = CreateValueParameter();
            var cancellationTokenParameter = KnownAzureParameters.CancellationTokenWithDefault;

            return [keyParameter, valueParameter, cancellationTokenParameter];
        }

        protected override MethodBodyStatement[] BuildBodyStatements()
        {
            var keyParam = _signature.Parameters[0];
            var valueParam = _signature.Parameters[1];
            var cancellationTokenParam = _signature.Parameters[2];

            var statements = ResourceMethodSnippets.CreateDiagnosticScopeStatements(_resourceClientProvider, "AddTag", out var scopeVariable);

            // Build try block
            var tryStatements = new List<MethodBodyStatement>();

            // if (CanUseTagResource(cancellationToken: cancellationToken))
            var canUseTagResourceCondition = CreateCanUseTagResourceCondition(_isAsync, cancellationTokenParam);

            // Create if-else statement with primary path in if block and secondary path in else block
            var ifElseStatement = new IfElseStatement(
                canUseTagResourceCondition,
                BuildIfStatement(keyParam, valueParam, cancellationTokenParam),
                BuildElseStatement(keyParam, valueParam, cancellationTokenParam)
            );

            tryStatements.Add(ifElseStatement);

            // Build catch block
            var catchBlock = ResourceMethodSnippets.CreateDiagnosticCatchBlock(scopeVariable);

            // Add try-catch statement
            statements.Add(new TryCatchFinallyStatement(
                new TryExpression(tryStatements),
                catchBlock));

            return [.. statements];
        }

        private List<MethodBodyStatement> BuildIfStatement(ParameterProvider keyParam, ParameterProvider valueParam, ParameterProvider cancellationTokenParam)
        {
            var getMethod = _isAsync ? "GetAsync" : "Get";
            var createMethod = _isAsync ? "CreateOrUpdateAsync" : "CreateOrUpdate";

            var statements = new List<MethodBodyStatement>
            {
                // var originalTags = GetTagResource().Get(cancellationToken);
                Declare(
                    "originalTags",
                    new CSharpType(typeof(Azure.Response<>), typeof(Azure.ResourceManager.Resources.TagResource)),
                    This.Invoke("GetTagResource").Invoke(getMethod, [cancellationTokenParam], null, _isAsync),
                    out var originalTagsVar),

                // originalTags.Value.Data.TagValues[key] = value;
                new IndexerExpression(originalTagsVar.Property("Value").Property("Data").Property("TagValues"), keyParam)
                    .Assign(valueParam).Terminate(),

                // GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                This.Invoke("GetTagResource").Invoke(createMethod, [
                    Static(typeof(WaitUntil)).Property("Completed"),
                    originalTagsVar.Property("Value").Property("Data"),
                    cancellationTokenParam
                ], null, _isAsync).Terminate()
            };

            // Add RequestContext/HttpMessage/Pipeline processing statements
            statements.AddRange(CreateRequestContextAndProcessMessage(
                _resourceClientProvider,
                _isAsync,
                cancellationTokenParam,
                out var responseVar));

            // Add primary path response creation statements
            statements.AddRange(CreatePrimaryPathResponseStatements(_resourceClientProvider, responseVar));

            return statements;
        }

        private List<MethodBodyStatement> BuildElseStatement(ParameterProvider keyParam, ParameterProvider valueParam, ParameterProvider cancellationTokenParam)
        {
            var getMethod = _isAsync ? "GetAsync" : "Get";
            var updateMethod = _isAsync ? "UpdateAsync" : "Update";

            var statements = new List<MethodBodyStatement>();

            // Get current resource data
            statements.AddRange(GetResourceDataStatements("current", _resourceClientProvider, _isAsync, cancellationTokenParam, out var currentVar));

            statements.AddRange(
            [
                // current.Tags[key] = value;
                new IndexerExpression(currentVar.Property("Tags"), keyParam)
                    .Assign(valueParam).Terminate(),

                // var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                Declare(
                    "result",
                    new CSharpType(typeof(Azure.ResourceManager.ArmOperation<>), _resourceClientProvider.ResourceClientCSharpType),
                    This.Invoke(updateMethod, [
                        Static(typeof(WaitUntil)).Property("Completed"),
                        currentVar,
                        cancellationTokenParam
                    ], null, _isAsync),
                    out var resultVar),

                // return Response.FromValue(result.Value, result.GetRawResponse());
                CreateSecondaryPathResponseStatement(resultVar)
            ]);

            return statements;
        }
    }
}
