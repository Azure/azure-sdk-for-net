// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Provisioning.Tests.TestHelpers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning.Tests
{
    public class EnumValueCustomizationResolverTests
    {
        [Test]
        public void ResolvesEditorBrowsableAndObsoleteMetadata()
        {
            const string customizationSource = """
                using System;
                using Microsoft.TypeSpec.Generator.Customizations;

                [assembly: CodeGenEnumValue(
                    "SampleKind",
                    "LegacyKind",
                    4,
                    WireName = "legacy-kind",
                    EditorBrowsableNever = true,
                    ObsoleteMessage = "Use CurrentKind instead.")]

                namespace Microsoft.TypeSpec.Generator.Customizations
                {
                    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
                    internal sealed class CodeGenEnumValueAttribute : Attribute
                    {
                        public CodeGenEnumValueAttribute(string enumName, string memberName, int value)
                        {
                        }

                        public string? WireName { get; set; }
                        public bool EditorBrowsableNever { get; set; }
                        public string? ObsoleteMessage { get; set; }
                    }
                }
                """;

            var generator = ProvisioningMockHelpers.LoadMockPlugin(customizationSources: [customizationSource]);

            var customization = generator.Object.EnumValueCustomizationResolver
                .GetAdditionalValues("SampleKind", new HashSet<string>())
                .Single();

            Assert.Multiple(() =>
            {
                Assert.That(customization.MemberName, Is.EqualTo("LegacyKind"));
                Assert.That(customization.WireName, Is.EqualTo("legacy-kind"));
                Assert.That(customization.Value, Is.EqualTo(4));
                Assert.That(customization.EditorBrowsableNever, Is.True);
                Assert.That(customization.ObsoleteMessage, Is.EqualTo("Use CurrentKind instead."));
            });
        }
    }
}
