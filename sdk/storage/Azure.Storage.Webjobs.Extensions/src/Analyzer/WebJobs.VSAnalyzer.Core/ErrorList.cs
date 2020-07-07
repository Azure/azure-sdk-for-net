// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Analyzer
{
    // Describe set of diagnostic messages that the analyzer can produce. 
    internal static class ErrorList
    {
        internal const string Category = "WebJobs";

        public static ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return ImmutableArray.Create(
Rule1,
Rule2,
Rule3,
Rule4);
            }
        }

        private static DiagnosticDescriptor Rule1 = new DiagnosticDescriptor(
            "WJ0001",
            "Illegal binding type",
            "Can't bind attribute '{0}' to parameter type '{1}'. Possible options are:{2}",
            Category,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Description #1");

        public static Diagnostic IllegalBindingType(
            ParameterSyntax syntax,
            Attribute attribute,
            Type parameterType,
            ErrorSuggestions[] possibleFixes)
        {
            var sb = new StringBuilder();
            foreach (var possible in possibleFixes)
            {
                sb.Append("\n  " + possible.ToString());
            }

            return Diagnostic.Create(Rule1,
                                          syntax.GetLocation(),
                                          attribute.GetType().Name,
                                          parameterType.ToString(),
                                          sb.ToString());
        }

        private static DiagnosticDescriptor Rule2 = new DiagnosticDescriptor(
                  "WJ0002",
                  "Illegal binding type",
                   "{0} can't be value '{1}': {2}",
                    Category,
                  DiagnosticSeverity.Warning,
                  isEnabledByDefault: true,
                  description: "Description #2");

        // The binding expression has a ValidationAttribute, the validation failed. 
        // Commonly a regex mismatch
        public static Diagnostic FailedValidation(AttributeArgumentSyntax syntax, PropertyInfo propInfo, object actualValue, Exception error)
        {
            return Diagnostic.Create(Rule2,
                                   syntax.GetLocation(),
                                   propInfo.Name,
                                   actualValue,
                                   error.Message
                                   );
        }

        private static DiagnosticDescriptor Rule3 = new DiagnosticDescriptor(
          "WJ0003",
          "Illegal binding expression syntax",
           "{0} can't be value '{1}': {2}",
            Category,
          DiagnosticSeverity.Warning,
          isEnabledByDefault: true,
          description: "Description #3");

        // The binding expression is [AutoResolve] and has an illegal syntax.
        // Commonly unmatched { } 
        public static Diagnostic BadBindingExpressionSyntax(AttributeArgumentSyntax syntax, PropertyInfo propInfo, object actualValue, Exception error)
        {
            return Diagnostic.Create(Rule3,
                                   syntax.GetLocation(),
                                   propInfo.Name,
                                   actualValue,
                                   error.Message
                                   );
        }

        private static DiagnosticDescriptor Rule4 = new DiagnosticDescriptor(
  "WJ0004",
  "Illegal Function name",
   "Function name can't be '{0}'",
    Category,
  DiagnosticSeverity.Warning,
  isEnabledByDefault: true,
  description: "Description #4");

        // The [FunctionName] attribute has an illegal function name.
        public static Diagnostic IllegalFunctionName(AttributeSyntax syntax, string value)
        {
            return Diagnostic.Create(Rule4,
                                   syntax.GetLocation(),
                                   value
                                   );
        }
    }
}
