// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.Configuration
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Microsoft.WindowsAzure.Management.Configuration.Data;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json;

    internal class PayloadConverter
    {
        public ComponentSettingAddress DeSerializeComponentSettingAddresses(string payload)
        {
            payload.ArgumentNotNullOrEmpty("payload");

            var componentSettingAddresses = new ComponentSettingAddress();

            var bytes = Encoding.UTF8.GetBytes(payload);
            using (var memoryStream = new MemoryStream(bytes))
            {
                var jsonParser = new JsonParser(memoryStream);
                var jsonItem = jsonParser.ParseNext();

                var rootCallObject = jsonItem as JsonObject;
                if (rootCallObject == null)
                {
                    return componentSettingAddresses;
                }

                var componentSettingsArray = rootCallObject.GetProperty("items") as JsonArray;
                if (componentSettingsArray == null)
                {
                    return componentSettingAddresses;
                }

                for (int index = 0; index < componentSettingsArray.Count(); index++)
                {
                    var componentObject = componentSettingsArray.GetIndex(index);
                    var type = GetJsonStringValue(componentObject.GetProperty("type"));
                    var href = GetJsonStringValue(componentObject.GetProperty("href"));
                    SetComponentUri(type, componentSettingAddresses, href);
                }
            }

            return componentSettingAddresses;
        }

        public CoreSiteConfigurationCollection DeserializeCoreSettings(string payload)
        {
            var coreSite = new CoreSiteConfigurationCollection();
            coreSite.AddRange(this.DeserializeSettingsCollection(payload));
            return coreSite;
        }

        public TSettingType DeserializeSettingsCollection<TSettingType>(string payload) where TSettingType : ConfigurationPropertyCollection, new()
        {
            var coreSite = new TSettingType();
            coreSite.AddRange(this.DeserializeSettingsCollection(payload));
            return coreSite;
        }

        private IEnumerable<KeyValuePair<string, string>> DeserializeSettingsCollection(string payload)
        {
            var bytes = Encoding.UTF8.GetBytes(payload);
            using (var memoryStream = new MemoryStream(bytes))
            {
                var jsonParser = new JsonParser(memoryStream);
                var jsonItem = jsonParser.ParseNext();

                var rootCallObject = jsonItem as JsonObject;
                if (rootCallObject == null)
                {
                    return Enumerable.Empty<KeyValuePair<string, string>>();
                }

                var itemsArray = rootCallObject.GetProperty("items") as JsonArray;
                if (itemsArray == null)
                {
                    return Enumerable.Empty<KeyValuePair<string, string>>();
                }

                var componentSettings = itemsArray.GetIndex(0) as JsonObject;
                if (componentSettings == null)
                {
                    return Enumerable.Empty<KeyValuePair<string, string>>();
                }

                var properties = componentSettings.GetProperty("properties") as JsonObject;
                if (properties == null)
                {
                    return Enumerable.Empty<KeyValuePair<string, string>>();
                }

                return this.GetConfigurationPropertyCollection(properties);
            }
        }

        private IEnumerable<KeyValuePair<string, string>> GetConfigurationPropertyCollection(JsonObject properties)
        {
            return properties.Properties.Select(prop => new KeyValuePair<string, string>(prop.Key, GetJsonStringValue(prop.Value)));
        }

        private static void SetComponentUri(string type, ComponentSettingAddress componentSettingAddresses, string href)
        {
            switch (type)
            {
                case "core-site":
                    componentSettingAddresses.Core = new Uri(href);
                    break;

                case "hdfs-site":
                    componentSettingAddresses.Hdfs = new Uri(href);
                    break;

                case "mapred-site":
                    componentSettingAddresses.MapReduce = new Uri(href);
                    break;

                case "hive-site":
                    componentSettingAddresses.Hive = new Uri(href);
                    break;

                case "oozie-site":
                    componentSettingAddresses.Oozie = new Uri(href);
                    break;
            }
        }

        private static string GetJsonStringValue(JsonItem item)
        {
            string value;
            item.TryGetValue(out value);
            return value;
        }
    }
}
