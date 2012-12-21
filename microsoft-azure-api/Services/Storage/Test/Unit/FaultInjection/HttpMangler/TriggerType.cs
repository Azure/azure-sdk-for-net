// -----------------------------------------------------------------------------------------
// <copyright file="TriggerType.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------


namespace Microsoft.WindowsAzure.Test.Network
{
    using System;

    /// <summary>
    /// The TriggerType enumeration controls, on a brute scale, when a behavior will fire.
    /// It is a bit flag enumeration, so multiple values can be specified at once.
    /// </summary>
    [Flags]
    public enum TriggerType
    {
        /// <summary>
        /// This behavior will never fire. This value cannot be combined with other flags.
        /// </summary>
        None = 0,

        /// <summary>
        /// This behavior will fire before the request is tranmitted across the wire.
        /// </summary>
        BeforeRequest = 1 << 0,

        /// <summary>
        /// This behavior will fire before the response from the server is delivered back to the client,
        /// but only in error cases.
        /// </summary>
        BeforeReturningError = 1 << 1,

        /// <summary>
        /// This behavior will fire before the response from server is delivered back to the client.
        /// </summary>
        BeforeResponse = 1 << 2,

        /// <summary>
        /// This behavior will fire when the HTTP session has been completed.
        /// </summary>
        AfterSessionComplete = 1 << 3,

        /// <summary>
        /// This behavior will fire when the response headers from the request have been delivered.
        /// This happens prior to the full response being delivered.
        /// </summary>
        ResponseHeadersAvailable = 1 << 4,

        /// <summary>
        /// This value contains all other values. When it is specified, this behavior will happen 
        /// for every sort of event.
        /// </summary>
        All = BeforeRequest 
            | BeforeReturningError 
            | BeforeResponse 
            | AfterSessionComplete 
            | ResponseHeadersAvailable,
    }
}