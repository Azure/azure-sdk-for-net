// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator;

    public class TestsBase : DisposableObject
    {
        public TestsBase()
        {
            var underlying = new HttpClientAbstractionFactory();
            this.factory = new HttpAbstractionSimulatorFactory(underlying);
        }

        private HttpAbstractionSimulatorFactory factory;
        private bool httpSpyEnabled;

        public virtual void Initialize()
        {
            this.ApplyFullMocking();
            this.ResetIndividualMocks();
            this.httpSpyEnabled = false;
        }

        public virtual void TestCleanup()
        {
            this.ApplyFullMocking();
            this.ResetIndividualMocks();
            this.httpSpyEnabled = false;
        }

        protected void EnableHttpSpy()
        {
            var manager = ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>();
            manager.Override<IHttpClientAbstractionFactory>(this.factory);
            this.httpSpyEnabled = true;
        }

        internal void EnableHttpMock(Func<IHttpClientAbstraction, IHttpResponseMessageAbstraction> asyncMoc)
        {
            if (!this.httpSpyEnabled)
            {
                this.EnableHttpSpy();
            }
            this.factory.AsyncMock = asyncMoc;
        }

        protected void DisableHttpMock()
        {
            this.factory.AsyncMock = null;
        }

        protected void ClearHttpCalls()
        {
            this.factory.Clients.Clear();
        }

        internal IEnumerable<Tuple<IHttpClientAbstraction, IHttpResponseMessageAbstraction>> GetHttpCalls()
        {
            return this.factory.Clients;
        }

        public TestContext TestContext { get; set; }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Need secure string for pscredential object.")]
        protected static PSCredential GetPSCredential(string userName, string password)
        {
            var securePassword = new SecureString();

            foreach (var character in password)
            {
                securePassword.AppendChar(character);
            }

            return new PSCredential(userName, securePassword);
        }

        public void ApplyIndividualTestMockingOnly()
        {
            HDInsightClient.DefaultPollingInterval = TimeSpan.FromMinutes(1);
            var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            manager.MockingLevel = ServiceLocationMockingLevel.ApplyIndividualTestMockingOnly;
        }

        public void ResetIndividualMocks()
        {
            var manager = ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>();
            manager.Reset();
        }

        public void ApplySimulatorMockingOnly()
        {
            var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            manager.MockingLevel = ServiceLocationMockingLevel.ApplyTestRunMockingOnly;
        }

        public void ApplyFullMocking()
        {
            var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            manager.MockingLevel = ServiceLocationMockingLevel.ApplyFullMocking;
        }

        public void ApplyNoMocking()
        {
            HDInsightClient.DefaultPollingInterval = TimeSpan.FromMinutes(1);
            var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            manager.MockingLevel = ServiceLocationMockingLevel.ApplyNoMocking;
        }

        public static string GetRandomValidPassword()
        {
            return Guid.NewGuid().ToString().ToUpperInvariant().Replace('A', 'a').Replace('B', 'b').Replace('C', 'c') + "forTest!";
        }
    }
}