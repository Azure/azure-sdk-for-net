// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text.RegularExpressions;

namespace Microsoft.Azure.WebJobs.Logging
{
    /// <summary>
    /// Constant values for log categories.
    /// </summary>
    public static class LogCategories
    {
        private static readonly Regex _userFunctionRegex = new Regex(@"^Function\.[^\s\.]+\.User$");
        private static readonly Regex _functionRegex = new Regex(@"^Function\.[^\s\.]+$");

        /// <summary>
        /// The category for all logs written by the function host during startup and shutdown. This
        /// includes indexing and configuration logs.
        /// </summary>
        public const string Startup = "Host.Startup";

        /// <summary>
        /// The category for all logs written by the Singleton infrastructure.
        /// </summary>
        public const string Singleton = "Host.Singleton";

        /// <summary>
        /// The category for all logs written by the function executor.
        /// </summary>
        public const string Executor = "Host.Executor";

        /// <summary>
        /// The category for logs written by the function aggregator.
        /// </summary>
        public const string Aggregator = "Host.Aggregator";

        /// <summary>
        /// The category for function results.
        /// </summary>
        public const string Results = "Host.Results";

        /// <summary>
        /// The category for function bindings.
        /// </summary>
        public const string Bindings = "Host.Bindings";

        /// <summary>
        /// The category for logs written for a specific function invocation.
        /// </summary>
        public static string CreateFunctionCategory(string functionName) => $"Function.{functionName}";

        /// <summary>
        /// The category for logs written from within user functions.
        /// </summary>
        public static string CreateFunctionUserCategory(string functionName) => $"{CreateFunctionCategory(functionName)}.User";

        /// <summary>
        /// Returns a logging category like "Host.Triggers.{triggerName}".
        /// </summary>
        /// <param name="triggerName">The trigger name.</param>
        public static string CreateTriggerCategory(string triggerName) => $"Host.Triggers.{triggerName}";

        /// <summary>
        /// Returns true if the category matches the pattern 'Function.{FunctionName}.User'.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool IsFunctionUserCategory(string category) => _userFunctionRegex.IsMatch(category);

        /// <summary>
        /// Returns true if the category matches the pattern 'Function.{FunctionName}'.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool IsFunctionCategory(string category) => _functionRegex.IsMatch(category);
    }
}