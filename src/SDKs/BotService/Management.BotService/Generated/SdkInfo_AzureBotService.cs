
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_AzureBotService
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("BotService", "Bots", "2017-12-01"),
                new Tuple<string, string, string>("BotService", "Channels", "2017-12-01"),
                new Tuple<string, string, string>("BotService", "Operations", "2017-12-01"),
            }.AsEnumerable();
        }
    }
}
