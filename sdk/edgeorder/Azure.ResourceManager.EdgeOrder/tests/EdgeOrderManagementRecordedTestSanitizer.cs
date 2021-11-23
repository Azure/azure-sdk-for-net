// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.EdgeOrder.Tests
{
    public class EdgeOrderManagementRecordedTestSanitizer : RecordedTestSanitizer
    {
        public EdgeOrderManagementRecordedTestSanitizer() : base()
        {
            AddJsonPathSanitizer("$..identity");
            AddJsonPathSanitizer("$..createdBy");
            AddJsonPathSanitizer("$..lastModifiedBy");
            AddJsonPathSanitizer("$..tenantId");
        }
    }
}
