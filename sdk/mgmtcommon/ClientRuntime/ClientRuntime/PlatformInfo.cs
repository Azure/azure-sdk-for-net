// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Rest
{
    using System;
    using System.Runtime.InteropServices;
    using System.IO;
    using System.Text.RegularExpressions;
#if FullNetFx
    using Microsoft.Win32;
#endif
    internal class PlatformInfo
    {
        #region Fields
        private OsInfo _osInfo;
        #endregion
        public OsInfo OsInfo
        {
            get
            {
                if(_osInfo == null)
                {
                    _osInfo = new OsInfo();
                }

                return _osInfo;
            }
        }
    }


    /// <summary>
    /// Provides basic information of underlying OS
    /// </summary>
    internal class OsInfo
    {
        #region Const
        const string WIN_OS_NAME = "Windows";
        const string LINUX_OS_NAME = "Linux";
        const string MAC_OSX_OS_NAME = "MacOs";
        #endregion

        #region Fields
        private string _osName;
        private bool _isOsWindows;
        #endregion

        public string OsName
        {
            get
            {
                if (string.IsNullOrEmpty(_osName))
                {
                    _osName = GetOsName();
                }

                return _osName;
            }
        }
        public string OsVersion
        {
            get
            {
                return GetOsVersion();
            }
        }

        public bool IsOsWindows
        {
            get
            {
                if (OsName.Equals(WIN_OS_NAME, StringComparison.OrdinalIgnoreCase))
                {
                    _isOsWindows = true;
                }
                else
                {
                    _isOsWindows = false;
                }

                return _isOsWindows;
            }
        }


        public OsInfo() { }

        private string GetOsVersion()
        {
            string osVer = string.Empty;
            try
            {
#if FullNetFx
                osVer = Environment.OSVersion.Version.ToString();
#elif !FullNetFx
                osVer = RuntimeInformation.OSDescription;
#endif

                if (string.IsNullOrEmpty(osVer))
                {
                    osVer = GetOsVersionBackup();
                }
            }
            catch
            {
                osVer = GetOsVersionBackup();
            }

            return osVer;
        }

        private string GetOsName()
        {
            string detectedOs = string.Empty;
            string exceptionFormat = "Unsupported Platform '{0}'";
            try
            {
#if FullNetFx
                switch (Environment.OSVersion.Platform)
                {
                    case PlatformID.Unix:
                        detectedOs = LINUX_OS_NAME;
                        break;
                    case PlatformID.MacOSX:
                        detectedOs = MAC_OSX_OS_NAME;
                        break;
                    case PlatformID.Win32NT:
                    case PlatformID.Win32S:
                    case PlatformID.Win32Windows:
                        detectedOs = WIN_OS_NAME;
                        break;
                    default:
                        throw new ApplicationException(string.Format(exceptionFormat, Environment.OSVersion.Platform.ToString()));
                }
#elif !FullNetFx
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    detectedOs = WIN_OS_NAME;
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    detectedOs = LINUX_OS_NAME;
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    detectedOs = MAC_OSX_OS_NAME;
                }
                else
                {
                    throw new System.PlatformNotSupportedException(string.Format(exceptionFormat, string.Empty));
                }
#endif
            }
            catch
            {
                detectedOs = GetOsNameBackup();
            }

            return detectedOs;
        }


        private string GetOsNameBackup()
        {
            //Using a way posted on this thread http://aka.ms/OSNameCR
            string osName = string.Empty;
            try
            {
                string windir = Environment.GetEnvironmentVariable("windir");
                if (!string.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir))
                {
                    osName = WIN_OS_NAME;
                }
                else if (File.Exists(@"/proc/sys/kernel/ostype"))
                {
                    string osType = File.ReadAllText(@"/proc/sys/kernel/ostype");
                    if (osType != null)
                    {
                        if (osType.StartsWith("Linux", StringComparison.OrdinalIgnoreCase))
                        {
                            osName = LINUX_OS_NAME;
                        }
                    }
                }
                else if (File.Exists(@"/System/Library/CoreServices/SystemVersion.plist"))
                {
                    osName = MAC_OSX_OS_NAME;
                }
            }
            catch { }

            return osName;
        }


        private string GetOsVersionBackup()
        {
            string osVerBackup = string.Empty;
            try
            {
                if (IsOsWindows)
                {
#if FullNetFx
                    string osMajorMinorVersion = ReadHKLMRegistry(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentVersion");
                    string osBuildNumber = ReadHKLMRegistry(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild");
                    string _osVersion = string.Format("{0}.{1}", osMajorMinorVersion, osBuildNumber);
                    Regex pattern = new Regex("[~`!@#$%^&*(),<>?{} ]");
                    osVerBackup = pattern.Replace(_osVersion, "");
#endif
                }
            }
            catch { }

            return osVerBackup;
        }

#if FullNetFx
        /// <summary>
        /// Reads HKLM registry key from the provided path/key combination
        /// </summary>
        /// <param name="path">Path to HKLM key</param>
        /// <param name="key">HKLM key name</param>
        /// <returns>Value for provided HKLM key</returns>
        private string ReadHKLMRegistry(string path, string key)
        {
            string regValue = string.Empty;
            try
            {
                if (IsOsWindows)
                {
                    using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(path))
                    {
                        if (rk != null)
                        {
                            regValue = rk.GetValue(key) as string;
                        }
                    }
                }
            }
            catch { }

            return regValue;
        }
#endif
    }
}
