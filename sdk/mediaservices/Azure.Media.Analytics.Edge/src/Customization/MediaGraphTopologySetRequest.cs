// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.Analytics.Edge.Models
{
    public partial class MediaGraphTopologySetRequest
    {
        /// <summary>
        ///  Gets the Payload from the request result.
        /// </summary>
        /// <returns>A string containing the Payload. </returns>
        public override string GetPayloadAsJson()
        {
            var graphBody = new MediaGraphTopologySetRequestBody(Graph.Name)
            {
                SystemData = Graph.SystemData,
                Properties = Graph.Properties
            };
            return graphBody.GetPayloadAsJson();
        }
    }
}
