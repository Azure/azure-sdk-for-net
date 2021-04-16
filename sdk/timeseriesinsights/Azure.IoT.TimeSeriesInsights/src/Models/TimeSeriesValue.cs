// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// </summary>
    public readonly struct TimeSeriesValue
    {
        private readonly long _i64;
        private readonly object _obj;

        /// <summary>
        /// </summary>
        public Type Type
        {
            get
            {
                if (_obj.GetType() == typeof(string))
                    return typeof(string);
                if (_obj.GetType() == typeof(byte[]))
                    return typeof(string);
                return (Type)_obj;
            }
        }

        #region Int32

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public TimeSeriesValue(int value)
        {
            _obj = typeof(int);
            _i64 = value;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator TimeSeriesValue(int value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// </summary>
        /// <param name="variant"></param>
        public static explicit operator int(TimeSeriesValue variant)
        {
            if (!variant._obj.Equals(typeof(int)))
                throw new InvalidCastException();
            return (int)variant._i64;
        }

        ///// <summary>
        ///// </summary>
        ///// <param name="variant"></param>
        //public static explicit operator string(TimeSeriesValue variant)
        //{
        //    if (!variant._obj.Equals(typeof(int)))
        //        throw new InvalidCastException();
        //    return variant._i64.ToString(CultureInfo.InvariantCulture);
        //}

        #endregion

        #region Double

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public TimeSeriesValue(double value)
        {
            _obj = typeof(double);
            _i64 = Unsafe.As<double, long>(ref value);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator TimeSeriesValue(double value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// </summary>
        /// <param name="variant"></param>
        public static explicit operator double(TimeSeriesValue variant)
        {
            if (!variant._obj.Equals(typeof(double)))
                throw new InvalidCastException();
            var representation = variant._i64;
            return Unsafe.As<long, double>(ref representation);
        }

        #endregion

        #region Boolean

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public TimeSeriesValue(bool value)
        {
            _obj = typeof(bool);
            _i64 = value ? 1 : 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator TimeSeriesValue(bool value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// </summary>
        /// <param name="variant"></param>
        public static explicit operator bool(TimeSeriesValue variant)
        {
            if (!variant._obj.Equals(typeof(bool)))
                throw new InvalidCastException();
            return variant._i64 == 1;
        }

        #endregion

        #region DateTimeOffset

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
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
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator TimeSeriesValue(DateTimeOffset value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
        /// </summary>
        /// <param name="variant"></param>
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

        #region String

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public TimeSeriesValue(string value)
        {
            _obj = value;
            _i64 = default;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator TimeSeriesValue(string value)
        {
            return new TimeSeriesValue(value);
        }

        /// <summary>
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
        /// </summary>
        /// <param name="variant"></param>
        public static explicit operator string(TimeSeriesValue variant)
        {
            var str = variant._obj as string;
            if (str != null)
                return str;

            var utf8 = variant._obj as byte[];
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
