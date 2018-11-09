// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if net472
using System.Data.SqlClient;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Shim class that allows setting custom parameter values for unit testing. 
    /// </summary>
    public class SqlAppAuthenticationParameters
    {
        public SqlAppAuthenticationParameters(SqlAuthenticationParameters parameters)
        {
            Authority = parameters.Authority;
            Resource = parameters.Resource;
        }

        public SqlAppAuthenticationParameters(string authority, string resource)
        {
            Authority = authority;
            Resource = resource;
        }
        
        public string Authority { get; }
        public string Resource { get; }
    }
}
#endif
