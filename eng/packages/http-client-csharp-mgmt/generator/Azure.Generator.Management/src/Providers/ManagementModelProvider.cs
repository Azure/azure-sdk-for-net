// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using AzureResourceData = Azure.ResourceManager.Models.ResourceData;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// ModelProvider used for non-resource management-plane models.
    /// </summary>
    internal class ManagementModelProvider : ModelProvider
    {
        public ManagementModelProvider(InputModelType inputModel)
            : base(inputModel)
        {
        }

        // Non-resource management-plane models are emitted under .Models. Build their
        // Type there up front so references cached before namespace visitors run do not
        // keep a stale root namespace.
        protected override string BuildNamespace()
            => $"{ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace}.Models";

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", "Models", $"{Type.Name}.cs");

        protected override ModelProvider? BuildBaseModelProvider()
        {
            if (TryGetCustomSystemBaseModelProvider(CustomCodeView?.BaseType, out var customBaseModelProvider))
            {
                return customBaseModelProvider;
            }

            return base.BuildBaseModelProvider();
        }

        internal static bool TryGetCustomSystemBaseModelProvider(CSharpType? customBaseType, out ModelProvider? customBaseModelProvider)
        {
            customBaseModelProvider = null;
            if (customBaseType is null || !TryGetFrameworkResourceDataType(customBaseType, out var frameworkType))
            {
                return false;
            }

            var typeFactory = ManagementClientGenerator.Instance.TypeFactory;
            var frameworkCSharpType = new CSharpType(frameworkType);
            if (typeFactory.CSharpTypeMap.TryGetValue(frameworkCSharpType, out var existingProvider)
                && existingProvider is ModelProvider existingModelProvider)
            {
                customBaseModelProvider = existingModelProvider;
                return true;
            }

            var systemModelProvider = new SystemObjectModelProvider(frameworkCSharpType, CreateSyntheticSystemInputModel(frameworkType));
            typeFactory.CSharpTypeMap[frameworkCSharpType] = systemModelProvider;
            typeFactory.CSharpTypeMap[customBaseType] = systemModelProvider;
            customBaseModelProvider = systemModelProvider;
            return true;
        }

        private static bool TryGetFrameworkResourceDataType(CSharpType customBaseType, out Type frameworkType)
        {
            if (customBaseType.IsFrameworkType)
            {
                frameworkType = customBaseType.FrameworkType;
            }
            else if (KnownManagementTypes.TryGetFrameworkType(customBaseType.FullyQualifiedName, out var resolvedFrameworkType))
            {
                frameworkType = resolvedFrameworkType;
            }
            else
            {
                frameworkType = typeof(object);
                return false;
            }

            return typeof(AzureResourceData).IsAssignableFrom(frameworkType);
        }

        private static InputModelType CreateSyntheticSystemInputModel(Type frameworkType)
        {
            return new InputModelType(
                frameworkType.Name,
                frameworkType.Namespace ?? string.Empty,
                frameworkType.FullName ?? frameworkType.Name,
                "public",
                null,
                null,
                null,
                InputModelTypeUsage.Input | InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                [],
                null,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);
        }
    }
}
