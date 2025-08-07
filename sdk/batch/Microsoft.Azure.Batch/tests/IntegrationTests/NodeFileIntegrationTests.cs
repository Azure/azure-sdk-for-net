// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using IntegrationTestUtilities;
    using Xunit;
    using Xunit.Abstractions;

    [Collection("SharedPoolCollection")]
    public class NodeFileIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(2);

        public NodeFileIntegrationTests(ITestOutputHelper testOutputHelper, PaasWindowsPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1480489NodeFileMissingIsDirectory()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "Bug1480489Job-" + TestUtilities.GetMyName();

                try
                {
                    // here we show how to use an unbound Job + Commit() to run millions of Tasks
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    unboundJob.Commit();

                    // Open the new Job as bound.
                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                    CloudTask myTask = new CloudTask(id: "Bug1480489Task", commandline: @"md Bug1480489Directory");

                    // add the task to the job
                    boundJob.AddTask(myTask);

                    // wait for the task to complete
                    Utilities utilities = batchCli.Utilities;
                    TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                    taskStateMonitor.WaitAll(
                        boundJob.ListTasks(),
                        Microsoft.Azure.Batch.Common.TaskState.Completed,
                        TimeSpan.FromMinutes(3));

                    CloudTask myCompletedTask = new List<CloudTask>(boundJob.ListTasks(null))[0];

                    string stdOut = myCompletedTask.GetNodeFile(Constants.StandardOutFileName).ReadAsString();
                    string stdErr = myCompletedTask.GetNodeFile(Constants.StandardErrorFileName).ReadAsString();

                    testOutputHelper.WriteLine("TaskId: " + myCompletedTask.Id);
                    testOutputHelper.WriteLine("StdOut: ");
                    testOutputHelper.WriteLine(stdOut);

                    testOutputHelper.WriteLine("StdErr: ");
                    testOutputHelper.WriteLine(stdErr);

                    testOutputHelper.WriteLine("Task Files:");

                    bool foundAtLeastOneDir = false;

                    foreach (NodeFile curFile in myCompletedTask.ListNodeFiles())
                    {
                        testOutputHelper.WriteLine("    Filepath: " + curFile.Path);
                        testOutputHelper.WriteLine("       IsDirectory: " + curFile.IsDirectory.ToString());

                        // turns out wd is created for each task so use it as sentinal
                        if (curFile.Path.Equals("wd") && curFile.IsDirectory.HasValue && curFile.IsDirectory.Value)
                        {
                            foundAtLeastOneDir = true;
                        }
                    }

                    Assert.True(foundAtLeastOneDir);
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
        public void Bug230385SupportDeleteNodeFileByTask()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "Bug230285Job-" + TestUtilities.GetMyName();

                try
                {
                    const string taskId = "hiWorld";
                    const string directoryCreationTaskId1 = "dirTask1";
                    const string directoryCreationTaskId2 = "dirTask2";

                    const string directoryNameOne = "Foo";
                    const string directoryNameTwo = "Bar";

                    const string directory2PathOnNode = "wd/" + directoryNameTwo;

                    //
                    // Create the job
                    //
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    unboundJob.PoolInformation.PoolId = poolFixture.PoolId;
                    unboundJob.Commit();

                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                    CloudTask myTask = new CloudTask(taskId, "cmd /c echo hello world");
                    CloudTask directoryCreationTask1 = new CloudTask(directoryCreationTaskId1, string.Format("cmd /c mkdir {0} && echo test > {0}/testfile.txt", directoryNameOne));
                    CloudTask directoryCreationTask2 = new CloudTask(directoryCreationTaskId2, string.Format("cmd /c mkdir {0} && echo test > {0}/testfile.txt", directoryNameTwo));

                    boundJob.AddTask(myTask);
                    boundJob.AddTask(directoryCreationTask1);
                    boundJob.AddTask(directoryCreationTask2);

                    testOutputHelper.WriteLine("Initial job commit()");

                    //
                    // Wait for task to go to completion
                    //
                    Utilities utilities = batchCli.Utilities;
                    TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                    taskStateMonitor.WaitAll(
                            boundJob.ListTasks(),
                            Microsoft.Azure.Batch.Common.TaskState.Completed,
                            TimeSpan.FromMinutes(3));

                    //
                    // NodeFile delete
                    //

                    //Delete single file
                    NodeFile file = batchCli.JobOperations.GetNodeFile(jobId, taskId, Constants.StandardOutFileName);
                    file.Delete();

                    //Ensure delete succeeded
                    TestUtilities.AssertThrows<BatchException>(() => batchCli.JobOperations.GetNodeFile(jobId, taskId, Constants.StandardOutFileName));

                    //Delete directory

                    NodeFile directory = batchCli.JobOperations.ListNodeFiles(jobId, directoryCreationTaskId1, recursive: true).First(item => item.Path.Contains(directoryNameOne));
                    Assert.True(directory.IsDirectory);
                    TestUtilities.AssertThrows<BatchException>(() => directory.Delete(recursive: false));
                    directory.Delete(recursive: true);

                    Assert.Null(batchCli.JobOperations.ListNodeFiles(jobId, directoryCreationTaskId1, recursive: true).FirstOrDefault(item => item.Path.Contains(directoryNameOne)));

                    //
                    // JobScheduleOperations delete task file
                    //
                    batchCli.JobOperations.GetNodeFile(jobId, taskId, Constants.StandardErrorFileName);
                    batchCli.JobOperations.DeleteNodeFile(jobId, taskId, Constants.StandardErrorFileName);

                    //Ensure delete succeeded
                    TestUtilities.AssertThrows<BatchException>(() => batchCli.JobOperations.GetNodeFile(jobId, taskId, Constants.StandardErrorFileName));

                    //Delete directory
                    directory = batchCli.JobOperations.ListNodeFiles(jobId, directoryCreationTaskId2, recursive: true).First(item => item.Path.Contains(directoryNameTwo));
                    Assert.True(directory.IsDirectory);
                    TestUtilities.AssertThrows<BatchException>(() => batchCli.JobOperations.DeleteNodeFile(jobId, directoryCreationTaskId2, directory2PathOnNode, recursive: false));
                    batchCli.JobOperations.DeleteNodeFile(jobId, directoryCreationTaskId2, directory2PathOnNode, recursive: true);

                    Assert.Null(batchCli.JobOperations.ListNodeFiles(jobId, directoryCreationTaskId2, recursive: true).FirstOrDefault(item => item.Path.Contains(directoryNameTwo)));
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
        public void TestNode_GetListDeleteFiles()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "TestNodeGetListDeleteFiles-" + TestUtilities.GetMyName();

                try
                {
                    const string taskId = "hiWorld";

                    const string directoryCreationTaskId1 = "dirTask1";
                    const string directoryCreationTaskId2 = "dirTask2";

                    const string directoryNameOne = "Foo";
                    const string directoryNameTwo = "Bar";

                    //
                    // Create the job
                    //
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    unboundJob.PoolInformation.PoolId = poolFixture.PoolId;
                    unboundJob.Commit();

                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                    CloudTask myTask = new CloudTask(taskId, "cmd /c echo hello world");
                    CloudTask directoryCreationTask1 = new CloudTask(directoryCreationTaskId1, string.Format("cmd /c mkdir {0} && echo test > {0}/testfile.txt", directoryNameOne));
                    CloudTask directoryCreationTask2 = new CloudTask(directoryCreationTaskId2, string.Format("cmd /c mkdir {0} && echo test > {0}/testfile.txt", directoryNameTwo));

                    boundJob.AddTask(myTask);
                    boundJob.AddTask(directoryCreationTask1);
                    boundJob.AddTask(directoryCreationTask2);

                    testOutputHelper.WriteLine("Initial job commit()");

                    //
                    // Wait for task to go to completion
                    //
                    Utilities utilities = batchCli.Utilities;
                    TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                    taskStateMonitor.WaitAll(
                        boundJob.ListTasks(),
                        Microsoft.Azure.Batch.Common.TaskState.Completed,
                        TimeSpan.FromMinutes(3));

                    CloudTask boundTask = boundJob.GetTask(taskId);
                    //Since the compute node name comes back as "Node:<computeNodeId>" we need to split on : to get the actual compute node name
                    string computeNodeId = boundTask.ComputeNodeInformation.AffinityId.Split(':')[1];

                    ComputeNode computeNode = batchCli.PoolOperations.GetComputeNode(poolFixture.PoolId, computeNodeId);

                    testOutputHelper.WriteLine("Task ran on compute node: {0}", computeNodeId);

                    //Ensure that ListFiles done without a recursive option, or with recursive false return the same values
                    {
                        List<NodeFile> filesByComputeNodeRecursiveOmitted = batchCli.PoolOperations.ListNodeFiles(
                            poolFixture.PoolId,
                            computeNodeId).ToList();

                        List<NodeFile> filesByComputeNodeRecursiveFalse = batchCli.PoolOperations.ListNodeFiles(
                            poolFixture.PoolId,
                            computeNodeId,
                            recursive: false).ToList();

                        AssertFileListsMatch(filesByComputeNodeRecursiveOmitted, filesByComputeNodeRecursiveFalse);
                    }

                    {
                        List<NodeFile> filesByTaskRecursiveOmitted = batchCli.JobOperations.ListNodeFiles(
                            jobId,
                            taskId).ToList();

                        List<NodeFile> filesByTaskRecursiveFalse = batchCli.JobOperations.ListNodeFiles(
                            jobId,
                            taskId,
                            recursive: false).ToList();

                        AssertFileListsMatch(filesByTaskRecursiveOmitted, filesByTaskRecursiveFalse);
                    }

                    //
                    // List all node files from operations -- recursive true
                    //
                    //TODO: Detail level?
                    List<NodeFile> fileListFromComputeNodeOperations = batchCli.PoolOperations.ListNodeFiles(poolFixture.PoolId, computeNodeId, recursive: true).ToList();

                    foreach (NodeFile f in fileListFromComputeNodeOperations)
                    {
                        testOutputHelper.WriteLine("Found file: {0}", f.Path);
                    }
                    //Check to make sure the expected folder named "Shared" exists
                    Assert.Contains("shared", fileListFromComputeNodeOperations.Select(f => f.Path));

                    //
                    // List all node files from the compute node -- recursive true
                    //
                    List<NodeFile> fileListFromComputeNode = computeNode.ListNodeFiles(recursive: true).ToList();
                    foreach (NodeFile f in fileListFromComputeNodeOperations)
                    {
                        testOutputHelper.WriteLine("Found file: {0}", f.Path);
                    }
                    //Check to make sure the expected folder named "Shared" exists
                    Assert.Contains("shared", fileListFromComputeNode.Select(f => f.Path));

                    //
                    // Get file from operations
                    //
                    string filePathToGet = fileListFromComputeNode.First(f => !f.IsDirectory.Value && f.Properties.ContentLength > 0).Path;
                    testOutputHelper.WriteLine("Getting file: {0}", filePathToGet);
                    NodeFile computeNodeFileFromManager = batchCli.PoolOperations.GetNodeFile(poolFixture.PoolId, computeNodeId, filePathToGet);
                    testOutputHelper.WriteLine("Successfully retrieved file: {0}", filePathToGet);
                    testOutputHelper.WriteLine("---- File data: ----");
                    var computeNodeFileContentFromManager = computeNodeFileFromManager.ReadAsString();
                    testOutputHelper.WriteLine(computeNodeFileContentFromManager);
                    Assert.NotEmpty(computeNodeFileContentFromManager);

                    //
                    // Get file directly from operations (bypassing the properties call)
                    //
                    var computeNodeFileContentDirect = batchCli.PoolOperations.CopyNodeFileContentToString(poolFixture.PoolId, computeNodeId, filePathToGet);
                    testOutputHelper.WriteLine("---- File data: ----");
                    testOutputHelper.WriteLine(computeNodeFileContentDirect);
                    Assert.NotEmpty(computeNodeFileContentDirect);

                    //
                    // Get file from compute node
                    //
                    testOutputHelper.WriteLine("Getting file: {0}", filePathToGet);
                    NodeFile fileFromComputeNode = computeNode.GetNodeFile(filePathToGet);
                    testOutputHelper.WriteLine("Successfully retrieved file: {0}", filePathToGet);
                    testOutputHelper.WriteLine("---- File data: ----");
                    var computeNodeFileContentFromNode = fileFromComputeNode.ReadAsString();
                    testOutputHelper.WriteLine(computeNodeFileContentFromNode);
                    Assert.NotEmpty(computeNodeFileContentFromNode);

                    //
                    // Get file from compute node (bypassing the properties call)
                    //
                    computeNodeFileContentDirect = computeNode.CopyNodeFileContentToString(filePathToGet);
                    testOutputHelper.WriteLine("---- File data: ----");
                    testOutputHelper.WriteLine(computeNodeFileContentDirect);
                    Assert.NotEmpty(computeNodeFileContentDirect);

                    //
                    // NodeFile delete
                    //
                    string filePath = Path.Combine(@"workitems", jobId, "job-1", taskId, Constants.StandardOutFileName);
                    NodeFile nodeFile = batchCli.PoolOperations.GetNodeFile(poolFixture.PoolId, computeNodeId, filePath);

                    nodeFile.Delete();

                    //Ensure delete succeeded

                    TestUtilities.AssertThrows<BatchException>(() => nodeFile.Refresh());

                    //Delete directory

                    NodeFile directory = batchCli.PoolOperations.ListNodeFiles(poolFixture.PoolId, computeNodeId, recursive: true).First(item => item.Path.Contains(directoryNameOne));
                    Assert.True(directory.IsDirectory);
                    TestUtilities.AssertThrows<BatchException>(() => directory.Delete(recursive: false));
                    directory.Delete(recursive: true);

                    Assert.Null(batchCli.PoolOperations.ListNodeFiles(poolFixture.PoolId, computeNodeId, recursive: true).FirstOrDefault(item => item.Path.Contains(directoryNameOne)));

                    //
                    // PoolManager delete node file
                    //
                    filePath = Path.Combine(@"workitems", jobId, "job-1", taskId, Constants.StandardErrorFileName);

                    NodeFile file = batchCli.JobOperations.GetNodeFile(jobId, taskId, Constants.StandardErrorFileName);
                    batchCli.PoolOperations.DeleteNodeFile(poolFixture.PoolId, computeNodeId, filePath);

                    //Ensure delete succeeded
                    TestUtilities.AssertThrows<BatchException>(() => batchCli.JobOperations.GetNodeFile(jobId, taskId, Constants.StandardErrorFileName));

                    //Delete directory
                    directory = batchCli.PoolOperations.ListNodeFiles(poolFixture.PoolId, computeNodeId, recursive: true).First(item => item.Path.Contains(directoryNameTwo));
                    Assert.True(directory.IsDirectory);
                    TestUtilities.AssertThrows<BatchException>(() => batchCli.PoolOperations.DeleteNodeFile(poolFixture.PoolId, computeNodeId, directory.Path, recursive: false));
                    batchCli.PoolOperations.DeleteNodeFile(poolFixture.PoolId, computeNodeId, directory.Path, recursive: true);

                    Assert.Null(batchCli.PoolOperations.ListNodeFiles(poolFixture.PoolId, computeNodeId, recursive: true).FirstOrDefault(item => item.Path.Contains(directoryNameTwo)));
                }
                finally
                {
                    batchCli.JobOperations.DeleteJob(jobId);
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug2338301_CheckStreamPositionAfterFileRead()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                JobOperations jobOperations = batchCli.JobOperations;
                {
                    string jobId = "Bug2338301Job-" + TestUtilities.GetMyName();

                    try
                    {
                        const string taskId = "hiWorld";

                        //
                        // Create the job
                        //
                        CloudJob unboundJob = jobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                        unboundJob.Commit();

                        CloudJob boundJob = jobOperations.GetJob(jobId);
                        CloudTask myTask = new CloudTask(taskId, "cmd /c echo hello world");

                        boundJob.AddTask(myTask);

                        testOutputHelper.WriteLine("Initial job commit()");

                        //
                        // Wait for task to go to completion
                        //
                        Utilities utilities = batchCli.Utilities;
                        TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();
                        taskStateMonitor.WaitAll(
                            boundJob.ListTasks(),
                            Microsoft.Azure.Batch.Common.TaskState.Completed,
                            TimeSpan.FromMinutes(3));

                        CloudTask boundTask = boundJob.GetTask(taskId);

                        //Get the task file
                        const string fileToGet = "stdout.txt";
                        NodeFile file = boundTask.GetNodeFile(fileToGet);

                        //Download the file data
                        string result = file.ReadAsString();
                        Assert.True(result.Length > 0);
                    }
                    finally
                    {
                        jobOperations.DeleteJob(jobId);
                    }
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1480491NodeFileFileProperties()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "Bug1480491Job-" + TestUtilities.GetMyName();

                try
                {
                    const string taskId = "hiWorld";

                    //
                    // Create the job
                    //
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    unboundJob.PoolInformation.PoolId = poolFixture.PoolId;
                    unboundJob.Commit();

                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                    CloudTask myTask = new CloudTask(taskId, "cmd /c echo hello world");

                    boundJob.AddTask(myTask);

                    testOutputHelper.WriteLine("Initial job commit()");

                    //
                    // Wait for task to go to completion
                    //
                    Utilities utilities = batchCli.Utilities;
                    TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                    taskStateMonitor.WaitAll(
                        boundJob.ListTasks(),
                        Microsoft.Azure.Batch.Common.TaskState.Completed,
                        TimeSpan.FromMinutes(3));

                    const int expectedFileSize = 13; //Magic number based on output generated by the task

                    //
                    // NodeFile by task
                    //
                    NodeFile file = batchCli.JobOperations.GetNodeFile(jobId, taskId, Constants.StandardOutFileName);

                    testOutputHelper.WriteLine("File {0} has content length: {1}", Constants.StandardOutFileName, file.Properties.ContentLength);
                    testOutputHelper.WriteLine("File {0} has content type: {1}", Constants.StandardOutFileName, file.Properties.ContentType);

                    testOutputHelper.WriteLine("File {0} has creation time: {1}", Constants.StandardOutFileName, file.Properties.CreationTime);
                    testOutputHelper.WriteLine("File {0} has last modified time: {1}", Constants.StandardOutFileName, file.Properties.LastModified);

                    Assert.Equal(expectedFileSize, file.Properties.ContentLength);
                    Assert.Equal("text/plain", file.Properties.ContentType);

                    //
                    // NodeFile by node
                    //
                    CloudTask boundTask = boundJob.GetTask(taskId);
                    string computeNodeId = boundTask.ComputeNodeInformation.AffinityId.Split(':')[1];

                    ComputeNode computeNode = batchCli.PoolOperations.GetComputeNode(poolFixture.PoolId, computeNodeId);

                    testOutputHelper.WriteLine("Task ran on compute node: {0}", computeNodeId);

                    List<NodeFile> files = computeNode.ListNodeFiles(recursive: true).ToList();
                    foreach (NodeFile nodeFile in files)
                    {
                        testOutputHelper.WriteLine("Found file: {0}", nodeFile.Path);
                    }

                    string filePathToGet = string.Format("workitems/{0}/{1}/{2}/{3}", jobId, "job-1", taskId, Constants.StandardOutFileName);
                    file = computeNode.GetNodeFile(filePathToGet);

                    testOutputHelper.WriteLine("File {0} has content length: {1}", filePathToGet, file.Properties.ContentLength);
                    testOutputHelper.WriteLine("File {0} has content type: {1}", filePathToGet, file.Properties.ContentType);

                    testOutputHelper.WriteLine("File {0} has creation time: {1}", filePathToGet, file.Properties.CreationTime);
                    testOutputHelper.WriteLine("File {0} has last modified time: {1}", filePathToGet, file.Properties.LastModified);

                    Assert.Equal(expectedFileSize, file.Properties.ContentLength);
                    Assert.Equal("text/plain", file.Properties.ContentType);
                }
                finally
                {
                    batchCli.JobOperations.DeleteJob(jobId);
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
        
        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void TestGetNodeFileByTask()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                JobOperations jobOperations = batchCli.JobOperations;

                string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-" + nameof(TestGetNodeFileByTask);
                try
                {
                    //
                    // Create the job
                    //
                    CloudJob job = jobOperations.CreateJob(jobId, new PoolInformation());
                    job.PoolInformation = new PoolInformation()
                    {
                        PoolId = poolFixture.PoolId
                    };

                    testOutputHelper.WriteLine("Initial job schedule commit()");

                    job.Commit();

                    //
                    // Wait for the job
                    //
                    testOutputHelper.WriteLine("Waiting for job");
                    CloudJob boundJob = jobOperations.GetJob(jobId);

                    //
                    // Add task to the job
                    //
                    const string taskId = "T1";
                    const string taskMessage = "This is a test";

                    testOutputHelper.WriteLine("Adding task: {0}", taskId);
                    CloudTask task = new CloudTask(taskId, string.Format("cmd /c echo {0}", taskMessage));
                    boundJob.AddTask(task);

                    //
                    // Wait for the task to complete
                    //
                    testOutputHelper.WriteLine("Waiting for the task to complete");
                    Utilities utilities = batchCli.Utilities;
                    TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                    //Wait for the task state to be running
                    taskStateMonitor.WaitAll(
                        jobOperations.ListTasks(jobId),
                        TaskState.Completed,
                        TimeSpan.FromSeconds(30));

                    //Download the data
                    testOutputHelper.WriteLine("Downloading the stdout for the file");
                    NodeFile file = jobOperations.GetNodeFile(jobId, taskId, Constants.StandardOutFileName);
                    string data = file.ReadAsString();
                    testOutputHelper.WriteLine("Data: {0}", data);
                    Assert.Contains(taskMessage, data);

                    // Download the data again using the JobOperations read file content helper
                    data = batchCli.JobOperations.CopyNodeFileContentToString(jobId, taskId, Constants.StandardOutFileName);
                    testOutputHelper.WriteLine("Data: {0}", data);
                    Assert.Contains(taskMessage, data);
                }
                finally
                {
                    jobOperations.DeleteJob(jobId);
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        private static void AssertFileListsMatch(List<NodeFile> listOne, List<NodeFile> listTwo)
        {
            Assert.Equal(listOne.Count, listTwo.Count);
            Assert.NotEmpty(listOne);
            Assert.NotEmpty(listTwo);
            foreach (NodeFile file in listOne)
            {
                //Find the corresponding file in the other list and ensure they are the same
                NodeFile matchedFile = listTwo.FirstOrDefault(f => f.Path == file.Path);
                Assert.NotNull(matchedFile);

                //Ensure the files match
                Assert.Equal(file.IsDirectory, matchedFile.IsDirectory);

                if (file.Properties == null)
                {
                    Assert.Null(file.Properties);
                    Assert.Null(matchedFile.Properties);
                }
                else
                {
                    Assert.Equal(file.Properties.ContentLength, matchedFile.Properties.ContentLength);
                    Assert.Equal(file.Properties.ContentType, matchedFile.Properties.ContentType);
                    Assert.Equal(file.Properties.CreationTime, matchedFile.Properties.CreationTime);
                    Assert.Equal(file.Properties.LastModified, matchedFile.Properties.LastModified);
                }
            }
        }
    }

    [Collection("SharedLinuxPoolCollection")]
    public class IntegrationNodeFileLinuxTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(2);

        public IntegrationNodeFileLinuxTests(ITestOutputHelper testOutputHelper, IaasLinuxPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }
        
        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestFilePropertiesFileMode()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = null;
                try
                {
                    // create some files on the node
                    TestUtilities.HelloWorld(
                        batchCli,
                        testOutputHelper,
                        poolFixture.Pool,
                        out jobId,
                        out string taskId,
                        deleteJob: false,
                        isLinux: false);

                    var nodes = poolFixture.Pool.ListComputeNodes().ToList();
                    ComputeNode cn = nodes[0]; // get the node that has files on it

                    List<NodeFile> files = cn.ListNodeFiles(recursive: true).ToList();

                    Assert.True(files.Count > 0);

                    bool foundOne = false;

                    // look through all the files for a filemode
                    foreach (NodeFile curNF in files)
                    {
                        if ((null != curNF.Properties) && !string.IsNullOrWhiteSpace(curNF.Properties.FileMode))
                        {
                            foundOne = true;
                            break;
                        }
                    }

                    Assert.True(foundOne);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
    }
}
