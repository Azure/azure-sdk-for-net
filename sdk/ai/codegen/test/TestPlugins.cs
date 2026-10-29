using System.Collections.Generic;
using Extensions.Plugin.Visitors;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;

namespace Test.Extensions.Plugin;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    public class VoiceAgentLiveGenerationTests
    {
        [Test]
        public void LiveClientIsNamedBeforeProviderConstructionWithoutChangingOtherClients()
        {
            InputClient live = Client("AgentEndpointLiveConversations");
            InputClient agents = Client("AgentAdministrationClient");
            InputClient realtime = Client("AgentEndpointConversations");
            InputNamespace input = new() { RootClients = [live, agents, realtime] };

            TestVisitor.ConfigureInput(input);
            TestVisitor.ConfigureInput(input);

            Assert.Multiple(() =>
            {
                Assert.That(live.Name, Is.EqualTo("BetaVoiceAgentsLiveConversations"));
                Assert.That(agents.Name, Is.EqualTo("AgentAdministrationClient"));
                Assert.That(realtime.Name, Is.EqualTo("AgentEndpointConversations"));
                Assert.That(input.RootClients, Has.Count.EqualTo(3));
            });
        }

        [TestCase("LiveClientEvent")]
        [TestCase("LiveServerEvent")]
        public void NativeEventRootsAndTheirDescendantsAreRetained(string name)
        {
            InputModelType root = Model(name);
            InputModelType child = Model("ConcreteEvent", root);
            InputModelType grandchild = Model("RefinedEvent", child);

            Assert.Multiple(() =>
            {
                Assert.That(TestVisitor.IsEvent(root), Is.True);
                Assert.That(TestVisitor.IsEvent(child), Is.True);
                Assert.That(TestVisitor.IsEvent(grandchild), Is.True);
            });
        }

        [TestCase("RealtimeServerEvent")]
        [TestCase("LiveSessionUsage")]
        [TestCase("VoiceAgentLiveConversation")]
        [TestCase("LiveServerEventEnvelope")]
        public void UnrelatedModelsDoNotBecomeGenerationRoots(string name)
            => Assert.That(TestVisitor.IsEvent(Model(name)), Is.False);

        private static InputClient Client(string name)
        {
            InputClient client = new();
            client.Update(name: name);
            return client;
        }

        private static InputModelType Model(string name, InputModelType? parent = null)
            => new(name, "Azure.AI.Projects.Agents", name, "public", null, null, null,
                InputModelTypeUsage.Input | InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                [], parent, [], null, null, new Dictionary<string, InputModelType>(), null, false,
                new InputSerializationOptions(), false);

        private class TestVisitor : VoiceAgentLiveVisitor
        {
            public static void ConfigureInput(InputNamespace input) => Configure(input);
            public static bool IsEvent(InputModelType model) => IsNativeEvent(model);
        }
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
