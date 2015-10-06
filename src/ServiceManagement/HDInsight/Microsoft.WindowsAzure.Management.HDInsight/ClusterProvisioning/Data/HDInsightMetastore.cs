// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    /// <summary>
    /// Sql Server Database that allows clusters to persist component metadata through deployments.
    /// </summary>
    public sealed class Metastore
    {
        /// <summary>
        /// Gets the server.
        /// </summary>
        public string Server { get; private set; }

        /// <summary>
        /// Gets the database Name.
        /// </summary>
        public string Database { get; private set; }

        /// <summary>
        /// Gets the user name.
        /// </summary>
        public string User { get; private set; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Metastore class.
        /// </summary>
        /// <param name="server">DB Server.</param>
        /// <param name="database">Exclusive database name that exists in the DB Server.</param>
        /// <param name="user">Valid username for the DB Server.</param>
        /// <param name="password">Valid password for the DB Server.</param>
        public Metastore(string server, string database, string user, string password)
        {
            this.Server = server;
            this.Database = database;
            this.User = user;
            this.Password = password;
        }
    }
}
