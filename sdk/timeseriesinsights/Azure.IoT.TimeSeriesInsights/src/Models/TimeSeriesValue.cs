// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// A variant type that represents a Time Series value that is retrieved when executing Query requests.
    /// </summary>
    public readonly struct TimeSeriesValue
    {
        private static readonly object s_nullInt32 = new();
        private static readonly object s_nullDouble = new();
        private static readonly object s_nullBoolean = new();
        private static readonly object s_nullDateTimeOffset = new();
        private static readonly object s_nullTimeSpan = new();

        private readonly long _i64;
        private readonly object _obj;

        /// <summary>
        /// Get the type of the variant.
        /// </summary>
        public Type Type
        {
            get
            {
                if (_obj.GetType() == typeof(string))
                    return typeof(string);
                if (_obj.GetType() == typeof(byte[]))
                    return typeof(string);
                if (_obj.GetType() == typeof(DateTimeOffset))
                    return typeof(DateTimeOffset);
                if (_obj.GetType() == typeof(object))
                {
                    if (_obj == s_nullInt32)
                        return typeof(int?);
                    if (_obj == s_nullDouble)
                        return typeof(double?);
                    if (_obj == s_nullBoolean)
                        return typeof(bool?);
                    if (_obj == s_nullDateTimeOffset)
                        return typeof(DateTimeOffset?);
                }
                return (Type)_obj;
            }
        }

        #region Int32

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="value">The integer to represent the variant type.</param>
        public TimeSeriesValue(int value)
        {
            _obj = typeof(int);
            _i64 = value;
        }

        /// <summary>
        /// An integer implicit cast operation to a TimeSeriesValue.
        /// </summary>
        /// <param name="value">The integer to cast.</param>
        public static implicit operator TimeSeriesValue(int value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// An TimeSeriesValue explicit cast operation to an integer.
        /// </summary>
        /// <param name="variant">The variant to cast.</param>
        public static explicit operator int(TimeSeriesValue variant)
        {
            if (!variant._obj.Equals(typeof(int)))
                throw new InvalidCastException();
            return (int)variant._i64;
        }

        #endregion

        #region Nullable<Int32>

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="value">The integer to represent the variant type.</param>
        public TimeSeriesValue(int? value)
        {
            if (value.HasValue)
            {
                _obj = typeof(int?);
                _i64 = value.Value;
            }
            else
            {
                _obj = s_nullInt32;
                _i64 = default;
            }
        }

        /// <summary>
        /// A nullable integer implicit cast operation to a TimeSeriesValue.
        /// </summary>
        /// <param name="value">The integer to cast.</param>
        public static implicit operator TimeSeriesValue(int? value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// An TimeSeriesValue explicit cast operation to an integer.
        /// </summary>
        /// <param name="variant">The variant to cast.</param>
        public static explicit operator int?(TimeSeriesValue variant)
        {
            if (variant._obj == s_nullInt32)
                return null;
            if (variant._obj.Equals(typeof(int?)))
                return (int)variant._i64;
            throw new InvalidCastException();
        }

        #endregion

        #region Double

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="value">The double to represent the variant type.</param>
        public TimeSeriesValue(double value)
        {
            _obj = typeof(double);
            _i64 = Unsafe.As<double, long>(ref value);
        }

        /// <summary>
        /// A double implicit cast operation to a TimeSeriesValue.
        /// </summary>
        /// <param name="value">The double to cast.</param>
        public static implicit operator TimeSeriesValue(double value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// An TimeSeriesValue explicit cast operation to a double.
        /// </summary>
        /// <param name="variant">The variant to cast.</param>
        public static explicit operator double(TimeSeriesValue variant)
        {
            if (!variant._obj.Equals(typeof(double)))
                throw new InvalidCastException();
            var representation = variant._i64;
            return Unsafe.As<long, double>(ref representation);
        }

        #endregion

        #region Nullable<Double>

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="value">The double to cast.</param>
        public TimeSeriesValue(double? value)
        {
            if (value.HasValue)
            {
                _obj = typeof(double?);
                double v = value.Value;
                _i64 = Unsafe.As<double, long>(ref v);
            }
            else
            {
                _obj = s_nullDouble;
                _i64 = default;
            }
        }

        /// <summary>
        /// A double implicit cast operation to a TimeSeriesValue.
        /// </summary>
        /// <param name="value">The double to cast.</param>
        public static implicit operator TimeSeriesValue(double? value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// An TimeSeriesValue explicit cast operation to a double.
        /// </summary>
        /// <param name="variant">The variant to cast.</param>
        public static explicit operator double?(TimeSeriesValue variant)
        {
            if (variant._obj == s_nullDouble)
                return null;
            if (variant._obj.Equals(typeof(double?)))
            {
                var representation = variant._i64;
                return Unsafe.As<long, double>(ref representation);
            }
            throw new InvalidCastException();
        }

        #endregion

        #region Boolean

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="value">The boolean to represent the variant type.</param>
        public TimeSeriesValue(bool value)
        {
            _obj = typeof(bool);
            _i64 = value ? 1 : 0;
        }

        /// <summary>
        /// A boolean implicit cast operation to a TimeSeriesValue.
        /// </summary>
        /// <param name="value">The boolean to cast.</param>
        public static implicit operator TimeSeriesValue(bool value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// An TimeSeriesValue explicit cast operation to a boolean.
        /// </summary>
        /// <param name="variant">The variant to cast.</param>
        public static explicit operator bool(TimeSeriesValue variant)
        {
            if (!variant._obj.Equals(typeof(bool)))
                throw new InvalidCastException();
            return variant._i64 == 1;
        }

        #endregion

        #region Nullable<Boolean>

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="value">The boolean to represent the variant type.</param>
        public TimeSeriesValue(bool? value)
        {
            if (value.HasValue)
            {
                _obj = typeof(bool?);
                _i64 = value.Value ? 1 : 0;
            }
            else
            {
                _obj = s_nullBoolean;
                _i64 = default;
            }
        }

        /// <summary>
        /// A boolean implicit cast operation to a TimeSeriesValue.
        /// </summary>
        /// <param name="value">The boolean to cast.</param>
        public static implicit operator TimeSeriesValue(bool? value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// An TimeSeriesValue explicit cast operation to a boolean.
        /// </summary>
        /// <param name="variant">The variant to cast.</param>
        public static explicit operator bool?(TimeSeriesValue variant)
        {
            if (variant._obj == s_nullBoolean)
                return null;
            if (variant._obj.Equals(typeof(bool?)))
                return variant._i64 == 1;
            throw new InvalidCastException();
        }

        #endregion

        #region DateTimeOffset

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="value">The DateTimeOffset to represent the variant type.</param>
        public TimeSeriesValue(DateTimeOffset value)
        {
            if (value.Offset.Ticks == 0)
            {
                _i64 = value.Ticks;
                _obj = typeof(DateTimeOffset);
            }
            else
            {
                _obj = value;
                _i64 = 0;
            }
        }

        /// <summary>
        /// A DateTimeOffset implicit cast operation to a TimeSeriesValue.
        /// </summary>
        /// <param name="value">The DateTimeOffset to cast.</param>
        public static implicit operator TimeSeriesValue(DateTimeOffset value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// An TimeSeriesValue explicit cast operation to a DateTimeOffset.
        /// </summary>
        /// <param name="variant">The variant to cast.</param>
        public static explicit operator DateTimeOffset(TimeSeriesValue variant)
        {
            if (variant._obj.Equals(typeof(DateTimeOffset)))
            {
                return new DateTimeOffset(variant._i64, TimeSpan.Zero);
            }
            if (variant._obj is DateTimeOffset dto)
            {
                return dto;
            }

            throw new InvalidCastException();
        }
        #endregion

        #region Nullable<DateTimeOffset>

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="value">The DateTimeOffset to represent the variant type.</param>
        public TimeSeriesValue(DateTimeOffset? value)
        {
            if (value.HasValue)
            {
                if (value.Value.Offset.Ticks == 0)
                {
                    _i64 = value.Value.Ticks;
                    _obj = typeof(DateTimeOffset?);
                }
                else
                {
                    _i64 = 0;
                    _obj = value.Value;
                }
            }
            else
            {
                _obj = s_nullDateTimeOffset;
                _i64 = default;
            }
        }

        /// <summary>
        /// A DateTimeOffset implicit cast operation to a TimeSeriesValue.
        /// </summary>
        /// <param name="value">The DateTimeOffset to cast.</param>
        public static implicit operator TimeSeriesValue(DateTimeOffset? value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// An TimeSeriesValue explicit cast operation to a DateTimeOffset.
        /// </summary>
        /// <param name="variant">The variant to cast.</param>
        public static explicit operator DateTimeOffset?(TimeSeriesValue variant)
        {
            if (variant._obj == s_nullDateTimeOffset)
                return null;
            if (variant._obj.Equals(typeof(DateTimeOffset?)))
                return new DateTimeOffset(variant._i64, TimeSpan.Zero);
            if (variant._obj is DateTimeOffset dto)
                return dto;
            throw new InvalidCastException();
        }

        #endregion

        #region TimeSpan

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="value">The TimeSpan to represent the variant type.</param>
        public TimeSeriesValue(TimeSpan value)
        {
            _obj = typeof(TimeSpan);
            _i64 = value.Ticks;
        }

        /// <summary>
        /// A TimeSpan implicit cast operation to a TimeSeriesValue.
        /// </summary>
        /// <param name="value">The TimeSpan to cast.</param>
        public static implicit operator TimeSeriesValue(TimeSpan value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// An TimeSeriesValue explicit cast operation to a TimeSpan.
        /// </summary>
        /// <param name="variant">The variant to cast.</param>
        public static explicit operator TimeSpan(TimeSeriesValue variant)
        {
            if (!variant._obj.Equals(typeof(TimeSpan)))
                throw new InvalidCastException();
            return new TimeSpan(variant._i64);
        }

        #endregion

        #region Nullable<TimeSpan>

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="value">The TimeSpan to represent the variant type.</param>
        public TimeSeriesValue(TimeSpan? value)
        {
            if (value.HasValue)
            {
                _obj = typeof(TimeSpan?);
                _i64 = value.Value.Ticks;
            }
            else
            {
                _obj = s_nullTimeSpan;
                _i64 = default;
            }
        }

        /// <summary>
        /// A TimeSpan implicit cast operation to a TimeSeriesValue.
        /// </summary>
        /// <param name="value">The TimeSpan to cast.</param>
        public static implicit operator TimeSeriesValue(TimeSpan? value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// An TimeSeriesValue explicit cast operation to a TimeSpan.
        /// </summary>
        /// <param name="variant">The variant to cast.</param>
        public static explicit operator TimeSpan?(TimeSeriesValue variant)
        {
            if (variant._obj == s_nullTimeSpan)
                return null;
            if (variant._obj.Equals(typeof(TimeSpan?)))
            {
                return new TimeSpan(variant._i64);
            }
            throw new InvalidCastException();
        }

        #endregion

        #region String

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="value">The string to represent the variant type.</param>
        public TimeSeriesValue(string value)
        {
            _obj = value;
            _i64 = default;
        }

        /// <summary>
        /// A string implicit cast operation to a TimeSeriesValue.
        /// </summary>
        /// <param name="value">The string to cast.</param>
        public static implicit operator TimeSeriesValue(string value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSeriesValue"/> struct.
        /// </summary>
        /// <param name="utf8"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        public TimeSeriesValue(byte[] utf8, int index, int count)
        {
            _obj = utf8;
            _i64 = index << 32 | count;
        }

        /// <summary>
        /// An TimeSeriesValue explicit cast operation to a string.
        /// </summary>
        /// <param name="variant">The variant to cast.</param>
        public static explicit operator string(TimeSeriesValue variant)
        {
            string str = variant._obj as string;
            if (str != null)
                return str;

            byte[] utf8 = variant._obj as byte[];
            if (utf8 != null)
            {
                var decoded = Encoding.UTF8.GetString(utf8, (int)(variant._i64 << 32), (int)variant._i64);
                return decoded;
            }

            throw new InvalidCastException();
        }

        #endregion
    }
}
