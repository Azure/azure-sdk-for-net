// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace SnippetGenerator
{
    public class DirectoryProcessor
    {
        private const string _snippetPrefix = "Snippet:";
        private readonly string _directory;
        private readonly Lazy<List<Snippet>> _snippets;
        private static readonly Regex _markdownOnlyRegex = new Regex(
            @"(?<indent>\s*)//@@\s*(?<line>.*)",
            RegexOptions.Compiled | RegexOptions.Singleline);
        private const string _codeOnlyPattern = "/*@@*/";
        private static readonly Regex _regionRegex = new Regex(
            @"^(?<indent>\s*)(#region|#endregion)\s*(?<line>.*)",
            RegexOptions.Compiled | RegexOptions.Singleline);

        private UTF8Encoding _utf8EncodingWithoutBOM;

        public DirectoryProcessor(string directory)
        {
            _directory = directory;
            _snippets = new Lazy<List<Snippet>>(DiscoverSnippets);
        }

        public void Process()
        {

            List<string> files = new List<string>();
            files.AddRange(Directory.EnumerateFiles(_directory, "*.md", SearchOption.AllDirectories));
            files.AddRange(Directory.EnumerateFiles(_directory, "*.cs", SearchOption.AllDirectories));

            foreach (var file in files)
            {
                string SnippetProvider(string s)
                {
                    var selectedSnippets = _snippets.Value.Where(snip => snip.Name == s).ToArray();
                    if (selectedSnippets.Length > 1)
                    {
                        throw new InvalidOperationException($"Multiple snippets with the name '{s}' defined '{_directory}'");
                    }

                    if (selectedSnippets.Length == 0)
                    {
                        throw new InvalidOperationException($"Snippet '{s}' not found in directory '{_directory}'");
                    }

                    var selectedSnippet = selectedSnippets.Single();
                    Console.WriteLine($"Replaced {selectedSnippet.Name} in {file}");
                    return FormatSnippet(selectedSnippet.Text);
                }

                var originalText = File.ReadAllText(file);

                string text;
                switch (Path.GetExtension(file))
                {
                    case ".md":
                        text = MarkdownProcessor.Process(originalText, SnippetProvider);
                        break;
                    case ".cs":
                        text = CSharpProcessor.Process(originalText, SnippetProvider);
                        break;
                    default:
                        throw new NotSupportedException(file);
                }

                if (text != originalText)
                {
                    _utf8EncodingWithoutBOM = new UTF8Encoding(false);
                    File.WriteAllText(file, text, _utf8EncodingWithoutBOM);
                }
            }
        }

        private List<Snippet> DiscoverSnippets()
        {
            var snippets = GetSnippetsInDirectory(_directory);
            Console.WriteLine($"Discovered snippets:");

            foreach (var snippet in snippets)
            {
                Console.WriteLine($" {snippet.Name} in {snippet.FilePath}");
            }

            return snippets;
        }

        private string FormatSnippet(SourceText text)
        {
            int minIndent = int.MaxValue;
            int firstLine = 0;
            var lines = text.Lines.Select(l => l.ToString()).ToArray();

            int lastLine = lines.Length - 1;

            while (firstLine < lines.Length && string.IsNullOrWhiteSpace(lines[firstLine]))
            {
                firstLine++;
            }

            while (lastLine > 0 && string.IsNullOrWhiteSpace(lines[lastLine]))
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
            for (var index = firstLine; index <= lastLine; index++)
            {
                var line = lines[index];
                line = string.IsNullOrWhiteSpace(line) ? string.Empty : line.Substring(minIndent);
                line = RemoveMarkdownOnlyPrefix(line);
                if (!IsCodeOnlyLine(line) && !IsRegionLine(line))
                {
                    stringBuilder.AppendLine(line);
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// There are occasions where we might want some explanatory code only
        /// appearing in the markdown document.  Comments like
        ///
        ///     //@@ bool onlyInMarkDown = true;
        ///
        /// will have the "//@@" stripped off by this method when generating
        /// our markdown text.
        /// </summary>
        /// <param name="line">The line of text.</param>
        /// <returns>
        /// The line of text with an optional "//@@" markdown only prefix
        /// removed.
        /// </returns>
        private static string RemoveMarkdownOnlyPrefix(string line) =>
            _markdownOnlyRegex.Replace(line, match =>
            {
                var indentGroup = match.Groups["indent"];
                var lineGroup = match.Groups["line"];
                if (indentGroup.Success && lineGroup.Success)
                {
                    return indentGroup.Value + lineGroup.Value;
                }
                return line;
            });

        /// <summary>
        /// There are occasions where we might want to keep a line of code out
        /// of the snippets.  Comments like
        ///
        ///     /*@@*/ bool onlyInCode = true;
        ///
        /// will be stripped out of the markdown text.
        /// </summary>
        /// <param name="line">The line of text.</param>
        /// <returns>
        /// Whether the line should be removed.
        /// </returns>
        private static bool IsCodeOnlyLine(string line) =>
            line.IndexOf(_codeOnlyPattern) >= 0;

        /// <summary>
        /// Detects whether the line being processed is actually the region header or footer.
        /// These lines should be stripped out in order to support nested regions.
        /// </summary>
        /// <param name="line">The line of text.</param>
        /// <returns>Whether this is a region line.</returns>
        private static bool IsRegionLine(string line) =>
            _regionRegex.IsMatch(line);

        private List<Snippet> GetSnippetsInDirectory(string baseDirectory)
        {
            var list = new List<Snippet>();
            foreach (var file in Directory.GetFiles(baseDirectory, "*.cs", SearchOption.AllDirectories))
            {
                var syntaxTree = CSharpSyntaxTree.ParseText(
                    File.ReadAllText(file),
                    new CSharpParseOptions(LanguageVersion.Preview),
                    path: file);
                list.AddRange(GetAllSnippets(syntaxTree));
            }

            return list;
        }

        private Snippet[] GetAllSnippets(SyntaxTree syntaxTree)
        {
            var snippets = new List<Snippet>();
            var directiveWalker = new DirectiveWalker();
            directiveWalker.Visit(syntaxTree.GetRoot());

            foreach (var region in directiveWalker.Regions)
            {
                var syntaxTrivia = region.Item1.EndOfDirectiveToken.LeadingTrivia.First(t => t.IsKind(SyntaxKind.PreprocessingMessageTrivia));
                var fromBounds = TextSpan.FromBounds(
                    region.Item1.GetLocation().SourceSpan.End,
                    region.Item2.GetLocation().SourceSpan.Start);

                var regionName = syntaxTrivia.ToString();
                if (regionName.StartsWith(_snippetPrefix))
                {
                    snippets.Add(new Snippet(syntaxTrivia.ToString(), syntaxTree.GetText().GetSubText(fromBounds), syntaxTree.FilePath));
                }
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