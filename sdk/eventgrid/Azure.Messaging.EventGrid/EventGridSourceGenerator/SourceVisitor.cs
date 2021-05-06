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
        private readonly Dictionary<string, SystemEventNode> _systemEvents;
        private List<SystemEventNode> _systemEventList;
        
        public List<SystemEventNode> SystemEvents
        {
            get
            {
                // We expect some EventData to not have event types if they are base types,
                // e.g. ContainerRegistryEventData
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
                            type = $@"""{match.Value}""";
                        }
                        break;
                    }
                }
                var methods = node.DescendantNodes().OfType<MethodDeclarationSyntax>();
                deserializationMethod = methods
                    .FirstOrDefault(m => m.Identifier.ValueText.StartsWith("Deserialize"))?.Identifier.ValueText;

                // Since each system event is defined in two separate files, we need to handle Visit being
                // called separately for each of the files. In the first Visit call, we will populate the 
                // EventName and EventType. In the next Visit call, we will populate the DeserializeMethod.
                if (!_systemEvents.ContainsKey(node.Identifier.ValueText))
                {
                    _systemEvents.Add(node.Identifier.ValueText, new SystemEventNode());
                }
                _systemEvents[node.Identifier.ValueText].EventName ??= name;
                _systemEvents[node.Identifier.ValueText].EventType ??=
                    // temporary workaround until https://github.com/Azure/azure-rest-api-specs/pull/14261/ is merged
                    type == @"""Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListenersEvent""" ? 
                        @"""Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListener""" 
                        : type;
                _systemEvents[node.Identifier.ValueText].DeserializeMethod ??= deserializationMethod;
            }
        }

        public override void VisitCompilationUnit(CompilationUnitSyntax node)
        {
            base.VisitCompilationUnit(node);
        }
    }
}
