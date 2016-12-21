// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Cdn.Fluent.Models;

namespace Microsoft.Azure.Management.Cdn.Fluent
{
    /// <summary>
    /// Operation that CDN service supports.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNkbi5PcGVyYXRpb24=
    public partial class Operation 
    {
        private OperationInner inner;

        /// <summary>
        /// Get the provider value.
        /// </summary>
        /// <return>The provider value.</return>
        ///GENMHASH:B02B5B6A1DD75D38C563663DA1450D40:150FC7DB40E34EF39437F09ABE964235
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
        ///GENMHASH:17189B1962A88F2A8CC610963CAD0A42:6F4AB6E491CED66D2DB131E1C17BACE5
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
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:8CC68A07507378BC8AFC6AE910E81D29
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
        public  Operation(OperationInner inner)
        {
            this.inner = inner;
        }

        /// <summary>
        /// Get the operation value.
        /// </summary>
        /// <return>The operation value.</return>
        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:536682F51F05DB89D4CB8B448D8EA927
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
