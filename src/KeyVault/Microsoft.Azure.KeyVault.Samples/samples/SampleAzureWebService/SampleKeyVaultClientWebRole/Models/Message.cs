// 
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace SampleKeyVaultClientWebRole.Models
{
    /// <summary>
    /// A message saved in the storage table - the user name and some text
    /// </summary>
    public class Message : TableEntity
    {
        public Message()
        { 
        
        }
        public Message(string u, string m)
        {
            UserName = u;
            MessageText = m;
        }

        public string UserName { get; set; }

        public string MessageText { get; set; }

        public DateTime CreationTime { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] User \'{1}\' said: \t\"{2}\"", CreationTime.ToString(), UserName, MessageText);
        }
    }
}

