// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.AI.Extensions.OpenAI;

internal sealed class LegacyCollectionResult<T> : CollectionResult<T>
{
    private readonly CollectionResult _source;

    internal LegacyCollectionResult(CollectionResult source) => _source = source;

    public override IEnumerable<ClientResult> GetRawPages() => _source.GetRawPages();

    public override ContinuationToken GetContinuationToken(ClientResult page) => _source.GetContinuationToken(page);

    protected override IEnumerable<T> GetValuesFromPage(ClientResult page) => ReadPage(page);

    internal static IEnumerable<T> ReadPage(ClientResult page)
    {
        using JsonDocument document = JsonDocument.Parse(page.GetRawResponse().Content);
        foreach (JsonElement item in document.RootElement.GetProperty("data").EnumerateArray())
        {
            yield return ModelReaderWriter.Read<T>(BinaryData.FromString(item.GetRawText()),
                ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
        }
    }
}

internal sealed class LegacyAsyncCollectionResult<T> : AsyncCollectionResult<T>
{
    private readonly AsyncCollectionResult _source;

    internal LegacyAsyncCollectionResult(AsyncCollectionResult source) => _source = source;

    public override IAsyncEnumerable<ClientResult> GetRawPagesAsync() => _source.GetRawPagesAsync();

    public override ContinuationToken GetContinuationToken(ClientResult page) => _source.GetContinuationToken(page);

    protected override async IAsyncEnumerable<T> GetValuesFromPageAsync(ClientResult page)
    {
        foreach (T item in LegacyCollectionResult<T>.ReadPage(page))
        {
            yield return item;
            await Task.Yield();
        }
    }
}
