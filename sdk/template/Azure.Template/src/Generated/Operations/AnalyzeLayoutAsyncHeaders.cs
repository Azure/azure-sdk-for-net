// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.Template
{
    internal class AnalyzeLayoutAsyncHeaders
    {
        private readonly Azure.Response _response;
        public AnalyzeLayoutAsyncHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string OperationLocation => _response.Headers.TryGetValue("Operation-Location", out string value) ? value : null;
    }
}
