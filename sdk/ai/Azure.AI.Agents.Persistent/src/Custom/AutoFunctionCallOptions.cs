// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.AI.Agents.Persistent
{
    public class AutoFunctionCallOptions
    {
        private Dictionary<string, Delegate> _autoFunctionCallDelegates = new();
        private int _maxRetry;
        /// <summary> The size of the client cache. </summary>

        /// <summary>
        /// Enables auto tool calls to be executed automatically during streaming.  If this is not set, function must be called manually.
        /// </summary>
        /// <param name="toolDelegates">Dictionary in name and delegate in pair</param>
        /// <param name="maxRetry">Maximum number of errors allowed and retry per stream. Default value is 10.</param>
        public AutoFunctionCallOptions(Dictionary<string, Delegate> toolDelegates, int maxRetry) {
            ValidateAutoFunctions(toolDelegates);
            _autoFunctionCallDelegates.Clear();

            foreach (var kvp in toolDelegates)
            {
                _autoFunctionCallDelegates[kvp.Key] = kvp.Value;
            }
            _maxRetry = maxRetry;
        }

        private void ValidateAutoFunctions(Dictionary<string, Delegate> toolDelegates)
        {
            if (toolDelegates == null || toolDelegates.Count == 0)
            {
                throw new InvalidOperationException("The delegate dictionary must have at least one delegate.");
            }
            foreach (var kvp in toolDelegates)
            {
                if (kvp.Value.Method.ReturnType != typeof(string))
                {
                    throw new InvalidOperationException($"The Delegates must have string as return type.");
                }
            }
        }

        internal Dictionary<string, Delegate> AutoFunctionCallDelegates => _autoFunctionCallDelegates;

        internal int MaxRetry => _maxRetry;
    }
}
