// Copyright(c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// A captured message. This is used as part of the <see cref="MockPipelineTransport"/>.
/// </summary>
public abstract class CapturedMessage
{
    private static BinaryData? s_emptyData = null;
    private static IReadOnlyDictionary<string, IReadOnlyList<string>>? s_emptyHeaders = null;

    /// <summary>
    /// An empty header dictionary.
    /// </summary>
    public static IReadOnlyDictionary<string, IReadOnlyList<string>> EMPTY_HEADERS
        => s_emptyHeaders ??= new Dictionary<string, IReadOnlyList<string>>();

    /// <summary>
    /// Empty binary data.
    /// </summary>
    public static BinaryData EMPTY_DATA => s_emptyData ??= new BinaryData(Array.Empty<byte>());

    /// <summary>
    /// Gets or sets the headers of the captured message.
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<string>> Headers { get; init; } = EMPTY_HEADERS;

    /// <summary>
    /// Gets or sets the content of the captured message.
    /// </summary>
    public BinaryData Content { get; init; } = EMPTY_DATA;

    /// <summary>
    /// Copies the content from the provided <see cref="HttpContent"/> to a new <see cref="BinaryData"/> instance.
    /// </summary>
    /// <param name="content">The <see cref="HttpContent"/> to copy the content from.</param>
    /// <returns>A new <see cref="BinaryData"/> instance containing the copied content.</returns>
    public static BinaryData CopyContent(HttpContent? content)
    {
        if (content == null)
        {
            return EMPTY_DATA;
        }

        using Stream stream = content.ReadAsStreamAsync().Result;
        return BinaryData.FromStream(stream);
    }

    /// <summary>
    /// Copies the headers from the provided <see cref="HttpHeaders"/> and <see cref="HttpContentHeaders"/> to a new dictionary.
    /// </summary>
    /// <param name="header">The <see cref="HttpHeaders"/> to copy headers from.</param>
    /// <param name="contentHeaders">The <see cref="HttpContentHeaders"/> to copy headers from.</param>
    /// <returns>A new dictionary containing the copied headers.</returns>
    public static IReadOnlyDictionary<string, IReadOnlyList<string>> CopyHeaders(HttpHeaders header, HttpContentHeaders? contentHeaders)
    {
        Dictionary<string, IReadOnlyList<string>> dict = new(StringComparer.OrdinalIgnoreCase);
        foreach (var kvp in header)
        {
            dict[kvp.Key] = new List<string>(kvp.Value);
        }

        if (contentHeaders != null)
        {
            foreach (var kvp in contentHeaders)
            {
                var list = (List<string>?)dict.GetValueOrDefault(kvp.Key);
                if (list == null)
                {
                    list = new List<string>();
                    dict[kvp.Key] = list;
                }

                list.AddRange(kvp.Value);
            }
        }

        return dict;
    }
}

/// <summary>
/// A captured request.
/// </summary>
public class CapturedRequest : CapturedMessage
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    public CapturedRequest()
    { }

    /// <summary>
    /// Creates a new instance of <see cref="CapturedRequest"/> using the provided <see cref="HttpRequestMessage"/>.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> to create the captured request from.</param>
    public CapturedRequest(HttpRequestMessage request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        Method = request.Method;
        Uri = request.RequestUri;
        Headers = CopyHeaders(request.Headers, request.Content?.Headers);
        Content = CopyContent(request.Content);
    }

    /// <summary>
    /// Gets or sets the HTTP method of the captured request.
    /// </summary>
    public HttpMethod Method { get; init; } = HttpMethod.Get;

    /// <summary>
    /// Gets or sets the URI of the captured request.
    /// </summary>
    public Uri? Uri { get; init; }
}

/// <summary>
/// A captured response.
/// </summary>
public class CapturedResponse : CapturedMessage
{
    /// <summary>
    /// Gets or sets the status code of the captured response.
    /// </summary>
    public HttpStatusCode Status { get; init; } = HttpStatusCode.OK;

    /// <summary>
    /// Gets or sets the reason phrase of the captured response.
    /// </summary>
    public string? ReasonPhrase { get; init; } = "OK";

    /// <summary>
    /// Converts the captured response to an <see cref="HttpResponseMessage"/>.
    /// </summary>
    /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
    public HttpResponseMessage ToResponse()
    {
        const string contentPrefix = "Content-";

        HttpResponseMessage response = new()
        {
            StatusCode = Status,
            ReasonPhrase = ReasonPhrase
        };

        foreach (var kvp in Headers.Where(h => h.Key?.StartsWith(contentPrefix) == false))
        {
            response.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value);
        }

        if (Content != null && Content.ToMemory().Length > 0)
        {
            response.Content = new StreamContent(Content.ToStream());
            foreach (var kvp in Headers.Where(h => h.Key?.StartsWith(contentPrefix) == true))
            {
                response.Content.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value);
            }
        }

        return response;
    }
}


