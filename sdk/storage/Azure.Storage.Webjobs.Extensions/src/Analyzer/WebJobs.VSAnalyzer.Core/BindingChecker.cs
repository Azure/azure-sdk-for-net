// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    // Produce warnings for tooling 
    internal class DiagnosticHelper
    {
        private readonly JobHostMetadataProvider _provider;

        public DiagnosticHelper(JobHostMetadataProvider provider)
        {
            _provider = provider;
        }

        private static bool ApplyFilter(Attribute attribute, FilterNode filter)
        {
            if (filter == null)
            {
                return true;
            }
            return filter.Eval(attribute);
        }

        // Returns null on success, else a list of errors. 
        public ErrorSuggestions[] CheckBindingErrors(Attribute attribute, Type targetType)
        {
            var rules = this._provider.GetRules();
            return CheckBindingErrors(rules, attribute, targetType);
        }

        // Primary interface called by tooling to get binding warnings for parameters at compile time. 
        // targetType may not be a reflection implementation.  
        // Returns null on success, else a list of errors. 
        internal static ErrorSuggestions[] CheckBindingErrors(IEnumerable<BindingRule> rules, Attribute attribute, Type targetType)
        {
            if (attribute == null)
            {
                throw new ArgumentNullException(nameof(attribute));
            }
            if (targetType == null)
            {
                throw new ArgumentNullException(nameof(targetType));
            }

            var possible = new HashSet<ErrorSuggestions>();

            foreach (var rule in rules)
            {
                var attr = rule.SourceAttribute;

                bool attrMatch = attr.FullName == attribute.GetType().FullName;
                bool typeMatch = rule.UserType.IsMatch(targetType);
                bool filterMatch = attrMatch && ApplyFilter(attribute, rule.Filter);

                if (attrMatch && filterMatch && typeMatch)
                {
                    // Success!
                    return null;
                }

                // Doesn't match. Add a possible hint about what would match. 
                if (typeMatch)
                {
                    if (attrMatch)
                    {
                        // Filter mismatch 
                        possible.Add(new ErrorSuggestions.FilterMismatch { Filter = rule.Filter });
                    }
                    else
                    {
                        // Possibly use another attribute to bind to this type?
                        possible.Add(new ErrorSuggestions.AttributeMismatch { PossibleAttribute = attr });
                    }
                }
                else
                {
                    if (filterMatch && attrMatch)
                    {
                        possible.Add(new ErrorSuggestions.TypeMismatch { ParameterType = rule.UserType });
                    }
                    else
                    {
                        // Rule is too unrelated 
                    }
                }
            }

            var errors = possible.OrderBy(x => x.ToString()).ToArray();
            return errors;
        }
    }

    // Possible errors to return to tooling. 
    // Tooling can provide different options (such as Code Fix) for each error. 
    internal class ErrorSuggestions
    {
        // We failed because of a filter mismatch. 
        // Fix: Update the attribute to match this filter
        public class FilterMismatch : ErrorSuggestions
        {
            public FilterNode Filter { get; set; }

            public override string ToString()
            {
                return $"set {this.Filter}";
            }
        }

        // Another attribute could bind to this type. 
        // Fix: switch to this attribute. 
        public class AttributeMismatch : ErrorSuggestions
        {
            public Type PossibleAttribute { get; set; }

            public override string ToString()
            {
                return $"try [{this.PossibleAttribute.Name}]";
            }
        }

        // the Attribute and filter match, but the type doesn't. 
        // Fix: try changing to this parameter type. 
        public class TypeMismatch : ErrorSuggestions
        {
            public OpenType ParameterType { get; set; }

            public override string ToString()
            {
                return this.ParameterType.GetDisplayName();
            }
        }
    }
}
