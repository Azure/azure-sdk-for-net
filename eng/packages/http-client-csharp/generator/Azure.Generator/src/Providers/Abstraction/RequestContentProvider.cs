// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Snippets;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

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
                Return(Static(typeof(RequestContent)).Invoke(nameof(RequestContent.Create), [argument, Static<ModelSerializationExtensionsDefinition>().Property("WireOptions")]))
            ];

        internal static MethodBodyStatement[] Create(ValueExpression argument, ValueExpression options)
            => [
                Return(Static(typeof(RequestContent)).Invoke(nameof(RequestContent.Create), [argument, options]))
            ];

        internal static MethodBodyStatement[] CreateXml(ValueExpression argument, ValueExpression options, string xmlElementName)
            => [
                Declare("content", typeof(XmlWriterContent), New.Instance(typeof(XmlWriterContent)), out var content),
                content.As<XmlWriterContent>().XmlWriter().Invoke("WriteObjectValue", [argument, options, Literal(xmlElementName)]).Terminate(),
                Return(content)
            ];
    }
}
