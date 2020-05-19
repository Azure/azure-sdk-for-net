// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables.Queryable
{
    internal enum ResourceExpressionType
    {
        RootResourceSet = 10000,
        ResourceNavigationProperty,
        ResourceNavigationPropertySingleton,
        TakeQueryOption,
        SkipQueryOption,
        OrderByQueryOption,
        FilterQueryOption,
        InputReference,
        ProjectionQueryOption,
        RequestOptions,
        OperationContext,
        Resolver,
    }
}
