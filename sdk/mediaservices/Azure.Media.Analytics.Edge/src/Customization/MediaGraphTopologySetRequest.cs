// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.Analytics.Edge.Models
{
    /// <summary>
    ///  Represents the MediaGraphTopologyRequest body.
    /// </summary>
    public partial class MediaGraphTopologySetRequest
    {
        private MediaGraphTopologySetRequestBody graphBody;

        /// <summary>
        ///  Gets the Payload from the request result.
        /// </summary>
        /// <returns>A string containing the Payload. </returns>
        public override string GetPayloadAsJson()
        {
            graphBody = new MediaGraphTopologySetRequestBody(Graph.Name);
            graphBody.SystemData = Graph.SystemData;
            graphBody.Properties = Graph.Properties;
            return graphBody.GetPayloadAsJson();
        }
    }
}
