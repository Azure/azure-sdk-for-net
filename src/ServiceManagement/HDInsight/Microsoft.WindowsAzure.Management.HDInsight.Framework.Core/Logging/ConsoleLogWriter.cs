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
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// Writes log messages to the console.
    /// </summary>
    public class ConsoleLogWriter : LogWriter
    {
        /// <summary>
        /// Initializes a new instance of the ConsoleLogWriter class.
        /// </summary>
        /// <param name="severity">
        /// The severity of messages that should be submitted to the log writer.
        /// The log writer will accept messages of equal or greater logical severity.
        /// </param>
        /// <param name="verbosity">
        /// The verbosity level of messages that should be submitted to the log writer.
        /// The log writer will accept messages of equal or greater logical verbosity.
        /// </param>
        public ConsoleLogWriter(Severity severity, Verbosity verbosity)
            : base(severity, verbosity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConsoleLogWriter class.
        /// This will initialize the log writer with "Message" severity and "Normal" verbosity.
        /// </summary>
        public ConsoleLogWriter()
        {
        }

        /// <inheritdoc />
        protected override void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
