// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class QueryKnowledgeBaseOptionsTests
    {
        [Test]
        public void QueryKnowledgeBaseOptionsProjectNameNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new QueryKnowledgeBaseOptions(null, null, null));
            Assert.AreEqual("projectName", ex.ParamName);
        }

        [Test]
        public void QueryKnowledgeBaseOptionsDeploymentNameNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new QueryKnowledgeBaseOptions("projectName", null, null));
            Assert.AreEqual("deploymentName", ex.ParamName);
        }

        [Test]
        public void QueryKnowledgeBaseOptionsQuestionNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new QueryKnowledgeBaseOptions("projectName", "deploymentName", null));
            Assert.AreEqual("question", ex.ParamName);
        }
    }
}
