// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public partial class PipelineTopologySetRequest
    {
        /// <summary>
        ///  Gets the Payload from the request result.
        /// </summary>
        /// <returns>A string containing the Payload.</returns>
        public override string GetPayloadAsJson()
        {
            var pipelineBody = new PipelineTopologySetRequestBody(PipelineTopology.Name)
            {
                SystemData = PipelineTopology.SystemData,
                Properties = PipelineTopology.Properties
            };
            return pipelineBody.GetPayloadAsJson();
        }
    }
}
