// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Microsoft.TypeSpec.Generator.AspNetServer.Providers
{
    /// <summary>
    /// A placeholder type provider that emits a single static class so we can
    /// verify the generator pipeline end-to-end. Will be removed once real
    /// providers (controllers, models, version registry) come online.
    /// </summary>
    internal sealed class HelloWorldProvider : TypeProvider
    {
        protected override string BuildName() => "HelloWorld";

        protected override string BuildRelativeFilePath() =>
            Path.Combine("src", "Generated", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
            TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static | TypeSignatureModifiers.Class;

        protected override MethodProvider[] BuildMethods()
        {
            var signature = new MethodSignature(
                Name: "Greet",
                Description: $"Returns a greeting from the ASP.NET server code generator.",
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                ReturnType: typeof(string),
                ReturnDescription: $"A friendly greeting.",
                Parameters: []);

            var body = new MethodBodyStatement[]
            {
                Return(Literal("Hello from AspNetServerCodeModelGenerator."))
            };

            return [new MethodProvider(signature, body, this)];
        }
    }
}
