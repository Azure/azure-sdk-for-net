// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

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

                classifier.TryClassify(message, out bool isError);
                bool isNonError = !isError;

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

        Assert.IsTrue(classifier.TryClassify(message, out bool error));
        Assert.AreEqual(isError, error);
    }

    [Test]
    public void CanComposeErrorClassifiers()
    {
        var last = PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 201, 204 });

        ChainingClassifier classifier = new ChainingClassifier(last);
        classifier.AddClassifier(new SingleStatusCodeClassifier(403, isError: false));
        classifier.AddClassifier(new SingleStatusCodeClassifier(404, isError: false));
        classifier.AddClassifier(new SingleStatusCodeClassifier(201, isError: true));

        MockPipelineMessage message = new();

        message.SetResponse(new MockPipelineResponse(200));
        Assert.IsTrue(classifier.TryClassify(message, out bool isError));
        Assert.IsFalse(isError);

        message.SetResponse(new MockPipelineResponse(201));
        Assert.IsTrue(classifier.TryClassify(message, out isError));
        Assert.IsTrue(isError);

        message.SetResponse(new MockPipelineResponse(204));
        Assert.IsTrue(classifier.TryClassify(message, out isError));
        Assert.IsFalse(isError);

        message.SetResponse(new MockPipelineResponse(304));
        Assert.IsTrue(classifier.TryClassify(message, out isError));
        Assert.IsTrue(isError);

        message.SetResponse(new MockPipelineResponse(403));
        Assert.IsTrue(classifier.TryClassify(message, out isError));
        Assert.IsFalse(isError);

        message.SetResponse(new MockPipelineResponse(404));
        Assert.IsTrue(classifier.TryClassify(message, out isError));
        Assert.IsFalse(isError);

        message.SetResponse(new MockPipelineResponse(500));
        Assert.IsTrue(classifier.TryClassify(message, out isError));
        Assert.IsFalse(isError);
    }

    #region Helpers

    internal class SingleStatusCodeClassifier : PipelineMessageClassifier
    {
        private readonly (int, bool) _code;

        public SingleStatusCodeClassifier(int code, bool isError)
        {
            _code = (code, isError);
        }

        public override bool TryClassify(PipelineMessage message, out bool isError)
        {
            if (message.Response!.Status == _code.Item1)
            {
                isError = _code.Item2;
                return true;
            }

            isError = false;
            return false;
        }
    }

    internal class ChainingClassifier : PipelineMessageClassifier
    {
        private readonly List<PipelineMessageClassifier> _classifiers;
        private readonly PipelineMessageClassifier _endOfChain;

        public ChainingClassifier(PipelineMessageClassifier endOfChain)
        {
            _classifiers = new();
            _endOfChain = endOfChain;
        }

        public void AddClassifier(PipelineMessageClassifier classifier)
        {
            _classifiers.Add(classifier);
        }

        public override bool TryClassify(PipelineMessage message, out bool isError)
        {
            foreach (var classifier in _classifiers)
            {
                if (classifier.TryClassify(message, out isError))
                {
                    return true;
                }
            }

            return _endOfChain.TryClassify(message, out isError);
        }
    }

    #endregion
}
