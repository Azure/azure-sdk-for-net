// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

public class ClientResultTests
{
    #region ClientResult

    [Test]
    public void CannotCreateClientResultFromNullResponse()
    {
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

    #region Optional results: ClientResult<T?>

    [Test]
    public void CanCreateOptionalClientResultFromBool()
    {
        // This tests simulates creation of the result returned from a HEAD request.

        PipelineResponse response = new MockPipelineResponse(200);
        ClientResult<bool?> result = ClientResult.FromOptionalValue<bool?>(true, response);

        Assert.IsTrue(result.Value);
        Assert.IsTrue(result.Value.HasValue);
        Assert.AreEqual(response.Status, result.GetRawResponse().Status);

        response = new MockPipelineResponse(400);
        result = ClientResult.FromOptionalValue<bool?>(false, response);

        Assert.IsFalse(result.Value);
        Assert.AreEqual(response.Status, result.GetRawResponse().Status);

        response = new MockPipelineResponse(500);
        result = ClientResult.FromOptionalValue<bool?>(null, response);

        Assert.IsNull(result.Value);
        Assert.IsFalse(result.Value.HasValue);
        Assert.AreEqual(response.Status, result.GetRawResponse().Status);
    }

    [Test]
    public void OptionalClientResultDerivedTypeCanShadowValue()
    {
        PipelineResponse response = new MockPipelineResponse(200);
        MockPersistableModel model = new MockPersistableModel(1, "a");
        MockClientResult<MockPersistableModel?> result = new MockClientResult<MockPersistableModel?>(model, response);

        Assert.AreEqual(model.IntValue, result.Value!.IntValue);
        Assert.AreEqual(model.StringValue, result.Value!.StringValue);

        model = new MockPersistableModel(2, "b");

        result.SetValue(model);

        Assert.AreEqual(model.IntValue, result.Value!.IntValue);
        Assert.AreEqual(model.StringValue, result.Value!.StringValue);

        result.SetValue(null);

        Assert.IsNull(result.Value);
    }

    #endregion

    #region ClientResult<T>

    [Test]
    public void CannotCreateClientResultOfTFromNullResponse()
    {
        object value = new();

        Assert.Throws<ArgumentNullException>(() =>
        {
            ClientResult<object> result = ClientResult.FromValue(value, null!);
        });
    }

    [Test]
    public void CannotCreateClientResultOfTFromNullValue()
    {
        MockPipelineResponse response = new MockPipelineResponse();

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

        Assert.AreEqual(value, result.Value);
        Assert.AreEqual(response.Status, result.GetRawResponse().Status);
    }

    [Test]
    public void CanImplicitlyCastClientResultOfT()
    {
        PipelineResponse response = new MockPipelineResponse(200);

        string plainString = "hello";
        ClientResult<string> resultAsClientResultOfString = ClientResult.FromValue(plainString, response);
        string resultAsPlainString = ClientResult.FromValue(plainString, response);
        Assert.AreEqual(resultAsClientResultOfString.Value, resultAsPlainString);

        string? nullableString = null;
        ClientResult<string?> resultAsClientResultOfNullableString = ClientResult.FromOptionalValue(nullableString, response);
        string? resultAsNullableString = ClientResult.FromOptionalValue(nullableString, response);
        Assert.IsNull(resultAsNullableString);
        Assert.AreEqual(resultAsClientResultOfNullableString.Value, resultAsNullableString);

        int? nullableInt = null;
        ClientResult<int?> resultAsClientResultOfNullableInt = ClientResult.FromOptionalValue(nullableInt, response);
        int? resultAsNullableInt = ClientResult.FromOptionalValue(nullableInt, response);
        Assert.IsNull(resultAsNullableInt);
        Assert.AreEqual(resultAsClientResultOfNullableInt.Value, resultAsNullableInt);
    }

    #endregion

    #region MockClient Tests

    [Test]
    public void CanGetReferenceTypeValueFromClientResultOfT()
    {
        MockClient client = new MockClient();
        ClientResult<MockJsonModel> result = client.GetModel(1, "a");

        Assert.AreEqual(1, result.Value.IntValue);
        Assert.AreEqual("a", result.Value.StringValue);
        Assert.AreEqual(200, result.GetRawResponse().Status);
    }

    [Test]
    public void CanGetOptionalReferenceTypeValueFromClientResultOfT()
    {
        MockClient client = new MockClient();
        ClientResult<MockJsonModel?> result = client.GetOptionalModel(1, "a", hasValue: true);

        Assert.IsNotNull(result.Value);
        Assert.AreEqual(1, result.Value!.IntValue);
        Assert.AreEqual("a", result.Value!.StringValue);
        Assert.AreEqual(200, result.GetRawResponse().Status);

        result = client.GetOptionalModel(1, "a", hasValue: false);
        Assert.IsNull(result.Value);
        Assert.AreEqual(404, result.GetRawResponse().Status);
    }

    [Test]
    public void CanGetValueTypeValueFromClientResultOfT()
    {
        MockClient client = new MockClient();
        ClientResult<int> result = client.GetCount(1);

        Assert.AreEqual(1, result.Value);
        Assert.AreEqual(200, result.GetRawResponse().Status);
    }

    [Test]
    public void CanGetOptionalValueTypeValueFromClientResultOfT()
    {
        MockClient client = new MockClient();
        ClientResult<int?> result = client.GetOptionalCount(1, hasValue: true);

        Assert.IsNotNull(result.Value);
        Assert.IsTrue(result.Value.HasValue);
        Assert.AreEqual(1, result.Value);
        Assert.AreEqual(200, result.GetRawResponse().Status);

        result = client.GetOptionalCount(1, hasValue: false);
        Assert.IsNull(result.Value);
        Assert.IsFalse(result.Value.HasValue);
        Assert.AreEqual(404, result.GetRawResponse().Status);
    }

    #endregion

    #region Cast evolution validation

    [Test]
    public void CanCastToTFromClientResultOfT()
    {
        MockJsonModel model = new(1, "a");
        MockPipelineResponse response = new MockPipelineResponse(200);
        CastableClientResult<MockJsonModel> result = new(model, response);

        MockJsonModel value = (MockJsonModel)result.Value;

        Assert.AreEqual(model.IntValue, value.IntValue);
        Assert.AreEqual(model.StringValue, value.StringValue);
        Assert.AreEqual(200, result.GetRawResponse().Status);
    }

    [Test]
    public void CanCastToTFromOptionalClientResultOfT()
    {
        MockJsonModel model = new(1, "a");
        MockPipelineResponse response = new MockPipelineResponse(200);
        CastableClientResult<MockJsonModel?> result = new(model, response);

        MockJsonModel? value = (MockJsonModel?)result.Value;

        Assert.IsNotNull(value);
        Assert.AreEqual(model.IntValue, value!.IntValue);
        Assert.AreEqual(model.StringValue, value!.StringValue);
        Assert.AreEqual(200, result.GetRawResponse().Status);

        result = new(default, response);
        value = (MockJsonModel?)result.Value;

        Assert.IsNull(value);
        Assert.AreEqual(200, result.GetRawResponse().Status);
    }

    #endregion

    #region Helpers

    internal class DerivedClientResult<T> : ClientResult<T>
    {
        public DerivedClientResult(T value, PipelineResponse response) : base(value, response)
        {
        }
    }

    internal class MockClient
    {
        public virtual ClientResult<MockJsonModel> GetModel(int intValue, string stringValue)
        {
            MockPipelineResponse response = new(200);
            MockJsonModel model = new MockJsonModel(intValue, stringValue);
            return ClientResult.FromValue(model, response);
        }

        public virtual ClientResult<MockJsonModel?> GetOptionalModel(int intValue, string stringValue, bool hasValue)
        {
            if (hasValue)
            {
                MockPipelineResponse response = new(200);
                MockJsonModel model = new MockJsonModel(intValue, stringValue);
                return ClientResult.FromOptionalValue(model, response);
            }
            else
            {
                MockPipelineResponse response = new(404);
                return ClientResult.FromOptionalValue<MockJsonModel?>(default, response);
            }
        }

        public virtual ClientResult<int> GetCount(int count)
        {
            MockPipelineResponse response = new(200);
            return ClientResult.FromValue(count, response);
        }

        public virtual ClientResult<int?> GetOptionalCount(int count, bool hasValue)
        {
            if (hasValue)
            {
                MockPipelineResponse response = new(200);
                return ClientResult.FromOptionalValue<int?>(count, response);
            }
            else
            {
                MockPipelineResponse response = new(404);
                return ClientResult.FromOptionalValue<int?>(default, response);
            }
        }
    }

    internal class CastableClientResult<T> : ClientResult<T>
    {
        protected internal CastableClientResult(T value, PipelineResponse response) : base(value, response)
        {
        }

        public static implicit operator T(CastableClientResult<T> result) => result.Value;
    }

    #endregion
}
