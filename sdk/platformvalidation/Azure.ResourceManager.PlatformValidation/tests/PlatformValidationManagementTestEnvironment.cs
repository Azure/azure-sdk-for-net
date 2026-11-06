// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.PlatformValidation.Tests
{
    public class PlatformValidationManagementTestEnvironment : TestEnvironment
    {
        internal const string SanitizedSourceVhdUri = "https://example.invalid/image.vhd";

        public string CatalogTestName => GetRecordedOptionalVariable("CATALOG_TEST")
            ?? "compute-vmimagevalidation-vm-boot-test";

        public string ValidationLocation => GetRecordedVariable("VALIDATION_LOCATION");

        public string SourceVhdUri => GetRecordedVariable("SOURCE_VHD_URI",
            options => options.IsSecret(SanitizedSourceVhdUri));

        protected override TokenCredential CreateDeveloperCredential()
        {
            if (string.Equals(GetOptionalVariable("USE_CLI_AUTH"), "true", StringComparison.OrdinalIgnoreCase))
            {
                return new AzureCliCredential();
            }

            return base.CreateDeveloperCredential();
        }
    }
}
