// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Test.HttpRecorder
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

        public static FileSystemUtils FileSystemUtilsObject { get; set; }

        static HttpMockServer()
        {
            Matcher = new SimpleRecordMatcher("x-ms-version");
            records = new Records(Matcher);
            Variables = new Dictionary<string, string>();
            RecordsDirectory = "SessionRecords";
        }

        private HttpMockServer() { }

        public static void Initialize(Type callerIdentity, string testIdentity)
        {
            Initialize(callerIdentity, testIdentity, GetCurrentMode());
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
                var fileName = Path.GetFullPath(Path.Combine(recordDir, testIdentity.Replace(".json","") + ".json"));
                if (!HttpMockServer.FileSystemUtilsObject.DirectoryExists(recordDir) ||
                    !HttpMockServer.FileSystemUtilsObject.FileExists(fileName))
                {
                    throw new ArgumentException(
                        string.Format("Unable to find recorded mock file '{0}'.", fileName), "callerIdentity");
                }
                else
                { 
                    RecordEntryPack pack = RecordEntryPack.Deserialize(fileName);
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

            initialized = true;
        }

        public static HttpMockServer CreateInstance()
        {
            if (!initialized)
            {
                throw new InvalidOperationException("HttpMockServer has not been initialized yet. Use HttpMockServer.Initialize() method to initialize the HttpMockServer.");
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
        /// Gets the asset unique identifier. This is used to store the GUID in the recording so it can be easily retrieved.
        /// This behaves the same as name generation, but if useful if the client is required to generate Guids for the service.
        /// </summary>
        /// <param name="testName">Name of the test.</param>
        /// <returns></returns>
        public static Guid GetAssetGuid(string testName)
        {
            if (Mode == HttpRecorderMode.Playback)
            {
                return new Guid(names[testName].Dequeue());
            }
            else
            {
                string generated = Guid.NewGuid().ToString();

                if (Mode == HttpRecorderMode.Record)
                {
                    if (names.ContainsKey(testName))
                    {
                        // this should never happen, but just in case.
                        while (names[testName].Any(n => n.Equals(generated)))
                        {
                            generated = Guid.NewGuid().ToString();
                        }
                    }
                    names.Enqueue(testName, generated);
                }

                return new Guid(generated);
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
            string input = null;
            HttpRecorderMode mode;

            if(HttpMockServer.FileSystemUtilsObject != null)
            {
                input = HttpMockServer.FileSystemUtilsObject.GetEnvironmentVariable(ModeEnvironmentVariableName);
            }

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

    }
}