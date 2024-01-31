// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Developer.DevCenter.Tests
{
    public class DevCenterClientTestEnvironment : TestEnvironment
    {
        public Uri Endpoint => new(GetRecordedVariable("DEFAULT_DEVCENTER_ENDPOINT"));
        public string ProjectName => GetRecordedVariable("DEFAULT_PROJECT_NAME");
        public string PoolName => GetRecordedVariable("DEFAULT_POOL_NAME");
        public string CatalogName => GetRecordedVariable("DEFAULT_CATALOG_NAME");
        public string EnvironmentTypeName => GetRecordedVariable("DEFAULT_ENVIRONMENT_TYPE_NAME");
        public string UserId => GetRecordedVariable("STATIC_TEST_USER_ID");
        public string MeUserId => "me";
        public RequestContext context = null;
        public string filter = null;
        public int? maxCount = null;
        public bool? hibernate = null;
    }
}
