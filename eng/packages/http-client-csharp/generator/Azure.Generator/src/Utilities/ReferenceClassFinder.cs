// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Microsoft.Generator.CSharp.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Azure.Generator.Utilities
{
    internal class ReferenceClassFinder
    {
        public const string PropertyReferenceTypeAttributeName = "PropertyReferenceTypeAttribute";
        public const string TypeReferenceTypeAttributeName = "TypeReferenceTypeAttribute";

        private static readonly Dictionary<Type, Dictionary<string, PropertyMetadata>> _referenceTypesPropertyMetadata = new()
        {
            [typeof(ResourceData)] = new()
            {
                ["Id"] = new PropertyMetadata("id", true),
                ["Name"] = new PropertyMetadata("name", true),
                ["ResourceType"] = new PropertyMetadata("type", true),
                ["SystemData"] = new PropertyMetadata("systemData", false),
            },
            [typeof(TrackedResourceData)] = new()
            {
                ["Id"] = new PropertyMetadata("id", true),
                ["Name"] = new PropertyMetadata("name", true),
                ["ResourceType"] = new PropertyMetadata("type", true),
                ["SystemData"] = new PropertyMetadata("systemData", false),
                ["Location"] = new PropertyMetadata("location", true),
                ["Tags"] = new PropertyMetadata("tags"),
            },
            [typeof(ManagedServiceIdentity)] = new()
            {
                ["PrincipalId"] = new PropertyMetadata("principalId"),
                ["TenantId"] = new PropertyMetadata("tenantId"),
                ["ManagedServiceIdentityType"] = new PropertyMetadata("type", true),
                ["UserAssignedIdentities"] = new PropertyMetadata("userAssignedIdentities"),
            },
            [typeof(SystemData)] = new()
            {
                ["CreatedBy"] = new PropertyMetadata("createdBy"),
                ["CreatedByType"] = new PropertyMetadata("createdByType"),
                ["CreatedOn"] = new PropertyMetadata("createdAt"),
                ["LastModifiedBy"] = new PropertyMetadata("lastModifiedBy"),
                ["LastModifiedByType"] = new PropertyMetadata("lastModifiedByType"),
                ["LastModifiedOn"] = new PropertyMetadata("lastModifiedAt")
            },
            [typeof(ResponseError)] = new()
            {
                ["Code"] = new PropertyMetadata("code", true),
                ["Message"] = new PropertyMetadata("message", true),
                ["Target"] = new PropertyMetadata("target"),
                ["Details"] = new PropertyMetadata("details")
            },
            //[typeof(DataFactoryLinkedServiceReference)] = new()
            //{
            //    [nameof(DataFactoryLinkedServiceReference.ReferenceKind)] = new PropertyMetadata("type", true),
            //    [nameof(DataFactoryLinkedServiceReference.ReferenceName)] = new PropertyMetadata("referenceName", true),
            //    [nameof(DataFactoryLinkedServiceReference.Parameters)] = new PropertyMetadata("parameters")
            //}
        };

        private Lazy<IReadOnlyList<Type>> _externalTypes;

        public ReferenceClassFinder()
        {
            _externalTypes = new Lazy<IReadOnlyList<Type>>(GetExternalTypes);
            TypeReferenceTypes = new Lazy<IReadOnlyList<Type>>(() => _externalTypes.Value.Where(IsTypeReferenceType).ToList());
        }

        private IReadOnlyList<Type> GetExternalTypes()
        {
            List<Type> types = new List<Type>();
            var assembly = Assembly.GetAssembly(typeof(ArmClient));
            if (assembly != null)
                types.AddRange(assembly.GetTypes());

            assembly = Assembly.GetAssembly(typeof(Operation));
            if (assembly != null)
                types.AddRange(assembly.GetTypes());

            // TODO: handle DFE
            //if (Configuration.UseCoreDataFactoryReplacements)
            //{
            //    assembly = Assembly.GetAssembly(typeof(DataFactoryElement<>));
            //    if (assembly != null)
            //        types.AddRange(assembly.GetTypes());
            //}

            return types;
        }

        public static bool TryGetPropertyMetadata(Type type, [MaybeNullWhen(false)] out Dictionary<string, PropertyMetadata> dict)
        {
            dict = null;
            if (_referenceTypesPropertyMetadata.TryGetValue(type, out dict))
                return dict != null;

            if (TryConstructPropertyMetadata(type, out dict))
            {
                _referenceTypesPropertyMetadata.Add(type, dict);
                return true;
            }

            return false;
        }

        private static bool TryConstructPropertyMetadata(Type type, [MaybeNullWhen(false)] out Dictionary<string, PropertyMetadata> dict)
        {
            var publicCtor = type.GetConstructors().Where(c => c.IsPublic).OrderBy(c => c.GetParameters().Count()).FirstOrDefault();
            if (publicCtor == null && !type.IsAbstract)
            {
                dict = null;
                return false;
            }
            dict = new Dictionary<string, PropertyMetadata>();
            var internalPropertiesToInclude = new List<PropertyInfo>();
            PropertyMatchDetection.AddInternalIncludes(type, internalPropertiesToInclude);
            foreach (var property in type.GetProperties().Where(p => p.DeclaringType == type).Concat(internalPropertiesToInclude))
            {
                var metadata = new PropertyMetadata(property.Name.ToVariableName(), publicCtor != null && GetRequired(publicCtor, property));
                dict.Add(property.Name, metadata);
            }
            return true;
        }

        private static bool GetRequired(ConstructorInfo publicCtor, PropertyInfo property)
            => publicCtor.GetParameters().Any(param => param.Name?.Equals(property.Name, StringComparison.OrdinalIgnoreCase) == true && param.GetType() == property.GetType());


        public Lazy<IReadOnlyList<Type>> TypeReferenceTypes { get; }

        private static bool IsTypeReferenceType(Type type) => HasAttribute(type, TypeReferenceTypeAttributeName);
        private static bool HasAttribute(Type type, string attributeName)
            => type.GetCustomAttributes(false).Where(a => a.GetType().Name == attributeName).Any();

        public record PropertyMetadata(string SerializedName, bool Required)
        {
            public PropertyMetadata(string serializedName) : this(serializedName, false)
            {
            }
        }
    }
}
