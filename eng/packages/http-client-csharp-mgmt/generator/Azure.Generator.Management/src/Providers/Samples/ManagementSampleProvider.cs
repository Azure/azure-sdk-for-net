// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.IO;

namespace Azure.Generator.Management.Providers.Samples;

internal class ManagementSampleProvider : TypeProvider
{
    private TypeProvider _owner;
    public ManagementSampleProvider(TypeProvider owner) : base()
    {
        _owner = owner;
    }

    protected override string BuildName() => $"Sample_{_owner.Name}";

    protected override string BuildRelativeFilePath() => Path.Combine("tests", "Generated", "Samples", $"{Name}.cs");

    protected override string BuildNamespace() => $"{_owner.Type.Namespace}.Samples";

    protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Public;

    protected override MethodProvider[] BuildMethods()
    {
        var methods = new List<MethodProvider>();

        foreach (var method in _owner.Methods)
        {
            if (method is ServiceMethodProvider serviceMethod && serviceMethod.Sample != null)
            {
                var sampleMethod = serviceMethod.Sample.ToMethodProvider(this);
                methods.Add(sampleMethod);
            }
        }

        return methods.ToArray();
    }
}
