// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Media.Analytics.Edge.Models
{
    public partial class MediaGraphInstanceSetRequest
    {
        internal MediaGraphInstanceSetRequestBody InstanceBody;

        /// <summary>
        ///  Serialize .
        /// </summary>
        /// <returns>
        /// The method payload as a Json string.
        /// </returns>
        public override string GetPayloadAsJson()
        {
            InstanceBody = new MediaGraphInstanceSetRequestBody(Instance.Name);
            InstanceBody.SystemData = Instance.SystemData;
            InstanceBody.Properties = Instance.Properties;
            return InstanceBody.GetPayloadAsJson();
        }
    }
}
