// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
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
            string location = string.Empty;

#if FullNetFx
            var asmCollection = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly asm in asmCollection)
            {
                if (asm.GetType(CallerIdentity) != null)
                {
                    location = asm.Location;
                    break;
                }
            }
#elif netcoreapp11 || netcoreapp20
            location = AppContext.BaseDirectory;
#endif
            RecordsDirectory = Path.Combine(location, RecordsDirectory);

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
                    lock (records)
                    {
                        foreach (var entry in pack.Entries)
                        {
                            records.Enqueue(entry);
                        }
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
                lock (records)
                {
                    var key = Matcher.GetMatchingKey(request);

                    var queue = records[key];
                    if (!queue.Any())
                    {
                        throw new InvalidOperationException(string.Format(
                            "Queue empty for request {0}",
                            RecorderUtilities.DecodeBase64AsUri(key)));
                    }

                    var result = queue.Dequeue().GetResponse();
                    result.RequestMessage = request;
                    return Task.FromResult(result);
                }
            }
            else
            {
                lock (this)
                {
                    return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(response =>
                    {
                        HttpResponseMessage result = response.Result;
                        if (Mode == HttpRecorderMode.Record)
                        {
                            lock (records)
                            {
                                records.Enqueue(new RecordEntry(result));
                            }
                        }

                        return result;
                    });
                }
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
                lock (records)
                {
                    records.Enqueue(record);
                }
            }
        }

        public static string Flush(string outputPath = null)
        {
            string fileName = string.Empty;
            if (Mode == HttpRecorderMode.Record && records.Count > 0)
            {
                RecordEntryPack pack = new RecordEntryPack();
                string perfImpactFileName = string.Empty;
                string fileDirectory = outputPath ?? RecordsDirectory;
                fileDirectory = Path.Combine(fileDirectory, CallerIdentity);
                RecorderUtilities.EnsureDirectoryExists(fileDirectory);

                lock (records)
                {
                    foreach (RecordEntry recordEntry in records.GetAllEntities())
                    {
                        recordEntry.RequestHeaders.Remove("Authorization");
                        recordEntry.RequestUri = new Uri(recordEntry.RequestUri).PathAndQuery;
                        pack.Entries.Add(recordEntry);
                    }
                }

                fileName = (TestIdentity ?? "record") + ".json";                
                fileName = Path.Combine(fileDirectory, fileName);
                pack.Variables = Variables;
                pack.Names = names.Names;

                pack.Serialize(fileName);
            }

            servers.ForEach(s => s.Dispose());

            return fileName;
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