// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.TestBase;
using Microsoft.TestBase.Models;
using System;
using System.Collections.Generic;
using System.Net;


namespace TestBase.Tests
{
    public class TestbaseBase
    {
        protected const string TestPrefix = "testbase";
        protected string t_ResourceGroupName= "testbase_rg";
        protected string t_TestBaseAccountName= "testBaseAccount_kaifa";
        /// <summary>
        /// package name + "-" + Version , e.g. package1-1.0.0
        /// </summary>
        protected string t_PackageName = "package2_kaifa-1.0";//Package name + "-" + Version
        protected string t_CustomerEventName = "testbase6336_event";

        protected TestBaseClient t_TestBaseClient;
        protected ResourceManagementClient t_ResourceClient;
        protected StorageManagementClient t_StorageClient;
        protected NetworkManagementClient t_NetworkClient;
        protected ManagedServiceIdentityClient t_ManagedSvcClient;

        protected ResourceGroup t_ResourceGroup;
        protected TestBaseAccountResource t_TestBaseAccount;

        protected bool t_initialized = false;
        protected object t_lock = new object();

        protected string t_subId;
        protected string t_location;

        protected void EnsureClientInitialized(MockContext context)
        {
            if (!t_initialized)
            {
                lock (t_lock)
                {
                    if (!t_initialized)
                    {
                        t_TestBaseClient = TestbaseManagementTestUtilities.GetTestbaseManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        t_ResourceClient = TestbaseManagementTestUtilities.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        t_StorageClient = TestbaseManagementTestUtilities.GetStorageManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        t_NetworkClient = TestbaseManagementTestUtilities.GetNetworkManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        t_ManagedSvcClient = TestbaseManagementTestUtilities.GetManagedServiceIdentityClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                        t_subId = t_TestBaseClient.SubscriptionId;
                        t_location = TestbaseManagementTestUtilities.DefaultLocation;
                    }
                }
            }
        }

        /// <summary>
        /// The type of the OS Update SecurityUpdate/FeatureUpdate.
        /// </summary>
        protected class OsUpdateType
        {
            public static string SecurityUpdate = "SecurityUpdate";
            public static string FeatureUpdate = "FeatureUpdate";
        }

        /// <summary>
        /// The type of Analysis Result
        /// </summary>
        protected class AnalysisResultType
        {
            public static string ScriptExecution = "scriptExecution";
            public static string Reliability = "reliability";
            public static string MemoryUtilization = "memoryUtilization";
            public static string CPUUtilization = "CPUUtilization";
            public static string MemoryRegression = "memoryRegression";
            public static string CPURegression = "CPURegression";
        }

        /// <summary>
        /// Gets a formatted string for the current time, yyyyMMddHHmmssfff
        /// </summary>
        protected string ErrorValue { get { return DateTime.Now.ToString("yyyyMMddHHmmssfff"); } }
    }
}
