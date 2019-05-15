// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.Common
{
    static class NodeList
    {
        public static NodeList<T> Create<T>(T value) => new NodeList<T>(value);
    }

    sealed class NodeList<T> : IEnumerable<T>
    {
        public readonly NodeList<T> First;
        public readonly NodeList<T> Head;
        public readonly T Value;

        public readonly int Count;

        public NodeList(T value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value));
            }

            this.First = default;
            this.Head = default;
            this.Value = value;
            this.Count = 1;
        }

        NodeList()
        {
            this.First = default;
            this.Head = default;
            this.Value = default;
            this.Count = 0;
        }

        NodeList(NodeList<T> first, NodeList<T> head, T value)
        {
            this.First = first;
            this.Head = head;
            this.Value = value;
            this.Count = head.Count + 1;
        }

        public static NodeList<T> Empty => new NodeList<T>();

        public NodeList<T> Append(T value)
            =>
            value == default
            ? throw new ArgumentNullException(nameof(value))
            : this.Count == 0
            ? new NodeList<T>(value)
            : new NodeList<T>(this.First ?? this, this, value)
            ;

        public NodeList<T> Append(NodeList<T> list)
        {
            var result = this;

            foreach (var item in list)
            {
                result = result.Append(item);
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator() => this.GetValues().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        IEnumerable<T> GetValues()
        {
            if (this.Head != default)
            {
                foreach (var item in this.Head)
                {
                    yield return item;
                }
            }

            yield return this.Value;
        }
    }

    internal struct StorageTaskState<TResult>
    {
        // batch support

        public HttpPipeline Pipeline { get; }
        public Func<HttpPipeline, CancellationToken, Task<TResult>> Operation { get; }
        public CancellationToken CancellationToken { get; }

        // reliable operation support
        public ReliabilityConfiguration ReliabilityConfiguration { get; }
        
        internal StorageTaskState(HttpPipeline pipeline, Func<HttpPipeline, CancellationToken, Task<TResult>> operation, CancellationToken cancellationToken, ReliabilityConfiguration? reliabilityConfiguration = default)
        {
            this.Pipeline = pipeline;
            this.Operation = operation;
            this.CancellationToken = cancellationToken;

            this.ReliabilityConfiguration = reliabilityConfiguration ?? ReliabilityConfiguration.Default;
        }

        internal Task<TResult> InvokeAsync(HttpPipeline pipeline = default, CancellationToken? cancellationToken = default)
            =>
            this.Operation(
                pipeline ?? this.Pipeline,
                cancellationToken ?? this.CancellationToken
                );
    }
/*
    internal struct StorageTaskCollectionState<TResult>
        where TResult: IBatchable
    {
        public NodeList<StorageTask<TResult>> Tasks { get; }
        public ReliabilityConfiguration ReliabilityConfiguration
            => this.Tasks.FirstOrDefault().StorageTaskState.ReliabilityConfiguration;

        StorageTaskCollectionState(NodeList<StorageTask<TResult>> tasks)
            => this.Tasks = tasks;

        internal Task<TResult[]> InvokeAsync()
            => BatchExtensions.DoBatch(this.Tasks.Select(t => t.StorageTaskState).ToArray());

        public StorageTaskCollectionState(StorageTask<TResult> t0, StorageTask<TResult> t1)
            : this(NodeList.Create(t0).Append(t1))
        {

        }

        public StorageTaskCollectionState(StorageTask<TResult> t0, NodeList<StorageTask<TResult>> t1)
            : this(NodeList.Create(t0).Append(t1))
        {

        }

        public StorageTaskCollectionState(NodeList<StorageTask<TResult>> t0, StorageTask<TResult> t1)
            : this(t0.Append(t1))
        {

        }

        public StorageTaskCollectionState(NodeList<StorageTask<TResult>> t0, NodeList<StorageTask<TResult>> t1)
            : this(t0.Append(t1))
        {

        }
    }
*/
    internal static class StorageTask
    {
        public static StorageTask<TResult> Create<TResult>(HttpPipeline pipeline, Func<HttpPipeline, CancellationToken, Task<TResult>> operation, CancellationToken cancellationToken, ReliabilityConfiguration? reliabilityConfiguration = default) 
            => new StorageTask<TResult>(pipeline, operation, cancellationToken, reliabilityConfiguration);
    }

    public struct StorageTask<TResult> : IEquatable<StorageTask<TResult>>
    {
        internal StorageTaskState<TResult> StorageTaskState;

        internal StorageTask(StorageTaskState<TResult> state) => this.StorageTaskState = state;

        internal StorageTask(HttpPipeline pipeline, Func<HttpPipeline, CancellationToken, Task<TResult>> operation, CancellationToken cancellationToken, ReliabilityConfiguration? reliabilityConfiguration = default)
            : this(new StorageTaskState<TResult>(pipeline, operation, cancellationToken, reliabilityConfiguration))
        {

        }

        public TaskAwaiter<TResult> GetAwaiter() => this.WithRetry().GetAwaiter();

        public override bool Equals(object obj)
            => obj is StorageTask<TResult> other && this.Equals(other);

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(StorageTask<TResult> left, StorageTask<TResult> right)
            => left.Equals(right);

        public static bool operator !=(StorageTask<TResult> left, StorageTask<TResult> right) 
            => !(left == right);

        public bool Equals(StorageTask<TResult> other)
            => base.Equals(other);
    }
/*
    public struct StorageTaskCollection<TResult> : IEquatable<StorageTaskCollection<TResult>> where TResult : IBatchable
    {
        internal StorageTaskCollectionState<TResult> StorageTaskState;

        internal StorageTaskCollection(StorageTaskCollectionState<TResult> state)
            => this.StorageTaskState = state;

        public TaskAwaiter<TResult[]> GetAwaiter() => this.WithRetry().GetAwaiter();

        public override bool Equals(object obj)
            => obj is StorageTaskCollection<TResult> other && this.Equals(other);

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(StorageTaskCollection<TResult> left, StorageTaskCollection<TResult> right)
            => left.Equals(right);

        public static bool operator !=(StorageTaskCollection<TResult> left, StorageTaskCollection<TResult> right)
            => !(left == right);

        public bool Equals(StorageTaskCollection<TResult> other)
            => base.Equals(other);
    }
    
    public static class StorageTaskCollectionExtensions
    {
        public static StorageTaskCollection<TResult> And<TResult>(this StorageTask<TResult> t0, StorageTask<TResult> t1)
            where TResult : IBatchable
            => new StorageTaskCollection<TResult>(new StorageTaskCollectionState<TResult>(t0, t1));

        public static StorageTaskCollection<TResult> And<TResult>(this StorageTask<TResult> t0, StorageTaskCollection<TResult> t1)
            where TResult : IBatchable
            => new StorageTaskCollection<TResult>(new StorageTaskCollectionState<TResult>(t0, t1.StorageTaskState.Tasks));

        public static StorageTaskCollection<TResult> And<TResult>(this StorageTaskCollection<TResult> t0, StorageTask<TResult> t1)
            where TResult : IBatchable
            => new StorageTaskCollection<TResult>(new StorageTaskCollectionState<TResult>(t0.StorageTaskState.Tasks, t1));

        public static StorageTaskCollection<TResult> And<TResult>(this StorageTaskCollection<TResult> t0, StorageTaskCollection<TResult> t1)
            where TResult : IBatchable
            => new StorageTaskCollection<TResult>(new StorageTaskCollectionState<TResult>(t0.StorageTaskState.Tasks, t1.StorageTaskState.Tasks));
    }
*/
    struct ReliabilityConfiguration
    {
        public static ReliabilityConfiguration Default = new ReliabilityConfiguration(default, default, default);

        public Action Reset { get; }
        public Action Cleanup { get; }
        public Func<Exception, bool> ExceptionPredicate { get; }

        public ReliabilityConfiguration(Action reset = default, Action cleanup = default, Func<Exception, bool> exceptionPredicate = default)
        {
            this.Reset = reset ?? NoOp;
            this.Cleanup = cleanup ?? NoOp;
            this.ExceptionPredicate = exceptionPredicate ?? AllExceptions;
        }

        static Action NoOp => () => { };
        static Func<Exception, bool> AllExceptions => e => true;
    }

    static class RetryExtensions
    {
        public static Task<TResult> WithRetry<TResult>(this StorageTask<TResult> task, int maximumRetries = Constants.MaxReliabilityRetries)
            => ReliableOperation.DoAsync(
                operation: () => task.StorageTaskState.InvokeAsync(),
                reliabilityConfiguration: task.StorageTaskState.ReliabilityConfiguration,
                maximumRetries: maximumRetries
                );
        /*
        public static Task<TResult[]> WithRetry<TResult>(this StorageTaskCollection<TResult> task, int maximumRetries = Constants.MaxReliabilityRetries)
            where TResult: IBatchable
            => ReliableOperation.DoAsync(
                operation: () => task.StorageTaskState.InvokeAsync(),
                reliabilityConfiguration: task.StorageTaskState.ReliabilityConfiguration,
                maximumRetries: maximumRetries
                );
        */
    }
/*
    static class BatchExtensions
    {
        public static Task<TResult[]> DoBatch<TResult>(StorageTaskState<TResult>[] states) where TResult: IBatchable
        {
            var pipeline = states[0].Pipeline;

            if (!states.All(s => s.Pipeline == pipeline))
            {
                throw new InvalidOperationException("Cannot create batch over operations using different pipelines.");
            }

            var cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(states.Select(s => s.CancellationToken).ToArray()).Token;

            var requestMap = new Dictionary<HttpRequestMessage, TaskCompletionSource<HttpResponseMessage>>();

            var batchPipeline =
                new Pipeline(
                    new PipelineOptions
                    {
                        HttpSender = new BatchPolicyFactory(requestMap),
                        Logger = pipeline.Logger
                    },
                    pipeline.m_factories
                    );

            // run all operations against the batch pipeline to record messages and force them to wait for completion, which will happen in the next step
            var ts =
                states
                .Select(s => s.InvokeAsync(batchPipeline, cancellationToken))
                .ToArray();

            // make actual network call, which will assign results and trigger completion of tasks
            DoBatchRequestOnCallerPipeline(pipeline, requestMap, cancellationToken);

            // return the set of tasks
            return Task.WhenAll(ts);
        }

        static async void DoBatchRequestOnCallerPipeline(Pipeline pipeline, IDictionary<HttpRequestMessage, TaskCompletionSource<HttpResponseMessage>> requestMap, CancellationToken cancellationToken)
        {
            var requests = requestMap.Keys.ToList();

            var batchRequest = CreateBatchRequest(pipeline, requests);

            var batchResponse = await pipeline.SendAsync(batchRequest, cancellationToken, default).ConfigureAwait(false);

            if (batchResponse.StatusCode == HttpStatusCode.Accepted)
            {
                var parsedResponses = ParseBatchResponse(batchResponse);

                var requestEnumerator = requests.GetEnumerator();
                var responseEnumerator = (await parsedResponses.ConfigureAwait(false)).GetEnumerator();

                while (requestEnumerator.MoveNext() && responseEnumerator.MoveNext())
                {
                    var request = requestEnumerator.Current;
                    var response = responseEnumerator.Current;

                    response.RequestMessage = request;

                    requestMap[request].SetResult(response);
                }
            }
            else
            {
                // TODO handle exceptions

                //var text = await batchResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                //var xml = XElement.Parse(text);

                //var errorCode = xml.Element("Code").Value;
                //var errorMessage = xml.Element("Message").Value;

                //var exception = new StorageErrorException(errorMessage, errorCode, batchResponse);

                foreach (var task in requestMap.Values)
                {
                    //task.SetException(exception);
                    task.SetResult(batchResponse);
                }
            }
        }
        
        class BatchStreamProvider : MultipartMemoryStreamProvider
        {
            public override async Task ExecutePostProcessingAsync()
            {
                for (var i = 0; i < this.Contents.Count; i++)
                {
                    var content = this.Contents[i];

                    // HACK to append \r\n to end of stream so ReadAsHttpResponseMessageAsync can parse it
                    // TODO We can't get to the underlying stream, even though it's writeable.  Wrap the stream and append if we want to avoid the copy.

                    var modifiedStream = new MemoryStream();
                    await content.CopyToAsync(modifiedStream).ConfigureAwait(false);

                    var writer = new StreamWriter(modifiedStream);
                    writer.WriteLine();
                    writer.Flush();
                    modifiedStream.Position = 0;

                    var modifiedContent = new StreamContent(modifiedStream);

                    // HACK to set content type to include msgtype=response

                    modifiedContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/http; msgtype=response");

                    this.Contents[i] = modifiedContent;
                }
            }
        }

        static async Task<IEnumerable<HttpResponseMessage>> ParseBatchResponse(HttpResponseMessage response)
        {
            var multipartContent = await response.Content.ReadAsMultipartAsync(new BatchStreamProvider()).ConfigureAwait(false);
            return CreateBatchSubresponse(response, multipartContent.Contents);
        }

        static IEnumerable<HttpResponseMessage> CreateBatchSubresponse(HttpResponseMessage response, IEnumerable<HttpContent> contents)
        {
            foreach (var content in contents)
            {
                var result = content.ReadAsHttpResponseMessageAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                foreach (var header in response.Headers)
                {
                    result.Headers.Add(header.Key, header.Value);
                }

                foreach (var header in content.Headers.Where(IsNotContentHeader))
                {
                    result.Headers.Add(header.Key, header.Value);
                }

                result.Content = content;

                yield return result;
            }
        }

        private static bool IsNotContentHeader(KeyValuePair<string, IEnumerable<string>> arg)
            => arg.Key != "Content-Length"
            && arg.Key != "Content-Type"
            ;

        static HttpRequestMessage CreateBatchRequest(Pipeline pipeline, IEnumerable<HttpRequestMessage> requests)
        {
            var builder =
                new UriBuilder(requests.First().RequestUri)
                {
                    Path = default,
                    Query = "comp=batch"
                };

            var boundary = StringExtensions.Invariant($"batch_{Guid.NewGuid()}");

            var result = new HttpRequestMessage(HttpMethod.Post, builder.Uri);
            var multipartContent = new MultipartContent("mixed", boundary);
            result.Headers.Add("x-ms-version", "2018-11-09"); // TODO Use real service client version 
            multipartContent.Headers.ContentType = MediaTypeHeaderValue.Parse(
                StringExtensions.Invariant($"multipart/mixed; boundary={boundary}"));
            var id = 0;

            foreach (var request in requests)
            {
                request.Headers.Remove("x-ms-version");
                request.Headers.UserAgent.Clear();

                switch (request.Headers.Authorization.Scheme)
                {
                    case "SharedKey":
                        var policy = pipeline.m_factories.OfType<SharedKeyCredential>().Single();
                        policy.AddAuthorizationHeader(request, includeXmsDate: true);
                        break;
                    default:
                        break;
                }

                var sb = new StringBuilder();
                sb.AppendLine(StringExtensions.Invariant($"{request.Method} {request.RequestUri.PathAndQuery} HTTP/1.1"));

                sb.Append(request.Headers.ToString());

                var content = new StringContent(sb.ToString());
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/http");
                content.Headers.TryAddWithoutValidation("Content-Transfer-Encoding", "binary");
                content.Headers.TryAddWithoutValidation("Content-ID", id++.ToString(CultureInfo.InvariantCulture));

                multipartContent.Add(content);
            }

            result.Content = multipartContent;

            return result;
        }
    }

    class BatchPolicyFactory : IPipelinePolicyFactory
    {
        readonly IDictionary<HttpRequestMessage, TaskCompletionSource<HttpResponseMessage>> requestMap;

        public BatchPolicyFactory(IDictionary<HttpRequestMessage, TaskCompletionSource<HttpResponseMessage>> requestMap) 
            => this.requestMap = requestMap;

        public IPipelinePolicy Create(IPipelinePolicy nextPolicy, PipelinePolicyOptions options) => new BatchPipelinePolicy(this.requestMap, options);

        class BatchPipelinePolicy : IPipelinePolicy
        {
            readonly PipelinePolicyOptions options;
            readonly IDictionary<HttpRequestMessage, TaskCompletionSource<HttpResponseMessage>> requestMap;

            public BatchPipelinePolicy(IDictionary<HttpRequestMessage, TaskCompletionSource<HttpResponseMessage>> requestMap, PipelinePolicyOptions options)
            {
                this.requestMap = requestMap;
                this.options = options;
            }

            public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                using (this.options.Logger.BeginScope(this))
                {
                    this.options.Logger.LogTrace("BATCHING REQUEST to {0}\n{1}", request.RequestUri, request);

                    var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();

                    this.requestMap.Add(request, taskCompletionSource);

                    return taskCompletionSource.Task;
                }
            }
        }
    }
    
#pragma warning disable CA1040 // empty interfaces

    public interface IBatchable { }

    public interface IRetryable { }

#pragma warning restore CA1040
*/
}
