// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Models;

/// <summary>
/// Represents a parsed ARM resource type pattern (e.g., "Microsoft.Compute/virtualMachines").
/// Uses <see cref="RequestPathSegment"/> for each component since type segments may contain
/// variables (e.g., "{parentResourceType}").
/// </summary>
internal class ResourceTypePattern : IEquatable<ResourceTypePattern>
{
    /// <summary> The provider namespace segment (e.g., "Microsoft.Compute"). </summary>
    public RequestPathSegment ProviderNamespace { get; }

    /// <summary> The resource type segments after the namespace (e.g., ["virtualMachines", "extensions"]). </summary>
    public IReadOnlyList<RequestPathSegment> TypeSegments { get; }

    public ResourceTypePattern(RequestPathSegment providerNamespace, IReadOnlyList<RequestPathSegment> typeSegments)
    {
        ProviderNamespace = providerNamespace;
        TypeSegments = typeSegments;
    }

    /// <summary> True if the provider namespace and all type segments are constant (no variables). </summary>
    public bool IsConstant => ProviderNamespace.IsConstant && TypeSegments.All(s => s.IsConstant);

    /// <summary>
    /// Extracts the ARM resource type from a sequence of path segments.
    /// Finds the last "providers" segment, then takes namespace + type segments at odd indices.
    /// Falls back to well-known patterns (subscriptions, resourceGroups, tenants) if no providers segment found.
    /// Returns null if the resource type cannot be determined.
    /// </summary>
    internal static ResourceTypePattern? FromSegments(IReadOnlyList<RequestPathSegment> segments)
    {
        // Find the last "providers" segment index
        int lastProvidersIndex = -1;
        for (int i = 0; i < segments.Count; i++)
        {
            if (segments[i].IsProvidersSegment)
            {
                lastProvidersIndex = i;
            }
        }

        if (lastProvidersIndex >= 0 && lastProvidersIndex + 1 < segments.Count)
        {
            var afterProviders = segments.Skip(lastProvidersIndex + 1).ToList();
            if (afterProviders.Count == 0)
                return null;

            var ns = afterProviders[0];
            var typeSegs = new List<RequestPathSegment>();
            for (int i = 1; i < afterProviders.Count; i += 2)
            {
                typeSegs.Add(afterProviders[i]);
            }

            if (typeSegs.Count > 0)
            {
                return new ResourceTypePattern(ns, typeSegs);
            }
        }

        // Well-known patterns when no providers segment found
        if (segments.Count >= 2 && segments[0].IsConstant)
        {
            if (segments[0].Value.Equals("subscriptions", StringComparison.OrdinalIgnoreCase))
            {
                if (segments.Count >= 4 && segments[2].IsConstant &&
                    segments[2].Value.Equals("resourceGroups", StringComparison.OrdinalIgnoreCase))
                {
                    return new ResourceTypePattern(
                        new RequestPathSegment("Microsoft.Resources"),
                        [new RequestPathSegment("resourceGroups")]);
                }
                return new ResourceTypePattern(
                    new RequestPathSegment("Microsoft.Resources"),
                    [new RequestPathSegment("subscriptions")]);
            }
            if (segments[0].Value.Equals("tenants", StringComparison.OrdinalIgnoreCase))
            {
                return new ResourceTypePattern(
                    new RequestPathSegment("Microsoft.Resources"),
                    [new RequestPathSegment("tenants")]);
            }
        }

        return null;
    }

    /// <summary>
    /// Returns the full resource type string (e.g., "Microsoft.Compute/virtualMachines").
    /// </summary>
    public override string ToString() => $"{ProviderNamespace}/{string.Join("/", TypeSegments)}";

    public bool Equals(ResourceTypePattern? other)
    {
        if (other is null) return false;
        if (!ProviderNamespace.Equals(other.ProviderNamespace)) return false;
        if (TypeSegments.Count != other.TypeSegments.Count) return false;
        for (int i = 0; i < TypeSegments.Count; i++)
        {
            if (!TypeSegments[i].Equals(other.TypeSegments[i]))
                return false;
        }
        return true;
    }

    public override bool Equals(object? obj) => obj is ResourceTypePattern other && Equals(other);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(ProviderNamespace);
        foreach (var segment in TypeSegments)
        {
            hash.Add(segment);
        }
        return hash.ToHashCode();
    }

    public static bool operator ==(ResourceTypePattern? left, ResourceTypePattern? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    public static bool operator !=(ResourceTypePattern? left, ResourceTypePattern? right) => !(left == right);

    public static implicit operator string(ResourceTypePattern resourceType) => resourceType.ToString();
}
