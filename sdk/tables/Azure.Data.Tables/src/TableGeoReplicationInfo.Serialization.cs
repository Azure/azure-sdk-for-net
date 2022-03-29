// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Data.Tables.Models
{
    public partial class TableGeoReplicationInfo
    {
        internal static TableGeoReplicationInfo DeserializeTableGeoReplicationInfo(XElement element)
        {
            TableGeoReplicationStatus status = default;
            DateTimeOffset lastSyncedOn = default;
            if (element.Element("Status") is XElement statusElement)
            {
                status = new TableGeoReplicationStatus(statusElement.Value);
            }
            if (element.Element("LastSyncTime") is XElement lastSyncTimeElement)
            {
                // LastSyncTime can be empty (see https://docs.microsoft.com/en-us/rest/api/storageservices/get-table-service-stats#response-body)
                lastSyncedOn = (lastSyncTimeElement.Value.Length == 0) switch
                {
                    true => DateTimeOffset.MinValue,
                    false => lastSyncTimeElement.GetDateTimeOffsetValue("R")
                };
            }
            return new TableGeoReplicationInfo(status, lastSyncedOn);
        }
    }
}
