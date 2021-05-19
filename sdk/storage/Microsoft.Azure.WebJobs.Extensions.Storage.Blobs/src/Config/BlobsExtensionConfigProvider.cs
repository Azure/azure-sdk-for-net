// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Triggers;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Config
{
    [Extension("AzureStorageBlobs", "Blobs")]
    internal class BlobsExtensionConfigProvider : IExtensionConfigProvider,
        IConverter<BlobAttribute, BlobContainerClient>,
        IConverter<BlobAttribute, BlobsExtensionConfigProvider.MultiBlobContext>,
        IAsyncConverter<HttpRequestMessage, HttpResponseMessage>,
        IDisposable
    {
        private readonly BlobTriggerAttributeBindingProvider _triggerBinder;
        private BlobServiceClientProvider _blobServiceClientProvider;
        private IContextGetter<IBlobWrittenWatcher> _blobWrittenWatcherGetter;
        private readonly INameResolver _nameResolver;
        private IConverterManager _converterManager;
        private readonly BlobTriggerQueueWriterFactory _blobTriggerQueueWriterFactory;
        private readonly ILogger _logger;
        private BlobTriggerQueueWriter _blobTriggerQueueWriter;
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
        private readonly HttpRequestProcessor _httpRequestProcessor;

        public BlobsExtensionConfigProvider(
            BlobServiceClientProvider blobServiceClientProvider,
            BlobTriggerAttributeBindingProvider triggerBinder,
            IContextGetter<IBlobWrittenWatcher> contextAccessor,
            INameResolver nameResolver,
            IConverterManager converterManager,
            BlobTriggerQueueWriterFactory blobTriggerQueueWriterFactory,
            HttpRequestProcessor httpRequestProcessor,
            ILoggerFactory loggerFactory)
        {
            _blobServiceClientProvider = blobServiceClientProvider;
            _triggerBinder = triggerBinder;
            _blobWrittenWatcherGetter = contextAccessor;
            _nameResolver = nameResolver;
            _converterManager = converterManager;
            _blobTriggerQueueWriterFactory = blobTriggerQueueWriterFactory;
            _httpRequestProcessor = httpRequestProcessor;
            _logger = loggerFactory.CreateLogger<BlobsExtensionConfigProvider>();
        }

        public void Initialize(ExtensionConfigContext context)
        {
            InitilizeBlobBindings(context);
            InitializeBlobTriggerBindings(context);
        }

        private void InitilizeBlobBindings(ExtensionConfigContext context)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Uri url = context.GetWebhookHandler();
#pragma warning restore CS0618 // Type or member is obsolete
            _logger.LogInformation($"registered http endpoint = {url?.GetLeftPart(UriPartial.Path)}");

            var rule = context.AddBindingRule<BlobAttribute>();

            // Bind to multiple blobs (either via a container; an IEnumerable<T>)
            rule.BindToInput<BlobContainerClient>(this);

            rule.BindToInput<MultiBlobContext>(this); // Intermediate private context to capture state
            rule.AddOpenConverter<MultiBlobContext, IEnumerable<BlobCollectionType>>(typeof(BlobCollectionConverter<>), this);

            // BindToStream will also handle the custom Stream-->T converters.
            rule.BindToStream(CreateStreamAsync, FileAccess.ReadWrite); // Precedence, must beat CloudBlobStream

            // Normal blob
            // These are not converters because Blob/Page/Append affects how we *create* the blob.
            rule.BindToInput<BlockBlobClient>((attr, cts) => CreateBlobReference<BlockBlobClient>(attr, cts));
            rule.BindToInput<PageBlobClient>((attr, cts) => CreateBlobReference<PageBlobClient>(attr, cts));
            rule.BindToInput<AppendBlobClient>((attr, cts) => CreateBlobReference<AppendBlobClient>(attr, cts));
            rule.BindToInput<BlobClient>((attr, cts) => CreateBlobReference<BlobClient>(attr, cts));
            rule.BindToInput<BlobBaseClient>((attr, cts) => CreateBlobReference<BlobBaseClient>(attr, cts));

            // CloudBlobStream's derived functionality is only relevant to writing. check derived functionality
            rule.When("Access", FileAccess.Write).
                BindToInput<Stream>(ConvertToCloudBlobStreamAsync);

            RegisterCommonConverters(rule);
            rule.AddConverter(new StorageBlobConverter<BlobClient>());
        }

        private void InitializeBlobTriggerBindings(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<BlobTriggerAttribute>();
            rule.BindToTrigger<BlobBaseClient>(_triggerBinder);

            rule.AddConverter<BlobBaseClient, DirectInvokeString>(blob => new DirectInvokeString(blob.GetBlobPath()));
            rule.AddConverter<DirectInvokeString, BlobBaseClient>(ConvertFromInvokeString);

            RegisterCommonConverters(rule);
            rule.AddConverter<BlobBaseClient, BlobClient>(ConvertBlobBaseClientToBlobClient);
        }

#pragma warning disable CS0618 // Type or member is obsolete. FluentBindingRule is "Not ready for public consumption."
        private void RegisterCommonConverters<T>(FluentBindingRule<T> rule) where T : Attribute
#pragma warning restore CS0618 // Type or member is obsolete
        {
            //  Converter manager already has Stream-->Byte[],String,TextReader
            rule.AddConverter<BlobBaseClient, Stream>(ConvertToStreamAsync);
            // Blob type is a property of an existing blob.
            rule.AddConverter(new StorageBlobConverter<AppendBlobClient>());
            rule.AddConverter(new StorageBlobConverter<BlockBlobClient>());
            rule.AddConverter(new StorageBlobConverter<PageBlobClient>());
        }

        #region Container rules
        BlobContainerClient IConverter<BlobAttribute, BlobContainerClient>.Convert(
            BlobAttribute blobAttribute)
        {
            return GetContainer(blobAttribute);
        }

        public async Task<HttpResponseMessage> ConvertAsync(HttpRequestMessage input, CancellationToken cancellationToken)
        {
            var functionName = HttpUtility.ParseQueryString(input.RequestUri.Query)["functionName"];
            // Potential race condition, initialize _blobTriggerQueueWriter once.
            if (_blobTriggerQueueWriter == null)
            {
                await _semaphoreSlim.WaitAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    if (_blobTriggerQueueWriter == null)
                    {
                        _blobTriggerQueueWriter = await _blobTriggerQueueWriterFactory.CreateAsync(cancellationToken).ConfigureAwait(false);
                    }
                }
                finally
                {
                    _semaphoreSlim.Release();
                }
            }

            string content = await input.Content.ReadAsStringAsync().ConfigureAwait(false);
            var headers = input.Headers;

            return await _httpRequestProcessor.ProcessAsync(input, functionName, ProcessEventsAsync, cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region CloudBlob rules

        // Produce a write only stream.
        private async Task<Stream> ConvertToCloudBlobStreamAsync(
           BlobAttribute blobAttribute, ValueBindingContext context)
        {
            var stream = await CreateStreamAsync(blobAttribute, context).ConfigureAwait(false);
            return stream;
        }

        private async Task<T> CreateBlobReference<T>(BlobAttribute blobAttribute, CancellationToken cancellationToken) where T : BlobBaseClient
        {
            var blob = await GetBlobAsync(blobAttribute, cancellationToken, typeof(T)).ConfigureAwait(false);
            return (T)blob.BlobClient;
        }

        #endregion

        public void Dispose()
        {
            _semaphoreSlim.Dispose();
        }

        #region Support for binding to Multiple blobs
        // Open type matching types that can bind to an IEnumerable<T> blob collection.
        private class BlobCollectionType : OpenType
        {
            private static readonly Type[] _types = new Type[]
            {
                typeof(BlobBaseClient),
                typeof(BlobClient),
                typeof(BlockBlobClient),
                typeof(PageBlobClient),
                typeof(AppendBlobClient),
                typeof(TextReader),
                typeof(Stream),
                typeof(string)
            };

            public override bool IsMatch(Type type, OpenTypeMatchContext ctx)
            {
                bool match = _types.Contains(type);
                return match;
            }
        }

        // Converter to produce an IEnumerable<T> for binding to multiple blobs.
        // T must have been matched by MultiBlobType
        private class BlobCollectionConverter<T> : IAsyncConverter<MultiBlobContext, IEnumerable<T>>
        {
            private readonly FuncAsyncConverter<BlobBaseClient, T> _converter;

            public BlobCollectionConverter(BlobsExtensionConfigProvider parent)
            {
                IConverterManager cm = parent._converterManager;
                _converter = cm.GetConverter<BlobBaseClient, T, BlobAttribute>();
                if (_converter == null)
                {
                    throw new InvalidOperationException($"Can't convert blob to {typeof(T).FullName}.");
                }
            }

            public async Task<IEnumerable<T>> ConvertAsync(MultiBlobContext context, CancellationToken cancellationToken)
            {
                // Query the blob container using the blob prefix (if specified)
                // Note that we're explicitly using useFlatBlobListing=true to collapse
                // sub directories.
                string prefix = context.Prefix;
                var container = context.Container;
                IAsyncEnumerable<BlobItem> blobItems = container.GetBlobsAsync(prefix: prefix, cancellationToken: cancellationToken);

                // create an IEnumerable<T> of the correct type, performing any required conversions on the blobs
                var list = await ConvertBlobs(blobItems, container).ConfigureAwait(false);
                return list;
            }

            private async Task<IEnumerable<T>> ConvertBlobs(IAsyncEnumerable<BlobItem> blobItems, BlobContainerClient blobContainerClient)
            {
                var list = new List<T>();

                await foreach (var blobItem in blobItems.ConfigureAwait(false))
                {
                    BlobBaseClient src = null;
                    switch (blobItem.Properties.BlobType)
                    {
                        case BlobType.Block:
                            if (typeof(T) == typeof(BlobClient))
                            {
                                // BlobClient is simplified version of BlockBlobClient, i.e. upload results in creation of block blob.
                                src = blobContainerClient.GetBlobClient(blobItem.Name);
                            }
                            else
                            {
                                src = blobContainerClient.GetBlockBlobClient(blobItem.Name);
                            }
                            break;
                        case BlobType.Append:
                            src = blobContainerClient.GetAppendBlobClient(blobItem.Name);
                            break;
                        case BlobType.Page:
                            src = blobContainerClient.GetPageBlobClient(blobItem.Name);
                            break;
                        default:
                            throw new InvalidOperationException($"Unexpected blob type {blobItem.Properties.BlobType}");
                    }

                    var funcCtx = new FunctionBindingContext(Guid.Empty, CancellationToken.None);
                    var valueCtx = new ValueBindingContext(funcCtx, CancellationToken.None);

                    var converted = await _converter(src, null, valueCtx).ConfigureAwait(false);

                    list.Add(converted);
                }

                return list;
            }
        }

        // Internal context object to aide in binding to  multiple blobs.
        private class MultiBlobContext
        {
            public string Prefix;
            public BlobContainerClient Container;
        }

        // Initial rule that captures the muti-blob context.
        // Then a converter morphs this to the user type
        MultiBlobContext IConverter<BlobAttribute, MultiBlobContext>.Convert(BlobAttribute attr)
        {
            var path = BlobPath.ParseAndValidate(attr.BlobPath, isContainerBinding: true);

            return new MultiBlobContext
            {
                Prefix = path.BlobName,
                Container = GetContainer(attr)
            };
        }
        #endregion

        private async Task<Stream> ConvertToStreamAsync(BlobBaseClient input, CancellationToken cancellationToken)
        {
            return await ReadBlobArgumentBinding.TryBindStreamAsync(input, cancellationToken).ConfigureAwait(false);
        }

        // For describing InvokeStrings.
        private async Task<BlobBaseClient> ConvertFromInvokeString(DirectInvokeString input, Attribute attr, ValueBindingContext context)
        {
            var attrResolved = (BlobTriggerAttribute)attr;

            var client = _blobServiceClientProvider.Get(attrResolved.Connection);
            BlobPath path = BlobPath.ParseAndValidate(input.Value);
            var container = client.GetBlobContainerClient(path.ContainerName);
            var blob = await container.GetBlobReferenceFromServerAsync(path.BlobName).ConfigureAwait(false);

            return blob.Item1;
        }

        // BlobClient is simplified version of BlockBlobClient, i.e. upload results in creation of block blob.
        private BlobClient ConvertBlobBaseClientToBlobClient(BlobBaseClient input, BlobTriggerAttribute attr)
        {
            if (input is BlockBlobClient)
            {
                var client = _blobServiceClientProvider.Get(attr.Connection);
                var blob = client.GetBlobContainerClient(input.BlobContainerName).GetBlobClient(input.Name);

                return blob;
            }
            else
            {
                throw new InvalidOperationException($"The blob is not an {typeof(BlockBlobClient).Name}.");
            }
        }

        private async Task<Stream> CreateStreamAsync(
            BlobAttribute blobAttribute,
            ValueBindingContext context)
        {
            var cancellationToken = context.CancellationToken;
            var blob = await GetBlobAsync(blobAttribute, cancellationToken).ConfigureAwait(false);

            switch (blobAttribute.Access)
            {
                case FileAccess.Read:
                    var readStream = await ReadBlobArgumentBinding.TryBindStreamAsync(blob.BlobClient, context).ConfigureAwait(false);
                    return readStream;

                case FileAccess.Write:
                    var writeStream = await WriteBlobArgumentBinding.BindStreamAsync(blob,
                    context, _blobWrittenWatcherGetter.Value).ConfigureAwait(false);
                    return writeStream;

                default:
                    throw new InvalidOperationException("Cannot bind blob to Stream using FileAccess ReadWrite.");
            }
        }

        private BlobServiceClient GetClient(
         BlobAttribute blobAttribute)
        {
            return _blobServiceClientProvider.Get(blobAttribute.Connection, _nameResolver);
        }

        private BlobContainerClient GetContainer(
            BlobAttribute blobAttribute)
        {
            var client = GetClient(blobAttribute);

            BlobPath boundPath = BlobPath.ParseAndValidate(blobAttribute.BlobPath, isContainerBinding: true);

            var container = client.GetBlobContainerClient(boundPath.ContainerName);
            return container;
        }

        private async Task<BlobWithContainer<BlobBaseClient>> GetBlobAsync(
                BlobAttribute blobAttribute,
                CancellationToken cancellationToken,
                Type requestedType = null)
        {
            var client = GetClient(blobAttribute);
            BlobPath boundPath = BlobPath.ParseAndValidate(blobAttribute.BlobPath);

            var container = client.GetBlobContainerClient(boundPath.ContainerName);

            // Call ExistsAsync before attempting to create. This reduces the number of
            // 40x calls that App Insights may be tracking automatically
            if (blobAttribute.Access != FileAccess.Read && !await container.ExistsAsync().ConfigureAwait(false))
            {
                await container.CreateIfNotExistsAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }

            var blob = await container.GetBlobReferenceForArgumentTypeAsync(
                boundPath.BlobName, requestedType, cancellationToken).ConfigureAwait(false);

            return new BlobWithContainer<BlobBaseClient>(container, blob);
        }

        private async Task<HttpResponseMessage> ProcessEventsAsync(JArray events, string functionName, CancellationToken cancellationToken)
        {
            foreach (JObject jo in events)
            {
                BlobTriggerMessage blobTriggerMessage = GetBlobTriggerMessage(jo, functionName);
                await _blobTriggerQueueWriter.EnqueueAsync(blobTriggerMessage, cancellationToken).ConfigureAwait(false);
            }

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        private static BlobTriggerMessage GetBlobTriggerMessage(JObject jo, string functionId)
        {
            JObject data = jo["data"] as JObject;

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri(data["url"].ToString()));

            return new BlobTriggerMessage()
            {
                ETag = $"\"{data["eTag"]}\"",
                BlobType = (BlobType)Enum.Parse(typeof(BlobType), data["blobType"].ToString().Replace("Blob", "")),
                ContainerName = blobUriBuilder.BlobContainerName,
                BlobName = blobUriBuilder.BlobName,
                FunctionId = functionId
            };
        }
    }
}
