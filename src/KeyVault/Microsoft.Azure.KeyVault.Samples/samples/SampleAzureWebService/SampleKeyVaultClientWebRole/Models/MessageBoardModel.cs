//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

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