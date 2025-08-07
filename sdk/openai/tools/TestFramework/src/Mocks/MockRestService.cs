// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// Represents a mock REST service for testing purposes.
/// </summary>
/// <typeparam name="TData">The type of data stored in the service.</typeparam>
public class MockRestService<TData> : IDisposable
{
    /// <summary>
    /// Represents an entry in the mock REST service.
    /// </summary>
    /// <param name="id">The ID of the entry.</param>
    /// <param name="data">The data associated with the entry.</param>
    public record Entry(string id, TData data);

    /// <summary>
    /// Represents an error in the mock REST service.
    /// </summary>
    /// <param name="error">The error code.</param>
    /// <param name="message">The error message.</param>
    /// <param name="stack">The stack trace of the error.</param>
    public record Error(int error, string message, string? stack = null);

    private static readonly JsonSerializerOptions s_options = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private ConcurrentDictionary<string, TData> _data;
    private HttpListener _listener;
    private CancellationTokenSource _cts;
    private Task _workerTask;

    /// <summary>
    /// Initializes a new instance of the <see cref="MockRestService{TData}"/> class.
    /// </summary>
    /// <param name="basePath">(Optional) The base path of the service.</param>
    /// <param name="port">(Optional) The port number to listen on. If set to 0, a port will be automatically selected.</param>
    public MockRestService(string? basePath = null, ushort port = 0)
    {
        _data = new();
        basePath = basePath?.EnsureEndsWith("/");

        int maxAttempts = port == 0 ? 15 : 1;
        Exception? ex = null;
        for (int i = 0; _listener == null && i < maxAttempts; i++)
        {
            _listener = TryStartListener(basePath ?? string.Empty, port, out ex)!;
        }

        if (_listener == null || ex != null)
        {
            throw new ApplicationException("Failed to start the mock rest service", ex);
        }

        HttpEndpoint = TerminatePathWithSlash(new Uri(_listener.Prefixes.First()));
        _cts = new();
        _workerTask = Task.Run(() => WorkerAsync(_cts.Token), _cts.Token);
    }

    /// <summary>
    /// Gets the HTTP endpoint of the mock REST service.
    /// </summary>
    public Uri HttpEndpoint { get; }

    /// <summary>
    /// Gets all entries in the mock REST service.
    /// </summary>
    /// <returns>An enumerable collection of entries.</returns>
    public virtual IEnumerable<Entry> GetAll()
        => _data.Select(kvp => new Entry(kvp.Key, kvp.Value));

    /// <summary>
    /// Tries to get an entry from the mock REST service.
    /// </summary>
    /// <param name="id">The ID of the entry to get.</param>
    /// <param name="entry">When this method returns, contains the entry associated with the specified ID, if found; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if the entry was found; otherwise, <c>false</c>.</returns>
    public virtual bool TryGet(string id, out Entry? entry)
    {
        if (_data.TryGetValue(id, out TData? value))
        {
            entry = new(id, value);
            return true;
        }

        entry = null;
        return false;
    }

