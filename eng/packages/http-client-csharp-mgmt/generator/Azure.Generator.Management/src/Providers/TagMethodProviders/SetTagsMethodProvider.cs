// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using Microsoft.TypeSpec.Generator.Expressions;
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
            : base(resourceClientProvider, isAsync,
                   isAsync ? "SetTagsAsync" : "SetTags",
                   "Replace the tags on the resource with the given set.")
        {
        }

        protected override ParameterProvider[] BuildParameters()
        {
            var tagsParameter = new ParameterProvider("tags", $"The tags to set on the resource.", typeof(IDictionary<string, string>), validation: ParameterValidationType.AssertNotNull);
            var cancellationTokenParameter = KnownParameters.CancellationTokenParameter;

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
            var createMethod = _isAsync ? "CreateOrUpdateAsync" : "CreateOrUpdate";
            var deleteMethod = _isAsync ? "DeleteAsync" : "Delete";

            var statements = new List<MethodBodyStatement>
            {
                // GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                This.Invoke("GetTagResource").Invoke(deleteMethod, [
                    Static(typeof(WaitUntil)).Property("Completed"),
                    cancellationTokenParam
                ], null, _isAsync).Terminate(),

                GetOriginalTagsStatement(_isAsync, cancellationTokenParam, out var originalTagsVar),

                // originalTags.Value.Data.TagValues.ReplaceWith(tags);
                originalTagsVar.Property("Value").Property("Data").Property("TagValues")
                    .Invoke("ReplaceWith", [tagsParam]).Terminate(),

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

        private List<MethodBodyStatement> BuildElseStatement(ParameterProvider tagsParam, ParameterProvider cancellationTokenParam)
        {
            var updateMethod = _isAsync ? "UpdateAsync" : "Update";

            var statements = new List<MethodBodyStatement>();

            // Get current resource data
            statements.AddRange(GetResourceDataStatements("current", _resourceClientProvider, _isAsync, cancellationTokenParam, out var currentVar));

            statements.AddRange(
            [
                // current.Tags.ReplaceWith(tags);
                currentVar.Property("Tags").Invoke("ReplaceWith", [tagsParam]).Terminate(),

                // var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                Declare(
                    "result",
                    new CSharpType(typeof(ResourceManager.ArmOperation<>), _resourceClientProvider.ResourceClientCSharpType),
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
