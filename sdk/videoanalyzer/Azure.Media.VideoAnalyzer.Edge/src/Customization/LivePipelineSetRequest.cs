// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public partial class LivePipelineSetRequest
    {
        /// <summary>
        ///  Serialize .
        /// </summary>
        /// <returns>A String containing the Payload.</returns>
        public override string GetPayloadAsJson()
        {
            var livePipelineBody = new LivePipelineSetRequestBody(LivePipeline.Name)
            {
                SystemData = LivePipeline.SystemData,
                Properties = LivePipeline.Properties
            };
            return livePipelineBody.GetPayloadAsJson();
        }
    }
}
