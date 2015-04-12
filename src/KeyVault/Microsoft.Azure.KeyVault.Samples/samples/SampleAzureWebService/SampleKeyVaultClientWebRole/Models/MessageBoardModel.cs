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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleKeyVaultClientWebRole.Models
{
    /// <summary>
    /// Model representing the data that is displayed in the main home page.
    /// This includes a new message entry that the user might input, recent messages loaded
    /// from storage and trace messages with details on the steps.
    /// </summary>
    public class MessageBoardModel
    {
        public MessageBoardModel()
        {
            NewMessage = new Message();
            RecentMessages = new List<Message>();
            Trace = new List<string>();
        }

        public Message NewMessage { get; set; }
        public List<Message> RecentMessages { get; set; }

        public List<string> Trace { get; set; }

        [DataType(DataType.MultilineText)]
        public string RecentMessagesAsString
        {
            get
            {
                if (RecentMessages != null && RecentMessages.Count > 0)
                {
                    string ret = "";
                    for (int i = 0; i < RecentMessages.Count; i++)
                    {
                        ret += RecentMessages[i].ToString() + "\n";
                    }
                    return ret;
                }
                else
                    return "No recent messages...";
            }
        }

        [DataType(DataType.MultilineText)]
        public string TracesAsString
        {
            get
            {
                string ret = "";
                foreach (string s in Trace)
                    ret += s + "\n";
                return ret;
            }
        }
    }
}