// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net.Http;
using System.Text.Json;
using OpenAI.TestFramework.Recording.Matchers;
using OpenAI.TestFramework.Recording.Proxy;
using OpenAI.TestFramework.Recording.Proxy.Service;
using OpenAI.TestFramework.Recording.Sanitizers;
using OpenAI.TestFramework.Recording.Transforms;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Recording.RecordingProxy;

/// <summary>
/// A client for configuring the recording text proxy. Please see here for more information:
/// https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md
/// </summary>
public class ProxyClient
{
    protected internal const string X_RECORDING_ID_HEADER = "x-recording-id";

    private ProxyClientOptions _options;
    private ClientPipeline _pipeline;

    /// <summary>
    /// For testing only.
    /// </summary>
    internal ProxyClient()
    {
        _options = new(new Uri("http://localhost:0"));
        _pipeline = ClientPipeline.Create();
    }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="options">The options to use.</param>
    public ProxyClient(ProxyClientOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _pipeline = ClientPipeline.Create(options);
    }

    /// <summary>
    /// Starts playback session of recordings.
    /// </summary>
    /// <param name="startInfo">The configuration to use for starting playback.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The result that includes any recorded variables.</returns>
    public virtual ProxyClientResult<IDictionary<string, string>> StartPlayback(RecordingStartInformation startInfo, CancellationToken token = default)
    {
        if (startInfo == null)
        {
            throw new ArgumentNullException(nameof(startInfo));
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "playback/start", startInfo, token);
        return SendSyncOrAsync<IDictionary<string, string>>(false, message, token).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Starts playback session of recordings asynchronously.
    /// </summary>
    /// <param name="startInfo">The configuration to use for starting playback.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The result that includes any recorded variables.</returns>
    public virtual async Task<ProxyClientResult<IDictionary<string, string>>> StartPlaybackAsync(RecordingStartInformation startInfo, CancellationToken token = default)
    {
        if (startInfo == null)
        {
            throw new ArgumentNullException(nameof(startInfo));
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "playback/start", startInfo, token);
        return await SendSyncOrAsync<IDictionary<string, string>>(true, message, token).ConfigureAwait(false);
    }

    /// <summary>
    /// Stops a playback session.
    /// </summary>
    /// <param name="recordingId">The ID for the playback session to stop.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual ProxyClientResult StopPlayback(string recordingId, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(recordingId))
        {
            throw new ArgumentException("Recording ID cannot be null, empty, or white space only");
        }

        PipelineMessage message = CreateJsonRequest<object>(HttpMethod.Post, "playback/stop", null, token, new()
        {
            [X_RECORDING_ID_HEADER] = recordingId,
        });
        return SendSyncOrAsync(false, message, token).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Stops a playback session asynchronously.
    /// </summary>
    /// <param name="recordingId">The ID for the playback session to stop.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual async Task<ProxyClientResult> StopPlaybackAsync(string recordingId, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(recordingId))
        {
            throw new ArgumentException("Recording ID cannot be null, empty, or white space only");
        }

        PipelineMessage message = CreateJsonRequest<object>(HttpMethod.Post, "playback/stop", null, token, new()
        {
            [X_RECORDING_ID_HEADER] = recordingId,
        });
        return await SendSyncOrAsync(true, message, token).ConfigureAwait(false);
    }

