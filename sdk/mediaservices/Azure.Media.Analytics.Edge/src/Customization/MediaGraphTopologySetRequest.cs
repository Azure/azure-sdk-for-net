// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.Analytics.Edge.Models
{
    public partial class MediaGraphTopologySetRequest
    {
        private MediaGraphTopologySetRequestBody _graphBody;

        /// <summary>
        ///  Gets the Payload from the request result.
        /// </summary>
        /// <returns>A string containing the Payload. </returns>
        public override string GetPayloadAsJson()
        {
            _graphBody = new MediaGraphTopologySetRequestBody(Graph.Name);
            _graphBody.SystemData = Graph.SystemData;
            _graphBody.Properties = Graph.Properties;
            return _graphBody.GetPayloadAsJson();
        }
    }
}
