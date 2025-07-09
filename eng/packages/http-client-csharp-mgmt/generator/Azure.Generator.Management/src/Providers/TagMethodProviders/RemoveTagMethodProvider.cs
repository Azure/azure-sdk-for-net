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
    internal class RemoveTagMethodProvider : BaseTagMethodProvider
    {
        public RemoveTagMethodProvider(
            ResourceClientProvider resourceClientProvider,
            bool isAsync)
            : base(resourceClientProvider, isAsync,
                   isAsync ? "RemoveTagAsync" : "RemoveTag",
                   "Removes a tag by key from the resource.")
        {
        }

        protected override ParameterProvider[] BuildParameters()
        {
            var cancellationTokenParameter = KnownParameters.CancellationTokenParameter;

            return [_keyParameter, cancellationTokenParameter];
        }

        protected override MethodBodyStatement[] BuildBodyStatements()
        {
            var keyParam = _keyParameter;
            var cancellationTokenParam = KnownParameters.CancellationTokenParameter;

            var statements = ResourceMethodSnippets.CreateDiagnosticScopeStatements(_resourceClientProvider, "RemoveTag", out var scopeVariable);

            // Build try block
            var tryStatements = new List<MethodBodyStatement>();

            // if (CanUseTagResource(cancellationToken: cancellationToken))
            var canUseTagResourceCondition = CreateCanUseTagResourceCondition(_isAsync, cancellationTokenParam);

            // Create if-else statement with primary path in if block and secondary path in else block
            var ifElseStatement = new IfElseStatement(
                canUseTagResourceCondition,
                BuildIfStatement(keyParam, cancellationTokenParam),
                BuildElseStatement(keyParam, cancellationTokenParam)
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

        private List<MethodBodyStatement> BuildIfStatement(ParameterProvider keyParam, ParameterProvider cancellationTokenParam)
        {
            var createMethod = _isAsync ? "CreateOrUpdateAsync" : "CreateOrUpdate";

            var statements = new List<MethodBodyStatement>
            {
                GetOriginalTagsStatement(_isAsync, cancellationTokenParam, out var originalTagsVar),

                // originalTags.Value.Data.TagValues.Remove(key);
                originalTagsVar.Property("Value").Property("Data").Property("TagValues")
                    .Invoke("Remove", [keyParam]).Terminate(),

                // GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                This.Invoke("GetTagResource").Invoke(createMethod, [
                    Static(typeof(WaitUntil)).Property("Completed"),
                    originalTagsVar.Property("Value").Property("Data"),
                    cancellationTokenParam
                ], null, _isAsync).Terminate(),
            };

            // Add RequestContext/HttpMessage/Pipeline processing statements
            statements.AddRange(CreateRequestContextAndProcessMessage(
                _resourceClientProvider,
                _isAsync,
                cancellationTokenParam,
                out var responseVar));

            statements.AddRange(CreatePrimaryPathResponseStatements(_resourceClientProvider, responseVar));

            return statements;
        }

        private List<MethodBodyStatement> BuildElseStatement(ParameterProvider keyParam, ParameterProvider cancellationTokenParam)
        {
            var updateMethod = _isAsync ? "UpdateAsync" : "Update";

            var statements = new List<MethodBodyStatement>();

            // Get current resource data
            statements.AddRange(GetResourceDataStatements("current", _resourceClientProvider, _isAsync, cancellationTokenParam, out var currentVar));

            statements.AddRange(
            [
                // current.Tags.Remove(key);
                currentVar.Property("Tags").Invoke("Remove", [keyParam]).Terminate(),

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
