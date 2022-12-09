// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Reservations.Tests
{
    public class ReservationsManagementTestEnvironment : TestEnvironment
    {
        public ReservationsManagementTestEnvironment() : base()
        {
            Environment.SetEnvironmentVariable("CLIENT_ID", "d8d6ed95-c525-4509-a4b6-7f49d6379f91");
            Environment.SetEnvironmentVariable("CLIENT_SECRET", "VCB8Q~yIdJ0BdklAVP.VOhbaK8QvzTFZ~2F5EacZ");
            Environment.SetEnvironmentVariable("SUBSCRIPTION_ID", "fed2a274-8787-4a13-8371-f5282597b779");
            Environment.SetEnvironmentVariable("TENANT_ID", "3a689a02-340f-4a4e-a32c-6fce276c6bdc");
            Environment.SetEnvironmentVariable("AZURE_AUTHORITY_HOST", "https://login.microsoftonline.com");
        }
    }
}
