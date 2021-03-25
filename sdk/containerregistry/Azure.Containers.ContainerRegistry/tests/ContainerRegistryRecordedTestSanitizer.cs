// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using Azure.Core.TestFramework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryRecordedTestSanitizer : RecordedTestSanitizer
    {
        public List<string> FormEncodedBodySanitizers { get; } = new List<string>();

        public ContainerRegistryRecordedTestSanitizer()
            : base()
        {
            JsonPathSanitizers.Add("$..access_token");
            JsonPathSanitizers.Add("$..refresh_token");

            FormEncodedBodySanitizers.Add("access_token");
            FormEncodedBodySanitizers.Add("refresh_token");
        }

        public override string SanitizeTextBody(string contentType, string body)
        {
            string jsonSanitizedBody = base.SanitizeTextBody(contentType, body);

            if (FormEncodedBodySanitizers.Count == 0)
            {
                return jsonSanitizedBody;
            }

            try
            {
                if (contentType == "application/x-www-form-urlencoded")
                {
                    string urlEncodedSanitizedBody = string.Empty;

                    NameValueCollection queryParams = HttpUtility.ParseQueryString(jsonSanitizedBody);
                    for (int i = 0; i < queryParams.Keys.Count; i++)
                    {
                        string key = queryParams.Keys[i].ToString();
                        foreach (string paramToSanitize in FormEncodedBodySanitizers)
                        {
                            if (key == paramToSanitize)
                            {
                                queryParams[key] = SanitizeValue;
                            }
                        }
                    }

                    return queryParams.ToString();
                }

                return jsonSanitizedBody;
            }
            catch
            {
                return jsonSanitizedBody;
            }
        }
    }
}
