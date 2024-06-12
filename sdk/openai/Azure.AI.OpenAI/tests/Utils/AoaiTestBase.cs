// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Tests.Utils;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Castle.DynamicProxy;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Images;
using OpenAI.Tests;
using OpenAI.VectorStores;

namespace Azure.AI.OpenAI.Tests;

public class AoaiTestBase<TClient> : RecordedTestBase<AoaiTestEnvironment>
{
    internal TestConfig TestConfig { get; }
    internal Assets Assets { get; }

    // TODO FIXME: Until we figure out recording, force into live mode. This works around the really low (but badly implemented) timeouts
    //             that are enforced by the test framework
    protected AoaiTestBase(bool isAsync, RecordedTestMode? mode = RecordedTestMode.Live)
        : base(isAsync, mode)
    {
        TestConfig = new TestConfig();
        if (TestConfig.GetConfig("chat").Endpoint is null)
        {
            // TODO: as a temporary CI exclusion, make forced live tests inconclusive. Remove this for development and as soon as recording support is available.
            Assert.Inconclusive($"Tests are currently disabled via inconclusivity if both default and chat configuration settings are not available.");
        }
        Assets = new Assets(TestEnvironment);
    }

    internal AzureOpenAIClient GetTestTopLevelClient(string @override, TestClientOptions options = null)
        => GetExplicitTestTopLevelClient<TClient, ApiKeyCredential>(@override, options);
    internal AzureOpenAIClient GetTestTopLevelClient<TCredential>(string @override, TestClientOptions options = null)
        => GetExplicitTestTopLevelClient<TClient, TCredential>(@override, options);
    private AzureOpenAIClient GetExplicitTestTopLevelClient<TForExplicitClient,TCredential>(string @override, TestClientOptions options = null, bool honorParentClient = true)
    {
        // If the top-level client is being requested on behalf of another client (e.g. a file client for resources to
        // use with an assistant client), then we'll ensure we match the configuration of the dependent client to its
        // progenitor.
        if (honorParentClient && options?.ParentClientObject is not null)
        {
            return options.ParentClientObject switch
            {
                AssistantClient => GetExplicitTestTopLevelClient<AssistantClient, TCredential>(@override, options, false),
                BatchClient => GetExplicitTestTopLevelClient<BatchClient, TCredential>(@override, options, false),
                ChatClient => GetExplicitTestTopLevelClient<ChatClient, TCredential>(@override, options, false),
                EmbeddingClient => GetExplicitTestTopLevelClient<EmbeddingClient, TCredential>(@override, options, false),
                FileClient => GetExplicitTestTopLevelClient<FileClient, TCredential>(@override, options, false),
                FineTuningClient => GetExplicitTestTopLevelClient<FineTuningClient, TCredential>(@override, options, false),
                ImageClient => GetExplicitTestTopLevelClient<ImageClient, TCredential>(@override, options, false),
                VectorStoreClient => GetExplicitTestTopLevelClient<VectorStoreClient, TCredential>(@override, options, false),
                _ => throw new NotImplementedException()
            };
        }

        Uri endpoint = TestConfig.GetEndpointFor<TForExplicitClient>(@override);

        ApiKeyCredential apiKeyCredential = typeof(TCredential) == typeof(ApiKeyCredential)
            ? TestConfig.GetApiKeyFor<TForExplicitClient>(@override)
            : null;
        TokenCredential tokenCredential = typeof(TCredential) == typeof(TokenCredential)
            ? new DefaultAzureCredential()
            : null;

        options ??= new();
        Action<PipelineRequest> requestAction = options.ShouldOutputRequests ? DumpRequest : null;
        Action<PipelineResponse> responseAction = options.ShouldOutputResponses ? DumpResponse : null;
        options.AddPolicy(new TestPipelinePolicy(requestAction, responseAction), PipelinePosition.PerCall);

        AzureOpenAIClient client =
            typeof(TCredential) == typeof(ApiKeyCredential)
                ? new(endpoint, apiKeyCredential, options)
            : (typeof(TCredential) == typeof(TokenCredential))
                ? new(endpoint, tokenCredential, options)
            : throw new NotImplementedException();

        return client;
    }

