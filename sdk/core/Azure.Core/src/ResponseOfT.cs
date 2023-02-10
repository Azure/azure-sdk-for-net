// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Azure
{
    /// <summary>
    /// Represents a result of Azure operation.
    /// </summary>
    /// <typeparam name="T">The type of returned value.</typeparam>
    [DebuggerTypeProxy(typeof(ResponseDebugView<>))]
#pragma warning disable SA1649 // File name should match first type name
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Response<T> : NullableResponse<T>
#pragma warning restore AZC0012 // Avoid single word type names
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool HasValue => true;

        /// <summary>
        /// Returns the value of this <see cref="Response{T}"/> object.
        /// </summary>
        /// <param name="response">The <see cref="Response{T}"/> instance.</param>
        public static implicit operator T(Response<T> response)
        {
            if (response == null)
            {
#pragma warning disable CA1065 // Don't throw from cast operators
                throw new ArgumentNullException(nameof(response), $"The implicit cast from Response<{typeof(T)}> to {typeof(T)} failed because the Response<{typeof(T)}> was null.");
#pragma warning restore CA1065
            }

            return response.Value;
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
