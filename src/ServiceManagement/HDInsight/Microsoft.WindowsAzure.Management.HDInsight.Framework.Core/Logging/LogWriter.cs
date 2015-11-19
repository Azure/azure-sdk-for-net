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
    using System.Globalization;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// The base class for log writers.
    /// </summary>
    public abstract class LogWriter : ILogWriter
    {
        private Severity logSeverity;
        private Verbosity logVerbosity;
        private object lockObject = new object();

        /// <summary>
        /// Initializes a new instance of the LogWriter class.
        /// This will initialize the log writer with "Message" severity and "Normal" verbosity.
        /// </summary>
        protected LogWriter()
            : this(Severity.Message, Verbosity.Normal)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LogWriter class.
        /// </summary>
        /// <param name="severity">
        /// The severity of messages that should be submitted to the log writer.
        /// The log writer will accept messages of equal or greater logical severity.
        /// </param>
        /// <param name="verbosity">
        /// The verbosity level of messages that should be submitted to the log writer.
        /// The log writer will accept messages of equal or greater logical verbosity.
        /// </param>
        protected LogWriter(Severity severity, Verbosity verbosity)
        {
            this.logSeverity = severity;
            this.logVerbosity = verbosity;
        }

        /// <summary>
        /// When implemented in a derived class this receives the message that should be logged.
        /// </summary>
        /// <param name="content">
        /// The content of the message that should be logged.
        /// </param>
        protected abstract void Write(string content);

        /// <inheritdoc />
        public void Log(Severity severity, Verbosity verbosity, string content)
        {
            if (severity >= this.logSeverity && verbosity <= this.logVerbosity)
            {
                string msg = string.Format(CultureInfo.InvariantCulture, "Severity: {0}\r\n{1}", severity, content);
                lock (this.lockObject)
                {
                    this.Write(msg);
                }
            }
        }
    }
}
