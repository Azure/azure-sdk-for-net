// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Path
{
    /// <summary>
    /// This class is used to create <see cref="BindingTemplateSource"/> instances from path template strings.
    /// <see cref="BindingTemplateSource"/> is used at binding time to capture parameter values from actual
    /// paths at runtime, for use in function parameter binding.
    /// </summary>
    [DebuggerDisplay("{Pattern,nq}")]
    public class BindingTemplateSource
    {
        private const string EntirePatternGroupName = "0";
        private readonly string _pattern;
        private readonly Regex _captureRegex;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="pattern">The template pattern.</param>
        /// <param name="captureRegex">The capture regular expression.</param>
        internal BindingTemplateSource(string pattern, Regex captureRegex)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            if (captureRegex == null)
            {
                throw new ArgumentNullException("captureRegex");
            }

            _pattern = pattern;
            _captureRegex = captureRegex;
        }

        /// <summary>
        /// Gets the binding template pattern.
        /// </summary>
        public string Pattern
        {
            get { return _pattern; }
        }

        /// <summary>
        /// Gets the collection of template parameter names parsed from the template pattern.
        /// </summary>
        public IEnumerable<string> ParameterNames
        {
            get
            {
                return _captureRegex.GetGroupNames().Where(n => !String.Equals(n, EntirePatternGroupName));
            }
        }

        /// <summary>
        /// Factory method that constructs a <see cref="BindingTemplateSource"/> from an input binding template pattern.
        /// </summary>
        /// <remarks>
        /// A template string may contain parameters embraced with curly brackets, which get replaced 
        /// with values later when the template is bound. 
        /// </remarks>
        /// <example>
        /// Below is a minimal template that illustrates a few basics:
        /// {p1}-p2/{{2014}}/folder/{name}.{ext}
        /// </example>
        /// <param name="pattern">A binding template pattern string in a supported format (see remarks).
        /// </param>
        /// <param name="ignoreCase">True if matches should be case insensitive.</param>
        /// <returns>An instance of <see cref="BindingTemplateSource"/> for the specified template pattern.</returns>
        public static BindingTemplateSource FromString(string pattern, bool ignoreCase = false)
        {
            IEnumerable<BindingTemplateToken> tokens = BindingTemplateParser.GetTokens(pattern);
            string capturePattern = BindingTemplateToken.BuildCapturePattern(tokens);

            RegexOptions options = RegexOptions.Compiled;
            if (ignoreCase)
            {
                options |= RegexOptions.IgnoreCase;
            }

            return new BindingTemplateSource(pattern, new Regex(capturePattern, options));
        }

        /// <summary>
        /// Parses parameter values from the actual path if it matches the binding template pattern.
        /// </summary>
        /// <param name="actualPath">Path string to match</param>
        /// <returns>Dictionary of parameter names to parameter values, or null if no match.</returns>
        public IReadOnlyDictionary<string, object> CreateBindingData(string actualPath)
        {
            Match match = _captureRegex.Match(actualPath);
            if (!match.Success)
            {
                return null;
            }

            Dictionary<string, object> namedParameters = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            foreach (var parameterName in ParameterNames)
            {
                Debug.Assert(match.Groups[parameterName].Success, 
                    "Capturing pattern shouldn't allow unmatched named parameter groups!");
                namedParameters[parameterName] = match.Groups[parameterName].Value;
            }

            return namedParameters;
        }

        /// <summary>
        /// Returns a string representation of the binding template.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _pattern;
        }
    }
}
