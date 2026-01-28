// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Options;

public class PipelineMessageClassifierTests
{
    [Theory]
    [TestCase(500)]
    [TestCase(429)]
    [TestCase(408)]
    [TestCase(502)]
    [TestCase(503)]
    [TestCase(504)]
    public void RetriesStatusCodes(int code)
    {
        PipelineMessageClassifier classifier = PipelineMessageClassifier.Default;
        MockPipelineMessage message = new MockPipelineMessage();
        message.SetResponse(new MockPipelineResponse(code));

        Assert.That(classifier.TryClassify(message, exception: default, out bool isRetriable), Is.True);
        Assert.That(isRetriable, Is.True);
    }

    [Test]
    public void RetriesClientResultExceptionsWithoutCode()
    {
        PipelineMessageClassifier classifier = PipelineMessageClassifier.Default;
        MockPipelineMessage message = new MockPipelineMessage();
        message.SetResponse(new MockPipelineResponse(0));

        ClientResultException exception = new(message.Response!);
        Assert.That(classifier.TryClassify(message, exception, out bool isRetriable), Is.True);
        Assert.That(isRetriable, Is.True);
    }

    [Test]
    public void DoesntRetryClientResultExceptionsWithStatusCode()
    {
        PipelineMessageClassifier classifier = PipelineMessageClassifier.Default;
        MockPipelineMessage message = new MockPipelineMessage();
        message.SetResponse(new MockPipelineResponse(500));

        ClientResultException exception = new(message.Response!);
        Assert.That(classifier.TryClassify(message, exception, out bool isRetriable), Is.True);
        Assert.That(isRetriable, Is.False);
    }

    [Test]
    public void RetriesNonUserOperationCancelledExceptions()
    {
        PipelineMessageClassifier classifier = PipelineMessageClassifier.Default;
        MockPipelineMessage message = new MockPipelineMessage();

        Assert.That(classifier.TryClassify(message, exception: new OperationCanceledException(), out bool isRetriable), Is.True);
        Assert.That(isRetriable, Is.True);
    }

