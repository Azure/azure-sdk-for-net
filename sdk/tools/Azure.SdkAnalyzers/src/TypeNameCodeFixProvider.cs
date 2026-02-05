// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Text;
using System;
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

            // Generate name suggestions using shared helper
            ImmutableArray<string> suggestions = TypeNameSuggestionHelper.GenerateNameSuggestions(typeSymbol);

            // Create individual code actions for each suggestion
            ImmutableArray<CodeAction> nestedActions = suggestions.Select(suggestion =>
                CodeAction.Create(
                    title: $"Rename to '{suggestion}'",
                    createChangedSolution: c => generatedInfo.IsInGeneratedFolder
                        ? RenameGeneratedTypeAsync(context.Document, typeSymbol, suggestion, generatedInfo, c)
                        : RenameTypeAsync(context.Document.Project.Solution, context.Document, typeSymbol, suggestion, c),
                    equivalenceKey: suggestion)).ToImmutableArray();

            // Register a parent action with nested children for IDE submenu experience
            // Note: dotnet format does not support nested actions, so an external orchestrator
            // must be used to automate these fixes in CLI scenarios
            CodeAction parentAction = CodeAction.Create(
                title: "Fix AZC0012",
                nestedActions: nestedActions,
                isInlinable: false);

            context.RegisterCodeFix(parentAction, diagnostic);
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

            return await RenameTypeAsync(solution, document, typeSymbol, newName, cancellationToken);
        }

        private string GenerateCustomTypeCode(INamedTypeSymbol typeSymbol, string newName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendNormalizedLine("// Copyright (c) Microsoft Corporation. All rights reserved.");
            sb.AppendNormalizedLine("// Licensed under the MIT License.");
            sb.AppendNormalizedLine("");
            sb.AppendNormalizedLine("using Microsoft.TypeSpec.Generator.Customizations;");
            sb.AppendNormalizedLine("");
            sb.AppendNormalizedLine($"namespace {typeSymbol.ContainingNamespace.ToDisplayString()}");
            sb.AppendNormalizedLine("{");

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
                        sb.AppendNormalizedLine($"    {line.TrimStart()}");
                    }
                }
            }

            // Add CodeGenType attribute with the original name
            sb.AppendNormalizedLine($"    [CodeGenType(\"{typeSymbol.Name}\")]");

            // Determine the type kind and accessibility
            string typeKind = typeSymbol.TypeKind switch
            {
                TypeKind.Class => "class",
                TypeKind.Struct => "struct",
                TypeKind.Interface => "interface",
                _ => "class"
            };

            string readonlyModifier = typeSymbol.TypeKind == TypeKind.Struct ? "readonly " : "";

            sb.AppendNormalizedLine($"    public {readonlyModifier}partial {typeKind} {newName} {{ }}");

            sb.AppendNormalizedLine("}");

            return sb.ToString();
        }

        private async Task<Solution> RenameTypeAsync(Solution solution, Document document, INamedTypeSymbol typeSymbol, string newName, CancellationToken cancellationToken)
        {
            // Rename the symbol and all its references
            Solution newSolution = await Renamer.RenameSymbolAsync(
                solution,
                typeSymbol,
                new SymbolRenameOptions(),
                newName,
                cancellationToken).ConfigureAwait(false);

            // Also rename the file to match the new type name
            Document newDocument = newSolution.GetDocument(document.Id);
            if (newDocument != null)
            {
                string oldFileName = Path.GetFileNameWithoutExtension(newDocument.Name);
                string extension = Path.GetExtension(newDocument.Name);

                // Only rename if the file name matches the old type name
                if (!string.IsNullOrEmpty(oldFileName) && oldFileName.Equals(typeSymbol.Name, StringComparison.Ordinal))
                {
                    string newFileName = newName + extension;
                    newSolution = newSolution.WithDocumentName(newDocument.Id, newFileName);
                }
            }

            return newSolution;
        }
    }
}
