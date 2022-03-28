using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.StressTests.EventProcessorTest;
using dotenv.net;

namespace Azure.Messaging.EventHubs.StressTests
{
    public class BasicPublishReadTestRunner
    {
        public async static Task Main(string[] args)
        {
            var ENV_FILE = Environment.GetEnvironmentVariable("ENV_FILE");
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] {ENV_FILE}));
            var connectionString = Environment.GetEnvironmentVariable("EVENTHUB_NAMESPACE_CONNECTION_STRING");
            var eventHubName = Environment.GetEnvironmentVariable("EVENTHUB_NAME");
            
            int durationInHours = 72;
            var BPRtest = new BasicPublishReadTest();
            await BPRtest.Run(connectionString, eventHubName, TimeSpan.FromHours(durationInHours));
        }
    }
}



	
