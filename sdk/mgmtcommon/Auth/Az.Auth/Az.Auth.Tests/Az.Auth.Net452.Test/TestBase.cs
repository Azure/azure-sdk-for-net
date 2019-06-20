// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Az.Auth.Net452.Test
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;


    public class AuthNet452TestBase
    {
        private bool IsLiteralDirty = false;
        private string _literalCnnString;
        private ConnectionString _cs;
        private TestEndpoints _cloudEndPoints;
        string _testOutputDir;

        public string TestOutputDir
        {
            get
            {
                if(string.IsNullOrEmpty(_testOutputDir))
                {
                    string codeBasePath = Assembly.GetExecutingAssembly().CodeBase;
                    var uri = new UriBuilder(codeBasePath);
                    string path = Uri.UnescapeDataString(uri.Path);
                    _testOutputDir = Path.GetDirectoryName(path);
                }

                return _testOutputDir;
            }
        }

        public string TestOutputAssemblyLocation { get; set; }

        public string LiteralCnnString
        {
            get
            {
                return _literalCnnString;
            }
            set
            {
                _literalCnnString = value;
                IsLiteralDirty = true;
            }
        }

        public ConnectionString CS
        {
            get
            {
                if(IsLiteralDirty || (_cs == null))
                {
                    if (string.IsNullOrEmpty(LiteralCnnString))
                    {
                        _cs = new ConnectionString();
                    }
                    else
                    {
                        if (IsLiteralDirty)
                            _cs = new ConnectionString(LiteralCnnString);
                    }
                }

                return _cs;
            }

            set
            {
                _cs = value;
            }
        }

        public string UserName
        {
            get
            {
                return CS.KeyValuePairs[ConnectionStringKeys.UserIdKey];
            }
        }

        public string TenantId { get { return CS.KeyValuePairs[ConnectionStringKeys.AADTenantKey]; } }

        public string ClientId { get { return CS.KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey]; } }

        public string Password { get { return CS.KeyValuePairs[ConnectionStringKeys.PasswordKey]; } }

        public TestEndpoints CloudEndPoints
        {
            get
            {
                if (_cloudEndPoints == null)
                {
                    _cloudEndPoints = new TestEndpoints(EnvironmentNames.Prod);
                }

                return _cloudEndPoints;
            }
        }


        public AuthNet452TestBase(string connectionString)
        {
            LiteralCnnString = connectionString;
            TestOutputAssemblyLocation = Assembly.GetExecutingAssembly().CodeBase;
            //TestOutputDir = Path.GetDirectoryName(TestOutputAssemblyLocation);
        }

        public AuthNet452TestBase() : this(connectionString: string.Empty) { }
    }
}
