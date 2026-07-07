// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            return TryCreateInheritableSystemObjectModelProvider(baseType, [], requireSerializationCapability: true);
        }

        private InputModelType CreateSystemInputModel(
            string name,
            string crossLanguageDefinitionId)
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
                null,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                InputModel.ModelAsStruct,
                new(),
                InputModel.IsDynamicModel);
        }

        private InheritableSystemObjectModelProvider? TryCreateInheritableSystemObjectModelProvider(
            CSharpType systemType,
            HashSet<string> visited,
            bool requireSerializationCapability)
        {
            if (systemType.IsFrameworkType && systemType.FrameworkType == typeof(object))
            {
                return null;
            }

            var key = $"{systemType.Namespace}.{systemType.Name}";
            if (!visited.Add(key))
            {
                return null;
            }

            var typeMap = ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap;
            if (typeMap.TryGetValue(systemType, out var existingProvider) &&
                existingProvider is InheritableSystemObjectModelProvider existingSystemObjectModelProvider)
            {
                return existingSystemObjectModelProvider;
            }

            var referencedType = TryGetReferencedType(systemType);
            if (requireSerializationCapability &&
                (referencedType is null || !HasJsonModelWriteCoreInHierarchy(referencedType, new HashSet<string>(visited))))
            {
                return null;
            }

            var referencedBaseType = referencedType?.BaseType ??
                systemType.BaseType ??
                (referencedType is not null ? TryGetSerializationRootBaseType(referencedType, systemType) : null);
            var baseModelProvider = referencedBaseType is not null
                ? TryCreateInheritableSystemObjectModelProvider(referencedBaseType, new HashSet<string>(visited), requireSerializationCapability: false)
                : null;
            var inputModel = CreateSystemInputModel(
                systemType.Name,
                string.IsNullOrEmpty(systemType.Namespace) ? systemType.Name : $"{systemType.Namespace}.{systemType.Name}");
            var systemObjectModelProvider = new InheritableSystemObjectModelProvider(
                systemType,
                inputModel,
                baseModelProvider,
                referencedType?.Properties);
            typeMap[systemType] = systemObjectModelProvider;
            typeMap[systemObjectModelProvider.Type] = systemObjectModelProvider;
            if (systemType.IsFrameworkType)
            {
                typeMap[new CSharpType(systemType.FrameworkType)] = systemObjectModelProvider;
            }
            return systemObjectModelProvider;
        }

        private static TypeProvider? TryGetReferencedType(CSharpType systemType)
        {
            var sourceInputModel = ManagementClientGenerator.Instance.SourceInputModel;
            if (sourceInputModel is null || string.IsNullOrEmpty(systemType.Namespace))
            {
                return null;
            }

            return sourceInputModel.FindForTypeInCustomization(
                systemType.Namespace,
                systemType.Name,
                declaringTypeName: null,
                includeReferencedAssemblies: true);
        }

        private static bool HasJsonModelWriteCoreInHierarchy(TypeProvider typeProvider, HashSet<string> visited)
        {
            if (typeProvider.Methods.Any(method => method.Signature.Name == "JsonModelWriteCore"))
            {
                return true;
            }

            var baseType = typeProvider.BaseType ?? typeProvider.Type.BaseType;
            if (baseType is null)
            {
                return false;
            }

            var key = $"{baseType.Namespace}.{baseType.Name}";
            return visited.Add(key) &&
                TryGetReferencedType(baseType) is { } baseTypeProvider &&
                HasJsonModelWriteCoreInHierarchy(baseTypeProvider, visited);
        }

        private static CSharpType? TryGetSerializationRootBaseType(TypeProvider typeProvider, CSharpType systemType)
        {
            foreach (var method in typeProvider.Methods)
            {
                if (method.Signature.Name is not ("JsonModelCreateCore" or "PersistableModelCreateCore") ||
                    method.Signature.ReturnType is not { } returnType ||
                    returnType.AreNamesEqual(systemType))
                {
                    continue;
                }

                return returnType;
            }

            return null;
        }
    }
}