    /// <summary>
    /// Starts a recording session.
    /// </summary>
    /// <param name="startInfo">The configuration to use for the recording session.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual ProxyClientResult StartRecording(RecordingStartInformation startInfo, CancellationToken token = default)
    {
        if (startInfo == null)
        {
            throw new ArgumentNullException(nameof(startInfo));
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "record/start", startInfo, token);
        return SendSyncOrAsync(false, message, token).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Starts a recording session asynchronously.
    /// </summary>
    /// <param name="startInfo">The configuration to use for the recording session.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual async Task<ProxyClientResult> StartRecordingAsync(RecordingStartInformation startInfo, CancellationToken token = default)
    {
        if (startInfo == null)
        {
            throw new ArgumentNullException(nameof(startInfo));
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "record/start", startInfo, token);
        return await SendSyncOrAsync(true, message, token).ConfigureAwait(false);
    }

    /// <summary>
    /// Stops a recording session.
    /// </summary>
    /// <param name="recordingId">The identifier for the recording session.</param>
    /// <param name="variables">(Optional) Any additional variables to include with the recording.</param>
    /// <param name="skipRecording">(Optional) Set this to true to turn off recording.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual ProxyClientResult StopRecording(string recordingId, IDictionary<string, string>? variables = null, bool skipRecording = false, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(recordingId))
        {
            throw new ArgumentException("Recording ID cannot be null, empty, or white space only");
        }

        Dictionary<string, string> additionalHeaders = new()
        {
            [X_RECORDING_ID_HEADER] = recordingId
        };

        if (skipRecording)
        {
            additionalHeaders["x-recording-skip"] = "request-response";
        }

        variables ??= new Dictionary<string, string>();
        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "record/stop", variables, token, additionalHeaders);
        return SendSyncOrAsync(false, message, token).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Stops a recording session asynchronously.
    /// </summary>
    /// <param name="recordingId">The ID for the recording session to stop.</param>
    /// <param name="variables">(Optional) Any additional variables to include with the recording.</param>
    /// <param name="skipRecording">(Optional) Set this to true to turn off recording.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual async Task<ProxyClientResult> StopRecordingAsync(string recordingId, IDictionary<string, string>? variables = null, bool skipRecording = false, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(recordingId))
        {
            throw new ArgumentException("Recording ID cannot be null, empty, or white space only");
        }

        Dictionary<string, string> additionalHeaders = new()
        {
            [X_RECORDING_ID_HEADER] = recordingId
        };

        if (skipRecording)
        {
            additionalHeaders["x-recording-skip"] = "request-response";
        }

