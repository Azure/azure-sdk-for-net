// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Converters;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Data
{
    /// <summary>
    /// Handles value types (structs) as well as nullable types.
    /// </summary>
    internal class StructDataBindingProvider<TBindingData> : IBindingProvider
    {
        private static readonly IDataArgumentBindingProvider<TBindingData> InnerProvider =
            new CompositeArgumentBindingProvider<TBindingData>(
                new ConverterArgumentBindingProvider<TBindingData, TBindingData>(new IdentityConverter<TBindingData>()),
                new TToStringArgumentBindingProvider<TBindingData>());

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ParameterInfo parameter = context.Parameter;

            IArgumentBinding<TBindingData> argumentBinding = InnerProvider.TryCreate(parameter);

            string parameterName = parameter.Name;
            Type parameterType = parameter.ParameterType;

            if (argumentBinding == null)
            {
                throw new InvalidOperationException(
                    "Can't bind parameter '" + parameterName + "' to type '" + parameterType + "'.");
            }

            IBinding binding = new StructDataBinding<TBindingData>(parameterName, argumentBinding);
            return Task.FromResult(binding);
        }
    }
}
