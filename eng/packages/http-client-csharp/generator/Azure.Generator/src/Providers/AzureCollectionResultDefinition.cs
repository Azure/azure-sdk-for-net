// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Extensions;
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
    internal class AzureCollectionResultDefinition : CollectionResultDefinition
    {
        private readonly InputOperation _operation;
        private readonly CSharpType _itemModelType;
        private readonly InputPagingServiceMetadata _paging;
        private readonly string _scopeName;
        private readonly string _getNextResponseMethodName;

        private static readonly ParameterProvider ContinuationTokenParameter =
            new("continuationToken", $"A continuation token indicating where to resume paging.", new CSharpType(typeof(string)));
        private static readonly ParameterProvider NextLinkParameter =
            new("nextLink", $"The next link to use for the next page of results.", new CSharpType(typeof(Uri), isNullable: true));
        private static readonly ParameterProvider PageSizeHintParameter =
            new("pageSizeHint", $"The number of items per page.", new CSharpType(typeof(int?)));

        private readonly bool _isProtocol;

        protected override string RequestOptionsFieldName => "_context";

        public AzureCollectionResultDefinition(ClientProvider client, InputPagingServiceMethod serviceMethod, CSharpType? itemModelType, bool isAsync) : base(client, serviceMethod, itemModelType, isAsync)
        {
            _paging = serviceMethod.PagingMetadata;
            _getNextResponseMethodName = isAsync ? "GetNextResponseAsync" : "GetNextResponse";

            _operation = serviceMethod.Operation;
            _isProtocol = itemModelType == null;
            _itemModelType = itemModelType ?? new CSharpType(typeof(BinaryData));
            _scopeName = Client.GetScopeName(_operation);
        }

        private IReadOnlyList<ParameterProvider> CreateRequestParameters
            => Client.RestClient.GetCreateRequestMethod(_operation).Signature.Parameters;

        private string CreateRequestMethodName
            => Client.RestClient.GetCreateRequestMethod(_operation).Signature.Name;

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

        protected override CSharpType[] BuildImplements() =>
            IsAsync
                ? [new CSharpType(typeof(AsyncPageable<>), _itemModelType)]
                : [new CSharpType(typeof(Pageable<>), _itemModelType)];

        protected override MethodProvider[] BuildMethods()
        {
            return [BuildAsPagesMethod(), BuildGetNextResponseMethod()];
        }

        private MethodProvider BuildAsPagesMethod()
        {
            var signature = new MethodSignature(
                "AsPages",
                $"Gets the pages of {Name} as an enumerable collection.",
                IsAsync
                    ? MethodSignatureModifiers.Async | MethodSignatureModifiers.Public | MethodSignatureModifiers.Override
                    : MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                IsAsync ?
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
                : NextTokenField!.Type;

            statements.Add(Declare("nextPage", nextPageType, _paging.NextLink != null ?
                new TernaryConditionalExpression(ContinuationTokenParameter.NotEqual(Null), New.Instance<Uri>(ContinuationTokenParameter), Null) :
                ContinuationTokenParameter.NullCoalesce(NextTokenField!), out var nextPageVariable));

            var whileStatement = new WhileStatement(True)
            {
                // Get the response
                Declare("response", new CSharpType(typeof(Response), isNullable: true),
                    This.Invoke(_getNextResponseMethodName, [PageSizeHintParameter, nextPageVariable], IsAsync),
                    out var responseVariable),
                // Early exit if response is null
                new IfStatement(responseVariable.Is(Null)) { new YieldBreakStatement() },
                Declare("result", ResponseModelType, responseVariable.CastTo(ResponseModelType), out var resultVariable),
            };

            var nextPageExpression = _paging.NextLink != null ? nextPageVariable.NullConditional().Property("AbsoluteUri") : nextPageVariable;
            if (_isProtocol)
            {
                // Convert items to BinaryData
                whileStatement.Add(ConvertItemsToListOfBinaryData(resultVariable, out var itemsVariable));

                // Create and yield the page
                whileStatement.Add(YieldReturn(Static(new CSharpType(typeof(Page<>), [_itemModelType])).Invoke("FromValues", [itemsVariable, nextPageExpression, responseVariable])));
            }
            else
            {
                // Create and yield the page
                whileStatement.Add(YieldReturn(Static(new CSharpType(typeof(Page<>), [_itemModelType])).Invoke("FromValues", [BuildGetPropertyExpression(Paging.ItemPropertySegments, resultVariable).CastTo(new CSharpType(typeof(IReadOnlyList<>), _itemModelType)), nextPageExpression, responseVariable])));
            }

            // Extract next page
            whileStatement.Add(AssignAndCheckNextPageVariable(responseVariable.ToApi<ClientResponseApi>(), resultVariable, nextPageVariable));

            statements.Add(whileStatement);
            return [.. statements];
        }

        private MethodBodyStatement[] ConvertItemsToListOfBinaryData(VariableExpression responseVariable, out VariableExpression itemsVariable)
        {
            return
            [
                Declare("items", new CSharpType(typeof(List<>), typeof(BinaryData)),
                    New.Instance(new CSharpType(typeof(List<>), typeof(BinaryData))), out itemsVariable),
                new ForEachStatement("item", BuildGetPropertyExpression(Paging.ItemPropertySegments, responseVariable).As<IEnumerable<object>>(), out var itemVariable)
                {
                    itemsVariable.Invoke("Add", Static(typeof(ModelReaderWriter)).Invoke(nameof(ModelReaderWriter.Write),
                        [
                            itemVariable,
                            Static<ModelSerializationExtensionsDefinition>().Property(ModelSerializationExtensionsDefinition.WireOptionsFieldName),
                            Static<ModelReaderWriterContextDefinition>().Property("Default")
                        ])).Terminate()
                }
            ];
        }

        private MethodBodyStatement[] BuildAsPagesSinglePageMethodBody()
        {
            var statements = new List<MethodBodyStatement>
            {
                Declare("response", new CSharpType(typeof(Response), isNullable: true),
                    This.Invoke(_getNextResponseMethodName, [PageSizeHintParameter, Null], IsAsync),
                    out var responseVariable),
                Declare("result", ResponseModelType, responseVariable.CastTo(ResponseModelType), out var resultVariable),
            };

            if (_isProtocol)
            {
                statements.Add(ConvertItemsToListOfBinaryData(resultVariable, out var itemsVariable));
                statements.Add(
                    YieldReturn(Static(new CSharpType(typeof(Page<>), [_itemModelType])).Invoke("FromValues", [itemsVariable, Null, responseVariable])));
            }
            else
            {
                statements.Add(YieldReturn(Static(new CSharpType(typeof(Page<>), [_itemModelType])).Invoke("FromValues", [BuildGetPropertyExpression(Paging.ItemPropertySegments, resultVariable).CastTo(new CSharpType(typeof(IReadOnlyList<>), _itemModelType)), Null, responseVariable])));
            }

            return [..statements];
        }

        private MethodProvider BuildGetNextResponseMethod()
        {
            var nextPageParameter = _paging.NextLink != null
                ? NextLinkParameter
                : ContinuationTokenParameter;
            var signature = new MethodSignature(
                _getNextResponseMethodName,
                $"Get next page",
                IsAsync ? MethodSignatureModifiers.Private | MethodSignatureModifiers.Async : MethodSignatureModifiers.Private,
                IsAsync ? new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response), isNullable: true)) : new CSharpType(typeof(Response), isNullable: true),
                null,
                [PageSizeHintParameter, nextPageParameter]);

            var bodyStatements = new List<MethodBodyStatement>();

            // If there's a page size field, declare a local variable that uses pageSizeHint if available, otherwise the stored field
            VariableExpression? pageSizeVariable = null;
            if (PageSizeField != null)
            {
                bodyStatements.Add(Declare("pageSize", PageSizeField.Type,
                    new TernaryConditionalExpression(
                        PageSizeHintParameter.Property("HasValue"),
                        PageSizeHintParameter.Property("Value"),
                        PageSizeField),
                    out pageSizeVariable));
            }

            bodyStatements.Add(Declare("message", AzureClientGenerator.Instance.TypeFactory.HttpMessageApi.HttpMessageType, BuildCreateHttpMessageExpression(), out var messageVariable));
            bodyStatements.Add(UsingDeclare("scope", typeof(DiagnosticScope), ClientField.Property("ClientDiagnostics").Invoke(nameof(ClientDiagnostics.CreateScope), [Literal(_scopeName)]), out var scopeVariable));
            bodyStatements.Add(scopeVariable.Invoke(nameof(DiagnosticScope.Start)).Terminate());
            bodyStatements.Add(new TryCatchFinallyStatement
                (BuildTryExpression(), Catch(Declare<Exception>("e", out var exceptionVariable), [scopeVariable.Invoke(nameof(DiagnosticScope.Failed), exceptionVariable).Terminate(), Throw()])));

            ValueExpression BuildCreateHttpMessageExpression()
            {
                if (_paging.NextLink is not null)
                {
                    return InvokeCreateRequestForNextLink(nextPageParameter, pageSizeVariable);
                }

                return ClientField.Invoke(CreateRequestMethodName, ApplyRequestArgumentTransformations(pageSizeVariable)).As<HttpMessage>();
            }

            TryExpression BuildTryExpression()
                => new TryExpression(Return(ClientField.Property("Pipeline").Invoke(IsAsync ? "ProcessMessageAsync" : "ProcessMessage", [messageVariable, RequestOptionsField], IsAsync)));

            return new MethodProvider(signature, bodyStatements.ToArray(), this);
        }

        private ScopedApi<HttpMessage> InvokeCreateRequestForNextLink(ValueExpression nextPageUri, VariableExpression? pageSizeVariable)
        {
            var createNextLinkRequestMethodSignature =
                Client.RestClient.GetCreateNextLinkRequestMethod(_operation).Signature;

            // The next link request method may not contain all the same parameters as the original create request method.
            var createNextLinkParameters = new HashSet<string>(createNextLinkRequestMethodSignature.Parameters.Select(p => p.Name.ToVariableName()));

            return new TernaryConditionalExpression(
                nextPageUri.NotEqual(Null),
                ClientField.Invoke(
                    createNextLinkRequestMethodSignature.Name,
                    [
                        nextPageUri,
                        .. ApplyRequestArgumentTransformations(
                            pageSizeVariable,
                            RequestFields.Where(f => createNextLinkParameters.Contains(f.AsParameter.Name.ToVariableName())))
                    ]),
                ClientField.Invoke(
                    CreateRequestMethodName,
                    [.. ApplyRequestArgumentTransformations(pageSizeVariable)])).As<HttpMessage>();
        }

        private IReadOnlyList<ValueExpression> ApplyRequestArgumentTransformations(
            VariableExpression? pageSizeVariable,
            IEnumerable<FieldProvider>? requestFields = null)
        {
            FieldProvider? pageSizeField = null;
            requestFields ??= RequestFields;

            if (PageSizeField != null)
            {
                pageSizeField = PageSizeField;
            }

            if (_paging.ContinuationToken != null)
            {
                return [.. requestFields.Select(
                    f => f.Name == NextTokenField?.Name ? ContinuationTokenParameter
                        : f.Name == pageSizeField?.Name && pageSizeVariable != null ? pageSizeVariable : f.AsValueExpression) ];
            }

            return [.. requestFields.Select(f => f.Name == pageSizeField?.Name && pageSizeVariable != null ? pageSizeVariable : f.AsValueExpression)];
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            var ctors = base.BuildConstructors();
            foreach (var ctor in ctors)
            {
                ctor.Signature.Update(initializer: new ConstructorInitializer(
                    true,
                    // Pass the request context cancellation token to the base Pageable constructor
                    [CreateRequestParameters[^1].NullConditional().Property("CancellationToken").NullCoalesce(Default)]));
            }

            return ctors;
        }
    }
}