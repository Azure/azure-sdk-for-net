// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class QuestionAnsweringProjectTests
    {
        [Test]
        public void QueryKnowledgeBaseOptionsProjectNameNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new QuestionAnsweringProject(null, null));
            Assert.That(ex.ParamName, Is.EqualTo("projectName"));
        }

        [Test]
        public void QueryKnowledgeBaseOptionsDeploymentNameNull()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new QuestionAnsweringProject("projectName", null));
            Assert.That(ex.ParamName, Is.EqualTo("deploymentName"));
        }
    }
}
