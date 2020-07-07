// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class BindingSource : IBindingSource
    {
        private readonly IFunctionBinding _binding;
        private readonly IDictionary<string, object> _parameters;

        public BindingSource(IFunctionBinding binding, IDictionary<string, object> parameters)
        {
            _binding = binding;
            _parameters = parameters;
        }

        public Task<IReadOnlyDictionary<string, IValueProvider>> BindAsync(ValueBindingContext context)
        {
            return _binding.BindAsync(context, _parameters);
        }
    }
}
