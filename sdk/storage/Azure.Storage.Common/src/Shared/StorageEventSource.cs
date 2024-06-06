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

        private const int GenerateSharedKeyStringToSignEvent = 1;
        private const int GenerateAccountSasStringToSignEvent = 2;
        private const int GenerateServiceSasStringToSignEvent = 3;
        private const int GenerateUserDelegationSasStringToSignEvent = 4;

        private StorageEventSource() : base(EventSourceName) { }

        public static StorageEventSource Singleton { get; } = new StorageEventSource();

        [Event(GenerateSharedKeyStringToSignEvent, Level = EventLevel.Verbose, Message = "Generated string to sign:\n{0}")]
        public void GenerateSharedKeyStringToSign(string stringToSign)
        {
            WriteEvent(GenerateSharedKeyStringToSignEvent, stringToSign);
        }

        [Event(GenerateAccountSasStringToSignEvent, Level = EventLevel.Verbose, Message = "Generated string to sign:\n{0}")]
        public void GenerateAccountSasStringToSign(string stringToSign)
        {
            WriteEvent(GenerateAccountSasStringToSignEvent, stringToSign);
        }

        [Event(GenerateServiceSasStringToSignEvent, Level = EventLevel.Verbose, Message = "Generated string to sign:\n{0}")]
        public void GenerateServiceSasStringToSign(string stringToSign)
        {
            WriteEvent(GenerateServiceSasStringToSignEvent, stringToSign);
        }

        [Event(GenerateUserDelegationSasStringToSignEvent, Level = EventLevel.Verbose, Message = "Generated string to sign:\n{0}")]
        public void GenerateUserDelegationSasStringToSign(string stringToSign)
        {
            WriteEvent(GenerateUserDelegationSasStringToSignEvent, stringToSign);
        }
    }
}
