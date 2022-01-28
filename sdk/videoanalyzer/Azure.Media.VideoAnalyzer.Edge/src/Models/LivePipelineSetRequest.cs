// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public partial class LivePipelineSetRequest
    {
        /// <summary>
        ///  Gets the Payload from the request result.
        /// </summary>
        /// <returns>A string containing the Payload.</returns>
        public override string GetPayloadAsJson()
        {
            var instanceBody = new LivePipelineSetRequestBody(LivePipeline.Name)
            {
                SystemData = LivePipeline.SystemData,
                Properties = LivePipeline.Properties
            };
            return instanceBody.GetPayloadAsJson();
        }
    }
}
