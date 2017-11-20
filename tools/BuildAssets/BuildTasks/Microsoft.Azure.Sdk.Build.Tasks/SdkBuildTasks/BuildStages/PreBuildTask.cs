namespace Microsoft.Azure.Sdk.Build.Tasks.BuildStages
{
    using System;
    using Microsoft.Build.Utilities;
    using Microsoft.Build.Framework;

    /// <summary>
    /// 
    /// </summary>
    public class PreBuildTask : Task
    {

        #region Required Properties
        [Required]
            public ITaskItem ProjectToBuild { get; set; }

#endregion
        public override bool Execute()
        {
            

            return true;
        }
    }
}
