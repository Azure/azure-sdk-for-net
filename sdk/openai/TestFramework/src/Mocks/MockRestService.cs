// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Mocks;

public abstract class MockRestService<TData> : IDisposable
{
    public record Entry(string id, TData data);
    public record Error(int error, string message, string? stack = null);

    private static readonly JsonSerializerOptions s_options = new()
    {
        WriteIndented = true,
#pragma warning disable SYSLIB0020
        IgnoreNullValues = true
#pragma warning restore SYSLIB0020
    };

    private HttpListener _listener;
    private CancellationTokenSource _cts;
    private Task _workerTask;

    public MockRestService(string? basePath = null, ushort port = 0)
    {
        if (basePath?.EndsWith("/") == false)
        {
            basePath += "/";
        }

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

    public Uri HttpEndpoint { get; }

    public abstract IEnumerable<Entry> GetAll();
    public abstract bool TryGet(string id, out Entry? entry);
    public abstract bool TryAdd(string id, TData? data, out Entry? entry);
    public abstract bool TryDelete(string id);
    public abstract bool TryUpdate(string id, TData? data, out Entry? entry);
    public abstract void Reset();

    public void Dispose()
    {
        _cts.Cancel();
        _listener.Stop();
        try { _workerTask.Wait(500); } catch { }
        _listener.Close();
        _cts.Dispose();
    }

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
                            if (TryAdd(id, data, out Entry? entry))
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
                            if (TryUpdate(id, data, out Entry? entry))
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

        return JsonExtensions.Deserialize<TData>(request.InputStream, s_options);
    }

    private static void WriteJsonResponse<T>(HttpListenerResponse response, int status, T data)
    {
        response.StatusCode = status;

        using MemoryStream buffer = new();
        JsonExtensions.Serialize(buffer, data, s_options);
        buffer.Seek(0, SeekOrigin.Begin);

        response.ContentType = "application/json";
        response.ContentLength64 = buffer.Length;
        buffer.CopyTo(response.OutputStream);
    }
}
