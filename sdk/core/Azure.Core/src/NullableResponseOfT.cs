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

        // This property is used to enable passing a value to the base type
        // that validates Response is not null.  We don't expect this to be
        // used, so it is instantiated lazily.
        private static DefaultResponse? _defaultRawResponse;
        private static DefaultResponse DefaultRawResponse
            => _defaultRawResponse ??= new();

        /// <summary>
        /// Creates an instance of <see cref="NullableResponse{T}"/> with no
        /// value or <see cref="Response"/>. It is not intended for this
        /// constructor to be called, as it will create an instance of
        /// <see cref="Response{T}"/> with a null <see cref="Response"/>,
        /// which is not the intended usage of this type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected NullableResponse() : base(default, DefaultRawResponse)
        {
            // Added for back-compat with GA APIs.  Any type that derives from
            // NullableResponse<T> must provide an implementation for
            // GetRawResponse that replaces DefaultResponse with the Response
            // populated on HttpMessage during the call to pipeline.Send.
        }

        /// <summary>
        /// Creates an instance of <see cref="NullableResponse{T}"/> from the
        /// provided <paramref name="value"/> and <paramref name="response"/>.
        /// </summary>
        /// <param name="value">The value to return from
        /// <see cref="ClientResult{T}.Value"/> on the created instance.</param>
        /// <param name="response">The <see cref="Response"/> to return from
        /// <see cref="GetRawResponse"/> on the created instance.</param>
        protected NullableResponse(T? value, Response response)
            : base(value, ReplaceWithDefaultIfNull(response))
        {
        }

        /// <summary>
        /// Gets a value indicating whether the current instance has a non-null value.
        /// </summary>
        public virtual bool HasValue => Value != null;

        /// <summary>
        /// Returns the HTTP response returned by the service.
        /// </summary>
        /// <returns>The HTTP response returned by the service.</returns>
        public new virtual Response GetRawResponse()
            => (Response)base.GetRawResponse();

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
            => response ?? DefaultRawResponse;

        // This type exists because of the following reasons:
        //   1. The base ClientResult constructor requires a non-null instance
        //      of PipelineResponse.
        //   2. NullableResponse<T> was GA'ed with a protected parameterless
        //      default constructor before inheriting from the base
        //      ClientResult class.
        //   3. The new implementation of the default constructor must pass an
        //      instance of this dummy type to the base constructor.
        //
        // Because the intent of NullableResponse<T> and Response<T> is to
        // always return a Response value from GetRawResponse, it is incorrect
        // for types derived from them to return null from GetRawResponse, and
        // instances of this type should only be created when the derived type
        // has been implemented incorrectly.  If an instance of this type is
        // returned from GetRawResponse, callers who access its properties will
        // get a NotSupportedException.
        private class DefaultResponse : Response
        {
            private readonly string ExceptionMessage = "Types derived from abstract NullableResponse<T> or Response<T> must provide an implementation of the virtual GetRawResponse method that returns a non-null Response value.";

            public override string ClientRequestId
            {
                get => throw new NotSupportedException(ExceptionMessage);
                set => throw new NotSupportedException(ExceptionMessage);
            }

            public override int Status
                => throw new NotSupportedException(ExceptionMessage);

            public override string ReasonPhrase
                => throw new NotSupportedException(ExceptionMessage);

            public override Stream? ContentStream
            {
                get => throw new NotSupportedException(ExceptionMessage);
                set => throw new NotSupportedException(ExceptionMessage);
            }

            protected override PipelineResponseHeaders HeadersCore
                => throw new NotSupportedException(ExceptionMessage);

            public override void Dispose()
            {
                throw new NotSupportedException(ExceptionMessage);
            }

            protected internal override bool ContainsHeader(string name)
            {
                throw new NotSupportedException(ExceptionMessage);
            }

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                throw new NotSupportedException(ExceptionMessage);
            }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
            {
                throw new NotSupportedException(ExceptionMessage);
            }

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
            {
                throw new NotSupportedException(ExceptionMessage);
            }

            public override BinaryData BufferContent(CancellationToken cancellationToken = default)
            {
                throw new NotSupportedException(ExceptionMessage);
            }

            public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
            {
                throw new NotSupportedException(ExceptionMessage);
            }
        }
    }
}
