// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

#nullable enable

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Represents a property on the storage resource.
    /// </summary>
    /// <typeparam name="T">The property of the storage resource</typeparam>
    #pragma warning disable SA1649 // File name should match first type name
    public class DataTransferProperty<T> : DataTransferProperty where T : notnull
#pragma warning restore SA1649 // File name should match first type name
    {
        internal T? _value;

        /// <summary>
        /// Represents the value of the DataTransferProperty.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only if the property as been set. (HasValue is true).
        /// </remarks>
        public virtual T? Value {
            get => _value;
            internal set => _value = value;
        }

        /// <summary>
        /// Constructs <see cref="DataTransferProperty"/> to preserves the respective property.
        /// </summary>
        /// <param name="preserve">Specifies whether or to preserve the property value from the source.</param>
        public DataTransferProperty(bool preserve) : base(preserve)
        {
            _value = default;
        }

        /// <summary>
        /// Constructor for <see cref="DataTransferProperty"/> to set value on the destination.
        /// This will overwrite the property on the destination with the parameter value.
        /// </summary>
        /// <param name="value">The value to set on the property.</param>
        public DataTransferProperty(T value)
        {
            _value = value;
            Preserve = false;
        }
    }
}
