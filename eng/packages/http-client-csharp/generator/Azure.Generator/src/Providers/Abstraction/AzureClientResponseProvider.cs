// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal record AzureClientResponseProvider : ClientResponseApi
    {
        private static ClientResponseApi? _instance;
        internal static ClientResponseApi Instance => _instance ??= new AzureClientResponseProvider(Empty);

        public AzureClientResponseProvider(ValueExpression original) : base(typeof(Response), original)
        {
        }

        public override CSharpType ClientResponseType => typeof(Response);

        public override CSharpType ClientResponseOfTType => typeof(Response<>);

        // There is no non-generic Pageable type. Instead we use Pageable<T> with T = BinaryData.
        public override CSharpType ClientCollectionResponseType => new CSharpType(typeof(Pageable<>), typeof(BinaryData));
        public override CSharpType ClientCollectionAsyncResponseType => new CSharpType(typeof(AsyncPageable<>), typeof(BinaryData));
        public override CSharpType ClientCollectionResponseOfTType => new CSharpType(typeof(Pageable<>), typeof(BinaryData));
        public override CSharpType ClientCollectionAsyncResponseOfTType => new CSharpType(typeof(AsyncPageable<>), typeof(BinaryData));

        public override TypeProvider CreateClientCollectionResultDefinition(ClientProvider client,
            InputPagingServiceMethod serviceMethod,
            CSharpType? type,
            bool isAsync)
        {
            return new AzureCollectionResultDefinition(client, serviceMethod, type, isAsync);
        }

        public override CSharpType ClientResponseExceptionType => typeof(RequestFailedException);

        public override ValueExpression CreateAsync(HttpResponseApi response)
            => New.Instance(ClientResponseExceptionType, [response]);

        public override ClientResponseApi FromExpression(ValueExpression original)
            => new AzureClientResponseProvider(original);

        public override ValueExpression FromResponse(ValueExpression valueExpression) => valueExpression;

        public override ValueExpression FromValue(ValueExpression valueExpression, HttpResponseApi response)
            => Static(ClientResponseType).Invoke(nameof(FromValue), [valueExpression, response]);

        public override ValueExpression FromValue<ValueType>(ValueExpression valueExpression, HttpResponseApi response)
            => Static(ClientResponseType).Invoke(nameof(FromValue), [valueExpression, response], [typeof(ValueType)], false);

        public override HttpResponseApi GetRawResponse()
            => new AzureResponseProvider(GetRawResponseExpression());

        public override ClientResponseApi ToExpression() => this;

        private ScopedApi<Response> GetRawResponseExpression() => Original.As<Response>();
    }
}
