// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Values for <see cref="LabelCollection"/>.
    /// </summary>
    public record LabelValue
    {
        /// <summary>
        /// Primitive value of <see cref="LabelCollection"/>.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Set value of <see cref="short"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(short value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="ushort"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(ushort value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="int"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="uint"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(uint value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="long"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(long value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="ulong"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(ulong value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="float"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="double"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="char"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(char value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="string"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="decimal"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(decimal value)
        {
            Value = value;
        }

        /// <summary>
        /// Set value of <see cref="bool"/> type.
        /// </summary>
        /// <param name="value"></param>
        public LabelValue(bool value)
        {
            Value = value;
        }

        internal LabelValue(object value)
        {
            Value = value;
        }
    }
}
