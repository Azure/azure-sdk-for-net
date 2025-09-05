// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.LibraryClient;

internal static class CancellationTokenExtensions
{
    public static RequestOptions ToRequestOptions(this CancellationToken cancellationToken)
    {
        if (cancellationToken == default)
            return null;

        return new RequestOptions()
        {
            CancellationToken = cancellationToken
        };
    }
}

internal partial class LibraryClient
{
    private readonly LibraryClientOptions _clientOptions;
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    public LibraryClient()
    {
    }

    public LibraryClient(ClientPipeline pipeline, Uri endpoint)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }

    public LibraryClient(Uri endpoint, LibraryClientOptions options = default)
    {
        _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        options ??= new LibraryClientOptions();
        _clientOptions = options;
        _pipeline = ClientPipeline.Create(options);
    }

    #region GetBookSummary

    public virtual async Task<ClientResult<Book>> GetBookSummaryAsync(string title, string author)
    {
        ClientResult result = await GetBookSummaryAsync(title, author, new RequestOptions()).ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();
        Book value = Book.FromResponse(response);
        return ClientResult.FromValue(value, response);
    }

    public virtual async Task<ClientResult> GetBookSummaryAsync(string title, string author, RequestOptions options = null)
    {
        options ??= new RequestOptions();
        using PipelineMessage message = CreateGetBookSummaryRequest(title, author, options);

        _pipeline.Send(message);

        PipelineResponse response = message.Response!;
        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw await ClientResultException.CreateAsync(response).ConfigureAwait(false);
        }
        return ClientResult.FromResponse(response);
    }

    public virtual ClientResult<Book> GetBookSummary(string title, string author)
    {
        ClientResult result = GetBookSummary(title, author);
        PipelineResponse response = result.GetRawResponse();
        Book book = Book.FromResponse(response);
        return ClientResult.FromValue(book, response);
    }

    public virtual ClientResult GetBookSummary(string title, string author, RequestOptions options = null)
    {
        options ??= new RequestOptions();
        using PipelineMessage message = CreateGetBookSummaryRequest(title, author, options);

        _pipeline.Send(message);

        PipelineResponse response = message.Response!;
        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw new ClientResultException(response);
        }
        return ClientResult.FromResponse(response);
    }

    #endregion

    #region AddBookToLibraryAsync

    public virtual ClientResult<Book> AddBookToLibrary(Book book)
    {
        BinaryContent content = BinaryContent.Create(book);
        ClientResult result = AddBookToLibrary(content);

        PipelineResponse response = result.GetRawResponse();
        Book value = ModelReaderWriter.Read<Book>(response.Content)!;

        return ClientResult.FromValue(value, response);
    }

    public virtual ClientResult AddBookToLibrary(BinaryContent book, RequestOptions options = null)
    {
        options ??= new RequestOptions();
        using PipelineMessage message = CreateAddBookRequest(book, options);

        _pipeline.Send(message);
        PipelineResponse response = message.Response!;

        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw new ClientResultException(response);
        }
        return ClientResult.FromResponse(response);
    }

    public virtual async Task<ClientResult<Book>> AddBookToLibraryAsync(Book book)
    {
        BinaryContent content = BinaryContent.Create(book);
        ClientResult result = await AddBookToLibraryAsync(content).ConfigureAwait(false);

        PipelineResponse response = result.GetRawResponse();
        Book value = ModelReaderWriter.Read<Book>(response.Content)!;

        return ClientResult.FromValue(value, response);
    }

    public virtual async Task<ClientResult> AddBookToLibraryAsync(BinaryContent book, RequestOptions options = null)
    {
        options ??= new RequestOptions();
        using PipelineMessage message = CreateAddBookRequest(book, options);

        _pipeline.Send(message);
        PipelineResponse response = message.Response!;

        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw await ClientResultException.CreateAsync(response).ConfigureAwait(false);
        }
        return ClientResult.FromResponse(response);
    }

    #endregion

    #region AddFileAssociation

    public virtual async Task<ClientResult<BookFileContent>> UploadBookContentAsync(Stream file, string filename, string purpose)
    {
        using MultiPartFormDataBinaryContent content = new();
        content.Add(file, "file", filename);
        content.Add(purpose, "purpose");

        ClientResult result = await UploadBookContentAsync(content, content.ContentType).ConfigureAwait(false);

        PipelineResponse response = result.GetRawResponse();
        BookFileContent value = ModelReaderWriter.Read<BookFileContent>(response.Content)!;

        return ClientResult.FromValue(value, response);
    }

    public virtual async Task<ClientResult> UploadBookContentAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        options ??= new RequestOptions();
        using PipelineMessage message = CreateUploadBookContentMessage(content, contentType, options);

        _pipeline.Send(message);

        PipelineResponse response = message.Response!;
        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw await ClientResultException.CreateAsync(response).ConfigureAwait(false);
        }

        return ClientResult.FromResponse(response);
    }

    public virtual ClientResult<BookFileContent> UploadBookContent(Stream file, string filename, string purpose)
    {
        using MultiPartFormDataBinaryContent content = new();
        content.Add(file, "file", filename);
        content.Add(purpose, "purpose");

        ClientResult result = UploadBookContent(content, content.ContentType);

        PipelineResponse response = result.GetRawResponse();
        BookFileContent value = ModelReaderWriter.Read<BookFileContent>(response.Content)!;

        return ClientResult.FromValue(value, response);
    }

    public virtual ClientResult UploadBookContent(BinaryContent content, string contentType, RequestOptions options = null)
    {
        options ??= new RequestOptions();
        using PipelineMessage message = CreateUploadBookContentMessage(content, contentType, options);

        _pipeline.Send(message);

        PipelineResponse response = message.Response!;
        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw new ClientResultException(response);
        }

        return ClientResult.FromResponse(response);
    }

    #endregion

    #region GetBooks (Pagination)

    public virtual AsyncCollectionResult<Book> GetBooksAsync(
        BookCollectionOptions options = default,
        CancellationToken cancellationToken = default)
    {
        return GetBooksAsync(options?.PageSizeLimit, options?.Author, options?.AfterId, options?.BeforeId, cancellationToken.ToRequestOptions())
            as AsyncCollectionResult<Book>;
    }

    public virtual CollectionResult<Book> GetBooks(
        BookCollectionOptions options = default,
        CancellationToken cancellationToken = default)
    {
        return GetBooks(options?.PageSizeLimit, options?.Author, options?.AfterId, options?.BeforeId, cancellationToken.ToRequestOptions())
            as CollectionResult<Book>;
    }

    public virtual AsyncCollectionResult GetBooksAsync(int? limit, string author, string after, string before, RequestOptions options)
    {
        return new AsyncBookCollectionResult(this, _pipeline, options, author, limit, after, before);
    }

    public virtual CollectionResult GetBooks(int? limit, string author, string after, string before, RequestOptions options)
    {
        return new BookCollectionResult(this, _pipeline, options, author, limit, after, before);
    }

    #endregion

}
