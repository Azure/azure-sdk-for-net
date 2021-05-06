// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing Azure resource API versions base.
    /// </summary>
    public class ApiVersionsBase : IEquatable<string>, IComparable<string>
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
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(ApiVersionsBase left, ApiVersionsBase right)
        {
            if (ReferenceEquals(null, left))
                return !ReferenceEquals(null, right);

            return left.CompareTo(right) == -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(ApiVersionsBase left, ApiVersionsBase right)
        {
            if (ReferenceEquals(null, left))
                return false;

            return left.CompareTo(right) == 1;
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
        /// <param name="first"> The ApiVersionsBase object to compare. </param>
        /// <param name="second"> The API version value in string to compare. </param>
        /// <returns> Comparison result in boolean. Equal returns true otherwise returns false. </returns>
        public static bool operator ==(ApiVersionsBase first, string second)
        {
            if (ReferenceEquals(null, first))
            {
                return ReferenceEquals(null, second);
            }

            if (ReferenceEquals(null, second))
            {
                return false;
            }

            return first.Equals(second);
        }

        /// <summary>
        /// Overrides != operator for comparing ApiVersionsBase object with string object.
        /// </summary>
        /// <param name="first"> The ApiVersionsBase object to compare. </param>
        /// <param name="second"> The API version value in string to compare. </param>
        /// <returns> Comparison result in boolean. Equal returns false otherwise returns true. </returns>
        public static bool operator !=(ApiVersionsBase first, string second)
        {
            if (ReferenceEquals(null, first))
            {
                return !ReferenceEquals(null, second);
            }

            if (ReferenceEquals(null, second))
            {
                return true;
            }

            return !first.Equals(second);
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
        /// <param name="obj"> The object to compare. </param>
        /// <returns> Comparison result in boolean. Equal returns true otherwise returns false. </returns>
        public override bool Equals(object obj)
        {
            if (obj is ApiVersionsBase)
                return Equals(obj as ApiVersionsBase);
            if (obj is string)
                return Equals(obj as string);

            return false;
        }

        /// <summary>
        /// Gets the hash code of the API version value.
        /// </summary>
        /// <returns> The hash code of the API version value. </returns>
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
