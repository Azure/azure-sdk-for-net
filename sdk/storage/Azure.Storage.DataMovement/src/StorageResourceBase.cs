// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// The abstract class StorageResourceBase.
    /// </summary>
    public abstract class StorageResourceBase
    {
        /// <summary>
        /// Stores the authentication scheme that client authenticates with.
        /// </summary>
        internal ResourceAuthorization _authScheme;

        /// <summary>
        /// The protected constructor for the abstract StorageResourceBase class (to allow for mocking).
        /// </summary>
        protected StorageResourceBase()
        {
            _authScheme = new ResourceAuthorization();
        }

        /// <summary>
        /// Defines whether we can produce a Uri.
        /// </summary>
        public abstract ProduceUriType CanProduceUri { get; }

        /// <summary>
        /// Gets the Uri.
        /// </summary>
        public abstract Uri Uri { get; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public abstract string Path { get; }

        /// <summary>
        /// Defines whether the storage resource is a container.
        /// </summary>
        public abstract bool IsContainer { get; }

        // TODO: add back in when AzureSasCredential supports generating SAS's
        // <summary>
        // Internal constructor to accept the authorization Scheme
        // </summary>
        //protected void SetAuthorizationScheme(AzureSasCredential sasCredential)
        //{
        //_authScheme.SetAuthentication(sasCredential);
        //}

        /// <summary>
        /// Internal constructor to accept the authorization Scheme
        /// </summary>
        /// <param name="tokenCredential"></param>
        protected void SetAuthorizationScheme(TokenCredential tokenCredential)
        {
            _authScheme.SetAuthentication(tokenCredential);
        }
    }
}
