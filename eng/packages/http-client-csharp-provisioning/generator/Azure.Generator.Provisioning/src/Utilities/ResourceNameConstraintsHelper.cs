// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;
using System.Linq;
using System.Text.RegularExpressions;

namespace Azure.Generator.Provisioning.Utilities;

/// <summary>
/// Helper to convert regex patterns from ARM spec into <see cref="ResourceNameCharacters"/> flags.
/// </summary>
internal static class ResourceNameConstraintsHelper
{
    /// <summary>
    /// Representative test strings for each <see cref="ResourceNameCharacters"/> flag.
    /// If any character in the test string matches the pattern, the flag is included.
    /// </summary>
    private static readonly (string TestChars, ResourceNameCharacters Flag)[] CharacterTests =
    [
        ("abcxyz", ResourceNameCharacters.LowercaseLetters),
        ("ABCXYZ", ResourceNameCharacters.UppercaseLetters),
        ("0123456789", ResourceNameCharacters.Numbers),
        ("-", ResourceNameCharacters.Hyphen),
        ("_", ResourceNameCharacters.Underscore),
        (".", ResourceNameCharacters.Period),
        ("()", ResourceNameCharacters.Parentheses),
    ];

    extension(string pattern)
    {
        /// <summary>
        /// Converts a regex pattern string into <see cref="ResourceNameCharacters"/> flags
        /// by extracting all character classes from the pattern and testing representative
        /// characters against them.
        /// </summary>
        internal ResourceNameCharacters ParsePatternToResourceNameCharacters()
        {
            // Extract all [...] character class groups from the pattern and combine them
            // so we can test if any position in the pattern accepts each character.
            var charClasses = Regex.Matches(pattern, @"\[(?:[^\]]|\\.)+\]");
            if (charClasses.Count == 0)
            {
                return (ResourceNameCharacters)0;
            }

            var combined = string.Join("|", charClasses.Cast<Match>().Select(m => m.Value));
            var regex = new Regex("^(?:" + combined + ")$");

            var result = (ResourceNameCharacters)0;

            foreach (var (testChars, flag) in CharacterTests)
            {
                foreach (char c in testChars)
                {
                    if (regex.IsMatch(c.ToString()))
                    {
                        result |= flag;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
