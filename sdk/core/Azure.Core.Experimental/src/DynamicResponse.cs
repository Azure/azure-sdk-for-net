// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace Azure.Core
{
    /// <summary>
    /// Represents a result of Azure operation with a <see cref="JsonData"/> response.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class DynamicResponse : Response
    {
        private bool _disposed;

        private Response Response { get; }

        /// <summary>
        /// The JSON body of the response.
        /// </summary>
        public JsonData? Body { get; }

        /// <summary>
        /// The JSON body of the response.
        /// </summary>
        public dynamic? DynamicBody { get => Body; }

        /// <inheritdoc />
        public override int Status => Response.Status;
        /// <inheritdoc />
        public override string ReasonPhrase => Response.ReasonPhrase;
        /// <inheritdoc />
        public override Stream? ContentStream { get => Response.ContentStream; set => Response.ContentStream = value; }
        /// <inheritdoc />
        public override string ClientRequestId { get => Response.ClientRequestId; set => Response.ClientRequestId = value; }
        /// <inheritdoc />
        protected override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value) => Response.Headers.TryGetValue(name, out value);
        /// <inheritdoc />
        protected override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values) => Response.Headers.TryGetValues(name, out values);
        /// <inheritdoc />
        protected override bool ContainsHeader(string name) => Response.Headers.Contains(name);
        /// <inheritdoc />
        protected override IEnumerable<HttpHeader> EnumerateHeaders() => Response.Headers;

        /// <summary>
        /// Represents a result of Azure operation with a <see cref="JsonData"/> response.
        /// </summary>
        /// <param name="response">The response returned by the service.</param>
        /// <param name="body">The body returned by the service.</param>
        public DynamicResponse(Response response, JsonData? body)
        {
            Response = response;
            Body = body;
        }

        /// <summary>
        /// Frees resources held by the <see cref="DynamicResponse"/> object.
        /// </summary>
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Frees resources held by the <see cref="DynamicResponse"/> object.
        /// </summary>
        /// <param name="disposing">true if we should dispose, otherwise false</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                Response.Dispose();
            }
            _disposed = true;
        }

        private string DebuggerDisplay
        {
            get => $"{{Status: {Response.Status}, Body: {(Body == null ? "" : Body.ToJsonString())}}}";
        }
    }
}
