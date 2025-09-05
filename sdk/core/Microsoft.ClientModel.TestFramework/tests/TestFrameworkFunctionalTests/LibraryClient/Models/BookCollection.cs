// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.LibraryClient;

internal class BookCollectionResult : CollectionResult<Book>
{
    private readonly LibraryClient _libraryClient;
    private readonly ClientPipeline _pipeline;
    private readonly RequestOptions _options;

    // Initial values
    private readonly string _author;
    private readonly int? _limit;
    private readonly string _after;
    private readonly string _before;

    public BookCollectionResult(LibraryClient libraryClient,
        ClientPipeline pipeline, RequestOptions options,
        string author,
        int? limit, string after, string before)
    {
        _libraryClient = libraryClient;
        _pipeline = pipeline;
        _options = options;

        _author = author;
        _limit = limit;
        _after = after;
        _before = before;
    }

    public override IEnumerable<ClientResult> GetRawPages()
    {
        ClientResult page = GetFirstPage();
        yield return page;

        while (HasNextPage(page))
        {
            page = GetNextPage(page);
            yield return page;
        }
    }

    protected override IEnumerable<Book> GetValuesFromPage(ClientResult page)
    {
        BookPage bookPage = BookPage.FromResponse(page.GetRawResponse());
        return bookPage.Books;
    }

    public override ContinuationToken GetContinuationToken(ClientResult page)
    {
        BookPage bookPage = BookPage.FromResponse(page.GetRawResponse());
        return bookPage.HasMore && bookPage.NextToken != null 
            ? new ContinuationToken(bookPage.NextToken) 
            : null;
    }

    public ClientResult GetFirstPage()
        => GetBooks(_limit, _after, _before, _author, _options);

    public ClientResult GetNextPage(ClientResult result)
    {
        PipelineResponse response = result.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string lastId = doc.RootElement.GetProperty("next_token"u8).GetString();

        return GetBooks(_limit, lastId, _before, _author, _options);
    }

    public static bool HasNextPage(ClientResult result)
    {
        PipelineResponse response = result.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        bool hasMore = doc.RootElement.GetProperty("has_more"u8).GetBoolean();

        return hasMore;
    }

    internal virtual ClientResult GetBooks(int? limit, string after, string before, string author, RequestOptions options)
    {
        using PipelineMessage message = _libraryClient.CreateGetBooksRequest(author, limit, after, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }
}

internal class AsyncBookCollectionResult : AsyncCollectionResult<Book>
{
    private readonly LibraryClient _libraryClient;
    private readonly ClientPipeline _pipeline;
    private readonly RequestOptions _options;
    private readonly CancellationToken _cancellationToken;

    // Initial values
    private readonly string _author;
    private readonly int? _limit;
    private readonly string _after;
    private readonly string _before;

    public AsyncBookCollectionResult(LibraryClient libraryClient,
        ClientPipeline pipeline, RequestOptions options,
        string author,
        int? limit, string after, string before)
    {
        _libraryClient = libraryClient;
        _pipeline = pipeline;
        _options = options;
        _cancellationToken = _options.CancellationToken;

        _author = author;
        _limit = limit;
        _after = after;
        _before = before;
    }

    public async override IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        ClientResult page = await GetFirstPageAsync().ConfigureAwait(false);
        yield return page;

        while (HasNextPage(page))
        {
            page = await GetNextPageAsync(page);
            yield return page;
        }
    }

    protected override IAsyncEnumerable<Book> GetValuesFromPageAsync(ClientResult page)
    {
        BookPage bookPage = BookPage.FromResponse(page.GetRawResponse());
        return bookPage.Books.ToAsyncEnumerable(_cancellationToken);
    }

    public override ContinuationToken GetContinuationToken(ClientResult page)
    {
        BookPage bookPage = BookPage.FromResponse(page.GetRawResponse());
        return bookPage.HasMore && bookPage.NextToken != null 
            ? new ContinuationToken(bookPage.NextToken) 
            : null;
    }

    public async Task<ClientResult> GetFirstPageAsync()
        => await GetBooksAsync(_limit, _after, _before, _author, _options).ConfigureAwait(false);

    public async Task<ClientResult> GetNextPageAsync(ClientResult result)
    {
        PipelineResponse response = result.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string lastId = doc.RootElement.GetProperty("next_token"u8).GetString();

        return await GetBooksAsync(_limit, lastId, _before, _author, _options).ConfigureAwait(false);
    }

    public static bool HasNextPage(ClientResult result)
        => BookCollectionResult.HasNextPage(result);

    internal virtual async Task<ClientResult> GetBooksAsync(int? limit, string after, string before, string author, RequestOptions options)
    {
        using PipelineMessage message = _libraryClient.CreateGetBooksRequest(author, limit, after, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }
}
