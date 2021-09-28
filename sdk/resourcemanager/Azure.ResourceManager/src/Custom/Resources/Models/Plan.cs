// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Core;

namespace Azure.ResourceManager.Models
{
    /// <summary>
    /// Representation of a publisher plan for marketplace RPs.
    /// </summary>
    public sealed partial class Plan : IEquatable<Plan>, IComparable<Plan>
    {
        /// <summary>
        /// Compares this <see cref="Plan"/> with another instance.
        /// </summary>
        /// <param name="other"> <see cref="Plan"/> object to compare. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(Plan other)
        {
            if (ReferenceEquals(other, null))
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            int compareResult = 0;
            if ((compareResult = string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Product, other.Product, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(PromotionCode, other.PromotionCode, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Publisher, other.Publisher, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Version, other.Version, StringComparison.InvariantCultureIgnoreCase)) == 0)
            {
                return 0;
            }

            return compareResult;
        }

        /// <summary>
        /// Compares this <see cref="Plan"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="other"> <see cref="Plan"/> object to compare. </param>
        /// <returns> True if they are equals, otherwise false. </returns>
        public bool Equals(Plan other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Product, other.Product, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(PromotionCode, other.PromotionCode, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Publisher, other.Publisher, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Version, other.Version, StringComparison.InvariantCultureIgnoreCase);
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

            if (obj is not Plan other)
                return false;

            return Equals(other);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(
                Name?.ToLower(CultureInfo.InvariantCulture),
                Publisher?.ToLower(CultureInfo.InvariantCulture),
                Product?.ToLower(CultureInfo.InvariantCulture),
                PromotionCode?.ToLower(CultureInfo.InvariantCulture),
                Version?.ToLower(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Compares this <see cref="Plan"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if they are equal, otherwise false. </returns>
        public static bool operator ==(Plan left, Plan right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Compares this <see cref="Plan"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if they are not equal, otherwise false. </returns>
        public static bool operator !=(Plan left, Plan right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Compares one <see cref="Plan"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than the right. </returns>
        public static bool operator <(Plan left, Plan right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Compares one <see cref="Plan"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than or equal to the right. </returns>
        public static bool operator <=(Plan left, Plan right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Compares one <see cref="Plan"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than the right. </returns>
        public static bool operator >(Plan left, Plan right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Compares one <see cref="Plan"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than or equal to the right. </returns>
        public static bool operator >=(Plan left, Plan right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
