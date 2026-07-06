// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

            var missingFrameworkTypes = CollectFrameworkModelTypesFromResponseBodies()
                .Where(type => !existingFrameworkTypes.Contains(type))
                .OrderBy(type => type.Name)
                .ThenBy(type => type.Namespace)
                .ToArray();

            return missingFrameworkTypes.Length == 0
                ? attributes
                : [
                    .. attributes,
                    .. missingFrameworkTypes.Select(type => new AttributeStatement(
                        new CSharpType(typeof(ModelReaderWriterBuildableAttribute)),
                        [Snippet.TypeOf(type)]))
                ];
        }

        private static IEnumerable<Type> CollectFrameworkModelTypesFromResponseBodies()
        {
            var visitedTypes = new HashSet<Type>();
            var buildableTypes = new HashSet<Type>();

            foreach (var metadata in ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas)
            {
                foreach (var resourceMethod in metadata.Methods)
                {
                    CollectFrameworkModelTypes(resourceMethod.InputMethod, visitedTypes, buildableTypes);
                }
            }

            foreach (var nonResourceMethod in ManagementClientGenerator.Instance.InputLibrary.NonResourceMethods)
            {
                CollectFrameworkModelTypes(nonResourceMethod.InputMethod, visitedTypes, buildableTypes);
            }

            return buildableTypes;
        }

        private static void CollectFrameworkModelTypes(
            InputServiceMethod method,
            HashSet<Type> visitedTypes,
            HashSet<Type> buildableTypes)
        {
            var lroMetadata = method switch
            {
                InputLongRunningServiceMethod lroMethod => lroMethod.LongRunningServiceMetadata,
                InputLongRunningPagingServiceMethod lroPagingMethod => lroPagingMethod.LongRunningServiceMetadata,
                _ => null
            };

            if (lroMetadata?.ReturnType is not null)
            {
                CollectFrameworkModelTypes(lroMetadata.ReturnType, visitedTypes, buildableTypes);
                return;
            }

            if (method.Response.Type is not null)
            {
                CollectFrameworkModelTypes(method.Response.Type, visitedTypes, buildableTypes);
            }
        }

        private static void CollectFrameworkModelTypes(
            InputType inputType,
            HashSet<Type> visitedTypes,
            HashSet<Type> buildableTypes)
        {
            var type = ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(inputType);
            CollectFrameworkModelTypes(type, visitedTypes, buildableTypes);
        }

        private static void CollectFrameworkModelTypes(
            CSharpType? type,
            HashSet<Type> visitedTypes,
            HashSet<Type> buildableTypes)
        {
            if (type is null)
            {
                return;
            }

            foreach (var argument in type.Arguments)
            {
                CollectFrameworkModelTypes(argument, visitedTypes, buildableTypes);
            }

            if (!type.IsFrameworkType)
            {
                return;
            }

            CollectFrameworkModelType(type.FrameworkType, visitedTypes, buildableTypes);
        }

        private static void CollectFrameworkModelType(
            Type frameworkType,
            HashSet<Type> visitedTypes,
            HashSet<Type> buildableTypes)
        {
            if (!visitedTypes.Add(frameworkType))
            {
                return;
            }

            if (ImplementsModelReaderWriter(frameworkType))
            {
                buildableTypes.Add(frameworkType);
            }

            foreach (var property in frameworkType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var propertyType = property.PropertyType;
                if (!propertyType.IsVisible)
                {
                    continue;
                }

                CollectFrameworkModelType(GetElementType(propertyType), visitedTypes, buildableTypes);
            }

            if (frameworkType.BaseType is not null && frameworkType.BaseType != typeof(object))
            {
                CollectFrameworkModelType(frameworkType.BaseType, visitedTypes, buildableTypes);
            }
        }

        private static Type GetElementType(Type type)
        {
            while (type.IsArray)
            {
                type = type.GetElementType()!;
            }

            return type.IsGenericType && type.GetGenericArguments() is { Length: > 0 } arguments
                ? arguments[^1]
                : type;
        }

        private static bool ImplementsModelReaderWriter(Type type)
            => !IsModelReaderWriterInterfaceType(type)
                && !type.IsEnum
                && !type.IsValueType
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
