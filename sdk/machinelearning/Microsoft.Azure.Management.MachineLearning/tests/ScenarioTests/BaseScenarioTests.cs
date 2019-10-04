// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace MachineLearning.Tests.ScenarioTests
{
    public abstract class BaseScenarioTests : TestBase
    {
        protected static string GenerateCloudExceptionReport(CloudException cloudException)
        {
            var errorReport = new StringBuilder();

            string requestId = cloudException.RequestId;
            if (string.IsNullOrWhiteSpace(requestId) && cloudException.Response != null)
            {
                // Try to obtain the request id from the HTTP response associated with the exception
                IEnumerable<string> headerValues = Enumerable.Empty<string>();
                if (cloudException.Response.Headers != null &&
                    cloudException.Response.Headers.TryGetValue("x-ms-request-id", out headerValues))
                {
                    requestId = headerValues.First();
                }
            }

            errorReport.AppendLine($"Request Id: {requestId}");
            if (cloudException.Body != null)
            {
                errorReport.AppendLine($"Error Code: {cloudException.Body.Code}");
                errorReport.AppendLine($"Error Message: {cloudException.Body.Message}");
                if (cloudException.Body.Details.Any())
                {
                    errorReport.AppendLine("Error Details:");
                    foreach (var errorDetail in cloudException.Body.Details)
                    {
                        errorReport.AppendLine($"\t[Code={errorDetail.Code}, Message={errorDetail.Message}]");
                    }
                }
            }

            return errorReport.ToString();
        }

        protected static void DisposeOfTestResource(Action disposalCall)
        {
            try
            {
                disposalCall();
            }
            catch (CloudException cloudEx)
            {
                Trace.TraceWarning("Caught unexpected exception during resource cleanup: ");
                Trace.TraceWarning(BaseScenarioTests.GenerateCloudExceptionReport(cloudEx));
            }
            catch (Exception ex)
            {
                Trace.TraceWarning("Caught unexpected exception during resource cleanup: {0}", ex.Message);
            }
        }
    }
}

