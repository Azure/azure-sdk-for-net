// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Path
{
    /// <summary>
    /// A class designed to provide a method of parsing binding template strings into a sequence of tokens.
    /// </summary>
    /// <remarks>
    /// A template is a plain text and may contain parameters embraced with curly brackets, which get replaced 
    /// with values later when the template is bound. 
    /// </remarks>
    /// <example>
    /// Below is a minimal template that illustrates a few basics:
    /// {p1}-p2/{{2014}}/folder/{name}.{ext}
    /// </example>
    internal class BindingTemplateParser
    {
        private const string TokenRule =
            @"(" +
            // 1st Alternative: 
            // Named capturing group escape
            // matches the characters '{{' or '}}' literally
            @"  (?<escape> (\{\{) | (\}\}) ) |" +
            // 2nd Alternative:
            // Non-capturing group of '{' and '}' embraced sequence
            @"  ( \{" + 
            // Named capturing group parameter
            // match a single character not present in the list below
            // between zero and unlimited times, as many times as possible, giving back as needed [greedy]
            @"      (?<parameter> [^\{\}]*)" +
            @"  \} ) |" +
            // 3rd Alternative:
            // Named capturing group literal
            // match a single character not present in the list below
            // between one and unlimited times, as many times as possible, giving back as needed [greedy]
            @"  (?<literal> [^\{\}]+) |" +
            // 4th Alternative:
            // Named capturing group unbalanced
            // match a single character present in the list below literally
            @"  (?<unbalanced> [\{\}])" +
            @")";

        // Validation grammar used to validate token rule and ensure entire input string is a list of zero or more
        // tokens
        private const string ValidateGrammar =
            @"(?xn)^" + TokenRule + "*$";

        // definition of a valid C# identifier: http://msdn.microsoft.com/en-us/library/aa664670(v=vs.71).aspx
        private const string FormattingCharacter = @"\p{Cf}";
        private const string ConnectingCharacter = @"\p{Pc}";
        private const string DecimalDigitCharacter = @"\p{Nd}";
        private const string CombiningCharacter = @"\p{Mn}|\p{Mc}";
        private const string LetterCharacter = @"\p{Lu}|\p{Ll}|\p{Lt}|\p{Lm}|\p{Lo}|\p{Nl}";
        private const string ExpressionCharacter = @"\.|\-"; // characters allowed in expressions
        private const string IdentifierPartCharacter = 
            LetterCharacter + "|" +
            DecimalDigitCharacter + "|" +
            ConnectingCharacter + "|" +
            CombiningCharacter + "|" +
            ExpressionCharacter + "|" + 
            FormattingCharacter;

        // Validation regex pattern of C# identifier
        private const string IdentifierPattern = "^(" + LetterCharacter + "|_)" + 
            "(" + "(" + IdentifierPartCharacter + ")+" + ")*$";

        /// <summary>
        /// Template parser's main entry point to validate and parse input template string.
        /// </summary>
        /// <param name="input">A template pattern string in supported format.</param>
        /// <returns>A read-only list of recognized and validated tokens.</returns>
        /// <exception cref="FormatException">Thrown when the input has unbalanced brackets, parameter name doesn't 
        /// match C# identifier definition, or some other content validation rule fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown when input argument is null.</exception>
        public static IReadOnlyList<BindingTemplateToken> ParseTemplate(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            return GetTokens(input).ToList();
        }
        
        /// <summary>
        /// Creates a streaming iterator to scan the input string and generate valid template tokens.
        /// </summary>
        /// <param name="input">A template pattern string in supported format.</param>
        /// <returns>A sequence of tokens.</returns>
        /// <exception cref="FormatException">Thrown when the input has unbalanced brackets, parameter name doesn't 
        /// match C# identifier definition, or some other content validation rule fails.</exception>
        public static IEnumerable<BindingTemplateToken> GetTokens(string input)
        {
            // Validate token rule is up-to-date and input string matches a pattern of sequence of tokens.
            // Ensure input string has no unrecognized chunks.
            Debug.Assert(Regex.IsMatch(input, ValidateGrammar));

            Regex grammarRegex = new Regex(TokenRule, 
                RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace);

            const string EntirePatternGroupName = "0";
            string[] groupNames = grammarRegex.GetGroupNames().Where(
                s => !String.Equals(s, EntirePatternGroupName)).ToArray();

            // Outer loop iterates over all matched tokens in the input.
            foreach (Match m in grammarRegex.Matches(input))
            {
                // Inner loops scans over possible token type alternatives of currently matched token.
                // It could be escaped character, parameter, or literal chunk.
                foreach (var name in groupNames.Where(n => m.Groups[n].Success))
                {
                    Group namedGroup = m.Groups[name];
                    switch (name)
                    {
                        case "escape":
                            string value = Char.ToString(namedGroup.Value[0]);
                            yield return BindingTemplateToken.NewLiteral(value);
                            break;
                        case "parameter":
                            if (String.IsNullOrEmpty(namedGroup.Value))
                            {
                                throw new FormatException(String.Format(
                                    "Invalid template '{0}'. The parameter name at position {1} is empty.",
                                    input, m.Index + 1));
                            }

                            BindingTemplateToken token;            
                            try
                            {
                                token = BindingTemplateToken.NewExpression(namedGroup.Value);
                            }
                            catch (FormatException e)
                            {
                                throw new FormatException($"Invalid template '{input}'. {e.Message}");
                            }
                            yield return token;
                            break;
                            
                        case "literal":
                            yield return BindingTemplateToken.NewLiteral(namedGroup.Value);
                            break;
                        case "unbalanced":
                            throw new FormatException(String.Format(
                                "Invalid template '{0}'. Missing {1} bracket at position {2}.",
                                input, namedGroup.Value[0] == '{' ? "closing" : "opening", m.Index + 1));
                        default:
                            Debug.Fail("Unsupported named group!");
                            break;
                    }
                }
            }
        }

        internal static bool IsValidIdentifier(string identifier)
        {
            // built-in sysetem identifiers are valid
            if (BindingParameterResolver.IsSystemParameter(identifier))
            {
                return true;
            }

            // match against our identifier regex
            // note that system identifiers include a '-' character so wouldn't
            // pass this test
            return Regex.IsMatch(identifier, IdentifierPattern);
        }
    }
}
