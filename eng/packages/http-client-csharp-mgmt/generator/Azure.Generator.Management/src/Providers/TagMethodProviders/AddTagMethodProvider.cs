// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers.OperationMethodProviders;
using Azure.Generator.Management.Snippets;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;

namespace Azure.Generator.Management.Providers.TagMethodProviders
{
    internal class AddTagMethodProvider : BaseTagMethodProvider
    {
        public AddTagMethodProvider(
            ResourceClientProvider resource,
            RequestPathPattern contextualPath,
            ResourceOperationMethodProvider updateMethodProvider,
            InputServiceMethod getMethod,
            List<FieldProvider> pathParameterFields,
            RestClientInfo updateRestClientInfo,
            RestClientInfo getRestClientInfo,
            bool isPatch,
            bool isAsync)
            : base(resource, contextualPath, updateMethodProvider, getMethod, pathParameterFields, updateRestClientInfo, getRestClientInfo, isPatch, isAsync,
                   isAsync ? "AddTagAsync" : "AddTag",
                   "Add a tag to the current resource.")
        {
        }

        protected override ParameterProvider[] BuildParameters()
        {
            var cancellationTokenParameter = KnownParameters.CancellationTokenParameter;

            return [_keyParameter, _valueParameter, cancellationTokenParameter];
        }

        protected override MethodBodyStatement[] BuildBodyStatements()
        {
            var keyParam = _keyParameter;
            var valueParam = _valueParameter;
            var cancellationTokenParam = KnownParameters.CancellationTokenParameter;

            var statements = ResourceMethodSnippets.CreateDiagnosticScopeStatements(_resource, _updateClientDiagnosticsField, "AddTag", out var scopeVariable);

            // Build try block
            var tryStatements = new List<MethodBodyStatement>();

            // if (CanUseTagResource(cancellationToken: cancellationToken))
            var canUseTagResourceCondition = CreateCanUseTagResourceCondition(_isAsync, cancellationTokenParam);

            // Create if-else statement with primary path in if block and secondary path in else block
            var ifElseStatement = new IfElseStatement(
                canUseTagResourceCondition,
                BuildIfStatements(cancellationTokenParam, (tagValues) =>
                {
                    // originalTags.Value.Data.TagValues[key] = value;
                    return new IndexerExpression(tagValues, keyParam).Assign(valueParam).Terminate();
                }, false),
                BuildElseStatements(cancellationTokenParam, (currentTags) =>
                {
                    // current.Tags[key] = value;
                    return new IndexerExpression(currentTags, keyParam)
                        .Assign(valueParam).Terminate();
                }, true)
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
