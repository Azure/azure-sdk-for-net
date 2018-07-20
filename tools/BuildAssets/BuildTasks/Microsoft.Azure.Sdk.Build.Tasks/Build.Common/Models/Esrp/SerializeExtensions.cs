// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Common.Models.Esrp
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    //using Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Scan;
    //using Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Sign;
    using Microsoft.Azure.Sdk.Build.Common.Models.Esrp.Scan;
    using Microsoft.Azure.Sdk.Build.Common.Models.Esrp.Sign;
    public static class SerializeExtensions
    {

        #region Sign
        //public static SignRequest FromSignManifestJson(string json) => JsonConvert.DeserializeObject<SignRequest>(json, SerializerConfig);

        //public static SignRequest FromSignManifestFile(string jsonFilePath)
        //{
        //    string fileContents = File.ReadAllText(jsonFilePath);
        //    return FromSignManifestJson(fileContents);
        //}

        public static string ToSignJson(this SignRequest self) => JsonConvert.SerializeObject(self, SerializerConfig);

        #endregion


        #region Scan
        //public static ScanFileRequest FromJson(string json) => JsonConvert.DeserializeObject<ScanFileRequest>(json, SerializerConfig);


        //public static ScanFileResponse FromJson(string json) => JsonConvert.DeserializeObject<ScanFileResponse>(json, QuickType.Converter.Settings);

        public static string ToScanJson(this ScanFileRequest self) => JsonConvert.SerializeObject(self, SerializerConfig);

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
