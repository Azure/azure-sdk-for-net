// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.IO;

namespace Azure.Generator.Management.Visitors;

internal class ResourceVisitor : ScmLibraryVisitor
{
    // ResourceDataModelProvider already applies the initial 'Data' suffix at construction time
    // (which is required to preserve the correct BaseType against custom-code-view collisions).
    // We still need this pass because NameVisitor.PreVisitModel may rename known types
    // (e.g. PrivateEndpointConnection -> {ResourceProviderName}PrivateEndpointConnection) and drop the suffix.
    protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
    {
        if (type is not null && ManagementClientGenerator.Instance.InputLibrary.IsResourceModel(model))
        {
            if (!type.Name.EndsWith("Data", StringComparison.Ordinal))
            {
                type.Update(name: $"{type.Name}Data");
            }
        }
        return type;
    }

    // Re-assert the namespace and fix serialization providers' file paths after Azure.Generator's
    // NamespaceVisitor (which runs in VisitType) has had a chance to override them.
    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (type is not null)
        {
            TransformNamespaceForResource(type);
        }
        return type;
    }

    private void TransformNamespaceForResource(TypeProvider type)
    {
        if (type is ModelProvider model && ManagementClientGenerator.Instance.OutputLibrary.IsResourceModelType(model.Type))
        {
            type.Update(@namespace: ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace);

            foreach (var serialization in type.SerializationProviders)
            {
                serialization.Update(
                    relativeFilePath: Path.Combine("src", "Generated", $"{model.Name}.Serialization.cs"),
                    @namespace: ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace);
            }
        }
    }
}
