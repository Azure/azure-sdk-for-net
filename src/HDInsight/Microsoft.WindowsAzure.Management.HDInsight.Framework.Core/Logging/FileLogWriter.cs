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
    using System.IO;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// Writes log messages to a supplied file.
    /// </summary>
    public sealed class FileLogWriter : StreamWriterLogWriter
    {
        /// <summary>
        /// Initializes a new instance of the FileLogWriter class.
        /// This will initialize the log writer with "Message" severity and "Normal" verbosity.
        /// </summary>
        /// <param name="fileName">
        /// The path to the file into which log values should be written.
        /// </param>
        public FileLogWriter(string fileName)
            : base(Help.SafeCreate(() => new StreamWriter(Help.SafeCreate(() => new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read)))))
        {
        }

        /// <summary>
        /// Initializes a new instance of the FileLogWriter class.
        /// </summary>
        /// <param name="fileName">
        /// The path to the file into which log values should be written.
        /// </param>
        /// <param name="severity">
        /// The severity of messages that should be submitted to the log writer.
        /// The log writer will accept messages of equal or greater logical severity.
        /// </param>
        /// <param name="verbosity">
        /// The verbosity level of messages that should be submitted to the log writer.
        /// The log writer will accept messages of equal or greater logical verbosity.
        /// </param>
        public FileLogWriter(string fileName, Severity severity, Verbosity verbosity)
            : base(Help.SafeCreate(() => new StreamWriter(Help.SafeCreate(() => new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read)))), severity, verbosity)
        {
        }
    }
}
