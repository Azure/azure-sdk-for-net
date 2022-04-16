// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Tests
{
    public class AttestationMayFailAttribute : IgnoreServiceErrorAttribute
    {
        protected override string Reason => "The service failed to verify the attestation token.";

        protected override bool Matches(string message) =>
            message.Contains("Status: 403") && message.Contains("Target environment attestation statement cannot be verified.");
    }
}
