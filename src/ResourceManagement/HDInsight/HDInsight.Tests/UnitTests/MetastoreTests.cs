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
            Assert.Equal(config.Count, 1);
            var hiveConfig = config["hive-site"];
            Assert.Equal(hiveConfig.Count, 4);
            Assert.Equal(hiveConfig["javax.jdo.option.ConnectionURL"],
                "jdbc:sqlserver://server1.database.windows.net;database=hivedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0");
            Assert.Equal(hiveConfig["javax.jdo.option.ConnectionUserName"], "user1");
            Assert.Equal(hiveConfig["javax.jdo.option.ConnectionPassword"], "dummy");
            Assert.Equal(hiveConfig["javax.jdo.option.ConnectionDriverName"],
                "com.microsoft.sqlserver.jdbc.SQLServerDriver");

            //Oozie metastore
            var oozieMetastore = new Metastore("server2", "ooziedb", "user2", "dummy2");
            config = ClusterOperations.GetMetastoreConfig(oozieMetastore, OSType.Windows, "oozie");
            Assert.Equal(config.Count, 1);
            var oozieConfig = config["oozie-site"];
            Assert.Equal(oozieConfig.Count, 4);
            Assert.Equal(oozieConfig["oozie.service.JPAService.jdbc.url"],
                "jdbc:sqlserver://server2.database.windows.net;database=ooziedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0");
            Assert.Equal(oozieConfig["oozie.service.JPAService.jdbc.username"], "user2");
            Assert.Equal(oozieConfig["oozie.service.JPAService.jdbc.password"], "dummy2");
            Assert.Equal(oozieConfig["oozie.service.JPAService.jdbc.driver"], "com.microsoft.sqlserver.jdbc.SQLServerDriver");
        }

        [Fact]
        public void TestMetastoreServer()
        {
            var hiveMetastore = new Metastore("server1.database.windows.net", "hivedb", "user1", "dummy");
            var config = ClusterOperations.GetMetastoreConfig(hiveMetastore, OSType.Windows, "hive");
            Assert.Equal(config.Count, 1);
            var hiveConfig = config["hive-site"];
            Assert.Equal(hiveConfig.Count, 4);
            Assert.Equal(hiveConfig["javax.jdo.option.ConnectionURL"],
                "jdbc:sqlserver://server1.database.windows.net;database=hivedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0");
            Assert.Equal(hiveConfig["javax.jdo.option.ConnectionUserName"], "user1");
            Assert.Equal(hiveConfig["javax.jdo.option.ConnectionPassword"], "dummy");
            Assert.Equal(hiveConfig["javax.jdo.option.ConnectionDriverName"],
                "com.microsoft.sqlserver.jdbc.SQLServerDriver");

            var oozieMetastore = new Metastore("server2.random.words.database.windows.net", "ooziedb", "user2", "dummy2");
            config = ClusterOperations.GetMetastoreConfig(oozieMetastore, OSType.Windows, "oozie");
            Assert.Equal(config.Count, 1);
            var oozieConfig = config["oozie-site"];
            Assert.Equal(oozieConfig.Count, 4);
            Assert.Equal(oozieConfig["oozie.service.JPAService.jdbc.url"],
                "jdbc:sqlserver://server2.random.words.database.windows.net;database=ooziedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0");
            Assert.Equal(oozieConfig["oozie.service.JPAService.jdbc.username"], "user2");
            Assert.Equal(oozieConfig["oozie.service.JPAService.jdbc.password"], "dummy2");
            Assert.Equal(oozieConfig["oozie.service.JPAService.jdbc.driver"], "com.microsoft.sqlserver.jdbc.SQLServerDriver");
        }

        [Fact]
        public void TestMetastoreConfigsForIaaS()
        {
            //Hive metastore
            var hiveMetastore = new Metastore("server1", "hivedb", "user1", "dummy");
            var config = ClusterOperations.GetMetastoreConfig(hiveMetastore, OSType.Linux, "hive");
            Assert.Equal(config.Count, 2);
            var hiveSite = config["hive-site"];
            Assert.Equal(hiveSite.Count, 4);
            Assert.Equal(hiveSite["javax.jdo.option.ConnectionURL"],
                "jdbc:sqlserver://server1.database.windows.net;database=hivedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0");
            Assert.Equal(hiveSite["javax.jdo.option.ConnectionUserName"], "user1");
            Assert.Equal(hiveSite["javax.jdo.option.ConnectionPassword"], "dummy");
            Assert.Equal(hiveSite["javax.jdo.option.ConnectionDriverName"],
                "com.microsoft.sqlserver.jdbc.SQLServerDriver");
            var hiveEnv = config["hive-env"];
            Assert.Equal(hiveEnv.Count, 6);
            Assert.Equal(hiveEnv["hive_database"], "Existing MSSQL Server database with SQL authentication");
            Assert.Equal(hiveEnv["hive_database_name"], "hivedb");
            Assert.Equal(hiveEnv["hive_database_type"], "mssql");
            Assert.Equal(hiveEnv["hive_existing_mssql_server_database"], "hivedb");
            Assert.Equal(hiveEnv["hive_existing_mssql_server_host"], "server1.database.windows.net");
            Assert.Equal(hiveEnv["hive_hostname"], "server1.database.windows.net");

            //Oozie metastore
            var oozieMetastore = new Metastore("server2", "ooziedb", "user2", "dummy2");
            config = ClusterOperations.GetMetastoreConfig(oozieMetastore, OSType.Linux, "oozie");
            Assert.Equal(config.Count, 2);
            var oozieSite = config["oozie-site"];
            Assert.Equal(oozieSite.Count, 5);
            Assert.Equal(oozieSite["oozie.service.JPAService.jdbc.url"],
                "jdbc:sqlserver://server2.database.windows.net;database=ooziedb;encrypt=true;trustServerCertificate=true;create=false;loginTimeout=300;sendStringParametersAsUnicode=true;prepareSQL=0");
            Assert.Equal(oozieSite["oozie.service.JPAService.jdbc.username"], "user2");
            Assert.Equal(oozieSite["oozie.service.JPAService.jdbc.password"], "dummy2");
            Assert.Equal(oozieSite["oozie.service.JPAService.jdbc.driver"], "com.microsoft.sqlserver.jdbc.SQLServerDriver");
            Assert.Equal(oozieSite["oozie.db.schema.name"], "oozie");
            var oozieEnv = config["oozie-env"];
            Assert.Equal(oozieEnv.Count, 6);
            Assert.Equal(oozieEnv["oozie_database"], "Existing MSSQL Server database with SQL authentication");
            Assert.Equal(oozieEnv["oozie_database_name"], "ooziedb");
            Assert.Equal(oozieEnv["oozie_database_type"], "mssql");
            Assert.Equal(oozieEnv["oozie_existing_mssql_server_database"], "ooziedb");
            Assert.Equal(oozieEnv["oozie_existing_mssql_server_host"], "server2.database.windows.net");
            Assert.Equal(oozieEnv["oozie_hostname"], "server2.database.windows.net");
        }
    }
}
