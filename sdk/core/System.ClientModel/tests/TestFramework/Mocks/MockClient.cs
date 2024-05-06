// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace ClientModel.Tests.Mocks;

public class MockClient
{
    public bool StreamingProtocolMethodCalled { get; private set; }

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

    // mock convenience method
    public virtual AsyncResultCollection<MockJsonModel> GetModelsStreamingAsync(string content)
    {
        return new MockJsonModelCollection(content, GetModelsStreamingAsync);
    }

    // mock protocol method
    public virtual ClientResult GetModelsStreamingAsync(string content, RequestOptions? options = default)
    {
        // This mocks sending a request and returns a respose containing
        // the passed-in content in the content stream.

        MockPipelineResponse response = new();
        response.SetContent(content);

        StreamingProtocolMethodCalled = true;

        return ClientResult.FromResponse(response);
    }

    private class MockJsonModelCollection : AsyncResultCollection<MockJsonModel>
    {
        private readonly string _content;
        private readonly Func<string, RequestOptions?, ClientResult> _protocolMethod;

        public MockJsonModelCollection(string content, Func<string, RequestOptions?, ClientResult> protocolMethod)
        {
            _content = content;
            _protocolMethod = protocolMethod;
        }

        public override IAsyncEnumerator<MockJsonModel> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            Func<Task<ClientResult>> getResultAsync = async () =>
            {
                // TODO: simulate async correctly
                await Task.Delay(0);
                return _protocolMethod(_content, /*options:*/ default);
            };

            AsyncResultCollection<MockJsonModel> enumerable = Create<MockJsonModel>(getResultAsync, cancellationToken);
            return enumerable.GetAsyncEnumerator(cancellationToken);
        }
    }
}
