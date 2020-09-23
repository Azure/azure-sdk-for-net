﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Triggers;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Bindings
{
    [Extension("AzureStorageBlobs", "Blobs")]
    internal class BlobsExtensionConfigProvider : IExtensionConfigProvider,
        IConverter<BlobAttribute, BlobContainerClient>,
        IConverter<BlobAttribute, BlobsExtensionConfigProvider.MultiBlobContext>
    {
        private readonly BlobTriggerAttributeBindingProvider _triggerBinder;
        private StorageAccountProvider _accountProvider;
        private IContextGetter<IBlobWrittenWatcher> _blobWrittenWatcherGetter;
        private readonly INameResolver _nameResolver;
        private IConverterManager _converterManager;

        public BlobsExtensionConfigProvider(StorageAccountProvider accountProvider,
            BlobTriggerAttributeBindingProvider triggerBinder,
            IContextGetter<IBlobWrittenWatcher> contextAccessor,
            INameResolver nameResolver,
            IConverterManager converterManager)
        {
            _accountProvider = accountProvider;
            _triggerBinder = triggerBinder;
            _blobWrittenWatcherGetter = contextAccessor;
            _nameResolver = nameResolver;
            _converterManager = converterManager;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            InitilizeBlobBindings(context);
            InitializeBlobTriggerBindings(context);
        }

        private void InitilizeBlobBindings(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<BlobAttribute>();

            // Bind to multiple blobs (either via a container; an IEnumerable<T>)
            rule.BindToInput<BlobContainerClient>(this);

            rule.BindToInput<MultiBlobContext>(this); // Intermediate private context to capture state
            rule.AddOpenConverter<MultiBlobContext, IEnumerable<BlobCollectionType>>(typeof(BlobCollectionConverter<>), this);

            // BindToStream will also handle the custom Stream-->T converters.
#pragma warning disable CS0618 // Type or member is obsolete
            rule.SetPostResolveHook(ToBlobDescr).
#pragma warning restore CS0618 // Type or member is obsolete
                BindToStream(CreateStreamAsync, FileAccess.ReadWrite); // Precedence, must beat CloudBlobStream

            // Normal blob
            // These are not converters because Blob/Page/Append affects how we *create* the blob.
#pragma warning disable CS0618 // Type or member is obsolete
            rule.SetPostResolveHook(ToBlobDescr).
#pragma warning restore CS0618 // Type or member is obsolete
                BindToInput<BlockBlobClient>((attr, cts) => CreateBlobReference<BlockBlobClient>(attr, cts));

#pragma warning disable CS0618 // Type or member is obsolete
            rule.SetPostResolveHook(ToBlobDescr).
#pragma warning restore CS0618 // Type or member is obsolete
                BindToInput<PageBlobClient>((attr, cts) => CreateBlobReference<PageBlobClient>(attr, cts));

#pragma warning disable CS0618 // Type or member is obsolete
            rule.SetPostResolveHook(ToBlobDescr).
#pragma warning restore CS0618 // Type or member is obsolete
                 BindToInput<AppendBlobClient>((attr, cts) => CreateBlobReference<AppendBlobClient>(attr, cts));

#pragma warning disable CS0618 // Type or member is obsolete
            rule.SetPostResolveHook(ToBlobDescr).
#pragma warning restore CS0618 // Type or member is obsolete
                // TODO (kasobol-msft) figure out how to add binding to BlobClient.
                BindToInput<BlobBaseClient>((attr, cts) => CreateBlobReference<BlobBaseClient>(attr, cts));

            // CloudBlobStream's derived functionality is only relevant to writing. check derived functionality
#pragma warning disable CS0618 // Type or member is obsolete
            rule.When("Access", FileAccess.Write).
                SetPostResolveHook(ToBlobDescr).
#pragma warning restore CS0618 // Type or member is obsolete
                BindToInput<Stream>(ConvertToCloudBlobStreamAsync);
        }

        private void InitializeBlobTriggerBindings(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<BlobTriggerAttribute>();
            rule.BindToTrigger<BlobBaseClient>(_triggerBinder);

            rule.AddConverter<BlobBaseClient, DirectInvokeString>(blob => new DirectInvokeString(blob.GetBlobPath()));
            rule.AddConverter<DirectInvokeString, BlobBaseClient>(ConvertFromInvokeString);

            // Common converters shared between [Blob] and [BlobTrigger]

            // Trigger already has the IStorageBlob. Whereas BindToInput defines: Attr-->Stream.
            //  Converter manager already has Stream-->Byte[],String,TextReader
            context.AddConverter<BlobBaseClient, Stream>(ConvertToStreamAsync);

            // Blob type is a property of an existing blob.
            // $$$ did we lose CloudBlob. That's a base class for Cloud*Blob, but does not implement ICloudBlob?
            context.AddConverter(new StorageBlobConverter<AppendBlobClient>());
            context.AddConverter(new StorageBlobConverter<BlockBlobClient>());
            context.AddConverter(new StorageBlobConverter<PageBlobClient>());
        }

        #region Container rules
        BlobContainerClient IConverter<BlobAttribute, BlobContainerClient>.Convert(
            BlobAttribute blobAttribute)
        {
            return GetContainer(blobAttribute);
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

        #region Support for binding to Multiple blobs
        // Open type matching types that can bind to an IEnumerable<T> blob collection.
        private class BlobCollectionType : OpenType
        {
            private static readonly Type[] _types = new Type[]
            {
                // TODO (kasobol-msft) figure out how to introduce BlobClient binding
                typeof(BlobBaseClient),
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
                            src = blobContainerClient.GetBlockBlobClient(blobItem.Name);
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
            WatchableReadStream watchableStream = await ReadBlobArgumentBinding.TryBindStreamAsync(input, cancellationToken).ConfigureAwait(false);
            return watchableStream;
        }

        // For describing InvokeStrings.
        private async Task<BlobBaseClient> ConvertFromInvokeString(DirectInvokeString input, Attribute attr, ValueBindingContext context)
        {
            var attrResolved = (BlobTriggerAttribute)attr;

            var account = _accountProvider.Get(attrResolved.Connection);
            var client = account.CreateBlobServiceClient();
            BlobPath path = BlobPath.ParseAndValidate(input.Value);
            var container = client.GetBlobContainerClient(path.ContainerName);
            var blob = await container.GetBlobReferenceFromServerAsync(path.BlobName).ConfigureAwait(false);

            return blob.Item1;
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
            var account = _accountProvider.Get(blobAttribute.Connection, _nameResolver);
            return account.CreateBlobServiceClient();
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
        private ParameterDescriptor ToBlobDescr(BlobAttribute attr, ParameterInfo parameter, INameResolver nameResolver)
        {
            // Resolve the connection string to get an account name.
            var client = GetClient(attr);

            var accountName = client.AccountName;

            var resolved = nameResolver.ResolveWholeString(attr.BlobPath);

            string containerName = resolved;
            string blobName = null;
            int split = resolved.IndexOf('/');
            if (split > 0)
            {
                containerName = resolved.Substring(0, split);
                blobName = resolved.Substring(split + 1);
            }

            FileAccess access = FileAccess.ReadWrite;
            if (attr.Access.HasValue)
            {
                access = attr.Access.Value;
            }
            else
            {
                var type = parameter.ParameterType;
                if (type.IsByRef || type == typeof(TextWriter))
                {
                    access = FileAccess.Write;
                }
                if (type == typeof(TextReader) || type == typeof(string) || type == typeof(byte[]))
                {
                    access = FileAccess.Read;
                }
            }

            return new BlobParameterDescriptor
            {
                Name = parameter.Name,
                AccountName = accountName,
                ContainerName = containerName,
                BlobName = blobName,
                Access = access
            };
        }
    }
}
