﻿//-----------------------------------------------------------------------
// <copyright file="BatchCredentials.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.Azure.Batch.Auth
{
    using System;

    /// <summary>
    /// Base class for credentials used to authenticate access to an Azure Batch account.
    /// </summary>
    public abstract class BatchCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchCredentials"/> class.
        /// </summary>
        protected BatchCredentials()
        { }

        /// <summary>
        /// Gets the Batch service endpoint.
        /// </summary>
        public string BaseUrl { get; protected set; }
    }
}
