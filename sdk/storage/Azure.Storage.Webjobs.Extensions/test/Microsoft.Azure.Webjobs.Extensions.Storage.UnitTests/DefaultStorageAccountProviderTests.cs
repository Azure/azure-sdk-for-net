// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Executors
{
    public class DefaultStorageAccountProviderTests
    {
        [Fact(Skip = "Missing StorageAccountParser")]
        public void ConnectionStringProvider_NoDashboardConnectionString_Throws()
        {
            //var configuration = new ConfigurationBuilder()
            //    .AddInMemoryCollection(new Dictionary<string, string>
            //    {
            //            { "Dashboard", null }
            //    })
            //    .Build();

            //IStorageAccountProvider product = new DefaultStorageAccountProvider(new AmbientConnectionStringProvider(configuration), new StorageAccountParser(new StorageClientFactory()), new DefaultStorageCredentialsValidator())
            //{
            //    StorageConnectionString = new CloudStorageAccount(new StorageCredentials("Test", string.Empty, "key"), true).ToString(exportSecrets: true)
            //};

            //// Act & Assert
            //ExceptionAssert.ThrowsInvalidOperation(() =>
            //    product.GetDashboardAccountAsync(CancellationToken.None).GetAwaiter().GetResult(),
            //    "Microsoft Azure WebJobs SDK 'Dashboard' connection string is missing or empty. The Microsoft Azure Storage account connection string can be set in the following ways:" + Environment.NewLine +
            //    "1. Set the connection string named 'AzureWebJobsDashboard' in the connectionStrings section of the .config file in the following format " +
            //    "<add name=\"AzureWebJobsDashboard\" connectionString=\"DefaultEndpointsProtocol=http|https;AccountName=NAME;AccountKey=KEY\" />, or" + Environment.NewLine +
            //    "2. Set the environment variable named 'AzureWebJobsDashboard', or" + Environment.NewLine +
            //    "3. Set corresponding property of JobHostConfiguration.");
        }

        [Theory(Skip = "Missing StorageAccountParser")]
        [InlineData("Dashboard")]
        [InlineData("Storage")]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void GetAccountAsync_WhenReadFromConfig_ReturnsParsedAccount(string connectionStringName)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            //string connectionString = "valid-ignore";
            //IStorageAccount parsedAccount = Mock.Of<IStorageAccount>();

            //Mock<IConnectionStringProvider> connectionStringProviderMock = new Mock<IConnectionStringProvider>(MockBehavior.Strict);
            //connectionStringProviderMock.Setup(p => p.GetConnectionString(connectionStringName))
            //                            .Returns(connectionString)
            //                            .Verifiable();
            //IConnectionStringProvider connectionStringProvider = connectionStringProviderMock.Object;

            //Mock<IStorageAccountParser> parserMock = new Mock<IStorageAccountParser>(MockBehavior.Strict);
            //IServiceProvider services = CreateServices();
            //parserMock.Setup(p => p.ParseAccount(connectionString, connectionStringName))
            //          .Returns(parsedAccount)
            //          .Verifiable();
            //IStorageAccountParser parser = parserMock.Object;

            //Mock<IStorageCredentialsValidator> validatorMock = new Mock<IStorageCredentialsValidator>(
            //    MockBehavior.Strict);
            //validatorMock.Setup(v => v.ValidateCredentialsAsync(parsedAccount, It.IsAny<CancellationToken>()))
            //             .Returns(Task.FromResult(0))
            //             .Verifiable();
            //IStorageCredentialsValidator validator = validatorMock.Object;

            //IStorageAccountProvider provider = CreateProductUnderTest(services, connectionStringProvider, parser, validator);

            //IStorageAccount actualAccount = provider.TryGetAccountAsync(
            //    connectionStringName, CancellationToken.None).GetAwaiter().GetResult();

            //Assert.Same(parsedAccount, actualAccount);
            //connectionStringProviderMock.Verify();
            //parserMock.Verify();
            //validatorMock.Verify();
        }

        [Theory(Skip = "Missing StorageAccountParser")]
        [InlineData("Dashboard")]
        [InlineData("Storage")]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void GetAccountAsync_WhenInvalidConfig_PropagatesParserException(string connectionStringName)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            //string connectionString = "invalid-ignore";
            //Exception expectedException = new InvalidOperationException();
            //IConnectionStringProvider connectionStringProvider = CreateConnectionStringProvider(connectionStringName,
            //    connectionString);
            //Mock<IStorageAccountParser> parserMock = new Mock<IStorageAccountParser>(MockBehavior.Strict);
            //IServiceProvider services = CreateServices();
            //parserMock.Setup(p => p.ParseAccount(connectionString, connectionStringName))
            //    .Throws(expectedException);
            //IStorageAccountParser parser = parserMock.Object;

            //IStorageAccountProvider provider = CreateProductUnderTest(services, connectionStringProvider, parser);

            //Exception actualException = Assert.Throws<InvalidOperationException>(
            //    () => provider.TryGetAccountAsync(connectionStringName, CancellationToken.None).GetAwaiter().GetResult());

            //Assert.Same(expectedException, actualException);
        }

        [Theory(Skip = "Missing StorageAccountParser")]
        [InlineData("Dashboard")]
        [InlineData("Storage")]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void GetAccountAsync_WhenInvalidCredentials_PropagatesValidatorException(string connectionStringName)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            //string connectionString = "invalid-ignore";
            //IStorageAccount parsedAccount = Mock.Of<IStorageAccount>();
            //Exception expectedException = new InvalidOperationException();
            //IConnectionStringProvider connectionStringProvider = CreateConnectionStringProvider(connectionStringName, connectionString);
            //IServiceProvider services = CreateServices();
            //IStorageAccountParser parser = CreateParser(services, connectionStringName, connectionString, parsedAccount);
            //Mock<IStorageCredentialsValidator> validatorMock = new Mock<IStorageCredentialsValidator>(
            //    MockBehavior.Strict);
            //validatorMock.Setup(v => v.ValidateCredentialsAsync(parsedAccount, It.IsAny<CancellationToken>()))
            //    .Throws(expectedException);
            //IStorageCredentialsValidator validator = validatorMock.Object;
            //IStorageAccountProvider provider = CreateProductUnderTest(services, connectionStringProvider, parser, validator);

            //Exception actualException = Assert.Throws<InvalidOperationException>(
            //    () => provider.TryGetAccountAsync(connectionStringName, CancellationToken.None).GetAwaiter().GetResult());

            //Assert.Same(expectedException, actualException);
        }

        [Fact(Skip = "Missing StorageAccountParser")]
        public void GetAccountAsync_WhenDashboardOverridden_ReturnsParsedAccount()
        {
            //IConnectionStringProvider connectionStringProvider = CreateDummyConnectionStringProvider();
            //string connectionString = "valid-ignore";
            //IStorageAccount parsedAccount = Mock.Of<IStorageAccount>();
            //IServiceProvider services = CreateServices();
            //IStorageAccountParser parser = CreateParser(services, ConnectionStringNames.Dashboard, connectionString, parsedAccount);
            //IStorageCredentialsValidator validator = CreateValidator(parsedAccount);
            //DefaultStorageAccountProvider provider = CreateProductUnderTest(services, connectionStringProvider, parser, validator);
            //provider.DashboardConnectionString = connectionString;
            //IStorageAccount actualAccount = provider.TryGetAccountAsync(
            //    ConnectionStringNames.Dashboard, CancellationToken.None).GetAwaiter().GetResult();

            //Assert.Same(parsedAccount, actualAccount);
        }

        [Fact(Skip = "Missing StorageAccountParser")]
        public void GetAccountAsync_WhenStorageOverridden_ReturnsParsedAccount()
        {
            //IConnectionStringProvider connectionStringProvider = CreateDummyConnectionStringProvider();
            //string connectionString = "valid-ignore";
            //IStorageAccount parsedAccount = Mock.Of<IStorageAccount>();
            //IServiceProvider services = CreateServices();
            //IStorageAccountParser parser = CreateParser(services, ConnectionStringNames.Storage, connectionString, parsedAccount);
            //IStorageCredentialsValidator validator = CreateValidator(parsedAccount);
            //DefaultStorageAccountProvider provider = CreateProductUnderTest(services, connectionStringProvider, parser, validator);
            //provider.StorageConnectionString = connectionString;

            //IStorageAccount actualAccount = provider.TryGetAccountAsync(
            //    ConnectionStringNames.Storage, CancellationToken.None).GetAwaiter().GetResult();

            //Assert.Same(parsedAccount, actualAccount);
        }

        [Fact(Skip = "Missing StorageAccountParser")]
        public void GetAccountAsync_WhenDashboardOverriddenWithNull_ReturnsNull()
        {
            //DefaultStorageAccountProvider provider = CreateProductUnderTest();
            //provider.DashboardConnectionString = null;

            //IStorageAccount actualAccount = provider.TryGetAccountAsync(
            //    ConnectionStringNames.Dashboard, CancellationToken.None).GetAwaiter().GetResult();

            //Assert.Null(actualAccount);
        }

        [Fact(Skip = "Missing StorageAccountParser")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetAccountAsync_WhenStorageOverriddenWithNull_Succeeds()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //DefaultStorageAccountProvider provider = CreateProductUnderTest();
            //provider.StorageConnectionString = null;

            //var account = await provider.TryGetAccountAsync(ConnectionStringNames.Storage, CancellationToken.None);
            //Assert.Null(account);
        }

        [Fact(Skip = "Missing StorageAccountParser")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetAccountAsync_WhenNoStorage_Succeeds()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //DefaultStorageAccountProvider provider = CreateProductUnderTest();
            //provider.DashboardConnectionString = null;
            //provider.StorageConnectionString = null;

            //var dashboardAccount = await provider.TryGetAccountAsync(ConnectionStringNames.Dashboard, CancellationToken.None);
            //Assert.Null(dashboardAccount);

            //var storageAccount = await provider.TryGetAccountAsync(ConnectionStringNames.Storage, CancellationToken.None);
            //Assert.Null(storageAccount);
        }

        [Fact(Skip = "Missing StorageAccountParser")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetAccountAsync_WhenWebJobsStorageAccountNotGeneral_Throws()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //string connectionString = "valid-ignore";
            //var connStringMock = new Mock<IConnectionStringProvider>();
            //connStringMock.Setup(c => c.GetConnectionString(ConnectionStringNames.Storage)).Returns(connectionString);
            //var connectionStringProvider = connStringMock.Object;
            //var accountMock = new Mock<IStorageAccount>();
            //accountMock.SetupGet(s => s.Type).Returns(StorageAccountType.BlobOnly);
            //accountMock.SetupGet(s => s.Credentials).Returns(new StorageCredentials("name", string.Empty));
            //var parsedAccount = accountMock.Object;
            //IServiceProvider services = CreateServices();
            //IStorageAccountParser parser = CreateParser(services, ConnectionStringNames.Storage, connectionString, parsedAccount);
            //IStorageCredentialsValidator validator = CreateValidator(parsedAccount);
            //DefaultStorageAccountProvider provider = CreateProductUnderTest(services, connectionStringProvider, parser, validator);
            //var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => provider.GetStorageAccountAsync(CancellationToken.None));

            //Assert.Equal("Storage account 'name' is of unsupported type 'Blob-Only/ZRS'. Supported types are 'General Purpose'", exception.Message);
        }

        [Fact(Skip = "Missing StorageAccountParser")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetAccountAsync_WhenWebJobsDashboardAccountNotGeneral_Throws()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //    string connectionString = "valid-ignore";
            //    var connStringMock = new Mock<IConnectionStringProvider>();
            //    connStringMock.Setup(c => c.GetConnectionString(ConnectionStringNames.Dashboard)).Returns(connectionString);
            //    var connectionStringProvider = connStringMock.Object;
            //    var accountMock = new Mock<IStorageAccount>();
            //    accountMock.SetupGet(s => s.Type).Returns(StorageAccountType.Premium);
            //    accountMock.SetupGet(s => s.Credentials).Returns(new StorageCredentials("name", string.Empty));
            //    var parsedAccount = accountMock.Object;
            //    IServiceProvider services = CreateServices();
            //    IStorageAccountParser parser = CreateParser(services, ConnectionStringNames.Dashboard, connectionString, parsedAccount);
            //    IStorageCredentialsValidator validator = CreateValidator(parsedAccount);
            //    DefaultStorageAccountProvider provider = CreateProductUnderTest(services, connectionStringProvider, parser, validator);
            //    var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => provider.GetDashboardAccountAsync(CancellationToken.None));

            //    Assert.Equal("Storage account 'name' is of unsupported type 'Premium'. Supported types are 'General Purpose'", exception.Message);
        }

        [Fact(Skip = "Missing StorageAccountParser")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetStorageAccountAsyncTest()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //string cxEmpty = "";
            //var accountDefault = new Mock<IStorageAccount>().Object;

            //string cxReal = "MyAccount";
            //var accountReal = new Mock<IStorageAccount>().Object;

            //var provider = new Mock<IStorageAccountProvider>();
            //provider.Setup(c => c.TryGetAccountAsync(ConnectionStringNames.Storage, CancellationToken.None)).Returns(Task.FromResult<IStorageAccount>(accountDefault));
            //provider.Setup(c => c.TryGetAccountAsync(cxReal, CancellationToken.None)).Returns(Task.FromResult<IStorageAccount>(accountReal));

            //var account = await StorageAccountProviderExtensions.GetStorageAccountAsync(provider.Object, cxEmpty, CancellationToken.None);
            //Assert.Equal(accountDefault, account);

            //account = await StorageAccountProviderExtensions.GetStorageAccountAsync(provider.Object, cxReal, CancellationToken.None);
            //Assert.Equal(accountReal, account);
        }

        [Fact(Skip = "Missing StorageAccountParser")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GetAccountAsync_CachesAccounts()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //var services = CreateServices();
            //var accountMock = new Mock<IStorageAccount>();
            //var storageMock = new Mock<IStorageAccount>();

            //var csProvider = CreateConnectionStringProvider("account", "cs");
            //var parser = CreateParser(services, "account", "cs", accountMock.Object);

            //// strick mock tests that validate does not occur twice
            //Mock<IStorageCredentialsValidator> validatorMock = new Mock<IStorageCredentialsValidator>(MockBehavior.Strict);
            //validatorMock.Setup(v => v.ValidateCredentialsAsync(accountMock.Object, It.IsAny<CancellationToken>()))
            //    .Returns(Task.CompletedTask);
            //validatorMock.Setup(v => v.ValidateCredentialsAsync(storageMock.Object, It.IsAny<CancellationToken>()))
            //    .Returns(Task.CompletedTask);

            //DefaultStorageAccountProvider provider = CreateProductUnderTest(services, csProvider, parser, validatorMock.Object);
            //var account = await provider.TryGetAccountAsync("account", CancellationToken.None);
            //var account2 = await provider.TryGetAccountAsync("account", CancellationToken.None);

            //Assert.Equal(account, account2);
            //validatorMock.Verify(v => v.ValidateCredentialsAsync(accountMock.Object, It.IsAny<CancellationToken>()), Times.Once());
        }

        //private static IConnectionStringProvider CreateConnectionStringProvider(string connectionStringName,
        //    string connectionString)
        //{
        //    Mock<IConnectionStringProvider> mock = new Mock<IConnectionStringProvider>(MockBehavior.Strict);
        //    mock.Setup(p => p.GetConnectionString(connectionStringName))
        //        .Returns(connectionString);
        //    return mock.Object;
        //}

        //private static IConnectionStringProvider CreateDummyConnectionStringProvider()
        //{
        //    return new Mock<IConnectionStringProvider>(MockBehavior.Strict).Object;
        //}

        //private static IStorageAccountParser CreateDummyParser()
        //{
        //    return new Mock<IStorageAccountParser>(MockBehavior.Strict).Object;
        //}

        //private static IStorageCredentialsValidator CreateDummyValidator()
        //{
        //    return new Mock<IStorageCredentialsValidator>(MockBehavior.Strict).Object;
        //}

        //private static IServiceProvider CreateServices()
        //{
        //    Mock<IServiceProvider> servicesMock = new Mock<IServiceProvider>(MockBehavior.Strict);
        //    StorageClientFactory clientFactory = new StorageClientFactory();
        //    servicesMock.Setup(p => p.GetService(typeof(StorageClientFactory))).Returns(clientFactory);

        //    return servicesMock.Object;
        //}

        //private static IStorageAccountParser CreateParser(IServiceProvider services, string connectionStringName, string connectionString, IStorageAccount parsedAccount)
        //{
        //    Mock<IStorageAccountParser> mock = new Mock<IStorageAccountParser>(MockBehavior.Strict);
        //    mock.Setup(p => p.ParseAccount(connectionString, connectionStringName)).Returns(parsedAccount);
        //    return mock.Object;
        //}

        //private static DefaultStorageAccountProvider CreateProductUnderTest()
        //{
        //    return CreateProductUnderTest(CreateServices(), CreateDummyConnectionStringProvider(), CreateDummyParser());
        //}

        //private static DefaultStorageAccountProvider CreateProductUnderTest(IServiceProvider services,
        //    IConnectionStringProvider ambientConnectionStringProvider, IStorageAccountParser storageAccountParser)
        //{
        //    return CreateProductUnderTest(services, ambientConnectionStringProvider, storageAccountParser, CreateDummyValidator());
        //}

        //private static DefaultStorageAccountProvider CreateProductUnderTest(IServiceProvider services,
        //    IConnectionStringProvider ambientConnectionStringProvider, IStorageAccountParser storageAccountParser,
        //    IStorageCredentialsValidator storageCredentialsValidator)
        //{
        //    return new DefaultStorageAccountProvider(ambientConnectionStringProvider, storageAccountParser, storageCredentialsValidator);
        //}

        //private static IStorageCredentialsValidator CreateValidator(IStorageAccount account)
        //{
        //    Mock<IStorageCredentialsValidator> mock = new Mock<IStorageCredentialsValidator>(MockBehavior.Strict);
        //    mock.Setup(v => v.ValidateCredentialsAsync(account, It.IsAny<CancellationToken>()))
        //        .Returns(Task.FromResult(0));
        //    return mock.Object;
        //}

        //[StorageAccount("class")]
        //private class AccountOverrides
        //{
        //    [StorageAccount("method")]
        //    private void ParamOverride([StorageAccount("param")] string s)
        //    {
        //    }

        //    [StorageAccount("method")]
        //    private void MethodOverride(string s)
        //    {
        //    }

        //    private void ClassOverride(string s)
        //    {
        //    }
        //}
    }
}
