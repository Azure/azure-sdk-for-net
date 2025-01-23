// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using System.IO;
using System.Threading;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal class RequestContextExtensionsDefinition : TypeProvider
    {
        protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;

        protected override string BuildName() => "RequestContextExtensions";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Internal", $"{Name}.cs");

        protected override MethodProvider[] BuildMethods() => [BuildParse()];

        private MethodProvider BuildParse()
        {
            var requestContextParameter = new ParameterProvider("requestContext", $"", typeof(RequestContext));
            var signature = new MethodSignature(
                "Parse",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                new CSharpType(typeof((CancellationToken, ErrorOptions))),
                null,
                [requestContextParameter]);

            var method = new MethodProvider(signature, new MethodBodyStatement[]
            {
                new IfStatement(requestContextParameter.Equal(Null))
                {
                    Return(new TupleExpression(Static<CancellationToken>().Property(nameof(CancellationToken.None)), Static<ErrorOptions>().Property(nameof(ErrorOptions.Default))))
                },
                Return(new TupleExpression(requestContextParameter.Property(nameof(RequestContext.CancellationToken)), requestContextParameter.Property(nameof(RequestContext.ErrorOptions))))
            }, this);
            return method;
        }
    }
}
