// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// The base class for all storage resources.
    /// </summary>
    public abstract class StorageResource
    {
        /// <summary>
        /// Stores the authentication scheme that client authenticates with.
        /// </summary>
        internal ResourceAuthorization _authScheme;

        /// <summary>
        /// The protected constructor for the abstract StorageResourceBase class (to allow for mocking).
        /// </summary>
        protected StorageResource()
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
        /// <param name="authorization"></param>
        protected void SetAuthorizationScheme(HttpAuthorization authorization)
        {
            _authScheme.SetAuthentication(authorization);
        }
    }
}
