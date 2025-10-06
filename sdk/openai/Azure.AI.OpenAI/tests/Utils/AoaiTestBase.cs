// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Tests.Models;
using Azure.AI.OpenAI.Tests.Utils;
using Azure.AI.OpenAI.Tests.Utils.Config;
using NUnit.Framework.Interfaces;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Images;
using OpenAI.Responses;
using OpenAI.TestFramework;
using OpenAI.TestFramework.Recording.Proxy;
using OpenAI.TestFramework.Recording.Proxy.Service;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Recording.Sanitizers;
using OpenAI.TestFramework.Utils;
using OpenAI.VectorStores;
using TokenCredential = Azure.Core.TokenCredential;

namespace Azure.AI.OpenAI.Tests;

public class AoaiTestBase<TClient> : RecordedClientTestBase where TClient : class
{
    private const string AZURE_URI_SANITIZER_PATTERN = @"(?<=/(subscriptions|resourceGroups|accounts)/)([^/]+?)(?=(/|$))";
    private const string SMALL_1x1_PNG = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAIAAACQd1PeAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAFiQAABYkAZsVxhQAAAAMSURBVBhXY2BgYAAAAAQAAVzN/2kAAAAASUVORK5CYII=";

    public static readonly DateTimeOffset START_2024 = new DateTimeOffset(2024, 01, 01, 00, 00, 00, TimeSpan.Zero);
    public static readonly DateTimeOffset UNIX_EPOCH =
#if NETFRAMEWORK
        DateTimeOffset.Parse("1970-01-01T00:00:00.0000000+00:00");
#else
        DateTimeOffset.UnixEpoch;
#endif

    internal TestConfig TestConfig { get; }

    internal Assets Assets { get; }

    public AzureTestEnvironment TestEnvironment { get; }

    protected AoaiTestBase(bool isAsync) : this(isAsync, null, null)
    { }

    protected AoaiTestBase(bool isAsync, RecordedTestMode? mode = null, bool? automaticRecord = null)
        : base(isAsync, mode, automaticRecord)
    {
        TestConfig = new TestConfig(() => Mode);
        Assets = new Assets();
        TestEnvironment = new AzureTestEnvironment(Mode);

        // Remove some of the default sanitizers to customize their behavior
        RecordingOptions.SanitizersToRemove.AddRange(
        [
            "AZSDK2003", // Location header (we use a less restrictive sanitizer)
            "AZSDK4001", // Replaces entire host name in URL. We want to mask only subdomain part to make it easier to distinguish requests
            "AZSDK3430", // OpenAI liberally uses "id" in its JSON responses, and we want to keep them in the recordings
            "AZSDK3493", // $..name in JSON. OpenAI uses this for things that don't need to be sanitized
        ]);

        // Prevent resource names from leaking into recordings
        RecordingOptions.Sanitizers.AddRange(
        [
            new UriRegexSanitizer(SanitizedJsonConfig.HOST_SUBDOMAIN_PATTERN)
            {
                Value = SanitizedJsonConfig.MASK_STRING
            },
            new UriRegexSanitizer(AZURE_URI_SANITIZER_PATTERN)
            {
                Value = SanitizedJsonConfig.MASK_STRING
            },
            new HeaderRegexSanitizer("Location")
            {
                Regex = AZURE_URI_SANITIZER_PATTERN,
                Value = SanitizedJsonConfig.MASK_STRING
            },
            new HeaderRegexSanitizer("Azure-AsyncOperation")
            {
                Regex = AZURE_URI_SANITIZER_PATTERN,
                Value = SanitizedJsonConfig.MASK_STRING
            },
            new BodyKeySanitizer("$..endpoint")
            {
                Regex = SanitizedJsonConfig.HOST_SUBDOMAIN_PATTERN,
                Value = SanitizedJsonConfig.MASK_STRING
            }
        ]);

        // Prevent keys from leaking into our recordings
        RecordingOptions.SanitizeJsonBody("*..key", "*..api_key");

        // Because the current implementation of multi-part form content data in OpenAI and Azure OpenAI uses random
        // to generate boundaries, this causes problems during playback as the boundary will be different each time.
        // Longer term, we should find a way to pass the TestRecording.Random to the multi-part form generator in the
        // code. The simplest solution for now is to disable recording the body for these mime types
        RecordingOptions.RequestOverride = request =>
        {
            if (request?.Headers.GetFirstOrDefault("Content-Type")?.StartsWith("multipart/form-data") == true)
            {
                return RequestRecordMode.RecordWithoutRequestBody;
            }

            return RequestRecordMode.Record;
        };
        RecordingOptions.Sanitizers.Add(new HeaderRegexSanitizer("Content-Type")
        {
            Regex = @"multipart/form-data; boundary=[^\s]+",
            Value = "multipart/form-data; boundary=***"
        });

        // Data URIs trimmed to prevent the recording from being too large
        RecordingOptions.Sanitizers.Add(new BodyKeySanitizer("$..url")
        {
            Regex = @"(?<=data:image/png;base64,)(.+)",
            Value = SMALL_1x1_PNG
        });

        // Base64 encoded images in the response are replaced with a 1x1 black pixel PNG image to ensure valid data
        RecordingOptions.Sanitizers.Add(new BodyKeySanitizer($"..b64_json")
        {
            Value = SMALL_1x1_PNG
        });
    }

