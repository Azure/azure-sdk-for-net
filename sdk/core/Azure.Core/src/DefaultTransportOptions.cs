// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Configures behaviors for the default Transport.
    /// </summary>
    public class DefaultTransportOptions
    {
        /// <summary>
        /// Gets or sets a value that indicates whether the transport should follow redirection responses.
        /// </summary>
        public bool AllowAutoRedirect { get; set; }
    }
}
