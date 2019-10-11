// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    internal class CustomHeadersPolicy : HttpPipelineSynchronousPolicy
    {
        private const string ActivityId = "Azure.CustomDiagnosticHeaders";

        private static readonly Dictionary<string, bool> SupportedHeaders = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase)
        {
            { "x-ms-client-request-id", true },
            { "x-ms-correlation-request-id", false },
            { "correlation-context", false }
        };

        public override void OnSendingRequest(HttpMessage message)
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
                        // ClientRequestId policy will set the header from this Request property
                        message.Request.ClientRequestId = tag.Value;
                    }
                    else
                    {
                        message.Request.Headers.Add(tag.Key, tag.Value);
                    }
                }
            }
        }
    }
}