    /// <summary>
    /// Gets the top level test client to use for testing.
    /// </summary>
    /// <param name="config">The test configuration to use</param>
    /// <param name="options">(Optional) The client options to use.</param>
    /// <param name="tokenCredential">(Optional) The token credential to use. If this is null, an API key will be read from the
    /// test configuration.</param>
    /// <param name="keyCredential">(Optional) The key credential to use instead of the one from the configuration.</param>
    public virtual AzureOpenAIClient GetTestTopLevelClient(
        IConfiguration? config,
        TestClientOptions? options = null,
        TokenCredential? tokenCredential = null,
        ApiKeyCredential? keyCredential = null)
    {
        // First validate that the config has the parameters we need
        if (config == null)
        {
            throw CreateKeyNotFoundEx("any configuration");
        }
        else if (config.Endpoint is null)
        {
            throw CreateKeyNotFoundEx("endpoint");
        }
        else if (tokenCredential == null && keyCredential == null && string.IsNullOrEmpty(config.Key))
        {
            throw CreateKeyNotFoundEx("API key");
        }

        // Configure the test options as needed
        options ??= new();
        Action<PipelineRequest>? requestAction = options.ShouldOutputRequests ? DumpRequest : null;
        Action<PipelineResponse>? responseAction = options.ShouldOutputResponses ? DumpResponse : null;
        options.AddPolicy(new TestPipelinePolicy(requestAction, responseAction), PipelinePosition.PerCall);

        options = ConfigureClientOptions(options);

        AzureOpenAIClient topLevelClient;
        if (tokenCredential != null)
        {
            topLevelClient = new AzureOpenAIClient(config.Endpoint, tokenCredential, options);
        }
        else
        {
            topLevelClient = new AzureOpenAIClient(config.Endpoint, keyCredential ?? new ApiKeyCredential(config.Key!), options);
        }

        return topLevelClient;
    }

    /// <summary>
    /// Gets the properly instrumented client to use for testing. This have proper support for automatic sync/async method testing,
    /// as well as recording, and playback support.
    /// </summary>
    /// <param name="options">(Optional) The client options to use.</param>
    /// <param name="tokenCredential">(Optional) The token credential to use. If this is null, an API key will be read from the
    /// test configuration.</param>
    /// <param name="keyCredential">(Optional) The key credential to use instead of the one from the configuration.</param>
    /// <returns>The test client instance.</returns>
    public virtual TClient GetTestClient(TestClientOptions? options = null, TokenCredential? tokenCredential = null, ApiKeyCredential? keyCredential = null)
        => GetTestClient(TestConfig.GetConfig<TClient>(), options, tokenCredential, keyCredential);

