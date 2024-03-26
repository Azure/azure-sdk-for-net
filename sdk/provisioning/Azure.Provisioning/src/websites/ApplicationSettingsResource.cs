// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.AppService.Models;

namespace Azure.Provisioning.AppService
{
    internal class ApplicationSettingsResource : Resource<AppServiceConfigurationDictionary>
    {
        private const string ResourceTypeName = "Microsoft.Web/sites/config";

        public ApplicationSettingsResource(IConstruct scope, IDictionary<string, string> appSettings, WebSite? parent = null, string version = "2021-02-01")
            : base(scope, parent, "appsettings", ResourceTypeName, version, (name) => ArmAppServiceModelFactory.AppServiceConfigurationDictionary(
                name: "appsettings",
                properties: appSettings))
        {
        }

        public void AddApplicationSetting(string key, string value)
        {
            Properties.Properties.Add(key, value);
        }

        public void AddApplicationSetting(string key, Parameter value)
        {
            Properties.Properties.Add(key, $"_p_.{value.Name}");
        }
    }
}
