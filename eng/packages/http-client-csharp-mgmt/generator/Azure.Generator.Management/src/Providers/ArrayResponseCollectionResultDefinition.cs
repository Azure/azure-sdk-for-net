// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// Provider for collection result classes that wrap array responses into a single-page Pageable.
    /// </summary>
    internal class ArrayResponseCollectionResultDefinition : TypeProvider
    {
        private readonly ClientProvider _restClient;
        private readonly InputServiceMethod _serviceMethod;
        private readonly CSharpType _itemType;
        private readonly CSharpType _listType;
        private readonly bool _isAsync;
        private readonly string _scopeName;
        private readonly IReadOnlyList<ParameterProvider> _constructorParameters;

        public ArrayResponseCollectionResultDefinition(
            ClientProvider restClient,
            InputServiceMethod serviceMethod,
            CSharpType itemType,
            CSharpType listType,
            bool isAsync,
            string scopeName,
            IReadOnlyList<ParameterProvider> constructorParameters)
        {
            _restClient = restClient;
            _serviceMethod = serviceMethod;
            _itemType = itemType;
            _listType = listType;
            _isAsync = isAsync;
            _scopeName = scopeName;
            _constructorParameters = constructorParameters;
        }

        protected override string BuildRelativeFilePath() =>
            $"src/Generated/CollectionResults/{Name}.cs";

        protected override string BuildName()
        {
            var operationName = _serviceMethod.Name.ToCleanName();
            var suffix = _isAsync ? "AsyncCollectionResultOfT" : "CollectionResultOfT";
            return $"{_restClient.Name}{operationName}{suffix}";
        }

        protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
            TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial;

        protected override CSharpType[] BuildImplements()
        {
            var baseType = _isAsync
                ? new CSharpType(typeof(AsyncPageable<>), _itemType)
                : new CSharpType(typeof(Pageable<>), _itemType);
            return [baseType];
        }

        protected override FieldProvider[] BuildFields()
        {
            var fields = new List<FieldProvider>();

            // Add field for the REST client
            fields.Add(new FieldProvider(
                FieldModifiers.Private | FieldModifiers.ReadOnly,
                _restClient.Type,
                "_client",
                this));

            // Add fields for each constructor parameter (except the rest client)
            foreach (var param in _constructorParameters)
            {
                if (param.Type.Equals(_restClient.Type))
                    continue;

                fields.Add(new FieldProvider(
                    FieldModifiers.Private | FieldModifiers.ReadOnly,
                    param.Type,
                    $"_{param.Name}",
                    this));
            }

            return [.. fields];
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            var parameters = new List<ParameterProvider> { new ParameterProvider("client", $"The {_restClient.Name} client used to send requests.", _restClient.Type) };
            parameters.AddRange(_constructorParameters);

            var baseInitializer = _isAsync
                ? new ConstructorInitializer(true, [This.Property("_context").NullConditional().Property("CancellationToken").NullCoalesce(Default)])
                : null;

            var signature = new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Name}, which is used to iterate over the pages of a collection.",
                MethodSignatureModifiers.Public,
                parameters,
                null,
                baseInitializer);

            var bodyStatements = new List<MethodBodyStatement>
            {
                Assign(This.Property("_client"), new ParameterReference("client", _restClient.Type)).Terminate()
            };

            foreach (var param in _constructorParameters)
            {
                if (param.Type.Equals(_restClient.Type))
                    continue;

                bodyStatements.Add(Assign(This.Property($"_{param.Name}"), new ParameterReference(param.Name, param.Type)).Terminate());
            }

            return [new ConstructorProvider(signature, bodyStatements.ToArray(), this)];
        }

        protected override MethodProvider[] BuildMethods()
        {
            return [BuildAsPagesMethod(), BuildGetNextResponseMethod(), BuildParseArrayFromResponseMethod()];
        }

        private MethodProvider BuildAsPagesMethod()
        {
            var continuationTokenParam = new ParameterProvider("continuationToken", "A continuation token indicating where to resume paging.", new CSharpType(typeof(string)));
            var pageSizeHintParam = new ParameterProvider("pageSizeHint", "The number of items per page.", new CSharpType(typeof(int?)));

            var returnType = _isAsync
                ? new CSharpType(typeof(IAsyncEnumerable<>), new CSharpType(typeof(Page<>), _itemType))
                : new CSharpType(typeof(IEnumerable<>), new CSharpType(typeof(Page<>), _itemType));

            var modifiers = _isAsync
                ? MethodSignatureModifiers.Public | MethodSignatureModifiers.Override | MethodSignatureModifiers.Async
                : MethodSignatureModifiers.Public | MethodSignatureModifiers.Override;

            var signature = new MethodSignature(
                "AsPages",
                $"Gets the pages of {Name} as an enumerable collection.",
                modifiers,
                returnType,
                $"The pages of {Name} as an enumerable collection.",
                [continuationTokenParam, pageSizeHintParam]);

            var bodyStatements = new List<MethodBodyStatement>
            {
                Declare("response", new CSharpType(typeof(Response), isNullable: true),
                    This.Invoke(_isAsync ? "GetNextResponseAsync" : "GetNextResponse", [pageSizeHintParam, Null], _isAsync),
                    out var responseVariable),
                new IfStatement(responseVariable.Is(Null)) { new YieldBreakStatement() },
                Declare("result", new CSharpType(typeof(IReadOnlyList<>), _itemType),
                    This.Invoke("ParseArrayFromResponse", [responseVariable]),
                    out var resultVariable),
                YieldReturn(Static(new CSharpType(typeof(Page<>), _itemType)).Invoke("FromValues", [resultVariable, Null, responseVariable]))
            };

            return new MethodProvider(signature, bodyStatements.ToArray(), this);
        }

        private MethodProvider BuildGetNextResponseMethod()
        {
            var pageSizeHintParam = new ParameterProvider("pageSizeHint", "The number of items per page.", new CSharpType(typeof(int?)));
            var nextLinkParam = new ParameterProvider("nextLink", "The next link to use for the next page of results.", new CSharpType(typeof(Uri), isNullable: true));

            var returnType = _isAsync
                ? new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response), isNullable: true))
                : new CSharpType(typeof(Response), isNullable: true);

            var modifiers = _isAsync
                ? MethodSignatureModifiers.Private | MethodSignatureModifiers.Async
                : MethodSignatureModifiers.Private;

            var signature = new MethodSignature(
                _isAsync ? "GetNextResponseAsync" : "GetNextResponse",
                "Get next page",
                modifiers,
                returnType,
                null,
                [pageSizeHintParam, nextLinkParam]);

            var requestMethod = _restClient.GetRequestMethodByOperation(_serviceMethod.Operation);
            var requestArgs = new List<ValueExpression>();

            // Build arguments for the request method
            foreach (var param in requestMethod.Signature.Parameters)
            {
                if (param.Name == "context" || param.Type.Equals(typeof(RequestContext)))
                {
                    requestArgs.Add(This.Property("_context"));
                }
                else
                {
                    // Check if this parameter matches one of our constructor parameters
                    var matchingField = Fields.FirstOrDefault(f => f.Name == $"_{param.Name}");
                    if (matchingField != null)
                    {
                        requestArgs.Add(This.Property(matchingField.Name));
                    }
                }
            }

            var bodyStatements = new List<MethodBodyStatement>
            {
                Declare("message", typeof(HttpMessage),
                    This.Property("_client").Invoke(requestMethod.Signature.Name, requestArgs),
                    out var messageVariable),
                UsingDeclare("scope", typeof(DiagnosticScope),
                    This.Property("_client").Property("ClientDiagnostics").Invoke("CreateScope", [Literal(_scopeName)]),
                    out var scopeVariable),
                scopeVariable.Invoke("Start").Terminate()
            };

            var tryStatements = new List<MethodBodyStatement>
            {
                Return(This.Property("_client").Property("Pipeline").Invoke(
                    _isAsync ? "ProcessMessageAsync" : "ProcessMessage",
                    [messageVariable, This.Property("_context")], null, _isAsync))
            };

            var catchBlock = new CatchExpression(new CodeWriterDeclaration("e"), typeof(Exception))
            {
                scopeVariable.Invoke("Failed", [new VariableExpression(typeof(Exception), new CodeWriterDeclaration("e"))]).Terminate(),
                Throw
            };

            bodyStatements.Add(new TryCatchFinallyStatement(new TryExpression(tryStatements), catchBlock));

            return new MethodProvider(signature, bodyStatements.ToArray(), this);
        }

        private MethodProvider BuildParseArrayFromResponseMethod()
        {
            var responseParam = new ParameterProvider("response", "The response to parse.", typeof(Response));

            var signature = new MethodSignature(
                "ParseArrayFromResponse",
                "Parse the array from the response.",
                MethodSignatureModifiers.Private,
                new CSharpType(typeof(IReadOnlyList<>), _itemType),
                "The parsed array.",
                [responseParam]);

            var bodyStatements = new List<MethodBodyStatement>
            {
                Return(Static(_listType).Invoke("FromResponse", [responseParam]))
            };

            return new MethodProvider(signature, bodyStatements.ToArray(), this);
        }
    }
}
