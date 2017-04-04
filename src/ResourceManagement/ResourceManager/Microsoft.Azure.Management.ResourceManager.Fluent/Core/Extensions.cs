// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Azure;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
    }
}
