// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace SnippetGenerator
{
    public class Program
    {
        [Option(ShortName = "u")]
        public string Markdown { get; set; }

        [Option(ShortName = "s")]
        public string Snippets { get; set; }

        public static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
        }

        public async Task OnExecuteAsync()
        {
            Console.WriteLine($"Processing {Markdown}");

            var text = File.ReadAllText(Markdown);
            var snippets = await GetSnippetsInDirectory(Snippets);
            Console.WriteLine($"Discovered snippets:");

            foreach (var snippet in snippets)
            {
                Console.WriteLine($" {snippet.Name}");
            }

            text = MarkdownProcessor.Process(text, s => {
                var selectedSnippets = snippets.Where(snip => snip.Name == s).ToArray();
                if (selectedSnippets.Length > 1)
                {
                    throw new InvalidOperationException($"Multiple snippets with the name '{s}' defined '{Snippets}'");
                }
                if (selectedSnippets.Length == 0)
                {
                    throw new InvalidOperationException($"Snippet '{s}' not found in directory '{Snippets}'");
                }

                var selectedSnippet = selectedSnippets.Single();
                Console.WriteLine($"Replaced {selectedSnippet.Name}");
                return FormatSnippet(selectedSnippet.Text);
            });

            File.WriteAllText(Markdown, text);
        }

        private string FormatSnippet(SourceText text)
        {
            int minIndent = int.MaxValue;
            int firstLine = 0;
            var lines = text.Lines.Select(l => l.ToString()).ToArray();

            int lastLine = lines.Length - 1;

            while (string.IsNullOrWhiteSpace(lines[firstLine]))
            {
                firstLine++;
            }

            while (string.IsNullOrWhiteSpace(lines[lastLine]))
            {
                lastLine--;
            }

            for (var index = firstLine; index <= lastLine; index++)
            {
                var textLine = lines[index];

                if (string.IsNullOrWhiteSpace(textLine))
                {
                    continue;
                }

                int i;
                for (i = 0; i < textLine.Length; i++)
                {
                    if (!char.IsWhiteSpace(textLine[i])) break;
                }

                minIndent = Math.Min(minIndent, i);
            }

            var stringBuilder = new StringBuilder();
            for (var index = firstLine; index  <= lastLine; index++)
            {
                var line = lines[index];
                line = string.IsNullOrWhiteSpace(line) ? string.Empty : line.Substring(minIndent);
                stringBuilder.AppendLine(line);
            }

            return stringBuilder.ToString();
        }

        private async Task<List<Snippet>> GetSnippetsInDirectory(string baseDirectory)
        {
            var list = new List<Snippet>();
            foreach (var file in Directory.GetFiles(baseDirectory, "*.cs", SearchOption.AllDirectories))
            {
                var syntaxTree = CSharpSyntaxTree.ParseText(
                    File.ReadAllText(file),
                    new CSharpParseOptions(LanguageVersion.Preview),
                    path: file);
                list.AddRange(await GetAllSnippetsAsync(syntaxTree));
            }

            return list;
        }

        private async Task<Snippet[]> GetAllSnippetsAsync(SyntaxTree syntaxTree)
        {
            var snippets = new List<Snippet>();
            var directiveWalker = new DirectiveWalker();
            directiveWalker.Visit(await syntaxTree.GetRootAsync());

            foreach (var region in directiveWalker.Regions)
            {
                var syntaxTrivia = region.Item1.EndOfDirectiveToken.LeadingTrivia.First(t => t.IsKind(SyntaxKind.PreprocessingMessageTrivia));
                var fromBounds = TextSpan.FromBounds(
                    region.Item1.GetLocation().SourceSpan.End,
                    region.Item2.GetLocation().SourceSpan.Start);

                snippets.Add(new Snippet(syntaxTrivia.ToString(), syntaxTree.GetText().GetSubText(fromBounds)));
            }

            return snippets.ToArray();
        }

        class DirectiveWalker : CSharpSyntaxWalker
        {
            private Stack<RegionDirectiveTriviaSyntax> _regions = new Stack<RegionDirectiveTriviaSyntax>();
            public List<(RegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)> Regions { get; } = new List<(RegionDirectiveTriviaSyntax, EndRegionDirectiveTriviaSyntax)>();

            public DirectiveWalker() : base(SyntaxWalkerDepth.StructuredTrivia)
            {
            }

            public override void VisitRegionDirectiveTrivia(RegionDirectiveTriviaSyntax node)
            {
                base.VisitRegionDirectiveTrivia(node);
                _regions.Push(node);
            }

            public override void VisitEndRegionDirectiveTrivia(EndRegionDirectiveTriviaSyntax node)
            {
                base.VisitEndRegionDirectiveTrivia(node);
                Regions.Add((_regions.Pop(), node));
            }
        }
    }
}
