// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
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
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1480489NodeFileMissingIsDirectory()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jobId = "Bug1480489Job-" + TestUtilities.GetMyName();

                    try
                    {
                        // here we show how to use an unbound Job + Commit() to run millions of Tasks
                        CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = this.poolFixture.PoolId });
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

                        this.testOutputHelper.WriteLine("TaskId: " + myCompletedTask.Id);
                        this.testOutputHelper.WriteLine("StdOut: ");
                        this.testOutputHelper.WriteLine(stdOut);

                        this.testOutputHelper.WriteLine("StdErr: ");
                        this.testOutputHelper.WriteLine(stdErr);

                        this.testOutputHelper.WriteLine("Task Files:");

                        bool foundAtLeastOneDir = false;

                        foreach (NodeFile curFile in myCompletedTask.ListNodeFiles())
                        {
                            this.testOutputHelper.WriteLine("    Filename: " + curFile.Name);
                            this.testOutputHelper.WriteLine("       IsDirectory: " + curFile.IsDirectory.ToString());

                            // turns out wd is created for each task so use it as sentinal
                            if (curFile.Name.Equals("wd") && curFile.IsDirectory.HasValue && curFile.IsDirectory.Value)
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
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
        
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug230385SupportDeleteNodeFileByTask()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
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
                        unboundJob.PoolInformation.PoolId = this.poolFixture.PoolId;
                        unboundJob.Commit();

                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                        CloudTask myTask = new CloudTask(taskId, "cmd /c echo hello world");
                        CloudTask directoryCreationTask1 = new CloudTask(directoryCreationTaskId1, string.Format("cmd /c mkdir {0} && echo test > {0}/testfile.txt", directoryNameOne));
                        CloudTask directoryCreationTask2 = new CloudTask(directoryCreationTaskId2, string.Format("cmd /c mkdir {0} && echo test > {0}/testfile.txt", directoryNameTwo));

                        boundJob.AddTask(myTask);
                        boundJob.AddTask(directoryCreationTask1);
                        boundJob.AddTask(directoryCreationTask2);

                        this.testOutputHelper.WriteLine("Initial job commit()");

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
                        const string stdOutFileName = "stdout.txt";
                        NodeFile file = batchCli.JobOperations.GetNodeFile(jobId, taskId, stdOutFileName);
                        file.Delete();

                        //Ensure delete succeeded
                        TestUtilities.AssertThrows<BatchException>(() => batchCli.JobOperations.GetNodeFile(jobId, taskId, stdOutFileName));

                        //Delete directory

                        NodeFile directory = batchCli.JobOperations.ListNodeFiles(jobId, directoryCreationTaskId1, recursive: true).First(item => item.Name.Contains(directoryNameOne));
                        Assert.True(directory.IsDirectory);
                        TestUtilities.AssertThrows<BatchException>(() => directory.Delete(recursive: false));
                        directory.Delete(recursive: true);

                        Assert.Null(batchCli.JobOperations.ListNodeFiles(jobId, directoryCreationTaskId1, recursive: true).FirstOrDefault(item => item.Name.Contains(directoryNameOne)));

                        //
                        // JobScheduleOperations delete task file
                        //
                        const string stdErrFileName = "stderr.txt";
                        batchCli.JobOperations.GetNodeFile(jobId, taskId, stdErrFileName);
                        batchCli.JobOperations.DeleteNodeFile(jobId, taskId, stdErrFileName);

                        //Ensure delete succeeded
                        TestUtilities.AssertThrows<BatchException>(() => batchCli.JobOperations.GetNodeFile(jobId, taskId, stdErrFileName));

                        //Delete directory
                        directory = batchCli.JobOperations.ListNodeFiles(jobId, directoryCreationTaskId2, recursive: true).First(item => item.Name.Contains(directoryNameTwo));
                        Assert.True(directory.IsDirectory);
                        TestUtilities.AssertThrows<BatchException>(() => batchCli.JobOperations.DeleteNodeFile(jobId, directoryCreationTaskId2, directory2PathOnNode, recursive: false));
                        batchCli.JobOperations.DeleteNodeFile(jobId, directoryCreationTaskId2, directory2PathOnNode, recursive: true);

                        Assert.Null(batchCli.JobOperations.ListNodeFiles(jobId, directoryCreationTaskId2, recursive: true).FirstOrDefault(item => item.Name.Contains(directoryNameTwo)));
                    }
                    finally
                    {
                        TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
        
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1771166_1771181_1771038_GetListDeleteNodeFile()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jobId = "Bug1771166Job-" + TestUtilities.GetMyName();

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
                        unboundJob.PoolInformation.PoolId = this.poolFixture.PoolId;
                        unboundJob.Commit();

                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                        CloudTask myTask = new CloudTask(taskId, "cmd /c echo hello world");
                        CloudTask directoryCreationTask1 = new CloudTask(directoryCreationTaskId1, string.Format("cmd /c mkdir {0} && echo test > {0}/testfile.txt", directoryNameOne));
                        CloudTask directoryCreationTask2 = new CloudTask(directoryCreationTaskId2, string.Format("cmd /c mkdir {0} && echo test > {0}/testfile.txt", directoryNameTwo));

                        boundJob.AddTask(myTask);
                        boundJob.AddTask(directoryCreationTask1);
                        boundJob.AddTask(directoryCreationTask2);

                        this.testOutputHelper.WriteLine("Initial job commit()");

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

                        ComputeNode computeNode = batchCli.PoolOperations.GetComputeNode(this.poolFixture.PoolId, computeNodeId);

                        this.testOutputHelper.WriteLine("Task ran on compute node: {0}", computeNodeId);

                        //Ensure that ListFiles done without a recursive option, or with recursive false return the same values
                        {
                            List<NodeFile> filesByComputeNodeRecursiveOmitted = batchCli.PoolOperations.ListNodeFiles(
                                this.poolFixture.PoolId, 
                                computeNodeId).ToList();

                            List<NodeFile> filesByComputeNodeRecursiveFalse = batchCli.PoolOperations.ListNodeFiles(
                                this.poolFixture.PoolId, 
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
                        List<NodeFile> fileListFromComputeNodeOperations = batchCli.PoolOperations.ListNodeFiles(this.poolFixture.PoolId, computeNodeId, recursive: true).ToList();

                        foreach (NodeFile f in fileListFromComputeNodeOperations)
                        {
                            this.testOutputHelper.WriteLine("Found file: {0}", f.Name);
                        }
                        //Check to make sure the expected folder named "Shared" exists
                        Assert.Contains("shared", fileListFromComputeNodeOperations.Select(f => f.Name));

                        //
                        // List all node files from the compute node -- recursive true
                        //
                        List<NodeFile> fileListFromComputeNode = computeNode.ListNodeFiles(recursive: true).ToList();
                        foreach (NodeFile f in fileListFromComputeNodeOperations)
                        {
                            this.testOutputHelper.WriteLine("Found file: {0}", f.Name);
                        }
                        //Check to make sure the expected folder named "Shared" exists
                        Assert.Contains("shared", fileListFromComputeNode.Select(f => f.Name));

                        //
                        // Get file from operations
                        //
                        string filePathToGet = fileListFromComputeNode.First(f => !f.IsDirectory.Value).Name;
                        this.testOutputHelper.WriteLine("Getting file: {0}", filePathToGet);
                        NodeFile computeNodeFileFromManager = batchCli.PoolOperations.GetNodeFile(this.poolFixture.PoolId, computeNodeId, filePathToGet);
                        this.testOutputHelper.WriteLine("Successfully retrieved file: {0}", filePathToGet);
                        this.testOutputHelper.WriteLine("---- File data: ----");
                        this.testOutputHelper.WriteLine(computeNodeFileFromManager.ReadAsString());

                        //
                        // Get file from compute node
                        //
                        this.testOutputHelper.WriteLine("Getting file: {0}", filePathToGet);
                        NodeFile fileFromComputeNode = computeNode.GetNodeFile(filePathToGet);
                        this.testOutputHelper.WriteLine("Successfully retrieved file: {0}", filePathToGet);
                        this.testOutputHelper.WriteLine("---- File data: ----");
                        this.testOutputHelper.WriteLine(fileFromComputeNode.ReadAsString());

                        //
                        // NodeFile delete
                        //
                        const string stdOutFileName = "stdout.txt";
                        string filePath = Path.Combine(@"workitems", jobId, "job-1", taskId, stdOutFileName);
                        NodeFile nodeFile = batchCli.PoolOperations.GetNodeFile(this.poolFixture.PoolId, computeNodeId, filePath);

                        nodeFile.Delete();

                        //Ensure delete succeeded

                        TestUtilities.AssertThrows<BatchException>(() => nodeFile.Refresh());

                        //Delete directory

                        NodeFile directory = batchCli.PoolOperations.ListNodeFiles(this.poolFixture.PoolId, computeNodeId, recursive: true).First(item => item.Name.Contains(directoryNameOne));
                        Assert.True(directory.IsDirectory);
                        TestUtilities.AssertThrows<BatchException>(() => directory.Delete(recursive: false));
                        directory.Delete(recursive: true);

                        Assert.Null(batchCli.PoolOperations.ListNodeFiles(this.poolFixture.PoolId, computeNodeId, recursive: true).FirstOrDefault(item => item.Name.Contains(directoryNameOne)));

                        //
                        // PoolManager delete node file
                        //
                        const string stdErrFileName = "stderr.txt";
                        filePath = Path.Combine(@"workitems", jobId, "job-1", taskId, stdErrFileName);

                        NodeFile file = batchCli.JobOperations.GetNodeFile(jobId, taskId, stdErrFileName);
                        batchCli.PoolOperations.DeleteNodeFile(this.poolFixture.PoolId, computeNodeId, filePath);

                        //Ensure delete succeeded
                        TestUtilities.AssertThrows<BatchException>(() => batchCli.JobOperations.GetNodeFile(jobId, taskId, stdErrFileName));

                        //Delete directory
                        directory = batchCli.PoolOperations.ListNodeFiles(this.poolFixture.PoolId, computeNodeId, recursive: true).First(item => item.Name.Contains(directoryNameTwo));
                        Assert.True(directory.IsDirectory);
                        TestUtilities.AssertThrows<BatchException>(() => batchCli.PoolOperations.DeleteNodeFile(this.poolFixture.PoolId, computeNodeId, directory.Name, recursive: false));
                        batchCli.PoolOperations.DeleteNodeFile(this.poolFixture.PoolId, computeNodeId, directory.Name, recursive: true);

                        Assert.Null(batchCli.PoolOperations.ListNodeFiles(this.poolFixture.PoolId, computeNodeId, recursive: true).FirstOrDefault(item => item.Name.Contains(directoryNameTwo)));
                    }
                    finally
                    {
                        batchCli.JobOperations.DeleteJob(jobId);
                    }

                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug2338301_CheckStreamPositionAfterFileRead()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    JobOperations jobOperations = batchCli.JobOperations;
                    {
                        string jobId = "Bug2338301Job-" + TestUtilities.GetMyName();

                        try
                        {
                            const string taskId = "hiWorld";

                            //
                            // Create the job
                            //
                            CloudJob unboundJob = jobOperations.CreateJob(jobId, new PoolInformation() { PoolId = this.poolFixture.PoolId });
                            unboundJob.Commit();

                            CloudJob boundJob = jobOperations.GetJob(jobId);
                            CloudTask myTask = new CloudTask(taskId, "cmd /c echo hello world");

                            boundJob.AddTask(myTask);

                            this.testOutputHelper.WriteLine("Initial job commit()");

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
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1480491NodeFileFileProperties()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jobId = "Bug1480491Job-" + TestUtilities.GetMyName();

                    try
                    {
                        const string taskId = "hiWorld";

                        //
                        // Create the job
                        //
                        CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                        unboundJob.PoolInformation.PoolId = this.poolFixture.PoolId;
                        unboundJob.Commit();

                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                        CloudTask myTask = new CloudTask(taskId, "cmd /c echo hello world");

                        boundJob.AddTask(myTask);

                        this.testOutputHelper.WriteLine("Initial job commit()");

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
                        const string stdOutFileName = "stdout.txt";
                        NodeFile file = batchCli.JobOperations.GetNodeFile(jobId, taskId, stdOutFileName);

                        this.testOutputHelper.WriteLine("File {0} has content length: {1}", stdOutFileName, file.Properties.ContentLength);
                        this.testOutputHelper.WriteLine("File {0} has content type: {1}", stdOutFileName, file.Properties.ContentType);

                        this.testOutputHelper.WriteLine("File {0} has creation time: {1}", stdOutFileName, file.Properties.CreationTime);
                        this.testOutputHelper.WriteLine("File {0} has last modified time: {1}", stdOutFileName, file.Properties.LastModified);

                        Assert.Equal(expectedFileSize, file.Properties.ContentLength);
                        Assert.Equal("application/octet-stream", file.Properties.ContentType);

                        //
                        // NodeFile by node
                        //
                        CloudTask boundTask = boundJob.GetTask(taskId);
                        string computeNodeId = boundTask.ComputeNodeInformation.AffinityId.Split(':')[1];

                        ComputeNode computeNode = batchCli.PoolOperations.GetComputeNode(this.poolFixture.PoolId, computeNodeId);

                        this.testOutputHelper.WriteLine("Task ran on compute node: {0}", computeNodeId);

                        List<NodeFile> files = computeNode.ListNodeFiles(recursive: true).ToList();
                        foreach (NodeFile nodeFile in files)
                        {
                            this.testOutputHelper.WriteLine("Found file: {0}", nodeFile.Name);
                        }

                        string filePathToGet = string.Format("workitems/{0}/{1}/{2}/{3}", jobId, "job-1", taskId, stdOutFileName);
                        file = computeNode.GetNodeFile(filePathToGet);

                        this.testOutputHelper.WriteLine("File {0} has content length: {1}", filePathToGet, file.Properties.ContentLength);
                        this.testOutputHelper.WriteLine("File {0} has content type: {1}", filePathToGet, file.Properties.ContentType);

                        this.testOutputHelper.WriteLine("File {0} has creation time: {1}", filePathToGet, file.Properties.CreationTime);
                        this.testOutputHelper.WriteLine("File {0} has last modified time: {1}", filePathToGet, file.Properties.LastModified);

                        Assert.Equal(expectedFileSize, file.Properties.ContentLength);
                        Assert.Equal("application/octet-stream", file.Properties.ContentType);
                    }
                    finally
                    {
                        batchCli.JobOperations.DeleteJob(jobId);
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
        
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1501413TestGetNodeFileByTask()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    JobOperations jobOperations = batchCli.JobOperations;

                    string jobId = Microsoft.Azure.Batch.Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-Bug1501413TestGetNodeFileByTask";
                    try
                    {
                        //
                        // Create the job
                        //
                        CloudJob job = jobOperations.CreateJob(jobId, new PoolInformation());
                        job.PoolInformation = new PoolInformation()
                        {
                            PoolId = this.poolFixture.PoolId
                        };

                        this.testOutputHelper.WriteLine("Initial job schedule commit()");

                        job.Commit();

                        //
                        // Wait for the job
                        //
                        this.testOutputHelper.WriteLine("Waiting for job");
                        CloudJob boundJob = jobOperations.GetJob(jobId);

                        //
                        // Add task to the job
                        //
                        const string taskId = "T1";
                        const string taskMessage = "This is a test";

                        this.testOutputHelper.WriteLine("Adding task: {0}", taskId);
                        CloudTask task = new CloudTask(taskId, string.Format("cmd /c echo {0}", taskMessage));
                        boundJob.AddTask(task);

                        //
                        // Wait for the task to complete
                        //
                        this.testOutputHelper.WriteLine("Waiting for the task to complete");
                        Utilities utilities = batchCli.Utilities;
                        TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                        //Wait for the task state to be running

                        taskStateMonitor.WaitAll(
                            jobOperations.ListTasks(jobId),
                            TaskState.Completed,
                            TimeSpan.FromSeconds(30));

                        //Download the data
                        this.testOutputHelper.WriteLine("Downloading the stdout for the file");
                        NodeFile file = jobOperations.GetNodeFile(jobId, taskId, "stdout.txt");

                        string data = file.ReadAsString(encoding: Encoding.UTF8);

                        this.testOutputHelper.WriteLine("Data: {0}", data);

                        Assert.Contains(taskMessage, data);
                    }
                    finally
                    {
                        jobOperations.DeleteJob(jobId);
                    }
                }
            };

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
                NodeFile matchedFile = listTwo.FirstOrDefault(f => f.Name == file.Name);
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
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestFilePropertiesFileMode()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jobId = null;
                    try
                    {
                        string taskId;

                        // create some files on the node
                        TestUtilities.HelloWorld(
                            batchCli,
                            this.testOutputHelper,
                            this.poolFixture.Pool,
                            out jobId,
                            out taskId,
                            deleteJob: false,
                            isLinux: true);

                        var nodes = this.poolFixture.Pool.ListComputeNodes().ToList();
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
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
    }
}
