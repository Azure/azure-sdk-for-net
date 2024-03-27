// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET6_0_OR_GREATER
using System.ServiceModel;
using System.Threading;

namespace Contracts
{
    [ServiceContract]
    public interface ITestContract_EndToEndTest
    {
        [OperationContract(IsOneWay = true)]
        void Create(string name);
    }

    public class TestService_EndToEnd : ITestContract_EndToEndTest
    {
        public TestService_EndToEnd()
        {
            ManualResetEvent = new ManualResetEventSlim(false);
        }

        public void Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new FaultException();
            ReceivedName = name;
            ManualResetEvent.Set();
        }

        public string ReceivedName { get; set; }

        public ManualResetEventSlim ManualResetEvent { get; }
    }
}
#endif