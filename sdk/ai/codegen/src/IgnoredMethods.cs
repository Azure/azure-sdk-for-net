using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Extensions.Plugin
{
    /// <summary>
    /// Reads the list of fully qualified methods, which must ignore the AAIP001 warning.
    /// </summary>
    internal class IgnoredMethods
    {
        private static Lazy<HashSet<string>> _stableTypes = new(LoadIgnoredMethodTypes);

        private static HashSet<string> LoadIgnoredMethodTypes()
        {
            // Read in the manually curated file fith fully qualified method names, which have to be ignored.
            string yaml = $"ignore-methods.yaml";
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(yaml)
                ?? throw new InvalidOperationException($"Embedded resource '{yaml}' not found.");
            using StreamReader reader = new(stream);
            var stableTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            string line;
            bool inSection = false;
            while ((line = reader.ReadLine()) != null)
            {
                string trimmed = line.Trim();
                if (trimmed.Length == 0 || trimmed.StartsWith("#"))
                    continue;

                if (trimmed == "ignoredMethods:")
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

        public static bool IsIgnored(MethodProvider method) => _stableTypes.Value.Contains($"{method.EnclosingType.Type.FullyQualifiedName}.{method.Signature.Name}");
    }
}