    /// <summary>
    /// Gets the properly instrumented client to use for testing. This have proper support for automatic sync/async method testing,
    /// as well as recording, and playback support.
    /// </summary>
    /// <param name="configName"></param>
    /// <param name="options">(Optional) The client options to use.</param>
    /// <param name="tokenCredential">(Optional) The token credential to use. If this is null, an API key will be read from the
    /// test configuration.</param>
    /// <param name="keyCredential">(Optional) The key credential to use instead of the one from the configuration.</param>
    /// <returns>The test client instance.</returns>
    public virtual TClient GetTestClient(string configName, TestClientOptions? options = null, TokenCredential? tokenCredential = null, ApiKeyCredential? keyCredential = null)
        => GetTestClient(TestConfig.GetConfig(configName), options, tokenCredential, keyCredential);

    /// <summary>
    /// Gets a different type of client using the same configuration as the specified client.
    /// </summary>
    /// <typeparam name="TExplicitClient">The type of other client to create.</typeparam>
    /// <param name="client">The client instance whose configuration we want to use.</param>
    /// <param name="deploymentName">(Optional) The specific deployment to use instead of the one from the config.</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException">The client instance passed was not instrumented</exception>
    public virtual TExplicitClient GetTestClientFrom<TExplicitClient>(TClient client, string? deploymentName = null)
    {
        var instrumented = (TopLevelInfo?)GetClientContext(client);
        if (instrumented?.TopLevelClient != null
            && instrumented?.Config != null)
        {
            return GetTestClient<TExplicitClient>(instrumented.TopLevelClient, instrumented.Config, deploymentName);
        }

        throw new NotSupportedException("The client provided was not properly instrumented. Please make sure to get your test client " +
            "instances using the GetTestClient() methods");
    }

    #region overrides

    /// <inheritdoc />
    protected override RecordedTestMode GetDefaultRecordedTestMode()
        => AzureTestEnvironment.DefaultRecordMode;

    /// <inheritdoc />
    protected override bool GetDefaultAutomaticRecordEnabled()
        => !IsRunningInCI && AzureTestEnvironment.DefaultAutomaticRecordEnabled;

    /// <inheritdoc />
    protected override ProxyServiceOptions CreateProxyServiceOptions()
        => new()
        {
            DotnetExecutable = TestEnvironment.DotNetExe.FullName,
            TestProxyDll = TestEnvironment.TestProxyDll.FullName,
            DevCertFile = TestEnvironment.TestProxyHttpsCert.FullName,
            DevCertPassword = TestEnvironment.TestProxyHttpsCertPassword,
            StorageLocationDir = TestEnvironment.RepoRoot.FullName,
        };

    /// <inheritdoc />
    protected override RecordingStartInformation CreateRecordingSessionStartInfo()
    {
        // This uses the same directory structure as the previous Azure.Core.TestFramework used for an easy drop in replacement.
        // For example, suppose your test class is (and your class name matches the file name):
        // c:\src\azure-sdk-for-net\sdk\openai\Azure.AI.OpenAI\tests\ChatTests.cs
        // Then this would return something like:
        // sdk\openai\Azure.AI.OpenAI\tests\SessionRecords\ChatTests\TestName.json
        DirectoryInfo? sourceDir = GetType().Assembly.GetAssemblySourceDir();
        string relativeDir = PathHelpers.GetRelativePath(
            TestEnvironment.RepoRoot.FullName,
            sourceDir?.FullName ?? TestEnvironment.RepoRoot.FullName);

        string recordingFile = Path.Combine(
            relativeDir,
            "SessionRecords",
            GetType().Name,
            GetRecordedTestFileName());

        // Start at the source directory for the current test project, and then walk up the directory structure searching for
        // an "assets.json" file.
        string? assetsFile = null;
        for (
            DirectoryInfo? current = sourceDir;
            current != null && current.FullName != TestEnvironment.RepoRoot.FullName;
            current = current?.Parent)
        {
            string file = Path.Combine(current!.FullName, "assets.json");
            if (File.Exists(file))
            {
                assetsFile = file;
                break;
            }
        }

        return new()
        {
            RecordingFile = recordingFile,
            AssetsFile = assetsFile
        };
    }

#endregion

