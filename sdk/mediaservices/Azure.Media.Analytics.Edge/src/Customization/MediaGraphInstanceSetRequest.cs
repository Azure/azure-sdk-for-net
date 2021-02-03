// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Media.Analytics.Edge.Models
{
    public partial class MediaGraphInstanceSetRequest
    {
        /// <summary>
        ///  Serialize .
        /// </summary>
        /// <returns>A String containing the Payload.</returns>
        public override string GetPayloadAsJson()
        {
            var instanceBody = new MediaGraphInstanceSetRequestBody(Instance.Name)
            {
                SystemData = Instance.SystemData,
                Properties = Instance.Properties
            };
            return instanceBody.GetPayloadAsJson();
        }
    }
}
