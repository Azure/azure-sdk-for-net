// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableAttributeBindingProvider : IBindingProvider
    {
        private readonly ITableEntityArgumentBindingProvider _entityBindingProvider;
        private readonly INameResolver _nameResolver;
        private readonly StorageAccountProvider _accountProvider;

        public TableAttributeBindingProvider(INameResolver nameResolver, StorageAccountProvider accountProvider)
        {
            _nameResolver = nameResolver;
            _accountProvider = accountProvider ?? throw new ArgumentNullException(nameof(accountProvider));
            _entityBindingProvider =
                new CompositeEntityArgumentBindingProvider(
                    new TableEntityArgumentBindingProvider(),
                    new PocoEntityArgumentBindingProvider()); // Supports all types; must come after other providers
        }

        private IBinding TryCreate(BindingProviderContext context)
        {
            ParameterInfo parameter = context.Parameter;
            var tableAttribute = TypeUtility.GetResolvedAttribute<TableAttribute>(context.Parameter);
            if (tableAttribute == null)
            {
                return null;
            }

            string tableName = Resolve(tableAttribute.TableName);
            var account = _accountProvider.Get(tableAttribute.Connection, _nameResolver);
            // requires storage account with table support
            // account.AssertTypeOneOf(StorageAccountType.GeneralPurpose); $$$
            CloudTableClient client = account.CreateCloudTableClient();
            bool bindsToEntireTable = tableAttribute.RowKey == null;
            IBinding binding;
            if (bindsToEntireTable)
            {
                // This should have been caught by the other rule-based binders.
                // We never expect this to get thrown.
                throw new InvalidOperationException("Can't bind Table to type '" + parameter.ParameterType + "'.");
            }
            else
            {
                string partitionKey = Resolve(tableAttribute.PartitionKey);
                string rowKey = Resolve(tableAttribute.RowKey);
                IBindableTableEntityPath path = BindableTableEntityPath.Create(tableName, partitionKey, rowKey);
                path.ValidateContractCompatibility(context.BindingDataContract);
                IArgumentBinding<TableEntityContext> argumentBinding = _entityBindingProvider.TryCreate(parameter);
                if (argumentBinding == null)
                {
                    throw new InvalidOperationException("Can't bind Table entity to type '" + parameter.ParameterType + "'.");
                }

                binding = new TableEntityBinding(parameter.Name, argumentBinding, client, path);
            }

            return binding;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            return Task.Run(() => TryCreate(context));
        }

        private string Resolve(string name)
        {
            if (_nameResolver == null)
            {
                return name;
            }

            return _nameResolver.ResolveWholeString(name);
        }
    }
}