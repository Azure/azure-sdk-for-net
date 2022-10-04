// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure
{
    /// <summary>
    /// Represents a result of Azure operation.
    /// </summary>
    /// <typeparam name="T">The type of returned value.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public abstract class NullableResponse<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// Gets the value returned by the service.
        /// </summary>
        public T? Value { get; }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
