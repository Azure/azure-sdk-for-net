// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
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
        private readonly bool _isAsync;
        private readonly InputPagingServiceMetadata _paging;
        private readonly IReadOnlyList<ParameterProvider> _createRequestParameters;
        private readonly int? _nextTokenParameterIndex;
        private readonly FieldProvider? _contextField;
        private readonly IReadOnlyList<FieldProvider> _requestFields;

        private static readonly ParameterProvider ContinuationTokenParameter =
            new("continuationToken", $"The continuation token.", new CSharpType(typeof(string)))
            {
                DefaultValue = Null
            };

        private static readonly ParameterProvider PageSizeHintParameter =
            new("pageSizeHint", $"The page size hint.", new CSharpType(typeof(int?)))
            {
                DefaultValue = Null
            };

        public CollectionResultDefinition(ClientProvider client, InputPagingServiceMethod serviceMethod, CSharpType? itemModelType, bool isAsync)
        {
            _client = client;
            _paging = serviceMethod.PagingMetadata;
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
        }

        protected override FieldProvider[] BuildFields() => [_clientField, .. _requestFields];

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override string BuildName()
        // TODO - may need to expose ToCleanName for the operation
            => $"{_client.Type.Name}{_operation.Name}{(_isAsync ? "Async" : "")}CollectionResult{(_itemModelType.Equals(typeof(BinaryData)) ? "" : "OfT")}";

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

        protected override CSharpType[] BuildImplements() =>
            _isAsync
                ? [new CSharpType(typeof(AsyncPageable<>), _itemModelType)]
                : [new CSharpType(typeof(Pageable<>), _itemModelType)];

        protected override MethodProvider[] BuildMethods()
        {
            return new[]
            {
                new MethodProvider(
                    new MethodSignature(
                    "AsPages",
                    $"Gets the pages of {Name} as an enumerable collection.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                    _isAsync ?
                        new CSharpType(typeof(IAsyncEnumerable<>), new CSharpType(typeof(Page<>), _itemModelType)) :
                        new CSharpType(typeof(IEnumerable<>), new CSharpType(typeof(Page<>), _itemModelType)),
                    $"The pages of {Name} as an enumerable collection.",
                    [ContinuationTokenParameter, PageSizeHintParameter]),
                    ThrowExpression(Null),
                    this)
            };
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