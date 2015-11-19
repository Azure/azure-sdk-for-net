// Copyright (c) Microsoft Corporation
// All rights reserved.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Tools
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception for the avro tool.
    /// </summary>
    [Serializable]
    public sealed class ToolException : Exception
    {
        [NonSerialized]
        private readonly string outMessage = string.Empty;
        [NonSerialized]
        private readonly ExitCode exitCode = ExitCode.InvalidArguments;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolException"/> class.
        /// </summary>
        public ToolException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ToolException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ToolException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolException"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        private ToolException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolException" /> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="outMessage">The out message.</param>
        /// <param name="exitCode">The exit code.</param>
        internal ToolException(string errorMessage, string outMessage, ExitCode exitCode)
            : this(string.Format(CultureInfo.InvariantCulture, errorMessage))
        {
            this.outMessage = outMessage;
            this.exitCode = exitCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolException"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="exitCode">The exit code.</param>
        internal ToolException(string errorMessage, ExitCode exitCode)
            : this(errorMessage, string.Empty, exitCode)
        {
        }

        internal string Out
        {
            get
            {
                return this.outMessage;
            }
        }

        internal ExitCode ExitCode
        {
            get
            {
                return this.exitCode;
            }
        }
    }
}
