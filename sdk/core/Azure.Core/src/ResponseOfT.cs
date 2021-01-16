// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public abstract class Response<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// Returns the HTTP response returned by the service.
        /// </summary>
        /// <returns>The HTTP response returned by the service.</returns>
        public abstract Response GetRawResponse();

        /// <summary>
        /// Gets the value returned by the service.
        /// </summary>
        public abstract T Value { get; }

        /// <summary>
        /// Returns the value of this <see cref="Response{T}"/> object.
        /// </summary>
        /// <param name="response">The <see cref="Response{T}"/> instance.</param>
        public static implicit operator T(Response<T> response) => response.Value;

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Status: {GetRawResponse().Status}, Value: {Value}";
        }
    }
}
