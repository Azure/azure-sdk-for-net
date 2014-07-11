using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Management.Sql
{
    public partial class SqlManagementClient
    {
        public override SqlManagementClient WithHandler(System.Net.Http.DelegatingHandler handler)
        {
			return (SqlManagementClient)WithHandler(new SqlManagementClient(), handler);
        }
    }
}
