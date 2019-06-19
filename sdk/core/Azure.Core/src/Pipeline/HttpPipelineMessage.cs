// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Core.Pipeline
{
    public class HttpPipelineMessage
    {
        private Dictionary<string, object> _properties;

        public CancellationToken CancellationToken { get; }

        public HttpPipelineMessage(CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
        }

        public Request Request { get; set; }

        public Response Response { get; set; }

        public ResponseClassifier ResponseClassifier { get; set; }

        public bool TryGetProperty(string name, out object value)
        {
            value = null;
            return _properties?.TryGetValue(name, out value) == true;
        }

        public void SetProperty(string name, object value)
        {
            _properties ??= new Dictionary<string, object>();

            _properties[name] = value;
        }
    }
}
