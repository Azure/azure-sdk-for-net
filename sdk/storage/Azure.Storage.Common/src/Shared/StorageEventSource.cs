// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Text;
using Azure.Core;
using Azure.Core.Diagnostics;

namespace Azure.Storage
{
    [EventSource(Name = EventSourceName)]
    internal sealed class StorageEventSource : AzureEventSource
    {
        private const string EventSourceName = "Azure-Storage";

        private const int GenerateStringToSignEvent = 1;

        private StorageEventSource() : base(EventSourceName) { }

        public static StorageEventSource Singleton { get; } = new StorageEventSource();

        [Event(GenerateStringToSignEvent, Level = EventLevel.Verbose, Message = "Generated string to sign\n{0}")]
        public void GenerateStringToSign(string stringToSign)
        {
            WriteEvent(GenerateStringToSignEvent, stringToSign);
        }
    }
}
