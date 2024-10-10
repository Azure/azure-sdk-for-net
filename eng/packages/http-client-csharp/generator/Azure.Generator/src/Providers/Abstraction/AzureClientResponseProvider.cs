// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Snippets;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal record AzureClientResponseProvider : ClientResponseApi
    {
        private static IClientResponseApi? _instance;
        internal static IClientResponseApi Instance => _instance ??= new AzureClientResponseProvider();
        private AzureClientResponseProvider() : base(typeof(Response), Empty)
        {
        }

        public AzureClientResponseProvider(ValueExpression original) : base(typeof(Response), original)
        {
        }

        public override CSharpType ClientResponseType => typeof(Response);

        public override CSharpType ClientResponseOfTType => typeof(Response<>);

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
