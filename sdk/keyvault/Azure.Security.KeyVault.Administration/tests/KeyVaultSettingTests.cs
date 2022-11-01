// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            Assert.That(setting.Type, Is.EqualTo(SettingType.Boolean));
            Assert.That(setting.AsBoolean(), Is.True);
        }

        [Test]
        public void AsBoolean([Values] bool value)
        {
            KeyVaultSetting setting = new("test", value ? "true" : "false", SettingType.Boolean);
            Assert.That(setting.Name, Is.EqualTo("test"));
            Assert.That(setting.Type, Is.EqualTo(SettingType.Boolean));
            Assert.That(setting.ToString(), Is.EqualTo($"test: AsBoolean()=>{(value ? "true" : "false")}"));
            Assert.That(setting.AsBoolean(), Is.EqualTo(value));
        }

        [Test]
        public void AsBooleanInvalidTypeThrows()
        {
            KeyVaultSetting setting = new("test", "false", new SettingType("invalid"));
            Assert.That(setting.Name, Is.EqualTo("test"));
            Assert.That(setting.Type.ToString(), Is.EqualTo("invalid"));
            Assert.That(setting.ToString(), Is.EqualTo($"test: AsString()=>false"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => setting.AsBoolean());
            Assert.That(ex.Message, Is.EqualTo("Cannot get setting as boolean. Setting type is invalid."));
        }

        [Test]
        public void AsBooleanInvalidValueThrows()
        {
            KeyVaultSetting setting = new("test", "invalid", SettingType.Boolean);
            Assert.That(setting.Name, Is.EqualTo("test"));
            Assert.That(setting.Type, Is.EqualTo(SettingType.Boolean));
            Assert.That(setting.ToString(), Is.EqualTo($"test: AsBoolean()=>invalid"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => setting.AsBoolean());
            Assert.That(ex.Message, Is.EqualTo("Cannot normalize the setting as boolean. Use AsString() for a textual representation of the setting."));
        }

        [Test]
        public void AsStringNull()
        {
            KeyVaultSetting setting = new("test", null, new SettingType("string"));
            Assert.That(setting.Name, Is.EqualTo("test"));
            Assert.That(setting.Type.ToString(), Is.EqualTo("string"));
            Assert.That(setting.ToString(), Is.EqualTo("test: AsString()=>"));
            Assert.That(setting.AsString(), Is.Null);
        }
    }
}
