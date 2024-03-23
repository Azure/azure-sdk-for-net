// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Generic value wrapper. Values must be primitive values - number, string, boolean.
    /// </summary>
    public class RouterValue : IEquatable<RouterValue>
    {
        /// <summary>
        /// Primitive value.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Set value of <see cref="int"/> type.
        /// </summary>
        /// <param name="value"></param>
        public RouterValue(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="long"/> type.
        /// </summary>
        /// <param name="value"></param>
        public RouterValue(long value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="float"/> type.
        /// </summary>
        /// <param name="value"></param>
        public RouterValue(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="double"/> type.
        /// </summary>
        /// <param name="value"></param>
        public RouterValue(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="string"/> type.
        /// </summary>
        /// <param name="value"></param>
        public RouterValue(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="decimal"/> type.
        /// </summary>
        /// <param name="value"></param>
        public RouterValue(decimal value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="bool"/> type.
        /// </summary>
        /// <param name="value"></param>
        public RouterValue(bool value)
        {
            Value = value;
        }

        internal RouterValue(object value)
        {
            Value = value;
        }

        /// <inheritdoc />
        public bool Equals(RouterValue other)
        {
            if (Value == null)
            {
                return other.Value == null;
            }

            var response = Value.Equals(other.Value);
            return response;
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RouterValue other && Equals(other);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;

        /// <inheritdoc />
        public override string ToString()
        {
            return Value.ToString();
        }

        /// <summary> Determines if two <see cref="RouterValue"/> values are the same. </summary>
        public static bool operator ==(RouterValue left, RouterValue right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RouterValue"/> values are not the same. </summary>
        public static bool operator !=(RouterValue left, RouterValue right) => !left.Equals(right);
    }
}
