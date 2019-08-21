// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Core.Pipeline
{
    public class ActivityRequestIdHeadersPolicy : SynchronousHttpPipelinePolicy
    {
        private const string ActivityId = "Azure.RequestId";

        private static readonly Dictionary<string, bool> SupportedHeaders = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase)
        {
            {"x-ms-client-request-id", true},
            {"x-ms-request-id", false},
            {"x-ms-correlation-request-id", false}
        };

        public override void OnSendingRequest(HttpPipelineMessage message)
        {
            Activity activity = Activity.Current;
            while (activity != null && activity.OperationName != ActivityId)
            {
                activity = activity.Parent;
            }

            if (activity == null)
            {
                return;
            }

            foreach (KeyValuePair<string, string> tag in activity.Tags)
            {
                if (SupportedHeaders.TryGetValue(tag.Key, out bool isClientRequestId))
                {
                    if (isClientRequestId)
                    {
                        // ClientRequestId policy would set the actual header
                        message.Request.ClientRequestId = tag.Value;
                    }
                    else
                    {
                        message.Request.SetHeader(tag.Key, tag.Value);
                    }
                }
            }

        }
    }
}
