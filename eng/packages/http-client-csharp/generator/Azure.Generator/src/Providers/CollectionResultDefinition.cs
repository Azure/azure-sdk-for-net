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
            new("continuationToken", $"A continuation token indicating where to resume paging.", new CSharpType(typeof(string)));
        private static readonly ParameterProvider NextLinkParameter =
            new("nextLink", $"The next link to use for the next page of results.", new CSharpType(typeof(Uri), isNullable: true));
        private static readonly ParameterProvider PageSizeHintParameter =
            new("pageSizeHint", $"The number of items per page.", new CSharpType(typeof(int?)));

        private readonly bool _isProtocol;

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
            _isProtocol = itemModelType == null;
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
            => $"{_client.Type.Name}{_operation.Name.ToIdentifierName()}{(_isAsync ? "Async" : "")}CollectionResult{(_isProtocol ? "" : "OfT")}";

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

        protected override CSharpType[] BuildImplements() =>
            _isAsync
                ? [new CSharpType(typeof(AsyncPageable<>), _itemModelType)]
                : [new CSharpType(typeof(Pageable<>), _itemModelType)];

        protected override MethodProvider[] BuildMethods() => [BuildAsPagesMethod(), BuildGetNextResponseMethod()];

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
                new MethodProvider(
                    signature,
                    BuildAsPagesMethodBody(),
                    this);
        }

        private MethodBodyStatement[] BuildAsPagesMethodBody()
        {
            if (_paging.NextLink == null && _paging.ContinuationToken == null)
            {
                return BuildAsPagesSinglePageMethodBody();
            }

            var statements = new List<MethodBodyStatement>();
            CSharpType nextPageType = _paging.NextLink != null
                ? new CSharpType(typeof(Uri))
                : _requestFields[_nextTokenParameterIndex!.Value].Type;

            statements.Add(Declare("nextPage", nextPageType, _paging.NextLink != null ?
                new TernaryConditionalExpression(ContinuationTokenParameter.NotEqual(Null), New.Instance<Uri>(ContinuationTokenParameter), Null) :
                ContinuationTokenParameter.NullCoalesce(_requestFields[_nextTokenParameterIndex!.Value]), out var nextPageVariable));

            var doWhileStatement = _paging.NextLink != null ?
                new DoWhileStatement(nextPageVariable.NotEqual(Null)) :
                new DoWhileStatement(Not(
                    Static<string>().Invoke(nameof(string.IsNullOrEmpty), [nextPageVariable])));

            // Get the response
            doWhileStatement.Add(Declare("response", new CSharpType(typeof(Response), isNullable: true),
                This.Invoke(_getNextResponseMethodName, [PageSizeHintParameter, nextPageVariable], _isAsync),
                out var responseVariable));

            // Early exit if response is null
            doWhileStatement.Add(new IfStatement(responseVariable.Is(Null)) { new YieldBreakStatement() });

            // Cast response to model type
            doWhileStatement.Add(Declare("responseWithType", _responseType, responseVariable.CastTo(_responseType), out var responseWithTypeVariable));
            var nextPageExpression = _paging.NextLink != null ? nextPageVariable.NullConditional().Property("AbsoluteUri") : nextPageVariable;
            if (_isProtocol)
            {
                // Convert items to BinaryData
                doWhileStatement.Add(ConvertItemsToListOfBinaryData(responseWithTypeVariable, out var itemsVariable));

                // Extract next page
                doWhileStatement.Add(nextPageVariable.Assign(_nextPagePropertyName is null ? Null : BuildGetNextPage(responseWithTypeVariable, responseVariable)).Terminate());

                // Create and yield the page
                doWhileStatement.Add(YieldReturn(Static(new CSharpType(typeof(Page<>), [_itemModelType])).Invoke("FromValues", [itemsVariable, nextPageExpression, responseVariable])));
            }
            else
            {
                // Extract next page
                doWhileStatement.Add(nextPageVariable.Assign(_nextPagePropertyName is null ? Null : BuildGetNextPage(responseWithTypeVariable, responseVariable)).Terminate());

                // Create and yield the page
                doWhileStatement.Add(YieldReturn(Static(new CSharpType(typeof(Page<>), [_itemModelType])).Invoke("FromValues", [responseWithTypeVariable.Property(_itemsPropertyName).CastTo(new CSharpType(typeof(IReadOnlyList<>), _itemModelType)), nextPageExpression, responseVariable])));
            }
            statements.Add(doWhileStatement);
            return [.. statements];
        }

        private MethodBodyStatement[] ConvertItemsToListOfBinaryData(VariableExpression responseVariable, out VariableExpression itemsVariable)
        {
            return
            [
                Declare("items", new CSharpType(typeof(List<>), typeof(BinaryData)),
                    New.Instance(new CSharpType(typeof(List<>), typeof(BinaryData))), out itemsVariable),
                new ForEachStatement("item", responseVariable.Property(_itemsPropertyName).As<IEnumerable<KeyValuePair<string, object>>>(), out var itemVariable)
                {
                    itemsVariable.Invoke("Add", [Static<BinaryData>().Invoke("FromObjectAsJson", [itemVariable])]).Terminate()
                }
            ];
        }

        private MethodBodyStatement[] BuildAsPagesSinglePageMethodBody()
        {
            var statements = new List<MethodBodyStatement>
            {
                Declare("response", new CSharpType(typeof(Response), isNullable: true),
                    This.Invoke(_getNextResponseMethodName, [PageSizeHintParameter, Null], _isAsync),
                    out var responseVariable),
                Declare("responseWithType", _responseType, responseVariable.CastTo(_responseType), out var responseWithTypeVariable)
            };

            if (_isProtocol)
            {
                statements.Add(ConvertItemsToListOfBinaryData(responseWithTypeVariable, out var itemsVariable));
                statements.Add(
                    YieldReturn(Static(new CSharpType(typeof(Page<>), [_itemModelType])).Invoke("FromValues", [itemsVariable, Null, responseVariable])));
            }
            else
            {
                statements.Add(YieldReturn(Static(new CSharpType(typeof(Page<>), [_itemModelType])).Invoke("FromValues", [responseWithTypeVariable.Property(_itemsPropertyName).CastTo(new CSharpType(typeof(IReadOnlyList<>), _itemModelType)), Null, responseVariable])));
            }

            return [..statements];
        }

        private ValueExpression BuildGetNextPage(VariableExpression responseWithTypeVariable, VariableExpression responseVariable)
        {
            if (_nextPagePropertyName is null)
            {
                return Null;
            }

            switch (_nextPageLocation)
            {
                case InputResponseLocation.Body:
                    return responseWithTypeVariable.Property(_nextPagePropertyName);
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
            var nextPageParameter = _paging.NextLink != null
                ? NextLinkParameter
                : ContinuationTokenParameter;
            var signature = new MethodSignature(
                _getNextResponseMethodName,
                $"Get next page",
                _isAsync ? MethodSignatureModifiers.Private | MethodSignatureModifiers.Async : MethodSignatureModifiers.Private,
                _isAsync ? new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response), isNullable: true)) : new CSharpType(typeof(Response), isNullable: true),
                null,
                [PageSizeHintParameter, nextPageParameter]);

            var body = new MethodBodyStatement[]
            {
                Declare("message", AzureClientGenerator.Instance.TypeFactory.HttpMessageApi.HttpMessageType, BuildCreateHttpMessageExpression(), out var messageVariable),
                UsingDeclare("scope", typeof(DiagnosticScope), _clientField.Property("ClientDiagnostics").Invoke(nameof(ClientDiagnostics.CreateScope), [Literal(_scopeName)]), out var scopeVariable),
                scopeVariable.Invoke(nameof(DiagnosticScope.Start)).Terminate(),
                new TryCatchFinallyStatement
                    (BuildTryExpression(), Catch(Declare<Exception>("e", out var exceptionVariable), [scopeVariable.Invoke(nameof(DiagnosticScope.Failed), exceptionVariable).Terminate(), Throw()]))
            };

            ValueExpression BuildCreateHttpMessageExpression()
            {
                if (_paging.NextLink is not null)
                {
                    return InvokeCreateRequestForNextLink(nextPageParameter);
                }
                else if (_paging.ContinuationToken is not null)
                {
                    return InvokeCreateRequestForContinuationToken(nextPageParameter);
                }
                else
                {
                    return InvokeCreateRequestForSingle();
                }
            }

            TryExpression BuildTryExpression()
                => new TryExpression(_clientField.Property("Pipeline").Invoke(_isAsync ? "SendAsync" : "Send", [messageVariable, This.Property("CancellationToken")], _isAsync).Terminate(), BuildGetResponse(messageVariable));

            return new MethodProvider(signature, body, this);
        }

        private MethodBodyStatement[] BuildGetResponse(ValueExpression messageVariable)
        {
            return new MethodBodyStatement[]
            {
                new IfStatement(messageVariable.Property("Response").Property("IsError").As<bool>().And(_contextField!.Property("ErrorOptions").NotEqual(Static<ErrorOptions>().Property(nameof(ErrorOptions.NoThrow)))))
                {
                    Throw(New.Instance<RequestFailedException>(messageVariable.Property("Response")))
                },
                Return(messageVariable.Property("Response"))
            };
        }

        private ScopedApi<HttpMessage> InvokeCreateRequestForNextLink(ValueExpression nextPageUri)
        {
            var createNextLinkRequestMethodName =
                _client.RestClient.GetCreateNextLinkRequestMethod(_operation).Signature.Name;
            return new TernaryConditionalExpression(
                nextPageUri.NotEqual(Null),
                _clientField.Invoke(
                    createNextLinkRequestMethodName,
                    [nextPageUri, .. _requestFields.Select(f => f.AsValueExpression)]),
                _clientField.Invoke(
                    _createRequestMethodName,
                    [.. _requestFields.Select(f => f.AsValueExpression)])).As<HttpMessage>();
        }

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

            return _clientField.Invoke(_createRequestMethodName, arguments).As<HttpMessage>();
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
                        ],
                        Initializer: new ConstructorInitializer(
                            true,
                            // Pass the request context cancellation token to the base Pageable constructor
                            [_createRequestParameters[^1].NullConditional().Property("CancellationToken").NullCoalesce(Default)])),
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