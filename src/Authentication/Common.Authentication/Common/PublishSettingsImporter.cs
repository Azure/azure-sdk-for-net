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

using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication.XmlSchema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// Class that handles loading publishsettings files
    /// and turning them into AzureSubscription objects.
    /// </summary>
    public static class PublishSettingsImporter
    {
        public static IEnumerable<AzureSubscription> ImportAzureSubscription(Stream stream, ProfileClient azureProfileClient, string environment)
        {
            var publishData = DeserializePublishData(stream);
            PublishDataPublishProfile profile = publishData.Items.Single();
            stream.Close();
            return profile.Subscription.Select(s => PublishSubscriptionToAzureSubscription(azureProfileClient, profile, s, environment));
        }

        private static PublishData DeserializePublishData(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(PublishData));
            return (PublishData)serializer.Deserialize(stream);
        }

        private static AzureSubscription PublishSubscriptionToAzureSubscription(
            ProfileClient azureProfileClient, 
            PublishDataPublishProfile profile,
            PublishDataPublishProfileSubscription s,
            string environment)
        {
            var certificate = GetCertificate(profile, s);

            if (string.IsNullOrEmpty(environment))
            {
                var azureEnvironment = azureProfileClient.GetEnvironment(environment, s.ServiceManagementUrl ?? profile.Url, null);
                if (azureEnvironment != null)
                {
                    environment = azureEnvironment.Name;
                }
                else
                {
                    environment = EnvironmentName.AzureCloud;
                }
            }
            
            return new AzureSubscription
            {
                Id = new Guid(s.Id),
                Name = s.Name,
                Environment = environment,
                Account = certificate.Thumbprint
            };
        }

        private static X509Certificate2 GetCertificate(PublishDataPublishProfile profile,
            PublishDataPublishProfileSubscription s)
        {
            string certificateString;
            if (!string.IsNullOrEmpty(s.ManagementCertificate))
            {
                certificateString = s.ManagementCertificate;
            }
            else
            {
                certificateString = profile.ManagementCertificate;
            }

            X509Certificate2 certificate = new X509Certificate2(Convert.FromBase64String(certificateString), string.Empty);
            AzureSession.DataStore.AddCertificate(certificate);
            
            return certificate;
        }
    }
}
