// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// Defines the protocols permitted for Storage requests made with a shared
    /// access signature.
    /// </summary>
    public enum TableSasProtocol
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
}
