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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClientAbstractionTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Data;
    using Microsoft.Hadoop.Client.WebHCatResources;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class JobsPayloadConverterTests : IntegrationTestBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidJobRequest_JobName()
        {
            var mapReduceJob = new MapReduceJobCreateParameters()
            {
                JobName = "pi estimation jobDetails"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeMapReduceRequest("hadoop", mapReduceJob);
            Assert.IsTrue(payload.Contains(Uri.EscapeDataString(string.Format("{0}={1}", WebHCatConstants.DefineJobName, mapReduceJob.JobName))));
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidJobRequestWithCallback()
        {
            var mapReduceJob = new MapReduceJobCreateParameters()
            {
                JobName = "pi estimation jobDetails",
                Callback = "http://someball.com/$jobid/notvalid"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeMapReduceRequest("hadoop", mapReduceJob);
            Assert.IsTrue(payload.Contains(Uri.EscapeDataString(string.Format("{0}={1}", WebHCatConstants.DefineJobName, mapReduceJob.JobName))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", Uri.EscapeDataString(WebHCatConstants.Callback), Uri.EscapeDataString(mapReduceJob.Callback))));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void DoesNotAddDefineIfJobNameAbsent()
        {
            var hiveJob = new HiveJobCreateParameters()
            {
                Query = "show tables"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeHiveRequest("hadoop", hiveJob);
            Assert.IsFalse(payload.Contains(Uri.EscapeDataString(string.Format("{0}={1}", WebHCatConstants.DefineJobName, hiveJob.JobName))));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        [TestCategory("Defect")]
        public void PayloadHasEnableLogsFalseByDefault()
        {
            var hiveJob = new HiveJobCreateParameters()
            {
                Query = "show tables",
                StatusFolder = "/showtableslocation"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeHiveRequest("hadoop", hiveJob);
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", HadoopRemoteRestConstants.EnableLogging, "false")));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        [TestCategory("Defect")]
        public void JobCanSetEnableLogsTrue()
        {
            var hiveJob = new HiveJobCreateParameters()
            {
                Query = "show tables",
                EnableTaskLogs = true,
                StatusFolder = "/showtableslocation"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeHiveRequest("hadoop", hiveJob);
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", HadoopRemoteRestConstants.EnableLogging, "true")));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        [TestCategory("Defect")]
        public void PayloadHasEnableLogsFalse()
        {
            var hiveJob = new HiveJobCreateParameters()
            {
                Query = "show tables"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeHiveRequest("hadoop", hiveJob);
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", HadoopRemoteRestConstants.EnableLogging, "false")));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidJobRequest_JobName_MoreThanOnce()
        {
            var mapReduceJob = new MapReduceJobCreateParameters() { JobName = "pi estimation jobDetails" };

            var payloadConverter = new PayloadConverterBase();
            for (int index = 0; index < 3; index++)
            {
                var payload = payloadConverter.SerializeMapReduceRequest("hadoop", mapReduceJob);
                Assert.IsTrue(payload.Contains(Uri.EscapeDataString(string.Format("{0}={1}", WebHCatConstants.DefineJobName, mapReduceJob.JobName))));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidJobRequest_UserName()
        {
            var mapReduceJob = new MapReduceJobCreateParameters()
            {
                JobName = "pi estimation jobDetails"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeMapReduceRequest("hadoop", mapReduceJob);
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.UserName, "hadoop")));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidJobRequest_Arguments()
        {
            var pigJob = new PigJobCreateParameters();
            pigJob.Arguments.Add("16");
            pigJob.Query = "show tables";
            pigJob.Arguments.Add("10000");

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializePigRequest("hadoop", pigJob);
            foreach (var argument in pigJob.Arguments)
            {
                Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Arg, argument)));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void ShouldNotSerializePigJobName()
        {
            var pigJob = new PigJobCreateParameters();
            pigJob.Arguments.Add("16");
            pigJob.Query = "show tables";
            pigJob.Arguments.Add("10000");

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializePigRequest("hadoop", pigJob);
            Assert.IsFalse((payload.Contains(WebHCatConstants.DefineJobName)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void ShouldNotSerializeSqoopJobName()
        {
            var sqoopJob = new SqoopJobCreateParameters();
            sqoopJob.Command = "show tables";

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeSqoopRequest("hadoop", sqoopJob);
            Assert.IsFalse((payload.Contains(WebHCatConstants.DefineJobName)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidJobRequest_Arguments_And_Defines()
        {
            var piJob = new MapReduceJobCreateParameters();
            piJob.JarFile = "hadoop-examples.jar";

            piJob.Arguments.Add("16");
            piJob.Arguments.Add("10000");
            piJob.Defines.Add("map.red.tasks", "1000");
            piJob.Defines.Add("other.tasks", "1000");

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeMapReduceRequest("hadoop", piJob);
            foreach (var argument in piJob.Arguments)
            {
                Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Arg, argument)));
            }

            int defineCounter = 0;
            foreach (var define in piJob.Defines)
            {
                defineCounter++;
                Assert.IsTrue(payload.Contains(Uri.EscapeDataString(string.Format("{0}={1}", define.Key, define.Value))));
            }

            Assert.AreEqual(piJob.Defines.Count, defineCounter);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidJobRequest_Defines()
        {
            var mapReduceJob = new MapReduceJobCreateParameters();
            mapReduceJob.JobName = "Define counter test";
            mapReduceJob.Defines.Add(new KeyValuePair<string, string>("map.input.tasks", "1000"));
            mapReduceJob.Defines.Add(new KeyValuePair<string, string>("map.input.mappers", "6"));
            mapReduceJob.Defines.Add(new KeyValuePair<string, string>("map.input.reducers", "16"));

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeMapReduceRequest("hadoop", mapReduceJob);

            int defineCounter = 0;
            foreach (var define in mapReduceJob.Defines)
            {
                defineCounter++;
                Assert.IsTrue(payload.Contains(Uri.EscapeDataString(string.Format("{0}={1}", define.Key, define.Value))));
            }

            Assert.AreEqual(mapReduceJob.Defines.Count, defineCounter);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidMapReduceJobRequest()
        {
            var mapReduceJob = new MapReduceJobCreateParameters()
            {
                JarFile = "/example/hadoop-examples.jar",
                ClassName = "pi"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeMapReduceRequest("hadoop", mapReduceJob);

            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Jar, Uri.EscapeDataString(mapReduceJob.JarFile))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Class, Uri.EscapeDataString(mapReduceJob.ClassName))));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidStreamingMapReduceJobRequest()
        {
            var streamingMapReduceJob = new StreamingMapReduceJobCreateParameters()
            {
                Input = "asv://input",
                Output = "asv://output",
                Mapper = "asv://mapper",
                Reducer = "asv://reducer",
                Combiner = "asv://combiner"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeStreamingMapReduceRequest("hadoop", streamingMapReduceJob);

            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Input, Uri.EscapeDataString(streamingMapReduceJob.Input))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Output, Uri.EscapeDataString(streamingMapReduceJob.Output))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Mapper, Uri.EscapeDataString(streamingMapReduceJob.Mapper))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Reducer, Uri.EscapeDataString(streamingMapReduceJob.Reducer))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Combiner, Uri.EscapeDataString(streamingMapReduceJob.Combiner))));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidStreamingMapReduceJobRequest_Defines()
        {
            var streamingMapReduceJob = new StreamingMapReduceJobCreateParameters()
            {
                Input = "asv://input",
                Output = "asv://output",
                Mapper = "asv://mapper",
                Reducer = "asv://reducer",
            };

            streamingMapReduceJob.Defines.Add(new KeyValuePair<string, string>("definekey1", "definevalue1"));
            streamingMapReduceJob.Defines.Add(new KeyValuePair<string, string>("definekey2", "definevalue2"));
            streamingMapReduceJob.Defines.Add(new KeyValuePair<string, string>("definekey3", "definevalue3"));
            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeStreamingMapReduceRequest("hadoop", streamingMapReduceJob);
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Input, Uri.EscapeDataString(streamingMapReduceJob.Input))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Output, Uri.EscapeDataString(streamingMapReduceJob.Output))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Mapper, Uri.EscapeDataString(streamingMapReduceJob.Mapper))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Reducer, Uri.EscapeDataString(streamingMapReduceJob.Reducer))));

            foreach (var define in streamingMapReduceJob.Defines)
            {
                Assert.IsTrue(payload.Contains(Uri.EscapeDataString(string.Format("{0}={1}", define.Key, define.Value))));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidStreamingMapReduceJobRequest_CmdEnv()
        {
            var streamingMapReduceJob = new StreamingMapReduceJobCreateParameters()
            {
                Input = "asv://input",
                Output = "asv://output",
                Mapper = "asv://mapper",
                Reducer = "asv://reducer"
            };

            streamingMapReduceJob.CommandEnvironment.Add("Name1=Value1");
            streamingMapReduceJob.CommandEnvironment.Add("Name2=Value2");

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeStreamingMapReduceRequest("hadoop", streamingMapReduceJob);

            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Input, Uri.EscapeDataString(streamingMapReduceJob.Input))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Output, Uri.EscapeDataString(streamingMapReduceJob.Output))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Mapper, Uri.EscapeDataString(streamingMapReduceJob.Mapper))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Reducer, Uri.EscapeDataString(streamingMapReduceJob.Reducer))));

            foreach (var cmdEnvArgument in streamingMapReduceJob.CommandEnvironment)
            {
                Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.CmdEnv, Uri.EscapeDataString(cmdEnvArgument))));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidStreamingMapReduceJobRequest_WithFiles()
        {
            var streamingMapReduceJob = new StreamingMapReduceJobCreateParameters()
            {
                Input = Constants.WabsProtocolSchemeName + "input",
                Output = Constants.WabsProtocolSchemeName + "output",
                Mapper = Constants.WabsProtocolSchemeName + "mapper",
                Reducer = Constants.WabsProtocolSchemeName + "reducer"
            };

            var resourceFile1 = "asv://container@hostname/myfile1";
            var resourceFile2 = "asv://container@hostname/myfile2";
            var payloadConverter = new PayloadConverterBase();
            streamingMapReduceJob.Files.Add(resourceFile1);
            streamingMapReduceJob.Files.Add(resourceFile2);

            var payload = payloadConverter.SerializeStreamingMapReduceRequest("hadoop", streamingMapReduceJob);

            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Input, Uri.EscapeDataString(streamingMapReduceJob.Input))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Output, Uri.EscapeDataString(streamingMapReduceJob.Output))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Mapper, Uri.EscapeDataString(streamingMapReduceJob.Mapper))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Reducer, Uri.EscapeDataString(streamingMapReduceJob.Reducer))));
            Assert.IsTrue(payload.Contains(Uri.EscapeDataString(resourceFile1)));
            Assert.IsTrue(payload.Contains(Uri.EscapeDataString(resourceFile2)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidStreamingMapReduceJobRequest_WithNoReducer()
        {
            var streamingMapReduceJob = new StreamingMapReduceJobCreateParameters()
            {
                Input = Constants.WabsProtocolSchemeName + "input",
                Output = Constants.WabsProtocolSchemeName + "output",
                Mapper = Constants.WabsProtocolSchemeName + "mapper"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeStreamingMapReduceRequest("hadoop", streamingMapReduceJob);

            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Input, Uri.EscapeDataString(streamingMapReduceJob.Input))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Output, Uri.EscapeDataString(streamingMapReduceJob.Output))));
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Mapper, Uri.EscapeDataString(streamingMapReduceJob.Mapper))));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidHiveJobRequest()
        {
            var hiveJob = new HiveJobCreateParameters()
            {
                Query = "show tables"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeHiveRequest("hadoop", hiveJob);

            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Execute, Uri.EscapeDataString(hiveJob.Query))));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidSqoopJobRequest_Command()
        {
            var sqoopJob = new SqoopJobCreateParameters()
            {
                Command = "show tables"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeSqoopRequest("hadoop", sqoopJob);
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Command, Uri.EscapeDataString(sqoopJob.Command))));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidSqoopJobRequest_File()
        {
            var sqoopJob = new SqoopJobCreateParameters()
            {
                File = "file.sqoop"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeSqoopRequest("hadoop", sqoopJob);
            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.File, Uri.EscapeDataString(sqoopJob.File))));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidHiveJobRequest_WithFile()
        {
            var hiveJob = new HiveJobCreateParameters()
            {
                File = Constants.WabsProtocolSchemeName + "filepath.hql"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializeHiveRequest("hadoop", hiveJob);

            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.File, Uri.EscapeDataString(hiveJob.File))));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidPigJobRequest()
        {
            var pigJob = new PigJobCreateParameters()
            {
                Query = "show tables"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializePigRequest("hadoop", pigJob);

            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.Execute, Uri.EscapeDataString(pigJob.Query))));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanSerializeValidPigJobRequest_WithFile()
        {
            var pigJob = new PigJobCreateParameters()
            {
                File = Constants.WabsProtocolSchemeName + "filepath.hql"
            };

            var payloadConverter = new PayloadConverterBase();
            var payload = payloadConverter.SerializePigRequest("hadoop", pigJob);

            Assert.IsTrue(payload.Contains(string.Format("{0}={1}", WebHCatConstants.File, Uri.EscapeDataString(pigJob.File))));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Payload")]
        public void CanDeserializeJobRequestWithInvalidJobId()
        {
            var payloadConverter = new PayloadConverter();
            var payload = payloadConverter.DeserializeJobDetails("{ \"error\": \"job_1111 does not exist\"}");

            Assert.IsNull(payload);
        }
    }
}
