// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Services.AppAuthentication.TestCommon
{
    public class Constants
    {
        // Resource identifiers for Azure services
        public const string KeyVaultResourceId = "https://vault.azure.net/";
        public const string GraphResourceId = "https://graph.windows.net/";
        public const string ArmResourceId = "https://management.azure.com/";
        public const string SqlAzureResourceId = "https://database.windows.net/";
        public const string DataLakeResourceId = "https://datalake.azure.net/";

        // Azure AD related constants
        public static readonly string TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        public static readonly string TestAppId = "f0b1f84a-ec74-4cef-8034-adbad168ce33";
        public static readonly string AzureAdInstance = "https://login.microsoftonline.com/";

        // Error messages
        public static readonly string AdalException = "Adal Exception";
        public static readonly string CertificateNotFoundError = "Specified certificate was not found. ";
        public static readonly string IncorrectSecretError = "Secret not correct";
        public static readonly string MsiFailureError = "MSI failed to get token";
        public static readonly string IncorrectFormatError = "Incorrect format";
        public static readonly string NotInExpectedFormatError = "not in expected format";
        public static readonly string NotInProperFormatError = "not in a proper format. Expected format is Key1=Value1;Key2=Value=2;";
        public static readonly string NoMethodWorkedToGetTokenError = "methods to get an access token, but none of them worked";
        public static readonly string ProgramNotFoundError = "No such file";
        public static readonly string FailedToGetTokenError = "Access token could not be acquired";
        public static readonly string MustUseHttpsError = "must use https";
        public static readonly string CannotBeNullError = "Value cannot be null";
        public static readonly string NoConnectionString = "[No connection string specified]";
        public static readonly string ConnectionStringEmpty = "Connection string is empty.";
        public static readonly string InvalidCertLocationError = "is not valid. Valid values are CurrentUser and LocalMachine.";
        public static readonly string ConnectionStringNotHaveAtLeastOneRequiredKey = "is not valid. Must contain at least one of";
        public static readonly string KeyRepeatedInConnectionString = "is repeated";
        public static readonly string InvalidConnectionString = "is not valid";
        public static readonly string Redacted = "<<Redacted>>";
        public static readonly string InvalidResource = "invalid_resource";
        public static readonly string TokenFormatExceptionMessage = "Access token is not in the expected format.";
        public static readonly string TokenResponseFormatExceptionMessage = "Token response is not in the expected format.";
        public static readonly string DeveloperToolError = "You are not logged in.";
        public static readonly string JsonParseErrorException = "There was an error deserializing the object of type";
        public static readonly string TokenNotInExpectedFormatError = "Index was outside the bounds of the array";

        // Connection strings
        public static readonly string ClientSecret = "Secret";
        public static readonly string IntegratedAuthConnectionString = "RunAs = CurrentUser;";
        public static readonly string AzureCliConnectionString = "RunAs=Developer; DeveloperTool=AzureCli";
        public static readonly string VisualStudioConnectionString = "RunAs=Developer; DeveloperTool=VisualStudio";
        public static readonly string InvalidDeveloperToolConnectionString = "RunAs=Developer; DeveloperTool=InvalidCLI";
        public static readonly string InvalidRunAsConnectionString = "RunAs=Invalid; DeveloperTool=AzureCLI";
        public static readonly string IncorrectFormatConnectionString = "RunAs:Invalid; DeveloperTool:AzureCLI";
        public static readonly string AzureCliConnectionStringWithSpaces = "RunAs = Developer; DeveloperTool =AzureCLI";
        public static readonly string AzureCliConnectionStringEndingWithSemiColonAndSpace = "RunAs=Developer; DeveloperTool=AzureCLI; ";
        public static readonly string AzureCliConnectionStringWithEmptyDeveloperTool = "RunAs=Developer; DeveloperTool=";
        public static readonly string AzureCliConnectionStringRepeatedRunAs = "RunAs=Developer; DeveloperTool=AzureCli; RunAs=Developer";
        public static readonly string AzureCliConnectionStringNoRunAs = "DeveloperTool=AzureCLI";
        public static readonly string ActiveDirectoryIntegratedConnectionString = "RunAs=CurrentUser;";
        public static readonly string ManagedServiceIdentityConnectionString = "RunAs=App;";
        public static readonly string CertificateConnStringThumbprintLocalMachine = $"RunAs=App;AppId={TestAppId};TenantId={TenantId};CertificateThumbprint=123;CertificateStoreLocation=LocalMachine";
        public static readonly string CertificateConnStringThumbprintInvalidLocation = $"RunAs=App;AppId={TestAppId};TenantId={TenantId};CertificateThumbprint=123;CertificateStoreLocation=InvalidLocation";
        public static readonly string AppConnStringNoLocationOrAppKey = $"RunAs=App;AppId={TestAppId};TenantId={TenantId};CertificateThumbprint=123;";
        public static readonly string CertificateConnStringThumbprintCurrentUser = $"RunAs=App;AppId={TestAppId};TenantId={TenantId};CertificateThumbprint=123;CertificateStoreLocation=CurrentUser";
        public static readonly string CertificateConnStringSubjectNameCurrentUser = $"RunAs=App;AppId={TestAppId};TenantId={TenantId};CertificateSubjectName=123;CertificateStoreLocation=CurrentUser";
        public static readonly string ClientSecretConnString = $"RunAs=App;AppId={TestAppId};TenantId={TenantId};AppKey={ClientSecret}";
        public static readonly string ConnectionStringEnvironmentVariableName = "AzureServicesAuthConnectionString";
        public static readonly string CurrentUserStore = "CurrentUser";
        public static readonly string InvalidString = "Invalid";

        // Http related constants
        public static readonly string JsonContentType = "application/json";

        // Principal related constants
        public static readonly string UserType = "User";
        public static readonly string AppType = "App";

        // MSI related constants
        public static readonly string MsiAppServiceEndpointEnv = "MSI_ENDPOINT";
        public static readonly string MsiAppServiceSecretEnv = "MSI_SECRET";
        public static readonly string MsiEndpoint = "http://localhost:3748/oauth2/token";

        // Unit test certificate
        //[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Certificate is used for tests only")] 
        public static readonly string TestCert = "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";

        // End to end test cert url environment variable. 
        // The AppAuthenticationTestCertUrl environment variable should point to a cert in key vault. 
        public static readonly string TestCertUrlEnv = "AppAuthenticationTestCertUrl";

        // Visual Studio related constants
        public static readonly string TokenProviderPath = "C:\\Users\\johndoe\\AppData\\Local\\Microsoft\\VisualStudio\\15.0_5b4bdc86\\Extensions\\lyzwtlta.zzj\\TokenService\\Microsoft.Asal.TokenService.exe";
        public static readonly string ServiceConfigFileArgument = "C:\\Program Files (x86)\\Microsoft Visual Studio\\Preview\\Enterprise\\Common7\\servicehub.config.json";
        public static readonly string ServiceConfigFileArgumentName = "--serviceConfigFile";
        public static readonly string LocalAppDataEnv = "LOCALAPPDATA";
        public static readonly string TokenProviderFileNotFound = "Visual Studio Token provider file not found at ";
        public static readonly string TokenProviderExceptionMessage = "Exception for Visual Studio token provider";
        public static readonly string PreferenceNotFound= "'Preference' was not found";
        public static readonly string TokenProviderFileFormatExceptionMessage = "VisualStudio Token Provider File is not in the expected format.";

        // Test files path
        public static readonly string TestFilesPath = "TestFiles";
    }
}
