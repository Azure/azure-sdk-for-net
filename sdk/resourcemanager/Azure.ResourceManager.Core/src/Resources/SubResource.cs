// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the a sub resource of ResourceIdentifier.
    /// </summary>
    public class SubResource : SubResource<ResourceIdentifier>
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="SubResource"/> for mocking.
        /// </summary>
        [InitializationConstructor]
        protected SubResource() { }

        /// <summary> Initializes a new instance of <see cref="SubResource"/>. </summary>
        /// <param name="id"> ARM resource Id. </param>
        [SerializationConstructor]
        public SubResource(string id) : base(id) { }
    }

    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    [ReferenceType]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Types differ by type argument only")]
    public partial class SubResource<TIdentifier> : IEquatable<SubResource<TIdentifier>>, IEquatable<string>,
        IComparable<SubResource<TIdentifier>>, IComparable<string> where TIdentifier : ResourceIdentifier
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="SubResource{TIdentifier}"/> for mocking.
        /// </summary>
        [InitializationConstructor]
        protected SubResource() { }

        /// <summary> Initializes a new instance of <see cref="SubResource{TIdentifier}"/>. </summary>
        /// <param name="id"> ARM resource Id. </param>
        [SerializationConstructor]
        public SubResource(string id)
        {
            Id = ResourceIdentifier.Create(id) as TIdentifier;
        }

        /// <summary>
        /// Gets the ARM resource identifier.
        /// </summary>
        /// <value></value>
        public virtual TIdentifier Id { get; }

        /// <inheritdoc/>
        public int CompareTo(string other)
        {
            return string.Compare(Id, other, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        public int CompareTo(SubResource<TIdentifier> other)
        {
            if (other is null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            return Id.CompareTo(other.Id);
        }

        /// <inheritdoc/>
        public bool Equals(SubResource<TIdentifier> other)
        {
            if (Id is null)
                return false;

            return Id.Equals(other?.Id);
        }

        /// <inheritdoc/>
        public bool Equals(string other)
        {
            if (Id is null)
                return false;

            return Id.Equals(other);
        }
    }
}
