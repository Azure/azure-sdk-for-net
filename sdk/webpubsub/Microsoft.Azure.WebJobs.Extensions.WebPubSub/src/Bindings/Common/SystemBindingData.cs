// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Copy from: https://github.com/Azure/azure-webjobs-sdk/blob/v3.0.29/src/Microsoft.Azure.WebJobs.Host/Bindings/SystemBindingData.cs.
    /// </summary>
    /// <summary>
    /// Class providing support for built in system binding expressions.
    /// </summary>
    /// <remarks>
    /// It's expected this class is created and added to the binding data.
    /// </remarks>
    internal class SystemBindingData
    {
        // The public name for this binding in the binding expressions.
        public const string Name = "sys";

        // An internal name for this binding that uses characters that gaurantee it can't be overwritten by a user.
        // This is never seen by the user.
        // This ensures that we can always unambiguously retrieve this later.
        private const string InternalKeyName = "$sys";

        private static readonly IReadOnlyDictionary<string, Type> DefaultSystemContract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
        {
            { Name, typeof(SystemBindingData) }
        };

        /// <summary>
        /// The method name that the binding lives in.
        /// The method name can be override by the <see cref="FunctionNameAttribute"/>.
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Get the current UTC date.
        /// </summary>
        public static DateTime UtcNow => DateTime.UtcNow;

        /// <summary>
        /// Return a new random guid. This create a new guid each time it's called.
        /// </summary>
        public static Guid RandGuid => Guid.NewGuid();

        // Given a full bindingData, create a binding data with just the system object .
        // This can be used when resolving default contracts that shouldn't be using an instance binding data.
        internal static IReadOnlyDictionary<string, object> GetSystemBindingData(IReadOnlyDictionary<string, object> bindingData)
        {
            var data = GetFromData(bindingData);
            var systemBindingData = new Dictionary<string, object>
            {
                { Name, data }
            };
            return systemBindingData;
        }

        // Validate that a template only uses static (non-instance) binding variables.
        // Enforces we're not referring to other data from the trigger.
        internal static void ValidateStaticContract(BindingTemplate template)
        {
            try
            {
                template.ValidateContractCompatibility(SystemBindingData.DefaultSystemContract);
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException($"Default contract can only refer to the '{SystemBindingData.Name}' binding data: " + e.Message);
            }
        }

        internal void AddToBindingData(Dictionary<string, object> bindingData)
        {
            // User data takes precedence, so if 'sys' already exists, add via the internal name.
            string sysName = bindingData.ContainsKey(SystemBindingData.Name) ? SystemBindingData.InternalKeyName : SystemBindingData.Name;
            bindingData[sysName] = this;
        }

        // Given per-instance binding data, extract just the system binding data object from it.
        private static SystemBindingData GetFromData(IReadOnlyDictionary<string, object> bindingData)
        {
            if (bindingData.TryGetValue(InternalKeyName, out object val))
            {
                return val as SystemBindingData;
            }
            if (bindingData.TryGetValue(Name, out val))
            {
                return val as SystemBindingData;
            }
            return null;
        }
    }
}