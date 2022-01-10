// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing Azure resource API versions base.
    /// </summary>
    internal class ApiVersionsBase : IEquatable<string>, IComparable<string>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiVersionsBase"/> class.
        /// </summary>
        /// <param name="value"> The API version value. </param>
        protected ApiVersionsBase(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Compares one <see cref="ApiVersionsBase"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than the right. </returns>
        public static bool operator <(ApiVersionsBase left, ApiVersionsBase right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Compares one <see cref="ApiVersionsBase"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than the right. </returns>
        public static bool operator >(ApiVersionsBase left, ApiVersionsBase right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Implicit operator to convert ApiVersionsBase to string.
        /// </summary>
        /// <param name="version"> The ApiVersionsBase object. </param>
        /// <returns> API version value. </returns>
        public static implicit operator string(ApiVersionsBase version)
        {
            if (ReferenceEquals(null, version))
            {
                return null;
            }
            return version._value;
        }

        /// <summary>
        /// Implicit operator to convert ApiVersionsBase to string.
        /// </summary>
        /// <returns> API version value. </returns>
        public virtual ResourceType ResourceType {get; }

        /// <summary>
        /// Overrides == operator for comparing ApiVersionsBase object with string object.
        /// </summary>
        /// <param name="left"> The ApiVersionsBase object to compare. </param>
        /// <param name="right"> The API version value in string to compare. </param>
        /// <returns> Comparison result in boolean. Equal returns true otherwise returns false. </returns>
        public static bool operator ==(ApiVersionsBase left, string right)
        {
            if (ReferenceEquals(null, left))
            {
                return ReferenceEquals(null, right);
            }

            if (ReferenceEquals(null, right))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Overrides != operator for comparing ApiVersionsBase object with string object.
        /// </summary>
        /// <param name="left"> The ApiVersionsBase object to compare. </param>
        /// <param name="right"> The API version value in string to compare. </param>
        /// <returns> Comparison result in boolean. Equal returns false otherwise returns true. </returns>
        public static bool operator !=(ApiVersionsBase left, string right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Compares two API version values in string type.
        /// </summary>
        /// <param name="other"> The API version value to compare. </param>
        /// <returns> Comparison result in integer. 1 for greater than, 0 for equals to, and -1 for less than. </returns>
        public int CompareTo(string other)
        {
            if (other is null)
            {
                return 1;
            }

            var regPattern = @"(\d\d\d\d-\d\d-\d\d)(.*)";

            var otherMatch = Regex.Match(other, regPattern);
            var thisMatch = Regex.Match(_value, regPattern);

            var otherDatePart = otherMatch.Groups[1].Value;
            var thisDatePart = thisMatch.Groups[1].Value;

            if (otherDatePart == thisDatePart)
            {
                var otherPreviewPart = otherMatch.Groups[2].Value;
                var thisPreviewPart = thisMatch.Groups[2].Value;

                if (otherPreviewPart == thisPreviewPart)
                {
                    return 0;
                }

                if (string.IsNullOrEmpty(otherPreviewPart))
                {
                    return -1;
                }

                if (string.IsNullOrEmpty(thisPreviewPart))
                {
                    return 1;
                }

                return string.Compare(thisPreviewPart, otherPreviewPart, StringComparison.InvariantCulture);
            }

            return string.Compare(thisDatePart, otherDatePart, StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Compares the API version value in ApiVersionsBase object and the one in string.
        /// </summary>
        /// <param name="other"> The API version value to compare. </param>
        /// <returns> Comparison result in boolean. Equal returns true otherwise returns false. </returns>
        public bool Equals(string other)
        {
            if (other == null)
            {
                return false;
            }

            return other == _value;
        }

        /// <summary>
        /// Converts ApiVersionsBase object to string.
        /// </summary>
        /// <returns> The API version value. </returns>
        public override string ToString()
        {
            return _value;
        }

        /// <summary>
        /// Compares the API version value in ApiVersionsBase object and the one in object.
        /// </summary>
        /// <param name="other"> The object to compare. </param>
        /// <returns> Comparison result in boolean. Equal returns true otherwise returns false. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object other)
        {
            if (other is ApiVersionsBase)
                return Equals(other as ApiVersionsBase);
            if (other is string)
                return Equals(other as string);

            return false;
        }

        /// <summary>
        /// Gets the hash code of the API version value.
        /// </summary>
        /// <returns> The hash code of the API version value. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        /// <summary>
        /// Compares one <see cref="ApiVersionsBase"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than or equal to the right. </returns>
        public static bool operator <=(ApiVersionsBase left, ApiVersionsBase right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Compares one <see cref="ApiVersionsBase"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than or equal to the right. </returns>
        public static bool operator >=(ApiVersionsBase left, ApiVersionsBase right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