        variables ??= new Dictionary<string, string>();
        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "record/stop", variables, token, additionalHeaders);
        return await SendSyncOrAsync(true, message, token).ConfigureAwait(false);
    }

    /// <summary>
    /// Sets options for the proxy.
    /// </summary>
    /// <param name="recordingId">The identifier for the playback/recording session.</param>
    /// <param name="options">The options to set.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual ProxyClientResult SetRecordingTransportOptions(string recordingId, ProxyServiceOptions options, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(recordingId))
        {
            throw new ArgumentException("Recording ID cannot be null, empty, or white space only");
        }
        else if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "admin/setrecordingoptions", options, token, new()
        {
            [X_RECORDING_ID_HEADER] = recordingId,
        });
        return SendSyncOrAsync(false, message, token).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Sets options for the proxy asynchronously.
    /// </summary>
    /// <param name="recordingId">The identifier for the playback/recording session.</param>
    /// <param name="options">The options to set.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual async Task<ProxyClientResult> SetRecordingTransportOptionsAsync(string recordingId, ProxyServiceOptions options, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(recordingId))
        {
            throw new ArgumentException("Recording ID cannot be null, empty, or white space only");
        }
        else if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "admin/setrecordingoptions", options, token, new()
        {
            [X_RECORDING_ID_HEADER] = recordingId,
        });
        return await SendSyncOrAsync(true, message, token).ConfigureAwait(false);
    }

    /// <summary>
    /// Removes some pre-defined sanitizers to be used during recording/playback by specifying their IDs.
    /// </summary>
    /// <param name="sanitizerIds">The set of sanitizer IDs to remove.</param>
    /// <param name="recordingId">(Optional) If specified, the sanitizers will be removed for a particular session only.
    /// If null, the sanitizers will be removed globally on the test proxy.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual ProxyClientResult RemoveSanitizers(ISet<string> sanitizerIds, string? recordingId = null, CancellationToken token = default)
    {
        if (sanitizerIds == null)
        {
            throw new ArgumentNullException(nameof(sanitizerIds));
        }

        Dictionary<string, string> headers = new();
        if (recordingId != null)
        {
            headers[X_RECORDING_ID_HEADER] = recordingId;
        }

        PipelineMessage message = CreateJsonRequest(
            HttpMethod.Post,
            "admin/removesanitizers",
            new SanitizerIdList() { Sanitizers = sanitizerIds.ToArray() },
            token,
            headers);
        return SendSyncOrAsync(false, message, token).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Removes some pre-defined sanitizers to be used during recording/playback by specifying their IDs.
    /// </summary>
    /// <param name="sanitizerIds">The set of sanitizer IDs to remove.</param>
    /// <param name="recordingId">(Optional) If specified, the sanitizers will be removed for a particular session only.
    /// If null, the sanitizers will be removed globally on the test proxy.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual async Task<ProxyClientResult> RemoveSanitizersAsync(ISet<string> sanitizerIds, string? recordingId = null, CancellationToken token = default)
    {
        if (sanitizerIds == null)
        {
            throw new ArgumentNullException(nameof(sanitizerIds));
        }

        Dictionary<string, string> headers = new();
        if (recordingId != null)
        {
            headers[X_RECORDING_ID_HEADER] = recordingId;
        }

        PipelineMessage message = CreateJsonRequest(
            HttpMethod.Post,
            "admin/removesanitizers",
            new SanitizerIdList() { Sanitizers = sanitizerIds.ToArray() },
            token,
            headers);
        return await SendSyncOrAsync(true, message, token).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds sanitizers for the recording test proxy.
    /// </summary>
    /// <param name="sanitizers">The sanitizers to add.</param>
    /// <param name="recordingId">(Optional) If specified, the sanitizers will added for a particular session only.
    /// If null, the sanitizers will be added globally on the test proxy.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result with the set of sanitizer IDs added.</returns>
    public virtual ProxyClientResult<IReadOnlyList<string>> AddSanitizers(IEnumerable<BaseSanitizer> sanitizers, string? recordingId = null, CancellationToken token = default)
    {
        if (sanitizers == null)
        {
            throw new ArgumentNullException(nameof(sanitizers));
        }

        Dictionary<string, string> headers = new();
        if (recordingId != null)
        {
            headers[X_RECORDING_ID_HEADER] = recordingId;
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "Admin/AddSanitizers", sanitizers, token, headers);
        ProxyClientResult<SanitizerIdList> result = SendSyncOrAsync<SanitizerIdList>(false, message, token).GetAwaiter().GetResult();
        return new ProxyClientResult<IReadOnlyList<string>>(
            result.Value.Sanitizers ?? Array.Empty<string>(),
            result.GetRawResponse());
    }

    /// <summary>
    /// Adds sanitizers for the recording test proxy asynchronously.
    /// </summary>
    /// <param name="sanitizers">The sanitizers to add.</param>
    /// <param name="recordingId">(Optional) If specified, the sanitizers will added for a particular session only.
    /// If null, the sanitizers will be added globally on the test proxy.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result with the set of sanitizer IDs added.</returns>
    public virtual async Task<ProxyClientResult<IReadOnlyList<string>>> AddSanitizersAsync(IEnumerable<BaseSanitizer> sanitizers, string? recordingId = null, CancellationToken token = default)
    {
        if (sanitizers == null)
        {
            throw new ArgumentNullException(nameof(sanitizers));
        }

        Dictionary<string, string> headers = new();
        if (recordingId != null)
        {
            headers[X_RECORDING_ID_HEADER] = recordingId;
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "Admin/AddSanitizers", sanitizers, token, headers);
        ProxyClientResult<SanitizerIdList> result = await SendSyncOrAsync<SanitizerIdList>(true, message, token).ConfigureAwait(false);
        return new ProxyClientResult<IReadOnlyList<string>>(
            result.Value.Sanitizers ?? Array.Empty<string>(),
            result.GetRawResponse());
    }

    /// <summary>
    /// Sets the matcher to use.
    /// </summary>
    /// <param name="matcher">The matcher to use.</param>
    /// <param name="recordingId">(Optional) If specified, the matcher will be set for a particular session only.
    /// If null, the matcher will be set globally on the test proxy.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual ProxyClientResult SetMatcher(BaseMatcher matcher, string? recordingId = null, CancellationToken token = default)
    {
        if (matcher == null)
        {
            throw new ArgumentNullException(nameof(matcher));
        }

        Dictionary<string, string> headers = new()
        {
            ["x-abstraction-identifier"] = matcher.Type
        };

        if (recordingId != null)
        {
            headers[X_RECORDING_ID_HEADER] = recordingId;
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "admin/setmatcher", matcher, token, headers);
        return SendSyncOrAsync(false, message, token).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Sets the matcher to use asynchronously.
    /// </summary>
    /// <param name="matcher">The matcher to use.</param>
    /// <param name="recordingId">(Optional) If specified, the matcher will be set for a particular session only.
    /// If null, the matcher will be set globally on the test proxy.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual async Task<ProxyClientResult> SetMatcherAsync(BaseMatcher matcher, string? recordingId = null, CancellationToken token = default)
    {
        if (matcher == null)
        {
            throw new ArgumentNullException(nameof(matcher));
        }

        Dictionary<string, string> headers = new()
        {
            ["x-abstraction-identifier"] = matcher.Type
        };

        if (recordingId != null)
        {
            headers[X_RECORDING_ID_HEADER] = recordingId;
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "admin/setmatcher", matcher, token, headers);
        return await SendSyncOrAsync(true, message, token).ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a transform.
    /// </summary>
    /// <param name="transform">The transform to add.</param>
    /// <param name="recordingId">(Optional) If specified, the transform will be added for a particular session only.
    /// If null, the transform will be added globally on the test proxy.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual ProxyClientResult AddTransform(BaseTransform transform, string? recordingId = null, CancellationToken token = default)
    {
        if (transform == null)
        {
            throw new ArgumentNullException(nameof(transform));
        }

        Dictionary<string, string> headers = new()
        {
            ["x-abstraction-identifier"] = transform.Type
        };

        if (recordingId != null)
        {
            headers[X_RECORDING_ID_HEADER] = recordingId;
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "admin/addtransform", transform, token, headers);
        return SendSyncOrAsync(false, message, token).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Adds a transform asynchronously.
    /// </summary>
    /// <param name="transform">The transform to add.</param>
    /// <param name="recordingId">(Optional) If specified, the transform will be added for a particular session only.
    /// If null, the transform will be added globally on the test proxy.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual async Task<ProxyClientResult> AddTransformAsync(BaseTransform transform, string? recordingId = null, CancellationToken token = default)
    {
        if (transform == null)
        {
            throw new ArgumentNullException(nameof(transform));
        }

        Dictionary<string, string> headers = new()
        {
            ["x-abstraction-identifier"] = transform.Type
        };

        if (recordingId != null)
        {
            headers[X_RECORDING_ID_HEADER] = recordingId;
        }

        PipelineMessage message = CreateJsonRequest(HttpMethod.Post, "admin/addtransform", transform, token, headers);
        return await SendSyncOrAsync(true, message, token).ConfigureAwait(false);
    }

    /// <summary>
    /// Resets the sanitizers, matcher, and transforms to the default.
    /// </summary>
    /// <param name="recordingId">(Optional) If specified, only the particular session will be reset.
    /// If null, the reset will apply globally.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual ProxyClientResult Reset(string? recordingId = null, CancellationToken token = default)
    {
        Dictionary<string, string> headers = new();
        if (recordingId != null)
        {
            headers[X_RECORDING_ID_HEADER] = recordingId;
        }

        PipelineMessage message = CreateJsonRequest<object>(HttpMethod.Post, "Admin/Reset", null, token, headers);
        return SendSyncOrAsync(false, message, token).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Resets the sanitizers, matcher, and transforms to the default asynchronously.
    /// </summary>
    /// <param name="recordingId">(Optional) If specified, only the particular session will be reset.
    /// If null, the reset will apply globally.</param>
    /// <param name="token">The cancellation token to use.</param>
    /// <returns>The client result.</returns>
    public virtual async Task<ProxyClientResult> ResetAsync(string? recordingId = null, CancellationToken token = default)
    {
        Dictionary<string, string> headers = new();
        if (recordingId != null)
        {
            headers[X_RECORDING_ID_HEADER] = recordingId;
        }

        PipelineMessage message = CreateJsonRequest<object>(HttpMethod.Post, "Admin/Reset", null, token, headers);
        return await SendSyncOrAsync(true, message, token).ConfigureAwait(false);
    }

    /// <summary>
    /// Lists the available sanitizers, matchers, and transforms.
    /// </summary>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The client result with the HTML returned from the service.</returns>
    public virtual ProxyClientResult<string> ListAvailable(CancellationToken token = default)
    {
        PipelineMessage message = CreateJsonRequest<object>(HttpMethod.Get, "Info/Available", null, token);
        ProxyClientResult result = SendSyncOrAsync(false, message, token).GetAwaiter().GetResult();
        return new ProxyClientResult<string>(result.GetRawResponse().Content.ToString(), result.GetRawResponse());
    }

    /// <summary>
    /// Lists the available sanitizers, matchers, and transforms asynchronously.
    /// </summary>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The client result with the HTML returned from the service.</returns>
    public virtual async Task<ProxyClientResult<string>> ListAvailableAsync(CancellationToken token = default)
    {
        PipelineMessage message = CreateJsonRequest<object>(HttpMethod.Get, "Info/Available", null, token);
        ProxyClientResult result = await SendSyncOrAsync(true, message, token).ConfigureAwait(false);
        return new ProxyClientResult<string>(result.GetRawResponse().Content.ToString(), result.GetRawResponse());
    }

    protected virtual PipelineMessage CreateJsonRequest<TBody>(HttpMethod method, string path, TBody? body, CancellationToken token, Dictionary<string, string>? headers = null)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        message.Apply(new RequestOptions
        {
            CancellationToken = token,
            BufferResponse = true
        });

        PipelineRequest request = message.Request;
        request.Method = method.Method;
        request.Uri = new Uri(_options.HttpEndpoint, path);
        request.Headers.Add("Accept", "application/json");

        if (headers != null)
        {
            foreach (var kvp in headers)
            {
                request.Headers.Add(kvp.Key, kvp.Value);
            }
        }

        if (body != null)
        {
            MemoryStream stream = new();
            using Utf8JsonWriter writer = new(stream);
            JsonSerializer.Serialize(writer, body, Default.RecordingJsonOptions);
            BinaryData jsonBody = BinaryData.FromBytes(new ReadOnlyMemory<byte>(stream.GetBuffer(), 0, (int)stream.Length));

            request.Headers.Add("Content-Type", "application/json");
            request.Content = BinaryContent.Create(jsonBody);
        }

        return message;
    }

    protected virtual async ValueTask<ProxyClientResult> SendSyncOrAsync(bool isAsync, PipelineMessage message, CancellationToken token)
    {
        if (isAsync)
        {
            await _pipeline.SendAsync(message).ConfigureAwait(false);
        }
        else
        {
            _pipeline.Send(message);
        }

        PipelineResponse response = message.Response ?? throw new ClientResultException("Response was null", message.Response);
        if (response.IsError)
        {
            if (response.Content.ToMemory().Length > 0)
            {
                string contentType = response.Headers.GetFirstOrDefault("Content-Type") ?? string.Empty;

                if (contentType.StartsWith("text/", StringComparison.OrdinalIgnoreCase))
                {
                    string error = response.Content.ToString();
                    throw new ClientResultException(error, response);
                }
                else if (contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                {
                    string error;
                    try
                    {
                        var parsed = response.Content.ToObjectFromJson<ErrorResponse>(new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        error = $"{parsed.Status}: {parsed.Message}";
                    }
                    catch 
                    {
                        error = response.Content.ToString();
                    }

                    throw new ClientResultException(error, response);
                }
            }

            throw new ClientResultException(response);
        }

        return new ProxyClientResult(response);
    }

    protected virtual async ValueTask<ProxyClientResult<TResponse>> SendSyncOrAsync<TResponse>(bool isAsync, PipelineMessage message, CancellationToken token)
    {
        if (isAsync)
        {
            await SendSyncOrAsync(isAsync, message, token).ConfigureAwait(false);
        }
        else
        {
            SendSyncOrAsync(isAsync, message, token).GetAwaiter().GetResult();
        }

        PipelineResponse response = message.Response!; // we've already validated this is not null in the previous call

        try
        {
            TResponse? parsed = JsonSerializer.Deserialize<TResponse>(response.Content.ToMemory().Span, Default.TestProxyJsonOptions);
            if (parsed == null)
            {
                throw new InvalidDataException("Response parsed to null");
            }

            return new ProxyClientResult<TResponse>(parsed, response);
        }
        catch (Exception ex)
        {
            throw new ClientResultException("Failed to deserialize response", message.Response, ex);
        }
    }

    private struct ErrorResponse
    {
        public string? Message { get; set; }
        public string? Status { get; set; }
    }
}
