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
        // The following keys are used to parse the relevant fields from an IoT hub connection string.
        internal const string HostNameIdentifier = "HostName";
        internal const string SharedAccessKeyIdentifier = "SharedAccessKey";
        internal const string SharedAccessPolicyIdentifier = "SharedAccessKeyName";

        // The following keys are used for constructing the shared access signature token.
        // Example returned string:
        // SharedAccessSignature sr=<Audience>&sig=<Signature>&se=<ExpiresOnValue>[&skn=<KeyName>]
        internal const string SharedAccessSignatureIdentifier = "SharedAccessSignature";
        internal const string AudienceFieldName = "sr";
        internal const string SignatureFieldName = "sig";
        internal const string KeyNameFieldName = "skn";
        internal const string ExpiryFieldName = "se";

        // The Unix time representation of January 1, 1970 midnight UTC.
        internal static readonly DateTime s_epochTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    }
}