    internal TClient GetTestClient(string overrideName, TestClientOptions options = null)
        => GetExplicitTestClient<TClient, ApiKeyCredential>(overrideName, options);
    internal TClient GetTestClient(TestClientOptions options = null)
        => GetExplicitTestClient<TClient, ApiKeyCredential>(null, options);
    internal TClient GetTestClient<TCredential>(TestClientOptions options = null)
        => GetExplicitTestClient<TClient, TCredential>(null, options);
    internal TChildClient GetChildTestClient<TChildClient>(TClient parentClient)
        => GetExplicitTestClient<TChildClient, ApiKeyCredential>(null, new() { ParentClientObject = parentClient });
    private TExplicitClient GetExplicitTestClient<TExplicitClient,TCredential>(string overrideName = null, TestClientOptions options = null)
    {
        AzureOpenAIClient topLevelClient = GetExplicitTestTopLevelClient<TExplicitClient,TCredential>(overrideName, options);
        string deploymentName = TestConfig.GetDeploymentNameFor<TExplicitClient>(overrideName);
        object clientObject = null;
        switch (typeof(TExplicitClient).Name)
        {
            case nameof(AssistantClient):
                clientObject = topLevelClient.GetAssistantClient();
                break;
            case nameof(AudioClient):
                clientObject = topLevelClient.GetAudioClient(deploymentName);
                break;
            case nameof(BatchClient):
                clientObject = topLevelClient.GetBatchClient(deploymentName);
                break;
            case nameof(ChatClient):
                clientObject = topLevelClient.GetChatClient(deploymentName);
                break;
            case nameof(EmbeddingClient):
                clientObject = topLevelClient.GetEmbeddingClient(deploymentName);
                break;
            case nameof(FileClient):
                clientObject = topLevelClient.GetFileClient();
                break;
            case nameof(FineTuningClient):
                clientObject = topLevelClient.GetFineTuningClient();
                break;
            case nameof(ImageClient):
                clientObject = topLevelClient.GetImageClient(deploymentName);
                break;
            case nameof(VectorStoreClient):
                clientObject = topLevelClient.GetVectorStoreClient();
                break;
            default: throw new NotImplementedException($"Test client helpers not yet implemented for {typeof(TExplicitClient)}");
        };

        var instrumented = InstrumentClient(typeof(TExplicitClient), clientObject, null);
        return (TExplicitClient)instrumented;
    }

    private static void DumpRequest(PipelineRequest request)
    {
        Console.WriteLine($"--- New request ---");
        string headers = request.Headers?
            .Select(header => $"{header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}")
            .Aggregate(string.Empty, (current, next) => string.Format("{0},{1}", current, next));
        Console.WriteLine($"Headers: {headers}");
        Console.WriteLine($"{request.Method} URI: {request?.Uri}");
        if (request.Content is not null)
        {
            using MemoryStream stream = new();
            request.Content.WriteTo(stream, default);
            stream.Position = 0;
            using StreamReader reader = new(stream);
            Console.WriteLine(reader.ReadToEnd());
        }
    }

    private static void DumpResponse(PipelineResponse response)
    {
        Console.WriteLine($"--- Response --- <dump not yet implemented>");
    }

