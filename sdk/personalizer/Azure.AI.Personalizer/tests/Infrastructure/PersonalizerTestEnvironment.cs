using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Microsoft.Azure.AI.Personalizer.Tests
{
    public class PersonalizerTestEnvironment: TestEnvironment
    {
        /// <summary>The name of the environment variable from which Personalizer resource's endpoint will be extracted for the live tests.</summary>
        internal const string EndpointEnvironmentVariableName = "PERSONALIZER_ENDPOINT";

        /// <summary>The name of the environment variable from which the Personalizer resource's API key will be extracted for the live tests.</summary>
        internal const string ApiKeyEnvironmentVariableName = "PERSONALIZER_API_KEY";

        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName);
        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);
    }
}
