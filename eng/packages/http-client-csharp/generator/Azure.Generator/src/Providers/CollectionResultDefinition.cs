// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
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
        private readonly string? _nextLinkPropertyName;
        private readonly InputResponseLocation? _nextPageLocation;
        private readonly string _getNextResponseMethodName;

        private readonly IReadOnlyList<ParameterProvider> _createRequestParameters;
        private readonly FieldProvider? _contextField;

        private static readonly ParameterProvider NextLinkParameter =
            new("continuationToken", $"The continuation token.", new CSharpType(typeof(string), isNullable: true));

        private static readonly ParameterProvider PageSizeHintParameter =
            new("pageSizeHint", $"The page size hint.", new CSharpType(typeof(int?)));

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
            _createRequestParameters = _client.RestClient.GetCreateRequestMethod(_operation).Signature.Parameters;
            var fields = new List<FieldProvider>();
            for (int paramIndex = 0; paramIndex < _createRequestParameters.Count; paramIndex++)
            {
                var parameter = _createRequestParameters[paramIndex];
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
            _scopeName = $"{_client.Name}.{_operation.Name}"; // TODO - may need to expose ToCleanName for the operation

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
                _nextLinkPropertyName =
                    responseModel.CanonicalView.Properties.FirstOrDefault(
                        p => p.WireInfo?.SerializedName == nextPagePropertyName)?.Name;
            }
            else if (_nextPageLocation == InputResponseLocation.Header)
            {
                _nextLinkPropertyName = nextPagePropertyName;
            }
        }

        protected override FieldProvider[] BuildFields() => [_clientField, .. _requestFields];

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override string BuildName()
        // TODO - may need to expose ToCleanName for the operation
            => $"{_client.Type.Name}{_operation.Name}{(_isAsync ? "Async" : "")}CollectionResult{(IsProtocolMethod() ? "" : "OfT")}";

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
                [NextLinkParameter, PageSizeHintParameter]);

            if (!IsProtocolMethod())
            {
                // Convenience method
                return new MethodProvider(signature, new MethodBodyStatement[]
                {
                    Declare("nextLink", new CSharpType(typeof(string), isNullable: true), NextLinkParameter, out var nextLinkVariableForConvenience),
                    BuildDoWhileStatementForConvenience(nextLinkVariableForConvenience)
                }, this);
            }

            // Protocol method
            return new MethodProvider(signature, new MethodBodyStatement[]
                {
                    Declare("nextLink", new CSharpType(typeof(string), isNullable: true), NextLinkParameter, out var nextLinkVariable),
                    BuildDoWhileStatementForProtocol(nextLinkVariable)
                }, this);
        }

        private DoWhileStatement BuildDoWhileStatementForProtocol(VariableExpression nextLinkVariable)
        {
            var doWhileStatement = new DoWhileStatement(Not(Static<string>().Invoke("IsNullOrEmpty", [nextLinkVariable])));

            // Get the response
            doWhileStatement.Add(Declare("response", new CSharpType(typeof(Response), isNullable: true),
                This.Invoke(_getNextResponseMethodName, [PageSizeHintParameter, nextLinkVariable], _isAsync),
                out var responseVariable));

            // Early exit if response is null
            doWhileStatement.Add(new IfStatement(responseVariable.Is(Null)) { new YieldBreakStatement() });

            // Parse response content as JsonDocument
            doWhileStatement.Add(UsingDeclare("jsonDoc", typeof(JsonDocument),
                Static<JsonDocument>().Invoke("Parse", [responseVariable.Property("Content").Invoke("ToString")]),
                out var jsonDocVariable));

            // Get root element
            doWhileStatement.Add(Declare("root", typeof(JsonElement),
                jsonDocVariable.Property("RootElement"), out var rootVariable));

            // Extract items array
            doWhileStatement.Add(Declare("items", new CSharpType(typeof(List<>), _itemModelType),
                New.Instance(new CSharpType(typeof(List<>), _itemModelType)), out var itemsVariable));

            // Get items array from response
            var tryGetItems = new IfStatement(rootVariable.Invoke("TryGetProperty", [Literal(_itemsPropertyName), new DeclarationExpression(typeof(JsonElement), "itemsArray", out var itemsArrayVariable, isOut: true)]));

            // Parse items
            var foreachItems = new ForeachStatement("item", itemsArrayVariable.Invoke("EnumerateArray").As<IEnumerable<KeyValuePair<string, object>>>(), out var itemVariable);
            //var foreachItems = new ForEachStatement("item", itemsArrayVariable.Invoke("EnumerateArray"), out var itemVarialble);
            foreachItems.Add(itemsVariable.Invoke("Add", [Static<BinaryData>().Invoke("FromString", [itemVariable.Invoke("ToString")])]).Terminate());

            tryGetItems.Add(foreachItems);
            doWhileStatement.Add(tryGetItems);

            // Extract next link
            if (_nextPageLocation == InputResponseLocation.Body && _nextLinkPropertyName != null)
            {
                doWhileStatement.Add(nextLinkVariable.Assign(new BinaryOperatorExpression(":",
                    new BinaryOperatorExpression("?",
                    rootVariable.Invoke("TryGetProperty", [Literal(_nextLinkPropertyName), new DeclarationExpression(typeof(JsonElement), "value", out var nextLinkValue, isOut: true)]),
                    nextLinkValue.Invoke("GetString")), Null)).Terminate());
            }
            else if (_nextPageLocation == InputResponseLocation.Header && _nextLinkPropertyName != null)
            {
                doWhileStatement.Add(nextLinkVariable.Assign(new BinaryOperatorExpression(":",
                    new BinaryOperatorExpression("?",
                        responseVariable.Property("Headers").Invoke("TryGetValue",[Literal(_nextLinkPropertyName), new DeclarationExpression(typeof(string), "value", out var nextLinkHeader, isOut: true)]).As<bool>(),nextLinkHeader),
                        Null)).Terminate());
            }

            // Create and yield the page
            doWhileStatement.Add(new YieldReturnStatement(
                Static(new CSharpType(typeof(Page<>), [_itemModelType]))
                    .Invoke("FromValues", [itemsVariable, nextLinkVariable, responseVariable])));

            return doWhileStatement;
        }

        private ValueExpression BuildGetNextLinkForProtocol(VariableExpression nextLinkVariable, VariableExpression rootVariable, VariableExpression responseVariable)
        {
            if (_nextLinkPropertyName is null)
            {
                return Null;
            }

            switch (_nextPageLocation)
            {
                case InputResponseLocation.Body:
                    return new BinaryOperatorExpression(":",
                    new BinaryOperatorExpression("?",
                    rootVariable.Invoke("TryGetProperty", [Literal(_nextLinkPropertyName), new DeclarationExpression(typeof(JsonElement), "value", out var nextLinkValue, isOut: true)]),
                    nextLinkValue.Invoke("GetString")), Null);
                case InputResponseLocation.Header:
                    return new BinaryOperatorExpression(":",
                        new BinaryOperatorExpression("?",
                            responseVariable.Property("Headers").Invoke("TryGetValue", [Literal(_nextLinkPropertyName), new DeclarationExpression(typeof(string), "value", out var nextLinkHeader, isOut: true)]).As<bool>(), nextLinkHeader),
                            Null);
                default:
                    return Null;
            }
        }

        private DoWhileStatement BuildDoWhileStatementForConvenience(VariableExpression nextLinkVariable)
        {
            var doWhileStatement = new DoWhileStatement(Not(Static<string>().Invoke("IsNullOrEmpty", [nextLinkVariable])));
            doWhileStatement.Add(Declare("response", new CSharpType(typeof(Response), isNullable: true), This.Invoke(_getNextResponseMethodName, [PageSizeHintParameter, nextLinkVariable], _isAsync), out var responseVariable));
            doWhileStatement.Add(new IfStatement(responseVariable.Is(Null)) { new YieldBreakStatement() });
            doWhileStatement.Add(Declare("items", _responseType, responseVariable.CastTo(_responseType), out var itemsVariable));
            doWhileStatement.Add(nextLinkVariable.Assign(_nextLinkPropertyName is null ? Null : BuildGetNextLinkMethodBodyForConvenience(itemsVariable, responseVariable).Invoke("ToString")).Terminate());
            doWhileStatement.Add(new YieldReturnStatement(Static(new CSharpType(typeof(Page<>), [_itemModelType])).Invoke("FromValues", [itemsVariable.Property(_itemsPropertyName).CastTo(new CSharpType(typeof(IReadOnlyList<>), _itemModelType))/*.Invoke("AsReadOnly")*/, nextLinkVariable, responseVariable])));
            return doWhileStatement;
        }

        private ValueExpression BuildGetNextLinkMethodBodyForConvenience(VariableExpression itemsVariable, VariableExpression responseVariable)
        {
            if (_nextLinkPropertyName is null)
            {
                return Null;
            }

            switch (_nextPageLocation)
            {
                case InputResponseLocation.Body:
                    return itemsVariable.Property(_nextLinkPropertyName);
                case InputResponseLocation.Header:
                    return new BinaryOperatorExpression(":",
                            new BinaryOperatorExpression("?",
                            responseVariable.Property("Headers").Invoke("TryGetValue", Literal(_nextLinkPropertyName), new DeclarationExpression(typeof(string), "value", out var nextLinkHeader, isOut: true)).As<bool>(),
                            nextLinkHeader),
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
                [PageSizeHintParameter, NextLinkParameter]);

            var body = new MethodBodyStatement[]
            {
                Declare("message", AzureClientGenerator.Instance.TypeFactory.HttpMessageApi.HttpMessageType, InvokeCreateRequestForNextLink(_requestFields[0].As<Uri>()), out var messageVariable),
                UsingDeclare("scope", typeof(DiagnosticScope), _clientField.Property("ClientDiagnostics").Invoke(nameof(ClientDiagnostics.CreateScope), [Literal(_scopeName)]), out var scopeVariable),
                scopeVariable.Invoke(nameof(DiagnosticScope.Start)).Terminate(),
                new TryCatchFinallyStatement
                    (BuildTryStatement(messageVariable), Catch(Declare<Exception>("e", out var exceptionVarialble), [scopeVariable.Invoke(nameof(DiagnosticScope.Failed), exceptionVarialble).Terminate(), Throw()]))
            };

            TryStatement BuildTryStatement(ValueExpression messageVariable)
            {
                var tryStatement = new TryStatement();
                tryStatement.Add(_clientField.Property("Pipeline").Invoke(_isAsync ? "SendAsync" : "Send", [messageVariable, Default], _isAsync).Terminate());
                tryStatement.Add(Return(This.Invoke(GetResponseMethodName, [messageVariable])));
                return tryStatement;
            }
            return new MethodProvider(signature, body, this);
        }

        private const string GetResponseMethodName = "GetResponse";
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
                new IfStatement(new BinaryOperatorExpression("&&", messageParameter.Property("Response").Property("IsError"), _contextField!.Property("ErrorOptions").NotEqual(Static<ErrorOptions>().Property(nameof(ErrorOptions.NoThrow)))))
                {
                    Throw(New.Instance<RequestFailedException>(messageParameter.Property("Response")))
                },
                Return(messageParameter.Property("Response"))
            };
            return new MethodProvider(signature, body, this);
        }

        private ScopedApi<HttpMessage> InvokeCreateRequestForNextLink(ValueExpression nextPageUri) => _clientField.Invoke(
            // TODO - may need to expose ToCleanName for the operation
            $"Create{_operation.Name}Request",
            // we replace the first argument (the initialUri) with the nextPageUri
            [nextPageUri, .. _requestFields.Skip(1)])
            .As<HttpMessage>();

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