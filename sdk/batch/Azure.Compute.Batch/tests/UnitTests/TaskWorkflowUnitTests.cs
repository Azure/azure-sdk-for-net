// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure;
using Azure.Compute.Batch;
using Moq;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using Microsoft.Extensions.Azure;
using System.Collections.Generic;

namespace Azure.Compute.Batch.Tests.UnitTests
{
    public class TaskWorkflowUnitTests
    {
        [Test]
        /// <summary>
        /// Verify that for the default result handler we treat TaskExists as success
        /// </summary>
        public async Task AddTaskThatAlreadyExits_DefaultResultHandler()
        {
            // Arrange
            var mockResponse = new Mock<Response>();

            // two resutls, one a sucess and one an error that the task exists
            string batchTaskAddCollectionJson = @"
            {
              ""value"": [
                {
                  ""taskId"": ""task1"",
                  ""status"": ""success"",
                  ""error"": null
                },
                {
                  ""taskId"": ""task2"",
                  ""status"": ""clienterror"",
                  ""error"": {
                    ""code"": ""TaskExists"",
                    ""message"": {
                      ""value"": ""Error message""
                    },
                    ""values"": [
                      {
                        ""key"": ""key1"",
                        ""value"": ""value1""
                      },
                      {
                        ""key"": ""key2"",
                        ""value"": ""value2""
                      }
                    ]
                  }
                }
              ]
            }";

            var binaryData = new BinaryData(batchTaskAddCollectionJson);
            mockResponse.Setup(response => response.Content).Returns(binaryData);

            var batchTaskAddCollectionResult = BatchTaskAddCollectionResult.FromResponse(mockResponse.Object);
            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.CreateTaskCollectionAsync(
                It.IsAny<string>(),
                It.IsAny<BatchTaskGroup>(),
                It.IsAny<int?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<CancellationToken>())
            )
            .ReturnsAsync(Response.FromValue(batchTaskAddCollectionResult, Mock.Of<Response>()));

            BatchClient batchClient = clientMock.Object;
            TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(batchClient, "jobId", null);

            List<BatchTaskCreateContent> tasks = new List<BatchTaskCreateContent>();
            tasks.Add(new BatchTaskCreateContent("task1", "cmd /c echo Hello World"));
            tasks.Add(new BatchTaskCreateContent("task2", "cmd /c echo Hello World"));

