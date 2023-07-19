// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public partial class RemoteDeviceAdapterSetRequest
    {
        /// <summary>
        ///  Gets the Payload from the request result.
        /// </summary>
        /// <returns>A string containing the Payload.</returns>
        public override string GetPayloadAsJson()
        {
            var remoteDeviceAdapter = new RemoteDeviceAdapterSetRequestBody(RemoteDeviceAdapter.Name)
            {
                SystemData = RemoteDeviceAdapter.SystemData,
                Properties = RemoteDeviceAdapter.Properties
            };
            return remoteDeviceAdapter.GetPayloadAsJson();
        }
    }
}
