// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;

namespace Extensions.Plugin.Visitors
{
    /// <summary>
    /// A visitor that adds <see cref="ExperimentalAttribute"/> to generated public types that are not
    /// present in the stable-types baseline. This ensures that newly introduced generated types are
    /// automatically tagged as experimental until explicitly promoted.
    /// </summary>
    /// <remarks>
    /// This visitor mirrors the pattern established by the upstream OpenAI library's codegen plugin
    /// (ExperimentalAttributeVisitor), adapted for Azure.AI.Extensions.OpenAI conventions.
    /// </remarks>
    public class ExperimentalAttributeVisitor : ScmLibraryVisitor
    {
        private const string DiagnosticId = "AOAIEXT001";

        private static readonly Lazy<HashSet<string>> _stableTypes = new(LoadStableTypes);

        private readonly HashSet<string> _attributedTypes = new(StringComparer.Ordinal);

        private static HashSet<string> LoadStableTypes()
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("stable-types.yaml")
                ?? throw new InvalidOperationException("Embedded resource 'stable-types.yaml' not found.");
            using StreamReader reader = new(stream);

            var stableTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            string? line;
            bool inSection = false;
            while ((line = reader.ReadLine()) != null)
            {
                string trimmed = line.Trim();
                if (trimmed.Length == 0 || trimmed.StartsWith("#"))
                    continue;

                if (trimmed == "stableTypes:")
                {
                    inSection = true;
                    continue;
                }

                if (inSection && trimmed.StartsWith("- "))
                {
                    stableTypes.Add(trimmed.Substring(2).Trim());
                }
            }

            return stableTypes;
        }

        /// <inheritdoc />
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            string fullName = $"{type.Type.Namespace}.{type.Name}";

            if ((type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public)
                    || type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Protected))
                && !_stableTypes.Value.Contains(fullName)
                && !type.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)))
                && _attributedTypes.Add(fullName))
            {
                type.Update(
                    attributes: [.. type.Attributes,
                        new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);

                return type;
            }

            return base.VisitType(type);
        }
    }
}
