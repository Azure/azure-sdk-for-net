// <copyright file="EnumerateExtenions.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
namespace Microsoft.Azure.Management.MixedReality
{
    using System;
    using System.Collections;
    using Microsoft.Rest.Azure;

    internal static class EnumerateExtenions
    {
        internal static IEnumerable Enumerate(this IOperations operations)
        {
            return Enumerate(() => operations.List(), link => operations.ListNext(link));
        }

        internal static IEnumerable EnumerateBySubscription(this ISpatialAnchorsAccountsOperations operations)
        {
            return Enumerate(() => operations.ListBySubscription(), link => operations.ListBySubscriptionNext(link));
        }

        internal static IEnumerable EnumerateByResourceGroup(this ISpatialAnchorsAccountsOperations operations, string resourceGroupName)
        {
            return Enumerate(() => operations.ListByResourceGroup(resourceGroupName), link => operations.ListByResourceGroupNext(link));
        }

        private static IEnumerable Enumerate<T>(Func<IPage<T>> getFirstPage, Func<string, IPage<T>> getNextPage)
        {
            for (var page = getFirstPage(); page != null; page = !string.IsNullOrWhiteSpace(page.NextPageLink) ? getNextPage(page.NextPageLink) : null)
            {
                foreach (var item in page)
                {
                    yield return item;
                }
            }
        }
    }
}
