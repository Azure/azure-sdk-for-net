// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning.Primitives
{
    /// <summary>
    /// Provisioning-specific view over one or more compatible management resource
    /// metadata entries that should emit as one provisioning resource type.
    /// </summary>
    internal sealed class ProvisioningResourceProjection
    {
        private ProvisioningResourceProjection(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            Metadata = metadata;
            ResourceModel = GetSameResourceModel(metadata);
            ResourceType = GetSameResourceType(metadata);
            ResourceName = GetSameValueOrDefault(metadata.Select(resource => resource.ResourceName), ResourceModel.Name, StringComparer.Ordinal);
            SingletonResourceName = GetSameNullableValueOrDefault(metadata.Select(resource => resource.SingletonResourceName), null, StringComparer.Ordinal);
            ParentResourceId = GetSameNullableValueOrDefault(metadata.Select(resource => resource.ParentResourceId), null);
            NameConstraints = GetSameValueOrDefault(
                metadata.Select(resource => resource.NameConstraints),
                new ArmResourceNameConstraints(null, null, null));
            ResourceIdPatterns = [.. CollectResourceIdPatterns(metadata)];
            ApiVersions = [.. CollectApiVersions(metadata)];
            Methods = [.. CollectMethods(metadata)];
            RbacRoles = [.. CollectRbacRoles(metadata)];
            ReadableScopes = CollectScopes(metadata, IsReadableOperation);
            WritableScopes = CollectScopes(metadata, IsWritableOperation);
        }

        /// <summary>
        /// Gets the raw management resource metadata entries represented by this
        /// provisioning resource projection.
        /// </summary>
        internal IReadOnlyList<ArmResourceMetadata> Metadata { get; }

        /// <summary>
        /// Gets the resource body model shared by all collapsed metadata entries.
        /// </summary>
        internal InputModelType ResourceModel { get; }

        /// <summary>
        /// Gets the generated provisioning resource type name.
        /// </summary>
        internal string ResourceName { get; }

        /// <summary>
        /// Gets the concrete ARM resource type emitted in Bicep.
        /// </summary>
        internal string ResourceType { get; }

        /// <summary>
        /// Gets the fixed singleton resource name when all collapsed metadata
        /// entries agree on the same singleton name; otherwise null.
        /// </summary>
        internal string? SingletonResourceName { get; }

        /// <summary>
        /// Gets the detected structural parent resource ID pattern.
        /// </summary>
        internal RequestPathPattern? ParentResourceId { get; }

        /// <summary>
        /// Gets the resource name constraints when all collapsed metadata entries
        /// agree on the same constraints; otherwise conservative defaults.
        /// </summary>
        internal ArmResourceNameConstraints NameConstraints { get; }

        /// <summary>
        /// Gets all ARM resource ID patterns collapsed into this projection.
        /// </summary>
        internal IReadOnlyList<RequestPathPattern> ResourceIdPatterns { get; }

        /// <summary>
        /// Gets all API versions available across the collapsed metadata entries.
        /// </summary>
        internal IReadOnlyList<string> ApiVersions { get; }

        /// <summary>
        /// Gets all resource methods from the collapsed metadata entries.
        /// </summary>
        internal IReadOnlyList<ResourceMethod> Methods { get; }

        /// <summary>
        /// Gets all RBAC roles declared on the collapsed metadata entries.
        /// </summary>
        internal IReadOnlyList<ArmResourceRbacRole> RbacRoles { get; }

        /// <summary>
        /// Gets deployment scopes where the resource can be read.
        /// </summary>
        internal IReadOnlyList<ResourceScope> ReadableScopes { get; }

        /// <summary>
        /// Gets deployment scopes where the resource can be written.
        /// </summary>
        internal IReadOnlyList<ResourceScope> WritableScopes { get; }

        /// <summary>
        /// Gets whether this resource should be emitted as a Bicep extension
        /// resource with a language-level <c>scope</c> relationship.
        /// </summary>
        internal bool IsExtensionResource => WritableScopes.Contains(ResourceScope.Extension);

        internal static IReadOnlyList<ProvisioningResourceProjection> Create(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            var groups = new Dictionary<(string ResourceType, InputModelType ResourceModel), List<ArmResourceMetadata>>();
            var orderedGroups = new List<List<ArmResourceMetadata>>();

            foreach (var resource in metadata)
            {
                var key = (resource.ResourceType, resource.ResourceModel);
                if (!groups.TryGetValue(key, out var group))
                {
                    group = [];
                    groups.Add(key, group);
                    orderedGroups.Add(group);
                }
                group.Add(resource);
            }

            return [.. orderedGroups.Select(group => new ProvisioningResourceProjection(group))];
        }

        private static InputModelType GetSameResourceModel(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            var resourceModel = metadata[0].ResourceModel;
            if (metadata.Any(resource => !ReferenceEquals(resource.ResourceModel, resourceModel)))
            {
                throw new InvalidOperationException("Collapsed provisioning resources must share the same resource model.");
            }
            return resourceModel;
        }

        private static string GetSameResourceType(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            var resourceType = metadata[0].ResourceType;
            if (metadata.Any(resource => !string.Equals(resource.ResourceType, resourceType, StringComparison.Ordinal)))
            {
                throw new InvalidOperationException("Collapsed provisioning resources must share the same resource type.");
            }
            return resourceType;
        }

        private static T GetSameValueOrDefault<T>(IEnumerable<T> values, T defaultValue, IEqualityComparer<T>? comparer = null)
            where T : notnull
        {
            var distinctValues = values.Distinct(comparer).Take(2).ToArray();
            return distinctValues.Length == 1 ? distinctValues[0] : defaultValue;
        }

        private static T? GetSameNullableValueOrDefault<T>(IEnumerable<T?> values, T? defaultValue, IEqualityComparer<T?>? comparer = null)
        {
            var distinctValues = values.Distinct(comparer).Take(2).ToArray();
            return distinctValues.Length == 1 ? distinctValues[0] : defaultValue;
        }

        private static IEnumerable<RequestPathPattern> CollectResourceIdPatterns(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            var seen = new HashSet<RequestPathPattern>();
            foreach (var resource in metadata)
            {
                if (seen.Add(resource.ResourceIdPattern))
                {
                    yield return resource.ResourceIdPattern;
                }
            }
        }

        private static IEnumerable<string> CollectApiVersions(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            var seen = new HashSet<string>();
            foreach (var resource in metadata)
            {
                foreach (var apiVersion in resource.ApiVersions)
                {
                    if (seen.Add(apiVersion))
                    {
                        yield return apiVersion;
                    }
                }
            }
        }

        private static IEnumerable<ResourceMethod> CollectMethods(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            var seen = new HashSet<ResourceMethod>();
            foreach (var resource in metadata)
            {
                foreach (var method in resource.Methods)
                {
                    if (seen.Add(method))
                    {
                        yield return method;
                    }
                }
            }
        }

        private static IEnumerable<ArmResourceRbacRole> CollectRbacRoles(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            var seen = new HashSet<ArmResourceRbacRole>();
            foreach (var resource in metadata)
            {
                foreach (var role in resource.RbacRoles)
                {
                    if (seen.Add(role))
                    {
                        yield return role;
                    }
                }
            }
        }

        private static IReadOnlyList<ResourceScope> CollectScopes(
            IReadOnlyList<ArmResourceMetadata> metadata,
            Func<ResourceOperationKind, bool> operationSelector)
        {
            var seen = new HashSet<ResourceScope>();
            var scopes = new List<ResourceScope>();
            foreach (var resource in metadata)
            {
                if (resource.Methods.Any(method => operationSelector(method.Kind)) && seen.Add(resource.Scope.Kind))
                {
                    scopes.Add(resource.Scope.Kind);
                }
            }
            return scopes;
        }

        private static bool IsReadableOperation(ResourceOperationKind kind)
            => kind == ResourceOperationKind.Read;

        private static bool IsWritableOperation(ResourceOperationKind kind)
            => kind == ResourceOperationKind.Create || kind == ResourceOperationKind.Update;
    }
}
