// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;

namespace Azure.Generator.Management.Visitors;

internal class ResourceVisitor : ScmLibraryVisitor
{
    // Name, namespace, and relative file path for resource data models are handled at construction
    // time by ResourceDataModelProvider (see ManagementTypeFactory.CreateModelCore). What remains
    // for the visitor is fixing the *serialization* providers' file paths and re-asserting the
    // namespace after Azure.Generator's NamespaceVisitor runs.
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
