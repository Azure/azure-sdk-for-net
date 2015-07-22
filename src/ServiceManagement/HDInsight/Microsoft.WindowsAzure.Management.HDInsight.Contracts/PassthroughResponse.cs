using System;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts
{
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015;

    /// <summary>
    /// Class that represents a response to a passthrough request.
    /// </summary>
    // TODO: Re-enable all of the KnownTypes that are here for job submission, once job submission is enabled
    //       All of these types need to move into this project and need to be updated to specify ordering, etc, as needed for RDFE
    //[KnownType(typeof(List<string>))]
    //[KnownType(typeof(JobDetails))]
    //[KnownType(typeof(DatabaseDetails))]
    //[KnownType(typeof(TableDetails))]
    //[KnownType(typeof(ColumnDetails))]
    [KnownType(typeof(UserChangeOperationStatusResponse))]
    [KnownType(typeof(Cluster))]
    [KnownType(typeof(ComponentSet))]
    [KnownType(typeof(Operation))]
    [KnownType(typeof(ClusterRoleCollection))]
    [KnownType(typeof(ClusterComponent))]
    [KnownType(typeof(MapReduceComponent))]
    [KnownType(typeof(HBaseComponent))]
    [KnownType(typeof(HdfsComponent))]
    [KnownType(typeof(HiveComponent))]
    [KnownType(typeof(OozieComponent))]
    [KnownType(typeof(YarnComponent))]
    [KnownType(typeof(GatewayComponent))]
    [KnownType(typeof(HadoopCoreComponent))]
    [KnownType(typeof(ZookeeperComponent))]
    [KnownType(typeof(StormComponent))]
    [KnownType(typeof(DashboardComponent))]
    [KnownType(typeof(UserChangeOperationStatusResponse))]
    [KnownType(typeof(IaasCluster))]
    [DataContract(Namespace = May2013.Constants.XsdNamespace)]
    public class PassthroughResponse
    {
        [DataMember(EmitDefaultValue = true, IsRequired = false, Order = 1)]
        public object Data { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = false, Order = 2)]
        public ErrorDetails Error { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"PassthroughResponse:"));
            if (Data != null)
            {
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"Data: {0}", this.Data));
            }
            if (Error != null)
            {
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"Error:"));
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tStatusCode: {0}", Error.StatusCode));
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tErrorId: {0}", Error.ErrorId));
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tErrorMessage: {0}", Error.ErrorMessage));
            }
            return builder.ToString();
        }
    }
}