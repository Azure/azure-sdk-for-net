//-----------------------------------------------------------------------
// <copyright file="MessageUpdateFields.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the MessageUpdateFields enum.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Enumeration controlling the options for updating queue messages.
    /// </summary>
    [Flags]
    public enum MessageUpdateFields
    {
        /// <summary>
        /// Update the message visibility timeout.
        /// This is required for calls to UpdateMessage in version 2011-08-18.
        /// </summary>
        Visibility = 0x1,

        /// <summary>
        /// Update the message content.
        /// </summary>
        Content = 0x2
    }
}
