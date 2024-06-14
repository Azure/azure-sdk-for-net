// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Azure.Core;

namespace Azure.Storage.Shared
{
    internal class Smuggler : Response
    {
        private readonly Response _original;

        public Smuggler(Response original, Dictionary<string, string> cargo)
        {
            _original = original;
            Cargo = cargo;
        }

        public Dictionary<string, string> Cargo { get; } = new Dictionary<string, string>();

        public override int Status => _original.Status;
        public override string ReasonPhrase => _original.ReasonPhrase;
        public override Stream ContentStream { get => _original.ContentStream; set => _original.ContentStream = value; }
        public override string ClientRequestId { get => _original.ClientRequestId; set => _original.ClientRequestId = value; }
        public override void Dispose() => _original.Dispose();
        protected override bool ContainsHeader(string name) => TryGetHeader(name, out _);
        protected override IEnumerable<HttpHeader> EnumerateHeaders() => _original.Headers;
        protected override bool TryGetHeader(string name, out string value) => _original.Headers.TryGetValue(name, out value);
        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values) => _original.Headers.TryGetValues(name, out values);
        public override bool IsError => _original.IsError;
    }
}
