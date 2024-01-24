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
    public abstract class NullableResponse<T> : ClientResult
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly T? _value;

        private const string NoValue = "<null>";
        internal static Response DefaultResponse = new Response.AzureCoreDefaultResponse();

        /// <summary>
        /// TBD.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected NullableResponse() : base(DefaultResponse)
        {
            // Added for back-compat with GA APIs.  Any type that derives from
            // Response<T> must provide an implementation for GetRawResponse that
            // replaces DefaultResponse with the Response populated on HttpMessage
            // during the call to pipeline.Send.

            _value = default;
        }

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="response"></param>
        protected NullableResponse(T? value, Response response)
            : base(ReplaceWithDefaultIfNull(response))
        {
            _value = value;
        }

        /// <summary>
        /// Gets the value returned by the service. Accessing this property will throw if <see cref="HasValue"/> is false.
        /// </summary>
        public virtual T? Value => _value;

        /// <summary>
        /// Gets a value indicating whether the current instance has a non-null value.
        /// </summary>
        public virtual bool HasValue => _value != null;

        private static Response ReplaceWithDefaultIfNull(Response? response)
            => response ?? DefaultResponse;

        /// <summary>
        /// Returns the HTTP response returned by the service.
        /// </summary>
        /// <returns>The HTTP response returned by the service.</returns>
        public new virtual Response GetRawResponse() => (Response)base.GetRawResponse();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <inheritdoc />
        public override string ToString()
             => $"Status: {GetRawResponse()?.Status}, Value: {(HasValue ? Value : NoValue)}";
    }
}
