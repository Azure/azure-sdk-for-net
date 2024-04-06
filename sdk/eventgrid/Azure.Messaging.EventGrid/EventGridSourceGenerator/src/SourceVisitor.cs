// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EventGridSourceGenerator
{
    internal class SourceVisitor : SymbolVisitor
    {
        public List<SystemEventNode> SystemEvents { get; } = new();

        public override void VisitNamespace(INamespaceSymbol symbol)
        {
            foreach (var childSymbol in symbol.GetMembers())
            {
                childSymbol.Accept(this);
            }
        }

        public override void VisitNamedType(INamedTypeSymbol symbol)
        {
            if (symbol.Name.EndsWith("EventData"))
            {
                string type = null;
                XmlDocument xmlDoc = new();
                xmlDoc.LoadXml(symbol.GetDocumentationCommentXml());
                var xmlNode = xmlDoc.SelectSingleNode("member/summary");
                // the event name is either 3 or 4 parts, e.g. Microsoft.AppConfiguration.KeyValueDeleted or Microsoft.ResourceNotifications.HealthResources.AvailabilityStatusChanged
                var match = Regex.Match(xmlNode.InnerText, "[a-zA-Z]+\\.[a-zA-Z]+\\.[a-zA-Z]+(\\.[a-zA-Z]+)?");
                if (!match.Success)
                {
                    // We expect some EventData to not have event types if they are base types,
                    // e.g. ContainerRegistryEventData
                    return;
                }

                type = $@"""{match.Value}""";
                SystemEvents.Add(
                    new SystemEventNode()
                    {
                        EventName = symbol.Name,
                        EventType = type,
                        DeserializeMethod = symbol.MemberNames.Single(m => m.StartsWith("Deserialize"))
                    });
            }
        }
    }
}
