// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Storage;

namespace Microsoft.Azure.WebJobs.Host.Bindings.StorageAccount
{
    internal class CloudStorageAccountBinding : IBinding
    {
        private static readonly IObjectToTypeConverter<CloudStorageAccount> Converter =
            new CompositeObjectToTypeConverter<CloudStorageAccount>(
                new OutputConverter<CloudStorageAccount>(new IdentityConverter<CloudStorageAccount>()),
                new OutputConverter<string>(new StringToCloudStorageAccountConverter()));

        private readonly string _parameterName;
        private readonly CloudStorageAccount _account;
        private readonly string _accountName;

        public CloudStorageAccountBinding(string parameterName, CloudStorageAccount account)
        {
            _parameterName = parameterName;
            _account = account;
            _accountName = account.GetAccountName();
        }

        public bool FromAttribute
        {
            get { return false; }
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "context")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private Task<IValueProvider> BindAccountAsync(CloudStorageAccount account, ValueBindingContext context)
        {
            IValueProvider provider = new CloudStorageAccountValueProvider(account);
            return Task.FromResult(provider);
        }

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            CloudStorageAccount account = null;

            if (!Converter.TryConvert(value, out account))
            {
                throw new InvalidOperationException("Unable to convert value to CloudStorageAccount.");
            }

            return BindAccountAsync(account, context);
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            return BindAccountAsync(_account, context.ValueContext);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new CloudStorageAccountParameterDescriptor
            {
                Name = _parameterName,
                AccountName = _accountName
            };
        }
    }
}
