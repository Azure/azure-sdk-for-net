// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Canonical Representation of a Resource Identity
    /// </summary>
    public sealed class ResourceIdentifier :
        IEquatable<ResourceIdentifier>,
        IEquatable<string>,
        IComparable<string>,
        IComparable<ResourceIdentifier>
    {
        private readonly IDictionary<string, string> _partsDictionary =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentifier"/> class.
        /// </summary>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        public ResourceIdentifier(string id)
        {
            Id = id;
            Parse(id);
        }

        /// <summary>
        /// Gets the Resource ID.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the Resource Name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the Resource Type.
        /// </summary>
        public ResourceType Type { get; private set; }

        /// <summary>
        /// Gets the Subscription.
        /// </summary>
        public string Subscription => _partsDictionary.ContainsKey(KnownKeys.Subscription)
            ? _partsDictionary[KnownKeys.Subscription]
            : null;

        /// <summary>
        /// Gets the Resource Group.
        /// </summary>
        public string ResourceGroup => _partsDictionary.ContainsKey(KnownKeys.ResourceGroup)
            ? _partsDictionary[KnownKeys.ResourceGroup]
            : null;

        /// <summary>
        /// Gets the Parent.
        /// Currently this will contain the identifier for either the parent resource, the resource group, the location, the subscription, or the tenant that is the logical parent of this resource.
        /// </summary>
        public ResourceIdentifier Parent { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentifier"/> class from a string.
        /// </summary>
        /// <param name="other"> String to be implicit converted into a <see cref="ResourceIdentifier"/> object. </param>
        public static implicit operator ResourceIdentifier(string other)
        {
            return new ResourceIdentifier(other); // will null check in PR #119
        }

        /// <summary>
        /// Creates a new string from  a <see cref="ResourceIdentifier"/> object.
        /// </summary>
        /// <param name="other"> <see cref="ResourceIdentifier"/> object to be implicit converted into an string. </param>
        public static implicit operator string(ResourceIdentifier other)
        {
            return other.Id;
        }

        /// <summary>
        /// Allow static, safe comparisons of resource identifier strings or objects.
        /// </summary>
        /// <param name="x"> A resource id. </param>
        /// <param name="y"> Another resource id. </param>
        /// <returns> True if the resource ids are equivalent, otherwise False. </returns>
        public static bool Equals(ResourceIdentifier x, ResourceIdentifier y)
        {
            if (null == x && null == y)
                return true;

            if (null == x || null == y)
                return false;

            return x.Equals(y);
        }

        /// <summary>
        /// Allow static null-safe comparisons between resource identifier strings or objects.
        /// </summary>
        /// <param name="x"> A resource id. </param>
        /// <param name="y"> Another resource id. </param>
        /// <returns> -1 if x &lt; y, 0 if x == y, 1 if x &gt; y. </returns>
        public static int CompareTo(ResourceIdentifier x, ResourceIdentifier y)
        {
            if (null == x && null == y)
                return 0;

            if (null == x)
                return -1;

            if (null == y)
                return 1;

            return x.CompareTo(y);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Id;
        }

        /// <summary>
        /// Compares this <see cref="ResourceIdentifier"/> instance ID with another instance's ID.
        /// </summary>
        /// <param name="other"> <see cref="ResourceIdentifier"/> object to compare. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(ResourceIdentifier other)
        {
            return string.Compare(
                Id?.ToLowerInvariant(),
                other?.Id?.ToLowerInvariant(),
                StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Compares this <see cref="ResourceIdentifier"/> instance ID with another plain text ID.
        /// </summary>
        /// <param name="other"> The ID to compare. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(string other)
        {
            return string.Compare(
                Id?.ToLowerInvariant(),
                other?.ToLowerInvariant(),
                StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Compares this <see cref="ResourceIdentifier"/> instance ID with another <see cref="ResourceIdentifier"/> instance's ID and determines if they are equals.
        /// </summary>
        /// <param name="other"> <see cref="ResourceIdentifier"/> object to compare. </param>
        /// <returns> True if they are equals, otherwise false. </returns>
        public bool Equals(ResourceIdentifier other)
        {
            return string.Equals(
                Id?.ToLowerInvariant(),
                other?.Id?.ToLowerInvariant(),
                StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Compares this <see cref="ResourceIdentifier"/> instance ID with another plain text ID. and determines if they are equals.
        /// </summary>
        /// <param name="other"> <see cref="ResourceIdentifier"/> The ID to compare. </param>
        /// <returns> True if they are equals, otherwise false. </returns>
        public bool Equals(string other)
        {
            return string.Equals(
                Id?.ToLowerInvariant(),
                other?.ToLowerInvariant(),
                StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Populate Resource Identity fields from input string.
        /// </summary>
        /// <param name="id"> A properly formed resource identity. </param>
        private void Parse(string id)
        {
            // Throw for null, empty, and string without the correct form
            if (string.IsNullOrWhiteSpace(id) || !id.Contains('/'))
                throw new ArgumentOutOfRangeException($"'{id}' is not a valid resource");

            // Resource ID paths consist mainly of name/value pairs. Split the uri so we have an array of name/value pairs
            var parts = id.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            // There must be at least one name/value pair for the resource id to be valid
            if (parts.Count < 2)
                throw new ArgumentOutOfRangeException($"'{id}' is not a valid resource");

            // This is asserting that resources must start with '/subscriptions', /tenants, or /locations.
            // TODO: we will need to update this code to accomodate tenant based resources (which start with /providers)
            if (!(KnownKeys.Subscription.Equals(parts[0], StringComparison.InvariantCultureIgnoreCase) ||
                  KnownKeys.Tenant.Equals(parts[0], StringComparison.InvariantCultureIgnoreCase) ||
                  KnownKeys.Location.Equals(parts[0], StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ArgumentOutOfRangeException($"'{id}' is not a valid resource");
            }

            Type = new ResourceType(id);

            // In the case that this resource is a singleton proxy resource, the number of parts will be odd,
            // where the last part is the type name of the singleton
            if (parts.Count % 2 != 0)
            {
                _partsDictionary.Add(KnownKeys.UntrackedSubResource, parts.Last());
                parts.RemoveAt(parts.Count - 1);
            }

            // This spplits into resource that come from a provider (which have the providers keyword) and
            // resources that are built in to ARM (e.g. /subscriptions/{sub}, /subscriptions/{sub}/resourceGroups/{rg})
            // TODO: This code will need to be updates for extension resources, which have two providers
            if (id.ToLowerInvariant().Contains("providers"))
            {
                ParseProviderResource(parts);
            }
            else
            {
                ParseGenericResource(parts);
            }
        }

        /// <summary>
        /// Helper method to parse a built in resource.
        /// </summary>
        /// <param name="parts"> Resource ID paths consisting of name/value pairs. </param>
        private void ParseGenericResource(IList<string> parts)
        {
            Debug.Assert(parts != null, "Parts parameter is null.");
            Debug.Assert(parts.Count > 1, "Parts should be a list containing more than 1 elements.");

            // The resource consists of well-known name-value pairs.  Make a resource dictionary
            // using the names as keys, and the values as values
            for (var i = 0; i < parts.Count - 1; i += 2)
            {
                _partsDictionary.Add(parts[i], parts[i + 1]);
            }

            // resource name is always the last part
            Name = parts.Last();
            parts.RemoveAt(parts.Count - 1);
            parts.RemoveAt(parts.Count - 1);

            // remove the last key/value pair to arrive at the parent (Count will be zero for /subscriptions/{foo})
            Parent = parts.Count > 1 ? new ResourceIdentifier($"/{string.Join("/", parts)}") : null;
        }

        /// <summary>
        /// Helper method to parse a resource that comes from a provider.
        /// </summary>
        /// <param name="parts"> Resource ID paths consisting of name/value pairs. </param>
        private void ParseProviderResource(IList<string> parts)
        {
            // The resource consists of name/value pairs, make a dictionary out of it
            for (var i = 0; i < parts.Count - 1; i += 2)
            {
                _partsDictionary[parts[i]] = parts[i + 1];
            }

            Name = parts.Last();
            parts.RemoveAt(parts.Count - 1);

            // remove the type name (there will be no typename if this is a singleton sub resource)
            if (parts.Count % 2 == 1)
                parts.RemoveAt(parts.Count - 1);

            // If this is a top-level resource, remove the providers/Namespace pair, otherwise continue
            if (parts.Count > 2 && string.Equals(parts[parts.Count - 2], KnownKeys.ProviderNamespace))
            {
                parts.RemoveAt(parts.Count - 1);
                parts.RemoveAt(parts.Count - 1);
            }

            // If this is not a top-level resource, it will have a parent
            Parent = parts.Count > 1 ? new ResourceIdentifier($"/{string.Join("/", parts)}") : null;
        }
    }
}
