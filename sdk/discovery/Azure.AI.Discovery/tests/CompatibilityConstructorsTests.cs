// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    [TestFixture]
    public class CompatibilityConstructorsTests
    {
        [Test]
        public void PreviouslyRequiredModelConstructorsInitializeValues()
        {
            var knowledgeBase = new KnowledgeBase("description", "copilot instruction");
            var assignee = new TaskAssignee("assignee-id", DiscoveryActorType.Application);

            Assert.That(knowledgeBase.Description, Is.EqualTo("description"));
            Assert.That(knowledgeBase.CopilotInstruction, Is.EqualTo("copilot instruction"));
            Assert.That(assignee.Id, Is.EqualTo("assignee-id"));
            Assert.That(assignee.Type, Is.EqualTo(DiscoveryActorType.Application));
        }
    }
}
