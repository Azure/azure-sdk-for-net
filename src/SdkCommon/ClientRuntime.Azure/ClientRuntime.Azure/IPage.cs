﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// Defines a page interface in Azure responses.
    /// </summary>
    /// <typeparam name="T">Type of the page content items</typeparam>
    public interface IPage<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets the link to the next page.
        /// </summary>
        string NextPageLink { get; }
    }
}
