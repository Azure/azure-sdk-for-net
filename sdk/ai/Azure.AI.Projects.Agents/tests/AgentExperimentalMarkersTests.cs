// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests;

public class AgentExperimentalMarkersTests
{
    [Test]
    public void GenerateAgentOverloadsAreExperimental()
    {
        MethodInfo[] methods = typeof(AgentAdministrationClient)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(method => method.Name is "GenerateAgent" or "GenerateAgentAsync")
            .ToArray();

        Assert.That(methods, Has.Length.EqualTo(6));
        foreach (MethodInfo method in methods)
        {
            Assert.That(IsExperimental(method), Is.True, $"{method} must remain experimental.");
        }
    }

    [TestCase(typeof(AgentEndpointConversations))]
    [TestCase(typeof(AgentTelephony))]
    [TestCase(typeof(AgentOptimizationCandidate))]
    [TestCase(typeof(AgentOptimizationJob))]
    [TestCase(typeof(AgentOptimizationJobResult))]
    [TestCase(typeof(VoiceResponseBaseObject))]
    public void PreviewTypeIsExperimental(Type type)
    {
        Assert.That(IsExperimental(type), Is.True, $"{type} must remain experimental.");
    }

    [TestCase(typeof(AgentOptimizationJobCandidates))]
    [TestCase(typeof(BrowserAutomationToolboxTool))]
    [TestCase(typeof(CallableToolAllowedCaller))]
    [TestCase(typeof(CodeInterpreterToolboxTool))]
    [TestCase(typeof(ContainerSkill))]
    [TestCase(typeof(MCPToolboxTool))]
    [TestCase(typeof(ShellToolboxTool))]
    [TestCase(typeof(ToolboxShellContainerAutoEnvironment))]
    [TestCase(typeof(WebSearchToolboxTool))]
    public void UnrelatedTypeIsNotExperimental(Type type)
    {
        Assert.That(IsExperimental(type), Is.False, $"{type} must not acquire an experimental marker.");
    }

    private static bool IsExperimental(MemberInfo member) =>
        member.GetCustomAttributes(inherit: false)
            .Any(attribute => attribute.GetType().FullName == "System.Diagnostics.CodeAnalysis.ExperimentalAttribute");
}
