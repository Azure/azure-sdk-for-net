// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication.Properties;
using System;
using System.IO;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// Represents current Azure session.
    /// </summary>
    public static class AzureSession
    {
        static AzureSession()
        {
            ClientFactory = new ClientFactory();
            AuthenticationFactory = new AuthenticationFactory();
            DataStore = new DiskDataStore();
            CurrentContext = new AzureContext();
            CurrentContext.Environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            AzureSession.OldProfileFile = "WindowsAzureProfile.xml";
            AzureSession.OldProfileFileBackup = "WindowsAzureProfile.xml.bak";
            AzureSession.ProfileDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Resources.AzureDirectoryName); ;
            AzureSession.ProfileFile = "AzureProfile.json";
            AzureSession.TokenCacheFile = "TokenCache.dat";
        }

        /// <summary>
        /// Current session context.
        /// </summary>
        public static AzureContext CurrentContext { get; private set; }
        
        /// <summary>
        /// Sets current session context.
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="environment"></param>
        /// <param name="account"></param>
        public static void SetCurrentContext(AzureSubscription subscription, AzureEnvironment environment, AzureAccount account)
        {
            if (environment == null)
            {
                if (subscription != null && CurrentContext != null &&
                    subscription.Environment == CurrentContext.Environment.Name)
                {
                    environment = CurrentContext.Environment;
                }
                else
                {
                    environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
                }

                if (subscription != null)
                {
                    subscription.Environment = environment.Name;
                }
            }

            if (account == null)
            {
                if (subscription != null && CurrentContext != null && subscription.Account != null)
                {
                    if (CurrentContext.Account != null && subscription.Account == CurrentContext.Account.Id)
                    {
                        account = CurrentContext.Account;
                    }
                    else
                    {
                        throw new ArgumentException(Resources.AccountIdDoesntMatchSubscription, "account");
                    }

                    subscription.Account = account.Id;

                }
            }

            if (subscription != null && subscription.Environment != environment.Name)
            {
                throw new ArgumentException(Resources.EnvironmentNameDoesntMatchSubscription, "environment");
            }

            CurrentContext = new AzureContext
            {
                Subscription = subscription,
                Account = account,
                Environment = environment
            };
        }

        /// <summary>
        /// Gets or sets Azure client factory.
        /// </summary>
        public static IClientFactory ClientFactory { get; set; }

        /// <summary>
        /// Gets or sets Azure authentication factory.
        /// </summary>
        public static IAuthenticationFactory AuthenticationFactory { get; set; }

        /// <summary>
        /// Gets or sets data persistence store.
        /// </summary>
        public static IDataStore DataStore { get; set; }

        /// <summary>
        /// Gets or sets profile directory.
        /// </summary>
        public static string ProfileDirectory { get; set; }

        /// <summary>
        /// Gets or sets token cache file path.
        /// </summary>
        public static string TokenCacheFile { get; set; }

        /// <summary>
        /// Gets or sets profile file name.
        /// </summary>
        public static string ProfileFile { get; set; }

        /// <summary>
        /// Gets or sets file name for the migration backup.
        /// </summary>
        public static string OldProfileFileBackup { get; set; }

        /// <summary>
        /// Gets or sets old profile file name.
        /// </summary>
        public static string OldProfileFile { get; set; }
    }
}
