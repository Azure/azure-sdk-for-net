// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal class CollectionResultDefinition : TypeProvider
    {
        private readonly ClientProvider _client;
        private readonly InputOperation _operation;
        private readonly CSharpType _itemModelType;
        private readonly bool _isAsync;

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
            _operation = serviceMethod.Operation;
            _itemModelType = itemModelType ?? new CSharpType(typeof(BinaryData));
            _isAsync = isAsync;
        }

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override string BuildName()
        // TODO - may need to expose ToCleanName for the operation
            => $"{_operation.Name}{(_isAsync ? "Async" : "")}CollectionResult{(_itemModelType == null ? "" : "OfT")}";

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
    }
}