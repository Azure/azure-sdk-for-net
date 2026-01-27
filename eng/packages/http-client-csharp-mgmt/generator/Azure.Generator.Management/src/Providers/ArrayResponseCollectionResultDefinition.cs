// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
    /// This uses a simpler TypeProvider-based implementation without inheriting from CollectionResultDefinition.
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
        private readonly string _methodName;
        private readonly string _enclosingTypeName;

        private static readonly ParameterProvider ContinuationTokenParameter =
            new("continuationToken", $"A continuation token indicating where to resume paging.", new CSharpType(typeof(string)));
        private static readonly ParameterProvider PageSizeHintParameter =
            new("pageSizeHint", $"The number of items per page.", new CSharpType(typeof(int?)));

        public ArrayResponseCollectionResultDefinition(
            ClientProvider restClient,
            InputServiceMethod serviceMethod,
            CSharpType itemType,
            CSharpType listType,
            bool isAsync,
            string scopeName,
            IReadOnlyList<ParameterProvider> constructorParameters,
            string methodName,
            string enclosingTypeName)
        {
            _restClient = restClient;
            _serviceMethod = serviceMethod;
            _itemType = itemType;
            _listType = listType;
            _isAsync = isAsync;
            _scopeName = scopeName;
            _constructorParameters = constructorParameters;
            _methodName = methodName;
            _enclosingTypeName = enclosingTypeName;
        }

        protected override string BuildRelativeFilePath() =>
            System.IO.Path.Combine("src", "Generated", "CollectionResults", $"{Name}.cs");

        protected override string BuildName()
        {
            // Use the enclosing type name (e.g., "FooResource") and actual method name
            // The method name already contains "Async" suffix when it's async, so we don't need to add/remove it
            return $"{_enclosingTypeName}{_methodName}CollectionResultOfT";
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
            var fields = new List<FieldProvider>
            {
                new FieldProvider(
                    FieldModifiers.Private | FieldModifiers.ReadOnly,
                    _restClient.Type,
                    "_client",
                    this)
            };

            // Add fields for constructor parameters
            foreach (var param in _constructorParameters)
            {
                fields.Add(new FieldProvider(
                    FieldModifiers.Private | FieldModifiers.ReadOnly,
                    param.Type,
                    $"_{param.Name}",
                    this));
            }

            // Add _context field
            fields.Add(new FieldProvider(
                FieldModifiers.Private | FieldModifiers.ReadOnly,
                typeof(RequestContext),
                "_context",
                this));

            return [.. fields];
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            var parameters = new List<ParameterProvider>
            {
                new ParameterProvider("client", $"The {_restClient.Name} client used to send requests.", _restClient.Type)
            };
            parameters.AddRange(_constructorParameters);
            parameters.Add(new ParameterProvider("context", $"The request options, which can override default behaviors of the client pipeline on a per-call basis.", typeof(RequestContext)));

            var contextParam = parameters.Last();

            var signature = new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Name}, which is used to iterate over the pages of a collection.",
                MethodSignatureModifiers.Public,
                parameters);

            var bodyStatements = new List<MethodBodyStatement>
            {
                This.Property("_client").Assign(parameters[0]).Terminate()
            };

            foreach (var param in _constructorParameters)
            {
                bodyStatements.Add(This.Property($"_{param.Name}").Assign(param).Terminate());
            }

            bodyStatements.Add(This.Property("_context").Assign(contextParam).Terminate());

            return [new ConstructorProvider(signature, bodyStatements.ToArray(), this)];
        }

        protected override MethodProvider[] BuildMethods()
        {
            return [BuildAsPagesMethod(), BuildGetNextResponseMethod(), BuildParseArrayFromResponseMethod()];
        }

        private MethodProvider BuildAsPagesMethod()
        {
            var signature = new MethodSignature(
                "AsPages",
                $"Gets the pages of {Name} as an enumerable collection.",
                _isAsync
                    ? MethodSignatureModifiers.Async | MethodSignatureModifiers.Public | MethodSignatureModifiers.Override
                    : MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                _isAsync
                    ? new CSharpType(typeof(IAsyncEnumerable<>), new CSharpType(typeof(Page<>), _itemType))
                    : new CSharpType(typeof(IEnumerable<>), new CSharpType(typeof(Page<>), _itemType)),
                $"The pages of {Name} as an enumerable collection.",
                [ContinuationTokenParameter, PageSizeHintParameter]);

            return new MethodProvider(signature, BuildAsPagesMethodBody(), this);
        }

        private MethodBodyStatement[] BuildAsPagesMethodBody()
        {
            var statements = new List<MethodBodyStatement>
            {
                Declare("response", new CSharpType(typeof(Response), isNullable: true),
                    This.Invoke(_isAsync ? "GetNextResponseAsync" : "GetNextResponse", [PageSizeHintParameter, Null], _isAsync),
                    out var responseVariable),
                new IfStatement(responseVariable.Is(Null)) { new YieldBreakStatement() },
                Declare("result", new CSharpType(typeof(IReadOnlyList<>), _itemType),
                    Static(Type).Invoke("ParseArrayFromResponse", [responseVariable]),
                    out var resultVariable),
                YieldReturn(Static(new CSharpType(typeof(Page<>), _itemType)).Invoke("FromValues", [resultVariable, Null, responseVariable]))
            };

            return [.. statements];
        }

        private MethodProvider BuildGetNextResponseMethod()
        {
            var nextLinkParameter = new ParameterProvider("nextLink", $"The next link to use for the next page of results.", new CSharpType(typeof(Uri), isNullable: true));

            var returnType = _isAsync
                ? new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response), isNullable: true))
                : new CSharpType(typeof(Response), isNullable: true);

            var modifiers = _isAsync
                ? MethodSignatureModifiers.Private | MethodSignatureModifiers.Async
                : MethodSignatureModifiers.Private;

            var signature = new MethodSignature(
                _isAsync ? "GetNextResponseAsync" : "GetNextResponse",
                $"Get next page.",
                modifiers,
                returnType,
                null,
                [PageSizeHintParameter, nextLinkParameter]);

            return new MethodProvider(signature, BuildGetNextResponseMethodBody(), this);
        }

        private MethodBodyStatement[] BuildGetNextResponseMethodBody()
        {
            // Since we're generating collection result, we just need to call the Create*Request method on the client
            // The method name is derived from the original convenience method name from the REST client, not the potentially customized _methodName
            // (e.g., operation "listDependencies" -> convenience method "GetDependencies" -> request method "CreateGetDependenciesRequest")
            var convenienceMethod = _restClient.GetConvenienceMethodByOperation(_serviceMethod.Operation, _isAsync);
            var originalMethodName = convenienceMethod.Signature.Name;
            var baseName = originalMethodName.EndsWith("Async") ? originalMethodName.Substring(0, originalMethodName.Length - 5) : originalMethodName;
            var createRequestMethodName = $"Create{baseName}Request";

            var requestArgs = new List<ValueExpression>();

            // Add arguments from fields
            foreach (var param in _constructorParameters)
            {
                requestArgs.Add(This.Property($"_{param.Name}"));
            }

            // Add context parameter
            requestArgs.Add(This.Property("_context"));

            var bodyStatements = new List<MethodBodyStatement>
            {
                Declare("message", typeof(HttpMessage),
                    This.Property("_client").Invoke(createRequestMethodName, requestArgs),
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
                    [messageVariable, This.Property("_context")],
                    _isAsync))
            };

            var catchBlock = Catch(
                Declare<Exception>("e", out var exceptionVariable),
                [
                    scopeVariable.Invoke("Failed", exceptionVariable).Terminate(),
                    Throw()
                ]);

            bodyStatements.Add(new TryCatchFinallyStatement(new TryExpression(tryStatements), catchBlock));

            return [.. bodyStatements];
        }

        private MethodProvider BuildParseArrayFromResponseMethod()
        {
            var responseParam = new ParameterProvider("response", $"The response to parse.", typeof(Response));

            var signature = new MethodSignature(
                "ParseArrayFromResponse",
                $"Parse the array from the response.",
                MethodSignatureModifiers.Private | MethodSignatureModifiers.Static,
                new CSharpType(typeof(IReadOnlyList<>), _itemType),
                $"The parsed array.",
                [responseParam]);

            // Generate body using ForEachStatement from Statements
            var bodyStatements = new List<MethodBodyStatement>
            {
                // using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
                UsingDeclare("document", typeof(System.Text.Json.JsonDocument),
                    Static(typeof(System.Text.Json.JsonDocument)).Invoke("Parse",
                        new ValueExpression[]
                        {
                            responseParam.Property("Content"),
                            Static<ModelSerializationExtensionsDefinition>().Property("JsonDocumentOptions")
                        }),
                    out var documentVariable),

                // var array = document.RootElement;
                Declare("array", typeof(System.Text.Json.JsonElement),
                    documentVariable.Property("RootElement"),
                    out var arrayVariable),

                // var result = new List<T>();
                Declare("result", new CSharpType(typeof(List<>), _itemType),
                    New.Instance(new CSharpType(typeof(List<>), _itemType)),
                    out var resultVariable),

                // foreach (var element in array.EnumerateArray())
                new Microsoft.TypeSpec.Generator.Statements.ForEachStatement(
                    typeof(System.Text.Json.JsonElement),
                    "element",
                    arrayVariable.Invoke("EnumerateArray"),
                    isAsync: false,
                    out var elementVariable)
                {
                    // result.Add(ModelReaderWriter.Read<T>(new BinaryData(element.GetRawText()), ModelSerializationExtensions.WireOptions, {Context}.Default));
                    // Use Literal code for the context reference since it's a generated type
                    resultVariable.Invoke("Add",
                        new ValueExpression[]
                        {
                            Static(new CSharpType(typeof(System.ClientModel.Primitives.ModelReaderWriter))).Invoke("Read",
                                new ValueExpression[]
                                {
                                    New.Instance(typeof(BinaryData),
                                        Static(typeof(System.Text.Encoding)).Property("UTF8").Invoke("GetBytes",
                                            elementVariable.Invoke("GetRawText"))),
                                    Static<ModelSerializationExtensionsDefinition>().Property("WireOptions"),
                                    Static(ManagementClientGenerator.Instance.OutputLibrary.ModelReaderWriterContextType).Property("Default")
                                },
                                new[] { _itemType })
                        }).Terminate()
                },

                // return result;
                Return(resultVariable)
            };

            return new MethodProvider(signature, bodyStatements.ToArray(), this);
        }
    }
}
