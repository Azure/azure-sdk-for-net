// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Provisioning.Utilities;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
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
        /// <summary>The TypeSpec property declaration represented by this provider.</summary>
        public InputModelProperty InputProperty { get; }

        /// <summary>The Bicep serialization path segments for DefineProperty calls.</summary>
        public string[] BicepPath { get; }

        /// <summary>Whether this property is output-only (read-only in Bicep).</summary>
        public bool IsOutput { get; }

        /// <summary>Whether this property should expose a public setter.</summary>
        public bool IsSettable { get; }

        /// <summary>Whether this property is required.</summary>
        public bool IsRequired { get; }

        /// <summary>Optional default value (e.g., for singleton resource names).</summary>
        public string? DefaultValue { get; }

        /// <summary>Optional Bicep literal serialization format.</summary>
        public string? Format { get; }

        /// <summary>
        /// Creates a regular provisioning property. This bypasses input-property initialization in
        /// <see cref="PropertyProvider"/> so provisioning can explicitly control public visibility
        /// and setter behavior while retaining <paramref name="inputProperty"/> for reconciliation.
        /// </summary>
        private ProvisioningPropertyProvider(
            InputModelProperty inputProperty,
            FieldProvider backingField,
            CSharpType type,
            string name,
            MethodPropertyBody body,
            TypeProvider enclosingType,
            string[] bicepPath,
            bool isOutput,
            bool isSettable,
            bool isRequired,
            string? defaultValue,
            string? format,
            PropertyWireInformation? wireInfo)
            : base(
                null,
                MethodSignatureModifiers.Public,
                type,
                name,
                body,
                enclosingType,
                wireInfo: wireInfo)
        {
            InputProperty = inputProperty;
            BackingField = backingField;
            BicepPath = bicepPath;
            IsOutput = isOutput;
            IsSettable = isSettable;
            IsRequired = isRequired;
            DefaultValue = defaultValue;
            Format = format;
        }

        /// <summary>
        /// Creates a discriminator property. Initializing <see cref="PropertyProvider"/> with
        /// <paramref name="inputProperty"/> preserves discriminator metadata before the property is
        /// reshaped as an internal, getter-only <c>BicepValue&lt;string&gt;</c>.
        /// </summary>
        private ProvisioningPropertyProvider(
            InputModelProperty inputProperty,
            FieldProvider backingField,
            CSharpType type,
            string name,
            MethodPropertyBody body,
            TypeProvider enclosingType,
            string[] bicepPath,
            bool isOutput,
            bool isRequired,
            string? defaultValue,
            string? format,
            PropertyWireInformation? wireInfo)
            : base(inputProperty, enclosingType)
        {
            InputProperty = inputProperty;
            Update(
                modifiers: MethodSignatureModifiers.Internal,
                type: type,
                name: name,
                body: body,
                wireInfo: wireInfo);
            BackingField = backingField;
            BicepPath = bicepPath;
            IsOutput = isOutput;
            IsSettable = false;
            IsRequired = isRequired;
            DefaultValue = defaultValue;
            Format = format;
        }

        /// <summary>
        /// Creates a provisioning property with its linked backing field.
        /// This is the single unified implementation used by both model and resource providers.
        /// </summary>
        internal static ProvisioningPropertyProvider Create(
            InputModelProperty inputProperty,
            string resolvedName,
            CSharpType bicepType,
            bool isOutput,
            bool isSettable,
            bool isRequired,
            string[] bicepPath,
            string? defaultValue,
            string? format,
            PropertyWireInformation? wireInfo,
            bool isDiscriminator,
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
            if (!isSettable || isDiscriminator)
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

            return isDiscriminator
                ? new ProvisioningPropertyProvider(
                    inputProperty, field, bicepType, resolvedName, body, enclosingType,
                    bicepPath, isOutput, isRequired, defaultValue, format, wireInfo)
                : new ProvisioningPropertyProvider(
                    inputProperty, field, bicepType, resolvedName, body, enclosingType,
                    bicepPath, isOutput, isSettable, isRequired, defaultValue, format, wireInfo);
        }
    }
}
