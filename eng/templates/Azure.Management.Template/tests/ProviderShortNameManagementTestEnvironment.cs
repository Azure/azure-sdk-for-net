// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;

namespace Azure.Management.Template.Tests
{
    public class ProviderShortNameManagementTestEnvironment : TestEnvironment
    {
        public ProviderShortNameManagementTestEnvironment() : base("ProviderNameLowercasemgmt")
        {
        }
    }
}