// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for Call Automtion's <see cref="EventProcessor"/>.
    /// </summary>
    public class EventProcessorOptions
    {
        /// <summary>
        /// EventTimeout for WaitForEvent method. Throws Timeout exception when no matching event arrives after timespan.
        /// </summary>
        public TimeSpan EventTimeout { get; set; }
    }
}
