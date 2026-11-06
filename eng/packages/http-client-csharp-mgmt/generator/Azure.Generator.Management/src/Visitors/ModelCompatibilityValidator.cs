// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Linq;

namespace Azure.Generator.Management.Visitors
{
    internal static class ModelCompatibilityValidator
    {
        internal static bool IsPropertyRemovalAccepted(ModelProvider model, PropertyProvider property)
        {
            var baseline = ManagementClientGenerator.Instance.SourceInputModel?.ApiCompatBaseline;
            return baseline is not null
                && (baseline.IsMemberSuppressed(model.Type.FullyQualifiedName, property.Name, 0)
                    || baseline.IsMemberSuppressed(model.Type.FullyQualifiedName, $"get_{property.Name}", 0)
                    || baseline.ReferencesSuppressedType(property.Type));
        }

        internal static bool IsConstructorRemovalAccepted(ModelProvider model, ConstructorSignature signature)
        {
            var baseline = ManagementClientGenerator.Instance.SourceInputModel?.ApiCompatBaseline;
            return baseline is not null
                && (baseline.IsMethodRemovalSuppressed(model.Type.FullyQualifiedName, ".ctor", [.. signature.Parameters.Select(p => p.Type)])
                    || signature.Parameters.Any(p => baseline.ReferencesSuppressedType(p.Type)));
        }
    }
}
