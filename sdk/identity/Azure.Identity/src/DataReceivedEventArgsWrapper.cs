// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.Identity
{
    internal class DataReceivedEventArgsWrapper
    {
        public DataReceivedEventArgsWrapper(string data)
        {
            Data = data;
        }

        public DataReceivedEventArgsWrapper(DataReceivedEventArgs args)
        {
            Data = args?.Data;
        }

        public string Data { get; }
    }

    internal delegate void DataReceivedEventWrapperHandler(object sender, DataReceivedEventArgsWrapper e);
}
