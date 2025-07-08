// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Generator.Management.Models
{
    internal class RequestPathSegment : IEquatable<RequestPathSegment>
    {
        private readonly string _value;
        private readonly bool _isConstant;
        private readonly string? _variableName;

        // TODO - scope not supported yet. we need to add support for it in the future.
        public RequestPathSegment(string value)
        {
            _value = value;
            (_isConstant, _variableName) = ParseValue(value);
        }

        public bool Equals(RequestPathSegment? other)
        {
            if (other is null)
                return false;
            return _value == other._value;
        }

        /// <summary>
        /// Returns true if this segment is a constant segment (i.e., it is not enclosed in curly braces).
        /// </summary>
        public bool IsConstant => _isConstant;

        /// <summary>
        /// Returns the variable name if this segment is a variable segment (i.e., it is enclosed in curly braces).
        /// Throws an exception if this segment is a constant segment.
        /// </summary>
        public string VariableName => _variableName ?? throw new InvalidOperationException("This segment is not a variable segment.");

        private static (bool IsConstant, string? VariableName) ParseValue(string value)
        {
            var span = value.AsSpan();
            if (span[0] == '{' && span[^1] == '}')
            {
                // This is a variable segment
                var variableName = span[1..^1].ToString();
                return (false, variableName);
            }
            else
            {
                // This is a constant segment
                return (true, null);
            }
        }

        public override bool Equals(object? obj) => obj is RequestPathSegment other && Equals(other);

        public override int GetHashCode() => _value.GetHashCode();

        public override string ToString() => _value;

        public static bool operator ==(RequestPathSegment left, RequestPathSegment right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RequestPathSegment left, RequestPathSegment right)
        {
            return !(left == right);
        }
    }
}
