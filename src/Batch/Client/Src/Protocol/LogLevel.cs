//-----------------------------------------------------------------------
// <copyright file="LogLevel.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.Azure.Batch.Protocol
{
    /// <summary>
    /// Specifies what messages to output to the log.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Output no tracing and debugging messages.
        /// </summary>
        Off = 0,

        /// <summary>
        /// Output error-handling messages.
        /// </summary>
        Error,

        /// <summary>
        /// Output warnings and error-handling messages.
        /// </summary>
        Warning,

        /// <summary>
        /// Output informational messages, warnings, and error-handling messages.
        /// </summary>
        Informational,

        /// <summary>
        /// Output all debugging and tracing messages.
        /// </summary>
        Verbose,
    }
}
