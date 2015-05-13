// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    public class MigrationCommonModelFormatter
    {
        /// <summary>
        /// Converts HcsMessageInfo to desired String output
        /// </summary>
        /// <param name="msgInfo">msg info o/p</param>
        /// <returns>display string</returns>
        public string HcsMessageInfoToString(HcsMessageInfo msgInfo)
        {
            StringBuilder consoleOp = new StringBuilder();
            if (null != msgInfo)
            {
                int maxLength = msgInfo.GetType().GetProperties().ToList().Max(t => t.Name.Length);
                if (!string.IsNullOrEmpty(msgInfo.Message) ||
                    !string.IsNullOrEmpty(msgInfo.Recommendation))
                {
                    if (0 != msgInfo.ErrorCode)
                    {
                        consoleOp.AppendLine(IntendAndConCat("ErrorCode", msgInfo.ErrorCode, maxLength));
                    }

                    if (!string.IsNullOrEmpty(msgInfo.Message))
                    {
                        consoleOp.AppendLine(IntendAndConCat("Message", msgInfo.Message, maxLength));
                    }

                    if (!string.IsNullOrEmpty(msgInfo.Recommendation))
                    {
                        consoleOp.AppendLine(IntendAndConCat("Recommendation", msgInfo.Recommendation, maxLength));
                    }
                }
            }

            return consoleOp.ToString();
        }

        /// <summary>
        /// The API is used Concats the prefix and string representation of the object specified, seperated by delimiter with proper indentation b/w strings
        /// </summary>
        /// <param name="prefix">name of suffix object</param>
        /// <param name="suffix">object which needs to converted to string</param>
        /// <param name="maxLength">maxlength to which prefix should be indentented</param>
        /// <param name="delimiter">delimiter between the prefix and the object suffix</param>
        /// <returns>string formed by concatenating prefix and suffix</returns>
        public string IntendAndConCat(string prefix, object suffix, int maxLength = -1, string delimiter = null)
        {
            maxLength = (-1 == maxLength) ? this.GetType().GetProperties().ToList().Max(t => t.Name.Length) : maxLength;
            delimiter = !(string.IsNullOrEmpty(delimiter)) ? delimiter : " : ";
            var intendedOp = new StringBuilder();
            intendedOp.Append(prefix);
            if (0 < maxLength - prefix.Length)
            {
                intendedOp.Append(' ', maxLength - prefix.Length);
            }

            intendedOp.Append(delimiter);
            intendedOp.Append(suffix.ToString());
            return intendedOp.ToString();
        }

        /// <summary>
        /// Concats all string specified in list seperated by the specified delimiter
        /// </summary>
        /// <param name="stringList">list of string to be concatenate</param>
        /// <param name="delimiter">delimiter b/w individual strings</param>
        /// <returns>single string formed by concatenating string in list</returns>
        public string ConcatStringList(List<string> stringList, string delimiter = null)
        {
            string concatedStr = string.Empty;
            delimiter = !(string.IsNullOrEmpty(delimiter)) ? delimiter : ", ";
            if (null != stringList && 0 < stringList.Count)
            {
                foreach (string ipString in stringList)
                {
                    if (!string.IsNullOrEmpty(concatedStr))
                    {
                        concatedStr = string.Format("{0}{1}{2}", concatedStr, delimiter, ipString);
                    }
                    else
                    {
                        concatedStr = ipString;
                    }
                }
            }

            return concatedStr;
        }

        /// <summary>
        /// Format the timespan
        /// </summary>
        /// <param name="span">time span to displayed</param>
        /// <returns>time span in string format</returns>
        public string FormatTimeSpan(TimeSpan span)
        {
            string timeFormat = string.Empty;
            if (0 != span.Days)
            {
                timeFormat = string.Format("{0} Day{1} ", span.Days, ((1 == span.Days) ? "s" : string.Empty));
            }
            if (0 != span.Hours || 0 != span.Days)
            {
                timeFormat = string.Format("{0}{1} Hour{2} ", timeFormat, span.Hours,
                    ((1 < span.Hours) ? "s" : string.Empty));
            }
            if (0 != span.Minutes || (0 == span.Days && 0 == span.Hours))
            {
                timeFormat = string.Format("{0}{1} Minute{2} ", timeFormat, span.Minutes,
                    ((1 < span.Minutes) ? "s" : string.Empty));
            }

            return timeFormat;
        }

        /// <summary>
        /// Gets Confirm migration success message to be displayed with error string obtained from service
        /// </summary>
        /// <param name="status">migration job status</param>
        public string GetResultMessage(string successMsg, MigrationJobStatus status)
        {
            StringBuilder builder = new StringBuilder();
            bool errorMessage = false;
            if (null != status.MessageInfoList)
            {
                foreach (var msgInfo in status.MessageInfoList)
                {
                    string msgInfoStr = HcsMessageInfoToString(msgInfo);
                    if (!string.IsNullOrEmpty(msgInfoStr))
                    {
                        builder.AppendLine(msgInfoStr);
                        errorMessage = true;
                    }
                }
            }

            if (!errorMessage)
            {
                builder.AppendLine(successMsg);
            }

            return builder.ToString();
        }
    }
}