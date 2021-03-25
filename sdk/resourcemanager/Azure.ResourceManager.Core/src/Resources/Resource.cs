// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the base resource used by all azure resources.
    /// </summary>
    [ReferenceType]
    public abstract class Resource<TIdentifier> : IEquatable<Resource<TIdentifier>>, IEquatable<string>,
        IComparable<Resource<TIdentifier>>, IComparable<string> where TIdentifier : TenantResourceIdentifier
    {
        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        public virtual TIdentifier Id { get; protected set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public virtual string Name => Id?.Name;

        /// <summary>
        /// Gets the resource type.
        /// </summary>
        public virtual ResourceType Type => Id?.ResourceType;

        /// <inheritdoc/>
        public virtual int CompareTo(Resource<TIdentifier> other)
        {
            if (other == null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            int compareResult = 0;
            if ((compareResult = string.Compare(Id, other.Id, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = Type.CompareTo(other.Type)) == 0)
                return 0;

            return compareResult;
        }

        /// <inheritdoc/>
        public virtual int CompareTo(string other)
        {
            return string.Compare(Id, other, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        public virtual bool Equals(Resource<TIdentifier> other)
        {
            if (Id == null)
                return false;

            return Id.Equals(other?.Id);
        }

        /// <inheritdoc/>
        public virtual bool Equals(string other)
        {
            if (Id == null)
                return false;

            return Id.Equals(other);
        }
    }
}
