// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Models;

namespace Microsoft.Azure.Management.Fluent.Resource
{
    internal class LocationImpl : IndexableWrapper<Location>, ILocation
    {
        public LocationImpl(Location innerObject) : base(innerObject)
        {
        }

        public string DisplayName
        {
            get
            {
                return Inner.DisplayName;
            }
        }

        public string Latitude
        {
            get
            {
                return Inner.Latitude;
            }
        }

        public string Longitude
        {
            get
            {
                return Inner.Longitude;
            }
        }

        public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public string SubscriptionId
        {
            get
            {
                return Inner.SubscriptionId;
            }
        }

        public Region Region
        {
            get { return Region.Create(Name);  }
        }
    }
}