    [Test]
    [TestCase(100, false)]
    [TestCase(200, false)]
    [TestCase(201, false)]
    [TestCase(202, false)]
    [TestCase(204, false)]
    [TestCase(300, false)]
    [TestCase(304, false)]
    [TestCase(400, true)]
    [TestCase(404, true)]
    [TestCase(412, true)]
    [TestCase(429, true)]
    [TestCase(500, true)]
    [TestCase(502, true)]
    [TestCase(503, true)]
    [TestCase(504, true)]
    public void DefaultClassifierClassifiesError(int code, bool isError)
    {
        PipelineMessageClassifier classifier = PipelineMessageClassifier.Default;
        MockPipelineMessage message = new MockPipelineMessage();
        message.SetResponse(new MockPipelineResponse(code));

        Assert.That(classifier.TryClassify(message, out bool responseIsError), Is.True);
        Assert.That(responseIsError, Is.EqualTo(isError));
    }

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
                    Assert.That(isNonError, Is.True);
                }
                else
                {
                    Assert.That(isNonError, Is.False);
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

        Assert.That(classifier.TryClassify(message, out bool error), Is.True);
        Assert.That(error, Is.EqualTo(isError));
    }

    [Test]
    public void CanComposeErrorClassifiers()
    {
        var last = PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 201, 204 });

        ChainingClassifier classifier = new ChainingClassifier(last);
        classifier.AddClassifier(new ErrorStatusCodeClassifier(403, isError: false));
        classifier.AddClassifier(new ErrorStatusCodeClassifier(404, isError: false));
        classifier.AddClassifier(new ErrorStatusCodeClassifier(201, isError: true));

        MockPipelineMessage message = new();

        message.SetResponse(new MockPipelineResponse(200));
        Assert.That(classifier.TryClassify(message, out bool isError), Is.True);
        Assert.That(isError, Is.False);

        message.SetResponse(new MockPipelineResponse(201));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(isError, Is.True);

        message.SetResponse(new MockPipelineResponse(204));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(isError, Is.False);

        message.SetResponse(new MockPipelineResponse(304));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(isError, Is.True);

        message.SetResponse(new MockPipelineResponse(403));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(isError, Is.False);

        message.SetResponse(new MockPipelineResponse(404));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(isError, Is.False);

        message.SetResponse(new MockPipelineResponse(500));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(isError, Is.True);
    }

    [Test]
    public void CanComposeRetryClassifiers()
    {
        var last = PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 201, 204 });

        ChainingClassifier classifier = new ChainingClassifier(last);
        classifier.AddClassifier(new RetriableStatusCodeClassifier(403, isRetriable: false));
        classifier.AddClassifier(new RetriableStatusCodeClassifier(404, isRetriable: false));
        classifier.AddClassifier(new RetriableStatusCodeClassifier(201, isRetriable: true));

        MockPipelineMessage message = new();

        message.SetResponse(new MockPipelineResponse(200));
        Assert.That(classifier.TryClassify(message, exception: default, out bool isRetriable), Is.True);
        Assert.That(isRetriable, Is.False);

        message.SetResponse(new MockPipelineResponse(201));
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isRetriable, Is.True);

        message.SetResponse(new MockPipelineResponse(204));
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isRetriable, Is.False);

        message.SetResponse(new MockPipelineResponse(304));
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isRetriable, Is.False);

        message.SetResponse(new MockPipelineResponse(403));
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isRetriable, Is.False);

        message.SetResponse(new MockPipelineResponse(404));
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isRetriable, Is.False);

        message.SetResponse(new MockPipelineResponse(500));
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isRetriable, Is.True);
    }

    [Test]
    public void CanComposeErrorAndRetryClassifiers()
    {
        var last = PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 201, 204 });

        ChainingClassifier classifier = new ChainingClassifier(last);
        classifier.AddClassifier(new RetriableStatusCodeClassifier(429, isRetriable: false));
        classifier.AddClassifier(new ErrorStatusCodeClassifier(404, isError: false));
        classifier.AddClassifier(new ErrorStatusCodeClassifier(201, isError: true));

        MockPipelineMessage message = new();

        message.SetResponse(new MockPipelineResponse(200));
        Assert.That(classifier.TryClassify(message, out bool isError), Is.True);
        Assert.That(classifier.TryClassify(message, exception: default, out bool isRetriable), Is.True);
        Assert.That(isError, Is.False);
        Assert.That(isRetriable, Is.False);

        message.SetResponse(new MockPipelineResponse(201));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isError, Is.True);
        Assert.That(isRetriable, Is.False);

        message.SetResponse(new MockPipelineResponse(204));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isError, Is.False);
        Assert.That(isRetriable, Is.False);

        message.SetResponse(new MockPipelineResponse(304));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isError, Is.True);
        Assert.That(isRetriable, Is.False);

        message.SetResponse(new MockPipelineResponse(404));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isError, Is.False);
        Assert.That(isRetriable, Is.False);

        message.SetResponse(new MockPipelineResponse(429));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isError, Is.True);
        Assert.That(isRetriable, Is.False);

        message.SetResponse(new MockPipelineResponse(500));
        Assert.That(classifier.TryClassify(message, out isError), Is.True);
        Assert.That(classifier.TryClassify(message, exception: default, out isRetriable), Is.True);
        Assert.That(isError, Is.True);
        Assert.That(isRetriable, Is.True);
    }

    #region Helpers

    internal class ErrorStatusCodeClassifier : PipelineMessageClassifier
    {
        private readonly (int, bool) _code;

        public ErrorStatusCodeClassifier(int code, bool isError)
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

        public override bool TryClassify(PipelineMessage message, Exception? exception, out bool isRetriable)
        {
            isRetriable = false;
            return false;
        }
    }

    internal class RetriableStatusCodeClassifier : PipelineMessageClassifier
    {
        private readonly (int, bool) _code;

        public RetriableStatusCodeClassifier(int code, bool isRetriable)
        {
            _code = (code, isRetriable);
        }

        public override bool TryClassify(PipelineMessage message, out bool isError)
        {
            isError = false;
            return false;
        }

        public override bool TryClassify(PipelineMessage message, Exception? exception, out bool isRetriable)
        {
            if (message.Response!.Status == _code.Item1)
            {
                isRetriable = _code.Item2;
                return true;
            }

            isRetriable = false;
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

        public override bool TryClassify(PipelineMessage message, Exception? exception, out bool isRetriable)
        {
            foreach (var classifier in _classifiers)
            {
                if (classifier.TryClassify(message, exception, out isRetriable))
                {
                    return true;
                }
            }

            if (!_endOfChain.TryClassify(message, exception, out isRetriable))
            {
                bool classified = Default.TryClassify(message, exception, out isRetriable);
                Debug.Assert(classified);
            }

            return true;
        }
    }

    #endregion
}
