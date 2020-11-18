// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    public partial class MediaGraphInstanceSetRequest
    {
        internal MediaGraphInstanceSetRequestBody InstanceBody;

        /// <summary>
        ///  Serialize .
        /// </summary>
        /// <returns></returns>
        public override string GetPayloadAsJSON()
        {
            InstanceBody = new MediaGraphInstanceSetRequestBody(Instance.Name);
            InstanceBody.SystemData = Instance.SystemData;
            InstanceBody.Properties = Instance.Properties;
            return InstanceBody.GetPayloadAsJSON();
        }
    }
}
