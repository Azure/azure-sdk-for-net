// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace System.ClientModel.Primitives.Tests;

public class CredentialSettingsTests
{
    [Test]
    public void CredentialSettings_WithNullSection_DoesNotThrow()
    {
        // Act & Assert - Should not throw
        CredentialSettings settings = new CredentialSettings(null!);

        // Verify properties are null/default
        Assert.That(settings, Is.Not.Null);
        Assert.That(settings.CredentialSource, Is.Null);
        Assert.That(settings.Key, Is.Null);
        Assert.That(settings.AdditionalProperties, Is.Null);
    }
}
