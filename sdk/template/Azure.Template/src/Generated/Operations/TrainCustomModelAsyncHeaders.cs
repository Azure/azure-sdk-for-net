// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    internal class TrainCustomModelAsyncHeaders
    {
        private readonly Azure.Response _response;
        public TrainCustomModelAsyncHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string Location => _response.Headers.TryGetValue("Location", out string value) ? value : null;
    }
}
