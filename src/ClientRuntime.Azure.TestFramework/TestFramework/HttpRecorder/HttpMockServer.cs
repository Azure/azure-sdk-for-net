// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework.HttpRecorder
{
    public class HttpMockServer : DelegatingHandler
    {
        // One of the enum values for HttpRecorderMode such as Record or Playback
        private const string ModeEnvironmentVariableName = "AZURE_TEST_MODE";
        private static AssetNames names;
        private static Records records;
        private static List<HttpMockServer> servers;
        private static bool initialized;

        public static HttpRecorderMode Mode { get; set; }
        public static IRecordMatcher Matcher { get; set; }
        public static string CallerIdentity { get; set; }
        public static string TestIdentity { get; set; }

        static HttpMockServer()
        {
            Matcher = new SimpleRecordMatcher("x-ms-version");
            records = new Records(Matcher);
            Variables = new Dictionary<string, string>();
            RecordsDirectory = "SessionRecords";
        }

        private HttpMockServer() 
        {
        }
        
        public static void Initialize(string callerIdentity, string testIdentity)
        {
            Initialize(callerIdentity, testIdentity, GetCurrentMode());
        }

        public static void Initialize(Type callerIdentity, string testIdentity, HttpRecorderMode mode)
        {
            Initialize(callerIdentity.Name, testIdentity, mode);
        }

        public static void Initialize(string callerIdentity, string testIdentity, HttpRecorderMode mode)
        {
            CallerIdentity = callerIdentity;
            TestIdentity = testIdentity;
            Mode = mode;
            names = new AssetNames();
            servers = new List<HttpMockServer>();
            records = new Records(Matcher);
            Variables = new Dictionary<string, string>();

            if (Mode == HttpRecorderMode.Playback)
            {
                string recordDir = Path.Combine(RecordsDirectory, CallerIdentity);
                if (Directory.Exists(recordDir))
                {
                    foreach (string recordsFile in Directory.GetFiles(recordDir, testIdentity + ".json"))
                    {
                        RecordEntryPack pack = RecordEntryPack.Deserialize(recordsFile);
                        foreach (var entry in pack.Entries)
                        {
                            records.Enqueue(entry);
                        }
                        foreach (var func in pack.Names.Keys)
                        {
                            pack.Names[func].ForEach(n => names.Enqueue(func, n));
                        }
                        Variables = pack.Variables;
                        if (Variables == null)
                        {
                            Variables = new Dictionary<string, string>();
                        }
                    }
                }
                else
                {
                    // if mock folder does not exist, switch execution back to HttpRecorderMode.None
                    throw new ArgumentException(
                        string.Format("Unable to find recorded mock directory '{0}'.", recordDir), "callerIdentity");
                }
            }

            initialized = true;
        }

        public static HttpMockServer CreateInstance()
        {
            if (!initialized)
            {
                throw new ApplicationException("HttpMockServer has not been initialized yet. Use HttpMockServer.Initialize() method to initialize the HttpMockServer.");
            }
            HttpMockServer server = new HttpMockServer();
            servers.Add(server);
            return server;
        }

        public static string RecordsDirectory { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (Mode == HttpRecorderMode.Playback)
            {
                // Will throw KeyNotFoundException if the request is not recorded
                var result = records[Matcher.GetMatchingKey(request)].Dequeue().GetResponse();
                result.RequestMessage = request;
                return Task.FromResult(result);
            }
            else
            {
                return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(response =>
                {
                    HttpResponseMessage result = response.Result;
                    if (Mode == HttpRecorderMode.Record)
                    {
                        records.Enqueue(new RecordEntry(result));
                    }

                    return result;
                });
            }
        }

        private static Random randomGenerator = new Random();
        public static string GetAssetName(string testName, string prefix)
        {
            if (Mode == HttpRecorderMode.Playback)
            {
                return names[testName].Dequeue();
            }
            else
            {
                string generated = prefix + randomGenerator.Next(9999);

                if (Mode == HttpRecorderMode.Record)
                {
                    if (names.ContainsKey(testName))
                    {
                        while (names[testName].Any(n => n.Equals(generated)))
                        {
                            generated = prefix + randomGenerator.Next(9999);
                        }
                    }
                    names.Enqueue(testName, generated);
                }

                return generated;
            }
        }

        /// <summary>
        /// Returns stored variable or variableValue if variableName is not found.
        /// </summary>
        /// <param name="variableName">Variable name</param>
        /// <param name="variableValue">Variable value to be preserved in recording mode.</param>
        /// <returns></returns>
        public static string GetVariable(string variableName, string variableValue)
        {
            if (Mode == HttpRecorderMode.Record)
            {
                Variables[variableName] = variableValue;
                return variableValue;
            }
            else
            {
                if (Variables.ContainsKey(variableName))
                {
                    return Variables[variableName];
                }
                else
                {
                    return variableValue;
                }
            }
        }

        /// <summary>
        /// Variables persistent across recording sessions.
        /// </summary>
        public static Dictionary<string, string> Variables { get; private set; }

        public void InjectRecordEntry(RecordEntry record)
        {
            if (Mode == HttpRecorderMode.Playback)
            {
                records.Enqueue(record);
            }
        }

        public static void Flush(string outputPath = null)
        {
            if (Mode == HttpRecorderMode.Record && records.Count > 0)
            {
                RecordEntryPack pack = new RecordEntryPack();

                foreach (RecordEntry recordEntry in records.GetAllEntities())
                {
                    recordEntry.RequestHeaders.Remove("Authorization");
                    recordEntry.RequestUri = new Uri(recordEntry.RequestUri).PathAndQuery;
                    pack.Entries.Add(recordEntry);
                }

                pack.Variables = Variables;

                string fileDirectory = outputPath ?? RecordsDirectory;
                string fileName = (TestIdentity ?? "record") + ".json";

                fileDirectory = Path.Combine(fileDirectory, CallerIdentity);

                Utilities.EnsureDirectoryExists(fileDirectory);
                
                pack.Names = names.Names;

                fileName = Path.Combine(fileDirectory, fileName);
                 
                pack.Serialize(fileName);
            }

            servers.ForEach(s => s.Dispose());
        }

        public static HttpRecorderMode GetCurrentMode()
        {
            string input = Environment.GetEnvironmentVariable(ModeEnvironmentVariableName);
            HttpRecorderMode mode;

            if (string.IsNullOrEmpty(input))
            {
                mode = HttpRecorderMode.Playback;
            }
            else
            {
                mode = (HttpRecorderMode)Enum.Parse(typeof(HttpRecorderMode), input, true);
            }

            return mode;
        }

        public static Records Records
        {
            get { return records; }
            set { records = value; }
        }

    }
}