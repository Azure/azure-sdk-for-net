﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class TenantImpl :
        IndexableWrapper<TenantIdDescription>,
        ITenant
    {
        internal TenantImpl(TenantIdDescription inner) : base(inner)
        {}

        public string TenantId
        {
            get
            {
                return Inner.TenantId;
            }
        }
    }
}
