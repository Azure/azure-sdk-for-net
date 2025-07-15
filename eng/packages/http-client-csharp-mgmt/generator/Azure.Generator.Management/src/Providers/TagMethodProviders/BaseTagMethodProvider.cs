// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Extensions;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.Generator.Management.Visitors;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.TagMethodProviders
{
    internal abstract class BaseTagMethodProvider
    {
        protected readonly MethodSignature _signature;
        protected readonly MethodBodyStatement[] _bodyStatements;
        protected readonly TypeProvider _enclosingType;
        protected readonly ResourceClientProvider _resource;
        protected readonly RequestPathPattern _contextualPath;
        protected readonly FieldProvider _clientDiagnosticsField;
        protected readonly FieldProvider _restClientField;
        protected readonly bool _isAsync;
        protected static readonly ParameterProvider _keyParameter = new ParameterProvider("key", $"The key for the tag.", typeof(string), validation: ParameterValidationType.AssertNotNull);
        protected static readonly ParameterProvider _valueParameter = new ParameterProvider("value", $"The value for the tag.", typeof(string), validation: ParameterValidationType.AssertNotNull);

        protected BaseTagMethodProvider(
            ResourceClientProvider resource,
            RequestPathPattern contextualPath,
            FieldProvider clientDiagnosticsField,
            FieldProvider restClientField,
            bool isAsync,
            string methodName,
            string methodDescription)
        {
            _resource = resource;
            _contextualPath = contextualPath;
            _enclosingType = resource;
            _isAsync = isAsync;
            _clientDiagnosticsField = clientDiagnosticsField;
            _restClientField = restClientField;

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
            out VariableExpression responseVariable)
        {
            var statements = new List<MethodBodyStatement>
            {
                ResourceMethodSnippets.CreateRequestContext(cancellationTokenParam, out var contextVariable)
            };

            InputServiceMethod? getServiceMethod = null;

            foreach (var (kind, method) in resourceClientProvider.ResourceServiceMethods)
            {
                var operation = method.Operation;
                if (kind == Models.ResourceOperationKind.Get)
                {
                    getServiceMethod = method;
                    break;
                }
            }

            var clientProvider = resourceClientProvider.GetClientProvider();
            var convenienceMethod = clientProvider.GetConvenienceMethodByOperation(getServiceMethod!.Operation, isAsync);
            var requestMethod = clientProvider.GetRequestMethodByOperation(getServiceMethod.Operation);
            var arguments = PopulateArguments(requestMethod.Signature.Parameters, contextVariable, _signature.Parameters);

            statements.Add(ResourceMethodSnippets.CreateHttpMessage(_restClientField, "CreateGetRequest", arguments, out var messageVariable));

            statements.AddRange(ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                messageVariable,
                contextVariable,
                resourceClientProvider.ResourceData.Type,
                isAsync,
                out responseVariable));

            return statements;
        }

        private IReadOnlyList<ValueExpression> PopulateArguments(
            IReadOnlyList<ParameterProvider> requestParameters,
            VariableExpression requestContext,
            IReadOnlyList<ParameterProvider> methodParameters)
        {
            var idProperty = This.As<ArmResource>().Id();
            var arguments = new List<ValueExpression>();
            // here we always assume that the parameter names in the create request method would match the parameter in the current method.
            foreach (var parameter in requestParameters)
            {
                // find the corresponding contextual parameter
                if (_contextualPath.TryGetContextualParameter(parameter, out var contextualParameter))
                {
                    // if the parameter is a contextual parameter, we use its value from the context variable
                    arguments.Add(contextualParameter.BuildValueExpression(idProperty)); // TODO -- add the convert later
                }
                else if (parameter.Type.Equals(typeof(RequestContent)))
                {
                    // find the body parameter
                    var bodyParameter = methodParameters.SingleOrDefault(p => p.Location == ParameterLocation.Body);
                    if (bodyParameter is not null)
                    {
                        arguments.Add(Static(bodyParameter.Type).Invoke(SerializationVisitor.ToRequestContentMethodName, [bodyParameter]));
                    }
                    else
                    {
                        arguments.Add(Null);
                    }
                }
                else if (parameter.Type.Equals(typeof(RequestContext)))
                {
                    // if the parameter is RequestContext, we use the requestContext variable
                    arguments.Add(requestContext);
                }
                else
                {
                    // otherwise, we just passing through the parameter as it is when there is one
                    arguments.Add(methodParameters.Single(p => p.WireInfo.SerializedName == parameter.WireInfo.SerializedName));
                }
            }
            return arguments;
        }

        protected static List<MethodBodyStatement> CreatePrimaryPathResponseStatements(
            ResourceClientProvider resource,
            VariableExpression responseVar)
        {
            return
            [
                // return Response.FromValue(new ResourceType(Client, response.Value), response.GetRawResponse());
                Return(Static(typeof(Response)).Invoke("FromValue", [
                    New.Instance(resource.Type, [
                        This.As<ArmResource>().Client(),
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