// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Represents a result of Azure operation.
    /// </summary>
    /// <typeparam name="T">The type of returned value.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public abstract class NullableResponse<T> : ClientResult<T?>
#pragma warning restore SA1649 // File name should match first type name
    {
        private const string NoValue = "<null>";

        private readonly T? _value;

        // Used to enable passing a value to the base type that validates
        // Response is not null.  We don't expect this to be used, so it is
        // instantiated lazily.
        private static Response? _defaultResponse;
        private static Response DefaultResponse
            => _defaultResponse ??= new AzureCoreDefaultResponse();

        /// <summary>
        /// TBD.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected NullableResponse() : base(default, DefaultResponse)
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
            : base(value, ReplaceWithDefaultIfNull(response))
        {
            _value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the current instance has a non-null value.
        /// </summary>
        public virtual bool HasValue => _value != null;

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

        private static Response ReplaceWithDefaultIfNull(Response? response)
            => response ?? DefaultResponse;

        private class AzureCoreDefaultResponse : Response
        {
            private readonly string DefaultMessage = "Types derived from abstract Response<T> must provide an implementation of the virtual GetRawResponse method that returns a non-null Response value.";

            public override string ClientRequestId
            {
                get => throw new NotSupportedException(DefaultMessage);
                set => throw new NotSupportedException(DefaultMessage);
            }

            public override int Status => throw new NotSupportedException(DefaultMessage);

            public override string ReasonPhrase => throw new NotSupportedException(DefaultMessage);

            public override Stream? ContentStream
            {
                get => throw new NotSupportedException(DefaultMessage);
                set => throw new NotSupportedException(DefaultMessage);
            }

            protected override PipelineResponseHeaders HeadersCore
                => throw new NotSupportedException(DefaultMessage);

            public override void Dispose()
            {
                throw new NotSupportedException(DefaultMessage);
            }

            protected internal override bool ContainsHeader(string name)
            {
                throw new NotSupportedException(DefaultMessage);
            }

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                throw new NotSupportedException(DefaultMessage);
            }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
            {
                throw new NotSupportedException(DefaultMessage);
            }

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
            {
                throw new NotSupportedException(DefaultMessage);
            }

            public override BinaryData BufferContent(CancellationToken cancellationToken = default)
            {
                throw new NotSupportedException(DefaultMessage);
            }

            public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
            {
                throw new NotSupportedException(DefaultMessage);
            }
        }
    }
}
