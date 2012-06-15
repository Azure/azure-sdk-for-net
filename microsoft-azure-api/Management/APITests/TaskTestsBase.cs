using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Microsoft.WindowsAzure.ManagementClient.v1_7;

namespace APITests
{
    [TestClass]
    public abstract class TaskTestsBase
    {
        public TaskTestsBase()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize]
        public void BaseInit()
        {
            TokenSource = new CancellationTokenSource();
            TestClient = Utilities.CreateAzureHttpClient();
        }

        [TestCleanup]
        public void BaseCleanup()
        {
            if (TokenSource != null)
            {
                TokenSource.Dispose();
                TokenSource = null;
            }

            if (TestClient != null)
            {
                TestClient.Dispose();
                TestClient = null;
            }
        }

        public CancellationTokenSource TokenSource { get; private set; }

        public AzureHttpClient TestClient { get; private set; }

    }
}
