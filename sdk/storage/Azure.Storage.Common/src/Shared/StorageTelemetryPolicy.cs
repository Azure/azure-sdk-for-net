// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    internal class StorageTelemetryPolicy : HttpPipelineSynchronousPolicy
    {
        private const string CseIdentifierV2 = "azstorage-clientsideencryption/2.0";
        private const string CseIdentifierV1 = "azstorage-clientsideencryption/1.0";

        [Flags]
        private enum AzFeatures
        {
            None = 0,
            CseV1 = 1,
            CseV2 = 2,
        }

        private StorageTelemetryPolicy()
        {
        }

        public static StorageTelemetryPolicy Shared { get; } = new StorageTelemetryPolicy();

        public override void OnSendingRequest(HttpMessage message)
        {
            AzFeatures azFeatures = AzFeatures.None;
            if (message.TryGetProperty(Constants.ClientSideEncryption.HttpMessagePropertyKeyV2, out _))
            {
                azFeatures |= AzFeatures.CseV2;
            }
            else if (message.TryGetProperty(Constants.ClientSideEncryption.HttpMessagePropertyKeyV1, out _))
            {
                azFeatures |= AzFeatures.CseV1;
            }

            if (azFeatures != AzFeatures.None)
            {
                ApplyAzFeatures(message, azFeatures);
            }
        }

        private static void ApplyAzFeatures(HttpMessage message, AzFeatures azFeatures)
        {
            string azFeatureString = Serialize(azFeatures);
            if (message.Request.Headers.TryGetValue(HttpHeader.Names.UserAgent, out string userAgent) && !userAgent.Contains(azFeatureString))
            {
                message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, TransformUserAgent(userAgent, azFeatureString));
            }
            else // no user agent string present, just set the feature string as the whole user agent
            {
                message.Request.Headers.SetValue(HttpHeader.Names.UserAgent, azFeatureString);
            }
        }

        private static string Serialize(AzFeatures azFeatures)
        {
            // currently only support specific CSE strings. This will be generalized in the future.
            if ((azFeatures & AzFeatures.CseV2) == AzFeatures.CseV2)
            {
                return CseIdentifierV2;
            }
            if ((azFeatures & AzFeatures.CseV1) == AzFeatures.CseV1)
            {
                return CseIdentifierV1;
            }
            return "";
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
