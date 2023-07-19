// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;

namespace Azure.Data.Tables
{
    internal class TablesRequestContext : RequestContext
    {
        public static int[] NotFound = new[] { (int)HttpStatusCode.NotFound };
        public static int[] Conflict = new[] { (int)HttpStatusCode.Conflict };
        public static TablesRequestContext Default = new();
        public static TablesRequestContext CreateIfNotExists = new(NotFound);
        public static TablesRequestContext AddEntity = new(Conflict) { ErrorOptions = ErrorOptions.NoThrow };

        public TablesRequestContext()
        { }

        public TablesRequestContext(int[] noErrorStatusCodes)
        {
            foreach (int statusCode in noErrorStatusCodes)
            {
                AddClassifier(statusCode, false);
            }
        }
    }
}
