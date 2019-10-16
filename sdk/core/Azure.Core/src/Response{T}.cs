// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure
{
    /// <summary>
    /// Represents a result of Azure operation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Response<T>
    {
        /// <summary>
        /// Returns the HTTP response returned by the service.
        /// </summary>
        /// <returns></returns>
        public abstract Response GetRawResponse();

        /// <summary>
        /// Gets the value returned by the service.
        /// </summary>
        public abstract T Value { get; }

        /// <summary>
        /// Returns the value of this <see cref="Response{T}"/> object.
        /// </summary>
        /// <param name="response"></param>
        public static implicit operator T(Response<T> response) => response.Value;

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
