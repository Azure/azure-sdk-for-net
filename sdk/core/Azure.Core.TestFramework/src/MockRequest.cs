// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core.TestFramework
{
    public class MockRequest : Request
    {
        public MockRequest()
        {
            ClientRequestId = Guid.NewGuid().ToString();
        }

        private readonly DictionaryHeaders _headers = new();
        public bool IsDisposed { get; private set; }

        public override RequestContent Content
        {
            get { return base.Content; }
            set
            {
                base.Content = value;
            }
        }

        protected override void SetHeader(string name, string value) => _headers.SetHeader(name, value);

        protected override void AddHeader(string name, string value) => _headers.AddHeader(name, value);

        protected override bool TryGetHeader(string name, out string value) => _headers.TryGetHeader(name, out value);

        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values) => _headers.TryGetHeaderValues(name, out values);

        protected override bool ContainsHeader(string name) => _headers.TryGetHeaderValues(name, out _);

        protected override bool RemoveHeader(string name) => _headers.RemoveHeader(name);

        protected override IEnumerable<HttpHeader> EnumerateHeaders() => _headers.EnumerateHeaders();

        public override string ClientRequestId { get; set; }

        public override string ToString() => $"{Method} {Uri}";

        public override void Dispose()
        {
            IsDisposed = true;
        }
    }
}
