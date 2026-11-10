// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Authoring.Tests
{
    [TestFixture]
    public class QnaRecordCompatibilityTests
    {
        [Test]
        public void ConstructorInitializesId()
        {
            var record = new QnaRecord(42);

            Assert.That(record.Id, Is.EqualTo(42));
        }
    }
}
