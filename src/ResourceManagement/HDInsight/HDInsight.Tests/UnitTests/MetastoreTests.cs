using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Xunit;

namespace HDInsight.Tests.UnitTests
{
    public class MetastoreTests
    {
        [Fact]
        public void TestMetastoreConfigsForPaaS()
        {
            //Hive metastore
            var hiveMetastore = new Metastore("server1", "hivedb", "user1", "dummy");
            var config = ClusterOperations.GetMetastoreConfig(hiveMetastore, OSType.Windows, "hive");
            Assert.Single(config);
            var hiveConfig = config["hive-site"];
            Assert.Equal(4, hiveConfig.Count);
            Assert.Equal("jdbc:sqlserver://server1.database.windows.net;database=hivedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0", 
                hiveConfig["javax.jdo.option.ConnectionURL"]);
            Assert.Equal("user1", hiveConfig["javax.jdo.option.ConnectionUserName"]);
            Assert.Equal("dummy", hiveConfig["javax.jdo.option.ConnectionPassword"]);
            Assert.Equal("com.microsoft.sqlserver.jdbc.SQLServerDriver", hiveConfig["javax.jdo.option.ConnectionDriverName"]);

            //Oozie metastore
            var oozieMetastore = new Metastore("server2", "ooziedb", "user2", "dummy2");
            config = ClusterOperations.GetMetastoreConfig(oozieMetastore, OSType.Windows, "oozie");
            Assert.Single(config);
            var oozieConfig = config["oozie-site"];
            Assert.Equal(4, oozieConfig.Count);
            Assert.Equal("jdbc:sqlserver://server2.database.windows.net;database=ooziedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0", 
                oozieConfig["oozie.service.JPAService.jdbc.url"]);
            Assert.Equal("user2", oozieConfig["oozie.service.JPAService.jdbc.username"]);
            Assert.Equal("dummy2", oozieConfig["oozie.service.JPAService.jdbc.password"]);
            Assert.Equal("com.microsoft.sqlserver.jdbc.SQLServerDriver", oozieConfig["oozie.service.JPAService.jdbc.driver"]);
        }

        [Fact]
        public void TestMetastoreServer()
        {
            var hiveMetastore = new Metastore("server1.database.windows.net", "hivedb", "user1", "dummy");
            var config = ClusterOperations.GetMetastoreConfig(hiveMetastore, OSType.Windows, "hive");
            Assert.Single(config);
            var hiveConfig = config["hive-site"];
            Assert.Equal(4, hiveConfig.Count);
            Assert.Equal("jdbc:sqlserver://server1.database.windows.net;database=hivedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0",
                hiveConfig["javax.jdo.option.ConnectionURL"]);
            Assert.Equal("user1", hiveConfig["javax.jdo.option.ConnectionUserName"]);
            Assert.Equal("dummy", hiveConfig["javax.jdo.option.ConnectionPassword"]);
            Assert.Equal("com.microsoft.sqlserver.jdbc.SQLServerDriver", 
                hiveConfig["javax.jdo.option.ConnectionDriverName"]);

            var oozieMetastore = new Metastore("server2.random.words.database.windows.net", "ooziedb", "user2", "dummy2");
            config = ClusterOperations.GetMetastoreConfig(oozieMetastore, OSType.Windows, "oozie");
            Assert.Single(config);
            var oozieConfig = config["oozie-site"];
            Assert.Equal(4, oozieConfig.Count);
            Assert.Equal("jdbc:sqlserver://server2.random.words.database.windows.net;database=ooziedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0",
                oozieConfig["oozie.service.JPAService.jdbc.url"]);
            Assert.Equal("user2", oozieConfig["oozie.service.JPAService.jdbc.username"]);
            Assert.Equal("dummy2", oozieConfig["oozie.service.JPAService.jdbc.password"]);
            Assert.Equal("com.microsoft.sqlserver.jdbc.SQLServerDriver", oozieConfig["oozie.service.JPAService.jdbc.driver"]);
        }

        [Fact]
        public void TestMetastoreConfigsForIaaS()
        {
            //Hive metastore
            var hiveMetastore = new Metastore("server1", "hivedb", "user1", "dummy");
            var config = ClusterOperations.GetMetastoreConfig(hiveMetastore, OSType.Linux, "hive");
            Assert.Equal(2, config.Count);
            var hiveSite = config["hive-site"];
            Assert.Equal(4, hiveSite.Count);
            Assert.Equal("jdbc:sqlserver://server1.database.windows.net;database=hivedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0", 
                hiveSite["javax.jdo.option.ConnectionURL"]);
            Assert.Equal("user1", hiveSite["javax.jdo.option.ConnectionUserName"]);
            Assert.Equal("dummy", hiveSite["javax.jdo.option.ConnectionPassword"]);
            Assert.Equal("com.microsoft.sqlserver.jdbc.SQLServerDriver", hiveSite["javax.jdo.option.ConnectionDriverName"]);
            var hiveEnv = config["hive-env"];
            Assert.Equal(6, hiveEnv.Count);
            Assert.Equal("Existing MSSQL Server database with SQL authentication", hiveEnv["hive_database"]);
            Assert.Equal("hivedb", hiveEnv["hive_database_name"]);
            Assert.Equal("mssql", hiveEnv["hive_database_type"]);
            Assert.Equal("hivedb", hiveEnv["hive_existing_mssql_server_database"]);
            Assert.Equal("server1.database.windows.net", hiveEnv["hive_existing_mssql_server_host"]);
            Assert.Equal("server1.database.windows.net", hiveEnv["hive_hostname"]);

            //Oozie metastore
            var oozieMetastore = new Metastore("server2", "ooziedb", "user2", "dummy2");
            config = ClusterOperations.GetMetastoreConfig(oozieMetastore, OSType.Linux, "oozie");
            Assert.Equal(2, config.Count);
            var oozieSite = config["oozie-site"];
            Assert.Equal(5, oozieSite.Count);
            Assert.Equal("jdbc:sqlserver://server2.database.windows.net;database=ooziedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0", 
                oozieSite["oozie.service.JPAService.jdbc.url"]);
            Assert.Equal("user2", oozieSite["oozie.service.JPAService.jdbc.username"]);
            Assert.Equal("dummy2", oozieSite["oozie.service.JPAService.jdbc.password"]);
            Assert.Equal("com.microsoft.sqlserver.jdbc.SQLServerDriver", oozieSite["oozie.service.JPAService.jdbc.driver"]);
            Assert.Equal("oozie", oozieSite["oozie.db.schema.name"]);
            var oozieEnv = config["oozie-env"];
            Assert.Equal(6, oozieEnv.Count);
            Assert.Equal("Existing MSSQL Server database with SQL authentication", oozieEnv["oozie_database"]);
            Assert.Equal("ooziedb", oozieEnv["oozie_database_name"]);
            Assert.Equal("mssql", oozieEnv["oozie_database_type"]);
            Assert.Equal("ooziedb", oozieEnv["oozie_existing_mssql_server_database"]);
            Assert.Equal("server2.database.windows.net", oozieEnv["oozie_existing_mssql_server_host"]);
            Assert.Equal("server2.database.windows.net", oozieEnv["oozie_hostname"]);
        }
    }
}
