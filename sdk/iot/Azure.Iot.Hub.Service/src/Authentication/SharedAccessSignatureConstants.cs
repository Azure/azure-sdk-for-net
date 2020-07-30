// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Iot.Hub.Service.Authentication
{
    /// <summary>
    /// The constants used for building the IoT hub service shared access signature token.
    /// </summary>
    internal static class SharedAccessSignatureConstants
    {
        internal const int MaxKeyNameLength = 256;
        internal const int MaxKeyLength = 256;
        internal const string SharedAccessSignatureIdentifier = "SharedAccessSignature";
        internal const string HostNameIdentifier = "HostName";
        internal const string SharedAccessKeyIdentifier = "SharedAccessKey";
        internal const string SharedAccessPolicyIdentifier = "SharedAccessKeyName";
        internal const string AudienceFieldName = "sr";
        internal const string SignatureFieldName = "sig";
        internal const string KeyNameFieldName = "skn";
        internal const string ExpiryFieldName = "se";
        internal const string SignedResourceFullFieldName = SharedAccessSignatureIdentifier + " " + AudienceFieldName;
        internal const string KeyValueSeparator = "=";
        internal const string PairSeparator = "&";
        internal static readonly DateTime EpochTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        internal static readonly TimeSpan MaxClockSkew = TimeSpan.FromMinutes(5);
    }
}
