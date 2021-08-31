// -------------------------------------------------------------------------
//  <copyright file="Arguments.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------
// 

namespace ConsoleTest
{
    public class Arguments
    {
        public string Tenant { get; set; }

        public string Client { get; set; }

        public string ClientSecret { get; set; }
        
        public string AccountEndpoint { get; set; }
        
        public string Instance { get; set; }
        
        public string ConnectionString { get; set; }
        
        public string Device { get; set; }
        
        public string DeviceTag { get; set; }

        public bool Delete { get; set; }
    }
}
