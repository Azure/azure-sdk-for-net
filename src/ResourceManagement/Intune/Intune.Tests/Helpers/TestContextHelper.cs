//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Microsoft.Azure.Test.HttpRecorder;
using System.Linq;

namespace Microsoft.Azure.Management.Intune.Tests.Helpers
{
    /// <summary>
    /// When policy is created, the policy Id parameter is created in client. If mock recording were to replay the test, 
    /// it has to use the same policy Id when recorded & playedback, for that we need to save the variable in Mocktestcontext.
    /// Below method handles saving/retrieving from MockContext.
    /// </summary>
    public class TestContextHelper
    {
        public static T GetValueFromTestContext<T>(Func<T> constructor, Func<string, T> parser, string mockName)
        {
            T retValue = default(T);

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                retValue = constructor.Invoke();
                HttpMockServer.Variables[mockName] = retValue.ToString();
            }
            else
            {
                if (HttpMockServer.Variables.ContainsKey(mockName))
                {
                    retValue = parser.Invoke(HttpMockServer.Variables[mockName]);
                }
            }

            return retValue;
        }

        public static string GetAdGroupFromTestContext(string mockName)
        {
            string retValue = string.Empty;
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                var aadClient = new AADClientHelper();
                var adGroups = aadClient.GetUserGroups().GetAwaiter().GetResult();
                var adGroupList = adGroups.Where(x => x.Keys.Contains("ID")).Select(x => x["ID"]).ToList();
                if (adGroupList.Count >= 1)
                {
                    retValue = HttpMockServer.Variables[mockName] = adGroupList.ElementAt(0);
                }
                else
                {
                    throw new Exception(string.Format("Unexpected number of Groups. Expected: adGroupList.Count >= 1 but actual = {0}", adGroupList.Count));
                }
            }
            else
            {
                if (HttpMockServer.Variables.ContainsKey(mockName))
                {
                    retValue = HttpMockServer.Variables[mockName];
                }
                else
                {
                    throw new Exception(string.Format("HttpMockServer.Variables does not have a value to retrieve for mockName={0}", mockName));
                }
            }

            return retValue;
        }

        public static string GetAdUserFromTestContext(string mockName)
        {
            string retValue = string.Empty;
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                var aadClient = new AADClientHelper();
                retValue = HttpMockServer.Variables[mockName] = aadClient.UserId;                
            }
            else
            {
                if (HttpMockServer.Variables.ContainsKey(mockName))
                {
                    retValue = HttpMockServer.Variables[mockName];
                }
                else
                {
                    throw new Exception(string.Format("HttpMockServer.Variables does not have a value to retrieve for mockName={0}", mockName));
                }
            }

            return retValue;
        }
    }
}
