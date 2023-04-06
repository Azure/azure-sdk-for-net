// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core.Serialization;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Samples
{
    public static class JsonCustomization
    {
        #region Snippet:SystemTextJsonCustomization
        public class SystemTextJsonStartup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                builder.Services.Configure<SignalROptions>(o => o.JsonObjectSerializer = new JsonObjectSerializer(
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    }));
            }
        }
        #endregion

        #region Snippet:NewtonsoftJsonCustomization
        public class NewtonsoftJsonStartup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                builder.Services.Configure<SignalROptions>(o => o.JsonObjectSerializer = new NewtonsoftJsonObjectSerializer(
                    new JsonSerializerSettings()
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                ));
            }
        }
        #endregion
    }
}