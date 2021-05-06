// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    internal class ArmVoidResponse : ArmResponse
    {
        private readonly Response _response;

        public ArmVoidResponse(Response response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            _response = response;
        }

        ///<inheritdoc />
        public override int Status => _response.Status;

        ///<inheritdoc />
        public override string ReasonPhrase => _response.ReasonPhrase;

        ///<inheritdoc />
        public override Stream ContentStream
        {
            get => _response.ContentStream;
            set => _response.ContentStream = value;
        }

        ///<inheritdoc />
        public override string ClientRequestId
        {
            get => _response.ClientRequestId;
            set => _response.ClientRequestId = value;
        }

        ///<inheritdoc />
        public override void Dispose() => _response.Dispose();

        ///<inheritdoc />
        protected override bool ContainsHeader(string name) => _response.Headers.Contains(name);

        ///<inheritdoc />
        protected override IEnumerable<HttpHeader> EnumerateHeaders() => _response.Headers;

        ///<inheritdoc />
        protected override bool TryGetHeader(string name, out string value) => _response.Headers.TryGetValue(name, out value);

        ///<inheritdoc />
        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values) => _response.Headers.TryGetValues(name, out values);
    }
}
