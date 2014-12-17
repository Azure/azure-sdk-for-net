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
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// The default implementation of the logger.  All messages are 
    /// simply passed into the LogWriter.
    /// </summary>
    public class Logger : ILogger
    {
        private List<Tuple<ILogWriter, object>> writers = new List<Tuple<ILogWriter, object>>();

        /// <inheritdoc />
        public void LogMessage(string message)
        {
            this.LogMessage(message, Severity.Message, Verbosity.Normal);
        }

        /// <inheritdoc />
        public void LogMessage(string message, Severity severity, Verbosity verbosity)
        {
            List<Tuple<ILogWriter, object>> localWriters;
            lock (this.writers)
            {
                // Lock the writers before capturing the list.
                localWriters = this.writers;
            }
            foreach (var logWriter in localWriters)
            {
                // Lock the lock object.
                lock (logWriter.Item2)
                {
                    // Log to the writer.
                    logWriter.Item1.Log(severity, verbosity, message);
                }
            }
        }

        /// <inheritdoc />
        public void AddWriter(ILogWriter writer)
        {
            // Log the writers before adding a new item.
            lock (this.writers)
            {
                // Use a Tuple so we can provide a lock object.
                this.writers.Add(new Tuple<ILogWriter, object>(writer, new object()));
            }
        }

        /// <inheritdoc />
        public void RemoveWriter(ILogWriter writer)
        {
            Tuple<ILogWriter, object> toRemove = null;
            // Log the writers before removing the item.
            lock (this.writers)
            {
                // Enumerate and find the correct writer pair.
                foreach (var keyValuePair in this.writers)
                {
                    if (keyValuePair.Item1 == writer)
                    {
                        toRemove = keyValuePair;
                        break;
                    }
                }
                // Remove the Tuple if we found one.
                if (toRemove != null)
                {
                    this.writers.Remove(toRemove);
                }
            }
        }
    }
}
