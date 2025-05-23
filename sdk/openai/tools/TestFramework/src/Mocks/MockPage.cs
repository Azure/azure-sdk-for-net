// Copyright(c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// Represents a mock page with a collection of values and a reference to the next page.
/// </summary>
/// <typeparam name="TValue">The type of values in the page.</typeparam>
public class MockPage<TValue>
{
    /// <summary>
    /// Gets or sets the collection of values in the page.
    /// </summary>
    required public IReadOnlyList<TValue> Values { get; set; }

    /// <summary>
    /// Gets or sets the first item on the next page.
    /// </summary>
    required public int Next { get; set; }

    /// <summary>
    /// Creates a <see cref="MockPage{TValue}"/> instance from a <see cref="ClientResult"/>.
    /// </summary>
    /// <param name="result">The client result.</param>
    /// <returns>The created <see cref="MockPage{TValue}"/> instance.</returns>
    public static MockPage<TValue>? FromClientResult(ClientResult result)
    {
        PipelineResponse response = result.GetRawResponse();
        response.BufferContent();
        MockPage<TValue> mockPage = response.Content.ToObjectFromJson<MockPage<TValue>>() ?? new MockPage<TValue>
        {
            Values = [],
            Next = 0
        };
        return mockPage;
    }

    /// <summary>
    /// Converts the <see cref="MockPage{TValue}"/> instance to a <see cref="ClientResult"/>.
    /// </summary>
    /// <returns>The converted <see cref="ClientResult"/> instance.</returns>
    public ClientResult AsClientResult()
    {
        var serialized = BinaryData.FromObjectAsJson(this);
        var mockResponse = new MockPipelineResponse(content: serialized);
        return ClientResult.FromResponse(mockResponse);
    }
}
