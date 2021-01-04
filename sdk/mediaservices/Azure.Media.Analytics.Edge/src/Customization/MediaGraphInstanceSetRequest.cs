// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Media.Analytics.Edge.Models
{
    /// <summary>
    ///  MediaGraphInstanceSetRequest model.
    /// </summary>
    public partial class MediaGraphInstanceSetRequest
    {
        /// <summary>
        ///  The GraphInstanceSet request Body.
        /// </summary>
        private MediaGraphInstanceSetRequestBody instanceBody;

        /// <summary>
        ///  Serialize .
        /// </summary>
        /// <returns>A String containing the Payload.</returns>
        public override string GetPayloadAsJson()
        {
            instanceBody = new MediaGraphInstanceSetRequestBody(Instance.Name);
            instanceBody.SystemData = Instance.SystemData;
            instanceBody.Properties = Instance.Properties;
            return instanceBody.GetPayloadAsJson();
        }
    }
}
