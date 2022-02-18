// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Castle.Core.Internal;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CommunicationManagementRecordedTestSanitizer : RecordedTestSanitizer
    {
        public CommunicationManagementRecordedTestSanitizer() : base()
        {
            // Lazy sanitize fields in the request and response bodies
            JsonPathSanitizers.Add("$..token");
            JsonPathSanitizers.Add("$..identity");
        }
    }
}
