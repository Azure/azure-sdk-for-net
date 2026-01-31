// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.SdkAnalyzers
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(TypeNameCodeFixProvider)), Shared]
    public class TypeNameCodeFixProvider : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create("AZC0012");

        public sealed override FixAllProvider GetFixAllProvider() => null;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            SyntaxNode root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
            if (root is null)
            {
                return;
            }

            Diagnostic diagnostic = context.Diagnostics.First();
            TextSpan diagnosticSpan = diagnostic.Location.SourceSpan;

            SemanticModel semanticModel = await context.Document.GetSemanticModelAsync(context.CancellationToken).ConfigureAwait(false);
            if (semanticModel == null)
            {
                return;
            }

            SyntaxToken token = root.FindToken(diagnosticSpan.Start);
            INamedTypeSymbol typeSymbol = semanticModel.GetDeclaredSymbol(token.Parent, context.CancellationToken) as INamedTypeSymbol;

            if (typeSymbol == null)
            {
                return;
            }

            // Check if file is in Generated folder and determine path separator once
            string filePath = context.Document.FilePath;
            GeneratedFolderInfo generatedInfo = GeneratedFolderHelper.GetGeneratedFolderInfo(filePath);

            // We don't generate interfaces, so if this is an interface in Generated folder, don't offer fix
            // (we can't add [CodeGenType] attribute to interfaces)
            if (generatedInfo.IsInGeneratedFolder && typeSymbol.TypeKind == TypeKind.Interface)
            {
                return;
            }

            // Generate 3 name suggestions based on namespace parts
            ImmutableArray<string> suggestions = GenerateNameSuggestions(typeSymbol);

            // Create nested actions for each suggestion
            ImmutableArray<CodeAction>.Builder nestedActions = ImmutableArray.CreateBuilder<CodeAction>();
            foreach (string suggestion in suggestions)
            {
                CodeAction action = CodeAction.Create(
                    title: $"Rename to '{suggestion}'",
                    createChangedSolution: c => generatedInfo.IsInGeneratedFolder
                        ? RenameGeneratedTypeAsync(context.Document, typeSymbol, suggestion, generatedInfo, c)
                        : RenameTypeAsync(context.Document, typeSymbol, suggestion, c),
                    equivalenceKey: suggestion);

                nestedActions.Add(action);
            }

            // Create a parent code action that contains the nested actions
            CodeAction parentAction = CodeAction.Create(
                title: "Fix AZC0012: Rename type",
                nestedActions: nestedActions.ToImmutable(),
                isInlinable: false);

            context.RegisterCodeFix(parentAction, diagnostic);
        }

        private ImmutableArray<string> GenerateNameSuggestions(INamedTypeSymbol typeSymbol)
        {
            ImmutableArray<string>.Builder suggestions = ImmutableArray.CreateBuilder<string>();
            string currentName = typeSymbol.Name;

            // For interfaces, work with the name without 'I' prefix
            string baseName = currentName;
            bool isInterface = typeSymbol.TypeKind == TypeKind.Interface;
            if (isInterface && currentName.Length > 1 && currentName[0] == 'I' && char.IsUpper(currentName[1]))
            {
                baseName = currentName.Substring(1);
            }

            // Get namespace parts (exclude 'Azure' and common prefixes)
            List<string> namespaceParts = typeSymbol.ContainingNamespace.ToDisplayString()
                .Split('.')
                .Where(p => !string.Equals(p, "Azure", StringComparison.OrdinalIgnoreCase) &&
                           !string.IsNullOrWhiteSpace(p))
                .Reverse()
                .ToList();

            // Generate up to 3 suggestions using namespace parts
            int suggestionCount = 0;
            foreach (string part in namespaceParts)
            {
                if (suggestionCount >= 3)
                    break;

                string newName = part + baseName;

                // Add 'I' prefix back for interfaces
                if (isInterface && newName[0] != 'I')
                {
                    newName = "I" + newName;
                }

                // Avoid suggesting the same name
                if (!string.Equals(newName, currentName, StringComparison.Ordinal))
                {
                    suggestions.Add(newName);
                    suggestionCount++;
                }
            }

            // If we don't have enough suggestions, add some generic ones
            while (suggestions.Count < 3)
            {
                string fallback;
                if (suggestions.Count == 0)
                {
                    fallback = baseName + "Service";
                }
                else if (suggestions.Count == 1)
                {
                    fallback = baseName + "Client";
                }
                else
                {
                    fallback = baseName + "Options";
                }

                if (isInterface && fallback[0] != 'I')
                {
                    fallback = "I" + fallback;
                }

                if (!suggestions.Contains(fallback) && !string.Equals(fallback, currentName, StringComparison.Ordinal))
                {
                    suggestions.Add(fallback);
                }
                else
                {
                    // If the fallback is already used, add a number
                    suggestions.Add($"{baseName}Type{suggestions.Count}");
                }
            }

            return suggestions.ToImmutable();
        }

        private async Task<Solution> RenameGeneratedTypeAsync(Document document, INamedTypeSymbol typeSymbol, string newName, GeneratedFolderInfo generatedInfo, CancellationToken cancellationToken)
        {
            Solution solution = document.Project.Solution;
            string filePath = document.FilePath;

            if (string.IsNullOrEmpty(filePath) || !generatedInfo.IsInGeneratedFolder)
            {
                return solution;
            }

            Project project = solution.GetProject(document.Project.Id);
            if (project == null)
            {
                return solution;
            }

            // Build custom file name
            string customFileName = newName + ".cs";

            // Generate the custom code content
            string customCode = GenerateCustomTypeCode(typeSymbol, newName);

            // Add the document with folders from helper - VS will create the directories
            Document customDocument = project.AddDocument(customFileName, customCode, generatedInfo.CustomFolders);
            solution = customDocument.Project.Solution;

            // Also perform the rename to update the generated file symbols
            solution = await Renamer.RenameSymbolAsync(
                solution,
                typeSymbol,
                new SymbolRenameOptions(),
                newName,
                cancellationToken).ConfigureAwait(false);

            // Rename the generated file to match the new type name
            Document updatedDocument = solution.GetDocument(document.Id);
            if (updatedDocument != null && !string.IsNullOrEmpty(updatedDocument.FilePath))
            {
                string oldFileName = Path.GetFileNameWithoutExtension(updatedDocument.Name);
                string extension = Path.GetExtension(updatedDocument.Name);

                // Only rename if the file name matches the old type name
                if (oldFileName.Equals(typeSymbol.Name, StringComparison.Ordinal))
                {
                    string newFileName = newName + extension;
                    solution = solution.WithDocumentName(updatedDocument.Id, newFileName);
                }
            }

            return solution;
        }

        private string GenerateCustomTypeCode(INamedTypeSymbol typeSymbol, string newName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("// Copyright (c) Microsoft Corporation. All rights reserved.");
            sb.AppendLine("// Licensed under the MIT License.");
            sb.AppendLine();
            sb.AppendLine("using Microsoft.TypeSpec.Generator.Customizations;");
            sb.AppendLine();
            sb.AppendLine($"namespace {typeSymbol.ContainingNamespace.ToDisplayString()}");
            sb.AppendLine("{");

            // Copy the original documentation comment exactly as written
            SyntaxReference syntaxRef = typeSymbol.DeclaringSyntaxReferences.FirstOrDefault();
            if (syntaxRef != null)
            {
                SyntaxNode syntaxNode = syntaxRef.GetSyntax();
                string docComment = syntaxNode.GetLeadingTrivia()
                    .Where(t => t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia) ||
                                t.IsKind(SyntaxKind.MultiLineDocumentationCommentTrivia))
                    .Select(t => t.ToFullString())
                    .FirstOrDefault();

                if (!string.IsNullOrEmpty(docComment))
                {
                    // Add indentation to each line
                    foreach (string line in docComment.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries))
                    {
                        sb.AppendLine($"    {line.TrimStart()}");
                    }
                }
            }

            // Add CodeGenType attribute with the original name
            sb.AppendLine($"    [CodeGenType(\"{typeSymbol.Name}\")]");

            // Determine the type kind and accessibility
            string typeKind = typeSymbol.TypeKind switch
            {
                TypeKind.Class => "class",
                TypeKind.Struct => "struct",
                TypeKind.Interface => "interface",
                _ => "class"
            };

            string readonlyModifier = typeSymbol.TypeKind == TypeKind.Struct ? "readonly " : "";

            sb.AppendLine($"    public {readonlyModifier}partial {typeKind} {newName} {{ }}");
            sb.AppendLine("}");

            return sb.ToString();
        }

        private async Task<Solution> RenameTypeAsync(Document document, INamedTypeSymbol typeSymbol, string newName, CancellationToken cancellationToken)
        {
            Solution solution = document.Project.Solution;

            // Rename the symbol and all its references
            Solution newSolution = await Renamer.RenameSymbolAsync(
                solution,
                typeSymbol,
                new SymbolRenameOptions(),
                newName,
                cancellationToken).ConfigureAwait(false);

            // Also rename the file to match the new type name
            Document newDocument = newSolution.GetDocument(document.Id);
            if (newDocument != null && !string.IsNullOrEmpty(newDocument.FilePath))
            {
                string oldFileName = Path.GetFileNameWithoutExtension(newDocument.Name);
                string extension = Path.GetExtension(newDocument.Name);

                // Only rename if the file name matches the old type name
                if (oldFileName.Equals(typeSymbol.Name, StringComparison.Ordinal))
                {
                    string newFileName = newName + extension;
                    newSolution = newSolution.WithDocumentName(newDocument.Id, newFileName);
                }
            }

            return newSolution;
        }
    }
}
