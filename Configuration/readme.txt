C# usage example:

using Microsoft.WindowsAzure;  // CloudConfigurationManager is defined here.

...

string connectionString = CloudConfigurationManager.GetSetting("ConnectionString");