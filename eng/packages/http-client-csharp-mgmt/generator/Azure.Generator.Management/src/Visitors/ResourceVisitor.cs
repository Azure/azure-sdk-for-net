// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;

namespace Azure.Generator.Management.Visitors;

internal class ResourceVisitor : ScmLibraryVisitor
{
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
