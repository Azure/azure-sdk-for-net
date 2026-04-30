// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Azure.EventGrid.Messaging.SourceGeneration
{
    /// <summary>
    /// This class generates the SystemEventNames constant values as well as the SystemEventExtensions which contains a mapping
    /// from constant values to deserialization method for each system event.
    /// </summary>
    [Generator]
    internal class EventGridSourceGenerator : IIncrementalGenerator
    {
        private const string Indent = "    ";

        // the event name is either 3 or 4 parts, e.g. Microsoft.AppConfiguration.KeyValueDeleted or Microsoft.ResourceNotifications.HealthResources.AvailabilityStatusChanged
        private static readonly Regex EventTypeRegex = new("[a-zA-Z]+\\.[a-zA-Z]+\\.[a-zA-Z]+(\\.[a-zA-Z]+)?", RegexOptions.Compiled);

        private static ReadOnlySpan<char> SummaryStartTag => "<summary>".AsSpan();
        private static ReadOnlySpan<char> SummaryEndTag => "</summary>".AsSpan();

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Get all class declarations that end with "EventData"
            var classDeclarations = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: static (s, _) => s is ClassDeclarationSyntax cds && cds.Identifier.Text.EndsWith("EventData"),
                    transform: static (ctx, cancellationToken) =>
                    {
                        var semanticModel = ctx.SemanticModel;
                        var classDeclaration = (ClassDeclarationSyntax)ctx.Node;

                        var declaredSymbol = semanticModel.GetDeclaredSymbol(classDeclaration, cancellationToken);

                        return declaredSymbol?.ContainingNamespace is { Name: "SystemEvents" } ? classDeclaration : null;
                    })
                .Where(static cls => cls != null);

            var compilationAndClasses = context.CompilationProvider.Combine(classDeclarations.Collect());

            // Generate the source
            context.RegisterSourceOutput(compilationAndClasses,
                static (SourceProductionContext sourceProductionContext, (Compilation Compilation, ImmutableArray<ClassDeclarationSyntax> ClassDeclarations) input) =>
                {
                    Execute(sourceProductionContext, input.Compilation, input.ClassDeclarations);
                });
        }

        private static void Execute(SourceProductionContext context, Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes)
        {
            if (classes.IsDefaultOrEmpty)
            {
                return;
            }

            var systemEventNodes = GetSystemEventNodes(compilation, classes);
            if (systemEventNodes.Count <= 0)
            {
                return;
            }

            context.AddSource("SystemEventNames.cs", SourceText.From(ConstructSystemEventNames(systemEventNodes), Encoding.UTF8));
            context.AddSource("SystemEventExtensions.cs", SourceText.From(ConstructSystemEventExtensions(systemEventNodes), Encoding.UTF8));
        }

        private static List<SystemEventNode> GetSystemEventNodes(Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes)
        {
            var systemEventNodes = new List<SystemEventNode>();
            var eventTypeSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var classDeclaration in classes)
            {
                var semanticModel = compilation.GetSemanticModel(classDeclaration.SyntaxTree);
                if (semanticModel.GetDeclaredSymbol(classDeclaration) is not INamedTypeSymbol classSymbol)
                {
                    continue;
                }

                var documentationCommentXml = classSymbol.GetDocumentationCommentXml();
                if (string.IsNullOrEmpty(documentationCommentXml))
                {
                    continue;
                }

                // Extract event type from documentation comments
                string eventType = ExtractEventTypeFromDocumentation(documentationCommentXml);
                if (string.IsNullOrEmpty(eventType))
                {
                    // Skip if no event type is found (likely a base type)
                    continue;
                }

                if (!eventTypeSet.Add(eventType))
                {
                    continue;
                }

                // Find the deserialize method
                var deserializeMethod = classSymbol.GetMembers()
                    .OfType<IMethodSymbol>()
                    .FirstOrDefault(m => m.Name.StartsWith("Deserialize", StringComparison.Ordinal))?.Name;

                if (deserializeMethod == null)
                {
                    // Skip if no deserialize method is found
                    continue;
                }

                // Create a SystemEventNode for this event
                systemEventNodes.Add(new SystemEventNode(eventName: classSymbol.Name, eventType: $@"""{eventType}""", deserializeMethod: deserializeMethod));
            }

            return systemEventNodes;
        }

        private static string ExtractEventTypeFromDocumentation(string documentationCommentXml)
        {
            if (string.IsNullOrEmpty(documentationCommentXml))
            {
                return null;
            }

            ReadOnlySpan<char> docSpan = documentationCommentXml.AsSpan();

            int summaryStartIndex = docSpan.IndexOf(SummaryStartTag);
            if (summaryStartIndex < 0)
            {
                return null;
            }

            summaryStartIndex += SummaryStartTag.Length;

            int summaryEndIndex = docSpan.Slice(summaryStartIndex).IndexOf(SummaryEndTag);
            if (summaryEndIndex < 0)
            {
                return null;
            }

            var summaryContent = docSpan.Slice(summaryStartIndex, summaryEndIndex);

            var match = EventTypeRegex.Match(summaryContent.ToString());
            return match.Success ? match.Value : null;
        }

        private static string ConstructSystemEventNames(List<SystemEventNode> systemEvents)
        {
            var sourceBuilder = new StringBuilder(
$@"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

using Azure.Messaging.EventGrid.SystemEvents;

namespace Azure.Messaging.EventGrid
{{
    /// <summary>
    ///  Represents the names of the various event types for the system events published to
    ///  Azure Event Grid.
    /// </summary>
    public static class SystemEventNames
    {{
");
            for (int i = 0; i < systemEvents.Count; i++)
            {
                if (i > 0)
                {
                    sourceBuilder.AppendLine();
                }
                SystemEventNode sysEvent = systemEvents[i];

                // Add the ref docs for each constant
                sourceBuilder.AppendIndentedLine(2, "/// <summary>");
                sourceBuilder.AppendIndentedLine(2,
                    "/// The value of the Event Type stored in <see cref=\"CloudEvent.Type\"/> ");

                sourceBuilder.AppendIndentedLine(2, $"/// for the <see cref=\"{sysEvent.EventName}\"/> system event.");
                sourceBuilder.AppendIndentedLine(2, "/// </summary>");

                // Add the constant
                sourceBuilder.AppendIndentedLine(2, $"public const string {sysEvent.EventConstantName} = {sysEvent.EventType};");
            }

            sourceBuilder.AppendIndentedLine(1, @"}
}");
            return sourceBuilder.ToString();
        }

        private static string ConstructSystemEventExtensions(List<SystemEventNode> systemEvents)
        {
            var sourceBuilder = new StringBuilder(
                $@"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Messaging.EventGrid.SystemEvents;
using System.ClientModel.Primitives;

namespace Azure.Messaging.EventGrid
{{
    internal class SystemEventExtensions
    {{
        public static object AsSystemEventData(string eventType, JsonElement data)
        {{
            var eventTypeSpan = eventType.AsSpan();
");
            foreach (SystemEventNode sysEvent in systemEvents)
            {
                // Add each an entry for each system event to the dictionary containing a mapping from constant name to deserialization method.
                sourceBuilder.AppendIndentedLine(3,
                    $"if (eventTypeSpan.Equals(SystemEventNames.{sysEvent.EventConstantName}.AsSpan(), StringComparison.OrdinalIgnoreCase))");
                sourceBuilder.AppendIndentedLine(4,
                    $"return {sysEvent.EventName}.{sysEvent.DeserializeMethod}(data, ModelSerializationExtensions.WireOptions);");
            }
            sourceBuilder.AppendIndentedLine(3, "return null;");
            sourceBuilder.AppendIndentedLine(2, "}");
            sourceBuilder.AppendIndentedLine(1, "}");
            sourceBuilder.AppendLine("}");

            return sourceBuilder.ToString();
        }
    }
}
