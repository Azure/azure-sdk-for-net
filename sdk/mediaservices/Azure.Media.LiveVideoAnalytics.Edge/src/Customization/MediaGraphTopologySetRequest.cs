// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    public partial class MediaGraphTopologySetRequest
    {
        internal MediaGraphTopologySetRequestBody GraphBody;

        /// <summary>
        ///  Serialize .
        /// </summary>
        /// <returns></returns>
        public override string GetPayloadAsJson()
        {
            GraphBody = new MediaGraphTopologySetRequestBody(Graph.Name);
            GraphBody.SystemData = Graph.SystemData;
            GraphBody.Properties = Graph.Properties;
            return GraphBody.GetPayloadAsJson();
        }
    }
}
