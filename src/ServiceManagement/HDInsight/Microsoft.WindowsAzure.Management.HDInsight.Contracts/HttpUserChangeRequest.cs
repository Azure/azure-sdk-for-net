﻿using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts
{
    /// <summary>
    /// Strongly typed class to represent the payload of a passthrough request to change the HTTP user.
    /// </summary>
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class HttpUserChangeRequest : UserChangeRequest
    {
    }
}
