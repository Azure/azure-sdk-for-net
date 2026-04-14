// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.CostManagement.Models;

namespace Azure.ResourceManager.CostManagement
{
    public partial class SettingResource : IJsonModel<SettingData>
    {
        private static IJsonModel<SettingData> s_dataDeserializationInstance;

        private static IJsonModel<SettingData> DataDeserializationInstance => s_dataDeserializationInstance ??= new UnknownSetting();
    }
}
