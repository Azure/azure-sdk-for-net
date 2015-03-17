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
namespace Microsoft.Hadoop.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// Represents the base interface of a Hadoop Client.
    /// </summary>
    public interface IHadoopClientBase : IDisposable, ILogProvider
    {
        /// <summary>
        /// Cancel's a pending operation.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Adds a log writer to the client.
        /// </summary>
        /// <param name="logWriter">
        /// The log writer.
        /// </param>
        void AddLogWriter(ILogWriter logWriter);

        /// <summary>
        /// Removes a log writer.
        /// </summary>
        /// <param name="logWriter">
        /// The log writer.
        /// </param>
        void RemoveLogWriter(ILogWriter logWriter);

        /// <summary>
        /// Gets or sets a value indicating whether or not servicer side SSL errors should be ignored.
        /// </summary>
        bool IgnoreSslErrors { get; set; }

        /// <summary>
        /// Allows a user to set a custom cancellation source.
        /// </summary>
        /// <param name="tokenSource">
        /// The cancellation source.
        /// </param>
        void SetCancellationSource(CancellationTokenSource tokenSource);
    }
}
