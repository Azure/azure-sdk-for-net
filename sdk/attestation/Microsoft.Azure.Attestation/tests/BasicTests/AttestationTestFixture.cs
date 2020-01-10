// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Azure.Attestation.Tests
{
    public class AttestationTestFixture : IDisposable
    {
        public AttestationTestFixture()
        {
            Initialize(this.GetType());
        }

        public void Initialize(Type type)
        {
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
            HttpMockServer.Initialize(type, "InitialCreation", HttpRecorderMode.Record);
            HttpMockServer.CreateInstance();
        }

        public AttestationClient CreateAttestationClient()
        {
            string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkJCOENlRlZxeWFHckdOdWVoSklpTDRkZmp6dyIsImtpZCI6IkJCOENlRlZxeWFHckdOdWVoSklpTDRkZmp6dyJ9.eyJhdWQiOiJodHRwczovL2F0dGVzdC5henVyZS5uZXQiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDcvIiwiaWF0IjoxNTc2MDE4MTI1LCJuYmYiOjE1NzYwMTgxMjUsImV4cCI6MTU3NjAyMjAyNSwiX2NsYWltX25hbWVzIjp7Imdyb3VwcyI6InNyYzEifSwiX2NsYWltX3NvdXJjZXMiOnsic3JjMSI6eyJlbmRwb2ludCI6Imh0dHBzOi8vZ3JhcGgud2luZG93cy5uZXQvNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3L3VzZXJzL2U0ZDA2ZWU4LWNhYjctNDc1My1hOThlLTJlNmU0OTM1MjllNS9nZXRNZW1iZXJPYmplY3RzIn19LCJhY3IiOiIxIiwiYWlvIjoiQVVRQXUvOE5BQUFBelE2a2FNOUlmanV6dlZoK3V5eWlobnhBVHorVURzMHNJUHBNVUZ6b1lJNnFvTEc2ZE82QTh0UTZVbzM1bHJOeXg4bDFZMXlSTTZScG5vM3dWc1psZnc9PSIsImFtciI6WyJyc2EiLCJtZmEiXSwiYXBwaWQiOiJkMzU5MGVkNi01MmIzLTQxMDItYWVmZi1hYWQyMjkyYWIwMWMiLCJhcHBpZGFjciI6IjAiLCJkZXZpY2VpZCI6IjRhYWIxMjIxLWVlMDktNDFjYi05ODRkLTdlNzQ2OThhNDdlYSIsImZhbWlseV9uYW1lIjoiTGVpIiwiZ2l2ZW5fbmFtZSI6IlNodWFuZ3lhbiIsImlwYWRkciI6IjEzMS4xMDcuMTYwLjE2MyIsIm5hbWUiOiJTaHVhbmd5YW4gTGVpIiwib2lkIjoiZTRkMDZlZTgtY2FiNy00NzUzLWE5OGUtMmU2ZTQ5MzUyOWU1Iiwib25wcmVtX3NpZCI6IlMtMS01LTIxLTIxMjc1MjExODQtMTYwNDAxMjkyMC0xODg3OTI3NTI3LTM1MjIzMTc5IiwicHVpZCI6IjEwMDMyMDAwNDQ1Q0Y1MjgiLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzdWIiOiI5MTYzMjdMaXJBSkdQSFoyNFNJT1BRa2VYTHQ5Q2ZReF9Nbm8tZ0pvTGY4IiwidGlkIjoiNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3IiwidW5pcXVlX25hbWUiOiJzaGxlaUBtaWNyb3NvZnQuY29tIiwidXBuIjoic2hsZWlAbWljcm9zb2Z0LmNvbSIsInV0aSI6IlZDQm5DS3pyRGsyMG1oRFhmaDRKQUEiLCJ2ZXIiOiIxLjAifQ.JMuwfFYBecyM73ECf7AHubct8Hpe7cZOVUub9niL6Yid7F3LXQ-wfTgGQlBQV-7gZ6PxTrA3bzFzENw867_mcsKaEdeRT6Wd43-nUjirf8dNz7NCEitGlcVZamLGu0bkiQeTkpPbFg6i_KGKRt4gWHbrZXsFGNBf_VSKtHQZ-Q5F3jIdxcj0fQjt_k7xT1x_901qfWtQl6QrFvloFclR9u_Xwy44GOiU23zkFNolpRc3V1GxlY25IQ3xQb7C8SF-TqGAmo2xBV3MTAwRKexEYrdtB46AOPtR6_A3jLNi62HZG52vmFihFEAT7QFZndVSoketibbniR60fWwMeIGcxg";
            AttestationCredentials credentials = new AttestationCredentials(accessToken);
            var myclient = new AttestationClient(credentials, GetHandlers());
            return myclient;
        }

        public DelegatingHandler[] GetHandlers()
        {
            HttpMockServer server = HttpMockServer.CreateInstance();
            var testHttpHandler = new CustomDelegatingHandler();
            return new DelegatingHandler[] { server, testHttpHandler };
        }

        public void Dispose()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record )
            {
                var testEnv = TestEnvironmentFactory.GetTestEnvironment();
                var context = new MockContext();
                var resourcesClient = context.GetServiceClient<ResourceManagementClient>();
            }
        }
    }
}
