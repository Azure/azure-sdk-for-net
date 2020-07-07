// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Data
{
    internal class DataBindingProvider : IBindingProvider
    {
        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            IReadOnlyDictionary<string, Type> bindingDataContract = context.BindingDataContract;
            string parameterName = context.Parameter.Name;

            if (bindingDataContract == null || !bindingDataContract.ContainsKey(parameterName))
            {
                return Task.FromResult<IBinding>(null);
            }

            Type bindingDataType = bindingDataContract[parameterName];

            if (bindingDataType.IsByRef)
            {
                return Task.FromResult<IBinding>(null);
            }

            if (bindingDataType.ContainsGenericParameters)
            {
                return Task.FromResult<IBinding>(null);
            }

            IBindingProvider typedProvider = CreateTypedBindingProvider(bindingDataType);
            return typedProvider.TryCreateAsync(context);
        }

        private static IBindingProvider CreateTypedBindingProvider(Type bindingDataType)
        {
            Type genericTypeDefinition;

            if (!bindingDataType.IsValueType)
            {
                genericTypeDefinition = typeof(ClassDataBindingProvider<>);
            }
            else
            {
                genericTypeDefinition = typeof(StructDataBindingProvider<>);
            }

            Type genericType = genericTypeDefinition.MakeGenericType(bindingDataType);
            return (IBindingProvider)Activator.CreateInstance(genericType);
        }
    }
}
