// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class KeyVaultSettingTests
    {
        [Test]
        public void NewNameNullThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new KeyVaultSetting(null, false));
            Assert.That(ex.ParamName, Is.EqualTo("name"));
        }

        [Test]
        public void NewNameEmptyThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new KeyVaultSetting(string.Empty, false));
            Assert.That(ex.ParamName, Is.EqualTo("name"));
        }

        [Test]
        public void NewBoolean()
        {
            KeyVaultSetting setting = new("test", true);
            Assert.That(setting.Name, Is.EqualTo("test"));
            Assert.That(setting.SettingType, Is.EqualTo(KeyVaultSettingType.Boolean));
            Assert.That(setting.Value.AsBoolean(), Is.True);
        }

        [Test]
        public void AsBoolean([Values] bool value)
        {
            KeyVaultSetting setting = new("test", value);
            Assert.That(setting.Name, Is.EqualTo("test"));
            Assert.That(setting.SettingType, Is.EqualTo(KeyVaultSettingType.Boolean));
            Assert.That(setting.ToString(), Is.EqualTo($"test={(value ? "true" : "false")} (boolean)"));
            Assert.That(setting.Value.AsBoolean(), Is.EqualTo(value));
            Assert.That(setting.Value.ToString(), Is.EqualTo(value ? "true" : "false"));
        }

        [Test]
        public void AsBooleanInvalidTypeThrows()
        {
            KeyVaultSetting setting = new("test", "false", new KeyVaultSettingType("invalid"), new Dictionary<string, BinaryData>());
            Assert.That(setting.Name, Is.EqualTo("test"));
            Assert.That(setting.SettingType.ToString(), Is.EqualTo("invalid"));
            Assert.That(setting.Value.ToString(), Is.EqualTo("false"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => setting.Value.AsBoolean());
            Assert.That(ex.Message, Is.EqualTo("Cannot get setting as boolean. Setting type is invalid."));
        }

        [Test]
        public void AsBooleanInvalidValueThrows()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new KeyVaultSetting("test", "invalid", KeyVaultSettingType.Boolean, new Dictionary<string, BinaryData>()).Value.AsBoolean());
            Assert.That(ex.Message, Is.EqualTo("Cannot normalize the setting as boolean. Use 'KeyVaultSetting.Value.ToString()' for a textual representation of the setting."));
        }

        [Test]
        public void NewStringNullThrows()
        {
            Assert.Throws<ArgumentNullException>(() => new KeyVaultSetting("test", null, new KeyVaultSettingType("string"), new Dictionary<string, BinaryData>()));
        }
    }
}
