// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.ServiceFabricProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Fabric;
    using System.Fabric.Health;

    class MockStatefulServicePartition : System.Fabric.IStatefulServicePartition
    {
        public void ReportLoad(IEnumerable<LoadMetric> metrics)
        {
            // nothing to do
        }

        #region unused
        // Unused
        public PartitionAccessStatus ReadStatus => throw new NotImplementedException();

        // Unused
        public PartitionAccessStatus WriteStatus => throw new NotImplementedException();

        // Unused
        public ServicePartitionInformation PartitionInfo => throw new NotImplementedException();

        public FabricReplicator CreateReplicator(IStateProvider stateProvider, ReplicatorSettings replicatorSettings)
        {
            // Unused
            throw new NotImplementedException();
        }

        public void ReportFault(FaultType faultType)
        {
            // Unused
            throw new NotImplementedException();
        }

        public void ReportMoveCost(MoveCost moveCost)
        {
            // Unused
            throw new NotImplementedException();
        }

        public void ReportPartitionHealth(HealthInformation healthInfo)
        {
            // Unused
            throw new NotImplementedException();
        }

        public void ReportPartitionHealth(HealthInformation healthInfo, HealthReportSendOptions sendOptions)
        {
            // Unused
            throw new NotImplementedException();
        }

        public void ReportReplicaHealth(HealthInformation healthInfo)
        {
            // Unused
            throw new NotImplementedException();
        }

        public void ReportReplicaHealth(HealthInformation healthInfo, HealthReportSendOptions sendOptions)
        {
            // Unused
            throw new NotImplementedException();
        }
        #endregion
    }
}
