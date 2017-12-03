using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Microsoft.Azure.Sdk.Build.Tasks.Utilities
{


    public class MsBuildProjectFile : IFileSystemAsset
    {
        #region private fields
        //string _fullFilePath;

        private bool CreateDirectoryIfDoesNotExists { get; set; }
        #endregion
        public string FullFilePath { get; set; }

        public MsBuildProjectFile(string fileFullPath) : this(fileFullPath, true)
        { }

        public MsBuildProjectFile(string fileFullPath, bool createDirectory)
        {
            FullFilePath = fileFullPath;
            CreateDirectoryIfDoesNotExists = createDirectory;
        }

        public void CreateEmptyFile()
        {
            if(!string.IsNullOrEmpty(FullFilePath))
            {
                CreateXmlDocWithProps();
            }
            else
            {
                throw new ApplicationException(string.Format("FullFilePath:'{0}' is not initialized", FullFilePath));
            }
        }

        internal string CreateXmlDocWithProps(string fullFilePathToCreate)
        {
            if (!File.Exists(fullFilePathToCreate))
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.DocumentElement;

                XmlComment comment = doc.CreateComment("This file and it's contents are updated at build time moving or editing might result in build failure. Take due deligence while editing this file");

                XmlElement projNode = doc.CreateElement("Project");
                projNode.SetAttribute("ToolsVersion", "15.0");
                projNode.SetAttribute("xmlns", "http://schemas.microsoft.com/developer/msbuild/2003");
                doc.AppendChild(projNode);

                projNode.AppendChild(comment);

                XmlElement propGroup = doc.CreateElement("PropertyGroup");
                projNode.AppendChild(propGroup);

                XmlElement apiTagProp = doc.CreateElement("AzureApiTag");
                propGroup.AppendChild(apiTagProp);

                XmlElement pkgTag = doc.CreateElement("PackageTags");
                XmlText pkgTagValue = doc.CreateTextNode("$(PackageTags);$(CommonTags);$(AzureApiTag);");
                pkgTag.AppendChild(pkgTagValue);

                propGroup.AppendChild(pkgTag);

                doc.Save(FullFilePath);

                if(File.Exists(fullFilePathToCreate))
                {
                    FullFilePath = fullFilePathToCreate;
                }
            }

            return fullFilePathToCreate;
        }
        internal string CreateXmlDocWithProps()
        {
            return CreateXmlDocWithProps(FullFilePath);
        }
        private void CreateXDoc()
        {
            if (!File.Exists(FullFilePath))
            {
                XDocument xDoc = new XDocument(
                                                new XElement("Project",
                                                new XElement("PropertyGroup",
                                                new XElement("AzureApiTag"))));

                CreateDirectoryPath(FullFilePath);
                xDoc.Save(FullFilePath);
            }
        }
        
        private void SaveToFileSystem()
        {
            
        }
        
        public bool ValidatePath(string fileFullPath)
        {
            bool isPathValid = false;
            if (!File.Exists(FullFilePath))
            {
                if (Directory.Exists(Path.GetDirectoryName(FullFilePath)))
                {
                    isPathValid = true;
                }
            }
            else
            {
                isPathValid = true;

            }

            return isPathValid;
        }

        internal void CreateDirectoryPath(string filePath)
        {
            if (CreateDirectoryIfDoesNotExists)
            {
                string dir = Path.GetDirectoryName(filePath);
                if (Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
        }
    }

    public interface IFileSystemAsset
    {
        string FullFilePath { get; set; }
        
    }
}

/*
        //{
        //    get
        //    {
        //        return _fullFilePath;
        //    }

        //    set
        //    {
        //        if (File.Exists(value))
        //        {
        //            _fullFilePath = value;
        //        }
        //        else
        //        {
        //            throw new FileNotFoundException("File not found '{0}'", value);
        //        }
        //    }
        //}
*/
