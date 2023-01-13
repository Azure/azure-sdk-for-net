using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class SynapseSparkJobDefinitionActivity : ExecutionActivity
    {
        /// <summary>
        /// Initializes a new instance of the SynapseSparkJobDefinitionActivity
        /// class.
        /// </summary>
        /// <param name="name">Activity name.</param>
        /// <param name="sparkJob">Synapse spark job reference.</param>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="description">Activity description.</param>
        /// <param name="dependsOn">Activity depends on condition.</param>
        /// <param name="userProperties">Activity user properties.</param>
        /// <param name="linkedServiceName">Linked service reference.</param>
        /// <param name="policy">Activity policy.</param>
        /// <param name="arguments">User specified arguments to
        /// SynapseSparkJobDefinitionActivity.</param>
        /// <param name="file">The main file used for the job, which will
        /// override the 'file' of the spark job definition you provide. Type:
        /// string (or Expression with resultType string).</param>
        /// <param name="className">The fully-qualified identifier or the main
        /// class that is in the main definition file, which will override the
        /// 'className' of the spark job definition you provide. Type: string
        /// (or Expression with resultType string).</param>
        /// <param name="files">Additional files used for reference in the main
        /// definition file, which will override the 'files' of the spark job
        /// definition you provide.</param>
        /// <param name="targetBigDataPool">The name of the big data pool which
        /// will be used to execute the spark batch job, which will override
        /// the 'targetBigDataPool' of the spark job definition you
        /// provide.</param>
        /// <param name="executorSize">Number of core and memory to be used for
        /// executors allocated in the specified Spark pool for the job, which
        /// will be used for overriding 'executorCores' and 'executorMemory' of
        /// the spark job definition you provide. Type: string (or Expression
        /// with resultType string).</param>
        /// <param name="conf">Spark configuration properties, which will
        /// override the 'conf' of the spark job definition you
        /// provide.</param>
        /// <param name="driverSize">Number of core and memory to be used for
        /// driver allocated in the specified Spark pool for the job, which
        /// will be used for overriding 'driverCores' and 'driverMemory' of the
        /// spark job definition you provide. Type: string (or Expression with
        /// resultType string).</param>
        /// <param name="numExecutors">Number of executors to launch for this
        /// job, which will override the 'numExecutors' of the spark job
        /// definition you provide.</param>
        public SynapseSparkJobDefinitionActivity(string name, SynapseSparkJobReference sparkJob, IDictionary<string, object> additionalProperties, string description, IList<ActivityDependency> dependsOn, IList<UserProperty> userProperties, LinkedServiceReference linkedServiceName, ActivityPolicy policy, IList<object> arguments, object file, object className, IList<object> files, BigDataPoolParametrizationReference targetBigDataPool, object executorSize = default(object), object conf = default(object), object driverSize = default(object), int? numExecutors = default(int?))
            : base(name, additionalProperties, description, dependsOn, userProperties, linkedServiceName, policy)
        {
            SparkJob = sparkJob;
            Arguments = arguments;
            File = file;
            ClassName = className;
            Files = files;
            TargetBigDataPool = targetBigDataPool;
            ExecutorSize = executorSize;
            Conf = conf;
            DriverSize = driverSize;
            NumExecutors = numExecutors;
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SynapseSparkJobDefinitionActivity
        /// class.
        /// </summary>
        /// <param name="name">Activity name.</param>
        /// <param name="sparkJob">Synapse spark job reference.</param>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="description">Activity description.</param>
        /// <param name="dependsOn">Activity depends on condition.</param>
        /// <param name="userProperties">Activity user properties.</param>
        /// <param name="linkedServiceName">Linked service reference.</param>
        /// <param name="policy">Activity policy.</param>
        /// <param name="arguments">User specified arguments to
        /// SynapseSparkJobDefinitionActivity.</param>
        /// <param name="file">The main file used for the job, which will
        /// override the 'file' of the spark job definition you provide. Type:
        /// string (or Expression with resultType string).</param>
        /// <param name="className">The fully-qualified identifier or the main
        /// class that is in the main definition file, which will override the
        /// 'className' of the spark job definition you provide. Type: string
        /// (or Expression with resultType string).</param>
        /// <param name="files">(Deprecated. Please use pythonCodeReference and
        /// filesV2) Additional files used for reference in the main definition
        /// file, which will override the 'files' of the spark job definition
        /// you provide.</param>
        /// <param name="pythonCodeReference">Additional python code files used
        /// for reference in the main definition file, which will override the
        /// 'pyFiles' of the spark job definition you provide.</param>
        /// <param name="filesV2">Additional files used for reference in the
        /// main definition file, which will override the 'jars' and 'files' of
        /// the spark job definition you provide.</param>
        /// <param name="targetBigDataPool">The name of the big data pool which
        /// will be used to execute the spark batch job, which will override
        /// the 'targetBigDataPool' of the spark job definition you
        /// provide.</param>
        /// <param name="executorSize">Number of core and memory to be used for
        /// executors allocated in the specified Spark pool for the job, which
        /// will be used for overriding 'executorCores' and 'executorMemory' of
        /// the spark job definition you provide. Type: string (or Expression
        /// with resultType string).</param>
        /// <param name="conf">Spark configuration properties, which will
        /// override the 'conf' of the spark job definition you
        /// provide.</param>
        /// <param name="driverSize">Number of core and memory to be used for
        /// driver allocated in the specified Spark pool for the job, which
        /// will be used for overriding 'driverCores' and 'driverMemory' of the
        /// spark job definition you provide. Type: string (or Expression with
        /// resultType string).</param>
        /// <param name="numExecutors">Number of executors to launch for this
        /// job, which will override the 'numExecutors' of the spark job
        /// definition you provide.</param>
        public SynapseSparkJobDefinitionActivity(string name, SynapseSparkJobReference sparkJob, IDictionary<string, object> additionalProperties, string description, IList<ActivityDependency> dependsOn, IList<UserProperty> userProperties, LinkedServiceReference linkedServiceName, ActivityPolicy policy, IList<object> arguments, object file, object className = default(object), IList<object> files = default(IList<object>), IList<object> pythonCodeReference = default(IList<object>), IList<object> filesV2 = default(IList<object>), BigDataPoolParametrizationReference targetBigDataPool = default(BigDataPoolParametrizationReference), object executorSize = default(object), object conf = default(object), object driverSize = default(object), int? numExecutors = default(int?))
            : base(name, additionalProperties, description, dependsOn, userProperties, linkedServiceName, policy)
        {
            SparkJob = sparkJob;
            Arguments = arguments;
            File = file;
            ClassName = className;
            Files = files;
            PythonCodeReference = pythonCodeReference;
            FilesV2 = filesV2;
            TargetBigDataPool = targetBigDataPool;
            ExecutorSize = executorSize;
            Conf = conf;
            DriverSize = driverSize;
            NumExecutors = numExecutors;
            CustomInit();
        }
    }
}
