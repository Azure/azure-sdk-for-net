// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.Samples;

internal class ResourceOperationSample
{
    internal ResourceOperationSample(TypeProvider owner, ServiceMethodProvider serviceMethod, InputOperation inputOperation)
    {
    }

    internal MethodProvider ToMethodProvider(TypeProvider enclosingType)
    {
        var signature = new MethodSignature(
            "SampleMethod",
            null,
            MethodSignatureModifiers.Public,
            null,
            null,
            [],
            Attributes: [
                new AttributeStatement(typeof(TestAttribute)),
                new AttributeStatement(typeof(IgnoreAttribute), Literal("Only validating compilation of examples"))
                ]);
        var body = Throw(New.Instance(typeof(NotImplementedException)));

        return new MethodProvider(signature, body, enclosingType);
    }
}
