// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;

namespace Azure.Core
{
    internal class EmptyResponse : Response
    {
        public EmptyResponse(HttpStatusCode status)
        {
            Status = (int)status;
            ReasonPhrase = status.ToString();
        }

        public override int Status { get; }

        public override string ReasonPhrase { get; }

        public override Stream ContentStream { get => null; set => throw new System.NotImplementedException(); }
        public override string ClientRequestId { get => string.Empty; set => throw new System.NotImplementedException(); }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override bool ContainsHeader(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override IEnumerable<HttpHeader> EnumerateHeaders()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override bool TryGetHeader(string name, out string value)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
        {
            throw new System.NotImplementedException();
        }
    }
}
