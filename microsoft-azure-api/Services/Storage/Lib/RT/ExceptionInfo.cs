// -----------------------------------------------------------------------------------------
// <copyright file="ExceptionInfo.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage
{
    using System;
    using System.Xml;
    using Microsoft.WindowsAzure.Storage.Core.Util;

    /// <summary>
    /// Represents exception information from a request to the Storage service.
    /// </summary>
    public sealed class ExceptionInfo
    {
        /// <summary>
        /// Gets the type of the exception.
        /// </summary>
        /// <value>The type of the exception.</value>
        public string Type { get; internal set; }

        /// <summary>
        /// Gets HRESULT, a coded numerical value that is assigned to a specific exception.
        /// </summary>
        /// <value>The HRESULT value.</value>
        public int HResult { get; internal set; }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        /// <value>The error message that explains the reason for the exception, or an empty string("").</value>
        public string Message { get; internal set; }

        /// <summary>
        /// Gets the name of the operation that causes the error. 
        /// </summary>
        /// <value>The name of the operation that causes the error.</value>
        public string Source { get; internal set; }

        /// <summary>
        /// Gets a string representation of the frames on the call stack at the time the current exception was thrown. 
        /// </summary>
        /// <value>The frames on the call stack at the time the current exception was thrown.</value>
        public string StackTrace { get; internal set; }

        /// <summary>
        /// Gets the <see cref="ExceptionInfo"/> instance that caused the current exception.
        /// </summary>
        /// <value>An instance of <see cref="ExceptionInfo"/> that describes the error that caused the current exception. </value>
        public ExceptionInfo InnerExceptionInfo { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionInfo"/> class.
        /// </summary>
        public ExceptionInfo()
        {
        }

        internal ExceptionInfo(Exception ex)
        {
            this.Type = ex.GetType().Name;
            this.Message = ex.Message;
            this.StackTrace = ex.StackTrace;
#if RTMD
            this.HResult = ex.HResult;
#endif

#if COMMON
#else
            this.Source = ex.Source;
#endif
            if (ex.InnerException != null)
            {
                this.InnerExceptionInfo = new ExceptionInfo(ex.InnerException);
            }
        }

        internal static ExceptionInfo ReadFromXMLReader(XmlReader reader)
        {
            ExceptionInfo res = new ExceptionInfo();
            try
            {
                res.ReadXml(reader);
            }
            catch (XmlException)
            {
                return null;
            }

            return res;
        }

        #region IXMLSerializable

        internal void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("ExceptionInfo");
            writer.WriteElementString("Type", this.Type);
#if RTMD
            writer.WriteElementString("HResult", Convert.ToString(this.HResult));
#endif
            writer.WriteElementString("Message", this.Message);
#if COMMON
#else
            writer.WriteElementString("Source", this.Source);
#endif
            writer.WriteElementString("StackTrace", this.StackTrace);

            if (this.InnerExceptionInfo != null)
            {
                writer.WriteStartElement("InnerExceptionInfo");
                this.InnerExceptionInfo.WriteXml(writer);
                writer.WriteEndElement();
            }

            // End ExceptionInfo
            writer.WriteEndElement();
        }

        internal void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("ExceptionInfo");
            this.Type = General.ReadElementAsString("Type", reader);

#if RTMD
            this.HResult = int.Parse(General.ReadElementAsString("HResult", reader));
#endif
            this.Message = General.ReadElementAsString("Message", reader);
#if COMMON
#else
            this.Source = General.ReadElementAsString("Source", reader);
#endif
            this.StackTrace = General.ReadElementAsString("StackTrace", reader);

            if (reader.IsStartElement() && reader.LocalName == "InnerExceptionInfo")
            {
                reader.ReadStartElement("InnerExceptionInfo");
                this.InnerExceptionInfo = ReadFromXMLReader(reader);
                reader.ReadEndElement();
            }

            // End ExceptionInfo
            reader.ReadEndElement();
        }
        
        #endregion
    }
}
