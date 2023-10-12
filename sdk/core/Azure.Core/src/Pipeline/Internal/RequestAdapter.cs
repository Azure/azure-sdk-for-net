// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel.Rest.Core;

namespace Azure.Core
{
    internal class RequestAdapter : Request
    {
        private readonly PipelineRequest _request;

        public RequestAdapter(PipelineRequest request)
        {
            _request = request;
        }

        internal PipelineRequest PipelineRequest => _request;

        public override RequestMethod Method
        {
            get => RequestMethod.Parse(_request.Method);
            set => _request.Method = value.Method;
        }

        public override void Dispose() => _request.Dispose();

        protected internal override void AddHeader(string name, string value)
        {
            throw new NotImplementedException();
        }

        protected internal override bool ContainsHeader(string name)
        {
            throw new NotImplementedException();
        }

        protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
        {
            throw new NotImplementedException();
        }

        protected internal override bool RemoveHeader(string name)
        {
            throw new NotImplementedException();
        }

        protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
        {
            throw new NotImplementedException();
        }

        protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
        {
            throw new NotImplementedException();
        }
    }
}
