using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Windows.Azure.Management.v1_7;

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
            this.TokenSource = new CancellationTokenSource();
            this.TestClient = Utilities.CreateAzureHttpClient();
        }

        [TestCleanup]
        public void BaseCleanup()
        {
            if (this.TokenSource != null)
            {
                this.TokenSource.Dispose();
                this.TokenSource = null;
            }

            if (this.TestClient != null)
            {
                this.TestClient.Dispose();
                this.TestClient = null;
            }
        }

        public CancellationTokenSource TokenSource { get; private set; }

        public AzureHttpClient TestClient { get; private set; }

    }
}
