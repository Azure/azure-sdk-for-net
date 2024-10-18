// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using System.ClientModel.Primitives;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal record RequestContentProvider : RequestContentApi
    {
        private static RequestContentApi? _instance;
        internal static RequestContentApi Instance => _instance ??= new RequestContentProvider(Empty);

        public RequestContentProvider(ValueExpression original) : base(typeof(RequestContent), original)
        {
        }

        public override CSharpType RequestContentType => typeof(RequestContent);

        public override RequestContentApi FromExpression(ValueExpression original)
            => new RequestContentProvider(original);

        public override RequestContentApi ToExpression() => this;

        public override MethodBodyStatement[] Create(ValueExpression argument)
            => [
                Declare("content", New.Instance<Utf8JsonBinaryContentDefinition>(), out ScopedApi<Utf8JsonBinaryContentDefinition> content),
                content.Property("JsonWriter").Invoke("WriteObjectValue", [argument, Static<ModelSerializationExtensionsDefinition>().Property("WireOptions").As<ModelReaderWriterOptions>()]).Terminate(),
                Return(content)
            ];
    }
}
