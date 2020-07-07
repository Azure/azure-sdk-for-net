// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Bindings
{
    [Extension("AzureStorageBlobs", "Blobs")]
    internal class BlobsExtensionConfigProvider : IExtensionConfigProvider,
        IConverter<BlobAttribute, CloudBlobContainer>,
        IConverter<BlobAttribute, CloudBlobDirectory>,
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

            // Bind to multiple blobs (either via a container; a blob directory, an IEnumerable<T>)
            rule.BindToInput<CloudBlobDirectory>(this);
            rule.BindToInput<CloudBlobContainer>(this);

            rule.BindToInput<MultiBlobContext>(this); // Intermediate private context to capture state
            rule.AddOpenConverter<MultiBlobContext, IEnumerable<BlobCollectionType>>(typeof(BlobCollectionConverter<>), this);

            // BindToStream will also handle the custom Stream-->T converters.
            rule.SetPostResolveHook(ToBlobDescr).
                BindToStream(CreateStreamAsync, FileAccess.ReadWrite); // Precedence, must beat CloudBlobStream

            // Normal blob
            // These are not converters because Blob/Page/Append affects how we *create* the blob. 
            rule.SetPostResolveHook(ToBlobDescr).
                BindToInput<CloudBlockBlob>((attr, cts) => CreateBlobReference<CloudBlockBlob>(attr, cts));

            rule.SetPostResolveHook(ToBlobDescr).
                BindToInput<CloudPageBlob>((attr, cts) => CreateBlobReference<CloudPageBlob>(attr, cts));

            rule.SetPostResolveHook(ToBlobDescr).
                 BindToInput<CloudAppendBlob>((attr, cts) => CreateBlobReference<CloudAppendBlob>(attr, cts));

            rule.SetPostResolveHook(ToBlobDescr).
                BindToInput<ICloudBlob>((attr, cts) => CreateBlobReference<ICloudBlob>(attr, cts));

            // CloudBlobStream's derived functionality is only relevant to writing. 
            rule.When("Access", FileAccess.Write).
                SetPostResolveHook(ToBlobDescr).
                BindToInput<CloudBlobStream>(ConvertToCloudBlobStreamAsync);
        }

        private void InitializeBlobTriggerBindings(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<BlobTriggerAttribute>();
            rule.BindToTrigger<ICloudBlob>(_triggerBinder);

            rule.AddConverter<ICloudBlob, DirectInvokeString>(blob => new DirectInvokeString(blob.GetBlobPath()));
            rule.AddConverter<DirectInvokeString, ICloudBlob>(ConvertFromInvokeString);

            // Common converters shared between [Blob] and [BlobTrigger]

            // Trigger already has the IStorageBlob. Whereas BindToInput defines: Attr-->Stream. 
            //  Converter manager already has Stream-->Byte[],String,TextReader
            context.AddConverter<ICloudBlob, Stream>(ConvertToStreamAsync);

            // Blob type is a property of an existing blob.             
            // $$$ did we lose CloudBlob. That's a base class for Cloud*Blob, but does not implement ICloudBlob? 
            context.AddConverter(new StorageBlobConverter<CloudAppendBlob>());
            context.AddConverter(new StorageBlobConverter<CloudBlockBlob>());
            context.AddConverter(new StorageBlobConverter<CloudPageBlob>());
        }

        #region Container rules
        CloudBlobContainer IConverter<BlobAttribute, CloudBlobContainer>.Convert(
            BlobAttribute blobAttribute)
        {
            return GetContainer(blobAttribute);
        }

        // Write-only rule. 
        CloudBlobDirectory IConverter<BlobAttribute, CloudBlobDirectory>.Convert(
            BlobAttribute blobAttribute)
        {
            var client = GetClient(blobAttribute);

            BlobPath boundPath = BlobPath.ParseAndValidate(blobAttribute.BlobPath, isContainerBinding: false);

            var container = client.GetContainerReference(boundPath.ContainerName);

            CloudBlobDirectory directory = container.GetDirectoryReference(
                boundPath.BlobName);

            return directory;
        }

        #endregion

        #region CloudBlob rules 

        // Produce a write only stream.
        private async Task<CloudBlobStream> ConvertToCloudBlobStreamAsync(
           BlobAttribute blobAttribute, ValueBindingContext context)
        {
            var stream = await CreateStreamAsync(blobAttribute, context);
            return (CloudBlobStream)stream;
        }

        private async Task<T> CreateBlobReference<T>(BlobAttribute blobAttribute, CancellationToken cancellationToken)
        {
            var blob = await GetBlobAsync(blobAttribute, cancellationToken, typeof(T));
            return (T)(blob);
        }

        #endregion

        #region Support for binding to Multiple blobs 
        // Open type matching types that can bind to an IEnumerable<T> blob collection. 
        private class BlobCollectionType : OpenType
        {
            private static readonly Type[] _types = new Type[]
            {
                typeof(ICloudBlob),
                typeof(CloudBlockBlob),
                typeof(CloudPageBlob),
                typeof(CloudAppendBlob),
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
            private readonly FuncAsyncConverter<ICloudBlob, T> _converter;

            public BlobCollectionConverter(BlobsExtensionConfigProvider parent)
            {
                IConverterManager cm = parent._converterManager;
                _converter = cm.GetConverter<ICloudBlob, T, BlobAttribute>();
                if (_converter == null)
                {
                    throw new InvalidOperationException($"Can't convert blob to {typeof(T).FullName}.");
                }
            }

            public async Task<IEnumerable<T>> ConvertAsync(MultiBlobContext context, CancellationToken cancellationToken)
            {
                // Query the blob container using the blob prefix (if specified)
                // Note that we're explicitly using useFlatBlobListing=true to collapse
                // sub directories. If users want to bind to a sub directory, they can
                // bind to CloudBlobDirectory.
                string prefix = context.Prefix;
                var container = context.Container;
                IEnumerable<IListBlobItem> blobItems = await container.ListBlobsAsync(prefix, true, cancellationToken);

                // create an IEnumerable<T> of the correct type, performing any required conversions on the blobs
                var list = await ConvertBlobs(blobItems);
                return list;
            }

            private async Task<IEnumerable<T>> ConvertBlobs(IEnumerable<IListBlobItem> blobItems)
            {
                var list = new List<T>();

                foreach (var blobItem in blobItems)
                {
                    var src = (ICloudBlob)blobItem;

                    var funcCtx = new FunctionBindingContext(Guid.Empty, CancellationToken.None);
                    var valueCtx = new ValueBindingContext(funcCtx, CancellationToken.None);

                    var converted = await _converter(src, null, valueCtx);

                    list.Add(converted);
                }

                return list;
            }
        }

        // Internal context object to aide in binding to  multiple blobs. 
        private class MultiBlobContext
        {
            public string Prefix;
            public CloudBlobContainer Container;
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

        private async Task<Stream> ConvertToStreamAsync(ICloudBlob input, CancellationToken cancellationToken)
        {
            WatchableReadStream watchableStream = await ReadBlobArgumentBinding.TryBindStreamAsync(input, cancellationToken);
            return watchableStream;
        }

        // For describing InvokeStrings.
        private async Task<ICloudBlob> ConvertFromInvokeString(DirectInvokeString input, Attribute attr, ValueBindingContext context)
        {
            var attrResolved = (BlobTriggerAttribute)attr;

            var account = _accountProvider.Get(attrResolved.Connection);
            var client = account.CreateCloudBlobClient();
            BlobPath path = BlobPath.ParseAndValidate(input.Value);
            var container = client.GetContainerReference(path.ContainerName);
            var blob = await container.GetBlobReferenceFromServerAsync(path.BlobName);

            return blob;
        }

        private async Task<Stream> CreateStreamAsync(
            BlobAttribute blobAttribute,
            ValueBindingContext context)
        {
            var cancellationToken = context.CancellationToken;
            var blob = await GetBlobAsync(blobAttribute, cancellationToken);

            switch (blobAttribute.Access)
            {
                case FileAccess.Read:
                    var readStream = await ReadBlobArgumentBinding.TryBindStreamAsync(blob, context);
                    return readStream;

                case FileAccess.Write:
                    var writeStream = await WriteBlobArgumentBinding.BindStreamAsync(blob,
                    context, _blobWrittenWatcherGetter.Value);
                    return writeStream;

                default:
                    throw new InvalidOperationException("Cannot bind blob to Stream using FileAccess ReadWrite.");
            }
        }

        private CloudBlobClient GetClient(
         BlobAttribute blobAttribute)
        {
            var account = _accountProvider.Get(blobAttribute.Connection, _nameResolver);
            return account.CreateCloudBlobClient();
        }

        private CloudBlobContainer GetContainer(
            BlobAttribute blobAttribute)
        {
            var client = GetClient(blobAttribute);

            BlobPath boundPath = BlobPath.ParseAndValidate(blobAttribute.BlobPath, isContainerBinding: true);

            var container = client.GetContainerReference(boundPath.ContainerName);
            return container;
        }

        private async Task<ICloudBlob> GetBlobAsync(
                BlobAttribute blobAttribute,
                CancellationToken cancellationToken,
                Type requestedType = null)
        {
            var client = GetClient(blobAttribute);
            BlobPath boundPath = BlobPath.ParseAndValidate(blobAttribute.BlobPath);

            var container = client.GetContainerReference(boundPath.ContainerName);

            // Call ExistsAsync before attempting to create. This reduces the number of 
            // 40x calls that App Insights may be tracking automatically
            if (blobAttribute.Access != FileAccess.Read && !await container.ExistsAsync())
            {
                await container.CreateIfNotExistsAsync(cancellationToken);
            }

            var blob = await container.GetBlobReferenceForArgumentTypeAsync(
                boundPath.BlobName, requestedType, cancellationToken);

            return blob;
        }
        private ParameterDescriptor ToBlobDescr(BlobAttribute attr, ParameterInfo parameter, INameResolver nameResolver)
        {
            // Resolve the connection string to get an account name.
            var client = GetClient(attr);

            var accountName = client.Credentials.AccountName;

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