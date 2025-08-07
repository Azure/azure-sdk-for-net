// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    internal class DataMovementUserAgentPolicy : HttpPipelineSynchronousPolicy
    {
        private const string UserAgentIdentifier = "DataMovement/";
        private readonly string _version;

        public DataMovementUserAgentPolicy(string dataMovementVersion)
        {
            Argument.AssertNotNullOrWhiteSpace(dataMovementVersion, nameof(dataMovementVersion));
            // The extra information after the hash separator '+' is unnecessary to print out
            int hashSeparator = dataMovementVersion.IndexOf('+');
            if (hashSeparator != -1)
            {
                dataMovementVersion = dataMovementVersion.Substring(0, hashSeparator);
            }
            _version = dataMovementVersion;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            string dataMovementVersion = string.Concat(UserAgentIdentifier, _version);
            if (message.Request.Headers.TryGetValue(HttpHeader.Names.UserAgent, out string userAgent) && !userAgent.Contains(dataMovementVersion))
            {
                message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, TransformUserAgent(userAgent, dataMovementVersion));
            }
            else // no user agent string present, just set the feature string as the whole user agent
            {
                message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, dataMovementVersion);
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
