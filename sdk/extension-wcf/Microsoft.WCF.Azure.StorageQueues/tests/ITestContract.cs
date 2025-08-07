// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel;
using System.Threading;

namespace Contracts
{
    [ServiceContract]
    public interface ITestContract
    {
        [OperationContract(IsOneWay = true)]
        void Create(string name);
    }

    public class TestService : ITestContract
    {
        public TestService()
        {
            ManualResetEvent = new ManualResetEventSlim(false);
        }

        public void Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new FaultException();

            ManualResetEvent.Set();
        }

        public ManualResetEventSlim ManualResetEvent { get; }
    }
}
