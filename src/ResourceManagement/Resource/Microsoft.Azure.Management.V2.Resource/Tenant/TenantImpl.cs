// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class TenantImpl :
        IndexableWrapper<TenantIdDescription>,
        ITenant
    {
        internal TenantImpl(TenantIdDescription inner) : base(inner.Id, inner)
        {}

        public string TenantId
        {
            get
            {
                return Inner.TenantId;
            }
        }

        TenantIdDescriptionInner IWrapper<TenantIdDescriptionInner>.Inner
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
