// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace TestProjects.Spector.Tests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal partial class SpectorTestAttribute : TestAttribute, IApplyToTest
    {
        [GeneratedRegex("(?<=[a-z])([A-Z])")]
        private static partial Regex ToKebabCase();

        public new void ApplyToTest(Test test)
        {
            string clientCodeDirectory = GetGeneratedDirectory(test);

            if (!Directory.Exists(clientCodeDirectory))
            {
                // Not all spector scenarios use kebab-case directories, so try again without kebab-case.
                clientCodeDirectory = GetGeneratedDirectory(test, false);
            }

            var clientCsFile = GetClientCsFile(clientCodeDirectory);

            TestContext.Progress.WriteLine($"Checking if '{clientCsFile}' is a stubbed implementation.");
            if (clientCsFile is null || IsLibraryStubbed(clientCsFile))
            {
                SkipTest(test);
            }
        }

        private static bool IsLibraryStubbed(string clientCsFile)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(File.ReadAllText(clientCsFile));
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

            var constructors = root.DescendantNodes()
                .OfType<ConstructorDeclarationSyntax>()
                .ToList();

            if (constructors.Count != 0)
            {
                ConstructorDeclarationSyntax? constructorWithMostParameters = constructors
                    .OrderByDescending(c => c.ParameterList.Parameters.Count)
                    .FirstOrDefault();

                return constructorWithMostParameters?.ExpressionBody != null;
            }

            return true;
        }

        private static void SkipTest(Test test)
        {
            test.RunState = RunState.Ignored;
            TestContext.Progress.WriteLine($"Test skipped because {test.FullName} is currently a stubbed implementation.");
            test.Properties.Set(PropertyNames.SkipReason, $"Test skipped because {test.FullName} is currently a stubbed implementation.");
        }

        private static string? GetClientCsFile(string clientCodeDirectory)
        {
            return Directory.GetFiles(clientCodeDirectory, "*.cs", SearchOption.TopDirectoryOnly)
                .Where(f => f.EndsWith("Client.cs", StringComparison.Ordinal) && !f.EndsWith("RestClient.cs", StringComparison.Ordinal))
                .FirstOrDefault();
        }

        private static string GetGeneratedDirectory(Test test, bool kebabCaseDirectories = true)
        {
            var namespaceParts = test.FullName.Split('.').Skip(3);
            namespaceParts = namespaceParts.Take(namespaceParts.Count() - 2);
            var clientCodeDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "..", "..", "..", "..", "..", "eng", "packages", "http-client-csharp", "generator", "TestProjects", "Spector");
            foreach (var part in namespaceParts)
            {
                clientCodeDirectory = Path.Combine(clientCodeDirectory, FixName(part, kebabCaseDirectories));
            }
            return Path.Combine(clientCodeDirectory, "src", "Generated");
        }

        private static string FixName(string part, bool kebabCaseDirectories)
        {
            if (kebabCaseDirectories)
            {
                return ToKebabCase().Replace(part.StartsWith("_", StringComparison.Ordinal) ? part.Substring(1) : part, "-$1").ToLowerInvariant();
            }
            // Use camelCase
            return char.ToLowerInvariant(part[0]) + part[1..];
        }
    }
}
