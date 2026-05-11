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

    [TestCase("ApiKey", "apikeycredential")]
    [TestCase("apikey", "apikeycredential")]
    [TestCase("APIKEY", "apikeycredential")]
    [TestCase("ApiKeyCredential", "apikeycredential")]
    [TestCase("apikeycredential", "apikeycredential")]
    [TestCase("APIKEYCREDENTIAL", "apikeycredential")]
    [TestCase("TokenCredential", "tokencredential")]
    [TestCase("CustomCredential", "customcredential")]
    [TestCase("ManagedIdentity", "managedidentity")]
    [TestCase("ManagedIdentityCredential", "managedidentitycredential")]
    [TestCase("AzureCli", "azurecli")]
    public void CredentialSource_NormalizesToLowercaseLongForm(string input, string expected)
    {
        CredentialSettings settings = new CredentialSettings(null!)
        {
            CredentialSource = input
        };

        Assert.That(settings.CredentialSource, Is.EqualTo(expected));
    }

    [Test]
    public void CredentialSource_NullRemainsNull()
    {
        CredentialSettings settings = new CredentialSettings(null!)
        {
            CredentialSource = null
        };

        Assert.That(settings.CredentialSource, Is.Null);
    }
}
