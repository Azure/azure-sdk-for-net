//==============================================================================
// Copyright (c) Microsoft Corporation. All Rights Reserved.
//==============================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.DataPipeline.Coordination.Contracts;
using Microsoft.DataPipeline.Metadata.JsonHelpers;
using Microsoft.DataPipeline.Metadata.ObjectModel;
using Microsoft.DataPipeline.TestFramework.Logging;
using Microsoft.DataPipeline.Utilities;
using Microsoft.ModernDataPipeline.ObjectModelExtensions.ExtensibleJsonConverters;
using Microsoft.ModernDataPipeline.ObjectModelExtensions.JsonHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.DataPipeline.TestFramework.JsonSamples
{
    public static class JsonSampleCommon
    {
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
            string apiVersion = ApiVersion.Latest,
            string factoryName = null)
        {
            var settings = new JsonSerializerSettings()
                               {
                                   MissingMemberHandling = MissingMemberHandling.Error,
                                   // Throw an error if the JSON includes invalid tokens that are not a part of the object.
                                   Formatting = Formatting.Indented,
                                   // indenting makes the JSON easier to read for manual troubleshooting.
                                   ContractResolver = new ExtensibleJsonContractResolver()
                               };

            if (DateTimeExtentions.ShouldEnforceIso8601DateTimeFormat(apiVersion))
            {
                settings.Converters.Add(new CustomIsoDateTimeConverter());
            }

            if (itemNameForContext != null)
            {
                JsonUtilities.AddNameToContext(settings, itemNameForContext);
            }

            if (factoryName != null)
            {
                JsonUtilities.AddDataFactoryNameToContext(settings, factoryName);
            }

            JsonUtilities.AddApiVersionToContext(settings, apiVersion);
            return settings;
        }

        /// <summary>
        /// Gets all JSON samples (public constant strings) defined in <typeparamref name="TSampleClass"/>
        /// </summary>
        /// <typeparam name="TSampleClass">contains JSON samples as public constants.</typeparam>
        /// <param name="jsonSampleType">The type of JSON samples to get.</param>
        /// <returns>JSON samples to test.</returns>
        public static IEnumerable<JsonSampleInfo> GetJsonSamplesFromType<TSampleClass>(JsonSampleType jsonSampleType = JsonSampleType.Both)
        {
            Type sampleType = typeof(TSampleClass);

            BindingFlags bindings = BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField;
            FieldInfo[] fieldInfos = sampleType.GetFields(bindings);

            Func<JsonSampleInfo, bool> predicate;
            
            IEnumerable<JsonSampleInfo> samples =
                    fieldInfos.Select(fieldInfo => GetJsonSampleInfo(sampleType, fieldInfo));
            if (jsonSampleType == JsonSampleType.Both)
            {
                // Return all samples, regardless of how they are designated
                return samples;
            }
            
            if (jsonSampleType == JsonSampleType.BackendOnly)
            {
                // Get samples that are marked as appropriate for both test types, 
                // or appropriate for backend tests only
                predicate = sample => sample.SampleType != JsonSampleType.ClientOnly;
            }
            else
            {
                // Get samples that are marked as appropriate for both test types, 
                // or appropriate for client tests only
                predicate = sample => sample.SampleType != JsonSampleType.BackendOnly;
            }

            return samples.Where(predicate);
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
            JsonSampleAttribute sampleAttribute = fieldInfo.GetCustomAttribute<JsonSampleAttribute>();
            if (sampleAttribute != null)
            {
                propertyBagKeys = sampleAttribute.PropertyBagKeys;
            }

            return new JsonSampleInfo(
                sampleName,
                json,
                sampleAttribute.Version,
                propertyBagKeys,
                sampleAttribute.SampleType);
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

            BindingFlags bindings = BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField;
            FieldInfo fieldInfo =
                sampleType.GetFields(bindings)
                    .FirstOrDefault(f => String.Equals(f.Name, name));

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
                    string.Format("Testing JSON sample #{0}: {1}", sampleCount, sampleInfo.Name));

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
            if (failureCount > 0)
            {
                Assert.Fail(failureCount + " of " + sampleCount + " samples failed. See test output for details.");
            }
        }

        public static string RemoveSchemaProperty(string json)
        {
            JObject temp = JObject.Parse(json);
            temp.Remove(GlobalConstants.SchemaPropertyName);
            return temp.ToString();
        }
    }
}
