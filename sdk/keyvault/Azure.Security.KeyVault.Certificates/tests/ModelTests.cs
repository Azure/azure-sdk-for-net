// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class ModelTests
    {
        [Test]
        public void ValidateCertificateIssuer() =>
            AssertModel(() => new CertificateIssuer(nameof(CertificateIssuer.Name), nameof(CertificateIssuer.Provider)));

        [Test]
        public void ValidateCertificateContact() =>
            AssertModel(() => new CertificateContact());

        [Test]
        public void ValidateCertificatePolicy() =>
            AssertModel(() => new CertificatePolicy());

        [Test]
        public void ValidateIssueProperties() =>
            AssertModel(() => new IssuerProperties("Name"));

        [Test]
        public void ValidateLifetimeAction() =>
            AssertModel(() => new LifetimeAction(CertificatePolicyAction.AutoRenew));

        #region Assertion helpers
        private static void AssertModel<T>(Func<T> factory) where T: IJsonSerializable, IJsonDeserializable
        {
            T obj = factory();

            // Write intrinsic properties.
            foreach (PropertyInfo property in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (property.CanWrite && ShouldSerialize(property, out var value))
                {
                    property.SetValue(obj, value);
                }
            }

            // Serialize.
            using MemoryStream ms = new();
            using Utf8JsonWriter writer = new(ms);
            writer.WriteStartObject();
            ((IJsonSerializable)obj).WriteProperties(writer);
            writer.WriteEndObject();
            writer.Flush();

            // Deserialize.
            ms.Seek(0, SeekOrigin.Begin);
            obj = factory();
            using JsonDocument doc = JsonDocument.Parse(ms);
            ((IJsonDeserializable)obj).ReadProperties(doc.RootElement);

            // Assert intrinsic properties.
            foreach (PropertyInfo property in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                // Check CanWrite to make sure we actually wrote it.
                if (property.CanWrite && property.CanRead && ShouldSerialize(property, out var value))
                {
                    Assert.AreEqual(value, property.GetValue(obj, null));
                }
            }
        }

        private static bool ShouldSerialize(PropertyInfo property, out object value)
        {
            if (property.PropertyType == typeof(string))
            {
                value = property.Name;
                return true;
            }

            if (property.PropertyType == typeof(int) || property.PropertyType == typeof(long))
            {
                value = property.Name.GetHashCode();
                return true;
            }

            if (property.PropertyType == typeof(int?))
            {
                value = new Nullable<int>(property.Name.GetHashCode());
                return true;
            }

            if (property.PropertyType == typeof(long?))
            {
                value = new Nullable<long>(property.Name.GetHashCode());
                return true;
            }

            value = string.Empty;
            return false;
        }
        #endregion
    }
}
