//-----------------------------------------------------------------------
// <copyright file="StorageExceptionExtensions.cs" company="Microsoft">
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
// <summary>
//    Contains code for the StorageExceptionExtensions.cs class.
// </summary>
//-----------------------------------------------------------------------
namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Net;

    /// <summary>
    ///  Provides a set of extensions for translating Exceptions into StorageExceptions.
    /// </summary>
    public static class StorageExceptionExtensions
    {
        /// <summary>
        /// Translates a WebException into the corresponding StorageException.
        /// </summary>
        /// <param name="exceptionRef">The exception to translate.</param>
        /// <returns>The translated exception.</returns>
        public static StorageException TranslateWebException(this WebException exceptionRef)
        {
            return Utilities.TranslateWebException(exceptionRef) as StorageException;
        }

        /// <summary>
        ///  Translates the data service client exception.
        /// </summary>
        /// <param name="exceptionRef">The exception to translate.</param>
        /// <returns>The translated exception.</returns>
        public static StorageException TranslateDataServiceClientException(this InvalidOperationException exceptionRef)
        {
            return Utilities.TranslateDataServiceClientException(exceptionRef) as StorageException;
        }
    }
}
