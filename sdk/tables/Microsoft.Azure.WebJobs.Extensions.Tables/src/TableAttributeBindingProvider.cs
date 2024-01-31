// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableAttributeBindingProvider : IBindingProvider
    {
        private readonly INameResolver _nameResolver;
        private readonly TablesAccountProvider _accountProvider;
        private readonly IConverterManager _converterManager;

        public TableAttributeBindingProvider(INameResolver nameResolver, TablesAccountProvider accountProvider, IConverterManager converterManager)
        {
            _nameResolver = nameResolver;
            _accountProvider = accountProvider ?? throw new ArgumentNullException(nameof(accountProvider));
            _converterManager = converterManager;
        }

        private IBinding TryCreate(BindingProviderContext context)
        {
            ParameterInfo parameter = context.Parameter;
            var tableAttribute = TypeUtility.GetResolvedAttribute<TableAttribute>(context.Parameter);
            if (tableAttribute == null)
            {
                return null;
            }

            // ParameterBindingData and JArray are bound by separate binding methods using BindToInput<> specific to those respective types
            if (parameter.ParameterType == typeof(JArray) || parameter.ParameterType == typeof(ParameterBindingData))
            {
                return null;
            }

            string tableName = Resolve(tableAttribute.TableName);
            var account = _accountProvider.Get(tableAttribute.Connection, _nameResolver);
            bool bindsToEntireTable = tableAttribute.RowKey == null;

            if (bindsToEntireTable)
            {
                // This should have been caught by the other rule-based binders.
                // We never expect this to get thrown.
                throw new InvalidOperationException("Can't bind Table to type '" + parameter.ParameterType + "'.");
            }

            string partitionKey = Resolve(tableAttribute.PartitionKey);
            string rowKey = Resolve(tableAttribute.RowKey);
            IBindableTableEntityPath path = BindableTableEntityPath.Create(tableName, partitionKey, rowKey);
            path.ValidateContractCompatibility(context.BindingDataContract);
            IArgumentBinding<TableEntityContext> argumentBinding = TryCreatePocoBinding(parameter, _converterManager);

            if (argumentBinding == null)
            {
                throw new InvalidOperationException("Can't bind Table entity to type '" + parameter.ParameterType + "'.");
            }

            return new TableEntityBinding(parameter.Name, argumentBinding, account, path);
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            return Task.FromResult(TryCreate(context));
        }

        private string Resolve(string name)
        {
            return _nameResolver == null ? name : _nameResolver.ResolveWholeString(name);
        }

        public static IArgumentBinding<TableEntityContext> TryCreatePocoBinding(ParameterInfo parameter, IConverterManager converterManager)
        {
            if (parameter.ParameterType.IsByRef)
            {
                return null;
            }

            if (parameter.ParameterType.ContainsGenericParameters)
            {
                return null;
            }

            var pocoToEntityConverter = converterManager.GetConverter<TableAttribute>(parameter.ParameterType, typeof(TableEntity));
            var entityToPocoConverter = converterManager.GetConverter<TableAttribute>(typeof(TableEntity), parameter.ParameterType);

            if (pocoToEntityConverter == null || entityToPocoConverter == null)
            {
                return null;
            }

            Type genericType = typeof(PocoEntityArgumentBinding<>).MakeGenericType(parameter.ParameterType);
            return (IArgumentBinding<TableEntityContext>)Activator.CreateInstance(genericType, entityToPocoConverter, pocoToEntityConverter);
        }
    }
}