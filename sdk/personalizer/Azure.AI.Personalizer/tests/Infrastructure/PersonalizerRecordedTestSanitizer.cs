using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Microsoft.Azure.AI.Personalizer.Tests
{
    public class PersonalizerRecordedTestSanitizer: RecordedTestSanitizer
    {
        public PersonalizerRecordedTestSanitizer(): base()
        {
            AddJsonPathSanitizer("$..accessToken");
            AddJsonPathSanitizer("$..source");
            // TODO: Remove when re-recording
            LegacyConvertJsonDateTokens = true;
        }

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey("Ocp-Apim-Subscription-Key"))
            {
                headers["Ocp-Apim-Subscription-Key"] = new[] { SanitizeValue };
            }

            base.SanitizeHeaders(headers);
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                PersonalizerTestEnvironment.ApiKeyEnvironmentVariableName => SanitizeValue,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }
    }
}