    protected void ValidateById<T>(string id)
    {
        Assert.That(id, Is.Not.Null.Or.Empty);
        switch (typeof(T).Name)
        {
            case nameof(Assistant): _assistantIdsToDelete.Add(id); break;
            case nameof(AssistantThread): _threadIdsToDelete.Add(id); break;
            case nameof(OpenAIFileInfo): _fileIdsToDelete.Add(id); break;
            case nameof(ThreadRun): break;
            case nameof(VectorStore): _vectorStoreIdsToDelete.Add(id); break;
            default: throw new NotImplementedException();
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
                OpenAIFileInfo file => file.Id,
                ThreadRun run => run.Id,
                VectorStore store => store.Id,
                _ => throw new NotImplementedException(),
            });
        }
    }

    [TearDown]
    protected void Cleanup()
    {
        AzureOpenAIClient topLevelCleanupClient = GetTestTopLevelClient(null, new()
        {
            ShouldOutputRequests = false,
            ShouldOutputResponses = false,
        });
        AssistantClient client = topLevelCleanupClient.GetAssistantClient();
        VectorStoreClient vectorStoreClient = topLevelCleanupClient.GetVectorStoreClient();
        FileClient fileClient = topLevelCleanupClient.GetFileClient();
        RequestOptions requestOptions = new() { ErrorOptions = ClientErrorBehaviors.NoThrow, };
        foreach ((string threadId, string messageId) in _threadIdsWithMessageIdsToDelete)
        {
            Console.WriteLine($"Cleanup: {messageId} -> {client.DeleteMessage(threadId, messageId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string assistantId in _assistantIdsToDelete)
        {
            Console.WriteLine($"Cleanup: {assistantId} -> {client.DeleteAssistant(assistantId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string threadId in _threadIdsToDelete)
        {
            Console.WriteLine($"Cleanup: {threadId} -> {client.DeleteThread(threadId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach ((string vectorStoreId, string fileId) in _vectorStoreFileAssociationsToRemove)
        {
            Console.WriteLine($"Cleanup: {vectorStoreId}<->{fileId} => {vectorStoreClient.RemoveFileFromStore(vectorStoreId, fileId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string vectorStoreId in _vectorStoreIdsToDelete)
        {
            Console.WriteLine($"Cleanup: {vectorStoreId} => {vectorStoreClient.DeleteVectorStore(vectorStoreId, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string fileId in _fileIdsToDelete)
        {
            Console.WriteLine($"Cleanup: {fileId} -> {fileClient.DeleteFile(fileId, requestOptions)?.GetRawResponse().Status}");
        }
        _threadIdsWithMessageIdsToDelete.Clear();
        _assistantIdsToDelete.Clear();
        _threadIdsToDelete.Clear();
        _vectorStoreFileAssociationsToRemove.Clear();
        _vectorStoreIdsToDelete.Clear();
        _fileIdsToDelete.Clear();
    }

    protected override object InstrumentClient(Type clientType, object client, IEnumerable<IInterceptor> preInterceptors)
    {
        // TODO FIXME For now this is a super simplified version of the base ClientTestBase.InstrumentClient method
        // with just the bare minimum need to be able to test async and sync versions of methods
        if (client is IProxyTargetAccessor)
        {
            // Already instrumented
            return client;
        }

        List<IInterceptor> interceptors = new List<IInterceptor>();
        if (preInterceptors != null)
        {
            interceptors.AddRange(preInterceptors);
        }

        interceptors.Add(new OriginalInterceptor(client));
        interceptors.Add(new UseSyncMethodsInterceptor(!IsAsync));

        return ProxyGenerator.CreateClassProxyWithTarget(
            clientType,
            [ typeof(IInstrumented) ],
            client,
            interceptors.ToArray());
    }

    protected virtual T Uninstrument<T>(T instrumented)
    {
        if (instrumented is IInstrumented wrapped)
        {
            return (T)wrapped.Original;
        }

        return instrumented;
    }

    protected AsyncResultCollection<T> SyncOrAsync<T>(TClient client, Func<TClient, ResultCollection<T>> sync, Func<TClient, AsyncResultCollection<T>> async)
    {
        // TODO FIXME HACK Since the test framework doesn't currently support async result collection, this methods provides
        //                 a simplified way to make explicit calls to the right methods in tests
        TClient rawClient = Uninstrument(client);

        if (IsAsync)
        {
            return async(rawClient);
        }
        else
        {
            ResultCollection<T> syncCollection = sync(rawClient);
            return new SyncToAsyncResultCollection<T>(syncCollection);
        }
    }

    protected AsyncPageableCollection<T> SyncOrAsync<T>(TClient client, Func<TClient, PageableCollection<T>> sync, Func<TClient, AsyncPageableCollection<T>> async)
    {
        // TODO FIXME HACK Since the test framework doesn't currently support async result collection, this methods provides
        //                 a simplified way to make explicit calls to the right methods in tests
        TClient rawClient = Uninstrument(client);

        if (IsAsync)
        {
            return async(rawClient);
        }
        else
        {
            PageableCollection<T> syncCollection = sync(rawClient);
            return new SyncToAsyncPageableCollection<T>(syncCollection);
        }
    }

    protected Task<List<T>> SyncOrAsyncList<T>(TClient client, Func<TClient, PageableCollection<T>> sync, Func<TClient, AsyncPageableCollection<T>> async)
    {
        // TODO FIXME HACK Since the test framework doesn't currently support async result collection, this methods provides
        //                 a simplified way to make explicit calls to the right methods in tests
        TClient rawClient = Uninstrument(client);

        if (IsAsync)
        {
            return async(rawClient).ToEnumerableAsync();
        }
        else
        {
            return Task.FromResult(sync(rawClient).ToList());
        }
    }

    // TODO FIXME: For some bizarre reason, InternalVisibleTo on the Azure core test framework library
    // decided it doesn't want to work for the original internal only IInstrumented. This is a duplicate
    // of that interface that is public to avoid headaches
    public interface IInstrumented
    {
        public object Original { get; }
    }

    // TODO FIXME: As per the previous interface, this is a public version to avoid headaches
    public class OriginalInterceptor : IInterceptor
    {
        private readonly object _original;

        public OriginalInterceptor(object original)
        {
            _original = original;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.DeclaringType == typeof(IInstrumented))
            {
                invocation.ReturnValue = _original;
            }
            else
            {
                invocation.Proceed();
            }
        }
    }

    private readonly List<string> _assistantIdsToDelete = [];
    private readonly List<string> _threadIdsToDelete = [];
    private readonly List<(string, string)> _threadIdsWithMessageIdsToDelete = [];
    private readonly List<string> _fileIdsToDelete = [];
    private readonly List<(string, string)> _vectorStoreFileAssociationsToRemove = [];
    private readonly List<string> _vectorStoreIdsToDelete = [];

}

internal class TestClientOptions : AzureOpenAIClientOptions
{
    public TestClientOptions() : base()
    { }

    public TestClientOptions(ServiceVersion version) : base(version)
    { }

    public bool ShouldOutputRequests { get; set; } = true;
    public bool ShouldOutputResponses { get; set; } = true;
    public object ParentClientObject { get; set; }
}
