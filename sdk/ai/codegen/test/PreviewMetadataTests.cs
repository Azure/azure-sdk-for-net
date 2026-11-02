// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Extensions.Plugin.Visitors;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;

namespace Test.Extensions.Plugin;

public class PreviewMetadataTests
{
    [TestCase("""{"required_previews":["VoiceAgents=V1Preview"]}""", true)]
    [TestCase("""{"required_previews":[]}""", false)]
    [TestCase("""{"conditional_previews":["VoiceAgents=V1Preview"]}""", false)]
    [TestCase("""{"required_previews":[],"conditional_previews":["VoiceAgents=V1Preview"]}""", false)]
    [TestCase("""{"required_previews":["VoiceAgents=V1Preview"],"conditional_previews":["Other=Preview"]}""", true)]
    [TestCase("{}", false)]
    public void OnlyRequiredPreviewMetadataMarksAnEntireType(string metadata, bool expected)
    {
        InputDecoratorInfo decorator = new("TypeSpec.OpenAPI.@extension",
            new Dictionary<string, BinaryData>
            {
                ["key"] = BinaryData.FromObjectAsJson("x-ms-foundry-meta"),
                ["value"] = BinaryData.FromString(metadata)
            });

        Assert.That(HasExperimentalDecorator([decorator]), Is.EqualTo(expected));
    }

    [Test]
    public void OtherOpenApiExtensionsDoNotMarkTypesExperimental()
    {
        InputDecoratorInfo decorator = new("TypeSpec.OpenAPI.@extension",
            new Dictionary<string, BinaryData>
            {
                ["key"] = BinaryData.FromObjectAsJson("other-extension"),
                ["value"] = BinaryData.FromString("""{"required_previews":["VoiceAgents=V1Preview"]}""")
            });

        Assert.That(HasExperimentalDecorator([decorator]), Is.False);
        Assert.That(HasExperimentalDecorator([]), Is.False);
    }

    [Test]
    public void MalformedRequiredPreviewMetadataIsNotSilentlyTreatedAsGa()
    {
        InputDecoratorInfo decorator = new("TypeSpec.OpenAPI.@extension",
            new Dictionary<string, BinaryData>
            {
                ["key"] = BinaryData.FromObjectAsJson("x-ms-foundry-meta"),
                ["value"] = BinaryData.FromString("""{"required_previews":"VoiceAgents=V1Preview"}""")
            });

        TargetInvocationException error = Assert.Throws<TargetInvocationException>(() =>
            HasExperimentalDecorator([decorator]));
        Assert.That(error.InnerException, Is.TypeOf<InvalidOperationException>());
    }

    private static bool HasExperimentalDecorator(InputDecoratorInfo[] decorators)
    {
        MethodInfo method = typeof(ExperimentalAttributeVisitor).GetMethod(
            "HasExperimentalDecorator", BindingFlags.NonPublic | BindingFlags.Static)!;
        return (bool)method.Invoke(null, [decorators])!;
    }
}
