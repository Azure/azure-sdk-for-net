// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Search.Documents.Pipeline
{
    /// <summary>
    /// Sets the Accept HTTP header.
    /// </summary>
    internal class OdataMetadataPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _acceptValue;

        private OdataMetadataPolicy(string level)
        {
            _acceptValue = "application/json; odata.metadata=" + level;
        }

        /// <summary>
        /// Gets a new <see cref="OdataMetadataPolicy"/> that sets Accept to "application/json;odata.metadata=none".
        /// </summary>
        public static OdataMetadataPolicy None => new OdataMetadataPolicy("none");

        /// <summary>
        /// Gets a new <see cref="OdataMetadataPolicy"/> that sets Accept to "application/json;odata.metadata=minimal".
        /// </summary>
        public static OdataMetadataPolicy Minimal => new OdataMetadataPolicy("minimal");

        /// <inheritdoc/>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);
            message.Request.Headers.SetValue(HttpHeader.Names.Accept, _acceptValue);
        }
    }
}
