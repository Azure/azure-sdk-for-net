// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// Policy that transforms the standard "Range" request header to "x-ms-range"
    /// as expected by Azure Storage services.
    /// </summary>
    internal class RangeHeaderPolicy : HttpPipelineSynchronousPolicy
    {
        private const string RangeHeaderName = "Range";
        private const string XmsRangeHeaderName = "x-ms-range";

        public static RangeHeaderPolicy Shared { get; } = new();

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.Request.Headers.TryGetValue(RangeHeaderName, out string rangeValue))
            {
                message.Request.Headers.SetValue(XmsRangeHeaderName, rangeValue);
                message.Request.Headers.Remove(RangeHeaderName);
            }
        }
    }
}
