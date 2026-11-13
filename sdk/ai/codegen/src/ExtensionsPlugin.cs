// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Extensions.Plugin.Visitors;
using Microsoft.TypeSpec.Generator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Text;

namespace Extensions.Plugin
{
    /// <summary>
    /// ExtensionsPlugin is a generator plugin that applies visitors to mutate the generated
    /// Azure.AI.Projects, Azure.AI.Extensions.OpenAI and Azure.AI.Projects.Agents libraries,
    /// analogous to the OpenAI library's codegen plugin.
    /// </summary>
    internal sealed class ExtensionsPlugin : GeneratorPlugin
    {
        /// <inheritdoc />
        public override void Apply(CodeModelGenerator generator)
        {
            generator.AddVisitor(new SerializationOverrideVisitor());
            // ExperimentalAttributeVisitor runs first so our intentional AAIP001 marking (driven by the
            // typespec x-ms-foundry-meta CSV tables) wins for any declaration that is experimental both because
            // we intend it to be and because it exposes OpenAI-experimental surface. OpenAIExperimentalVisitor
            // then marks the remaining OpenAI-dependency surface with AAIP002. Both skip already-attributed
            // declarations, and because C# suppresses experimental references inside any [Experimental] scope
            // regardless of id, neither ordering requires an assembly-wide NoWarn.
            generator.AddVisitor(new ExperimentalAttributeVisitor());
            generator.AddVisitor(new OpenAIExperimentalVisitor());
            MakeResponseItemDynamic(generator);
        }

        /// <summary>
        /// Make models to use JsonPatch.
        /// </summary>
        private static void MakeResponseItemDynamic(CodeModelGenerator generator)
        {
            // This code ia a fix needed to make models dynamic, i.e. to use JsonPatch instead
            // of additionalBinaryData.
            // This must be handled in the typespec by using @@dynamicModel decorator around the
            // appropriate classes, however, it is not yet supported.
            // This method should be removed, when the issue
            // https://github.com/Azure/typespec-azure/issues/5852 will be resolved and the PR
            // https://github.com/Azure/azure-rest-api-specs/pull/47632 will be merged.
            HashSet<string> dynamicModel = [
                "A2AToolCall",
                "A2AToolCallOutput",
                "StructuredOutputsOutputItem",
                "BingGroundingToolCall",
                "BingGroundingToolCallOutput",
                "WorkflowActionOutputItem",
                "AzureAISearchToolCall",
                "AzureAISearchToolCallOutput",
                "AzureFunctionToolCall",
                "AzureFunctionToolCallOutput",
                "BingCustomSearchToolCall",
                "BingCustomSearchToolCallOutput",
                "BrowserAutomationToolCall",
                "BrowserAutomationToolCallOutput",
                "FabricDataAgentToolCall",
                "FabricDataAgentToolCallOutput",
                "MemoryCommandToolCall",
                "MemoryCommandToolCallOutput",
                "MemorySearchToolCall",
                "OAuthConsentRequestResponseItem",
                "OpenApiToolCall",
                "OpenApiToolCallOutput",
                "SharePointGroundingToolCall",
                "SharePointGroundingToolCallOutput",
            ];
            foreach (var model in generator.InputLibrary.InputNamespace.Models)
            {
                if (dynamicModel.Contains(model.Name))
                {
                    model.Update(isDynamicModel: true);
                    dynamicModel.Remove(model.Name);
                }
            }
        }
    }
}
