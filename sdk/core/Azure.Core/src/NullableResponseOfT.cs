// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ComponentModel;

namespace Azure
{
    /// <summary>
    /// Represents a result of Azure operation.
    /// </summary>
    /// <typeparam name="T">The type of returned value.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public abstract class NullableResponse<T> : OptionalOutputMessage<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private const string NoValue = "<null>";

        /// <summary>
        /// Returns the HTTP response returned by the service.
        /// </summary>
        /// <returns>The HTTP response returned by the service.</returns>
        //public new abstract Response GetRawResponse();

        public new virtual Response GetRawResponse();

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
