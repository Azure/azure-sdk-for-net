// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Abstract class for empty classes.
    /// </summary>
    public abstract class EmptyPlaceholderObject
    {
        /// <summary>
        /// Generic value.
        /// </summary>
        protected object Value { get; set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="value"></param>
        protected EmptyPlaceholderObject(object value)
        {
            Value = value;
        }
    }
}
