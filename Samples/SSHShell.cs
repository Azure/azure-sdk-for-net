// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;
using Renci.SshNet;
using System;
using System.IO;

namespace Microsoft.Azure.Management.Samples.Common
{
    public class SSHShell : IDisposable
    {
        const string UBUNTU_HOME_DIRECTORY = "/home/";
        private SshClient sshClient;
        private ScpClient scpClient;
        private string homeDirectory;

        /**
         * Creates SSHShell.
         *
         * @param host the host name
         * @param port the ssh port
         * @param userName the ssh user name
         * @param password the ssh password
         * @return the shell client
         */
        private SSHShell(string host, int port, string userName, string password)
        {
            var backoffTime = 30 * 1000;
            var retryCount = 3;

            while (retryCount > 0)
            {
                try
                {
                    sshClient = new SshClient(host, port, userName, password);
                    sshClient.Connect();
                    scpClient = new ScpClient(host, port, userName, password);
                    scpClient.Connect();
                    homeDirectory = UBUNTU_HOME_DIRECTORY + userName + "/";
                    break;
                }
                catch (Exception exception)
                {
                    retryCount--;
                    if (retryCount == 0)
                    {
                        throw exception;
                    }
                }
                SdkContext.DelayProvider.Delay(backoffTime);
            }
        }

        /**
         * Opens a SSH shell.
         *
         * @param host the host name
         * @param port the ssh port
         * @param userName the ssh user name
         * @param password the ssh password
         * @return the shell client
         */
        public static SSHShell Open(string host, int port, string userName, string password)
        {
            return new SSHShell(host, port, userName, password);
        }

        /**
         * Executes a command on the remote host.
         *
         * @param shell the SSH shell client into which the command will be executed
         * @param commandToExecute the command to be executed
         * @return the content of the remote output from executing the command
         */
        public string ExecuteCommand(string commandToExecute)
        {
            if (sshClient != null)
            {
                using (var command = sshClient.CreateCommand(commandToExecute))
                {
                    return command.Execute();
                }
            }
            else
            {
                return null;
            }
        }

        /**
         * Downloads the content of a file from the remote host as a String.
         *
         * @param fileName the name of the file for which the content will be downloaded
         * @param fromPath the path of the file for which the content will be downloaded
         * @param isUserHomeBased true if the path of the file is relative to the user's home directory
         * @return the content of the file
         */
        public string Download(string fileName, string fromPath, bool isUserHomeBased)
        {
            if (scpClient != null)
            {
                string path = fromPath;
                if (isUserHomeBased)
                {
                    path = homeDirectory + path;
                }

                using (var mstream = new MemoryStream())
                {
                    scpClient.Download(path + "/" + fileName, mstream);
                    mstream.Position = 0;
                    return (new System.IO.StreamReader(mstream)).ReadToEnd();
                }
            }
            else
            {
                return null;
            }
        }

        /**
         * Downloads the content of a file from the remote host as a String.
         *
         * @param fileName the name of the file for which the content will be downloaded
         * @param fromPath the path of the file for which the content will be downloaded
         * @param isUserHomeBased true if the path of the file is relative to the user's home directory
         * @return the content of the file
         */
        public int Download(byte[] destBuff, int maxCount, string fileName, string fromPath, bool isUserHomeBased)
        {
            if (scpClient != null)
            {
                string path = fromPath;
                if (isUserHomeBased)
                {
                    path = homeDirectory + path;
                }

                using (MemoryStream mstream = new MemoryStream())
                {
                    scpClient.Download(path + "/" + fileName, mstream);
                    if (mstream.Position >= maxCount)
                    {
                        return -1;
                    }
                    mstream.Position = 0;
                    return mstream.Read(destBuff, 0, maxCount);
                }
            }
            else
            {
                return -1;
            }
        }

        /**
         * Creates a new file on the remote host using the input content.
         *
         * @param data the byte array content to be uploaded
         * @param fileName the name of the file for which the content will be saved into
         * @param toPath the path of the file for which the content will be saved into
         * @param isUserHomeBased true if the path of the file is relative to the user's home directory
         * @param filePerm file permissions to be set
         */
        public void Upload(byte[] data, string fileName, string toPath, bool isUserHomeBased)
        {
            if (scpClient != null && sshClient != null)
            {
                string path = toPath;
                if (isUserHomeBased)
                {
                    path = homeDirectory + path;
                }

                // Create the directory on the remote host
                using (var command = sshClient.CreateCommand("mkdir -p " + path))
                {
                    command.Execute();
                }

                // Create the file containing the uploaded data
                // byte[] data = System.Text.Encoding.ASCII.GetBytes("");
                using (var mstream = new MemoryStream(data))
                {
                    scpClient.Upload(mstream, path + "/" + fileName);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (sshClient != null)
                {
                    sshClient.Disconnect();
                    sshClient.Dispose();
                }
                if (scpClient != null)
                {
                    scpClient.Disconnect();
                    scpClient.Dispose();
                }
            }
            // free native resources if there are any.
        }
    }
}