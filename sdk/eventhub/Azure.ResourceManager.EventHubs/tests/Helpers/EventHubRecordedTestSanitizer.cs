// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Castle.Core.Internal;

namespace Azure.ResourceManager.EventHubs.Tests.Helpers
{
    public class EventHubRecordedTestSanitizer : RecordedTestSanitizer
    {
        public EventHubRecordedTestSanitizer() : base()
        {
            // Lazy sanitize fields in the request and response bodies
            AddJsonPathSanitizer("$..aliasPrimaryConnectionString");
            AddJsonPathSanitizer("$..aliasSecondaryConnectionString");
            AddJsonPathSanitizer("$..keyName");
        }
    }
}
