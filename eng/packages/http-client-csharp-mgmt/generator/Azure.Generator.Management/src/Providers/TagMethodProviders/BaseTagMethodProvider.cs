// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.Generator.Management.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.TagMethodProviders
{
    internal abstract class BaseTagMethodProvider
    {
        protected readonly MethodSignature _signature;
        protected readonly MethodBodyStatement[] _bodyStatements;
        protected readonly TypeProvider _enclosingType;
        protected readonly ResourceClientProvider _resourceClientProvider;
        protected readonly bool _isAsync;

        protected BaseTagMethodProvider(
            ResourceClientProvider resourceClientProvider,
            bool isAsync)
        {
            _resourceClientProvider = resourceClientProvider;
            _enclosingType = resourceClientProvider;
            _isAsync = isAsync;

            _signature = CreateMethodSignature();
            _bodyStatements = BuildBodyStatements();
        }

        protected abstract MethodSignature CreateMethodSignature();
        protected abstract ParameterProvider[] BuildParameters();
        protected abstract MethodBodyStatement[] BuildBodyStatements();

        protected static ParameterProvider CreateKeyParameter()
        {
            return new ParameterProvider("key", $"The key for the tag.", typeof(string), validation: ParameterValidationType.AssertNotNull);
        }

        protected static ParameterProvider CreateValueParameter()
        {
            return new ParameterProvider("value", $"The value for the tag.", typeof(string), validation: ParameterValidationType.AssertNotNull);
        }

        protected MethodSignature CreateMethodSignatureCore(string methodName, string description)
        {
            var returnType = new CSharpType(typeof(Azure.Response<>), _resourceClientProvider.ResourceClientCSharpType).WrapAsync(_isAsync);
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

        protected static List<MethodBodyStatement> CreateRequestContextAndProcessMessage(
            ResourceClientProvider resourceClientProvider,
            bool isAsync,
            ParameterProvider cancellationTokenParam,
            out VariableExpression responseVariable)
        {
            var statements = new List<MethodBodyStatement>
            {
                ResourceMethodSnippets.CreateRequestContext(cancellationTokenParam, out var contextVariable)
            };

            InputServiceMethod? getServiceMethod = null;

            foreach (var method in resourceClientProvider.ResourceServiceMethods)
            {
                var operation = method.Operation;
                if (operation.HttpMethod == HttpMethod.Get.ToString() && operation.Name == "get")
                {
                    getServiceMethod = method;
                    break;
                }
            }

            var clientProvider = resourceClientProvider.GetClientProvider();
            var convenienceMethod = clientProvider.GetConvenienceMethodByOperation(getServiceMethod!.Operation, isAsync);
            var requestMethod = getServiceMethod!.GetCorrespondingRequestMethod(resourceClientProvider);
            var arguments = resourceClientProvider.PopulateArguments(requestMethod.Signature.Parameters, contextVariable, convenienceMethod);

            statements.Add(ResourceMethodSnippets.CreateHttpMessage(resourceClientProvider, "CreateGetRequest", arguments, out var messageVariable));

            var responseType = new CSharpType(typeof(Response<>), resourceClientProvider.ResourceData.Type);
            statements.AddRange(ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                messageVariable,
                contextVariable,
                responseType,
                isAsync,
                out responseVariable));

            return statements;
        }

        protected static List<MethodBodyStatement> CreatePrimaryPathResponseStatements(
            ResourceClientProvider resourceClientProvider,
            VariableExpression responseVar)
        {
            return
            [
                // return Response.FromValue(new ResourceType(Client, response.Value), response.GetRawResponse());
                Return(Static(typeof(Response)).Invoke("FromValue", [
                    New.Instance(resourceClientProvider.ResourceClientCSharpType, [
                        This.Property("Client"),
                        responseVar.Property("Value")
                    ]),
                    responseVar.Invoke("GetRawResponse")
                ]))
            ];
        }

        protected static MethodBodyStatement CreateSecondaryPathResponseStatement(VariableExpression resultVariable)
        {
            // return Response.FromValue(result.Value, result.GetRawResponse());
            return Return(Static(typeof(Response)).Invoke("FromValue", [
                resultVariable.Property("Value"),
                resultVariable.Invoke("GetRawResponse")
            ]));
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

        public static implicit operator MethodProvider(BaseTagMethodProvider tagMethodProvider)
        {
            return new MethodProvider(
                tagMethodProvider._signature,
                tagMethodProvider._bodyStatements,
                tagMethodProvider._enclosingType);
        }
    }
}