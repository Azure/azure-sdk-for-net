// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Azure;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public static class Extensions
    {
        public static IEnumerable<T> AsContinuousCollection<T>(
            this IPage<T> firstPage,
            Func<string, IPage<T>> getNextPage)
        {
            var currentPage = firstPage;

            do
            {
                if (currentPage == null ||
                    !currentPage.Any())
                {
                    yield break;
                }

                foreach (var element in currentPage)
                {
                    yield return element;
                }

            } while (currentPage.NextPageLink != null &&
                    (currentPage = getNextPage(currentPage.NextPageLink)) != null);
        }

        public static IPage<InnerResourceT> ConvertToPage<InnerResourceT>(IEnumerable<InnerResourceT> list)
        {
            var page = new Page<InnerResourceT>();
            typeof(Page<InnerResourceT>).GetProperty(
                    "Items", 
                    BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(page, list.ToList());

            return page;
        }

        public static TResult Synchronize<TResult>(Func<Task<TResult>> function)
        {
            return Task.Factory.StartNew(function, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
                .Unwrap().GetAwaiter().GetResult();
        }

        public static void Synchronize(Func<Task> function)
        {
            Task.Factory.StartNew(function, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
    }
}
