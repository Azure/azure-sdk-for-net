// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Provisioning.Utilities;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Provisioning.Providers
{
    /// <summary>
    /// A PropertyProvider that includes provisioning-specific metadata and sets <see cref="PropertyProvider.BackingField"/>
    /// for BicepValue-based properties with Initialize()/Assign() getter/setter patterns.
    /// Used by both ProvisioningModelProvider and ProvisioningResourceProvider.
    /// </summary>
    internal class ProvisioningPropertyProvider : PropertyProvider
    {
        /// <summary>The Bicep serialization path segments for DefineProperty calls.</summary>
        public string[] BicepPath { get; }

        /// <summary>Whether this property is output-only (read-only in Bicep).</summary>
        public bool IsOutput { get; }

        /// <summary>Whether this property is required.</summary>
        public bool IsRequired { get; }

        /// <summary>Optional default value (e.g., for singleton resource names).</summary>
        public string? DefaultValue { get; }

        private ProvisioningPropertyProvider(
            FieldProvider backingField,
            CSharpType type,
            string name,
            MethodPropertyBody body,
            TypeProvider enclosingType,
            string[] bicepPath,
            bool isOutput,
            bool isRequired,
            string? defaultValue)
            : base(null, MethodSignatureModifiers.Public, type, name, body, enclosingType)
        {
            BackingField = backingField;
            BicepPath = bicepPath;
            IsOutput = isOutput;
            IsRequired = isRequired;
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// Creates a provisioning property with its linked backing field.
        /// This is the single unified implementation used by both model and resource providers.
        /// </summary>
        internal static ProvisioningPropertyProvider Create(
            string resolvedName,
            CSharpType bicepType,
            bool isOutput,
            bool isRequired,
            string[] bicepPath,
            string? defaultValue,
            TypeProvider enclosingType)
        {
            var field = new FieldProvider(
                FieldModifiers.Private,
                bicepType,
                $"_{resolvedName.ToVariableName()}",
                enclosingType);

            MethodBodyStatement[] getter =
            [
                This.Invoke("Initialize").Terminate(),
                Return(field)
            ];

            MethodPropertyBody body;
            if (isOutput)
            {
                body = new MethodPropertyBody(getter);
            }
            else if (BicepTypeHelpers.IsModelType(bicepType))
            {
                MethodBodyStatement[] setter =
                [
                    This.Invoke("Initialize").Terminate(),
                    This.Invoke("AssignOrReplace", new KeywordExpression("ref", field), Value).Terminate()
                ];
                body = new MethodPropertyBody(getter, setter);
            }
            else
            {
                MethodBodyStatement[] setter =
                [
                    This.Invoke("Initialize").Terminate(),
                    field.AsValueExpression.Invoke("Assign", Value).Terminate()
                ];
                body = new MethodPropertyBody(getter, setter);
            }

            return new ProvisioningPropertyProvider(
                field, bicepType, resolvedName, body, enclosingType,
                bicepPath, isOutput, isRequired, defaultValue);
        }
    }
}
