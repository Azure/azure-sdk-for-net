// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.TestHelpers.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests;

public class ClientResultTests
{
    #region ClientResult

    #endregion

    #region OptionalClientResult<T>
    [Test]
    public void CanCreateOptionalResultFromBool()
    {
        // This tests simulates creation of the result returned from a HEAD request.

        PipelineResponse response = new MockPipelineResponse(200);
        OptionalClientResult<bool> result = ClientResult.FromOptionalValue(true, response);

        Assert.IsTrue(result.Value);
        Assert.IsTrue(result.HasValue);
        Assert.AreEqual(response.Status, result.GetRawResponse().Status);

        response = new MockPipelineResponse(400);
        result = ClientResult.FromOptionalValue(false, response);

        Assert.IsFalse(result.Value);
        Assert.IsTrue(result.HasValue);
        Assert.AreEqual(response.Status, result.GetRawResponse().Status);
    }

    [Test]
    public void CanCreateDerivedOptionalResult()
    {
        // This tests simulates creation of the result returned from a HEAD request.

        PipelineResponse response = new MockPipelineResponse(500);
        OptionalClientResult<bool> result = new MockErrorResult<bool>(response, new ClientRequestException(response));

        Assert.Throws<ClientRequestException>(() => { bool b = result.Value; });
        Assert.IsFalse(result.HasValue);
        Assert.AreEqual(response.Status, result.GetRawResponse().Status);
    }
    #endregion

    #region ClientResult<T>

    #endregion

    #region Helpers
    private class MockErrorResult<T> : OptionalClientResult<T>
    {
        private readonly ClientRequestException _exception;

        public MockErrorResult(PipelineResponse response, ClientRequestException exception)
            : base(default, response)
        {
            _exception = exception;
        }

        public override T? Value { get => throw _exception; }

        public override bool HasValue => false;
    }
    #endregion
}
