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
        private const string NoValue = "<null>";

        /// <summary>
        /// Gets a value indicating whether the current instance has a valid value of its underlying type.
        /// </summary>
        public abstract bool HasValue { get; }

        /// <summary>
        /// Gets the value returned by the service. Accessing this property will throw if <see cref="HasValue"/> is false.
        /// </summary>
        public abstract T Value { get; }

        /// <summary>
        /// Returns the HTTP response returned by the service.
        /// </summary>
        /// <returns>The HTTP response returned by the service.</returns>
        public abstract Response GetRawResponse();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <inheritdoc />
        public override string ToString() => $"Status: {GetRawResponse()?.Status}, Value: {(HasValue ? Value : NoValue)}";
    }
}
