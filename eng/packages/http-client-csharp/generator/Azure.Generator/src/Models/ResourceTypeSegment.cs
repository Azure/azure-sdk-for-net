// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Models
{
    /// <summary>
    /// A <see cref="ResourceTypeSegment"/> represents the resource type that derives from a <see cref="RequestPath"/>. It can contain variables in it.
    /// </summary>
    internal struct ResourceTypeSegment : IEquatable<ResourceTypeSegment>, IReadOnlyList<Segment>
    {
        public static readonly ResourceTypeSegment Scope = new(Array.Empty<Segment>());

        public static readonly ResourceTypeSegment Any = new(new[] { new Segment("*") });

        /// <summary>
        /// The <see cref="ResourceTypeSegment"/> of the resource group resource
        /// </summary>
        public static readonly ResourceTypeSegment ResourceGroup = new(new[] {
            new Segment("Microsoft.Resources"),
            new Segment("resourceGroups")
        });

        /// <summary>
        /// The <see cref="ResourceTypeSegment"/> of the subscription resource
        /// </summary>
        public static readonly ResourceTypeSegment Subscription = new(new[] {
            new Segment("Microsoft.Resources"),
            new Segment("subscriptions")
        });

        /// <summary>
        /// The <see cref="ResourceTypeSegment"/> of the tenant resource
        /// </summary>
        public static readonly ResourceTypeSegment Tenant = new(new Segment[] {
            new Segment("Microsoft.Resources"),
            new Segment("tenants")
        });

        /// <summary>
        /// The <see cref="ResourceTypeSegment"/> of the management group resource
        /// </summary>
        public static readonly ResourceTypeSegment ManagementGroup = new(new[] {
            new Segment("Microsoft.Management"),
            new Segment("managementGroups")
        });

        private IReadOnlyList<Segment> _segments;

        public static ResourceTypeSegment ParseRequestPath(RequestPath path)
        {
            // first try our built-in resources
            if (path == RequestPath.Subscription)
                return ResourceTypeSegment.Subscription;
            if (path == RequestPath.ResourceGroup)
                return ResourceTypeSegment.ResourceGroup;
            if (path == RequestPath.ManagementGroup)
                return ResourceTypeSegment.ManagementGroup;
            if (path == RequestPath.Tenant)
                return ResourceTypeSegment.Tenant;
            if (path == RequestPath.Any)
                return ResourceTypeSegment.Any;

            return Parse(path);
        }

        public ResourceTypeSegment(string path)
            : this(path.Split('/', StringSplitOptions.RemoveEmptyEntries).Select(segment => new Segment(segment)).ToList())
        {
        }

        private ResourceTypeSegment(IReadOnlyList<Segment> segments)
        {
            _segments = segments;
            SerializedType = Segment.BuildSerializedSegments(segments, false);
            IsConstant = _segments.All(segment => segment.IsConstant);
        }

        private static ResourceTypeSegment Parse(RequestPath path)
        {
            var segment = new List<Segment>();
            // find providers
            var paths = path.ToList();
            int index = paths.LastIndexOf(Segment.Providers);
            if (index < 0 || index == paths.Count - 1)
            {
                if (path.SerializedPath.StartsWith(RequestPath.ResourceGroupScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                    return ResourceTypeSegment.ResourceGroup;
                if (path.SerializedPath.StartsWith(RequestPath.SubscriptionScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                    return ResourceTypeSegment.Subscription;
                if (path.SerializedPath.Equals(RequestPath.TenantScopePrefix))
                    return ResourceTypeSegment.Tenant;

                // TODO: better error handling
                throw new InvalidOperationException($"Could not set ResourceTypeSegment for request path {path}. No {Segment.Providers} string found in the URI. Please assign a valid resource type in `request-path-to-resource-type` configuration");
            }
            segment.Add(path[index + 1]);
            segment.AddRange(path.Skip(index + 1).Where((_, index) => index % 2 != 0));

            return new ResourceTypeSegment(segment);
        }

        /// <summary>
        /// Returns true if every <see cref="Segment"/> in this <see cref="ResourceTypeSegment"/> is constant
        /// </summary>
        public bool IsConstant { get; }

        public string SerializedType { get; }

        public Segment Namespace => this[0];

        public IEnumerable<Segment> Types => _segments.Skip(1);

        public Segment this[int index] => _segments[index];

        public int Count => _segments.Count;

        public bool Equals(ResourceTypeSegment other) => SerializedType.Equals(other.SerializedType, StringComparison.InvariantCultureIgnoreCase);

        public IEnumerator<Segment> GetEnumerator() => _segments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _segments.GetEnumerator();

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var other = (ResourceTypeSegment)obj;
            return other.Equals(this);
        }

        public override int GetHashCode() => SerializedType.GetHashCode();

        public override string? ToString() => SerializedType;

        public static bool operator ==(ResourceTypeSegment left, ResourceTypeSegment right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ResourceTypeSegment left, ResourceTypeSegment right)
        {
            return !(left == right);
        }

        internal bool DoesMatch(ResourceTypeSegment other)
        {
            if (Count == 0)
                return other.Count == 0;

            if (Count != other.Count)
                return false;

            if (this[Count - 1].IsConstant == other[Count - 1].IsConstant)
                return this.Equals(other);

            return DoAllButLastItemMatch(other); //TODO: limit matching to the enum values
        }

        private bool DoAllButLastItemMatch(ResourceTypeSegment other)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                if (!this[i].Equals(other[i]))
                    return false;
            }
            return true;
        }
    }
}
