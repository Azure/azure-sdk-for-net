// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Gallery.Models;

namespace Microsoft.Azure.Gallery
{
    public static partial class ItemOperationsExtensions
    {
        /// <summary>
        /// Gets a gallery items.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Gallery.IItemOperations.
        /// </param>
        /// <param name='itemIdentity'>
        /// Optional. Gallery item identity.
        /// </param>
        /// <returns>
        /// Gallery item information.
        /// </returns>
        public static ItemGetParameters Get(this IItemOperations operations, string itemIdentity)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IItemOperations)s).GetAsync(itemIdentity);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Gets a gallery items.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Gallery.IItemOperations.
        /// </param>
        /// <param name='itemIdentity'>
        /// Optional. Gallery item identity.
        /// </param>
        /// <returns>
        /// Gallery item information.
        /// </returns>
        public static Task<ItemGetParameters> GetAsync(this IItemOperations operations, string itemIdentity)
        {
            return operations.GetAsync(itemIdentity, CancellationToken.None);
        }
        
        /// <summary>
        /// Gets collection of gallery items.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Gallery.IItemOperations.
        /// </param>
        /// <param name='parameters'>
        /// Optional. Query parameters. If null is passed returns all gallery
        /// items.
        /// </param>
        /// <returns>
        /// List of gallery items.
        /// </returns>
        public static ItemListResult List(this IItemOperations operations, ItemListParameters parameters)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IItemOperations)s).ListAsync(parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Gets collection of gallery items.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Gallery.IItemOperations.
        /// </param>
        /// <param name='parameters'>
        /// Optional. Query parameters. If null is passed returns all gallery
        /// items.
        /// </param>
        /// <returns>
        /// List of gallery items.
        /// </returns>
        public static Task<ItemListResult> ListAsync(this IItemOperations operations, ItemListParameters parameters)
        {
            return operations.ListAsync(parameters, CancellationToken.None);
        }
    }
}
