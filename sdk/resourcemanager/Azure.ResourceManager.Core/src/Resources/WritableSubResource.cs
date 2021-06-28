// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the a writable sub resource of ResourceIdentifier.
    /// </summary>
    [ReferenceType]
    public class WritableSubResource : WritableSubResource<ResourceIdentifier>
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="WritableSubResource"/> for mocking.
        /// </summary>
        [InitializationConstructor]
        public WritableSubResource() 
        {
        }

        /// <summary> Initializes a new instance of <see cref="WritableSubResource"/>. </summary>
        /// <param name="id"> ARM resource Id. </param>
        [SerializationConstructor]
        protected internal WritableSubResource(string id) : base(id) { }
    }

    /// <summary>
    /// A class representing a sub-resource that contains only the read-only ID.
    /// </summary>
    [ReferenceType(typeof(ResourceIdentifier))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Types differ by type argument only")]
    public partial class WritableSubResource <TIdentifier> : IEquatable<WritableSubResource<TIdentifier>>, IEquatable<string>,
        IComparable<WritableSubResource<TIdentifier>>, IComparable<string> 
        where TIdentifier : ResourceIdentifier
    {
        /// <summary>
        /// Initializes an empty instance of <see cref="WritableSubResource{TIdentifier}"/> for mocking.
        /// </summary>
        [InitializationConstructor]
        public WritableSubResource() 
        { 
        }

        /// <summary> Initializes a new instance of <see cref="WritableSubResource{TIdentifier}"/>. </summary>
        /// <param name="id"> ARM resource Id. </param>
        [SerializationConstructor]
        protected internal WritableSubResource(string id)
        {
           Id = (TIdentifier)id;
        }

        /// <summary>
        /// Gets or sets the ARM resource identifier.
        /// </summary>
        /// <value></value>
        public virtual TIdentifier Id { get; set; }

        /// <inheritdoc/>
        public int CompareTo(string other)
        {
            return string.Compare(Id, other, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        public int CompareTo(WritableSubResource<TIdentifier> other)
        {
            if (other is null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;
            return Id.CompareTo(other.Id);
        }

        /// <inheritdoc/>
        public bool Equals(WritableSubResource<TIdentifier> other)
        {
            return Id.Equals(other?.Id);
        }

        /// <inheritdoc/>
        public bool Equals(string other)
        {
            return Id.Equals(other);
        }
    }
}
