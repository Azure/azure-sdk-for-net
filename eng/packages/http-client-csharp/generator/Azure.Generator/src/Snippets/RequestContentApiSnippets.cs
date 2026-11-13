// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Snippets
{
    internal static class RequestContentApiSnippets
    {
        private static CSharpType RequestContentType
            => AzureClientGenerator.Instance.TypeFactory.RequestContentApi.RequestContentType;

        public static ScopedApi<RequestContent> Create(ValueExpression content)
            => Static(RequestContentType).Invoke(nameof(RequestContent.Create), content).As<RequestContent>();
    }
}