    /// <summary>
    /// Tries to add an entry to the mock REST service.
    /// </summary>
    /// <param name="id">The ID of the entry to add.</param>
    /// <param name="data">The data associated with the entry.</param>
    /// <param name="entry">When this method returns, contains the added entry, if successful; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if the entry was added successfully; otherwise, <c>false</c>.</returns>
    public virtual bool TryAdd(string id, TData data, out Entry? entry)
    {
        entry = null;

        if (_data.TryAdd(id, data))
        {
            entry = new(id, data);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Tries to delete an entry from the mock REST service.
    /// </summary>
    /// <param name="id">The ID of the entry to delete.</param>
    /// <returns><c>true</c> if the entry was deleted successfully; otherwise, <c>false</c>.</returns>
    public virtual bool TryDelete(string id)
        => _data.TryRemove(id, out _);

    /// <summary>
    /// Tries to update an entry in the mock REST service.
    /// </summary>
    /// <param name="id">The ID of the entry to update.</param>
    /// <param name="data">The updated data for the entry.</param>
    /// <param name="entry">When this method returns, contains the updated entry, if successful; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if the entry was updated successfully; otherwise, <c>false</c>.</returns>
    public virtual bool TryUpdate(string id, TData data, out Entry? entry)
    {
        _data[id] = data;
        entry = new(id, data);
        return true;
    }

    /// <summary>
    /// Resets the mock REST service removing all entries.
    /// </summary>
    public virtual void Reset()
        => _data.Clear();

    /// <summary>
    /// Disposes of the resources used by the mock REST service.
    /// </summary>
    public void Dispose()
    {
        _cts.Cancel();
        _listener.Stop();
        try { _workerTask.Wait(500); } catch { }
        _listener.Close();
        _cts.Dispose();
    }

    /// <summary>
    /// Worker method that handles incoming HTTP requests.
    /// </summary>
    /// <param name="token">The cancellation token.</param>
    protected virtual async Task WorkerAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            HttpListenerContext context = await _listener.GetContextAsync().ConfigureAwait(false);
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            if (request == null || request.Url == null)
            {
                context.Response?.Abort();
                continue;
            }

            try
            {
                response.ContentLength64 = 0;

                string? id = GetId(HttpEndpoint, request.Url);
                switch (request.HttpMethod.ToUpperInvariant())
                {
                    case "GET":
                        if (id == null)
                        {
                            // Send down all data
                            IEnumerable<Entry> allData = GetAll();
                            WriteJsonResponse(response, 200, allData);
                        }
                        else if (TryGet(id, out Entry? entry) && entry != null)
                        {
                            WriteJsonResponse(response, 200, entry);
                        }
                        else
                        {
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                        }
                        break;

                    case "POST":
                        if (id == null)
                        {
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                        }
                        else
                        {
                            TData? data = ReadBody(request);
                            if (data == null)
                            {
                                response.StatusCode = (int)HttpStatusCode.GatewayTimeout;
                            }
                            else if (TryAdd(id, data, out Entry? entry))
                            {
                                if (entry == null)
                                {
                                    response.StatusCode = (int)HttpStatusCode.NoContent;
                                }
                                else
                                {
                                    WriteJsonResponse(response, 200, entry);
                                }
                            }
                            else
                            {
                                response.StatusCode = (int)HttpStatusCode.Conflict;
                            }
                        }
                        break;

                    case "PUT":
                        if (id == null)
                        {
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                        }
                        else
                        {
                            TData? data = ReadBody(request);
                            if (data == null)
                            {
                                response.StatusCode = (int)HttpStatusCode.GatewayTimeout;
                            }
                            else if (TryUpdate(id, data, out Entry? entry))
                            {
                                if (entry == null)
                                {
                                    response.StatusCode = (int)HttpStatusCode.NoContent;
                                }
                                else
                                {
                                    WriteJsonResponse(response, 200, entry);
                                }
                            }
                            else
                            {
                                response.StatusCode = (int)HttpStatusCode.NotFound;
                                response.ContentLength64 = 0;
                            }
                        }
                        break;

                    case "DELETE":
                        response.ContentLength64 = 0;
                        if (id == null)
                        {
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                        }
                        else if (TryDelete(id))
                        {
                            response.StatusCode = (int)HttpStatusCode.NoContent;
                        }
                        else
                        {
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                        }
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                        break;
                }

                response.Close();
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                try
                {
                    if (response.OutputStream.Length > 0 || response.OutputStream.CanSeek)
                    {
                        response.OutputStream.SetLength(0);
                    }

                    if (response.OutputStream.Length == 0)
                    {
                        WriteJsonResponse(
                            response,
                            (int)HttpStatusCode.InternalServerError,
                            new Error(
                                500,
                                ex.Message
#if DEBUG
                                , ex.StackTrace
#endif
                            ));
                    }
                }
                catch { /* we tried */ }
            }
        }
    }

    private static ushort GetFreePort()
    {
        TcpListener? listener = null;
        try
        {
            listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            return (ushort)((IPEndPoint)listener.LocalEndpoint).Port;
        }
        finally
        {
            listener?.Stop();
        }
    }

    private static HttpListener? TryStartListener(string basePath, ushort port, out Exception? ex)
    {
        if (port == 0)
        {
            port = GetFreePort();
        }

        HttpListener? listener = null;
        try
        {
            listener = new();
            listener.Prefixes.Add($"http://localhost:{port}/{basePath}");
            listener.Start();
            ex = null;
            return listener;
        }
        catch (Exception e)
        {
            listener?.Close();
            ex = e;
            return null;
        }
    }

    private static Uri TerminatePathWithSlash(Uri uri)
    {
        if (uri.IsAbsoluteUri)
        {
            if (!uri.AbsolutePath.EndsWith("/"))
            {
                UriBuilder builder = new(uri);
                builder.Path += '/';
                return builder.Uri;
            }
        }
        else if (!uri.OriginalString.EndsWith("/"))
        {
            return new Uri(uri.OriginalString + '/', UriKind.RelativeOrAbsolute);
        }

        return uri;
    }

    private static string? GetId(Uri baseUri, Uri requestUri)
    {
        Uri normalizedRequestUri = TerminatePathWithSlash(requestUri);
        Uri relative = baseUri.MakeRelativeUri(normalizedRequestUri);
        return relative.OriginalString.Split(["/"], StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
    }

    private static TData? ReadBody(HttpListenerRequest request)
    {
        if (request.ContentLength64 == 0)
        {
            return default;
        }

        return JsonSerializer.Deserialize<TData>(request.InputStream, s_options);
    }

    private static void WriteJsonResponse<T>(HttpListenerResponse response, int status, T data)
    {
        response.StatusCode = status;

        using MemoryStream buffer = new();
        JsonSerializer.Serialize(buffer, data, s_options);
        buffer.Seek(0, SeekOrigin.Begin);

        response.ContentType = "application/json";
        response.ContentLength64 = buffer.Length;
        buffer.CopyTo(response.OutputStream);
    }
}
