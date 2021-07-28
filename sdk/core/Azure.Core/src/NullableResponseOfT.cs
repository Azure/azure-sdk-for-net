// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure
{
    /// <summary>
    /// Represents a result of Azure operation that can be null.
    /// </summary>
    /// <typeparam name="T">The type of returned value.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public abstract class NullableResponse<T>
        where T : class
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
        /// Returns the value of this <see cref="NullableResponse{T}"/> object.
        /// </summary>
        /// <param name="response">The <see cref="NullableResponse{T}"/> instance.</param>
        public static implicit operator T(NullableResponse<T> response) => response.Value;

        /// <summary>
        /// Returns the value of this <see cref="NullableResponse{T}"/> object.
        /// </summary>
        /// <param name="response">The <see cref="Response{T}"/> instance.</param>
        public static implicit operator NullableResponse<T>(Response<T> response) => Response.FromNullableValue(response.Value, response.GetRawResponse());

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
