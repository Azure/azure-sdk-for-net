// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace ProcDetailsTestApplication
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This application when executed provides the details of it's execution
    /// space in a manner that can be later parsed by the test system.
    /// </summary>
    public class ProcDetails
    {
        private string[] args;
        private const string HadoopHome = "HADOOP_HOME";
        private const string HiveHome = "HIVE_HOME";

        /// <summary>
        /// Common string used to represent the section for Command Line Arguments.
        /// </summary>
        public const string CommandLineArguments = "Command Line Arguments";

        /// <summary>
        /// Common string used to represent the section for input lines.
        /// </summary>
        public const string InputLines = "Input Lines";

        /// <summary>
        /// Common string used to represent the section for System Values.
        /// </summary>
        public const string SystemValues = "System Values";

        /// <summary>
        /// Common string used to represent the section for Environment Variables.
        /// </summary>
        public const string EnvironmentVariables = "Environment Variables";

        /// <summary>
        /// Common string used to represent the section for Core Site Xml Settings.
        /// </summary>
        public const string CoreSiteSettings = "Core Site Xml Settings";

        /// <summary>
        /// Common string used to represent the section for Hive Site Xml Settings.
        /// </summary>
        public const string HiveSiteSettings = "Hive Site Xml Settings";

        /// <summary>
        /// Common string used to represent the section for Map/Reduce Site Xml Settings.
        /// </summary>
        public const string MapRedSiteSettings = "Map Reduce Site Xml Settings";

        /// <summary>
        /// Common string used to represent the section resulting from errors in processing.
        /// </summary>
        public const string Errors = "Errors Reading Environment";

        // Errors occuring when processing.
        private Entries errors = new Entries();
        private Entries lines;

        internal delegate Entries GetEntries();

        internal GetEntries SystemValuesGetter;
        internal GetEntries InputGetter;
        internal GetEntries EnvironmentVariablesGetter;
        internal GetEntries CoreSiteGetter;
        internal GetEntries HiveSiteGetter;
        internal GetEntries MapRedSiteGetter;

        private Entries GetEnvironmentVariables()
        {
            Dictionary<string, string> environmentVariables = new Dictionary<string, string>();
            foreach (DictionaryEntry environmentVariable in System.Environment.GetEnvironmentVariables())
            {
                environmentVariables.Add(environmentVariable.Key.ToString(), environmentVariable.Value.ToString());
            }
            return new Entries(environmentVariables);
        }

        private Entries GetCoreSiteXml()
        {
            var home = System.Environment.GetEnvironmentVariable(HadoopHome);
            if (!string.IsNullOrWhiteSpace(home))
            {
                home = home.Trim('\"');
                var sitePath = Path.Combine(home, "conf", "core-site.xml");
                if (File.Exists(sitePath))
                {
                    var ser = new SiteXmlSerializer();
                    return ser.DeserializeXml(sitePath);
                }
                else
                {
                    this.errors.Add(CoreSiteSettings, "Unable to locate core-site.xml");
                }
            }
            else
            {
                this.errors.Add(CoreSiteSettings, "Unable to locate Hadoop Home");
            }
            return new Entries();
        }

        private Entries GetHiveSiteXml()
        {
            var home = System.Environment.GetEnvironmentVariable(HiveHome);
            if (!string.IsNullOrWhiteSpace(home))
            {
                home = home.Trim('\"');
                var sitePath = Path.Combine(home, "conf", "hive-site.xml");
                if (File.Exists(sitePath))
                {
                    var ser = new SiteXmlSerializer();
                    return ser.DeserializeXml(sitePath);
                }
                else
                {
                    this.errors.Add(HiveSiteSettings, "unable to locate hive-site.xml");
                }
            }
            else
            {
                this.errors.Add(HiveSiteSettings, "Unable to locate HiveHome");
            }
            return new Entries();
        }

        private Entries GetMapRedSiteXml()
        {
            var home = System.Environment.GetEnvironmentVariable(HadoopHome);
            if (!string.IsNullOrWhiteSpace(home))
            {
                home = home.Trim('\"');
                var sitePath = Path.Combine(home, "conf", "mapred-site.xml");
                if (File.Exists(sitePath))
                {
                    var ser = new SiteXmlSerializer();
                    return ser.DeserializeXml(sitePath);
                }
                else
                {
                    this.errors.Add(MapRedSiteSettings, "unable to locate mapred-site.xml");
                }
            }
            else
            {
                this.errors.Add(MapRedSiteSettings, "Unable to locate HadoopHome");
            }
            return new Entries();
        }

        private Entries GetConsoleInput()
        {
            if (ReferenceEquals(this.lines, null))
            {
                List<string> lines = new List<string>();
                using (var input = Console.OpenStandardInput())
                using (var reader = new StreamReader(input))
                {
                    while (!reader.EndOfStream)
                    {
                        lines.Add(reader.ReadLine());
                    }
                }
                this.lines = Entries.MakeEntries(lines);
            }
            return this.lines;
        }

        private Entries GetSystemValues()
        {
            var machineName = System.Environment.MachineName;
            Entries retval = new Entries();
            retval.Add("MachineName", machineName);
            return retval;
        }

        internal ProcDetails(string[] args)
        {
            this.args = args;
            this.SystemValuesGetter = this.GetSystemValues;
            this.InputGetter = this.GetConsoleInput;
            this.EnvironmentVariablesGetter = this.GetEnvironmentVariables;
            this.CoreSiteGetter = this.GetCoreSiteXml;
            this.HiveSiteGetter = this.GetHiveSiteXml;
            this.MapRedSiteGetter = this.GetMapRedSiteXml;
        }

        private void Run()
        {
            Sections sections = new Sections();
            sections.Add(CommandLineArguments, Entries.MakeEntries(this.args));
            sections.Add(InputLines, this.InputGetter());
            sections.Add(SystemValues, this.GetSystemValues());
            sections.Add(EnvironmentVariables, this.EnvironmentVariablesGetter());
            sections.Add(CoreSiteSettings, this.CoreSiteGetter());
            sections.Add(HiveSiteSettings, this.HiveSiteGetter());
            sections.Add(MapRedSiteSettings, this.MapRedSiteGetter());
            sections.Add(Errors, this.errors);
            var ser = new SectionsSerializer();
            Console.Write(ser.Serialize(sections));
        }

        private static void Main(string[] args)
        {
            var app = new ProcDetails(args);
            app.Run();
        }
    }
}
