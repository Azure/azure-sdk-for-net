// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Azure.Generator.Management.Providers
{
    internal class ManagementModelReaderWriterContextDefinition : ModelReaderWriterContextDefinition
    {
        protected override IReadOnlyList<MethodBodyStatement> BuildAttributes()
        {
            var attributes = base.BuildAttributes();
            var existingFrameworkTypes = attributes
                .OfType<AttributeStatement>()
                .Select(GetBuildableFrameworkType)
                .Where(type => type is not null)
                .ToHashSet();
            var missingFrameworkTypes = CollectBaseModelFrameworkTypes()
                .Where(type => !existingFrameworkTypes.Contains(type))
                .OrderBy(type => type.Name)
                .ThenBy(type => type.Namespace)
                .ToArray();

            if (missingFrameworkTypes.Length == 0)
            {
                return attributes;
            }

            // The shared context collector can skip framework types that are only discoverable through
            // a base provider instance already visited by equivalent generated type name.
            // TODO: Remove this workaround after the base generator restores recursive base-model
            // framework type discovery.
            return [
                .. attributes,
                .. missingFrameworkTypes.Select(type => new AttributeStatement(
                    new CSharpType(typeof(ModelReaderWriterBuildableAttribute)),
                    [Snippet.TypeOf(type)]))
            ];
        }

        private static IEnumerable<Type> CollectBaseModelFrameworkTypes()
        {
            var visitedProviders = new HashSet<TypeProvider>();
            var visitedTypes = new HashSet<Type>();
            var buildableTypes = new HashSet<Type>();

            foreach (var provider in ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ModelProvider>())
            {
                if (provider.BaseModelProvider is not null)
                {
                    CollectProviderFrameworkTypes(provider.BaseModelProvider, visitedProviders, visitedTypes, buildableTypes);
                }
            }

            return buildableTypes;
        }

        private static void CollectProviderFrameworkTypes(
            TypeProvider provider,
            HashSet<TypeProvider> visitedProviders,
            HashSet<Type> visitedTypes,
            HashSet<Type> buildableTypes)
        {
            if (!visitedProviders.Add(provider))
            {
                return;
            }

            foreach (var property in provider.CanonicalView.Properties)
            {
                CollectFrameworkTypes(property.Type, visitedTypes, buildableTypes);
            }

            foreach (var method in provider.CanonicalView.Methods)
            {
                if (method.Signature.ReturnType is not null)
                {
                    CollectFrameworkTypes(UnwrapReturnType(method.Signature.ReturnType), visitedTypes, buildableTypes);
                }
            }

            if (provider is ModelProvider { BaseModelProvider: not null } modelProvider)
            {
                CollectProviderFrameworkTypes(modelProvider.BaseModelProvider, visitedProviders, visitedTypes, buildableTypes);
            }
            else
            {
                foreach (var implementedType in provider.Implements)
                {
                    CollectFrameworkTypes(implementedType, visitedTypes, buildableTypes);
                }
            }
        }

        private static void CollectFrameworkTypes(
            CSharpType? type,
            HashSet<Type> visitedTypes,
            HashSet<Type> buildableTypes)
        {
            if (type is null)
            {
                return;
            }

            var typeToCheck = type.IsCollection ? type.ElementType : type;
            if (!typeToCheck.IsFrameworkType)
            {
                return;
            }

            CollectFrameworkType(typeToCheck.FrameworkType, visitedTypes, buildableTypes);
        }

        private static void CollectFrameworkType(
            Type frameworkType,
            HashSet<Type> visitedTypes,
            HashSet<Type> buildableTypes)
        {
            if (!visitedTypes.Add(frameworkType) || !ImplementsModelReaderWriter(frameworkType))
            {
                return;
            }

            buildableTypes.Add(frameworkType);
            foreach (var property in frameworkType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var propertyType = property.PropertyType;
                if (!propertyType.IsVisible)
                {
                    continue;
                }

                CollectFrameworkType(
                    propertyType.IsGenericType ? propertyType.GetGenericArguments().Last() : propertyType,
                    visitedTypes,
                    buildableTypes);
            }

            if (frameworkType.BaseType is not null && frameworkType.BaseType != typeof(object))
            {
                CollectFrameworkType(frameworkType.BaseType, visitedTypes, buildableTypes);
            }
        }

        private static CSharpType? UnwrapReturnType(CSharpType returnType)
        {
            var unwrappedType = returnType;
            if (unwrappedType.IsFrameworkType
                && (unwrappedType.FrameworkType == typeof(Task) || unwrappedType.FrameworkType == typeof(ValueTask)))
            {
                if (unwrappedType.Arguments.Count == 0)
                {
                    return null;
                }

                unwrappedType = unwrappedType.Arguments[0];
            }

            return unwrappedType.IsCollection ? unwrappedType.ElementType : unwrappedType;
        }

        private static bool ImplementsModelReaderWriter(Type type)
            => !IsModelReaderWriterInterfaceType(type)
                && type.GetInterfaces().Any(i => i.Name is "IPersistableModel`1" or "IJsonModel`1");

        private static bool IsModelReaderWriterInterfaceType(Type type)
            => type.IsInterface
                && type.IsGenericType
                && type.GetGenericTypeDefinition() is Type genericType
                && (genericType == typeof(IPersistableModel<>) || genericType == typeof(IJsonModel<>));

        private static Type? GetBuildableFrameworkType(AttributeStatement attribute)
            => attribute.Type.IsFrameworkType
                && attribute.Type.FrameworkType == typeof(ModelReaderWriterBuildableAttribute)
                && attribute.Arguments is [TypeOfExpression { Type: { IsFrameworkType: true } buildableType }]
                    ? buildableType.FrameworkType
                    : null;
    }
}
