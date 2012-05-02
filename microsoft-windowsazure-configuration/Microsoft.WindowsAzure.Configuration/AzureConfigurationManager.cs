using System;

namespace Microsoft.WindowsAzure.Configuration
{
    /// <summary>
    /// Configuration manager for accessing Windows Azure settings.
    /// </summary>
    public static class AzureConfigurationManager
    {
        private static object _lock = new object();
        private static AzureApplicationSettings _appSettings;

        /// <summary>
        /// Gets application settings.
        /// </summary>
        public static AzureApplicationSettings AppSettings
        {
            get
            {
                if (_appSettings == null)
                {
                    lock (_lock)
                    {
                        if (_appSettings == null)
                        {
                            _appSettings = new AzureApplicationSettings();
                        }
                    }
                }

                return _appSettings;
            }
        }
    }
}
