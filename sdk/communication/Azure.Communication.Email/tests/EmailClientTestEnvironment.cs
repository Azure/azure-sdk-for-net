// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;

namespace Azure.Communication.Email.Tests
{
    public class EmailClientTestEnvironment : CommunicationTestEnvironment
    {
        public string SenderAddress => GetRecordedVariable("SENDER_ADDRESS");
        public string RecipientAddress => GetRecordedVariable("RECIPIENT_ADDRESS");
    }
}
