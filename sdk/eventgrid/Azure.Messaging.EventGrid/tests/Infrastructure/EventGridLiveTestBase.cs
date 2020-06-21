// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid.Models;
using Microsoft.Azure.Management.EventGrid.Models;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridLiveTestBase : RecordedTestBase<EventGridTestEnvironment>
    {
        public EventGridLiveTestBase(bool isAsync) : base(isAsync /*, RecordedTestMode.Record */)
        {
            Sanitizer = new EventGridRecordedTestSanitizer();
        }
    }
}
