// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Fluent.Resource
{
    internal class ProviderImpl :
        IndexableWrapper<ProviderInner>,
        IProvider
    {
        internal ProviderImpl(ProviderInner provider) : base(provider)
        {
        }

        public string Namespace
        {
            get
            {
                return Inner.NamespaceProperty;
            }
        }

        public string RegistrationState
        {
            get
            {
                return Inner.RegistrationState;
            }
        }

        public IList<ProviderResourceType> ResourceTypes
        {
            get
            {
                return Inner.ResourceTypes;
            }
        }
    }
}
