Generally speaking, every test method is written with a brief description and 4 test categories:
1)	The first test category defines which component to test in this method. The valid options are Auth/Core/RetryPolicies/Blob/Queue/Table.
2)	The second test category defines it’s a UnitTest or FunctionalTest. The valid options are are UnitTest/FunctionalTest/StressTest. 
3)	The third test category defines if it’s a smoke test. We need to at least run all smoke tests before checkin. The valid options are Smoke/NonSmoke. 
4)  The fourth test category defines the target test environments for this test case. Note that a test case can have up to 3 target test environments(DevStore/DevFabric/Cloud).
    The valid options are DevStore/DevFabric/Cloud.

The following is a test example. 
        [TestMethod]
        [Description("A test verifies all the constructor of the class StorageCredentials.")]
        [TestCategory("Auth")]
        [TestCategory("UnitTest")]
        [TestCategory("Smoke")]
		[TestCategory("DevStore"), TestCategory("DevFabric"), TestCategory("Cloud")]
        public void StorageCredentialsSampleTestMethod()
        {
			...
		}