// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    /// <summary>
    /// Implements parsing of Storage Analytics Log file.
    /// </summary>
    /// <remarks>
    /// Storage Analytics Log Format defined at <a href="http://msdn.microsoft.com/en-us/library/windowsazure/hh343259.aspx"/>
    /// </remarks>
    internal class StorageAnalyticsLogParser
    {
        private const string FieldPattern =
            // x - ignore whitespace and comments.
            // n - do not capture unnamed groups.
            @"(?xn)" +
            // Non-capturing group
            // asserts position at start of the string, or
            // matches the character ; literally
            @"(^|;)" +
            // Non-capturing group
            "(" +
            // 1st Alternative of named capturing group field:
            // greedy match of " embraced sequence of 0 to unlimited number of characters
            @"""(?<field>[^""]*)"" | " +
            // 2nd Alternative of named capturing group field:
            // greedy match of zero to unlimited number of characters not present in the list below
            @"(?<field>[^;""]*)" +
            @")" +
            // Positive Lookahead - Assert that the regex below can be matched
            // matches the character ; literally, or
            // asserts position at end of the string
            @"(?=;|$)";

        private const int ColumnCount = (int)StorageAnalyticsLogColumnId.LastColumn + 1;

        private readonly Version supportedVersion = new Version(1, 0);

        private readonly Regex _compiledRegex;
        private readonly ILogger<BlobListener> _logger;

        public StorageAnalyticsLogParser(ILogger<BlobListener> logger)
        {
            _compiledRegex = new Regex(FieldPattern, RegexOptions.Compiled);
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Given a log file (as a blob), parses it and return a collection of log entries matching version 1.0
        /// of the Storage Analytics Log Format.
        /// </summary>
        /// <param name="blob">Object representing a cloud blob with Storage Analytics log content.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation request.</param>
        /// <returns>Collection of successfully parsed log entries.</returns>
        /// <exception cref="FormatException">If unable to parse a line in given log.</exception>
        /// <seealso cref="StorageAnalyticsLogEntry"/>
        /// <remarks>
        /// The method scans log file lines one at a time.
        /// First it attempts to detect a line format version and throws an exception if failed to do so.
        /// It skips all lines with version different than supported one, i.e. 1.0.
        /// Then it calls TryParseLogEntry to create a log entry out of every line of supported version and throws
        /// an exception if the parse method returns null.
        /// </remarks>
        public async Task<IEnumerable<StorageAnalyticsLogEntry>> ParseLogAsync(BlobBaseClient blob,
            CancellationToken cancellationToken)
        {
            List<StorageAnalyticsLogEntry> entries = new List<StorageAnalyticsLogEntry>();

            using (Stream content = (await blob.DownloadAsync(cancellationToken).ConfigureAwait(false)).Value.Content)
            {
                using (TextReader tr = new StreamReader(content))
                {
                    for (int lineNumber = 1; ; lineNumber++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string line = await tr.ReadLineAsync().ConfigureAwait(false);
                        if (line == null)
                        {
                            break;
                        }

                        var entry = ParseLine(line, blob.Name, lineNumber.ToString(CultureInfo.CurrentCulture));
                        if (entry != null)
                        {
                            entries.Add(entry);
                        }
                    }
                }
            }

            return entries;
        }

        /// <summary>
        /// Attempts to parse first field of a log line assuming it's in 'Major.Minor' version format
        /// followed by ';'
        /// </summary>
        /// <param name="line">A line as extracted from a Storage Analytics Log file.</param>
        /// <returns>Parsed instance of <see cref="Version"/> or null if parsing has failed.</returns>
        public static Version TryParseVersion(string line)
        {
            if (String.IsNullOrEmpty(line))
            {
                return null;
            }

            int versionEndPos = line.IndexOf(';');
            if (versionEndPos == -1)
            {
                return null;
            }

            Version ver;
            if (!Version.TryParse(line.Substring(0, versionEndPos), out ver))
            {
                return null;
            }

            return ver;
        }

        /// <summary>
        /// Attempts to parse a single line of Storage Analytics Log file using Regex matches.
        /// </summary>
        /// <param name="line">A line as extracted from a Storage Analytics Log file. Must not be null or empty.</param>
        /// <returns>Parsed instance of <see cref="StorageAnalyticsLogEntry"/> if the given line matches expected format
        /// of the Storage Analytics Log v1.0, or null otherwise.</returns>
        public StorageAnalyticsLogEntry TryParseLogEntry(string line)
        {
            Debug.Assert(line != null);

            var capturedFields =
                from Match m in _compiledRegex.Matches(line)
                select WebUtility.HtmlDecode(m.Groups[1].Value);
            string[] fieldsArray = capturedFields.ToArray();

            if (fieldsArray.Length != ColumnCount)
            {
                return null;
            }

            return StorageAnalyticsLogEntry.TryParse(fieldsArray);
        }

        internal StorageAnalyticsLogEntry ParseLine(string line, string blobName, string lineNumber)
        {
            Version version = TryParseVersion(line);
            if (version == null)
            {
                string message = String.Format(CultureInfo.CurrentCulture,
                    "Unable to detect a version of log entry on line {1} of Storage Analytics log file '{0}'.",
                    blobName, lineNumber);

                _logger.LogWarning(message);
            }

            if (version == supportedVersion)
            {
                StorageAnalyticsLogEntry entry = TryParseLogEntry(line);
                if (entry == null)
                {
                    string message = String.Format(CultureInfo.CurrentCulture,
                        "Unable to parse the log entry on line {1} of Storage Analytics log file '{0}'.",
                        blobName, lineNumber);

                    _logger.LogWarning(message);
                }
                return entry;
            }
            return null;
        }
    }
}
