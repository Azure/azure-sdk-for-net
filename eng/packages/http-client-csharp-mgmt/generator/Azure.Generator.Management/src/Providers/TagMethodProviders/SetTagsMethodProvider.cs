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
    internal class SetTagsMethodProvider : BaseTagMethodProvider
    {
        public SetTagsMethodProvider(
            ResourceClientProvider resourceClientProvider,
            bool isAsync)
            : base(resourceClientProvider, isAsync)
        {
        }

        protected override MethodSignature CreateMethodSignature()
        {
            var methodName = _isAsync ? "SetTagsAsync" : "SetTags";
            return CreateMethodSignatureCore(methodName, "Replace the tags on the resource with the given set.");
        }

        protected override ParameterProvider[] BuildParameters()
        {
            var tagsParameter = new ParameterProvider("tags", $"The tags to set on the resource.", typeof(IDictionary<string, string>), validation: ParameterValidationType.AssertNotNull);
            var cancellationTokenParameter = KnownAzureParameters.CancellationTokenWithDefault;

            return [tagsParameter, cancellationTokenParameter];
        }

        protected override MethodBodyStatement[] BuildBodyStatements()
        {
            var tagsParam = _signature.Parameters[0];
            var cancellationTokenParam = _signature.Parameters[1];

            var statements = ResourceMethodSnippets.CreateDiagnosticScopeStatements(_resourceClientProvider, "SetTags", out var scopeVariable);

            // Build try block
            var tryStatements = new List<MethodBodyStatement>();

            // if (CanUseTagResource(cancellationToken: cancellationToken))
            var canUseTagResourceCondition = CreateCanUseTagResourceCondition(_isAsync, cancellationTokenParam);

            // Create if-else statement with primary path in if block and secondary path in else block
            var ifElseStatement = new IfElseStatement(
                canUseTagResourceCondition,
                BuildIfStatement(tagsParam, cancellationTokenParam),
                BuildElseStatement(tagsParam, cancellationTokenParam)
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

        private List<MethodBodyStatement> BuildIfStatement(ParameterProvider tagsParam, ParameterProvider cancellationTokenParam)
        {
            var getMethod = _isAsync ? "GetAsync" : "Get";
            var createMethod = _isAsync ? "CreateOrUpdateAsync" : "CreateOrUpdate";
            var deleteMethod = _isAsync ? "DeleteAsync" : "Delete";

            var statements = new List<MethodBodyStatement>
            {
                // GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                This.Invoke("GetTagResource").Invoke(deleteMethod, [
                    Static(typeof(Azure.WaitUntil)).Property("Completed"),
                    cancellationTokenParam
                ], null, _isAsync).Terminate(),

                // var originalTags = GetTagResource().Get(cancellationToken);
                Declare(
                    "originalTags",
                    new CSharpType(typeof(Azure.Response<>), typeof(Azure.ResourceManager.Resources.TagResource)),
                    This.Invoke("GetTagResource").Invoke(getMethod, [cancellationTokenParam], null, _isAsync),
                    out var originalTagsVar),

                // originalTags.Value.Data.TagValues.ReplaceWith(tags);
                originalTagsVar.Property("Value").Property("Data").Property("TagValues")
                    .Invoke("ReplaceWith", [tagsParam]).Terminate(),

                // GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                This.Invoke("GetTagResource").Invoke(createMethod, [
                    Static(typeof(Azure.WaitUntil)).Property("Completed"),
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

        private List<MethodBodyStatement> BuildElseStatement(ParameterProvider tagsParam, ParameterProvider cancellationTokenParam)
        {
            var updateMethod = _isAsync ? "UpdateAsync" : "Update";

            var statements = new List<MethodBodyStatement>();

            // Get current resource data
            statements.AddRange(GetResourceDataStatements("current", _resourceClientProvider, _isAsync, cancellationTokenParam, out var currentVar));

            statements.AddRange(new[]
            {
                // current.Tags.ReplaceWith(tags);
                currentVar.Property("Tags").Invoke("ReplaceWith", [tagsParam]).Terminate(),

                // var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                Declare(
                    "result",
                    new CSharpType(typeof(Azure.ResourceManager.ArmOperation<>), _resourceClientProvider.ResourceClientCSharpType),
                    This.Invoke(updateMethod, [
                        Static(typeof(Azure.WaitUntil)).Property("Completed"),
                        currentVar,
                        cancellationTokenParam
                    ], null, _isAsync),
                    out var resultVar),

                // return Response.FromValue(result.Value, result.GetRawResponse());
                Return(Static(typeof(Azure.Response)).Invoke("FromValue", [
                    resultVar.Property("Value"),
                    resultVar.Invoke("GetRawResponse")
                ]))
            });

            return statements;
        }
    }
}
