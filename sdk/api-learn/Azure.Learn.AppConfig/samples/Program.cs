using System;
using System.Threading.Tasks;
using Azure.Learn.AppConfig.Samples;

namespace samples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sample1 = new Sample1_HelloWorld();
            sample1.GetConfigurationSetting();

            var sample2 = new Sample2_GetSettingIfChanged();
            await sample2.GetConfigurationSettingIfChanged();
        }
    }
}
