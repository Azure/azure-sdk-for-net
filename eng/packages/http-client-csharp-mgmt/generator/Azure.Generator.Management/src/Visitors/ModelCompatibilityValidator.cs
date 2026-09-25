// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.EmitterRpc;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Linq;

namespace Azure.Generator.Management.Visitors
{
    internal static class ModelCompatibilityValidator
    {
        // Last contracts can contain only the public leaf, not its former internal wrapper.
        // Validate the final public surface instead of guessing a wire path from the old name.
        internal static void ValidateProperties(ModelProvider model)
        {
            if (model.LastContractView is not { } previous)
            {
                return;
            }

            var currentProperties = PropertyHelpers.GetAllProperties(model);
            foreach (var property in previous.Properties)
            {
                if (!property.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                    || currentProperties.Any(p => p.Name == property.Name && p.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                    || IsPropertyRemovalAccepted(model, property))
                {
                    continue;
                }

                ManagementClientGenerator.Instance.Emitter.ReportDiagnostic("general-error",
                    $"Cannot preserve historical property '{model.Name}.{property.Name}': no corresponding public property exists in the current model. "
                    + "If its wire shape changed, provide a customization with an explicit mapping; the generator cannot infer a lossless mapping.",
                    severity: EmitterDiagnosticSeverity.Error);
            }
        }

        internal static bool IsPropertyRemovalAccepted(ModelProvider model, PropertyProvider property)
        {
            var baseline = ManagementClientGenerator.Instance.SourceInputModel?.ApiCompatBaseline;
            return baseline is not null
                && (baseline.IsMemberSuppressed(model.Type.FullyQualifiedName, property.Name, 0)
                    || baseline.IsMemberSuppressed(model.Type.FullyQualifiedName, $"get_{property.Name}", 0)
                    || baseline.ReferencesSuppressedType(property.Type));
        }
    }
}
