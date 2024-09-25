// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Snippets;
using System.ClientModel.Primitives;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal record AzureClientResponseProvider : ClientResponseApi
    {
        public AzureClientResponseProvider(ValueExpression original) : base(typeof(Response), original)
        {
        }

        public override ValueExpression CreateAsync(HttpResponseApi response)
            => Static(AzureClientPlugin.Instance.TypeFactory.ClientResponseExceptionType).Invoke(nameof(CreateAsync), [response], true);

        public override ValueExpression FromResponse(ValueExpression valueExpression)
            => Static(AzureClientPlugin.Instance.TypeFactory.ClientResponseType).Invoke(nameof(FromResponse), [valueExpression]);

        public override ValueExpression FromValue(ValueExpression valueExpression, HttpResponseApi response)
            => Static(AzureClientPlugin.Instance.TypeFactory.ClientResponseType).Invoke(nameof(FromValue), [valueExpression, response]);

        public override ValueExpression FromValue<ValueType>(ValueExpression valueExpression, HttpResponseApi response)
            => Static(AzureClientPlugin.Instance.TypeFactory.ClientResponseType).Invoke(nameof(FromValue), [valueExpression, response], [typeof(ValueType)], false);

        public override HttpResponseApi GetRawResponse()
            => new AzureResponseProvider(GetRawResponseExpression());

        private ScopedApi<Response> GetRawResponseExpression()
            => Original.Invoke(nameof(ClientResponseApi.GetRawResponse)).As<Response>();
    }
}
