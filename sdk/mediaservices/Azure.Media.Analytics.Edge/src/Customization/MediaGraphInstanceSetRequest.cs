// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Media.Analytics.Edge.Models
{
    public partial class MediaGraphInstanceSetRequest
    {
        private MediaGraphInstanceSetRequestBody _instanceBody;

        /// <summary>
        ///  Serialize .
        /// </summary>
        /// <returns>A String containing the Payload.</returns>
        public override string GetPayloadAsJson()
        {
            _instanceBody = new MediaGraphInstanceSetRequestBody(Instance.Name);
            _instanceBody.SystemData = Instance.SystemData;
            _instanceBody.Properties = Instance.Properties;
            return _instanceBody.GetPayloadAsJson();
        }
    }
}