    /// <summary>
    /// Polls until a condition has been met with a maximum wait time. The function will always return the last value even
    /// if the condition was not met.
    /// </summary>
    /// <typeparam name="T">The value in the <see cref="ClientResult{T}">.</typeparam>
    /// <param name="initialValue">The initial value.</param>
    /// <param name="getAsync">The asynchronous function to get the latest state of the value.</param>
    /// <param name="stopCondition">When we should stop waiting.</param>
    /// <param name="waitTimeBetweenRequests">(Optional) The amount of time to wait between retries. This will be ignored in playback
    /// mode. Default is 2 seconds.</param>
    /// <param name="maxWait">(Optional) The maximum amount of time to wait until the condition becomes true. This will be ignored in
    /// playback mode. The default is 2 minutes.</param>
    /// <returns>The final state. This will return when the conditions have been met or we timed out.</returns>
    protected virtual Task<T> WaitUntilReturnLast<T>(T initialValue, Func<Task<ClientResult<T>>> getAsync, Predicate<T> stopCondition, TimeSpan? waitTimeBetweenRequests = null, TimeSpan? maxWait = null)
        => WaitUntilReturnLast(initialValue, new Func<Task<T>>(async () => await getAsync().ConfigureAwait(false)), stopCondition, waitTimeBetweenRequests, maxWait);

