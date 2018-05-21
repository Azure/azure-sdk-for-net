// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp
{
    using Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Scan;
    using Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Sign;
    using Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.SignClient;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Globalization;

    public static class SerializeExtensions
    {
        #region Sign
        public static string ToSignJson(this SignRequest self) => JsonConvert.SerializeObject(self, SerializerConfig);
        #endregion


        #region Scan
        public static string ToScanJson(this ScanFileRequest self) => JsonConvert.SerializeObject(self, SerializerConfig);
        #endregion

        #region SignClientCertAuthConfig
        public static string ToSignClientCertAuthConfigJson(this SignClientCertAuthConfig self) => JsonConvert.SerializeObject(self, SerializerConfig);
        #endregion

        #region SignClientConfig
        public static string ToSignClientConfigJson(this SignClientConfig self) => JsonConvert.SerializeObject(self, SerializerConfig);
        #endregion


        #region SignClientPolicyConfig
        public static string ToSignClientAuthConfigJson(this SignClientPolicyConfig self) => JsonConvert.SerializeObject(self, SerializerConfig);
        #endregion


        public static readonly JsonSerializerSettings SerializerConfig = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

    }
}
