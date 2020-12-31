// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Synapse.Tests
{
    /// <summary>
    /// Test utilities.
    /// </summary>
    internal static class SynapseTestUtilities
    {
        /// <summary>
        /// Text replacement rules.
        /// Key is real data to be replaced while value is the replacement.
        /// </summary>
        private static readonly Dictionary<string, string> textReplacementRules;

        static SynapseTestUtilities()
        {
            textReplacementRules = new Dictionary<string, string>();
        }

        /// <summary>
        /// Add a single text replacement rule.
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="replacement"></param>
        internal static void AddTextReplacementRule(this TestRecording recording, string regex, string replacement)
        {
            if (string.IsNullOrEmpty(regex))
            {
                throw new ArgumentException($"String cannot be of zero length. Parameter name: {nameof(regex)}");
            }

            textReplacementRules.Add(regex, replacement);
        }

        /// <summary>
        /// Clear text replacement rules.
        /// </summary>
        internal static void ClearTextReplacementRules(this TestRecording recording)
        {
            textReplacementRules.Clear();
        }

        /// <summary>
        /// Apply text replacement rules.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        internal static string ApplyTextReplacementRules(string line)
        {
            foreach (var rule in textReplacementRules)
            {
                line = line.Replace(rule.Key, rule.Value);
            }

            return line;
        }

        internal static string GenerateName(this TestRecording recording, string prefix)
        {
            return prefix + recording.GenerateId();
        }

        internal static void RewriteSessionRecords(this TestRecording recording, string recordedFilePath)
        {
            if (recording.Mode == RecordedTestMode.Record)
            {
                if (File.Exists(recordedFilePath))
                {
                    var lines = File.ReadAllLines(recordedFilePath).Select(ApplyTextReplacementRules);
                    File.WriteAllLines(recordedFilePath, lines);
                }
            }
        }

        /// <summary>
        /// Wait for the specified span unless we are in mock playback mode.
        /// </summary>
        /// <param name="timeout">The span of time to wait for.</param>
        internal static void Wait(this TestRecording recording, TimeSpan timeout)
        {
            if (recording.Mode != RecordedTestMode.Playback)
            {
                Thread.Sleep(timeout);
            }
        }
    }
}
