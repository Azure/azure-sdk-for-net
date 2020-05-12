// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Management.Compute.Tests
{
    public class ComputeManagementTestEnvironment : TestEnvironment
    {
        public ComputeManagementTestEnvironment() : base("computemgmt")
        {
        }
    }
}
