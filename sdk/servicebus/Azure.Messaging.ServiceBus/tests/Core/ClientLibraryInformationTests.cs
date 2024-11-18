// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Messaging.ServiceBus.Core;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ClientLibraryInformation" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ClientLibraryInformationTests
    {
        /// <summary>
        ///   Validates functionality of the <see cref="ClientLibraryInformation.Current" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void CurrentReturnsAnInstance()
        {
            Assert.That(ClientLibraryInformation.Current, Is.Not.Null);
        }

        /// <summary>
        ///   Validates functionality of the <see cref="ClientLibraryInformation.Current" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PlatformIsPopulated()
        {
            Assert.That(ClientLibraryInformation.Current.Platform, Is.Not.Null.And.Not.Empty);
        }

        /// <summary>
        ///   Validates functionality of the <see cref="ClientLibraryInformation.Current" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ProductCanBeAccessed()
        {
            Assert.That(() => ClientLibraryInformation.Current.Product, Throws.Nothing);
        }

        /// <summary>
        ///   Validates functionality of the <see cref="ClientLibraryInformation.Current" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void VersionCanBeAccessed()
        {
            Assert.That(() => ClientLibraryInformation.Current.Version, Throws.Nothing);
        }

        /// <summary>
        ///   Validates functionality of the <see cref="ClientLibraryInformation.Current" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void FrameworkCanBeAccessed()
        {
            Assert.That(() => ClientLibraryInformation.Current.Framework, Throws.Nothing);
        }

        /// <summary>
        ///   Validates functionality of the <see cref="ClientLibraryInformation.Current" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void UserAgentCanBeAccessed()
        {
            Assert.That(() => ClientLibraryInformation.Current.UserAgent, Throws.Nothing);
        }

        /// <summary>
        ///   Validates functionality of the <see cref="ClientLibraryInformation.SerializedProperties" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void SerializedPropertiesCanBeEnumerated()
        {
            Dictionary<string, string> expectedNames = typeof(ClientLibraryInformation)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(property => (property.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>(false)?.Description ?? property.Name).ToLowerInvariant(), property => property.Name);

            foreach (KeyValuePair<string, string> property in ClientLibraryInformation.Current.SerializedProperties)
            {
                Assert.That(expectedNames.ContainsKey(property.Key), Is.True, $"The property, { property.Key }, was not expected.");

                PropertyInfo matchingProperty = typeof(ClientLibraryInformation)
                    .GetProperty(expectedNames[property.Key], BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

                Assert.That(matchingProperty, Is.Not.Null, $"The property, { property.Key }, was not found.");
                Assert.That((string)matchingProperty.GetValue(ClientLibraryInformation.Current, null), Is.EqualTo(property.Value), $"The value for { property.Key } should match.");
            }
        }

        /// <summary>
        ///   Validates functionality of the <see cref="ClientLibraryInformation.SerializedProperties" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void SerializedPropertiesUseDescriptionsWhenPresent()
        {
            ClientLibraryInformation instance = ClientLibraryInformation.Current;

            HashSet<string> expectedNames = new HashSet<string>(
                typeof(ClientLibraryInformation)
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(property => (property.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>(false)?.Description ?? property.Name).ToLowerInvariant()));

            foreach (KeyValuePair<string, string> property in ClientLibraryInformation.Current.SerializedProperties)
            {
                Assert.That(expectedNames.Contains(property.Key), Is.True, $"The property, { property.Key }, was not found.");
            }
        }

        /// <summary>
        ///   Validates functionality of the <see cref="ClientLibraryInformation.SerializedProperties" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void SerializedPropertiesArePopulated()
        {
            foreach (KeyValuePair<string, string> property in ClientLibraryInformation.Current.SerializedProperties)
            {
                Assert.That(property.Value, Is.Not.Null.And.Not.Empty, $"The property, { property.Key }, was not populated.");
            }
        }
    }
}
