namespace Microsoft.Azure.Management.HDInsight.Models
{
    /// <summary>
    /// Sql Server Database that allows clusters to persist component metadata through deployments.
    /// </summary>
    public class Metastore
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