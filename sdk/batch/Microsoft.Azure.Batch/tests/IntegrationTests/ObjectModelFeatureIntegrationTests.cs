// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.FileStaging;
    using IntegrationTestUtilities;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using Microsoft.Azure.Batch.Protocol.BatchRequests;
    using Newtonsoft.Json;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol = Microsoft.Azure.Batch.Protocol;
    using System.Threading;

    [Collection("SharedPoolCollection")]
    public class ObjectModelFeatureIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(2);

        public ObjectModelFeatureIntegrationTests(ITestOutputHelper testOutputHelper, PaasWindowsPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug957878SkipTokenSupportMissing()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                int numTasksCreated = 0;
                string jobId = "bug957898Job-" + TestUtilities.GetMyName();

                try
                {
                    CloudJob jobCreate = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    jobCreate.Commit();

                    CloudJob theJob = batchCli.JobOperations.GetJob(jobId);

                    for (int i = 0; i < 50; i++)
                    {
                        CloudTask curTask = new CloudTask("bug957878-task-" + i.ToString(), "hostname");

                        theJob.AddTask(curTask);

                        numTasksCreated++;
                    }

                    int numTasksSeen = 0;

                    // test replacement interceptor and forces MaxResults to a low #
                    Bug957878ReplacementInterceptorBox box0 = new Bug957878ReplacementInterceptorBox(testOutputHelper);

                    foreach (CloudTask curTask in theJob.ListTasks(additionalBehaviors: new[] {
                            new Protocol.RequestReplacementInterceptor(box0.Bug957878RequestReplacementInterceptorOpContextFactory)}))
                    {
                        numTasksSeen++;

                        testOutputHelper.WriteLine("    Task_Id: " + curTask.Id);
                    }

                    // confirm we'v seen the correct # of tasks during enumeration
                    Assert.Equal(numTasksCreated, numTasksSeen);

                    // confirm we got the correct # of chunks...
                    Assert.True(box0.NumTimesCalled >= 10);

                    // >= because the server might hickup too and put in extra empty skiptokens

                    testOutputHelper.WriteLine("total tasks created: " + numTasksCreated.ToString());
                    testOutputHelper.WriteLine("total tasks enumerated: " + numTasksSeen.ToString());

                    Assert.Equal(numTasksCreated, numTasksSeen);

                    // tests performed elsewhere
                    // list task files
                    // list job schedules
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug1568799IEnumerableAsyncCannotBeIteratedAgain()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "Bug1568799Job-" + TestUtilities.GetMyName();
                try
                {
                    CloudJob newJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    newJob.Commit();

                    // now we have at least one JS (and pool).  double-enumerate them
                    IEnumerable<CloudJob> jobEnum = batchCli.JobOperations.ListJobs();
                    // populating the List enumerates once
                    List<CloudJob> jobList0 = new List<CloudJob>(jobEnum);

                    // enumerate via the List's enumerator
                    bool foundViaList0 = FoundJob(jobId, jobList0);

                    Assert.True(foundViaList0);

                    // use original enumerator to find js again
                    bool foundViaEnumeration = FoundJob(jobId, jobEnum);

                    Assert.True(foundViaEnumeration);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1719609ODATADetailLevel()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                // pools tested in Bug1770942ExposeBatchRequestProperties
                testOutputHelper.WriteLine("job schedule tests");

                // create a bunch of job schedules
                {
                    const int numJobSchedulesToCreate = 10;

                    List<string> jobScheduleIds = new List<string>();
                    for (int i = 0; i < numJobSchedulesToCreate; i++)
                    {
                        string id;

                        if (1 == (i % 2))
                        {
                            id = "Odd-Bug1770942-";
                        }
                        else
                        {
                            id = "Even-Bug1770942-";
                        }

                        // add my name for visibile accounting
                        id += i + "-" + TestUtilities.GetMyName();

                        jobScheduleIds.Add(id);
                    }

                    try
                    {
                        foreach (string jobScheduleId in jobScheduleIds)
                        {
                            CloudJobSchedule unboundJobSchedule = batchCli.JobScheduleOperations.CreateJobSchedule(jobScheduleId, null, null);
                            PoolInformation poolInformation = new PoolInformation();

                            poolInformation.PoolId = poolFixture.PoolId;

                            unboundJobSchedule.JobSpecification = new JobSpecification(poolInformation);

                            unboundJobSchedule.Schedule = new Schedule() { RecurrenceInterval = TimeSpan.FromMinutes(5) };

                            // create the job schedule
                            unboundJobSchedule.Commit();
                        }

                        // first get a list of all wi's with all props
                        IEnumerable<CloudJobSchedule> ienumJobScheduleAllProps = batchCli.JobScheduleOperations.ListJobSchedules();
                        List<CloudJobSchedule> listAllJobScheduleProps = new List<CloudJobSchedule>(ienumJobScheduleAllProps);

                        // get filtered lists using lower Detail Level
                        IEnumerable<CloudJobSchedule> ienumOdd =
                            batchCli.JobScheduleOperations.ListJobSchedules(detailLevel:
                                new ODATADetailLevel() { FilterClause = "startswith(id, 'Odd')", SelectClause = "id,state" });
                        List<CloudJobSchedule> listOdd = new List<CloudJobSchedule>(ienumOdd);

                        IEnumerable<CloudJobSchedule> ienumEven =
                            batchCli.JobScheduleOperations.ListJobSchedules(detailLevel:
                                new ODATADetailLevel() { FilterClause = "startswith(id, 'Even')", SelectClause = "id,state" });
                        List<CloudJobSchedule> listEven = new List<CloudJobSchedule>(ienumEven);

                        // confirm detail level worked

                        // pick one
                        CloudJobSchedule lowDetailLevelJobSchedule = listEven[0];
                        CloudJobSchedule matchingAllPropJobSchedule = null;

                        // find it in the list that has full props
                        foreach (CloudJobSchedule currJobSchedule in listAllJobScheduleProps)
                        {
                            // found it
                            if (currJobSchedule.Id.Equals(lowDetailLevelJobSchedule.Id, StringComparison.InvariantCultureIgnoreCase))
                            {
                                matchingAllPropJobSchedule = currJobSchedule;

                                Assert.NotEqual(currJobSchedule.CreationTime, lowDetailLevelJobSchedule.CreationTime);
                            }
                        }

                        // confirm that a match was found
                        Assert.NotNull(matchingAllPropJobSchedule);

                        // confirm that detail level works on jobScheduleOperations.GetJobSchedule()
                        CloudJobSchedule directGetLowDetailLevel = batchCli.JobScheduleOperations.GetJobSchedule(matchingAllPropJobSchedule.Id,
                            new ODATADetailLevel() { SelectClause = "id,state" });

                        Assert.NotEqual(matchingAllPropJobSchedule.CreationTime, directGetLowDetailLevel.CreationTime);

                        // confirm that detail level can be returned to normal via refresh()
                        directGetLowDetailLevel.Refresh(); // no detail level returns to full properties

                        Assert.Equal(matchingAllPropJobSchedule.CreationTime, directGetLowDetailLevel.CreationTime);
                    }
                    finally
                    {
                        List<Task> jobScheduleDeletions = new List<Task>();
                        foreach (string id in jobScheduleIds)
                        {
                            Task t = TestUtilities.DeleteJobScheduleIfExistsAsync(batchCli, id);
                            jobScheduleDeletions.Add(t);
                        }

                        Task.WhenAll(jobScheduleDeletions).Wait();
                    }
                }

                testOutputHelper.WriteLine("job tests");

                // jobs
                string jobId = "Bug1770942Job-" + TestUtilities.GetMyName();

                try
                {
                    {
                        // create a job
                        CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                        unboundJob.PoolInformation.PoolId = poolFixture.PoolId;
                        unboundJob.Commit();
                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                        CloudTask unboundTask = new CloudTask("Bug1770942Taskname", "hostname");
                        boundJob.AddTask(unboundTask);

                        string filterString = string.Format("startswith(id, '{0}')", jobId);

                        // first get a list with all props
                        IEnumerable<CloudJob> ienumAllProps = batchCli.JobOperations.ListJobs(detailLevel: new ODATADetailLevel() { FilterClause = filterString });
                        List<CloudJob> listAllProps = new List<CloudJob>(ienumAllProps);

                        // get list using lower Detail Level.  choose a predicate that will return no jobs since there is only the one :(
                        IEnumerable<CloudJob> iEnumFewerProps = batchCli.JobOperations.ListJobs(detailLevel: new ODATADetailLevel() { SelectClause = "id,state", FilterClause = filterString });
                        List<CloudJob> listFewerProps = new List<CloudJob>(iEnumFewerProps);

                        // the total must equal the sum of the parts
                        Assert.Equal(listFewerProps.Count, listAllProps.Count);

                        // confirm detail level worked

                        // get the low detail level object
                        CloudJob lowDetailLevel = listFewerProps.Single();

                        // yes its the same and only
                        Assert.Equal(listAllProps[0].Id, lowDetailLevel.Id);

                        // confirm detail levels different
                        Assert.NotEqual(listAllProps[0].CreationTime, lowDetailLevel.CreationTime);

                        // confirm detail level returned to normal via refresh
                        lowDetailLevel.Refresh();

                        // now they both have all props
                        Assert.Equal(listAllProps[0].CreationTime, lowDetailLevel.CreationTime);

                        // confirm refresh can lower detail level
                        lowDetailLevel = batchCli.JobOperations.GetJob(lowDetailLevel.Id);  // cant refresh 2 times or more because that pesky bug on refresh
                        Assert.Equal(listAllProps[0].CreationTime, lowDetailLevel.CreationTime);  // so all props are loaded

                        // refresh and lower DL
                        lowDetailLevel.Refresh(detailLevel: new ODATADetailLevel() { SelectClause = "id,state" });

                        // now they must be different
                        Assert.NotEqual(listAllProps[0].CreationTime, lowDetailLevel.CreationTime);
                    }

                    testOutputHelper.WriteLine("task tests");

                    // tasks
                    {
                        // push tasks to this job
                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                        // add a bunch of tasks
                        const int numToCreate = 10;

                        for (int i = 0; i < numToCreate; i++)
                        {
                            string id;

                            if (1 == (i % 2))
                            {
                                id = "Odd-Bug1770942-";
                            }
                            else
                            {
                                id = "Even-Bug1770942-";
                            }

                            // add my name for visibile accounting
                            id += i + "-" + TestUtilities.GetMyName();

                            CloudTask unboundTask = new CloudTask(id, "cmd /c hostname");

                            // add the task
                            boundJob.AddTask(unboundTask);
                        }

                        // first get a list with all props
                        IEnumerable<CloudTask> ienumAllProps = boundJob.ListTasks();
                        List<CloudTask> listAllProps = new List<CloudTask>(ienumAllProps);

                        // get filtered lists using lower Detail Level
                        IEnumerable<CloudTask> ienumOdd = boundJob.ListTasks(detailLevel: new ODATADetailLevel() { FilterClause = "startswith(id, 'Odd')", SelectClause = "id,state" });
                        List<CloudTask> listOdd = new List<CloudTask>(ienumOdd);

                        IEnumerable<CloudTask> ienumEven = boundJob.ListTasks(detailLevel: new ODATADetailLevel() { FilterClause = "startswith(id, 'Even')", SelectClause = "id,state" });
                        List<CloudTask> listEven = new List<CloudTask>(ienumEven);

                        // the total must equal the sum of the parts
                        Assert.Equal(listOdd.Count + listEven.Count + 1 /* 1 special task from above */, listAllProps.Count);

                        // confirm detail level worked
                        // pick one from lower detail level and compare it to the same one from the all-props collection

                        CloudTask lowerDetailTask = listOdd[0];
                        CloudTask matchingAllPropsTask = null;

                        // now find it in the all-props list
                        foreach (CloudTask curAllPropsTask in listAllProps)
                        {
                            if (curAllPropsTask.Id.Equals(lowerDetailTask.Id))
                            {
                                matchingAllPropsTask = curAllPropsTask;
                            }
                        }

                        // we have a matching all-props instance... compare them.
                        Assert.NotNull(matchingAllPropsTask);

                        // see!  detail level works!
                        Assert.NotEqual(matchingAllPropsTask.CreationTime, lowerDetailTask.CreationTime);

                        // now confirm that refresh will raise detail level
                        lowerDetailTask.Refresh();

                        // they should be the same now
                        Assert.Equal(matchingAllPropsTask.CreationTime, lowerDetailTask.CreationTime);

                        // now confirm that refresh + detail level can lower detail level
                        matchingAllPropsTask.Refresh(detailLevel: new ODATADetailLevel() { SelectClause = "id,state" });

                        // confirm lower detail level
                        Assert.NotEqual(lowerDetailTask.CreationTime, matchingAllPropsTask.CreationTime);
                    }

                    // task files
                    testOutputHelper.WriteLine("task file tests");

                    {
                        List<CloudTask> tasks = new List<CloudTask>(batchCli.JobOperations.GetJob(jobId).ListTasks());
                        CloudTask task = tasks[0]; // just pick one it doesnt matter which

                        //Ensure that the task has run
                        TaskStateMonitor tsm = batchCli.Utilities.CreateTaskStateMonitor();
                        tsm.WaitAll(new List<CloudTask> { task }, TaskState.Completed, TimeSpan.FromSeconds(20));

                        // first get a list with all props
                        IEnumerable<NodeFile> ienumAllProps = task.ListNodeFiles();
                        List<NodeFile> listAllProps = new List<NodeFile>(ienumAllProps);

                        // get filtered lists using lower Detail Level
                        IEnumerable<NodeFile> ienumStd = task.ListNodeFiles(detailLevel: new ODATADetailLevel() { FilterClause = "startswith(name, 'std')" });
                        List<NodeFile> listStd = new List<NodeFile>(ienumStd);

                        // assert that filtering works
                        Assert.Equal(2, listStd.Count);  // stdout/stderr
                        Assert.True(listAllProps.Count > listStd.Count);

                        // test nodefile refresh

                        NodeFile stdoutFile = null;

                        // find stdout
                        listStd.ForEach(x => { if (x.Path.IndexOf("stdout", StringComparison.InvariantCultureIgnoreCase) >= 0) { stdoutFile = x; } });

                        // save pre-refresh props
                        FileProperties saveFilProps = stdoutFile.Properties;

                        // refesh to see if the props come back
                        stdoutFile.Refresh();

                        NodeFile againViaList = null;

                        new List<NodeFile>(task.ListNodeFiles()).ForEach(x => { if (x.Path.IndexOf("stdout", StringComparison.InvariantCultureIgnoreCase) >= 0) { againViaList = x; } });

                        //"Bug1719609ODATADetailLevel: sometimes this can fail.  check out CreateTime"
                        //This fails due to different time formats used in the header vs in the body of a request.  Since we expect that this will basically never pass
                        //until the bug is fixed, we assert instead on only the upper-order digits of the DateTime

                        //Assert.Equal(stdoutFile.Properties.CreationTime, saveFilProps.CreationTime);
                        DateTime creationTime = saveFilProps.CreationTime.Value;
                        DateTime refreshedCreationTime = stdoutFile.Properties.CreationTime.Value;

                        Assert.Equal(DateTimeKind.Utc, refreshedCreationTime.Kind);

                        Assert.Equal(creationTime.Year, refreshedCreationTime.Year);
                        Assert.Equal(creationTime.Month, refreshedCreationTime.Month);
                        Assert.Equal(creationTime.Day, refreshedCreationTime.Day);
                        Assert.Equal(creationTime.Hour, refreshedCreationTime.Hour);
                        Assert.Equal(creationTime.Minute, refreshedCreationTime.Minute);
                        Assert.Equal(creationTime.Second, refreshedCreationTime.Second);
                        Assert.Equal(creationTime.Kind, refreshedCreationTime.Kind);

                        //Since the low order bits are lost in the GetFile (header based respose) assert that they are 0
                        Assert.Equal(0, refreshedCreationTime.Millisecond);
                    }
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1996130_ResourceDoubleRefreshDoesntWork()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                const string testName = "Bug1996130_ResourceDoubleRefreshDoesntWork";
                const string taskId = "Bug1996130_ResourceDoubleRefreshDoesntWork_Task1";

                string jobScheduleId = Microsoft.Azure.Batch.Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-" + testName;
                try
                {
                    //
                    // Create the job schedule
                    //
                    CloudJobSchedule jobSchedule = batchCli.JobScheduleOperations.CreateJobSchedule(jobScheduleId, null, null);
                    jobSchedule.JobSpecification = new JobSpecification(new PoolInformation()
                    {
                        PoolId = poolFixture.PoolId
                    });
                    jobSchedule.Schedule = new Schedule() { RecurrenceInterval = TimeSpan.FromMinutes(1) };

                    testOutputHelper.WriteLine("Initial job schedule commit()");
                    jobSchedule.Commit();

                    //Get the bound job schedule
                    CloudJobSchedule boundJobSchedule = TestUtilities.WaitForJobOnJobSchedule(batchCli.JobScheduleOperations, jobScheduleId);

                    //Get the job
                    CloudJob boundJob = batchCli.JobOperations.GetJob(boundJobSchedule.ExecutionInformation.RecentJob.Id);
                    string jobId = boundJob.Id; //We have to store this because after we commit we can't access the name anymore...

                    CloudTask myTask = new CloudTask(taskId, "cmd /c echo hello world");

                    //Add the task
                    testOutputHelper.WriteLine("Adding task: {0}", taskId);
                    boundJob.AddTask(myTask);

                    //Get the task
                    CloudTask boundTask = batchCli.JobOperations.GetTask(jobId, taskId);

                    //Wait for the task to complete

                    TaskStateMonitor stateMonitor = batchCli.Utilities.CreateTaskStateMonitor();
                    stateMonitor.WaitAll(new List<CloudTask> { boundTask }, TaskState.Completed, TimeSpan.FromMinutes(2));

                    //Try to refresh the job schedule multiple times
                    testOutputHelper.WriteLine("Refreshing job schedule");
                    boundJobSchedule.Refresh();
                    testOutputHelper.WriteLine("Refreshing job schedule");
                    boundJobSchedule.Refresh();

                    //Try to refresh the job multiple times
                    testOutputHelper.WriteLine("Refreshing job");
                    boundJob.Refresh();
                    testOutputHelper.WriteLine("Refreshing job");
                    boundJob.Refresh();

                    //Try to refresh the task multiple times
                    testOutputHelper.WriteLine("Refreshing task");
                    boundTask.Refresh();
                    testOutputHelper.WriteLine("Refreshing task");
                    boundTask.Refresh();

                    //Try to refresh a file multiple times
                    NodeFile nodeFile = boundTask.GetNodeFile("stdout.txt");

                    testOutputHelper.WriteLine("Refreshing task file");
                    nodeFile.Refresh();
                    testOutputHelper.WriteLine("Refreshing task file");
                    nodeFile.Refresh();

                    //Try to refresh the pool multiple times
                    CloudPool boundPool = batchCli.PoolOperations.GetPool(poolFixture.PoolId);

                    testOutputHelper.WriteLine("Refreshing pool");
                    boundPool.Refresh();
                    testOutputHelper.WriteLine("Refreshing pool");
                    boundPool.Refresh();
                    //Try to refresh a compute node multiple times
                    ComputeNode computeNode = boundPool.ListComputeNodes().First();

                    testOutputHelper.WriteLine("Refreshing compute node");
                    computeNode.Refresh();
                    testOutputHelper.WriteLine("Refreshing compute node");
                    computeNode.Refresh();

                    //Try to refresh a node file multiple times
                    //NodeFile nodeFile = computeNode.GetNodeFile("startup/stdout.txt");

                    //this.testOutputHelper.WriteLine("Refreshing vm file");
                    //nodeFile.Refresh();
                    //this.testOutputHelper.WriteLine("Refreshing vm file");
                    //nodeFile.Refresh();

                    //TODO: Add certificate refreshes here

                }
                finally
                {
                    batchCli.JobScheduleOperations.DeleteJobSchedule(jobScheduleId);
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void CommitFollowedByRefreshTest()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                const string testName = "PostCommitInvalidPropRouterTests";

                JobScheduleOperations jobScheduleOperations = batchCli.JobScheduleOperations;
                JobOperations jobOperations = batchCli.JobOperations;

                // test bound job commit followed by refresh
                string jobScheduleId = testName + "-" + TestUtilities.GetMyName();

                try
                {
                    CloudJobSchedule unboundJobSchedule = jobScheduleOperations.CreateJobSchedule(jobScheduleId, null, null);
                    PoolInformation poolInformation = new PoolInformation();
                    poolInformation.PoolId = poolFixture.PoolId;
                    unboundJobSchedule.JobSpecification = new JobSpecification(poolInformation);
                    unboundJobSchedule.Schedule = new Schedule() { DoNotRunAfter = DateTime.UtcNow.AddDays(1) };
                    unboundJobSchedule.Commit();

                    CloudJobSchedule boundJobSchedule = TestUtilities.WaitForJobOnJobSchedule(jobScheduleOperations, jobScheduleId);
                    CloudJob boundJob = jobOperations.GetJob(boundJobSchedule.ExecutionInformation.RecentJob.Id);

                    boundJob.Constraints = new JobConstraints(TimeSpan.FromDays(1), 99);

                    // we have a bound job, we made an unimportant change, now commit it to mark the object as read only
                    boundJob.Commit();

                    // this used to throw
                    boundJob.Refresh();
                }
                finally
                {
                    TestUtilities.DeleteJobScheduleIfExistsAsync(batchCli, jobScheduleId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1959324TestCustomBehaviorWorksOnLists()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string bug1959324JobId = null;
                try
                {
                    int interceptorCount = 0; // count the # of times the interceptor is executed

                    // 2015.jul: in GA there is no SetOpCon interceptor and YieldInjector was removed and "the func" exposed
                    //batchClient.CustomBehaviors.Add(new SetOperationContext(Bug1959324SetOperationContext));  // this does not exist in GA
                    //batchClient.CustomBehaviors.Add(new YieldInjectionInterceptor(Bug1959324YieldInjectionInterceptor));  // this is now done by func replacement. see below
                    batchCli.CustomBehaviors.Add(new Protocol.RequestInterceptor((o) => { interceptorCount++; testOutputHelper.WriteLine("Test: random interceptor"); }));

                    string taskIdHello;

                    // do some setup... get a job with a task that has files
                    {
                        int preSetupCount = interceptorCount;

                        CloudPool sharedPool = batchCli.PoolOperations.GetPool(poolFixture.PoolId);

                        TestUtilities.HelloWorld(batchCli, testOutputHelper, sharedPool, out bug1959324JobId, out taskIdHello, deleteJob: false);

                        // confirm interceptor was executed
                        Assert.True(interceptorCount > preSetupCount);
                    }

                    // test jobOps.ListNodeFiles
                    testOutputHelper.WriteLine("ListNodeFiles");
                    int preListNodeFilesCount = interceptorCount;
                    var files = batchCli.JobOperations.ListNodeFiles(bug1959324JobId, taskIdHello, recursive: true).ToList();

                    // assert the interceptor was honored in the list... lists can get skiptokens so there migth be more than one call
                    Assert.True(interceptorCount > preListNodeFilesCount);

                    // test jobOps.ListJobs
                    testOutputHelper.WriteLine("ListJobs");
                    int preListJobsCount = interceptorCount;
                    var jobs = batchCli.JobOperations.ListJobs().ToList();

                    // assert the interceptor was honored in the list... lists can get skiptokens so there migth be more than one call
                    Assert.True(interceptorCount > preListJobsCount);

                    // test poolOps.ListPools
                    testOutputHelper.WriteLine("ListPools");
                    int preListPoolsCount = interceptorCount;
                    var pools = batchCli.PoolOperations.ListPools().ToList();

                    // assert the interceptor was honored in the list... lists can get skiptokens so there migth be more than one call
                    Assert.True(interceptorCount > preListPoolsCount);

                    testOutputHelper.WriteLine("GetJob Yield Injector test");

                    // this yield injector will mung the func to make a get job call
                    // with real arguments.  the call made in the test has arguments that
                    // would fail/throw.
                    void yieldInjectionInterceptor(Protocol.IBatchRequest baseRequest)
                    {
                        testOutputHelper.WriteLine("Yield Injector!");

                        var request =
                            (JobGetBatchRequest)baseRequest;

                        // replace the func with one that actually will work
                        request.ServiceRequestFunc = (token) => { return request.RestClient.Job.GetWithHttpMessagesAsync(bug1959324JobId, request.Options, cancellationToken: token); };

                        // the func has been replaced with one that will work.. and the caller will get a real job
                        testOutputHelper.WriteLine("Leaving Yield Injector!");
                    }

                    CloudJob boundJob = batchCli.JobOperations.GetJob(
                                        "test value that can't possibly be found as a job id",
                                        additionalBehaviors: new[] { new Protocol.RequestInterceptor(yieldInjectionInterceptor) });

                    testOutputHelper.WriteLine("Done. got job.");

                    // confirm the job has a real id from HelloWorld not the bad one passed in

                    Assert.Equal(bug1959324JobId, boundJob.Id);
                }
                finally
                {
                    // cleanup
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, bug1959324JobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug1910530_ConcurrentChangeTrackedList()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                const string testName = "Bug1910530_ConcurrentChangeTrackedList";

                PoolOperations poolOperations = batchCli.PoolOperations;
                JobScheduleOperations jobScheduleOperations = batchCli.JobScheduleOperations;
                JobOperations jobOperations = batchCli.JobOperations;

                CloudJobSchedule boundJobSchedule = null;

                {
                    string jobScheduleId = Microsoft.Azure.Batch.Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-" + testName;
                    try
                    {
                        //
                        //Test bound pool properties
                        //
                        CloudPool pool = poolOperations.GetPool(poolFixture.PoolId);
                        pool.Metadata = new List<MetadataItem> { new MetadataItem("test", "test") };

                        //Note: We rely on the certificate specific tests to validate certificate references work for us

                        pool.Commit();

                        pool = poolOperations.GetPool(poolFixture.PoolId);

                        Assert.Equal(1, pool.Metadata.Count);

                        //
                        //Unbound job schedule properties
                        //
                        testOutputHelper.WriteLine("Creating job schedule {0}", jobScheduleId);
                        CloudJobSchedule unboundJobSchedule = jobScheduleOperations.CreateJobSchedule(jobScheduleId, null, null);

                        Assert.Null(unboundJobSchedule.Metadata);

                        unboundJobSchedule.Metadata = new List<MetadataItem>() { new MetadataItem("test", "test") };

                        //JobManagerTask
                        JobManagerTask jm = new JobManagerTask(id: "JobManagerTask", commandLine: "cmd /c dir");

                        Assert.Null(jm.ResourceFiles);
                        Assert.Null(jm.EnvironmentSettings);

                        jm.ResourceFiles = new List<ResourceFile> { ResourceFile.FromUrl("http://test", "test") };
                        jm.EnvironmentSettings = new List<EnvironmentSetting> { new EnvironmentSetting("test", "Test") };

                        //StartTask
                        StartTask startTask = new StartTask("cmd /c dir");

                        Assert.Null(startTask.ResourceFiles);
                        Assert.Null(startTask.EnvironmentSettings);

                        startTask.EnvironmentSettings = new List<EnvironmentSetting>() { new EnvironmentSetting("test", "test") };
                        startTask.ResourceFiles = new List<ResourceFile>() { ResourceFile.FromUrl("http://test", "Test") };

                        var ubuntuImageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

                        VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                            ubuntuImageDetails.ImageReference,
                            nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

                        //Pool Specification
                        PoolSpecification poolSpecification = new PoolSpecification()
                        {
                            TargetDedicatedComputeNodes = 0,
                            VirtualMachineSize = PoolFixture.VMSize,
                            VirtualMachineConfiguration = virtualMachineConfiguration,
                            StartTask = startTask
                        };

                        Assert.Null(poolSpecification.Metadata);
                        //Note: We rely on the certificate specific tests to validate certificate references work for us

                        poolSpecification.Metadata = new List<MetadataItem>() { new MetadataItem("test", "test") };

                        PoolInformation poolInformation = new PoolInformation()
                        {
                            AutoPoolSpecification = new AutoPoolSpecification()
                            {
                                KeepAlive = false,
                                PoolSpecification = poolSpecification,
                                PoolLifetimeOption = PoolLifetimeOption.JobSchedule
                            }
                        };

                        unboundJobSchedule.JobSpecification = new JobSpecification(poolInformation)
                        {
                            JobManagerTask = jm,
                        };

                        unboundJobSchedule.Schedule = new Schedule() { RecurrenceInterval = TimeSpan.FromMinutes(6) };

                        unboundJobSchedule.Commit();

                        testOutputHelper.WriteLine("Getting job schedule to ensure that IList properties were set correctly on server");
                        boundJobSchedule = jobScheduleOperations.GetJobSchedule(jobScheduleId);

                        Assert.Equal(1, boundJobSchedule.Metadata.Count);
                        Assert.Equal(1, boundJobSchedule.JobSpecification.JobManagerTask.EnvironmentSettings.Count);
                        Assert.Equal(1, boundJobSchedule.JobSpecification.JobManagerTask.ResourceFiles.Count);
                        Assert.Equal(1, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.Metadata.Count);
                        Assert.Equal(1, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.EnvironmentSettings.Count);
                        Assert.Equal(1, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.ResourceFiles.Count);

                        //
                        // Bound job schedule properties
                        //

                        //Testing addition to existing lists now
                        boundJobSchedule.Metadata.Add(new MetadataItem("abc", "abc"));
                        boundJobSchedule.JobSpecification.JobManagerTask.ResourceFiles.Add(ResourceFile.FromUrl("http://abc", "abc"));
                        boundJobSchedule.JobSpecification.JobManagerTask.EnvironmentSettings.Add(new EnvironmentSetting("abc", "abc"));
                        boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.Metadata.Add(new MetadataItem("abc", "abc"));
                        boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.EnvironmentSettings.Add(new EnvironmentSetting("abc", "abc"));
                        boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.ResourceFiles.Add(ResourceFile.FromUrl("http://abc", "abc"));

                        testOutputHelper.WriteLine("Commiting updated Job Schedule with more IList stuff added");
                        boundJobSchedule.Commit();

                        testOutputHelper.WriteLine("Getting job schedule to ensure that IList properties were set correctly on server");
                        boundJobSchedule = jobScheduleOperations.GetJobSchedule(jobScheduleId);


                        Assert.Equal(2, boundJobSchedule.Metadata.Count);
                        Assert.Equal(2, boundJobSchedule.JobSpecification.JobManagerTask.EnvironmentSettings.Count);
                        Assert.Equal(2, boundJobSchedule.JobSpecification.JobManagerTask.ResourceFiles.Count);
                        Assert.Equal(2, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.Metadata.Count);
                        Assert.Equal(2, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.EnvironmentSettings.Count);
                        Assert.Equal(2, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.ResourceFiles.Count);

                        //Choose some properties on the job schedule to set to null and ensure that works.

                        boundJobSchedule.Metadata = null;
                        boundJobSchedule.JobSpecification.JobManagerTask.ResourceFiles = null;
                        boundJobSchedule.JobSpecification.JobManagerTask.EnvironmentSettings = null;

                        testOutputHelper.WriteLine("Commiting updated Job Schedule with some IList stuff removed");
                        boundJobSchedule.Commit();

                        testOutputHelper.WriteLine("Getting job schedule to ensure that IList properties were removed correctly on server");
                        boundJobSchedule = jobScheduleOperations.GetJobSchedule(jobScheduleId);

                        Assert.Null(boundJobSchedule.Metadata);
                        Assert.Null(boundJobSchedule.JobSpecification.JobManagerTask.EnvironmentSettings);
                        Assert.Null(boundJobSchedule.JobSpecification.JobManagerTask.ResourceFiles);
                        Assert.Equal(2, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.Metadata.Count);
                        Assert.Equal(2, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.EnvironmentSettings.Count);
                        Assert.Equal(2, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.ResourceFiles.Count);

                        //Choose some properties on the job schedule to remove an item from, and ensure that works
                        boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.Metadata.RemoveAt(0);
                        boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.EnvironmentSettings.RemoveAt(1);

                        boundJobSchedule.Commit();

                        testOutputHelper.WriteLine("Getting job schedule to ensure that IList properties were removed correctly on server");
                        boundJobSchedule = TestUtilities.WaitForJobOnJobSchedule(jobScheduleOperations, jobScheduleId);

                        Assert.Null(boundJobSchedule.Metadata);
                        Assert.Null(boundJobSchedule.JobSpecification.JobManagerTask.EnvironmentSettings);
                        Assert.Null(boundJobSchedule.JobSpecification.JobManagerTask.ResourceFiles);
                        Assert.Equal(1, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.Metadata.Count);
                        Assert.Equal(1, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.EnvironmentSettings.Count);
                        //Extra check to ensure we removed the right one
                        Assert.Equal("abc", boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.Metadata.First().Name);
                        Assert.Equal("test", boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.EnvironmentSettings.First().Name);
                        Assert.Equal(2, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.ResourceFiles.Count);

                        //Now take a snapshot and ensure it isn't modified by editing the list after the fact
                        IList<ResourceFile> resourceFiles = boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.StartTask.ResourceFiles;

                        IEnumerator<ResourceFile> enumerator = resourceFiles.GetEnumerator();
                        int resourceFileCountBeforeListModification = 0;
                        int resourceFileCountAfterListModification = 0;
                        while (enumerator.MoveNext())
                        {
                            ++resourceFileCountBeforeListModification;
                        }

                        //Remove a file
                        ResourceFile resourceFile = resourceFiles[0];
                        resourceFiles.Remove(resourceFile);

                        enumerator.Reset();
                        while (enumerator.MoveNext())
                        {
                            ++resourceFileCountAfterListModification;
                        }

                        Assert.Equal(resourceFileCountBeforeListModification, resourceFileCountAfterListModification);

                        //
                        // Get the job and add a task
                        //
                        CloudTask unboundTask = new CloudTask("test", "cmd /c dir");
                        unboundTask.EnvironmentSettings = new List<EnvironmentSetting> { new EnvironmentSetting("foo", "baz") };

                        unboundTask.ResourceFiles = new List<ResourceFile> { ResourceFile.FromUrl("http://foo", "baz") };

                        CloudJob job = jobOperations.GetJob(boundJobSchedule.ExecutionInformation.RecentJob.Id);
                        job.AddTask(unboundTask);

                        const string taskId = "test";

                        //Get the bound task
                        CloudTask boundTask = job.GetTask(taskId);

                        Assert.NotNull(boundTask.ResourceFiles);
                        Assert.NotNull(boundTask.EnvironmentSettings);

                        //Ensure the task has the correct settings
                        Assert.Equal(1, boundTask.EnvironmentSettings.Count);
                        Assert.Equal(1, boundTask.ResourceFiles.Count);

                        TestUtilities.AssertThrows<InvalidOperationException>(() => boundTask.EnvironmentSettings.Add(new EnvironmentSetting("test", "test")));
                        TestUtilities.AssertThrows<InvalidOperationException>(() => boundTask.ResourceFiles.Add(ResourceFile.FromUrl("http://test", "test")));
                        TestUtilities.AssertThrows<InvalidOperationException>(() => { IList<IFileStagingProvider> filesToStage = boundTask.FilesToStage; });
                    }
                    finally
                    {
                        TestUtilities.DeleteJobScheduleIfExistsAsync(batchCli, jobScheduleId).Wait();
                    }
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestDisplayNameMutability()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                const string testName = "TestDisplayNameMutability";

                string originalDisplayName = "OriginalDisplayName";
                string updatedDisplayName = "UpdatedDisplayName";

                // Create an unbound job schedule with a job specification containing a pool sepcification and a job manager task.
                // Verify that their display names can be set.
                string jobScheduleId = testName + "_schedule_" + TestUtilities.GetMyName();
                CloudJobSchedule unboundJobSchedule = batchCli.JobScheduleOperations.CreateJobSchedule(jobScheduleId, null, null);
                unboundJobSchedule.DisplayName = originalDisplayName;


                Assert.Equal(originalDisplayName, unboundJobSchedule.DisplayName);

                JobManagerTask jobManager = new JobManagerTask("JobManagerTask", "cmd /c echo hello");
                jobManager.DisplayName = originalDisplayName;

                Assert.Equal(originalDisplayName, jobManager.DisplayName);

                PoolSpecification poolSpec = new PoolSpecification();

                var ubuntuImageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

                VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                    ubuntuImageDetails.ImageReference,
                    nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

                poolSpec.VirtualMachineConfiguration = virtualMachineConfiguration;
                poolSpec.TargetDedicatedComputeNodes = 0;
                poolSpec.VirtualMachineSize = PoolFixture.VMSize;
                poolSpec.DisplayName = originalDisplayName;

                Assert.Equal(originalDisplayName, poolSpec.DisplayName);

                AutoPoolSpecification autoPoolSpec = new AutoPoolSpecification();
                string autoPoolPrefix = "DisplayName" + TestUtilities.GetMyName(); ;
                autoPoolSpec.AutoPoolIdPrefix = autoPoolPrefix;
                autoPoolSpec.KeepAlive = false;
                autoPoolSpec.PoolLifetimeOption = PoolLifetimeOption.Job;
                autoPoolSpec.PoolSpecification = poolSpec;
                PoolInformation poolInfo = new PoolInformation();
                poolInfo.AutoPoolSpecification = autoPoolSpec;

                JobSpecification jobSpec = new JobSpecification(poolInfo);
                jobSpec.DisplayName = originalDisplayName;

                Assert.Equal(originalDisplayName, unboundJobSchedule.DisplayName);

                jobSpec.JobManagerTask = jobManager;

                unboundJobSchedule.JobSpecification = jobSpec;

                Schedule schedule = new Schedule();
                schedule.DoNotRunUntil = DateTime.Now.AddYears(1);
                unboundJobSchedule.Schedule = schedule;

                testOutputHelper.WriteLine("Creating job schedule {0}", jobScheduleId);
                unboundJobSchedule.Commit();

                try
                {
                    // Verify that display names were set
                    CloudJobSchedule boundJobSchedule = batchCli.JobScheduleOperations.GetJobSchedule(jobScheduleId);

                    Assert.Equal(originalDisplayName, boundJobSchedule.DisplayName);
                    Assert.Equal(originalDisplayName, boundJobSchedule.JobSpecification.DisplayName);
                    Assert.Equal(originalDisplayName, boundJobSchedule.JobSpecification.JobManagerTask.DisplayName);
                    Assert.Equal(originalDisplayName, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.DisplayName);

                    // Verify that job schedule display name cannot be set on bound, but sub property display names can
                    testOutputHelper.WriteLine("Attempting to set display names on job schedule, job specification, pool specification, and job manager task");

                    TestUtilities.AssertThrows<InvalidOperationException>(() => boundJobSchedule.DisplayName = updatedDisplayName);

                    boundJobSchedule.JobSpecification.DisplayName = updatedDisplayName;
                    boundJobSchedule.JobSpecification.JobManagerTask.DisplayName = updatedDisplayName;
                    boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.DisplayName = updatedDisplayName;

                    Assert.Equal(updatedDisplayName, boundJobSchedule.JobSpecification.DisplayName);
                    Assert.Equal(updatedDisplayName, boundJobSchedule.JobSpecification.JobManagerTask.DisplayName);
                    Assert.Equal(updatedDisplayName, boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.DisplayName);
                }
                finally
                {
                    testOutputHelper.WriteLine("Deleting job schedule {0}", jobScheduleId);
                    batchCli.JobScheduleOperations.DeleteJobSchedule(jobScheduleId);
                }

                // Create an unbound job and verify that display name can be set
                string jobId = testName + "_job_" + TestUtilities.GetMyName();
                CloudJob unboundJob = batchCli.JobOperations.CreateJob();
                unboundJob.Id = jobId;
                unboundJob.DisplayName = originalDisplayName;

                Assert.Equal(originalDisplayName, unboundJob.DisplayName);

                unboundJob.PoolInformation = new PoolInformation() { PoolId = poolFixture.PoolId };

                testOutputHelper.WriteLine("Creating job {0}", jobId);
                unboundJob.Commit();

                try
                {
                    // Verify that display name was set
                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                    Assert.Equal(originalDisplayName, boundJob.DisplayName);

                    // Verify that display name can not be set when bound
                    testOutputHelper.WriteLine("Attempting to set display name on job");
                    TestUtilities.AssertThrows<InvalidOperationException>(() => boundJob.DisplayName = updatedDisplayName);

                    // Create an unbound task and verify that display name can be set
                    string taskId = testName + "_task_" + TestUtilities.GetMyName();
                    CloudTask unboundTask = new CloudTask(taskId, "cmd /c echo hi");
                    unboundTask.DisplayName = originalDisplayName;

                    Assert.Equal(originalDisplayName, unboundTask.DisplayName);

                    testOutputHelper.WriteLine("Adding task {0} to job {1}", taskId, jobId);
                    boundJob.AddTask(unboundTask);

                    try
                    {
                        // Verify that display name was set
                        CloudTask boundTask = batchCli.JobOperations.GetTask(jobId, taskId);

                        Assert.Equal(originalDisplayName, boundTask.DisplayName);

                        // Verify that display name can not be set when bound
                        testOutputHelper.WriteLine("Attempting to set display name on task");
                        TestUtilities.AssertThrows<InvalidOperationException>(() => boundTask.DisplayName = updatedDisplayName);
                    }
                    finally
                    {
                        testOutputHelper.WriteLine("Deleting task {0}", taskId);
                        batchCli.JobOperations.DeleteTask(jobId, taskId);
                    }
                }
                finally
                {
                    testOutputHelper.WriteLine("Deleting job {0}", jobId);
                    batchCli.JobOperations.DeleteJob(jobId);
                }

                // Create an unbound pool and verify that display name can be set
                string poolId = testName + "_pool_" + TestUtilities.GetMyName();

                CloudPool unboundPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, virtualMachineConfiguration, 0);
                unboundPool.DisplayName = originalDisplayName;

                Assert.Equal(originalDisplayName, unboundPool.DisplayName);
                testOutputHelper.WriteLine("Creating pool {0}", poolId);
                unboundPool.Commit();

                try
                {
                    // Verify that display name was set
                    CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);

                    Assert.Equal(originalDisplayName, boundPool.DisplayName);

                    // Verify that display name can not be set when bound
                    testOutputHelper.WriteLine("Attempting to set display name on pool");

                    TestUtilities.AssertThrows<InvalidOperationException>(() => boundPool.DisplayName = updatedDisplayName);
                }
                finally
                {
                    testOutputHelper.WriteLine("Deleting pool {0}", poolId);
                    batchCli.PoolOperations.DeletePool(poolId);
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        #region Test helpers

        private static bool FoundJob(string jId, IEnumerable<CloudJob> jobs)
        {
            foreach (CloudJob currentJobSchedule in jobs)
            {
                if (currentJobSchedule.Id.Equals(jId))
                {
                    return true;
                }
            }

            return false;
        }

        private class Bug957878ReplacementInterceptorBox
        {
            public int NumTimesCalled { get; private set; }

            private readonly ITestOutputHelper testOutputHelper;

            public Bug957878ReplacementInterceptorBox(ITestOutputHelper testOutputHelper)
            {
                this.testOutputHelper = testOutputHelper;
            }

            /// <summary>
            ///  Tests request replacement and forces chunking by setting MaxResults to a low value.
            /// </summary>
            /// <param name="batchRequest"></param>
            internal void Bug957878RequestReplacementInterceptorOpContextFactory(ref Protocol.IBatchRequest batchRequest)
            {
                // been called again
                NumTimesCalled++;

                testOutputHelper.WriteLine("     _movenextAsync_call_to_server_");

                if (batchRequest is TaskListBatchRequest)
                {
                    var strongTypedBatchRequest = batchRequest as
                        TaskListBatchRequest;

                    strongTypedBatchRequest.Options.MaxResults = 5;
                }
            }
        }

        #endregion
    }

    public class IntegrationObjectModelFeatureTestsWithoutSharedPool
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);

        public IntegrationObjectModelFeatureTestsWithoutSharedPool(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        [Trait("Flaky", "true")]
        public void Bug1770942ExposeBatchRequestProperties()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                List<string> poolIdsToCreate = new List<string>();
                const int numPoolsToCreate = 10;

                // create some pools that can be listed and filtered
                for (int i = 0; i < numPoolsToCreate; i++)
                {
                    string name;

                    if (1 == (i % 2))
                    {
                        name = "Odd-Bug1770942-";
                    }
                    else
                    {
                        name = "Even-Bug1770942-";
                    }

                    // add my name for visibile accounting
                    name += i + "-" + TestUtilities.GetMyName();

                    poolIdsToCreate.Add(name);
                }

                try
                {
                    // Pool tests

                    // test custom retry policy per-call
                    {
                        var ubuntuImageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

                        VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                            ubuntuImageDetails.ImageReference,
                            nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

                        CloudPool unboundPool = batchCli.PoolOperations.CreatePool(
                            @"really/\bad+&*pool_^#name" + TestUtilities.GetMyName(),
                            PoolFixture.VMSize,
                           virtualMachineConfiguration,
                            targetDedicatedComputeNodes: 0);
                        Bug1770942RetryPolicy retryPolicy = new Bug1770942RetryPolicy(testOutputHelper);

                        // confirm there is a default retry policy
                        // EnforceThereIsOnlyOneRetry(unboundPool.CustomBehaviors);

                        // test perCall RetryPolicy
                        TestUtilities.AssertThrows<BatchException>(() => unboundPool.Commit(new[] { new RetryPolicyProvider(retryPolicy) }));

                        // confirm retry policy was used
                        Assert.Equal(3, retryPolicy.NumTimesCalled);
                    }

                    // test ListPools ODATA predicate
                    {
                        // create some pools that can be listed and filtered
                        foreach (string poolId in poolIdsToCreate)
                        {
                            var ubuntuImageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

                            VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                                ubuntuImageDetails.ImageReference,
                                nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

                            // no compute nodes because this is only a list/predicate test
                            CloudPool unboundPool = batchCli.PoolOperations.CreatePool(
                                poolId,
                                PoolFixture.VMSize,
                                virtualMachineConfiguration,
                                targetDedicatedComputeNodes: 0);

                            unboundPool.Commit();
                        }

                        testOutputHelper.WriteLine("All pools: ");

                        var allPools = batchCli.PoolOperations.ListPools();

                        TestUtilities.DisplayPools(testOutputHelper, allPools);

                        // get odd list, also test select
                        var oddIEnum =
                            batchCli.PoolOperations.ListPools(new ODATADetailLevel()
                            {
                                FilterClause = "startswith(id, 'Odd')",
                                SelectClause = "id,state"
                            });
                        List<CloudPool> oddList = new List<CloudPool>(oddIEnum);

                        testOutputHelper.WriteLine("Odd Pools:");

                        TestUtilities.DisplayPools(testOutputHelper, oddIEnum);

                        // get even list, also test select
                        var evenIEnum =
                            batchCli.PoolOperations.ListPools(new ODATADetailLevel()
                            {
                                FilterClause = "startswith(id, 'Even')",
                                SelectClause = "id,state"
                            });
                        List<CloudPool> evenList = new List<CloudPool>(evenIEnum);

                        testOutputHelper.WriteLine("Even Pools:");

                        TestUtilities.DisplayPools(testOutputHelper, evenIEnum);

                        Assert.Equal(numPoolsToCreate, (oddList.Count + evenList.Count));

                        // test that select worked

                        // pick one
                        CloudPool fewerDetails = oddList[0];
                        CloudPool matchingPoolWithFullDetailLevel = null;

                        // find in complete (which has no DetailLevel set and should have all props) list and compare detail level
                        foreach (CloudPool curPool in allPools)
                        {
                            if (curPool.Id.Equals(fewerDetails.Id, StringComparison.InvariantCultureIgnoreCase))
                            {
                                matchingPoolWithFullDetailLevel = curPool;

                                // confirm detail level is different between instances
                                Assert.NotEqual(curPool.AllocationState, fewerDetails.AllocationState);
                                break;
                            }
                        }

                        // confirm that a match was actually found.
                        Assert.NotNull(matchingPoolWithFullDetailLevel);

                        /////////////////////////////////////////////////////////////

                        // test select works on poolMgr.GetPool
                        // we have the matching instance with full props from list-all, and selected props from list+DetailLevel
                        // now test poolMgr.GetPool + detailLevel

                        Thread.Sleep(10000); // TODO: Remove this band-aid. It's just to give the operation more time before the following line, but this is a bad, flaky solution.
                        CloudPool lowerDetailLevel = batchCli.PoolOperations.GetPool(matchingPoolWithFullDetailLevel.Id, new ODATADetailLevel() { SelectClause = "id,state" });

                        // confirm that allocation state was not read in
                        Assert.Null(lowerDetailLevel.AllocationState);

                        matchingPoolWithFullDetailLevel.Refresh();

                        // confirm full props have good prop value
                        Assert.Equal(AllocationState.Steady, matchingPoolWithFullDetailLevel.AllocationState);

                        //////////////////////////////////////////////////////
                        //
                        // test that pool.Refresh() can change the detail level
                        // use "matching..." which has all props and "lowerDetailLevel" which has restricted props

                        matchingPoolWithFullDetailLevel.Refresh(detailLevel: new ODATADetailLevel() { SelectClause = "id,state" });

                        // confirm detail level is lower now
                        Assert.Null(matchingPoolWithFullDetailLevel.AllocationState);

                        // return to full props via refresh()

                        matchingPoolWithFullDetailLevel.Refresh();

                        Assert.Equal(AllocationState.Steady, matchingPoolWithFullDetailLevel.AllocationState);

                    }
                }
                finally
                {
                    // clean up
                    List<Task> deletePoolTasks = new List<Task>();
                    foreach (string poolId in poolIdsToCreate)
                    {
                        Task t = TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId);
                        deletePoolTasks.Add(t);
                    }

                    Task.WhenAll(deletePoolTasks).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact(Skip = "Currently swagger specification does not document all returned values from the service")]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestBatchClientWillErrorOnUnknownJsonProperties()
        {
            using BatchClient batchClient = await TestUtilities.OpenBatchClientFromEnvironmentAsync();
            Protocol.BatchServiceClient client = TestUtilities.GetServiceClient(batchClient);
            Assert.Equal(MissingMemberHandling.Error, client.DeserializationSettings.MissingMemberHandling);
        }

        #region Test helpers

        private class Bug1770942RetryPolicy : IRetryPolicy
        {
            public int NumTimesCalled { get; private set; }

            private readonly ITestOutputHelper testOutputHelper;

            public Bug1770942RetryPolicy(ITestOutputHelper testOutputHelper)
            {
                this.testOutputHelper = testOutputHelper;
            }

            /// <summary>
            /// Implementation of ShouldRetry from IRetryPolicy
            /// </summary>
            public Task<RetryDecision> ShouldRetryAsync(Exception exception, OperationContext operationContext)
            {
                TimeSpan retryInterval = TimeSpan.Zero;

                // count up retries to prove test works
                NumTimesCalled++;

                testOutputHelper.WriteLine("Bug1770942RetryPolicy exception:");
                testOutputHelper.WriteLine(exception.ToString());

                RetryDecision result;
                if (operationContext.RequestResults.Count < 3)
                {
                    result = RetryDecision.RetryWithDelay(retryInterval);
                }
                else
                {
                    result = RetryDecision.NoRetry;
                }

                return Task.FromResult(result);
            }
        }
        

        #endregion

    }
}
