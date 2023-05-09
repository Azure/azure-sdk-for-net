// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        public override Stream? ContentStream { get => null; set => throw new System.NotImplementedException(); }
        public override string ClientRequestId { get => string.Empty; set => throw new System.NotImplementedException(); }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }

        protected internal override bool ContainsHeader(string name)
        {
            throw new System.NotImplementedException();
        }

        protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
        {
            throw new System.NotImplementedException();
        }

        protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
        {
            throw new System.NotImplementedException();
        }

        protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
        {
            throw new System.NotImplementedException();
        }
    }
}
