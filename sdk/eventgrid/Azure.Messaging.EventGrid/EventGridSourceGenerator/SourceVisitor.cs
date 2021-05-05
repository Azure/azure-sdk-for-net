// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EventGridSourceGenerator
{
    internal class SourceVisitor : CSharpSyntaxWalker
    {
        private Dictionary<string, SystemEventNode> _systemEvents;
        private List<SystemEventNode> _systemEventList;
        
        public List<SystemEventNode> SystemEvents
        {
            get
            {
                _systemEventList ??= _systemEvents.Values.Where(e => !string.IsNullOrEmpty(e.EventType)).ToList();
                return _systemEventList;
            }
        }

        public SourceVisitor()
        {
            _systemEvents = new();
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            if (node.Identifier.ValueText.EndsWith("EventData"))
            {
                string name = node.Identifier.ValueText;
                string type = null;
                string deserializationMethod = null;
                var trivias = node.GetLeadingTrivia();
                foreach (var trivia in trivias)
                {
                    if (trivia.Kind() == SyntaxKind.SingleLineDocumentationCommentTrivia)
                    {
                        var doc = trivia.GetStructure();
                        var match = Regex.Match(doc.ToFullString(), "[a-zA-Z]+\\.[a-zA-Z]+\\.[a-zA-Z]+");
                        // We expect some EventData to not have event types if they are base types,
                        // e.g. ContainerRegistryEventData
                        if (match.Success)
                        {
                            type = $@"""{match.Value}"";";
                        }
                        break;
                    }
                }
                var methods = node.DescendantNodes().OfType<MethodDeclarationSyntax>();
                deserializationMethod = methods.Where(m => m.Identifier.ValueText.StartsWith("Deserialize"))
                    .FirstOrDefault()?.Identifier.ValueText;

                // since each system event is defined in two separate files, we need to handle Visit being
                // called separately for each of the files.
                if (!_systemEvents.ContainsKey(node.Identifier.ValueText))
                {
                    _systemEvents.Add(node.Identifier.ValueText, new SystemEventNode());
                }
                _systemEvents[node.Identifier.ValueText].EventName ??= name;
                _systemEvents[node.Identifier.ValueText].EventType ??= type;
                _systemEvents[node.Identifier.ValueText].DeserializeMethod ??= deserializationMethod;
            }
        }

        public override void VisitCompilationUnit(CompilationUnitSyntax node)
        {
            base.VisitCompilationUnit(node);
        }
    }
}
