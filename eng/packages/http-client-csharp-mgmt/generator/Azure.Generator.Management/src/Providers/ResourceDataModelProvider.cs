// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.IO;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// ModelProvider used for Azure resource data classes.
    /// </summary>
    /// <remarks>
    /// Overrides identity-shaping members (<see cref="BuildName"/>, <see cref="BuildNamespace"/>,
    /// <see cref="BuildRelativeFilePath"/>) so that resource data classes are constructed with the
    /// final name, namespace, and file path from the very first <c>Type</c> access.
    /// <para>
    /// In particular, overriding <see cref="BuildName"/> to append <c>"Data"</c> is the only way to
    /// prevent a user's resource-client customization partial (e.g.
    /// <c>partial class FooResource : ArmResource</c>) from polluting <c>CustomCodeView.BaseType</c>:
    /// once <c>Type</c> is constructed, the base type is captured into the immutable
    /// <c>CSharpType._baseType</c>, and no subsequent visitor-driven rename can rewrite it.
    /// </para>
    /// </remarks>
    internal class ResourceDataModelProvider : ModelProvider
    {
        public ResourceDataModelProvider(InputModelType inputModel)
            : base(inputModel)
        {
            InputModel = inputModel;
        }

        // Preserve the original input model so later visitors can distinguish output-only resource data
        // from input-capable request models after the provider has been converted to a C# type.
        internal InputModelType InputModel { get; }

        protected override string BuildName()
        {
            var name = base.BuildName();
            return name.EndsWith("Data", StringComparison.Ordinal) ? name : $"{name}Data";
        }

        protected override string BuildNamespace()
            => ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", $"{Type.Name}.cs");

        protected override ModelProvider? BuildBaseModelProvider()
        {
            if (CustomCodeView?.BaseType is { } baseType
                && ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(baseType, out var provider)
                && provider is ModelProvider modelProvider)
            {
                return modelProvider;
            }

            return base.BuildBaseModelProvider();
        }
    }
}
