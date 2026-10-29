// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests;

public class LiveExperimentalDependencyTests
{
    [TestCase(typeof(QuestionParam))]
    [TestCase(typeof(QuestionParamPredicate))]
    [TestCase(typeof(QuestionParamChoice))]
    [TestCase(typeof(QuestionParamScore))]
    [TestCase(typeof(ChoiceOptionParam))]
    [TestCase(typeof(ScoreLevelParam))]
    [TestCase(typeof(DecisionResult))]
    [TestCase(typeof(AnswerResource))]
    [TestCase(typeof(AnswerResourcePredicate))]
    [TestCase(typeof(AnswerResourceChoice))]
    [TestCase(typeof(AnswerResourceScore))]
    [TestCase(typeof(AnswerResourceRefusal))]
    [TestCase(typeof(ChoiceProbabilityResource))]
    [TestCase(typeof(ScoreProbabilityResource))]
    [TestCase(typeof(ResponseUsageResource))]
    [TestCase(typeof(InputTokensDetailsResource))]
    [TestCase(typeof(OutputTokensDetailsResource))]
    public void DecisionDependenciesAndTheirFactoriesAreExperimental(Type modelType)
    {
        MethodInfo[] factories = FactoryMethodsFor(modelType);

        Assert.Multiple(() =>
        {
            Assert.That(modelType.IsPublic, Is.True, "Preview gating must not hide a public model.");
            Assert.That(ExperimentalDiagnosticIds(modelType), Is.EqualTo(new[] { "AAIP001" }));
            Assert.That(factories, Is.Not.Empty, $"{modelType.Name} must retain a public model factory.");
            foreach (MethodInfo factory in factories)
            {
                Assert.That(ExperimentalDiagnosticIds(factory), Is.EqualTo(new[] { "AAIP001" }), factory.Name);
            }
        });
    }

    [TestCase(typeof(ProjectsAgentDefinition))]
    [TestCase(typeof(DeclarativeAgentDefinition))]
    [TestCase(typeof(ProjectsAgentRecord))]
    [TestCase(typeof(AgentReference))]
    [TestCase(typeof(ContentFilterConfiguration))]
    [TestCase(typeof(AgentAdministrationClient))]
    [TestCase(typeof(ProjectsAgentsModelFactory))]
    public void StableTypesRemainNonExperimental(Type type)
        => Assert.That(ExperimentalDiagnosticIds(type), Is.Empty);

    [TestCase(typeof(OpenAI.Responses.ResponseItem))]
    [TestCase(typeof(OpenAI.Responses.ResponseTool))]
    public void UpstreamTypesRetainTheirOwnExperimentalDiagnostic(Type type)
        => Assert.That(ExperimentalDiagnosticIds(type), Is.EqualTo(new[] { "OPENAI001" }));

    [TestCase(typeof(ProjectsAgentDefinition))]
    [TestCase(typeof(AgentReference))]
    [TestCase(typeof(ContentFilterConfiguration))]
    public void StableFactoriesRemainNonExperimental(Type modelType)
    {
        MethodInfo[] factories = FactoryMethodsFor(modelType);

        Assert.That(factories, Is.Not.Empty);
        Assert.Multiple(() =>
        {
            foreach (MethodInfo factory in factories)
            {
                Assert.That(ExperimentalDiagnosticIds(factory), Is.Empty, factory.Name);
            }
        });
    }

    private static MethodInfo[] FactoryMethodsFor(Type modelType)
        => typeof(ProjectsAgentsModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(method => method.ReturnType == modelType)
            .ToArray();

    private static string[] ExperimentalDiagnosticIds(MemberInfo member)
        => member.GetCustomAttributesData()
            .Where(attribute => attribute.AttributeType.FullName == "System.Diagnostics.CodeAnalysis.ExperimentalAttribute")
            .Select(attribute => (string)attribute.ConstructorArguments[0].Value)
            .ToArray();
}
