// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Utilities;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Provisioning.Tests
{
    public class ResourceNameConstraintsHelperTests
    {
        private const ResourceNameCharacters AllKnownCharacters =
            ResourceNameCharacters.LowercaseLetters |
            ResourceNameCharacters.UppercaseLetters |
            ResourceNameCharacters.Numbers |
            ResourceNameCharacters.Hyphen |
            ResourceNameCharacters.Underscore |
            ResourceNameCharacters.Period |
            ResourceNameCharacters.Parentheses;

        [Test]
        public void PartialNameConstraintsUseAllKnownCharacters()
        {
            var constraints = new ArmResourceNameConstraints(null, null, 128);

            var characters = constraints.ToResourceNameCharacters();

            Assert.That(characters, Is.EqualTo(AllKnownCharacters));
        }

        [Test]
        public void PatternParsesLiteralHyphenOutsideCharacterClass()
        {
            var constraints = new ArmResourceNameConstraints("^[a-zA-Z0-9]+(-*[a-zA-Z0-9])*$", 1, 255);

            var characters = constraints.ToResourceNameCharacters();

            Assert.That(characters.HasFlag(ResourceNameCharacters.LowercaseLetters), Is.True);
            Assert.That(characters.HasFlag(ResourceNameCharacters.UppercaseLetters), Is.True);
            Assert.That(characters.HasFlag(ResourceNameCharacters.Numbers), Is.True);
            Assert.That(characters.HasFlag(ResourceNameCharacters.Hyphen), Is.True);
        }
    }
}
