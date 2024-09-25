// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Snippets;
using System;
using System.IO;

namespace Azure.Generator.Providers
{
    internal record AzureResponseProvider : HttpResponseApi
    {
        public AzureResponseProvider(ValueExpression original) : base(typeof(Response), original)
        {
        }

        public override ScopedApi<BinaryData> Content()
            => Original.Property(nameof(Response.Content)).As<BinaryData>();

        public override ScopedApi<Stream> ContentStream()
            => Original.Property(nameof(Response.ContentStream)).As<Stream>();

        public override ScopedApi<bool> IsError()
            => Original.Property(nameof(Response.IsError)).As<bool>();
    }
}
