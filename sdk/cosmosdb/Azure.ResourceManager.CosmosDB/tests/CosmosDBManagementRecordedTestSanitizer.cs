// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Castle.Core.Internal;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class CosmosDBManagementRecordedTestSanitizer : RecordedTestSanitizer
    {
        public CosmosDBManagementRecordedTestSanitizer() : base()
        {
            // Lazy sanitize fields in the request and response bodies
            AddJsonPathSanitizer("$..primaryMasterKey");
            AddJsonPathSanitizer("$..primaryReadonlyMasterKey");
            AddJsonPathSanitizer("$..secondaryMasterKey");
            AddJsonPathSanitizer("$..secondaryReadonlyMasterKey");
        }
    }
}
