// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables.Queryable
{
    internal static class XmlConstants
    {
        internal const string MimeApplicationXml = "application/xml";
        internal const string DataServiceVersion3Dot0 = "3.0";
        internal const string DataServiceVersionCurrent = DataServiceVersion3Dot0 + ";";
        internal const string LiteralPrefixDateTime = "datetime";
        internal const string LiteralPrefixGuid = "guid";
        internal const char XmlBinaryPrefix = 'X';
        internal const string XmlDecimalLiteralSuffix = "M";
        internal const string XmlInt64LiteralSuffix = "L";
        internal const string XmlSingleLiteralSuffix = "f";
        internal const string TableItemServicePropertyName = "TableName";
        internal const string TableItemClientPropertyName = "Name";
    }
}
