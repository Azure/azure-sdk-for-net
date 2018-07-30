// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Az.Auth.Net452.Test
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class AuthFullDesktopTestBase
    {
        private bool IsLiteralDirty = false;
        private string _literalCnnString;
        private ConnectionString _cs;
        private TestEndpoints _cloudEndPoints;

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


        public AuthFullDesktopTestBase(string connectionString)
        {
            LiteralCnnString = connectionString;
        }

        public AuthFullDesktopTestBase() { LiteralCnnString = string.Empty; }
    }
}
