// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.CoreWCF.Azure.StorageQueues.Samples
{
    public class Service : IService
    {
        public void SendData(int value)
        {
        }

        public void SendDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException(nameof(composite));
            }
        }
    }
}
