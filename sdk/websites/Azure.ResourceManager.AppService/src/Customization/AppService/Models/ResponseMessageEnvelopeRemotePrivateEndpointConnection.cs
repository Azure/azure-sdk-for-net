// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AppService.Models
{
    public partial class ResponseMessageEnvelopeRemotePrivateEndpointConnection
    {
        /// <summary> Azure-AsyncOperation Error info. </summary>
        [WirePath("error")]
        public ResponseError Error { get; }
    }
}
