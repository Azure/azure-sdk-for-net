// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using CommandLine;

namespace Azure.DigitalTwins.Core.Samples
{
    internal enum LoginMethod
    {
        AppId,
        User,
    };

    public class Options
    {
        [Option('a', "adtEndpoint", Required = true, HelpText = "Digital twins service endpoint")]
        public string AdtEndpoint { get; set; }

        [Option('i', "clientId", Required = true, HelpText = "Client Id of the application Id to login, or the application Id used to log the user in.")]
        public string ClientId { get; set; }

        [Option('m', "loginMethod", Required = false, Default = "AppId", HelpText = "Choose between: AppId, User.")]
        public string LoginMethod { get; set; }

        [Option('t', "tenantId", Required = true, HelpText = "Application tenant Id")]
        public string TenantId { get; set; }

        [Option('s', "clientSecret", Required = false, HelpText = "Application client secret. Only applicable when using LoginMethod of AppId.")]
        public string ClientSecret { get; set; }

        [Option('e', "eventHubName", Required = true, HelpText = "Event Hub Name linked to digital twins instance")]
        public string EventHubName { get; set; }

        internal LoginMethod GetLoginMethod()
        {
            if (Enum.TryParse<LoginMethod>(LoginMethod, out LoginMethod loginMethod))
            {
                return loginMethod;
            }

            return Samples.LoginMethod.AppId;
        }
    }
}
