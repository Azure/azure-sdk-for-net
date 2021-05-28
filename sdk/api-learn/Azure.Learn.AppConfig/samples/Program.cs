// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Learn.AppConfig.Samples
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var sample1 = new Sample1_HelloWorld();
            sample1.GetConfigurationSetting();

            var sample2 = new Sample2_GetSettingIfChanged();
            await sample2.GetConfigurationSettingIfChanged();
        }
    }
}
