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
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging
{
    using System;
    using System.IO;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// Writes log messages to a supplied stream writter.
    /// </summary>
    public class StreamWriterLogWriter : LogWriter, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the StreamWriterLogWriter class.
        /// This will initialize the log writer with "Message" severity and "Normal" verbosity.
        /// </summary>
        /// <param name="writer">
        /// The stream writer into which log values should be written.
        /// </param>
        public StreamWriterLogWriter(StreamWriter writer)
            : this(writer, Severity.Informational, Verbosity.Normal)
        {
        }

        /// <summary>
        /// Initializes a new instance of the StreamWriterLogWriter class.
        /// </summary>
        /// <param name="writer">
        /// The stream writer into which log values should be written.
        /// </param>
        /// <param name="severity">
        /// The severity of messages that should be submitted to the log writer.
        /// The log writer will accept messages of equal or greater logical severity.
        /// </param>
        /// <param name="verbosity">
        /// The verbosity level of messages that should be submitted to the log writer.
        /// The log writer will accept messages of equal or greater logical verbosity.
        /// </param>
        public StreamWriterLogWriter(StreamWriter writer, Severity severity, Verbosity verbosity)
            : base(severity, verbosity)
        {
            this.writer = writer;
        }

        private StreamWriter writer;

        /// <inheritdoc />
        protected override void Write(string content)
        {
            this.writer.WriteLine(content);
            this.writer.Flush();
        }

        /// <summary>
        /// Disposes of the object.
        /// </summary>
        /// <param name="disposing">
        /// True if disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.writer.Dispose();
                this.writer = null;
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
