// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Triggers
{
    internal class BlobTriggerBinding : ITriggerBinding
    {
        private readonly ParameterInfo _parameter;
        private readonly StorageAccount _hostAccount;
        private readonly StorageAccount _dataAccount;
        private readonly CloudBlobClient _blobClient;
        private readonly string _accountName;
        private readonly IBlobPathSource _path;
        private readonly IHostIdProvider _hostIdProvider;
        private readonly QueuesOptions _queueOptions;
        private readonly BlobsOptions _blobsOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly IContextSetter<IBlobWrittenWatcher> _blobWrittenWatcherSetter;
        private readonly SharedQueueWatcher _messageEnqueuedWatcherSetter;
        private readonly ISharedContextProvider _sharedContextProvider;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IAsyncObjectToTypeConverter<ICloudBlob> _converter;
        private readonly IReadOnlyDictionary<string, Type> _bindingDataContract;
        private readonly IHostSingletonManager _singletonManager;

        public BlobTriggerBinding(ParameterInfo parameter,
            StorageAccount hostAccount,
            StorageAccount dataAccount,
            IBlobPathSource path,
            IHostIdProvider hostIdProvider,
            QueuesOptions queueOptions,
            BlobsOptions blobsOptions,
            IWebJobsExceptionHandler exceptionHandler,
            IContextSetter<IBlobWrittenWatcher> blobWrittenWatcherSetter,
            SharedQueueWatcher messageEnqueuedWatcherSetter,
            ISharedContextProvider sharedContextProvider,
            IHostSingletonManager singletonManager,
            ILoggerFactory loggerFactory)
        {
            _parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
            _hostAccount = hostAccount ?? throw new ArgumentNullException(nameof(hostAccount));
            _dataAccount = dataAccount ?? throw new ArgumentNullException(nameof(dataAccount));
                        

            _blobClient = dataAccount.CreateCloudBlobClient();
            _accountName = BlobClient.GetAccountName(_blobClient);
            _path = path ?? throw new ArgumentNullException(nameof(path));
            _hostIdProvider = hostIdProvider ?? throw new ArgumentNullException(nameof(hostIdProvider));
            _queueOptions = queueOptions ?? throw new ArgumentNullException(nameof(queueOptions));
            _blobsOptions = blobsOptions ?? throw new ArgumentNullException(nameof(blobsOptions));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _blobWrittenWatcherSetter = blobWrittenWatcherSetter ?? throw new ArgumentNullException(nameof(blobWrittenWatcherSetter));
            _messageEnqueuedWatcherSetter = messageEnqueuedWatcherSetter ?? throw new ArgumentNullException(nameof(messageEnqueuedWatcherSetter));
            _sharedContextProvider = sharedContextProvider ?? throw new ArgumentNullException(nameof(sharedContextProvider));
            _singletonManager = singletonManager ?? throw new ArgumentNullException(nameof(singletonManager));
            _loggerFactory = loggerFactory;
            _converter = CreateConverter(_blobClient);
            _bindingDataContract = CreateBindingDataContract(path);
        }

        public Type TriggerValueType
        {
            get
            {
                return typeof(ICloudBlob);
            }
        }

        public IReadOnlyDictionary<string, Type> BindingDataContract
        {
            get { return _bindingDataContract; }
        }

        public string ContainerName
        {
            get { return _path.ContainerNamePattern; }
        }

        public string BlobName
        {
            get { return _path.BlobNamePattern; }
        }

        public string BlobPath
        {
            get { return _path.ToString(); }
        }

        private static IReadOnlyDictionary<string, Type> CreateBindingDataContract(IBlobPathSource path)
        {
            var contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
            contract.Add("BlobTrigger", typeof(string));
            contract.Add("Uri", typeof(Uri));
            contract.Add("Properties", typeof(BlobProperties));
            contract.Add("Metadata", typeof(IDictionary<string, string>));

            IReadOnlyDictionary<string, Type> contractFromPath = path.CreateBindingDataContract();

            if (contractFromPath != null)
            {
                foreach (KeyValuePair<string, Type> item in contractFromPath)
                {
                    // In case of conflict, binding data from the value type overrides the built-in binding data above.
                    contract[item.Key] = item.Value;
                }
            }

            return contract;
        }

        private IReadOnlyDictionary<string, object> CreateBindingData(ICloudBlob value)
        {
            var bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            bindingData.Add("BlobTrigger", value.GetBlobPath());
            bindingData.Add("Uri", value.Uri);
            bindingData.Add("Properties", value.Properties);
            bindingData.Add("Metadata", value.Metadata);

            IReadOnlyDictionary<string, object> bindingDataFromPath = _path.CreateBindingData(value.ToBlobPath());

            if (bindingDataFromPath != null)
            {
                foreach (KeyValuePair<string, object> item in bindingDataFromPath)
                {
                    // In case of conflict, binding data from the value type overrides the built-in binding data above.
                    bindingData[item.Key] = item.Value;
                }
            }
            return bindingData;
        }

        private static IAsyncObjectToTypeConverter<ICloudBlob> CreateConverter(CloudBlobClient client)
        {
            return new CompositeAsyncObjectToTypeConverter<ICloudBlob>(
                new BlobOutputConverter<ICloudBlob>(new AsyncConverter<ICloudBlob, ICloudBlob>(new IdentityConverter<ICloudBlob>())),
                new BlobOutputConverter<string>(new StringToCloudBlobConverter(client)));
        }

        public async Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            ConversionResult<ICloudBlob> conversionResult = await _converter.TryConvertAsync(value, context.CancellationToken);

            if (!conversionResult.Succeeded)
            {
                throw new InvalidOperationException("Unable to convert trigger to IStorageBlob.");
            }

            IReadOnlyDictionary<string, object> bindingData = CreateBindingData(conversionResult.Result);

            return new TriggerData(bindingData);
        }

        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var container = _blobClient.GetContainerReference(_path.ContainerNamePattern);

            var factory = new BlobListenerFactory(_hostIdProvider, _queueOptions, _blobsOptions, _exceptionHandler,
                _blobWrittenWatcherSetter, _messageEnqueuedWatcherSetter, _sharedContextProvider, _loggerFactory,
                context.Descriptor, _hostAccount, _dataAccount, container, _path, context.Executor, _singletonManager);

            return factory.CreateAsync(context.CancellationToken);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new BlobTriggerParameterDescriptor
            {
                Name = _parameter.Name,
                AccountName = _accountName,
                ContainerName = _path.ContainerNamePattern,
                BlobName = _path.BlobNamePattern,
                Access = FileAccess.Read
            };
        }
    }
}
