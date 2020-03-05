// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    internal class AnalyzeReceiptAsyncHeaders
    {
        private readonly Azure.Response _response;
        public AnalyzeReceiptAsyncHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string OperationLocation => _response.Headers.TryGetValue("Operation-Location", out string value) ? value : null;
    }
}
