// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Defines the protocols permitted for Storage requests made with a shared
    /// access signature.
    /// </summary>
    public enum SasProtocol
    {
        /// <summary>
        /// No protocol has been specified. If no value is specified,
        /// the service will default to HttpsAndHttp.
        /// </summary>
        None = 0,
        /// <summary>
        /// Only requests issued over HTTPS or HTTP will be permitted.
        /// </summary>
        HttpsAndHttp = 1,

        /// <summary>
        /// Only requests issued over HTTPS will be permitted.
        /// </summary>
        Https = 2
    }

    /// <summary>
    /// Extension methods for AccountSasResourceTypes enum
    /// </summary>
    internal static partial class SasExtensions
    {
        private const string NoneName = null;
        private const string HttpsName = "https";
        private const string HttpsAndHttpName = "https,http";

        /// <summary>
        /// Gets a string representation of the protocol.
        /// </summary>
        /// <returns>A string representation of the protocol.</returns>
        internal static string ToProtocolString(this SasProtocol protocol)
        {
            switch (protocol)
            {
                case SasProtocol.Https:
                    return HttpsName;
                case SasProtocol.HttpsAndHttp:
                    return HttpsAndHttpName;
                case SasProtocol.None:
                default:
                    return null;
            }
        }

        /// <summary>
        /// Parse a string representation of a protocol.
        /// </summary>
        /// <param name="s">A string representation of a protocol.</param>
        /// <returns>A <see cref="SasProtocol"/>.</returns>
        public static SasProtocol ParseProtocol(string s)
        {
            switch (s)
            {
                case NoneName:
                case "":
                    return SasProtocol.None;
                case HttpsName:
                    return SasProtocol.Https;
                case HttpsAndHttpName:
                    return SasProtocol.HttpsAndHttp;
                default:
                    throw Errors.InvalidSasProtocol(nameof(s), nameof(SasProtocol));
            }
        }
    }
}
