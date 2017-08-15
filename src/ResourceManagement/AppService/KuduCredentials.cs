// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using System;
using System.Text.RegularExpressions;
using System.Net.Http;

namespace Microsoft.Azure.Management.AppService.Fluent
{
    internal class KuduCredentials : ServiceClientCredentials
    {
        private string token;
        private long expire;
        private FunctionAppImpl functionApp;

        internal KuduCredentials(FunctionAppImpl functionApp)
        {
            this.functionApp = functionApp;
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (token == null || expire < DateTime.Now.Ticks)
            {
                token = functionApp.Manager.Inner.WebApps
                    .GetFunctionsAdminToken(functionApp.ResourceGroupName, functionApp.Name);
                string jwt = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(token.Split(new char[] { '.' })[1]));
                Regex regex = new Regex("\"exp\": *([0-9]+),");
                Match match = regex.Match(jwt);
                expire = long.Parse(match.Groups[1].Value);
            }
            request.Headers.Add("Authorization", "Bearer " + token);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}