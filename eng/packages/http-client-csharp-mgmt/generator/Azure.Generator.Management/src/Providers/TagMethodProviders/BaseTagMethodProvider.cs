// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Extensions;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.TagMethodProviders
{
    internal abstract class BaseTagMethodProvider
    {
        protected readonly MethodSignature _signature;
        protected readonly MethodBodyStatement[] _bodyStatements;
        protected readonly TypeProvider _enclosingType;
        protected readonly ResourceClientProvider _resource;
        protected readonly MethodProvider _updateMethodProvider;
        protected readonly ClientProvider _restClient;
        protected readonly RequestPathPattern _contextualPath;
        protected readonly FieldProvider _clientDiagnosticsField;
        protected readonly FieldProvider _restClientField;
        protected readonly bool _isAsync;
        protected static readonly ParameterProvider _keyParameter = new ParameterProvider("key", $"The key for the tag.", typeof(string), validation: ParameterValidationType.AssertNotNull);
        protected static readonly ParameterProvider _valueParameter = new ParameterProvider("value", $"The value for the tag.", typeof(string), validation: ParameterValidationType.AssertNotNull);

        protected BaseTagMethodProvider(
            ResourceClientProvider resource,
            MethodProvider updateMethodProvider,
            RestClientInfo restClientInfo,
            bool isAsync,
            string methodName,
            string methodDescription)
        {
            _resource = resource;
            _updateMethodProvider = updateMethodProvider;
            _contextualPath = resource.ContextualPath;
            _enclosingType = resource;
            _restClient = restClientInfo.RestClientProvider;
            _isAsync = isAsync;
            _clientDiagnosticsField = restClientInfo.DiagnosticsField;
            _restClientField = restClientInfo.RestClientField;

            _signature = CreateMethodSignature(methodName, methodDescription);
            _bodyStatements = BuildBodyStatements();
        }

        protected abstract ParameterProvider[] BuildParameters();
        protected abstract MethodBodyStatement[] BuildBodyStatements();

        protected MethodSignature CreateMethodSignature(string methodName, string description)
        {
            var returnType = new CSharpType(typeof(Response<>), _resource.Type).WrapAsync(_isAsync);
            var modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual;
            if (_isAsync)
            {
                modifiers |= MethodSignatureModifiers.Async;
            }

            return new MethodSignature(
                methodName,
                $"{description}",
                modifiers,
                returnType,
                null,
                BuildParameters(),
                null,
                null,
                null,
                null,
                null);
        }

        protected static ValueExpression CreateCanUseTagResourceCondition(
            bool isAsync,
            ParameterProvider cancellationTokenParam)
        {
            var canUseTagResourceMethod = isAsync ? "CanUseTagResourceAsync" : "CanUseTagResource";

            return This.Invoke(canUseTagResourceMethod, [cancellationTokenParam], null, isAsync);
        }

        protected List<MethodBodyStatement> CreateRequestContextAndProcessMessage(
            ResourceClientProvider resourceClientProvider,
            bool isAsync,
            ParameterProvider cancellationTokenParam,
            out ScopedApi<Response> responseVariable)
        {
            var statements = new List<MethodBodyStatement>
            {
                ResourceMethodSnippets.CreateRequestContext(cancellationTokenParam, out var contextVariable)
            };

            InputServiceMethod? getServiceMethod = null;

            foreach (var (kind, method) in resourceClientProvider.ResourceServiceMethods)
            {
                var operation = method.Operation;
                if (kind == ResourceOperationKind.Get)
                {
                    getServiceMethod = method;
                    break;
                }
            }

            var requestMethod = _restClient.GetRequestMethodByOperation(getServiceMethod!.Operation);
            var arguments = _contextualPath.PopulateArguments(This.As<ArmResource>().Id(), requestMethod.Signature.Parameters, contextVariable, _signature.Parameters);

            statements.Add(ResourceMethodSnippets.CreateHttpMessage(_restClientField, "CreateGetRequest", arguments, out var messageVariable));

            statements.AddRange(ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                messageVariable,
                contextVariable,
                resourceClientProvider.ResourceData.Type,
                isAsync,
                out responseVariable));

            return statements;
        }

        protected static List<MethodBodyStatement> CreatePrimaryPathResponseStatements(
            ResourceClientProvider resource,
            ScopedApi<Response> responseVar)
        {
            return
            [
                // return Response.FromValue(new ResourceType(Client, response.Value), response.GetRawResponse());
                Return(ResponseSnippets.FromValue(
                    New.Instance(resource.Type, [
                        This.As<ArmResource>().Client(),
                        responseVar.Value()
                    ]),
                    responseVar.GetRawResponse()
                ))
            ];
        }

        protected static MethodBodyStatement CreateSecondaryPathResponseStatement(ScopedApi<Response> resultVariable)
        {
            // return Response.FromValue(result.Value, result.GetRawResponse());
            return Return(ResponseSnippets.FromValue(
                resultVariable.Property("Value"),
                resultVariable.Invoke("GetRawResponse")
            ));
        }

        protected static MethodBodyStatement GetResourceDataStatements(
            string variableName,
            ResourceClientProvider resourceClientProvider,
            bool isAsync,
            ParameterProvider cancellationTokenParam,
            out VariableExpression currentVar)
        {
            var getMethod = isAsync ? "GetAsync" : "Get";
            // TupleExpression wrapper is a workaround to ensure correct async syntax: (await GetAsync(...).ConfigureAwait(false)).Value.Data
            // Without this workaround, async case would generate invalid syntax: await GetAsync(...).ConfigureAwait(false).Value.Data
            return Declare(
                variableName,
                resourceClientProvider.ResourceData.Type,
                new TupleExpression(This.Invoke(getMethod, [cancellationTokenParam], null, isAsync))
                    .Property("Value").Property("Data"),
                out currentVar);
        }

        protected static MethodBodyStatement GetOriginalTagsStatement(
            bool isAsync,
            ParameterProvider cancellationTokenParam,
            out VariableExpression originalTagsVar)
        {
            var getMethod = isAsync ? "GetAsync" : "Get";
            // var originalTags = GetTagResource().Get(cancellationToken);
            return Declare(
                "originalTags",
                new CSharpType(typeof(Response<>), typeof(ResourceManager.Resources.TagResource)),
                This.Invoke("GetTagResource").Invoke(getMethod, [cancellationTokenParam], null, isAsync),
                out originalTagsVar);
        }

        protected MethodBodyStatement UpdateResourceStatement(
            VariableExpression dataVar,
            ParameterProvider cancellationTokenParam,
            out VariableExpression resultVar)
        {
            var updateMethod = _isAsync ? "UpdateAsync" : "Update";

            return Declare(
                "result",
                new CSharpType(typeof(ArmOperation<>), _resource.Type),
                This.Invoke(updateMethod, [
                    Static(typeof(WaitUntil)).Property("Completed"),
                    dataVar,
                    cancellationTokenParam
                ], null, _isAsync),
                out resultVar);
        }

        protected List<MethodBodyStatement> BuildElseStatements(
            ParameterProvider cancellationTokenParam,
            System.Func<ValueExpression, MethodBodyStatement> tagOperation,
            bool copyExistingTags)
        {
            var statements = new List<MethodBodyStatement>();

            // Get current resource data
            statements.Add(GetResourceDataStatements("current", _resource, _isAsync, cancellationTokenParam, out var resourceDataVar));

            var updateParam = _updateMethodProvider.Signature.Parameters[1];

            VariableExpression resultVar;
            if (!updateParam.Type.Equals(_resource.ResourceData.Type)) // patch case
            {
                // Create a new instance of the update patch type
                statements.Add(Declare(
                    "patch",
                    updateParam.Type,
                    New.Instance(updateParam.Type),
                    out var patchVar));

                if (copyExistingTags)
                {
                    // Generate foreach loop: foreach (var tag in current.Tags) { patch.Tags.Add(tag); }
                    var foreachStatement = new ForEachStatement(
                        typeof(KeyValuePair<string, string>), // item type
                        "tag", // item name
                        resourceDataVar.Property("Tags"), // enumerable
                        false, // isAsync
                        out var tagVariable);
                    foreachStatement.Add(patchVar.Property("Tags").Invoke("Add", tagVariable).Terminate());
                    statements.Add(foreachStatement);
                }

                // Apply the specific tag operation to the patch
                statements.Add(tagOperation(patchVar.Property("Tags")));
                statements.Add(UpdateResourceStatement(patchVar, cancellationTokenParam, out resultVar));
            }
            else
            {
                statements.Add(tagOperation(resourceDataVar.Property("Tags")));
                statements.Add(UpdateResourceStatement(resourceDataVar, cancellationTokenParam, out resultVar));
            }

            statements.Add(CreateSecondaryPathResponseStatement(resultVar.As<Response>()));
            return statements;
        }

        protected List<MethodBodyStatement> BuildIfStatements(
            ParameterProvider cancellationTokenParam,
            System.Func<ValueExpression, MethodBodyStatement> tagOperation,
            bool includeDeleteOperation)
        {
            var createMethod = _isAsync ? "CreateOrUpdateAsync" : "CreateOrUpdate";
            var deleteMethod = _isAsync ? "DeleteAsync" : "Delete";

            var statements = new List<MethodBodyStatement>();

            // Add delete operation if requested (for SetTags operation)
            if (includeDeleteOperation)
            {
                statements.Add(
                    // GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    This.Invoke("GetTagResource").Invoke(deleteMethod, [
                        Static(typeof(WaitUntil)).Property("Completed"),
                        cancellationTokenParam
                    ], null, _isAsync).Terminate()
                );
            }

            statements.Add(GetOriginalTagsStatement(_isAsync, cancellationTokenParam, out var originalTagsVar));

            // Apply the specific tag operation (add, remove, set, etc.)
            statements.Add(tagOperation(originalTagsVar.Property("Value").Property("Data").Property("TagValues")));

            statements.Add(
                // GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                This.Invoke("GetTagResource").Invoke(createMethod, [
                    Static(typeof(WaitUntil)).Property("Completed"),
                    originalTagsVar.Property("Value").Property("Data"),
                    cancellationTokenParam
                ], null, _isAsync).Terminate()
            );

            // Add RequestContext/HttpMessage/Pipeline processing statements
            statements.AddRange(CreateRequestContextAndProcessMessage(
                _resource,
                _isAsync,
                cancellationTokenParam,
                out var responseVar));

            // Add primary path response creation statements
            statements.AddRange(CreatePrimaryPathResponseStatements(_resource, responseVar));

            return statements;
        }

        public static implicit operator MethodProvider(BaseTagMethodProvider tagMethodProvider)
        {
            return new MethodProvider(
                tagMethodProvider._signature,
                tagMethodProvider._bodyStatements,
                tagMethodProvider._enclosingType);
        }
    }
}