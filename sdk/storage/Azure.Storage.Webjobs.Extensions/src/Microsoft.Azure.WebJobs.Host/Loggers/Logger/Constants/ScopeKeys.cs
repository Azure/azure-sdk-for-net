// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Logging
{
    /// <summary>
    /// A collection of constants used for logging scope keys.
    /// </summary>
    public static class ScopeKeys
    {
        /// <summary>
        /// A key identifying the function invocation id.
        /// </summary>
        public const string FunctionInvocationId = "MS_FunctionInvocationId";

        /// <summary>
        /// A key identifying the function name.
        /// </summary>
        public const string FunctionName = "MS_FunctionName";

        /// <summary>
        /// A key identifying the event starting with the current scope
        /// </summary>
        public const string Event = "MS_Event";

        /// <summary>
        /// A key identifying the current host instance.
        /// </summary>
        public const string HostInstanceId = "MS_HostInstanceId";

        /// <summary>
        /// A key identifying the current invocation trigger details.
        /// </summary>
        public const string TriggerDetails = "MS_TriggerDetails";
    }
}
