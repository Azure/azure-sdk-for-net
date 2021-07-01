// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Microsoft.Azure.Management.Synapse.Tests
{
    public class SynapseMockContext : MockContext
    {
        /// <summary>
        /// Real mock context
        /// </summary>
        private MockContext innerContext;

        /// <summary>
        /// Text replacement rules.
        /// Key is real data to be replaced while value is the replacement
        /// </summary>
        private readonly Dictionary<string, string> textReplacementRules;

        /// <summary>
        /// Ctor
        /// </summary>
        private SynapseMockContext()
        {
            textReplacementRules = new Dictionary<string, string>();
        }

        /// <summary>
        /// Return a new UndoContext
        /// </summary>
        /// <returns></returns>
        public new static SynapseMockContext Start(
            Type typeName,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName= "testframework_failed")
        {
            var context = new SynapseMockContext
            {
                innerContext = MockContext.Start(typeName, methodName)
            };

            return context;
        }

        /// <summary>
        /// Add a single text replacement rule
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="replacement"></param>
        public void AddTextReplacementRule(string regex, string replacement)
        {
            if (string.IsNullOrEmpty(regex))
            {
                throw new ArgumentException($"String cannot be of zero length. Parameter name: {nameof(regex)}");
            }

            this.textReplacementRules.Add(regex, replacement);
        }

        /// <summary>
        /// Apply text replacement rules
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public string ApplyTextReplacementRules(string line)
        {
            foreach (var rule in textReplacementRules)
            {
                line = line.Replace(rule.Key, rule.Value);
            }

            return line;
        }

        /// <summary>
        /// Get a test environment using default options
        /// </summary>
        /// <typeparam name="T">The type of the service client to return</typeparam>
        /// <returns>A Service client using credentials and base uri from the current environment</returns>
        public new T GetServiceClient<T>(bool internalBaseUri = false, params DelegatingHandler[] handlers) where T : class
        {
            return innerContext.GetServiceClient<T>(internalBaseUri, handlers);
        }

        /// <summary>
        /// Stop recording and Discard all undo information
        /// </summary>
        public new void Stop()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                string fileDirectory = HttpMockServer.RecordsDirectory;
                fileDirectory = Path.Combine(fileDirectory, HttpMockServer.CallerIdentity);
                string recordedFileName = (HttpMockServer.TestIdentity ?? "record") + ".json";
                string recordedFilePath = Path.Combine(fileDirectory, recordedFileName);
                if (File.Exists(recordedFilePath))
                {
                    var lines = File.ReadAllLines(recordedFilePath)
                        .Where(line => !line.Contains(nameof(RecordEntry.EncodedRequestUri)))
                        .Select(ApplyTextReplacementRules);

                    File.WriteAllLines(recordedFilePath, lines);
                }
            }
        }

        /// <summary>
        /// Dispose only if we have not previously been disposed
        /// </summary>
        /// <param name="disposing">true if we should dispose, otherwise false</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && !this.disposed)
            {
                innerContext.Dispose();
                this.Stop();
                this.disposed = true;
            }
        }
    }
}
