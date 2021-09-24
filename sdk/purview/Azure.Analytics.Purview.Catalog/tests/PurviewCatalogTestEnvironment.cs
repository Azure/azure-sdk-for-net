// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Catalog.Tests
{
    public class PurviewCatalogTestEnvironment: TestEnvironment
    {
        public PurviewCatalogTestEnvironment()
        {
        }
        public Uri Endpoint => new(GetRecordedVariable("PURVIEW_ACCOUNT_URL"));
    }
}
