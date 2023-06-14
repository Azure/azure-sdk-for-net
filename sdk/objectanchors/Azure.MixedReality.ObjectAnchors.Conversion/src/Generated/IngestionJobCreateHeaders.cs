// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    internal partial class IngestionJobCreateHeaders
    {
        private readonly Response _response;
        public IngestionJobCreateHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> The service response correlation vector, which will be a new value for every response. </summary>
        public string MsCv => _response.Headers.TryGetValue("ms-cv", out string value) ? value : null;
    }
}
