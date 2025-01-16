// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Models
{
    /// <summary>
    /// A <see cref="Segment"/> represents a segment of a request path which could be either a <see cref="Constant"/> or a <see cref="Reference"/>
    /// </summary>
    internal readonly struct Segment : IEquatable<Segment>
    {
        public static readonly Segment Providers = "providers";

        private readonly ReferenceOrConstant _value;
        private readonly string _stringValue;
        private readonly CSharpType? _expandableType;

        public Segment(ReferenceOrConstant value, bool escape, bool strict = false, CSharpType? expandableType = null)
        {
            _value = value;
            _stringValue = value.IsConstant ? value.Constant.Value?.ToString() ?? "null"
                : $"({value.Reference.Type.Name}){value.Reference.Name}";
            IsStrict = strict;
            Escape = escape;
            _expandableType = expandableType;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Segment"/>.
        /// </summary>
        /// <param name="value"> The string value for the segment. </param>
        /// <param name="escape"> Wether or not this segment is escaped. </param>
        /// <param name="strict"> Wether or not to use strict validate for this segment. </param>
        /// <param name="isConstant"> Whether this segment is a constant vs a reference. </param>
        public Segment(string value, bool escape = true, bool strict = false, bool isConstant = true)
             : this(isConstant ? new Constant(value, typeof(string)) : new Reference(value, typeof(string)), escape, strict)
        {
        }

        /// <summary>
        /// Represents the value of `x-ms-skip-url-encoding` if the corresponding path parameter has this extension
        /// </summary>
        public bool SkipUrlEncoding => !Escape;

        /// <summary>
        /// If this is a constant, escape is guranteed to be true, since our segment has been split by slashes.
        /// If this is a reference, escape is false when the corresponding parameter has x-ms-skip-url-encoding = true indicating this might be a scope variable
        /// </summary>
        public bool Escape { get; init; }

        /// <summary>
        /// Mark if this segment is strict when comparing with each other.
        /// IsStrict only works on Reference and does not work on Constant
        /// If IsStrict is false, and this is a Reference, we will only compare the type is the same when comparing
        /// But when IsStrict is true, or this is a Constant, we will always ensure we have the same value (for constant) or same reference name (for reference) and the same type
        /// </summary>
        public bool IsStrict { get; init; }

        public bool IsConstant => _value.IsConstant;

        public bool IsReference => !IsConstant;

        public bool IsExpandable => _expandableType is not null;

        public CSharpType Type => _expandableType ?? _value.Type;

        /// <summary>
        /// Returns the <see cref="Constant"/> of this segment
        /// </summary>
        /// <exception cref="InvalidOperationException">if this.IsConstant is false</exception>
        public Constant Constant => _value.Constant;

        /// <summary>
        /// Returns the value of the <see cref="Constant"/> of this segment in string
        /// </summary>
        /// <exception cref="InvalidOperationException">if this.IsConstant is false</exception>
        public string ConstantValue => _value.Constant.Value?.ToString() ?? "null";

        /// <summary>
        /// Returns the <see cref="Reference"/> of this segment
        /// </summary>
        /// <exception cref="InvalidOperationException">if this.IsReference is false</exception>
        public Reference Reference => _value.Reference;

        /// <summary>
        /// Returns the name of the <see cref="Reference"/> of this segment
        /// </summary>
        /// <exception cref="InvalidOperationException">if this.IsReference is false</exception>
        public string ReferenceName => _value.Reference.Name;

        internal bool Equals(Segment other, bool strict)
        {
            if (strict)
                return ExactEquals(this, other);
            if (this.IsConstant)
                return ExactEquals(this, other);
            // this is a reference, we will only test if the Type is the same
            if (other.IsConstant)
                return ExactEquals(this, other);
            // now other is also a reference
            return this._value.Reference.Type.Equals(other._value.Reference.Type);
        }

        private static bool ExactEquals(Segment left, Segment right)
        {
            return left._stringValue.Equals(right._stringValue, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Test if a segment is the same to the other. We will use strict mode if either of these two is strict.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Segment other) => this.Equals(other, IsStrict || other.IsStrict);

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var other = (Segment)obj;
            return other.Equals(this);
        }

        public override int GetHashCode() => _stringValue.GetHashCode();

        public override string ToString() => _stringValue;

        internal static string BuildSerializedSegments(IEnumerable<Segment> segments, bool slashPrefix = true)
        {
            var strings = segments.Select(segment => segment.IsConstant ? segment.ConstantValue : $"{{{segment.ReferenceName}}}");
            var prefix = slashPrefix ? "/" : string.Empty;
            return $"{prefix}{string.Join('/', strings)}";
        }

        public static implicit operator Segment(string value) => new Segment(value);

        public static bool operator ==(Segment left, Segment right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Segment left, Segment right)
        {
            return !(left == right);
        }
    }
}
