// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Tests
{
    public class PartiallyDeployedAttribute : IgnoreServiceErrorAttribute
    {
        protected override string Reason => "The feature under test may not be deployed to this environment.";

        protected override bool Matches(string message) =>
            message.Contains("Status: 400") && message.Contains("ErrorCode: BadParameter");
    }
}
