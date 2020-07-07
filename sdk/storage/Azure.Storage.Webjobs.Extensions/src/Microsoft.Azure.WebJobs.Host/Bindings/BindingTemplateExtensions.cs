// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;
using Microsoft.Azure.WebJobs.Host.Properties;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Class containing extension methods for <see cref="BindingTemplate"/> and other binding Types.
    /// </summary>
    public static class BindingTemplateExtensions
    {
        /// <summary>
        /// Verifies that the specified binding contract contains contract members for each of the
        /// parameters in the specified <see cref="BindingTemplate"/>.
        /// </summary>
        /// <param name="bindingTemplate">The binding template to validate.</param>
        /// <param name="bindingDataContract">The data contract to validate against.</param>
        public static void ValidateContractCompatibility(this BindingTemplate bindingTemplate, IReadOnlyDictionary<string, Type> bindingDataContract)
        {
            if (bindingTemplate == null)
            {
                throw new ArgumentNullException("bindingTemplate");
            }

            ValidateContractCompatibility(bindingTemplate.ParameterNames, bindingDataContract);
        }

        /// <summary>
        /// Bind the <see cref="BindingTemplate"/> using the specified binding data.
        /// </summary>
        /// <param name="bindingTemplate">The binding template to validate.</param>
        /// <param name="bindingData">The binding data to apply to the template.</param>
        /// <returns>The bound template string.</returns>
        [Obsolete("Call instance method directly")]
        public static string Bind(this BindingTemplate bindingTemplate, IReadOnlyDictionary<string, object> bindingData)
        {
            if (bindingTemplate == null)
            {
                throw new ArgumentNullException("bindingTemplate");
            }

            return bindingTemplate.Bind(bindingData);
        }

        public static void ValidateContractCompatibility(IEnumerable<string> parameterNames, IReadOnlyDictionary<string, Type> bindingDataContract)
        {
            if (parameterNames != null && bindingDataContract != null)
            {
                foreach (string parameterName in parameterNames)
                {
                    if (string.Equals(parameterName, SystemBindingData.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    if (BindingParameterResolver.IsSystemParameter(parameterName))
                    {
                        continue;
                    }

                    if (!bindingDataContract.ContainsKey(parameterName))
                    {
                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resource.UnableToResolveBindingParameterFormat, parameterName));
                    }
                }
            }
        }
    }
}
