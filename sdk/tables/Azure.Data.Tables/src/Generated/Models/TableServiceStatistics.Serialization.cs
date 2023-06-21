// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml.Linq;
using Azure.Core;

namespace Azure.Data.Tables.Models
{
    public partial class TableServiceStatistics
    {
        internal static TableServiceStatistics DeserializeTableServiceStatistics(XElement element)
        {
            TableGeoReplicationInfo geoReplication = default;
            if (element.Element("GeoReplication") is XElement geoReplicationElement)
            {
                geoReplication = TableGeoReplicationInfo.DeserializeTableGeoReplicationInfo(geoReplicationElement);
            }
            return new TableServiceStatistics(geoReplication);
        }
    }
}