            // Act
            CreateTasksResult result = await addTasksWorkflowManager.AddTasksAsync(tasks, "jobId");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.BatchTaskAddResults.Count);
            Assert.AreEqual(2, result.Pass);
            Assert.AreEqual(0, result.Fail);
        }

        [Test]
        /// <summary>
        /// Verify that for the default result handler we treat TaskExists as success
        /// </summary>
        public async Task AddTaskThatAlreadyExits_CustomResultHandler()
        {
            // Arrange
            var mockResponse = new Mock<Response>();

            // two resutls, one a sucess and one an error that the task exists
            string batchTaskAddCollectionJson = @"
            {
              ""value"": [
                {
                  ""taskId"": ""task1"",
                  ""status"": ""success"",
                  ""error"": null
                },
                {
                  ""taskId"": ""task2"",
                  ""status"": ""clienterror"",
                  ""error"": {
                    ""code"": ""TaskExists"",
                    ""message"": {
                      ""value"": ""Error message""
                    },
                    ""values"": [
                      {
                        ""key"": ""key1"",
                        ""value"": ""value1""
                      },
                      {
                        ""key"": ""key2"",
                        ""value"": ""value2""
                      }
                    ]
                  }
                }
              ]
            }";

            var binaryData = new BinaryData(batchTaskAddCollectionJson);
            mockResponse.Setup(response => response.Content).Returns(binaryData);

            var batchTaskAddCollectionResult = BatchTaskAddCollectionResult.FromResponse(mockResponse.Object);
            Mock<BatchClient> clientMock = new Mock<BatchClient>();
            clientMock.Setup(c => c.CreateTaskCollectionAsync(
                It.IsAny<string>(),
                It.IsAny<BatchTaskGroup>(),
                It.IsAny<int?>(),
                It.IsAny<DateTimeOffset?>(),
                It.IsAny<CancellationToken>())
            )
            .ReturnsAsync(Response.FromValue(batchTaskAddCollectionResult, Mock.Of<Response>()));

            BatchClient batchClient = clientMock.Object;
            TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(batchClient, "jobId", null, bulkTaskCollectionResultHandler: new CustomTaskCollectionResultHandler());

            List<BatchTaskCreateContent> tasks = new List<BatchTaskCreateContent>();
            tasks.Add(new BatchTaskCreateContent("task1", "cmd /c echo Hello World"));
            tasks.Add(new BatchTaskCreateContent("task2", "cmd /c echo Hello World"));

            // Act
            CreateTasksResult result = await addTasksWorkflowManager.AddTasksAsync(tasks, "jobId");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.BatchTaskAddResults.Count);
            Assert.AreEqual(1, result.Pass);
            Assert.AreEqual(1, result.Fail);
        }

        [Test]
        public async Task ServerError_TooManyRequests_DefaultResultHandler()
        {
            // Arrange
            Mock<BatchClient> clientMock = new Mock<BatchClient>();

            int CreateTaskCollectionAsyncCall = 0;
            clientMock.Setup(c => c.CreateTaskCollectionAsync(
               It.IsAny<string>(),
               It.IsAny<BatchTaskGroup>(),
               It.IsAny<int?>(),
               It.IsAny<DateTimeOffset?>(),
               It.IsAny<CancellationToken>())
           )
           .ReturnsAsync((string jobId, BatchTaskGroup taskCollection, int ? timeOutInSecondsl, DateTimeOffset? ocpdate, CancellationToken cancellationToken) =>
           {
               if (CreateTaskCollectionAsyncCall++ == 0)
               {
                   // mock the service call failing due to too many requests
                   var mockResponse = new Mock<Response>();
                   var batchErrorJson = "{\"code\":\"TooManyRequests\",\"message\":{\"value\":\"TooManyRequests\"},\"values\":[{\"key\": \"key1\",\"value\":\"value1\"},{\"key\": \"key2\",\"value\":\"value2\"}]}";
                   var binaryData = new BinaryData(batchErrorJson);
                   mockResponse.Setup(response => response.Content).Returns(binaryData);

                   throw new RequestFailedException(mockResponse.Object);
               }
               else
               {
                   // one the second pass there should have have all the tasks requests
                   Assert.AreEqual(2, taskCollection.Value.Count);
                   BatchTaskAddCollectionResult batchTaskAddCollectionResult = CreateBatchTaskAddCollectionResult(taskCollection);
                   return Response.FromValue(batchTaskAddCollectionResult, Mock.Of<Response>());
               }
           }
           );

            BatchClient batchClient = clientMock.Object;
            TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(batchClient, "jobId", null);

            List<BatchTaskCreateContent> tasks = new List<BatchTaskCreateContent>();
            tasks.Add(new BatchTaskCreateContent("task1", "cmd /c echo Hello World"));
            tasks.Add(new BatchTaskCreateContent("task2", "cmd /c echo Hello World"));

            // Act
            CreateTasksResult result = await addTasksWorkflowManager.AddTasksAsync(tasks, "jobId");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.BatchTaskAddResults.Count);
            Assert.AreEqual(2, result.Pass);
            Assert.AreEqual(0, result.Fail);
        }

        [Test]
        public async Task ServerError_RequestBodyTooLarge_DefaultResultHandler()
        {
            // Arrange
            int tasksCount = 100;
            Mock<BatchClient> clientMock = new Mock<BatchClient>();

            int CreateTaskCollectionAsyncCall = 0;
            clientMock.Setup(c => c.CreateTaskCollectionAsync(
               It.IsAny<string>(),
               It.IsAny<BatchTaskGroup>(),
               It.IsAny<int?>(),
               It.IsAny<DateTimeOffset?>(),
               It.IsAny<CancellationToken>())
           )
           .ReturnsAsync((string jobId, BatchTaskGroup taskCollection, int? timeOutInSecondsl, DateTimeOffset? ocpdate, CancellationToken cancellationToken) =>
           {
               if (CreateTaskCollectionAsyncCall++ == 0)
               {
                   // mock the service call failing due to too many requests
                   var mockResponse = new Mock<Response>();
                   var batchErrorJson = "{\"code\":\"RequestBodyTooLarge\",\"message\":{\"value\":\"RequestBodyTooLarge\"},\"values\":[{\"key\": \"key1\",\"value\":\"value1\"},{\"key\": \"key2\",\"value\":\"value2\"}]}";
                   var binaryData = new BinaryData(batchErrorJson);
                   mockResponse.Setup(response => response.Content).Returns(binaryData);

                   throw new RequestFailedException(mockResponse.Object);
               }
               else
               {
                   // The quue should be 50 as we halved the request size
                   Assert.AreEqual(50, taskCollection.Value.Count);

                   BatchTaskAddCollectionResult batchTaskAddCollectionResult = CreateBatchTaskAddCollectionResult(taskCollection);
                   return Response.FromValue(batchTaskAddCollectionResult, Mock.Of<Response>());
               }
           }
           );

            BatchClient batchClient = clientMock.Object;
            TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(batchClient, "jobId", null);

            List<BatchTaskCreateContent> tasks = new List<BatchTaskCreateContent>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateContent($"task{i}", "cmd /c echo Hello World"));
            }

            // Act
            CreateTasksResult result = await addTasksWorkflowManager.AddTasksAsync(tasks, "jobId");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(tasksCount, result.BatchTaskAddResults.Count);
            Assert.AreEqual(tasksCount, result.Pass);
            Assert.AreEqual(0, result.Fail);
        }

        [Test]
        public async Task Tasks_10000_Parrellel_10()
        {
            // Arrange
            int tasksCount = 10000;
            int parrellelTasks = 10;

            Mock<BatchClient> clientMock = new Mock<BatchClient>();

            clientMock.Setup(c => c.CreateTaskCollectionAsync(
               It.IsAny<string>(),
               It.IsAny<BatchTaskGroup>(),
               It.IsAny<int?>(),
               It.IsAny<DateTimeOffset?>(),
               It.IsAny<CancellationToken>())
           )
           .ReturnsAsync((string jobId, BatchTaskGroup taskCollection, int? timeOutInSecondsl, DateTimeOffset? ocpdate, CancellationToken cancellationToken) =>
           {
               // The defaul size should be 100
               Assert.AreEqual(100, taskCollection.Value.Count);

               BatchTaskAddCollectionResult batchTaskAddCollectionResult = CreateBatchTaskAddCollectionResult(taskCollection);
               return Response.FromValue(batchTaskAddCollectionResult, Mock.Of<Response>());
           }
           );

            BatchClient batchClient = clientMock.Object;
            BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
            {
                MaxDegreeOfParallelism = parrellelTasks
            };

            TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(batchClient, "jobId", parallelOptions);

            List<BatchTaskCreateContent> tasks = new List<BatchTaskCreateContent>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateContent($"task{i}", "cmd /c echo Hello World"));
            }

            // Act
            CreateTasksResult result = await addTasksWorkflowManager.AddTasksAsync(tasks, "jobId");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(tasksCount, result.BatchTaskAddResults.Count);
            Assert.AreEqual(tasksCount, result.Pass);
            Assert.AreEqual(0, result.Fail);
        }

        [Test]
        public async Task Tasks_10000_Parrellel_100()
        {
            // Arrange
            int tasksCount = 10000;
            int parrellelTasks = 100;

            Mock<BatchClient> clientMock = new Mock<BatchClient>();

            clientMock.Setup(c => c.CreateTaskCollectionAsync(
               It.IsAny<string>(),
               It.IsAny<BatchTaskGroup>(),
               It.IsAny<int?>(),
               It.IsAny<DateTimeOffset?>(),
               It.IsAny<CancellationToken>())
           )
           .ReturnsAsync((string jobId, BatchTaskGroup taskCollection, int? timeOutInSecondsl, DateTimeOffset? ocpdate, CancellationToken cancellationToken) =>
           {
               // The defaul size should be 100
               Assert.AreEqual(100, taskCollection.Value.Count);

               BatchTaskAddCollectionResult batchTaskAddCollectionResult = CreateBatchTaskAddCollectionResult(taskCollection);
               return Response.FromValue(batchTaskAddCollectionResult, Mock.Of<Response>());
           }
           );

            BatchClient batchClient = clientMock.Object;
            BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
            {
                MaxDegreeOfParallelism = parrellelTasks
            };

            TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(batchClient, "jobId", parallelOptions);

            List<BatchTaskCreateContent> tasks = new List<BatchTaskCreateContent>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateContent($"task{i}", "cmd /c echo Hello World"));
            }

            // Act
            CreateTasksResult result = await addTasksWorkflowManager.AddTasksAsync(tasks, "jobId");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(tasksCount, result.BatchTaskAddResults.Count);
            Assert.AreEqual(tasksCount, result.Pass);
            Assert.AreEqual(0, result.Fail);
        }

        [Test]
        public async Task Tasks_10000_Parrellel_100_ServerErrors()
        {
            // Arrange
            int tasksCount = 10000;
            int parrellelTasks = 100;

            Mock<BatchClient> clientMock = new Mock<BatchClient>();

            clientMock.Setup(c => c.CreateTaskCollectionAsync(
               It.IsAny<string>(),
               It.IsAny<BatchTaskGroup>(),
               It.IsAny<int?>(),
               It.IsAny<DateTimeOffset?>(),
               It.IsAny<CancellationToken>())
           )
           .ReturnsAsync((string jobId, BatchTaskGroup taskCollection, int? timeOutInSecondsl, DateTimeOffset? ocpdate, CancellationToken cancellationToken) =>
           {
               // creating a BatchTaskAddCollectionResult with 50% success rate, should triger retries
               BatchTaskAddCollectionResult batchTaskAddCollectionResult = CreateBatchTaskAddCollectionResult(taskCollection,0.5);
               return Response.FromValue(batchTaskAddCollectionResult, Mock.Of<Response>());
           }
           );

            BatchClient batchClient = clientMock.Object;
            BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
            {
                MaxDegreeOfParallelism = parrellelTasks
            };

            TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(batchClient, "jobId", parallelOptions);

            List<BatchTaskCreateContent> tasks = new List<BatchTaskCreateContent>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateContent($"task{i}", "cmd /c echo Hello World"));
            }

            // Act
            CreateTasksResult result = await addTasksWorkflowManager.AddTasksAsync(tasks, "jobId");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(tasksCount, result.BatchTaskAddResults.Count);
            Assert.AreEqual(tasksCount, result.Pass);
            Assert.AreEqual(0, result.Fail);
        }

        [Test]
        public async Task Tasks_10000_Parrellel_10_TooManyRequests()
        {
            // Arrange
            int tasksCount = 10000;
            int parrellelTasks = 10;

            Mock<BatchClient> clientMock = new Mock<BatchClient>();

            clientMock.Setup(c => c.CreateTaskCollectionAsync(
               It.IsAny<string>(),
               It.IsAny<BatchTaskGroup>(),
               It.IsAny<int?>(),
               It.IsAny<DateTimeOffset?>(),
               It.IsAny<CancellationToken>())
           )
           .ReturnsAsync((string jobId, BatchTaskGroup taskCollection, int? timeOutInSecondsl, DateTimeOffset? ocpdate, CancellationToken cancellationToken) =>
           {
               var random = new Random();
               if (random.NextDouble() < 0.1) // 10% chance to execute
               {
                   // mock the service call failing due to too many requests
                   var mockResponse = new Mock<Response>();
                   var batchErrorJson = "{\"code\":\"TooManyRequests\",\"message\":{\"value\":\"TooManyRequests\"},\"values\":[{\"key\": \"key1\",\"value\":\"value1\"},{\"key\": \"key2\",\"value\":\"value2\"}]}";
                   var binaryData = new BinaryData(batchErrorJson);
                   mockResponse.Setup(response => response.Content).Returns(binaryData);

                   throw new RequestFailedException(mockResponse.Object);
               }
               else
               {
                   // The defaul size should be 100
                   Assert.AreEqual(100, taskCollection.Value.Count);

                   BatchTaskAddCollectionResult batchTaskAddCollectionResult = CreateBatchTaskAddCollectionResult(taskCollection);
                   return Response.FromValue(batchTaskAddCollectionResult, Mock.Of<Response>());
               }
           }
           );

            BatchClient batchClient = clientMock.Object;
            BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
            {
                MaxDegreeOfParallelism = parrellelTasks,
                MaxTimeBetweenCallsInSeconds = 0
            };

            TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(batchClient, "jobId", parallelOptions);

            List<BatchTaskCreateContent> tasks = new List<BatchTaskCreateContent>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateContent($"task{i}", "cmd /c echo Hello World"));
            }

            // Act
            CreateTasksResult result = await addTasksWorkflowManager.AddTasksAsync(tasks, "jobId");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(tasksCount, result.BatchTaskAddResults.Count);
            Assert.AreEqual(tasksCount, result.Pass);
            Assert.AreEqual(0, result.Fail);
        }

        [Test]
        public async Task Tasks_100000_Parrellel_1000()
        {
            // Arrange
            int tasksCount = 100000;
            int parrellelTasks = 1000;

            Mock<BatchClient> clientMock = new Mock<BatchClient>();

            clientMock.Setup(c => c.CreateTaskCollectionAsync(
               It.IsAny<string>(),
               It.IsAny<BatchTaskGroup>(),
               It.IsAny<int?>(),
               It.IsAny<DateTimeOffset?>(),
               It.IsAny<CancellationToken>())
           )
           .ReturnsAsync((string jobId, BatchTaskGroup taskCollection, int? timeOutInSecondsl, DateTimeOffset? ocpdate, CancellationToken cancellationToken) =>
           {
               // The defaul size should be 100
               Assert.AreEqual(100, taskCollection.Value.Count);

               BatchTaskAddCollectionResult batchTaskAddCollectionResult = CreateBatchTaskAddCollectionResult(taskCollection);
               return Response.FromValue(batchTaskAddCollectionResult, Mock.Of<Response>());
           }
           );

            BatchClient batchClient = clientMock.Object;
            BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
            {
                MaxDegreeOfParallelism = parrellelTasks
            };

            TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(batchClient, "jobId", parallelOptions);

            List<BatchTaskCreateContent> tasks = new List<BatchTaskCreateContent>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateContent($"task{i}", "cmd /c echo Hello World"));
            }

            // Act
            CreateTasksResult result = await addTasksWorkflowManager.AddTasksAsync(tasks, "jobId");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(tasksCount, result.BatchTaskAddResults.Count);
            Assert.AreEqual(tasksCount, result.Pass);
            Assert.AreEqual(0, result.Fail);
        }

        [Test]
        public async Task Tasks_1000000_Parrellel_10000()
        {
            // Arrange
            int tasksCount = 1000000;
            int parrellelTasks = 10000;

            Mock<BatchClient> clientMock = new Mock<BatchClient>();

            clientMock.Setup(c => c.CreateTaskCollectionAsync(
               It.IsAny<string>(),
               It.IsAny<BatchTaskGroup>(),
               It.IsAny<int?>(),
               It.IsAny<DateTimeOffset?>(),
               It.IsAny<CancellationToken>())
           )
           .ReturnsAsync((string jobId, BatchTaskGroup taskCollection, int? timeOutInSecondsl, DateTimeOffset? ocpdate, CancellationToken cancellationToken) =>
           {
               // The defaul size should be 100
               Assert.AreEqual(100, taskCollection.Value.Count);

               BatchTaskAddCollectionResult batchTaskAddCollectionResult = CreateBatchTaskAddCollectionResult(taskCollection);
               return Response.FromValue(batchTaskAddCollectionResult, Mock.Of<Response>());
           }
           );

            BatchClient batchClient = clientMock.Object;
            BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
            {
                MaxDegreeOfParallelism = parrellelTasks
            };

            TasksWorkflowManager addTasksWorkflowManager = new TasksWorkflowManager(batchClient, "jobId", parallelOptions);

            List<BatchTaskCreateContent> tasks = new List<BatchTaskCreateContent>();
            for (int i = 0; i < tasksCount; i++)
            {
                tasks.Add(new BatchTaskCreateContent($"task{i}", "cmd /c echo Hello World"));
            }

            // Act
            CreateTasksResult result = await addTasksWorkflowManager.AddTasksAsync(tasks, "jobId");

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(tasksCount, result.BatchTaskAddResults.Count);
            Assert.AreEqual(tasksCount, result.Pass);
            Assert.AreEqual(0, result.Fail);
        }

        /// <summary>
        /// Helper method to create a BatchTaskAddCollectionResult
        /// </summary>
        /// <param name="batchTaskGroup"></param>
        /// <returns>A BatchTaskAddCollectionResult object</returns>
        private BatchTaskAddCollectionResult CreateBatchTaskAddCollectionResult(BatchTaskGroup batchTaskGroup, double passPercentage=1)
        {
            var mockResponse = new Mock<Response>();

            string batchTaskAddCollectionJson = @"
            {
              ""value"": [";

            int v = batchTaskGroup.Value.Count;
            for (int i = 0; i < v; i++)
            {
                var random = new Random();
                if (random.NextDouble() <= passPercentage) // chance for success result
                {
                    batchTaskAddCollectionJson += @"
                {
                  ""taskId"": """ + batchTaskGroup.Value[i].Id + @""",
                  ""status"": ""success"",
                  ""error"": null
                }";
                }
                else
                {
                    batchTaskAddCollectionJson += @"
                {
                  ""taskId"": """ + batchTaskGroup.Value[i].Id + @""",
                  ""status"": ""servererror"",
                  ""error"": {
                     ""code"": ""OperationTimedOut"",
                     ""message"": {
                         ""value"": ""Error message""
                     },
                     ""values"": [
                       {
                        ""key"": ""key1"",
                        ""value"": ""value1""
                       },
                       {
                         ""key"": ""key2"",
                         ""value"": ""value2""
                       }
                     ]
                   }
                }";
                }

                if ( i+1 < v)
                {
                    batchTaskAddCollectionJson += ",";
                }
            }
            batchTaskAddCollectionJson += @"
              ]
            }";

            var binaryData = new BinaryData(batchTaskAddCollectionJson);
            mockResponse.Setup(response => response.Content).Returns(binaryData);

            return BatchTaskAddCollectionResult.FromResponse(mockResponse.Object);
        }
    }
}
