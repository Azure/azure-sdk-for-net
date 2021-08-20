// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// A class representing SKU for resource.
    /// </summary>
    public sealed partial class Sku : IEquatable<Sku>, IComparable<Sku>
    {
        /// <summary>
        /// Compares this <see cref="Sku"/> with another instance.
        /// </summary>
        /// <param name="other"> <see cref="Sku"/> object to compare. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(Sku other)
        {
            if (other == null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            int compareResult = 0;
            if ((compareResult = string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Family, other.Family, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Size, other.Size, StringComparison.InvariantCultureIgnoreCase)) == 0)
            {
                return Nullable.Compare<long>(Capacity, other.Capacity);
            }

            return compareResult;
        }

        /// <summary>
        /// Compares this <see cref="Sku"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="other"> <see cref="Sku"/> object to compare. </param>
        /// <returns> True if they are equals, otherwise false. </returns>
        public bool Equals(Sku other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Family, other.Family, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Size, other.Size, StringComparison.InvariantCultureIgnoreCase) &&
                (Tier.HasValue ? Tier.Value.Equals(other.Tier) : !other.Tier.HasValue) &&
                long.Equals(Capacity, other.Capacity);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (obj is not Sku other)
                return false;

            return Equals(other);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(
                Name?.ToLower(CultureInfo.InvariantCulture),
                Family?.ToLower(CultureInfo.InvariantCulture),
                Size?.ToLower(CultureInfo.InvariantCulture),
                Tier?.ToString().ToLower(CultureInfo.InvariantCulture),
                Capacity);
        }

        /// <summary>
        /// Compares this <see cref="Sku"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="left"> The sku on the left side of the operator. </param>
        /// <param name="right"> The sku on the right side of the operator. </param>
        /// <returns> True if they are equal, otherwise false. </returns>
        public static bool operator ==(Sku left, Sku right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Compares this <see cref="Sku"/> instance with another object and determines if they are not equal.
        /// </summary>
        /// <param name="left"> The sku on the left side of the operator. </param>
        /// <param name="right"> The sku on the right side of the operator. </param>
        /// <returns> True if they are not equal, otherwise false. </returns>
        public static bool operator !=(Sku left, Sku right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Compares one <see cref="Sku"/> with another instance.
        /// </summary>
        /// <param name="left"> The sku on the left side of the operator. </param>
        /// <param name="right"> The sku on the right side of the operator. </param>
        /// <returns> True if the left Sku is less than the right. </returns>
        public static bool operator <(Sku left, Sku right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Compares one <see cref="Sku"/> with another instance.
        /// </summary>
        /// <param name="left"> The sku on the left side of the operator. </param>
        /// <param name="right"> The sku on the right side of the operator. </param>
        /// <returns> True if the left Sku is less than or equal to the right. </returns>
        public static bool operator <=(Sku left, Sku right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Compares one <see cref="Sku"/> with another instance.
        /// </summary>
        /// <param name="left"> The sku on the left side of the operator. </param>
        /// <param name="right"> The sku on the right side of the operator. </param>
        /// <returns> True if the left Sku is greater than the right. </returns>
        public static bool operator >(Sku left, Sku right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Compares one <see cref="Sku"/> with another instance.
        /// </summary>
        /// <param name="left"> The sku on the left side of the operator. </param>
        /// <param name="right"> The sku on the right side of the operator. </param>
        /// <returns> True if the left Sku is greater than or equal to the right. </returns>
        public static bool operator >=(Sku left, Sku right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
