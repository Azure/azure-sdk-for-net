// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.Options;

public class ChainingClassifierTests
{
    [Test]
    public void ClassifiesUsingOnlyEndOfChain()
    {
        ChainingClassifier classifier = new ChainingClassifier(
            statusCodes: null,
            handlers: null,
            HelperResponseClassifier.Instance);

        MockPipelineMessage message = new();

        message.SetResponse(new MockPipelineResponse(204));
        Assert.IsFalse(classifier.IsErrorResponse(message));

        message.SetResponse(new MockPipelineResponse(304));
        Assert.IsFalse(classifier.IsErrorResponse(message));

        message.SetResponse(new MockPipelineResponse(404));
        Assert.IsTrue(classifier.IsErrorResponse(message));

        message.SetResponse(new MockPipelineResponse(500));
        Assert.IsTrue(classifier.IsErrorResponse(message));
    }

    [Test]
    public void ClassifiesUsingHandlersAndEndOfChain()
    {
        MessageClassificationHandler[] handlers = new MessageClassificationHandler[]
        {
            new HeaderClassificationHandler(204, "ErrorCode", "Error"),
            new HeaderClassificationHandler(404, "ErrorCode", "NonError"),
        };

        ChainingClassifier classifier = new ChainingClassifier(
            statusCodes: null,
            handlers: handlers,
            HelperResponseClassifier.Instance);

        MockPipelineMessage message = new();

        var response = new MockPipelineResponse(204);
        response.AddHeader("ErrorCode", "Error");
        message.Response = response;
        Assert.IsTrue(classifier.IsErrorResponse(message));

        response = new MockPipelineResponse(304);
        response.AddHeader("ErrorCode", "Error");
        message.Response = response;
        Assert.IsFalse(classifier.IsErrorResponse(message));

        response = new MockPipelineResponse(404);
        response.AddHeader("ErrorCode", "Error");
        message.Response = response;
        Assert.IsFalse(classifier.IsErrorResponse(message));

        response = new MockPipelineResponse(500);
        response.AddHeader("ErrorCode", "Error");
        message.Response = response;
        Assert.IsTrue(classifier.IsErrorResponse(message));
    }

    [Test]
    public void ClassifiesUsingStatusCodesAndEndOfChain()
    {
        (int Status, bool IsError)[] classifications = new (int Status, bool IsError)[]
        {
            (204, true),
            (404, false),
            (500, false),
        };

        ChainingClassifier classifier = new ChainingClassifier(
            statusCodes: classifications,
            handlers: null,
            HelperResponseClassifier.Instance);

        MockPipelineMessage message = new();

        message.Response = new MockPipelineResponse(204);
        Assert.IsTrue(classifier.IsErrorResponse(message));

        message.Response = new MockPipelineResponse(304);
        Assert.IsFalse(classifier.IsErrorResponse(message));

        message.Response = new MockPipelineResponse(404);
        Assert.IsFalse(classifier.IsErrorResponse(message));

        message.Response = new MockPipelineResponse(500);
        Assert.IsFalse(classifier.IsErrorResponse(message));
    }

    [Test]
    public void ClassifiesUsingAllHandlersTakePrecedenceOverStatusCodes()
    {
        (int Status, bool IsError)[] classifications = new (int Status, bool IsError)[]
        {
            (204, false),
            (500, false),
        };

        MessageClassificationHandler[] handlers = new MessageClassificationHandler[]
        {
            new HeaderClassificationHandler(204, "ErrorCode", "Error"),
            new HeaderClassificationHandler(404, "ErrorCode", "NonError"),
        };

        ChainingClassifier classifier = new ChainingClassifier(
            statusCodes: classifications,
            handlers: handlers,
            HelperResponseClassifier.Instance);

        MockPipelineMessage message = new();

        // Handler takes precedence
        var response = new MockPipelineResponse(204);
        response.AddHeader("ErrorCode", "Error");
        message.Response = response;
        Assert.IsTrue(classifier.IsErrorResponse(message));

        // End of chain is reached
        message.Response = new MockPipelineResponse(304);
        Assert.IsFalse(classifier.IsErrorResponse(message));

        // Handler takes precedence
        response = new MockPipelineResponse(404);
        response.AddHeader("ErrorCode", "Error");
        message.Response = response;
        Assert.IsFalse(classifier.IsErrorResponse(message));

        // Status code handler is reached
        message.Response = new MockPipelineResponse(500);
        Assert.IsFalse(classifier.IsErrorResponse(message));
    }

    #region Helpers
    private sealed class HelperResponseClassifier : PipelineMessageClassifier
    {
        public static PipelineMessageClassifier Instance = new HelperResponseClassifier();
        public override bool IsErrorResponse(PipelineMessage message)
        {
            message.AssertResponse();

            return message.Response!.Status switch
            {
                >= 100 and < 400 => false,
                _ => true
            };
        }
    }

    public class HeaderClassificationHandler : MessageClassificationHandler
    {
        private readonly int _statusCode;
        private readonly string _headerName;    //  e.g. "ErrorCode";
        private readonly string _headerValue;   //  e.g. "LeaseNotAquired";

        public HeaderClassificationHandler(int statusCode, string headerName, string headerValue)
        {
            _statusCode = statusCode;
            _headerName = headerName;
            _headerValue = headerValue;
        }

        public override bool TryClassify(PipelineMessage message, out bool isError)
        {
            isError = false;

            message.AssertResponse();

            if (message.Response!.Status != _statusCode)
            {
                return false;
            }

            if (message.Response.Headers.TryGetValue(_headerName, out string? value) &&
                _headerValue == value)
            {
                isError = true;
            }

            return true;
        }
    }
    #endregion
}
