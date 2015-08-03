// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DataFactory.Tests.Framework
{
    public static class JsonSampleCommon
    {
        private const BindingFlags DefaultBindings = BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField;

        /// <summary>
        /// Gets JSON.NET serializer settings for test usage.
        /// </summary>
        /// <param name="includeActivityConverter"></param>
        /// <param name="includeLinkedServiceConverter"></param>
        /// <param name="itemNameForContext"></param>
        /// <returns></returns>
        public static JsonSerializerSettings GetSerializerSettings(
            bool includeActivityConverter = false,
            bool includeLinkedServiceConverter = false,
            string itemNameForContext = null,
            string factoryName = null)
        {
            var settings = new JsonSerializerSettings()
                               {
                                   // Throw an error if the JSON includes invalid tokens that are not a part of the object.
                                   MissingMemberHandling = MissingMemberHandling.Error,
                                   Formatting = Formatting.Indented,
                               };

            settings.Converters.Add(new CustomIsoDateTimeConverter());

            return settings;
        }

        /// <summary>
        /// Gets all JSON samples (public constant strings) defined in <typeparamref name="TSampleClass"/>
        /// </summary>
        /// <typeparam name="TSampleClass">contains JSON samples as public constants.</typeparam>
        /// <returns>JSON samples to test.</returns>
        public static IEnumerable<JsonSampleInfo> GetJsonSamplesFromType<TSampleClass>()
        {
            Type sampleType = typeof(TSampleClass);
            FieldInfo[] fieldInfos = sampleType.GetFields(DefaultBindings);

            return fieldInfos.Select(fieldInfo => GetJsonSampleInfo(sampleType, fieldInfo));
        }

        /// <summary>
        /// Gets all JSON samples from the files in the given folder.
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public static IEnumerable<JsonSampleInfo> GetJsonSamplesFromFolder(string folder)
        {
            foreach (string fileName in Directory.GetFiles(folder))
            {
                string json = File.ReadAllText(fileName);
                JsonSampleInfo info = new JsonSampleInfo(fileName, json, null);
                if (fileName.Contains("DP_AzureMLSqlReaderSqlWriter.json"))
                {
                    HashSet<string> propertyBagKeys = new HashSet<string>() 
                    {             
                        "properties.activities[0].transformation.webServiceParameters.Database server name1",
                        "properties.activities[0].transformation.webServiceParameters.Database name1",
                        "properties.activities[0].transformation.webServiceParameters.Server user account name1",
                        "properties.activities[0].transformation.webServiceParameters.Server user account password1",
                        "properties.activities[0].transformation.webServiceParameters.Comma separated list of columns to be saved",
                        "properties.activities[0].transformation.webServiceParameters.Data table name"
                    };
                    info.PropertyBagKeys = propertyBagKeys;
                }

                yield return info;
            }
        }

        /// <summary>
        /// Get a JSON sample of type <paramref name="sampleType"/> for the field <paramref name="fieldInfo"/>.
        /// </summary>
        /// <param name="sampleType">The type of the JSON sample.</param>
        /// <param name="fieldInfo">Info about the JSON sample field.</param>
        /// <returns>Info about the JSON sample.</returns>
        public static JsonSampleInfo GetJsonSampleInfo(Type sampleType, FieldInfo fieldInfo)
        {
            string sampleName = sampleType.Name + "." + fieldInfo.Name;
            string json = fieldInfo.GetRawConstantValue().ToString();

            HashSet<string> propertyBagKeys = null;
            string version = null;

            JsonSampleAttribute sampleAttribute = fieldInfo.GetCustomAttribute<JsonSampleAttribute>();
            if (sampleAttribute != null)
            {
                propertyBagKeys = sampleAttribute.PropertyBagKeys;
                version = sampleAttribute.Version;
            }

            return new JsonSampleInfo(sampleName, json, version, propertyBagKeys);
        }

        /// <summary>
        /// Get a JSON sample defined in <typeparamref name="TSampleClass"/> with name <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="TSampleClass">Contains JSON samples as public constants.</typeparam>
        /// <param name="name">The name of the JSON constant.</param>
        /// <returns>Info about the JSON sample.</returns>
        public static JsonSampleInfo GetJsonSample<TSampleClass>(string name)
        {
            Type sampleType = typeof(TSampleClass);
            FieldInfo fieldInfo = sampleType.GetFields(DefaultBindings).FirstOrDefault(f => String.Equals(f.Name, name));
            if (fieldInfo == null)
            {
                throw new ArgumentException(@"No JSON sample found with name " + name, "name");
            }
            
            return GetJsonSampleInfo(sampleType, fieldInfo);
        }

        /// <summary>
        /// Tests each of the given JSON samples using the given test method. If an error occurs when testing a 
        /// sample, the error is logged and then the remaining samples are tested. Once all samples have been tested,
        /// an Assert.Fail is triggered if any of the samples failed.
        /// </summary>
        public static void TestJsonSamples(IEnumerable<JsonSampleInfo> samples, Action<JsonSampleInfo> testMethod)
        {
            int failureCount = 0;
            int sampleCount = 0;
            foreach (JsonSampleInfo sampleInfo in samples)
            {
                string sampleName = sampleInfo.Name;
                sampleCount++;
                AdfTestLogger.LogInformation(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Testing JSON sample #{0}: {1}",
                        sampleCount,
                        sampleInfo.Name));

                try
                {
                    testMethod(sampleInfo);
                    AdfTestLogger.LogInformation(sampleName + " PASSED");
                }
                catch (Exception ex)
                {
                    // When a sample test fails, log the exception and then continue testing the remaining samples.
                    AdfTestLogger.LogInformation(
                        string.Format(
                            "{0} FAILED: Exception: {1}{2}{3} JSON:{4}{5}",
                            sampleName,
                            ex,
                            Environment.NewLine,
                            sampleName,
                            Environment.NewLine,
                            sampleInfo.Json));
                    failureCount++;
                }
            }

            // Fail the test if any of the samples failed.
            Assert.False(failureCount > 0, string.Format(
                    CultureInfo.InvariantCulture,
                    "{0} of {1} samples failed. See test output for details.",
                    failureCount,
                    sampleCount));
        }

        public static void TestJsonSample(JsonSampleInfo sampleInfo, Action<JsonSampleInfo> testMethod)
        {
            AdfTestLogger.LogInformation(string.Format(
                CultureInfo.InvariantCulture,
                "Testing JSON sample '{0}': {1}",
                sampleInfo.Name,
                sampleInfo.Json));

            testMethod(sampleInfo);
        }

        public static string RemoveSchemaProperty(string json)
        {
            JObject temp = JObject.Parse(json);
            temp.Remove(Common.SchemaPropertyName);
            return temp.ToString();
        }
    }
}
