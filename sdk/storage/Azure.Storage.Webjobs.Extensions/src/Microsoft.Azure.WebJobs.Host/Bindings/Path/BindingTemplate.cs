// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Path
{
    /// <summary>
    /// A binding template class providing method of resolving parameterized template into a string by replacing
    /// template parameters with parameter values.
    /// </summary>
    [DebuggerDisplay("{Pattern,nq}")]
    public class BindingTemplate
    {
        private readonly string _pattern;
        private readonly IReadOnlyList<BindingTemplateToken> _tokens;
        private readonly bool _ignoreCase;

        internal BindingTemplate(string pattern, IReadOnlyList<BindingTemplateToken> tokens, bool ignoreCase = false)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            if (tokens == null)
            {
                throw new ArgumentNullException("tokens");
            }

            _pattern = pattern;
            _tokens = tokens;
            _ignoreCase = ignoreCase;
        }

        /// <summary>
        /// Gets the binding pattern.
        /// </summary>
        public string Pattern
        {
            get { return _pattern; }
        }

        internal IEnumerable<BindingTemplateToken> Tokens
        {
            get { return _tokens; }
        }

        /// <summary>
        /// Gets the collection of parameter names this pattern applies to.
        /// </summary>
        public IEnumerable<string> ParameterNames
        {
            get
            {
                return from p in Tokens
                       let name = p.ParameterName
                       where name != null
                       select name;
            }
        }

        /// <summary>
        /// True if this expression has parameters. 
        /// </summary>
        public bool HasParameters => ParameterNames.Any();

        /// <summary>
        /// A factory method to parse input template string and construct a binding template instance using
        /// parsed tokens sequence.
        /// </summary>
        /// <param name="input">A binding template string in a format supported by <see cref="BindingTemplateParser"/>.
        /// </param>
        /// <param name="ignoreCase">True if matching should be case insensitive.</param>
        /// <returns>Valid ready-to-use instance of <see cref="BindingTemplate"/>.</returns>
        public static BindingTemplate FromString(string input, bool ignoreCase = false)
        {
            IReadOnlyList<BindingTemplateToken> tokens = BindingTemplateParser.ParseTemplate(input);
            return new BindingTemplate(input, tokens, ignoreCase);
        }

        /// <summary>
        /// Resolves original parameterized template into a string by replacing parameters with values provided as
        /// a dictionary.
        /// </summary>
        /// <param name="parameters">Dictionary providing parameter values.</param>
        /// <returns>Resolved string if succeeded.</returns>
        /// <exception cref="InvalidOperationException">Thrown when required parameter value is not available.
        /// </exception>
        public string Bind(IReadOnlyDictionary<string, object> parameters)
        {
            StringBuilder builder = new StringBuilder();

            if (_ignoreCase && parameters != null)
            {
                // convert to a case insensitive dictionary
                var caseInsensitive = new Dictionary<string, object>(parameters.Count, StringComparer.OrdinalIgnoreCase);
                foreach (var pair in parameters)
                {
                    caseInsensitive.Add(pair.Key, pair.Value);
                }
                parameters = caseInsensitive;
            }

            foreach (var token in Tokens)
            {
                var value = token.Evaluate(parameters);
                builder.Append(value);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Resolves original parameterized template into a string by replacing parameters with values provided as
        /// a dictionary.
        /// </summary>
        /// <param name="parameters">Dictionary providing parameter values.</param>
        /// <returns>Resolved string if succeeded.</returns>
        /// <exception cref="InvalidOperationException">Thrown when required parameter value is not available.
        /// </exception>
        [Obsolete("Switch to the overload accepting a IReadOnlyDictionary<string, object>.")]
        public string Bind(IReadOnlyDictionary<string, string> parameters)
        {
            var adapter = new Dictionary<string, object>();
            if (parameters != null)
            {
                foreach (var kv in parameters)
                {
                    adapter[kv.Key] = kv.Value;
                }
            }            

            return Bind(adapter);
        }

        /// <summary>
        /// Gets a string representation of the binding template.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _pattern;
        }
    }
}
