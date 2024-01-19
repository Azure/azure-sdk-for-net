// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.Options;

public class PipelineMessageClassifierTests
{
    [Test]
    public void ClassifiesSingleCodeAsNonError()
    {
        // test classifiers for each of the status codes
        for (ushort nonError = 100; nonError <= 599; nonError++)
        {
            PipelineMessageClassifier classifier = PipelineMessageClassifier.Create(new ushort[] { nonError });

            // test all the status codes against the classifier
            for (int code = 100; code <= 599; code++)
            {
                MockPipelineMessage message = new MockPipelineMessage();
                message.SetResponse(new MockPipelineResponse(code));

                bool isNonError = !classifier.IsErrorResponse(message);

                if (nonError == code)
                {
                    Assert.True(isNonError);
                }
                else
                {
                    Assert.False(isNonError);
                }
            }
        }
    }

    [Test]
    [TestCase(200, false)]
    [TestCase(204, true)]
    [TestCase(404, false)]
    [TestCase(500, true)]
    [TestCase(502, true)]
    public void ClassifiesMultipleCodesAsNonErrors(int code, bool isError)
    {
        PipelineMessageClassifier classifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 404 });

        MockPipelineMessage message = new MockPipelineMessage();
        message.SetResponse(new MockPipelineResponse(code));

        Assert.AreEqual(isError, classifier.IsErrorResponse(message));
    }
}
