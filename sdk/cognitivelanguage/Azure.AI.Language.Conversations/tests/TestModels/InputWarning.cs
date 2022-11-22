// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Contains details of warnings encountered during a job execution. </summary>
    public partial class InputWarning
    {
        /// <summary> Initializes a new instance of InputWarning. </summary>
        /// <param name="code"> Warning code. </param>
        /// <param name="message"> Warning message. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="code"/> or <paramref name="message"/> is null. </exception>
        public InputWarning(string code, string message)
        {
            Argument.AssertNotNull(code, nameof(code));
            Argument.AssertNotNull(message, nameof(message));

            Code = code;
            Message = message;
        }

        /// <summary> Initializes a new instance of InputWarning. </summary>
        /// <param name="code"> Warning code. </param>
        /// <param name="message"> Warning message. </param>
        /// <param name="targetRef"> A JSON pointer reference indicating the target object. </param>
        internal InputWarning(string code, string message, string targetRef)
        {
            Code = code;
            Message = message;
            TargetRef = targetRef;
        }

        /// <summary> Warning code. </summary>
        public string Code { get; set; }
        /// <summary> Warning message. </summary>
        public string Message { get; set; }
        /// <summary> A JSON pointer reference indicating the target object. </summary>
        public string TargetRef { get; set; }
    }
}
