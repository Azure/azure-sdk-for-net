// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables.Queryable
{
    internal class SR
    {
        public const string TableQueryTypeMustHaveDefaultParameterlessCtor = "TableQuery Generic Type must provide a default parameterless constructor.";

        // Table IQueryable Exception messages
        public const string ALinqCouldNotConvert = "Could not convert constant {0} expression to string.";
        public const string ALinqCantCastToUnsupportedPrimitive = "Can't cast to unsupported type '{0}'";
        public const string ALinqCantTranslateExpression = "The expression {0} is not supported.";
        public const string ALinqCantReferToPublicField = "Referencing public field '{0}' not supported in query option expression.  Use public property instead.";
        public const string IQueryableExtensionObjectMustBeTableQuery = "Query must be a TableQuery<T>";
    }
}
