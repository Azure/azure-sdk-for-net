// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Extensions.Plugin.Visitors;
using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;
using System.Linq;

namespace Extensions.Plugin
{
    /// <summary>
    /// ExtensionsPlugin is a generator plugin that applies visitors to mutate the generated
    /// Azure.AI.Projects, Azure.AI.Extensions.OpenAI and Azure.AI.Projects.Agents libraries,
    /// analogous to the OpenAI library's codegen plugin.
    /// </summary>
    internal sealed class ExtensionsPlugin : GeneratorPlugin
    {
        private const string VoiceAgentWebSocketOperationId = "Azure.AI.Projects.VoiceAgentWebSocket.connectVoiceAgent";

        /// <inheritdoc />
        public override void Apply(CodeModelGenerator generator)
        {
            var clients = new Queue<InputClient>(generator.InputLibrary.InputNamespace.RootClients.Concat(generator.InputLibrary.InputNamespace.Clients));
            var visitedClients = new HashSet<InputClient>();

            while (clients.TryDequeue(out InputClient client))
            {
                if (!visitedClients.Add(client))
                {
                    continue;
                }

                foreach (var method in client.Methods.Where(method => method.CrossLanguageDefinitionId == VoiceAgentWebSocketOperationId))
                {
                    method.Update(generateConvenient: false, generateProtocol: false);
                    method.Operation.Update(generateConvenienceMethod: false, generateProtocolMethod: false);
                }

                client.Update(methods: client.Methods.Where(method => method.CrossLanguageDefinitionId != VoiceAgentWebSocketOperationId));

                foreach (InputClient child in client.Children)
                {
                    clients.Enqueue(child);
                }
            }

            generator.AddVisitor(new SerializationOverrideVisitor());
            generator.AddVisitor(new ExperimentalAttributeVisitor());
            generator.AddVisitor(new OpenAIExperimentalVisitor());
        }
    }
}
