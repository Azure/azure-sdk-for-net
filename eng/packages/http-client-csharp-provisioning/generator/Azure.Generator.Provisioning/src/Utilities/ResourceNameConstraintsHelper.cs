// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Provisioning.Primitives;
using System.Linq;
using System.Text.RegularExpressions;

namespace Azure.Generator.Provisioning.Utilities;

/// <summary>
/// Helper to convert regex patterns from ARM spec into <see cref="ResourceNameCharacters"/> flags.
/// </summary>
internal static class ResourceNameConstraintsHelper
{
    private const ResourceNameCharacters AllKnownCharacters =
        ResourceNameCharacters.LowercaseLetters |
        ResourceNameCharacters.UppercaseLetters |
        ResourceNameCharacters.Numbers |
        ResourceNameCharacters.Hyphen |
        ResourceNameCharacters.Underscore |
        ResourceNameCharacters.Period |
        ResourceNameCharacters.Parentheses;

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

    extension(ArmResourceNameConstraints constraints)
    {
        internal ResourceNameCharacters ToResourceNameCharacters()
        {
            if (constraints.Pattern is null)
            {
                return AllKnownCharacters;
            }

            var parsed = ParsePatternToResourceNameCharacters(constraints.Pattern);
            return parsed == 0 ? AllKnownCharacters : parsed;
        }
    }

    /// <summary>
    /// Converts a regex pattern string into <see cref="ResourceNameCharacters"/> flags by extracting
    /// bracketed character classes (e.g. <c>[a-z]</c>) and testing representative characters against them,
    /// then scanning the remaining pattern for literal hyphen/underscore and escaped period/parentheses.
    /// </summary>
    private static ResourceNameCharacters ParsePatternToResourceNameCharacters(string pattern)
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

        var patternWithoutCharacterClasses = Regex.Replace(pattern, @"\[(?:[^\]]|\\.)+\]", "");
        if (Regex.IsMatch(patternWithoutCharacterClasses, @"(?<!\\)-|\\-"))
        {
            result |= ResourceNameCharacters.Hyphen;
        }
        if (patternWithoutCharacterClasses.Contains('_'))
        {
            result |= ResourceNameCharacters.Underscore;
        }
        if (Regex.IsMatch(patternWithoutCharacterClasses, @"\\\."))
        {
            result |= ResourceNameCharacters.Period;
        }
        if (Regex.IsMatch(patternWithoutCharacterClasses, @"\\[()]"))
        {
            result |= ResourceNameCharacters.Parentheses;
        }

        return result;
    }
}
