// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Resource.Core
{
    public class Utilities
    {
        public static IPage<InnerResourceT> ConvertToPage<InnerResourceT>(IEnumerable<InnerResourceT> list)
        {
            var page = new Page<InnerResourceT>();
            typeof(Page<InnerResourceT>).GetProperty("Items", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(page, list.ToList());

            return page;
        }
    }
}
