using System.Collections.Generic;
using System.Reflection;
using Extensions.Plugin.Visitors;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

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

        [TestCase("VoiceAgentLiveDefinition", "SubProtocol", true)]
        [TestCase("VoiceAgentDefinition", "SubProtocol", false)]
        [TestCase("VoiceAgentLiveDefinition", "ModelType", false)]
        public void OnlyLiveSubProtocolInitializerUsesTheEnumMember(string modelName, string propertyName, bool usesEnum)
        {
            AutoPropertyBody body = new(false) { InitializationExpression = Literal("live") };
            PropertyProvider property = new(
                $"The protocol.", MethodSignatureModifiers.Public, typeof(TestSubProtocol),
                propertyName, body, new TestTypeProvider(modelName));

            new TestVisitor().ConfigureProperty(property);

            Assert.That(((AutoPropertyBody)property.Body).InitializationExpression!.ToDisplayString(),
                usesEnum ? Does.EndWith(".Live") : Is.EqualTo("\"live\""));
        }

        private enum TestSubProtocol
        {
            Realtime,
            Live
        }

        private class TestTypeProvider : TypeProvider
        {
            private readonly string _name;

            public TestTypeProvider(string name)
            {
                _name = name;
                typeof(TypeProvider).GetField("_customCodeView", BindingFlags.NonPublic | BindingFlags.Instance)!
                    .SetValue(this, new Lazy<TypeProvider?>(() => null));
            }

            protected override string BuildNamespace() => "Azure.AI.Projects.Agents";
            protected override string BuildRelativeFilePath() => $"{Name}.cs";
            protected override string BuildName() => _name;
        }

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
            public PropertyProvider ConfigureProperty(PropertyProvider property) => PreVisitProperty(null!, property);
        }
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
