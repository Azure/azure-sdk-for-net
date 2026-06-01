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
            // TODO: Revisit parent merging in the parent/scope PR. For now, preserve
            // the previous behavior by using the first detected parent.
            ParentResourceId = metadata[0].ParentResourceId;
            NameConstraints = GetSameValueOrDefault(
                metadata.Select(resource => resource.NameConstraints),
                new ArmResourceNameConstraints(null, null, null));
            ResourceIdPatterns = [.. CollectResourceIdPatterns(metadata)];
            ApiVersions = [.. CollectApiVersions(metadata)];
            Methods = [.. CollectMethods(metadata)];
            RbacRoles = [.. CollectRbacRoles(metadata)];
            ReadableScopes = [.. CollectScopes(metadata, IsReadableOperation)];
            WritableScopes = [.. CollectScopes(metadata, IsWritableOperation)];
        }

        internal IReadOnlyList<ArmResourceMetadata> Metadata { get; }

        internal InputModelType ResourceModel { get; }

        internal string ResourceName { get; }

        internal string ResourceType { get; }

        internal string? SingletonResourceName { get; }

        internal RequestPathPattern? ParentResourceId { get; }

        internal ArmResourceNameConstraints NameConstraints { get; }

        internal IReadOnlyList<RequestPathPattern> ResourceIdPatterns { get; }

        internal IReadOnlyList<string> ApiVersions { get; }

        internal IReadOnlyList<ResourceMethod> Methods { get; }

        internal IReadOnlyList<ArmResourceRbacRole> RbacRoles { get; }

        internal IReadOnlyList<ResourceScope> ReadableScopes { get; }

        internal IReadOnlyList<ResourceScope> WritableScopes { get; }

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
            comparer ??= EqualityComparer<T>.Default;
            using var enumerator = values.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                return defaultValue;
            }

            var first = enumerator.Current;
            while (enumerator.MoveNext())
            {
                if (!comparer.Equals(first, enumerator.Current))
                {
                    return defaultValue;
                }
            }
            return first;
        }

        private static T? GetSameNullableValueOrDefault<T>(IEnumerable<T?> values, T? defaultValue, IEqualityComparer<T?>? comparer = null)
        {
            comparer ??= EqualityComparer<T?>.Default;
            using var enumerator = values.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                return defaultValue;
            }

            var first = enumerator.Current;
            while (enumerator.MoveNext())
            {
                if (!comparer.Equals(first, enumerator.Current))
                {
                    return defaultValue;
                }
            }
            return first;
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

        private static IEnumerable<ResourceScope> CollectScopes(
            IReadOnlyList<ArmResourceMetadata> metadata,
            Func<ResourceOperationKind, bool> operationSelector)
        {
            var seen = new HashSet<ResourceScope>();
            foreach (var resource in metadata)
            {
                foreach (var method in resource.Methods)
                {
                    if (operationSelector(method.Kind) && seen.Add(method.Scope.Kind))
                    {
                        yield return method.Scope.Kind;
                    }
                }
            }
        }

        private static bool IsReadableOperation(ResourceOperationKind kind)
            => kind == ResourceOperationKind.Read;

        private static bool IsWritableOperation(ResourceOperationKind kind)
            => kind == ResourceOperationKind.Create || kind == ResourceOperationKind.Update;
    }
}
