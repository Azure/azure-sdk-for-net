// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    enum PartitionPumpStatus
    {
        Uninitialized,
        Opening,
        OpenFailed,
        Running,
        Errored,
        Closing,
        Closed
    }
}