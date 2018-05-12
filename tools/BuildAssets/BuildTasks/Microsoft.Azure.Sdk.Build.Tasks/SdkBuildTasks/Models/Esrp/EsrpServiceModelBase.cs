// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp
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

    public class EsrpServiceModelBase<T> where T: class
    {
        private static JsonSerializerSettings _esrpModelSerializerSetting;
        private static JsonSerializerSettings _esrpModelDeSerializerSetting;

        protected static JsonSerializerSettings EsrpModelSerializerSetting
        {
            get
            {
                if (_esrpModelSerializerSetting == null)
                {
                    _esrpModelSerializerSetting = new JsonSerializerSettings
                    {
                        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                        DateParseHandling = DateParseHandling.None,
                        Converters = {
                            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                        },
                    };
                }

                return _esrpModelSerializerSetting;
            }

            set
            {
                _esrpModelSerializerSetting = value;
            }
        }

        protected static JsonSerializerSettings EsrpModelDeSerializerSetting
        {
            get
            {
                if (_esrpModelSerializerSetting == null)
                {
                    _esrpModelSerializerSetting = new JsonSerializerSettings
                    {
                        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                        DateParseHandling = DateParseHandling.None,
                        Converters = {
                            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                        },
                    };
                }

                return _esrpModelDeSerializerSetting;
            }

            set
            {
                _esrpModelDeSerializerSetting = value;
            }
        }

        public EsrpServiceModelBase()
        {

        }



        public static T FromJson(string json) => JsonConvert.DeserializeObject<T>(json, EsrpModelDeSerializerSetting);

        public static T FromJsonFile(string jsonFilePath) => FromJson(File.ReadAllText(jsonFilePath));

        public string ToJson() => JsonConvert.SerializeObject(this, EsrpModelSerializerSetting);


    }
}
