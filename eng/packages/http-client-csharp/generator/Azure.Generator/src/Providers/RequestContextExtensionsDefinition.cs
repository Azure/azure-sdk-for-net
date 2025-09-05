// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.IO;
using System.Threading;
using Azure.Generator.Primitives;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

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
            var signature = new MethodSignature(
                "Parse",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                new CSharpType(typeof((CancellationToken, ErrorOptions))),
                null,
                [KnownAzureParameters.RequestContext]);

            var method = new MethodProvider(signature, new MethodBodyStatement[]
            {
                new IfStatement(KnownAzureParameters.RequestContext.Equal(Null))
                {
                    Return(new TupleExpression(Static<CancellationToken>().Property(nameof(CancellationToken.None)), Static<ErrorOptions>().Property(nameof(ErrorOptions.Default))))
                },
                Return(new TupleExpression(KnownAzureParameters.RequestContext.Property(nameof(RequestContext.CancellationToken)), KnownAzureParameters.RequestContext.Property(nameof(RequestContext.ErrorOptions))))
            }, this);
            return method;
        }
    }
}
