// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Iot.Hub.Service.Authentication
{
    /// <summary>
    /// Builds the shared access signature based on the access policy passed.
    /// </summary>
    internal class SharedAccessSignatureBuilder
    {
        internal string SharedAccessPolicy { get; set; }

        internal string SharedAccessKey { get; set; }

        internal string HostName { get; set; }

        internal TimeSpan TimeToLive { get; set; }

        internal string ToSignature()
        {
            return BuildSignature(SharedAccessPolicy, SharedAccessKey, HostName, TimeToLive);
        }

        private static string BuildSignature(string sharedAccessPolicy, string sharedAccessKey, string hostName, TimeSpan timeToLive)
        {
            string expiresOn = BuildExpiresOn(timeToLive);
            string audience = WebUtility.UrlEncode(hostName);
            var fields = new List<string>
            {
                audience,
                expiresOn
            };

            // Example string to be signed:
            // dh://myiothub.azure-devices.net/a/b/c?myvalue1=a
            // <Value for ExpiresOn>

            string signature = Sign(string.Join("\n", fields), sharedAccessKey);

            // Example returned string:
            // SharedAccessSignature sr=ENCODED(dh://myiothub.azure-devices.net/a/b/c?myvalue1=a)&sig=<Signature>&se=<ExpiresOnValue>[&skn=<KeyName>]

            var buffer = new StringBuilder();
            buffer.Append($"{SharedAccessSignatureConstants.SharedAccessSignatureIdentifier} " +
                $"{SharedAccessSignatureConstants.AudienceFieldName}={audience}" +
                $"&{SharedAccessSignatureConstants.SignatureFieldName}={WebUtility.UrlEncode(signature)}" +
                $"&{SharedAccessSignatureConstants.ExpiryFieldName}={WebUtility.UrlEncode(expiresOn)}");

            if (!string.IsNullOrWhiteSpace(sharedAccessPolicy))
            {
                buffer.Append($"&{SharedAccessSignatureConstants.KeyNameFieldName}={WebUtility.UrlEncode(sharedAccessPolicy)}");
            }

            return buffer.ToString();
        }

        private static string BuildExpiresOn(TimeSpan timeToLive)
        {
            DateTimeOffset expiresOn = DateTimeOffset.UtcNow.Add(timeToLive);
            TimeSpan secondsFromBaseTime = expiresOn.Subtract(SharedAccessSignatureConstants.s_epochTime);
            long seconds = Convert.ToInt64(secondsFromBaseTime.TotalSeconds, CultureInfo.InvariantCulture);
            return Convert.ToString(seconds, CultureInfo.InvariantCulture);
        }

        private static string Sign(string requestString, string key)
        {
            using (var hmac = new HMACSHA256(Convert.FromBase64String(key)))
            {
                return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(requestString)));
            }
        }
    }
}
