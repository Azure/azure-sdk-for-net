// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.Results;

public class PipelineResponseTests
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
    public void CannotCreateOptionalClientResultFromNullResponse()
    {
        Assert.Throws<ArgumentNullException>(() => new MockOptionalClientResult<object>(null, null!));
        Assert.Throws<ArgumentNullException>(() =>
        {
            OptionalClientResult<object> result = ClientResult.FromOptionalValue<object>(null, null!);
        });
    }

    [Test]
    public void CanCreateOptionalClientResultFromBool()
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
    public void OptionalClientResultDerivedTypeCanShadowValue()
    {
        // This tests simulates creation of the result returned from a HEAD request.

        PipelineResponse response = new MockPipelineResponse(200);
        MockPersistableModel model = new MockPersistableModel(1, "a");
        MockOptionalClientResult<MockPersistableModel> result = new MockOptionalClientResult<MockPersistableModel>(model, response);

        Assert.AreEqual(model.IntValue, result.Value!.IntValue);
        Assert.AreEqual(model.StringValue, result.Value!.StringValue);

        model = new MockPersistableModel(2, "b");

        result.SetValue(model);

        Assert.AreEqual(model.IntValue, result.Value!.IntValue);
        Assert.AreEqual(model.StringValue, result.Value!.StringValue);
    }

    [Test]
    public void CanCreateDerivedOptionalClientResult()
    {
        // This tests simulates creation of the result returned from a HEAD request.

        PipelineResponse response = new MockPipelineResponse(500);
        OptionalClientResult<bool> result = new MockErrorResult<bool>(response, new ClientResultException(response));

        Assert.Throws<ClientResultException>(() => { bool b = result.Value; });
        Assert.IsFalse(result.HasValue);
        Assert.AreEqual(response.Status, result.GetRawResponse().Status);
    }

    #endregion

    #region ClientResult<T>

    [Test]
    public void CannotCreateClientResultOfTFromNullResponse()
    {
        object value = new();

        Assert.Throws<ArgumentNullException>(() => new MockClientResult<object>(value, null!));
        Assert.Throws<ArgumentNullException>(() =>
        {
            ClientResult<object> result = ClientResult.FromValue(value, null!);
        });
    }

    [Test]
    public void CannotCreateClientResultOfTFromNullValue()
    {
        MockPipelineResponse response = new MockPipelineResponse();

        Assert.Throws<ArgumentNullException>(() => new MockClientResult<object>(null!, response));
        Assert.Throws<ArgumentNullException>(() =>
        {
            ClientResult<object> result = ClientResult.FromValue<object>(null!, response);
        });
    }

    [Test]
    public void CanCreateDerivedClientResultOfT()
    {
        string value = "hello";

        PipelineResponse response = new MockPipelineResponse(200);
        DerivedClientResult<string> result = new(value, response);

        Assert.IsTrue(result.HasValue);
        Assert.AreEqual(value, result.Value);
        Assert.AreEqual(response.Status, result.GetRawResponse().Status);
    }

    #endregion

    #region Helpers

    internal class DerivedClientResult<T> : ClientResult<T>
    {
        public DerivedClientResult(T value, PipelineResponse response) : base(value, response)
        {
        }
    }

    #endregion
}
