// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace DataFactory.Tests.UnitTests
{
    public class BaseUnitTest
    {
        private class TestDataFactoryManagementClient : DataFactoryManagementClient
        {
            internal TestDataFactoryManagementClient(params DelegatingHandler[] handlers) : base(handlers)
            {
                // Allow unit tests to bypass credentials when providing a delegating handler
            }
        }

        /// <summary>
        /// Test resourcegroup name for integration account
        /// </summary>
        protected static string ResourceGroupName = Constants.DefaultResourceGroup;

        /// <summary>
        /// Empty content string
        /// </summary>
        protected StringContent Empty = new StringContent(string.Empty);

        /// <summary>
        /// Output folder, override to turn on diagnostic text file output from tests.
        /// </summary>
        protected virtual string OutputFolder { get { return null; } }

        /// <summary>
        /// Write a diagnostic text file from tests to OutputFolder if non-null.
        /// </summary>
        /// <param name="text">Text to write, typically json.</param>
        /// <param name="fileName">Name of file within OutputFolder</param>
        protected void WriteTextFile(string text, string fileName)
        {
            if (OutputFolder != null)
            {
                Directory.CreateDirectory(OutputFolder);
                File.WriteAllText(Path.Combine(OutputFolder, fileName), text);
            }
        }

        /// <summary>
        /// Tests each of the given JSON samples via serialization/deserialization. If an error occurs when testing a 
        /// sample, the error is logged and then the remaining samples are tested. Once all samples have been tested,
        /// an exception would be thrown if any of the samples failed.
        /// </summary>
        /// <typeparam name="TSample">JSON sample class</typeparam>
        /// <typeparam name="TResource">JSON sample type</typeparam>
        public void TestJsonSamples<TSample, TResource>(ITestOutputHelper logger)
        {
            int failureCount = 0;
            int sampleCount = 0;            
            IEnumerable<JsonSampleInfo> samples = JsonSampleCommon.GetJsonSamplesFromType<TSample>();

            foreach (JsonSampleInfo sampleInfo in samples)
            {
                string sampleName = sampleInfo.Name;
                string serializedJson = string.Empty;
                sampleCount++;
                logger.WriteLine
                (
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Testing JSON sample #{0}: {1}",
                        sampleCount,
                        sampleInfo.Name));

                try
                {
                    TestJsonSample<TResource>(sampleInfo);
                    logger.WriteLine(sampleName + " PASSED");
                }
                catch (Exception ex)
                {
                    // When a sample test fails, log the exception and then continue testing the remaining samples.
                    logger.WriteLine(
                        string.Format(
                            "{0} FAILED: Exception: {1}{2}{3} JSON:{4}{5}{6}",
                            sampleName,
                            ex,
                            Environment.NewLine,
                            sampleName,
                            Environment.NewLine,
                            sampleInfo.Json,
                            serializedJson));
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

        public JsonSerializerSettings GetFullSerializerSettings(IDataFactoryManagementClient client, bool includeNulls = false)
        {
            // Issue: The client's serializer ignores read-only properties like resource Name and Id, and also ignores nulls.
            // That's fine for serializing requests, but not for serializing responses or testing JSON round-trip through OM.
            // So, we make our own serializer that differs from the client's only in that it also serializes read-only properties,
            // and optionally also serializes nulls.
            JsonSerializerSettings fullSerializationSettings = new JsonSerializerSettings
            {
                Formatting = client.SerializationSettings.Formatting,
                DateFormatHandling = client.SerializationSettings.DateFormatHandling,
                DateTimeZoneHandling = client.SerializationSettings.DateTimeZoneHandling,
                NullValueHandling = includeNulls? NullValueHandling.Include : client.SerializationSettings.NullValueHandling,
                ReferenceLoopHandling = client.SerializationSettings.ReferenceLoopHandling,
                ContractResolver = new DefaultContractResolver(), // not the one that drops read-only properties
                Converters = client.SerializationSettings.Converters
            };
            return fullSerializationSettings;
        }

        public void TestJsonSample<TResource>(JsonSampleInfo sampleInfo)
        {
            RecordedDelegatingHandler handler = new RecordedDelegatingHandler();
            IDataFactoryManagementClient client = this.CreateWorkflowClient(handler);
            string serializedJson;
            TResource resource = SafeJsonConvert.DeserializeObject<TResource>(sampleInfo.Json, client.DeserializationSettings);
            serializedJson = SafeJsonConvert.SerializeObject(resource, GetFullSerializerSettings(client));
            JObject original = JObject.Parse(sampleInfo.Json);
            JObject serialized = JObject.Parse(serializedJson);
            Assert.True(JToken.DeepEquals(original, serialized), string.Format(CultureInfo.InvariantCulture, "Failed at case: {0}.", sampleInfo.Name));
        }

        /// <summary>
        /// Creates a mock DataFactoryManagementClient
        /// </summary>
        /// <param name="handler">delegating handler for http requests</param>
        /// <returns>DataFactoryManagementClient Client</returns>
        protected IDataFactoryManagementClient CreateWorkflowClient(RecordedDelegatingHandler handler = null)
        {
            if (handler == null)
            {
                handler = new RecordedDelegatingHandler();
            }

            var client = new TestDataFactoryManagementClient(handler)
            {
                SubscriptionId = "66666666-6666-6666-6666-666666666666"
            };
            return client;
        }
    }
}
