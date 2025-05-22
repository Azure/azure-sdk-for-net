// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal class CollectionResultDefinition : TypeProvider
    {
        private readonly ClientProvider _client;
        private readonly FieldProvider _clientField;
        private readonly InputOperation _operation;
        private readonly CSharpType _itemModelType;
        private readonly CSharpType _responseType;
        private readonly bool _isAsync;
        private readonly InputPagingServiceMetadata _paging;
        private readonly IReadOnlyList<FieldProvider> _requestFields;
        private readonly string _scopeName;
        private readonly string _itemsPropertyName;
        private readonly string? _nextPagePropertyName;
        private readonly InputResponseLocation? _nextPageLocation;
        private readonly string _getNextResponseMethodName;
        private readonly int? _nextTokenParameterIndex;
        private readonly string _createRequestMethodName;

        private readonly IReadOnlyList<ParameterProvider> _createRequestParameters;
        private readonly FieldProvider? _contextField;

        private static readonly ParameterProvider ContinuationTokenParameter =
            new("continuationToken", $"A continuation token indicating where to resume paging.", new CSharpType(typeof(string), isNullable: true));
        private static readonly ParameterProvider PageSizeHintParameter =
            new("pageSizeHint", $"The number of items per page.", new CSharpType(typeof(int?)));
        private const string GetResponseMethodName = "GetResponse";

        public CollectionResultDefinition(ClientProvider client, InputPagingServiceMethod serviceMethod, CSharpType? itemModelType, bool isAsync)
        {
            _client = client;
            _paging = serviceMethod.PagingMetadata;
            _getNextResponseMethodName = _isAsync ? "GetNextResponseAsync" : "GetNextResponse";

            var nextPagePropertyName = _paging.NextLink != null
                ? _paging.NextLink.ResponseSegments[0]
                : _paging.ContinuationToken?.ResponseSegments[0];
            _nextPageLocation = _paging.NextLink?.ResponseLocation ?? _paging.ContinuationToken?.ResponseLocation;
            _clientField = new FieldProvider(
                FieldModifiers.Private | FieldModifiers.ReadOnly,
                _client.Type,
                "_client",
                this);
            _operation = serviceMethod.Operation;
            _itemModelType = itemModelType ?? new CSharpType(typeof(BinaryData));
            _isAsync = isAsync;
            var createRequestMethodSignature = _client.RestClient.GetCreateRequestMethod(_operation).Signature;
            _createRequestMethodName = createRequestMethodSignature.Name;
            _createRequestParameters = createRequestMethodSignature.Parameters;
            var fields = new List<FieldProvider>();
            for (int paramIndex = 0; paramIndex < _createRequestParameters.Count; paramIndex++)
            {
                var parameter = _createRequestParameters[paramIndex];
                if (parameter.Name == _paging.ContinuationToken?.Parameter.Name)
                {
                    _nextTokenParameterIndex = paramIndex;
                }
                var field = new FieldProvider(
                    FieldModifiers.Private | FieldModifiers.ReadOnly,
                    parameter.Type,
                    $"_{parameter.Name}",
                    this);
                fields.Add(field);
                if (field.Name == "_context")
                {
                    _contextField = field;
                }
            }

            _requestFields = fields;
            _scopeName = _client.GetScopeName(_operation);

            // We only need to consider the first layer in Azure
            var response = _operation.Responses.FirstOrDefault(r => !r.IsErrorResponse);
            var responseModel = AzureClientGenerator.Instance.TypeFactory.CreateModel((InputModelType)response!.BodyType!)!;
            _responseType = responseModel.Type;
            var itemsPropertyName = _paging.ItemPropertySegments[0];
            var itemsModelPropertyName = responseModel.CanonicalView.Properties
                .FirstOrDefault(p => p.WireInfo?.SerializedName == itemsPropertyName)?.Name;
            if (itemsModelPropertyName == null)
            {
                AzureClientGenerator.Instance.Emitter.ReportDiagnostic(
                    "missing-items-property",
                    $"Missing items property: {itemsPropertyName}",
                    _operation.CrossLanguageDefinitionId);
            }
            _itemsPropertyName = itemsModelPropertyName ?? itemsPropertyName;

            // Find the model property that has the serialized name matching the next link.
            // Use the canonical view in case the property was customized.
            if (_nextPageLocation == InputResponseLocation.Body)
            {
                _nextPagePropertyName =
                    responseModel.CanonicalView.Properties.FirstOrDefault(
                        p => p.WireInfo?.SerializedName == nextPagePropertyName)?.Name;
            }
            else if (_nextPageLocation == InputResponseLocation.Header)
            {
                _nextPagePropertyName = nextPagePropertyName;
            }
        }

        protected override FieldProvider[] BuildFields() => [_clientField, .. _requestFields];

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override string BuildName()
            => $"{_client.Type.Name}{_operation.Name.ToIdentifierName()}{(_isAsync ? "Async" : "")}CollectionResult{(IsProtocolMethod() ? "" : "OfT")}";

        // Model type is BinaryData fro protocol methods
        private bool IsProtocolMethod() => _itemModelType.Equals(typeof(BinaryData));

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

        protected override CSharpType[] BuildImplements() =>
            _isAsync
                ? [new CSharpType(typeof(AsyncPageable<>), _itemModelType)]
                : [new CSharpType(typeof(Pageable<>), _itemModelType)];

        protected override MethodProvider[] BuildMethods() => [BuildAsPagesMethod(), BuildGetNextResponseMethod(), BuildGetResponseMethod()];

        private MethodProvider BuildAsPagesMethod()
        {
            var signature = new MethodSignature(
                "AsPages",
                $"Gets the pages of {Name} as an enumerable collection.",
                _isAsync
                    ? MethodSignatureModifiers.Async | MethodSignatureModifiers.Public | MethodSignatureModifiers.Override
                    : MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                _isAsync ?
                    new CSharpType(typeof(IAsyncEnumerable<>), new CSharpType(typeof(Page<>), _itemModelType)) :
                    new CSharpType(typeof(IEnumerable<>), new CSharpType(typeof(Page<>), _itemModelType)),
                $"The pages of {Name} as an enumerable collection.",
                [ContinuationTokenParameter, PageSizeHintParameter]);

            return
                new MethodProvider(signature,
                    new MethodBodyStatement[]
                    {
                        BuildDoWhileStatementForProtocol(IsProtocolMethod())
                    }, this);
        }

        private DoWhileStatement BuildDoWhileStatementForProtocol(bool isProtocol)
        {
            var doWhileStatement = new DoWhileStatement(Not(Static<string>().Invoke(nameof(string.IsNullOrEmpty), [ContinuationTokenParameter])));

            // Get the response
            doWhileStatement.Add(Declare("response", new CSharpType(typeof(Response), isNullable: true),
                This.Invoke(_getNextResponseMethodName, [PageSizeHintParameter, ContinuationTokenParameter], _isAsync),
                out var responseVariable));

            // Early exit if response is null
            doWhileStatement.Add(new IfStatement(responseVariable.Is(Null)) { new YieldBreakStatement() });

            // Cast response to model type
            doWhileStatement.Add(Declare("responseWithType", _responseType, responseVariable.CastTo(_responseType), out var responseWithTypeVariable));

            if (isProtocol)
            {
                // Declare items array
                doWhileStatement.Add(Declare("items", new CSharpType(typeof(List<>), _itemModelType),
                    New.Instance(new CSharpType(typeof(List<>), _itemModelType)), out var itemsVariable));

                // Get items array from response
                doWhileStatement.Add(
                    new ForEachStatement("item", responseWithTypeVariable.Property(_itemsPropertyName).As<IEnumerable<KeyValuePair<string, object>>>(), out var itemVariable)
                    {
                    itemsVariable.Invoke("Add", [Static<BinaryData>().Invoke("FromObjectAsJson", [itemVariable])]).Terminate()
                    });

                // Extract next page
                doWhileStatement.Add(ContinuationTokenParameter.Assign(_nextPagePropertyName is null ? Null : BuildGetNextPageMethodBody(responseWithTypeVariable, responseVariable)).Terminate());

                // Create and yield the page
                doWhileStatement.Add(YieldReturn(Static(new CSharpType(typeof(Page<>), [_itemModelType])).Invoke("FromValues", [itemsVariable, ContinuationTokenParameter, responseVariable])));
            }
            else
            {
                // Extract next page
                doWhileStatement.Add(ContinuationTokenParameter.Assign(_nextPagePropertyName is null ? Null : BuildGetNextPageMethodBody(responseWithTypeVariable, responseVariable)).Terminate());

                // Create and yield the page
                doWhileStatement.Add(YieldReturn(Static(new CSharpType(typeof(Page<>), [_itemModelType])).Invoke("FromValues", [responseWithTypeVariable.Property(_itemsPropertyName).CastTo(new CSharpType(typeof(IReadOnlyList<>), _itemModelType)), ContinuationTokenParameter, responseVariable])));
            }

            return doWhileStatement;
        }

        private ValueExpression BuildGetNextPageMethodBody(VariableExpression responseWithTypeVariable, VariableExpression responseVariable)
        {
            if (_nextPagePropertyName is null)
            {
                return Null;
            }

            switch (_nextPageLocation)
            {
                case InputResponseLocation.Body:
                    return  _paging.NextLink is not null ? responseWithTypeVariable.Property(_nextPagePropertyName).Property(nameof(Uri.AbsoluteUri)) : responseWithTypeVariable.Property(_nextPagePropertyName);
                case InputResponseLocation.Header:
                    return new TernaryConditionalExpression(
                        responseVariable.Property("Headers").Invoke("TryGetValue", Literal(_nextPagePropertyName), new DeclarationExpression(typeof(string), "value", out var nextLinkHeader, isOut: true)).As<bool>(),
                        nextLinkHeader,
                        Null);
                default:
                    // Invalid location is logged by the emitter.
                    return Null;
            }
        }

        private MethodProvider BuildGetNextResponseMethod()
        {
            var signature = new MethodSignature(
                _getNextResponseMethodName,
                $"Get response from next link",
                _isAsync ? MethodSignatureModifiers.Private | MethodSignatureModifiers.Async : MethodSignatureModifiers.Private,
                _isAsync ? new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response), isNullable: true)) : new CSharpType(typeof(Response), isNullable: true),
                null,
                [PageSizeHintParameter, ContinuationTokenParameter]);

            var body = new MethodBodyStatement[]
            {
                Declare("message", AzureClientGenerator.Instance.TypeFactory.HttpMessageApi.HttpMessageType, BuildCreateHttpMessageExpression(), out var messageVariable),
                UsingDeclare("scope", typeof(DiagnosticScope), _clientField.Property("ClientDiagnostics").Invoke(nameof(ClientDiagnostics.CreateScope), [Literal(_scopeName)]), out var scopeVariable),
                scopeVariable.Invoke(nameof(DiagnosticScope.Start)).Terminate(),
                new TryCatchFinallyStatement
                    (BuildTryExpression(messageVariable), Catch(Declare<Exception>("e", out var exceptionVariable), [scopeVariable.Invoke(nameof(DiagnosticScope.Failed), exceptionVariable).Terminate(), Throw()]))
            };

            ValueExpression BuildCreateHttpMessageExpression()
            {
                if (_paging.NextLink is not null)
                {
                    return InvokeCreateRequestForNextLink(_requestFields[0].As<Uri>());
                }
                else if (_paging.ContinuationToken is not null)
                {
                    return InvokeCreateRequestForContinuationToken(ContinuationTokenParameter);
                }
                else
                {
                    return InvokeCreateRequestForSingle();
                }
            }

            TryExpression BuildTryExpression(ValueExpression messageVariable)
                => new TryExpression(_clientField.Property("Pipeline").Invoke(_isAsync ? "SendAsync" : "Send", [messageVariable, _contextField!.Property(nameof(RequestContext.CancellationToken))], _isAsync).Terminate(), Return(This.Invoke(GetResponseMethodName, [messageVariable])));

            return new MethodProvider(signature, body, this);
        }

        private MethodProvider BuildGetResponseMethod()
        {
            var messageParameter = new ParameterProvider("message", $"Http message", typeof(HttpMessage));
            var signature = new MethodSignature(
                GetResponseMethodName,
                $"Get response from message",
                MethodSignatureModifiers.Private,
                typeof(Response),
                null,
                [messageParameter]);
            var body = new MethodBodyStatement[]
            {
                new IfStatement(messageParameter.Property("Response").Property("IsError").As<bool>().And(_contextField!.Property("ErrorOptions").NotEqual(Static<ErrorOptions>().Property(nameof(ErrorOptions.NoThrow)))))
                {
                    Throw(New.Instance<RequestFailedException>(messageParameter.Property("Response")))
                },
                Return(messageParameter.Property("Response"))
            };
            return new MethodProvider(signature, body, this);
        }

        private ScopedApi<HttpMessage> InvokeCreateRequestForNextLink(ValueExpression nextPageUri) => _clientField.Invoke(
            _createRequestMethodName,
            // we replace the first argument (the initialUri) with the nextPageUri
            [nextPageUri, .. _requestFields.Skip(1)])
            .As<HttpMessage>();

        private ScopedApi<HttpMessage> InvokeCreateRequestForContinuationToken(ValueExpression continuationToken)
        {
            ValueExpression[] arguments = _requestFields.Select(f => f.AsValueExpression).ToArray();

            // Replace the nextToken field with the nextToken variable
            arguments[_nextTokenParameterIndex!.Value] = continuationToken;

            return _clientField.Invoke(_createRequestMethodName, arguments).As<HttpMessage>();
        }

        private ScopedApi<HttpMessage> InvokeCreateRequestForSingle()
        {
            ValueExpression[] arguments = [.. _requestFields.Select(f => f.AsValueExpression)];

            return _clientField.Invoke(_createRequestMethodName,arguments).As<HttpMessage>();
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            var clientParameter = new ParameterProvider(
                "client",
                $"The {_client.Type.Name} client used to send requests.",
                _client.Type);
            return
            [
                new ConstructorProvider(
                    new ConstructorSignature(
                        Type,
                        $"Initializes a new instance of {Name}, which is used to iterate over the pages of a collection.",
                        MethodSignatureModifiers.Public,
                        [
                            clientParameter,
                            .. _createRequestParameters
                        ]),
                    BuildConstructorBody(clientParameter),
                    this)
            ];
        }

        private MethodBodyStatement[] BuildConstructorBody(ParameterProvider clientParameter)
        {
            var statements = new List<MethodBodyStatement>(_createRequestParameters.Count + 1);
            statements.Add(_clientField.Assign(clientParameter).Terminate());

            for (int parameterNumber = 0; parameterNumber < _createRequestParameters.Count; parameterNumber++)
            {
                var parameter = _createRequestParameters[parameterNumber];
                var field = _requestFields[parameterNumber];
                statements.Add(field.Assign(parameter).Terminate());
            }
            return statements.ToArray();
        }
    }
}