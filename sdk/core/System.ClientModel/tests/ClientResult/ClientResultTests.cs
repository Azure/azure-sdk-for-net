// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests;

public class ClientResultTests
{
    #region ClientResult

    [Test]
    public void CannotCreateClientResultFromNullResponse()
    {
        Assert.Throws<ArgumentNullException>(() => new MockClientResult(null!));
        Assert.Throws<ArgumentNullException>(() =>
        {
            ClientResult result = ClientResult.FromResponse(null!);
        });
    }

    [Test]
    public void GetRawResponseReturnsResponse()
    {
        PipelineResponse response = new MockPipelineResponse(200, "MockReason");
        MockClientResult mockResult = new MockClientResult(response);
        Assert.AreEqual(response, mockResult.GetRawResponse());
        Assert.AreEqual(response.Status, mockResult.GetRawResponse().Status);
        Assert.AreEqual(response.ReasonPhrase, mockResult.GetRawResponse().ReasonPhrase);

        ClientResult result = ClientResult.FromResponse(response);
        Assert.AreEqual(response, result.GetRawResponse());
        Assert.AreEqual(response.Status, result.GetRawResponse().Status);
        Assert.AreEqual(response.ReasonPhrase, result.GetRawResponse().ReasonPhrase);
    }

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
    #endregion
}
