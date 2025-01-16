using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Generator.Utilities;

namespace Azure.Generator.Models
{
    /// <summary>
    /// A <see cref="RequestPath"/> represents a parsed request path in the swagger which corresponds to an operation. For instance, `/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines`
    /// </summary>
    internal readonly struct RequestPath : IEquatable<RequestPath>, IReadOnlyList<Segment>
    {
        private const string _providerPath = "/subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}";
        private const string _featurePath = "/subscriptions/{subscriptionId}/providers/Microsoft.Features/providers/{resourceProviderNamespace}/features";

        internal const string ManagementGroupScopePrefix = "/providers/Microsoft.Management/managementGroups";
        internal const string ResourceGroupScopePrefix = "/subscriptions/{subscriptionId}/resourceGroups";
        internal const string SubscriptionScopePrefix = "/subscriptions";
        internal const string TenantScopePrefix = "/tenants";

        public static readonly RequestPath Empty = new(Array.Empty<Segment>());

        public static readonly RequestPath Null = new(new[] { new Segment("") });

        /// <summary>
        /// This is a placeholder of request path for "any" resources in other RPs
        /// </summary>
        public static readonly RequestPath Any = new(new[] { new Segment("*") });

        /// <summary>
        /// The <see cref="RequestPath"/> of a resource group resource
        /// </summary>
        public static readonly RequestPath ResourceGroup = new(new[] {
        new Segment("subscriptions"),
        new Segment(new Reference("subscriptionId", typeof(string)), true, true),
        new Segment("resourceGroups"),
        new Segment(new Reference("resourceGroupName", typeof(string)), true, false)
    });

        /// <summary>
        /// The <see cref="RequestPath"/> of a subscription resource
        /// </summary>
        public static readonly RequestPath Subscription = new(new[] {
        new Segment("subscriptions"),
        new Segment(new Reference("subscriptionId", typeof(string)), true, true)
    });

        /// <summary>
        /// The <see cref="RequestPath"/> of tenants
        /// </summary>
        public static readonly RequestPath Tenant = new(Enumerable.Empty<Segment>());

        /// <summary>
        /// The <see cref="RequestPath"/> of a management group resource
        /// </summary>
        public static readonly RequestPath ManagementGroup = new(new[] {
        new Segment("providers"),
        new Segment("Microsoft.Management"),
        new Segment("managementGroups"),
        // We use strict = false because we usually see the name of management group is different in different RPs. Some of them are groupId, some of them are groupName, etc
        new Segment(new Reference("managementGroupId", typeof(string)), true, false)
    });

        private static Dictionary<Type, RequestPath>? _extensionChoices;
        public static Dictionary<Type, RequestPath> ExtensionChoices => _extensionChoices ??= new()
        {
            [typeof(TenantResource)] = RequestPath.Tenant,
            [typeof(ManagementGroupResource)] = RequestPath.ManagementGroup,
            [typeof(SubscriptionResource)] = RequestPath.Subscription,
            [typeof(ResourceGroupResource)] = RequestPath.ResourceGroup,
        };

        public static RequestPath GetContextualPath(Type armCoreType)
        {
            return ExtensionChoices[armCoreType];
        }

        private readonly IReadOnlyList<Segment> _segments;

        public static RequestPath FromString(string rawPath)
        {
            var rawSegments = rawPath.Split('/', StringSplitOptions.RemoveEmptyEntries);

            var segments = rawSegments.Select(GetSegmentFromString);

            return new RequestPath(segments);
        }

        public static RequestPath FromSegments(IEnumerable<Segment> segments) => new RequestPath(segments);

        private static Segment GetSegmentFromString(string str)
        {
            var trimmed = TrimRawSegment(str);
            var isScope = trimmed == "scope";
            return new Segment(trimmed, escape: !isScope, isConstant: !isScope && !str.Contains('{'));
        }

        private static string TrimRawSegment(string segment) => segment.TrimStart('{').TrimEnd('}');

        public int IndexOfLastProviders { get; }

        private RequestPath(IReadOnlyList<Segment> segments, string httpPath)
        {
            _segments = segments;
            SerializedPath = httpPath;
            IndexOfLastProviders = _segments.ToList().LastIndexOf(Segment.Providers);
        }

        private static IReadOnlyList<Segment> CheckByIdPath(IReadOnlyList<Segment> segments)
        {
            // if this is a byId request path, we need to make it strict, since it might be accidentally to be any scope request path's parent
            if (segments.Count != 1)
                return segments;
            var first = segments.First();
            if (first.IsConstant)
                return segments;
            if (!first.SkipUrlEncoding)
                return segments;

            // this is a ById request path
            return new List<Segment> { new(first.Reference, first.Escape, true) };
        }

        public bool IsById => Count == 1 && this.First().SkipUrlEncoding;

        /// <summary>
        /// Constructs the <see cref="RequestPath"/> instance using a collection of <see cref="Segment"/>
        /// This is used for the request path that does not come from the swagger document, or an incomplete request path
        /// </summary>
        /// <param name="segments"></param>
        private RequestPath(IEnumerable<Segment> segments) : this(segments.ToArray(), Segment.BuildSerializedSegments(segments))
        {
        }

        /// <summary>
        /// The raw request path of this <see cref="RequestPath"/> instance
        /// </summary>
        public string SerializedPath { get; }

        private bool IsAncestorOf(RequestPath other)
        {
            // To be the parent of other, you must at least be shorter than other.
            if (other.Count <= Count)
                return false;
            for (int i = 0; i < Count; i++)
            {
                // we need the segment to be identical when strict is true (which is the default value)
                // when strict is false, we also need the segment to be identical if it is constant.
                // but if it is a reference, we only require they have the same type, do not require they have the same variable name.
                // This case happens a lot during the management group parent detection - different RP calls this different things
                if (!this[i].Equals(other[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check if <paramref name="requestPath"/> is a prefix path of <paramref name="candidate"/>
        /// While comparing, we will ignore everything inside {}
        /// For instance, if "/subs/{subsId}/rgs/{name}/foo" and "/subs/{subsId}/rgs/{name}/foo/bar/{something}",
        /// we are effectively comparing /subs/{}/rgs/{}/foo and /subs/{}/rgs/{}/foo/bar/{}
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public static bool IsPrefix(string requestPath, string candidate)
        {
            // Create spans for the candidate and request path
            ReadOnlySpan<char> candidateSpan = candidate.AsSpan();
            ReadOnlySpan<char> requestPathSpan = requestPath.AsSpan();

            int cIdx = 0, rIdx = 0;

            // iterate through everything on request path
            while (rIdx < requestPathSpan.Length)
            {
                // if we run out of candidate, return false because request path here is effectively longer than candidate
                if (cIdx >= candidateSpan.Length)
                    return false;

                // if we hit a {
                char c = candidateSpan[cIdx];
                char r = requestPathSpan[rIdx];

                if (c != r)
                    return false;

                if (c == '{')
                {
                    // they both are {, skip everything until we have a } or we get to the last character of the string
                    while (cIdx < candidateSpan.Length - 1 && candidateSpan[cIdx] != '}')
                        cIdx++;
                    while (rIdx < requestPathSpan.Length - 1 && requestPathSpan[rIdx] != '}')
                        rIdx++;
                }
                else
                {
                    // they are the same but not {
                    cIdx++;
                    rIdx++;
                }
            }

            return true;
        }

        /// <summary>
        /// Trim this from the other and return the <see cref="RequestPath"/> that remain.
        /// The result is "other - this" by removing this as a prefix of other.
        /// If this == other, return empty request path
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">if this.IsAncestorOf(other) is false</exception>
        public RequestPath TrimAncestorFrom(RequestPath other)
        {
            if (TryTrimAncestorFrom(other, out var diff))
                return diff;

            throw new InvalidOperationException($"Request path {this} is not parent of {other}");
        }

        public bool TryTrimAncestorFrom(RequestPath other, [MaybeNullWhen(false)] out RequestPath diff)
        {
            diff = default;
            if (this == other)
            {
                diff = RequestPath.Tenant;
                return true;
            }
            if (this.IsAncestorOf(other))
            {
                diff = new RequestPath(other._segments.Skip(this.Count));
                return true;
            }
            // Handle the special case of trim provider from feature
            else if (this.SerializedPath == _providerPath && other.SerializedPath.StartsWith(_featurePath))
            {
                diff = new RequestPath(other._segments.Skip(this.Count + 2));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Trim the scope out of this request path.
        /// If this is already a scope path, return the empty request path, aka the RequestPath.Tenant
        /// </summary>
        /// <returns></returns>
        public RequestPath TrimScope()
        {
            var scope = this.GetScopePath();
            // The scope for /subscriptions is /subscriptions/{subscriptionId}, we identify such case with scope.Count > this.Count.
            if (scope == this || scope.Count > this.Count)
                return Tenant; // if myself is a scope path, we return the empty path after the trim.
            return scope.TrimAncestorFrom(this);
        }

        public RequestPath Append(RequestPath other)
        {
            return new RequestPath(this._segments.Concat(other._segments));
        }

        public RequestPath ApplyHint(ResourceTypeSegment hint)
        {
            if (hint.Count == 0)
                return this;
            int hintIndex = 0;
            List<Segment> newPath = new List<Segment>();
            int thisIndex = 0;
            for (; thisIndex < _segments.Count; thisIndex++)
            {
                var segment = this[thisIndex];
                if (segment.IsExpandable)
                {
                    newPath.Add(hint[hintIndex]);
                    hintIndex++;
                }
                else
                {
                    if (segment.Equals(hint[hintIndex]))
                    {
                        hintIndex++;
                    }
                    newPath.Add(segment);
                }
                if (hintIndex >= hint.Count)
                {
                    thisIndex++;
                    break;
                }
            }

            //copy remaining items in this
            for (; thisIndex < _segments.Count; thisIndex++)
            {
                newPath.Add(_segments[thisIndex]);
            }
            return new RequestPath(newPath);
        }

        private static ISet<ResourceTypeSegment> GetScopeResourceTypes(RequestPath requestPath)
        {
            var scope = requestPath.GetScopePath();
            if (scope.IsParameterizedScope())
            {
                return new HashSet<ResourceTypeSegment>(requestPath.GetParameterizedScopeResourceTypes()!);
            }

            return new HashSet<ResourceTypeSegment> { scope.GetResourceType() };
        }

        /// <summary>
        /// Return true if the scope resource types of the first path are a subset of the second path
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="resourcePath"></param>
        /// <returns></returns>
        public static bool IsScopeCompatible(RequestPath requestPath, RequestPath resourcePath)
        {
            // get scope types
            var requestScopeTypes = GetScopeResourceTypes(requestPath);
            var resourceScopeTypes = GetScopeResourceTypes(resourcePath);
            if (resourceScopeTypes.Contains(ResourceTypeSegment.Any))
                return true;
            return requestScopeTypes.IsSubsetOf(resourceScopeTypes);
        }

        public int Count => _segments.Count;

        public Segment this[int index] => _segments[index];

        public bool Equals(RequestPath other)
        {
            if (Count != other.Count)
                return false;
            for (int i = 0; i < Count; i++)
            {
                if (!this[i].Equals(other[i]))
                    return false;
            }
            return true;
        }

        public override bool Equals(object? obj) => obj is RequestPath other && Equals(other);

        public IEnumerator<Segment> GetEnumerator() => _segments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _segments.GetEnumerator();

        public override int GetHashCode() => SerializedPath.GetHashCode();

        public override string ToString() => SerializedPath;

        public static bool operator ==(RequestPath left, RequestPath right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RequestPath left, RequestPath right)
        {
            return !(left == right);
        }

        public static implicit operator string(RequestPath requestPath)
        {
            return requestPath.SerializedPath;
        }
    }
}
