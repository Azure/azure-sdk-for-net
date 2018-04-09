using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training
{
    public partial class TrainingApi
    {
        /// <summary>
        /// An partial-method to perform custom initialization.
        ///</summary>
        partial void CustomInitialize()
        {
            //Iso8601TimeSpanConverter causes problems with our account quota timestamps
            this.DeserializationSettings.Converters.Clear();
        }
    }
}
