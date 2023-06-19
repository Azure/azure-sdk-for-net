// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    public partial class QueueServiceStatistics
    {
        internal static QueueServiceStatistics DeserializeQueueServiceStatistics(XElement element)
        {
            QueueGeoReplication geoReplication = default;
            if (element.Element("GeoReplication") is XElement geoReplicationElement)
            {
                geoReplication = QueueGeoReplication.DeserializeQueueGeoReplication(geoReplicationElement);
            }
            return new QueueServiceStatistics(geoReplication);
        }
    }
}