    /// <summary>
    /// Polls until a condition has been met with a maximum wait time. The function will always return the last value even
    /// if the condition was not met.
    /// </summary>
    /// <typeparam name="T">The return value.</typeparam>
    /// <param name="initialValue">The initial value.</param>
    /// <param name="getAsync">The asynchronous function to get the latest state of the value.</param>
    /// <param name="stopCondition">When we should stop waiting.</param>
    /// <param name="waitTimeBetweenRequests">(Optional) The amount of time to wait between retries. This will be ignored in playback
    /// mode. Default is 2 seconds.</param>
    /// <param name="maxWait">(Optional) The maximum amount of time to wait until the condition becomes true. This will be ignored in
    /// playback mode. The default is 2 minutes.</param>
    /// <returns>The final state. This will return when the conditions have been met or we timed out.</returns>
    protected virtual async Task<T> WaitUntilReturnLast<T>(T initialValue, Func<Task<T>> getAsync, Predicate<T> stopCondition, TimeSpan? waitTimeBetweenRequests = null, TimeSpan? maxWait = null)
    {
        TimeSpan delay, max;
        if (Mode == RecordedTestMode.Playback)
        {
            delay = TimeSpan.FromMilliseconds(10);
            max = TimeSpan.FromSeconds(30);
        }
        else
        {
            delay = waitTimeBetweenRequests ?? TimeSpan.FromSeconds(2);
            max = maxWait ?? TimeSpan.FromMinutes(2);
        }

        DateTimeOffset stopTime = DateTimeOffset.Now + max;
        T result = initialValue;

        while (!stopCondition(result) && DateTimeOffset.Now < stopTime)
        {
            await Task.Delay(delay).ConfigureAwait(false);
            result = await getAsync().ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>
    /// Gets the properly instrumented client to use for testing. This have proper support for automatic sync/async method testing,
    /// as well as recording, and playback support.
    /// </summary>
    /// <param name="config">The test configuration to use</param>
    /// <param name="options">(Optional) The client options to use.</param>
    /// <param name="tokenCredential">(Optional) The token credential to use. If this is null, an API key will be read from the
    /// test configuration.</param>
    /// <param name="keyCredential">(Optional) The key credential to use instead of the one from the configuration.</param>
    /// <returns>The test client instance.</returns>
    protected virtual TClient GetTestClient(IConfiguration? config, TestClientOptions? options = null, TokenCredential? tokenCredential = null, ApiKeyCredential? keyCredential = null)
    {
        AzureOpenAIClient topLevelClient = GetTestTopLevelClient(config, options, tokenCredential, keyCredential);
        return GetTestClient<TClient>(topLevelClient, config!, deploymentName: null, wrapClient: options?.DisableClientWrapping != true);
    }

    /// <summary>
    /// Gets the properly instrumented client to use for testing. This have proper support for automatic sync/async method testing,
    /// as well as recording, and playback support.
    /// </summary>
    /// <typeparam name="TExplicitClient">The type of test client to get.</typeparam>
    /// <param name="topLevelClient">The top level client to use.</param>
    /// <param name="config">The configuration to use to get the deployment information (if needed).</param>
    /// <returns>The instrumented client instance to use.</returns>
    /// <exception cref="NotImplementedException">Support for the type of client being requested has not been implemented yet.</exception>
    protected virtual TExplicitClient GetTestClient<TExplicitClient>(AzureOpenAIClient topLevelClient, IConfiguration config, string? deploymentName = null, bool wrapClient = true)
    {
        Func<string> getDeployment = () => deploymentName ?? config?.Deployment ?? throw CreateKeyNotFoundEx("deployment");
        object clientObject;

        switch (typeof(TExplicitClient).Name)
        {
            case nameof(AssistantClient):
                clientObject = topLevelClient.GetAssistantClient();
                break;
            case nameof(AudioClient):
                clientObject = topLevelClient.GetAudioClient(getDeployment());
                break;
            case nameof(BatchClient):
                clientObject = topLevelClient.GetBatchClient();
                break;
            case nameof(ChatClient):
                clientObject = topLevelClient.GetChatClient(getDeployment());
                break;
            case nameof(EmbeddingClient):
                clientObject = topLevelClient.GetEmbeddingClient(getDeployment());
                break;
            case nameof(OpenAIFileClient):
                clientObject = topLevelClient.GetOpenAIFileClient();
                break;
            case nameof(FineTuningClient):
                clientObject = topLevelClient.GetFineTuningClient();
                break;
            case nameof(ImageClient):
                clientObject = topLevelClient.GetImageClient(getDeployment());
                break;
            case nameof(OpenAIResponseClient):
                clientObject = topLevelClient.GetOpenAIResponseClient(getDeployment());
                break;
            case nameof(VectorStoreClient):
                clientObject = topLevelClient.GetVectorStoreClient();
                break;
            case nameof(AzureDeploymentClient):
                var accessor = NonPublic.FromField<ClientPipeline, PipelineTransport>("_transport");
                clientObject = new AzureDeploymentClient(
                    config,
                    TestEnvironment.Credential,
                    transport: accessor.Get(topLevelClient.Pipeline));
                break;
            default:
                throw new NotImplementedException($"Test client helpers not yet implemented for {typeof(TExplicitClient)}");
        };

        if (!wrapClient)
        {
            return (TExplicitClient)clientObject;
        }

        object instrumented = WrapClient(
            typeof(TExplicitClient),
            clientObject,
            new TopLevelInfo
            {
                TopLevelClient = topLevelClient,
                Config = config,
            },
            null);

        return (TExplicitClient)instrumented;
    }

    private Exception CreateKeyNotFoundEx(string whatIsMissing)
    {
        return new KeyNotFoundException($"Could not find any {whatIsMissing} to use. Please make sure you have the necessary" +
                $" {TestConfig.AssetsJson} config file, or have the needed environment variables set");
    }

    private static void DumpRequest(PipelineRequest request)
    {
        Console.WriteLine($"--- New request ---");
        Console.WriteLine($"{request.Method} {request?.Uri}");
        string headers = string.Join("\n  ",
            request!.Headers
                .Select(kvp => $"{kvp.Key}: {(kvp.Key.ToLowerInvariant().Contains("auth") ? "***" : kvp.Value)}"));
        Console.Write("  ");
        Console.WriteLine(headers);

        if (request?.Content is not null)
        {
            using MemoryStream stream = new();
            request.Content.WriteTo(stream, default);
            stream.Position = 0;

            string? contentType = request.Headers.GetFirstOrDefault("Content-Type");
            if (IsProbableTextContent(contentType))
            {
                DumpText(contentType, stream);
            }
            else
            {
                DumpHex(stream);
            }
        }
    }

    private static void DumpResponse(PipelineResponse response)
    {
        Console.WriteLine($"--- Response ---");
        Console.WriteLine($"{response.Status} - {response.ReasonPhrase}");
        string headers = string.Join(
            "\n  ",
            response.Headers
                .Where(kvp => !kvp.Key.ToLowerInvariant().Contains("client-"))
                .Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        Console.Write("  ");
        Console.WriteLine(headers);

        response.BufferContent();

        if (response!.Content is not null)
        {
            using Stream stream = response.Content.ToStream();
            string? contentType = response.Headers.GetFirstOrDefault("Content-Type");
            if (IsProbableTextContent(contentType))
            {
                DumpText(contentType, stream);
            }
            else
            {
                DumpHex(stream);
            }
        }

        Console.WriteLine();
    }

    private static bool IsProbableTextContent(string? contentType)
    {
        contentType = contentType?.ToLowerInvariant() ?? string.Empty;
        return contentType.StartsWith("application/json")
            || contentType.StartsWith("text/");
    }

    private static void DumpText(string? contentType, Stream stream)
    {
        if (contentType?.ToLowerInvariant().StartsWith("application/json") == true)
        {
            var json = JsonDocument.Parse(stream);

            stream = new MemoryStream();
            using (Utf8JsonWriter writer = new(stream, new() { Indented = true }))
            {
                json.WriteTo(writer);
            }

            stream.Seek(0, SeekOrigin.Begin);
        }

        using StreamReader reader = new(stream);
        Console.WriteLine(reader.ReadToEnd());
    }

    private static void DumpHex(Stream stream, int maxLines = 256)
    {
        byte[] buffer = new byte[32];
        StringBuilder hex = new(3 * buffer.Length);
        StringBuilder chars = new(buffer.Length);

        int read = 0;
        for (int lines = 0; (read = stream.FillBuffer(buffer)) > 0 && lines < maxLines; lines++)
        {
            for (int i = 0; i < read; i++)
            {
                hex.AppendFormat("{0:X2} ", buffer[i]);

                char c = Convert.ToChar(buffer[i]);
                chars.Append(char.IsControl(c) ? ' ' : c);
            }

            Console.Write(hex.PadRight(buffer.Length * 3));
            Console.Write("| ");
            Console.WriteLine(chars);

            hex.Clear();
            chars.Clear();
        }

        if (read != 0)
        {
            Console.WriteLine(" ... truncated");
        }
    }

    protected void ValidateById<T>(string id)
    {
        Assert.That(id, Is.Not.Null.Or.Empty);
        switch (typeof(T).Name)
        {
            case nameof(Assistant):
                _assistantIdsToDelete.Add(id);
                break;
            case nameof(AssistantThread):
                _threadIdsToDelete.Add(id);
                break;
            case nameof(OpenAIFile):
                _fileIdsToDelete.Add(id);
                break;
            case nameof(ThreadRun):
                break;
            case nameof(VectorStore):
                _vectorStoreIdsToDelete.Add(id);
                break;
            case nameof(CreateVectorStoreOperation):
                _vectorStoreIdsToDelete.Add(id);
                break;
            case nameof(CreateBatchOperation):
                _batchIdsToDelete.Add(id);
                break;
            default:
                throw new NotImplementedException();
        }
    }

    protected void ValidateById<T>(string id, string parentId)
    {
        Assert.That(id, Is.Not.Null.Or.Empty);
        Assert.That(parentId, Is.Not.Null.Or.Empty);
        switch (typeof(T).Name)
        {
            case nameof(ThreadMessage):
                _threadIdsWithMessageIdsToDelete.Add((parentId, id));
                break;
            case nameof(VectorStoreFileAssociation):
                _vectorStoreFileAssociationsToRemove.Add((parentId, id));
                break;
            default:
                throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Performs basic, invariant validation of a target that was just instantiated from its corresponding origination
    /// mechanism. If applicable, the instance is recorded into the test run for cleanup of persistent resources.
    /// </summary>
    /// <typeparam name="T"> Instance type being validated. </typeparam>
    /// <param name="target"> The instance to validate. </param>
    /// <exception cref="NotImplementedException"> The provided instance type isn't supported. </exception>
    protected void Validate<T>(T target)
    {
        if (target is ThreadMessage message)
        {
            ValidateById<ThreadMessage>(message.Id, message.ThreadId);
        }
        else if (target is VectorStoreFileAssociation fileAssociation)
        {
            ValidateById<VectorStoreFileAssociation>(fileAssociation.VectorStoreId, fileAssociation.FileId);
        }
        else
        {
            ValidateById<T>(target switch
            {
                Assistant assistant => assistant.Id,
                AssistantThread thread => thread.Id,
                OpenAIFile file => file.Id,
                ThreadRun run => run.Id,
                VectorStore store => store.Id,
                CreateVectorStoreOperation op => op.VectorStoreId,
                CreateBatchOperation batchOperation => batchOperation.BatchId,
                _ => throw new NotImplementedException(),
            });
        }
    }

    [TearDown]
    protected void Cleanup()
    {
        AzureOpenAIClient topLevelCleanupClient = GetTestTopLevelClient(TestConfig.GetConfig<TClient>(), new()
        {
            ShouldOutputRequests = false,
            ShouldOutputResponses = false,
        });
        RequestOptions requestOptions = new() { ErrorOptions = ClientErrorBehaviors.NoThrow, };

        void WriteIfNotSuppressed(string message)
        {
            if (Environment.GetEnvironmentVariable("AOAI_SUPPRESS_TRAFFIC_DUMP") != "true")
            {
                Console.WriteLine(message);
            }
        }

        OpenAIFileClient fileClient = topLevelCleanupClient.GetOpenAIFileClient();
        foreach (string fileId in _fileIdsToDelete)
        {
            WriteIfNotSuppressed($"Cleanup: {fileId} -> {fileClient.DeleteFile(fileId, requestOptions)?.GetRawResponse().Status}");
        }
        _fileIdsToDelete.Clear();

        BatchClient batchClient = topLevelCleanupClient.GetBatchClient();
        foreach (string batchId in _batchIdsToDelete)
        {
            // No delete currently exists
        }

#if !AZURE_OPENAI_GA
        AssistantClient client = topLevelCleanupClient.GetAssistantClient();
        VectorStoreClient vectorStoreClient = topLevelCleanupClient.GetVectorStoreClient();
        foreach ((string threadId, string messageId) in _threadIdsWithMessageIdsToDelete)
        {
            WriteIfNotSuppressed($"Cleanup: {messageId} -> {client.DeleteMessage(threadId, messageId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string assistantId in _assistantIdsToDelete)
        {
            WriteIfNotSuppressed($"Cleanup: {assistantId} -> {client.DeleteAssistant(assistantId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string threadId in _threadIdsToDelete)
        {
            WriteIfNotSuppressed($"Cleanup: {threadId} -> {client.DeleteThread(threadId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach ((string vectorStoreId, string fileId) in _vectorStoreFileAssociationsToRemove)
        {
            WriteIfNotSuppressed($"Cleanup: {vectorStoreId}<->{fileId} => {vectorStoreClient.RemoveFileFromStore(vectorStoreId, fileId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string vectorStoreId in _vectorStoreIdsToDelete)
        {
            WriteIfNotSuppressed($"Cleanup: {vectorStoreId} => {vectorStoreClient.DeleteVectorStore(vectorStoreId, requestOptions)?.GetRawResponse().Status}");
        }
        _threadIdsWithMessageIdsToDelete.Clear();
        _assistantIdsToDelete.Clear();
        _threadIdsToDelete.Clear();
        _vectorStoreFileAssociationsToRemove.Clear();
        _vectorStoreIdsToDelete.Clear();
#endif

        // If we are in recording mode, update the recorded playback configuration as well
        if (Mode == RecordedTestMode.Record
            && TestContext.CurrentContext.Result.Outcome == ResultState.Success)
        {
            TestConfig.SavePlaybackConfig();
        }
    }

    protected static void ValidateClientResult(ClientResult result)
    {
        Assert.That(result, Is.Not.Null);
        Assert.That(result.GetRawResponse(), Is.Not.Null);
    }

    protected static PipelineResponse ValidateClientResultResponse(ClientResult result)
    {
        ValidateClientResult(result);

        PipelineResponse response = result.GetRawResponse();
        Assert.That(response.Status, Is.GreaterThanOrEqualTo(200).And.LessThan(300));
        Assert.That(response.Headers, Is.Not.Null);
        Assert.That(response.Headers.GetFirstOrDefault("Content-Type"), Does.StartWith("application/json"));
        Assert.That(response.Content, Is.Not.Null);

        return response;
    }

    protected virtual TModel ValidateAndParse<TModel>(ClientResult result) where TModel : IJsonModel<TModel>
    {
        var response = ValidateClientResultResponse(result);

        TModel? model = ModelReaderWriter.Read<TModel>(response.Content, ModelReaderWriterOptions.Json);
        Assert.That(model, Is.Not.Null);
        return model!;
    }

    protected virtual TModel ValidateAndParse<TModel>(ClientResult result, JsonSerializerOptions? options = null)
    {
        var response = ValidateClientResultResponse(result);

        using Stream stream = response.Content.ToStream();
        Assert.That(stream, Is.Not.Null);

        TModel? model = JsonSerializer.Deserialize<TModel>(stream, options ?? JsonOptions.OpenAIJsonOptions);
        Assert.That(model, Is.Not.Null);
        return model!;
    }

    internal class TopLevelInfo
    {
        //required public object Client { get; init; }
        required public AzureOpenAIClient TopLevelClient { get; init; }
        required public IConfiguration Config { get; init; }
    }

    private readonly List<string> _assistantIdsToDelete = [];
    private readonly List<string> _threadIdsToDelete = [];
    private readonly List<(string, string)> _threadIdsWithMessageIdsToDelete = [];
    private readonly List<string> _fileIdsToDelete = [];
    private readonly List<(string, string)> _vectorStoreFileAssociationsToRemove = [];
    private readonly List<string> _vectorStoreIdsToDelete = [];
    private readonly List<string> _batchIdsToDelete = [];
}

public class TestClientOptions : AzureOpenAIClientOptions
{
    public TestClientOptions() : base()
    { }

    public TestClientOptions(ServiceVersion version) : base(version)
    { }

    public bool ShouldOutputRequests { get; set; } = Environment.GetEnvironmentVariable("AOAI_SUPPRESS_TRAFFIC_DUMP") != "true";
    public bool ShouldOutputResponses { get; set; } = Environment.GetEnvironmentVariable("AOAI_SUPPRESS_TRAFFIC_DUMP") != "true";
    public bool DisableClientWrapping { get; set; }
}
