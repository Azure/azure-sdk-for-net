// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System;
    using ApplicationGatewayProbe.Definition;
    using ApplicationGatewayProbe.UpdateDefinition;
    using ApplicationGateway.Update;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for ApplicationGatewayProbe.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5UHJvYmVJbXBs
    internal partial class ApplicationGatewayProbeImpl  :
        ChildResource<Models.ApplicationGatewayProbeInner, ApplicationGatewayImpl, IApplicationGateway>,
        IApplicationGatewayProbe,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayProbe.Update.IUpdate
    {
        
        ///GENMHASH:7A83988386C7C70A116BE5DCD6855E1F:3D04631A2220D4D9B77495D5BB355D5B
        public int RetriesBeforeUnhealthy()
        {
            return (Inner.UnhealthyThreshold != null) ? Inner.UnhealthyThreshold.Value : 0;
        }

        
        ///GENMHASH:5319363BA516693C02815523816AB844:00B3C8CCF6429E7DE6545D5135D5BFDE
        public ApplicationGatewayProbeImpl WithPath(string path)
        {
            if (path != null && !path.StartsWith("/"))
            {
                path = "/" + path;
            }
            Inner.Path = path;
            return this;
        }

        
        ///GENMHASH:A473E8C551A81C93BD8EA73FE99E314B:8E47A7551FAA8958BCB5314D0E665506
        public ApplicationGatewayProbeImpl WithProtocol(ApplicationGatewayProtocol protocol)
        {
            Inner.Protocol = protocol.Value;
            return this;
        }

        
        ///GENMHASH:604F12B361C77B3E3AD5768A73BA6DCF:D334CF6C9B1B779FDE1F111524814A80
        public ApplicationGatewayProbeImpl WithHttp()
        {
            return WithProtocol(ApplicationGatewayProtocol.Http);
        }

        
        ///GENMHASH:0C099F803BFF93B985C6F9147E5A5C94:ADDE1E2C72810A483408581D937F159B
        public ApplicationGatewayProbeImpl WithHost(string host)
        {
            Inner.Host = host;
            return this;
        }

        
        ///GENMHASH:FA888A1E446DDA9E368D1EF43B428BAC:E284CF01C0CAA27F5A90C3ABCFAC1A76
        public ApplicationGatewayProbeImpl WithHttps()
        {
            return WithProtocol(ApplicationGatewayProtocol.Https);
        }

        
        ///GENMHASH:37084664F49C3D11783DB37E6E3AEC41:01248376B0F04FE8677BF1A5C20D3D3C
        public ApplicationGatewayProbeImpl WithTimeoutInSeconds(int seconds)
        {
            Inner.Timeout = seconds;
            return this;
        }

        
        ///GENMHASH:173B129C5EA6C47FFC97F082948F9DBE:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal  ApplicationGatewayProbeImpl(ApplicationGatewayProbeInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        
        ///GENMHASH:A9FF49E997E9B5A09BF0C69F4EDEE447:ED5B6906F820C8BDA19CA2404E9ADC16
        public int TimeoutInSeconds()
        {
            return (Inner.Timeout != null) ? Inner.Timeout.Value: 0;
        }

        
        ///GENMHASH:537F077310BD926C06D990A2A9E0B9F7:D006895CE997A6BBCC10525F46BE9275
        public ApplicationGatewayProbeImpl WithTimeBetweenProbesInSeconds(int seconds)
        {
            Inner.Interval = seconds;
            return this;
        }

        
        ///GENMHASH:8DD7957DF346525387CB5260FCB137FA:9E96D894B08BF26B7839105F76681D56
        public string Path()
        {
            return Inner.Path;
        }

        
        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        public ApplicationGatewayProtocol Protocol()
        {
            return ApplicationGatewayProtocol.Parse(Inner.Protocol);
        }

        
        ///GENMHASH:BC34BEC0EEC7CFEE35830DAF210D5171:5C5C9EA2F1762FB1DFD4F57FF4964BC3
        public int TimeBetweenProbesInSeconds()
        {
            return (Inner.Interval != null) ? Inner.Interval.Value : 0;
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        
        ///GENMHASH:B080669EED3C5A54D6A185F636429F32:C65F5A25BEF7A92C9DD3487ABDFEA44D
        public string Host()
        {
            return Inner.Host;
        }

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:DC5402587DE18D89F2F72B8535043012
        public ApplicationGatewayImpl Attach()
        {
            return Parent.WithProbe(this);
        }

        
        ///GENMHASH:70E7D37BF133357D21295D242DC89671:506FC3ABD5638395D7C77A111BC83582
        public ApplicationGatewayProbeImpl WithRetriesBeforeUnhealthy(int retryCount)
        {
            Inner.UnhealthyThreshold = retryCount;
            return this;
        }

        IUpdate ISettable<IUpdate>.Parent()
        {
            return Parent;
        }
    }
}
