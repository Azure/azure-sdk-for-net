﻿//
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
//

using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Common.Internals;
using Hyak.Common.TransientFaultHandling;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;
using Xunit;
using Microsoft.Azure.Test;
using Newtonsoft.Json;
using Microsoft.Azure.Test.HttpRecorder;
using System.Configuration;
using Microsoft.Azure;
using System.Reflection;
using System.Net.Http;
using System.Net.Security;

namespace BackupServices.Tests
{
    public class BackupServicesTestsBase : TestBase
    {
        public new static T GetServiceClient<T>() where T : class
        {
            var factory = (TestEnvironmentFactory)new CSMTestEnvironmentFactory();

            var testEnvironment = factory.GetTestEnvironment();

            ServicePointManager.ServerCertificateValidationCallback = IgnoreCertificateErrorHandler;

            BackupServicesManagementClient client;

            string resourceName = ConfigurationManager.AppSettings["RESOURCE_NAME"];
            string resourceGroupName = ConfigurationManager.AppSettings["RESOURCE_GROUP_NAME"];
            if (testEnvironment.UsesCustomUri())
            {
                client = new BackupServicesManagementClient(
                    resourceName,
                    resourceGroupName,
                    testEnvironment.Credentials as SubscriptionCloudCredentials,
                    testEnvironment.BaseUri);
            }

            else
            {
                client = new BackupServicesManagementClient(
                    resourceName,
                    resourceGroupName,
                    testEnvironment.Credentials as SubscriptionCloudCredentials);
            }

            return GetServiceClient<T>(factory, client);
        }


        public static T GetServiceClient<T>(TestEnvironmentFactory factory, BackupServicesManagementClient client) where T : class
        {
            TestEnvironment testEnvironment = factory.GetTestEnvironment();

            HttpMockServer instance;
            try
            {
                instance = HttpMockServer.CreateInstance();
            }
            catch (ApplicationException)
            {
                HttpMockServer.Initialize("TestEnvironment", "InitialCreation");
                instance = HttpMockServer.CreateInstance();
            }
            T obj2 = typeof(T).GetMethod("WithHandler", new Type[1]
            {
                typeof (DelegatingHandler)
            }).Invoke((object)client, new object[1]
            {
                (object) instance
            }) as T;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables[TestEnvironment.SubscriptionIdKey] = testEnvironment.SubscriptionId;
            }

            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                PropertyInfo property1 = typeof(T).GetProperty("LongRunningOperationInitialTimeout", typeof(int));
                PropertyInfo property2 = typeof(T).GetProperty("LongRunningOperationRetryTimeout", typeof(int));
                if (property1 != (PropertyInfo)null && property2 != (PropertyInfo)null)
                {
                    property1.SetValue((object)obj2, (object)0);
                    property2.SetValue((object)obj2, (object)0);
                }
            }
            return obj2;
        }

        private static bool IgnoreCertificateErrorHandler
           (object sender,
           System.Security.Cryptography.X509Certificates.X509Certificate certificate,
           System.Security.Cryptography.X509Certificates.X509Chain chain,
           SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static CustomRequestHeaders GetCustomRequestHeaders()
        {
            return new CustomRequestHeaders()
            {
                ClientRequestId = Guid.NewGuid().ToString(),
            };
        }
    }
}