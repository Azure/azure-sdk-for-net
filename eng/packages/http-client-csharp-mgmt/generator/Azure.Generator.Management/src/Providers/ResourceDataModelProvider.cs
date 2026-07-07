// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Azure.ResourceManager.Models;
using System;
using System.Collections.Generic;
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
        private static readonly CSharpType _resourceDataType = new(typeof(ResourceData));
        private static readonly CSharpType _trackedResourceDataType = new(typeof(TrackedResourceData));

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
            var baseModelProvider = base.BuildBaseModelProvider();
            if (baseModelProvider is not null)
            {
                return baseModelProvider;
            }

            var baseType = BaseType;
            if (baseType is null)
            {
                return null;
            }

            if (AreSameFrameworkType(baseType, _trackedResourceDataType))
            {
                return CreateTrackedResourceDataProvider();
            }

            if (AreSameFrameworkType(baseType, _resourceDataType))
            {
                return CreateResourceDataProvider();
            }

            return null;
        }

        private SystemObjectModelProvider CreateTrackedResourceDataProvider()
        {
            var resourceDataInput = CreateResourceDataInputModel();
            RegisterSystemObjectModelProvider(_resourceDataType, resourceDataInput);
            var trackedResourceDataInput = CreateSystemInputModel(
                "TrackedResource",
                "Azure.ResourceManager.CommonTypes.TrackedResource",
                resourceDataInput);

            return RegisterSystemObjectModelProvider(_trackedResourceDataType, trackedResourceDataInput);
        }

        private SystemObjectModelProvider CreateResourceDataProvider()
            => RegisterSystemObjectModelProvider(_resourceDataType, CreateResourceDataInputModel());

        private InputModelType CreateResourceDataInputModel()
        {
            return CreateSystemInputModel(
                "Resource",
                "Azure.ResourceManager.CommonTypes.Resource");
        }

        private InputModelType CreateSystemInputModel(
            string name,
            string crossLanguageDefinitionId,
            InputModelType? baseModel = null)
        {
            return new InputModelType(
                name,
                InputModel.Namespace,
                crossLanguageDefinitionId,
                InputModel.Access,
                InputModel.Deprecation,
                InputModel.Summary,
                InputModel.Doc,
                InputModel.Usage,
                [],
                baseModel,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                InputModel.ModelAsStruct,
                new(),
                InputModel.IsDynamicModel);
        }

        private static InheritableSystemObjectModelProvider RegisterSystemObjectModelProvider(CSharpType systemType, InputModelType inputModel)
        {
            var typeMap = ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap;
            if (typeMap.TryGetValue(systemType, out var existingProvider) &&
                existingProvider is InheritableSystemObjectModelProvider existingSystemObjectModelProvider)
            {
                return existingSystemObjectModelProvider;
            }

            var systemObjectModelProvider = new InheritableSystemObjectModelProvider(systemType, inputModel);
            typeMap[systemType] = systemObjectModelProvider;
            if (systemType.IsFrameworkType)
            {
                typeMap[new CSharpType(systemType.FrameworkType)] = systemObjectModelProvider;
            }
            return systemObjectModelProvider;
        }

        private static bool AreSameFrameworkType(CSharpType type, CSharpType frameworkType)
            => type.AreNamesEqual(frameworkType) ||
                (type.IsFrameworkType &&
                 frameworkType.IsFrameworkType &&
                 type.FrameworkType == frameworkType.FrameworkType);
    }
}
