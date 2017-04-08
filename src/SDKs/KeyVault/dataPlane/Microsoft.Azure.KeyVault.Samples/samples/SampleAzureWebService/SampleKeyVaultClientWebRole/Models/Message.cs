//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

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

