// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.IO;
using Microsoft.CodeAnalysis.Simplification;
using AutoRest.Core.Utilities;
using Microsoft.Rest.Azure;
using Microsoft.Rest;

namespace Microsoft.CodeSimplifier
{
    class Program
    {
        private static MetadataReference _mscorlib;

        private static MetadataReference Mscorlib
        {
            get
            {
                if (_mscorlib == null)
                {
                    _mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
                }

                return _mscorlib;
            }
        }

        static void Main(string[] args)
        {
            var input = args[0];
            var outputFolder = args[1];

            // Can't pull Microsoft.Rest.ClientRuntime or Azure from current assembly unless we load this assembly
            var op = new AzureAsyncOperation();
            var restOp = new RestException();

            // Get all files from the input directory
            var fileSystem = new FileSystem();
            var files = fileSystem.GetFiles(input, "*.cs", SearchOption.AllDirectories)
                .Select(each => new KeyValuePair<string, string>(each, fileSystem.ReadFileAsText(each))).ToArray();

            // Create the project and add references
            var projectId = ProjectId.CreateNewId();
            var solution = new AdhocWorkspace().CurrentSolution
                .AddProject(projectId, "MyProject", "MyProject", LanguageNames.CSharp)
                .AddMetadataReference(projectId, Mscorlib)
                .AddMetadataReference(projectId, AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => string.Compare(a.GetName().Name, "Microsoft.Rest.ClientRuntime.Azure", StringComparison.OrdinalIgnoreCase) == 0)
                    .Select(a => MetadataReference.CreateFromFile(a.Location)).Single())
                .AddMetadataReference(projectId, AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => string.Compare(a.GetName().Name, "Microsoft.Rest.ClientRuntime", StringComparison.OrdinalIgnoreCase) == 0)
                    .Select(a => MetadataReference.CreateFromFile(a.Location)).Single())
                .AddMetadataReference(projectId, AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => string.Compare(a.GetName().Name, "System", StringComparison.OrdinalIgnoreCase) == 0)
                    .Select(a => MetadataReference.CreateFromFile(a.Location)).Single());

            // Add the files from the input directory to the project
            foreach (var file in files)
            {
                var documentId = DocumentId.CreateNewId(projectId);
                solution = solution.AddDocument(documentId, file.Key, SourceText.From(file.Value));
            }

            // For each doc, simplify the syntax tree and write it to disk
            foreach (var proj in solution.Projects)
            {
                foreach (var document in proj.Documents)
                {
                    var newRoot = (SyntaxNode)document.GetSyntaxRootAsync().Result;

                    // Add simplify annotations (which let Roslyn know to simplify the token
                    newRoot = new SimplifyNamesAnnotionRewriter().Visit(newRoot);
                    var doc = document.WithSyntaxRoot(newRoot);

                    // Call Reduce on each file and write to disk
                    File.WriteAllText(document.Name, Simplifier.ReduceAsync(doc).Result.GetTextAsync().Result.ToString());
                }
            }
        }
    }
}
