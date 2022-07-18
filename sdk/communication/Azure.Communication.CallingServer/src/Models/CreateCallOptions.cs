// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.CallingServer.Models
{
    /// <summary> The options for creating a call. </summary>
    public class CreateCallOptions
    {
        /// <summary> The subject. </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Create Call Options.
        /// </summary>
        public CreateCallOptions(string subject = default)
        {
            Subject = subject;
        }
    }
}
