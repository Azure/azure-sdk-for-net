// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using Microsoft.TypeSpec.Generator.Expressions;
using Azure.Generator.Management.Snippets;
using System.Collections.Generic;

namespace Azure.Generator.Management.Providers.TagMethodProviders
{
    internal class SetTagsMethodProvider : BaseTagMethodProvider
    {
        public SetTagsMethodProvider(
            ResourceClientProvider resourceClientProvider,
            MethodProvider updateMethodProvider,
            bool isAsync)
            : base(resourceClientProvider, updateMethodProvider, isAsync,
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
                BuildIfStatements(cancellationTokenParam, (tagValues) =>
                {
                    // originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    return tagValues.Invoke("ReplaceWith", [tagsParam]).Terminate();
                }, true),
                BuildElseStatements(cancellationTokenParam, (currentTags) =>
                {
                    // current.Tags.ReplaceWith(tags);
                    return currentTags.Invoke("ReplaceWith", [tagsParam]).Terminate();
                }, false)
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
    }
}
