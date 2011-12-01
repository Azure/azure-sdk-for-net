//-----------------------------------------------------------------------
// <copyright file="StorageExceptionExtensions.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
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
