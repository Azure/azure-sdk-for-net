// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;

namespace Azure.Storage
{
    internal class StorageUserAgentPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly string _preappendUserAgent;

        public StorageUserAgentPolicy(string preappendUserAgent)
        {
            Argument.AssertNotNullOrWhiteSpace(preappendUserAgent, nameof(preappendUserAgent));
            // The extra information after the hash separator '+' is unnecessary to print out
            int hashSeparator = preappendUserAgent.IndexOf('+');
            if (hashSeparator != -1)
            {
                preappendUserAgent = preappendUserAgent.Substring(0, hashSeparator);
            }
            _preappendUserAgent = preappendUserAgent;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (message.Request.Headers.TryGetValue(HttpHeader.Names.UserAgent, out string userAgent) && !userAgent.Contains(_preappendUserAgent))
            {
                message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, TransformUserAgent(userAgent, _preappendUserAgent));
            }
            else // no user agent string present, just set the feature string as the whole user agent
            {
                message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, _preappendUserAgent);
            }
        }

        private static string TransformUserAgent(string userAgent, string injection)
        {
            if (string.IsNullOrEmpty(injection))
            {
                return userAgent;
            }
            return string.Join(" ", injection, userAgent);
        }
    }
}
