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
    public abstract class DataTransferProperty<T> : DataTransferProperty where T : notnull
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// Final result of the long-running operation.
        /// </summary>
        /// <remarks>
        /// This property can be accessed only after the operation completes successfully (HasValue is true).
        /// </remarks>
        public abstract T Value { get; }

        /// <summary>
        /// Returns true if the long-running operation completed successfully and has produced final result (accessible by Value property).
        /// </summary>
        public abstract bool HasValue { get; }
    }
}
