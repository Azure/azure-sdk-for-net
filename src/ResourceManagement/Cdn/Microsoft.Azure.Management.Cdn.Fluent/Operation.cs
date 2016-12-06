// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Cdn.Fluent.Models;

namespace Microsoft.Azure.Management.Cdn.Fluent
{
    /// <summary>
    /// Operation that CDN service supports.
    /// </summary>
    public partial class Operation 
    {
        private OperationInner inner;

        /// <summary>
        /// Get the provider value.
        /// </summary>
        /// <return>The provider value.</return>
        public string Provider
        {
            get
            {
                if (this.inner.Display == null)
                {
                    return null;
                }

                return this.inner.Display.Provider;
            }
        }

        /// <summary>
        /// Get the resource value.
        /// </summary>
        /// <return>The resource value.</return>
        public string Resource
        {
            get
            {
                if (this.inner.Display == null)
                {
                    return null;
                }

                return this.inner.Display.Resource;
            }
        }

        /// <summary>
        /// Get the name value.
        /// </summary>
        /// <return>The name value.</return>
        public string Name
        {
            get
            {
                return this.inner.Name;
            }
        }

        /// <summary>
        /// Construct Operation object from server response object.
        /// </summary>
        /// <param name="inner">Server response object containing supported operation description.</param>
        public Operation(OperationInner inner)
        {
            this.inner = inner;
        }

        /// <summary>
        /// Get the operation value.
        /// </summary>
        /// <return>The operation value.</return>
        public string Type
        {
            get
            {
                if (this.inner.Display == null)
                {
                    return null;
                }
                return this.inner.Display.Operation;
            }
        }
    }
}