// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts
{
    internal partial class DataFlowDebugSessionExecuteCommandHeaders
    {
        private readonly Response _response;
        public DataFlowDebugSessionExecuteCommandHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> URI to poll for asynchronous operation status. </summary>
        public string Location => _response.Headers.TryGetValue("location", out string value) ? value : null;
    }
}
