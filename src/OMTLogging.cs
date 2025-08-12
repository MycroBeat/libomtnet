﻿/*
* MIT License
*
* Copyright (c) 2025 Open Media Transport Contributors
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace libomtnet
{
    public class OMTLogging
    {
        private static FileStream logStream;
        private static StreamWriter logWriter;
        private static object lockSync = new object();
        private static Thread loggingThread;
        private static bool threadRunning;
        private static Queue<string> queue = new Queue<string>();
        private static AutoResetEvent readyEvent = new AutoResetEvent(false);
        private static bool initialized = false;

        static OMTLogging()
        {
            loggingThread = new Thread(ProcessLog);
            loggingThread.IsBackground = true;
            threadRunning = true;
            loggingThread.Start();
        }

        private static void SetDefaultLogFilename()
        {
            lock (lockSync)
            {
                initialized = true;
                try
                {
                    string name = GetProcessNameAndId();
                    if (name != null)
                    {
                        string szPath = OMTPlatform.GetInstance().GetStoragePath();
                        if (Directory.Exists(szPath) == false)
                        {
                            Directory.CreateDirectory(szPath);
                        }
                        szPath = szPath + Path.DirectorySeparatorChar + "logs";
                        if (Directory.Exists(szPath) == false)
                        {
                            Directory.CreateDirectory(szPath);
                        }
                        SetFilename(szPath + Path.DirectorySeparatorChar + name + ".log");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private static string GetProcessNameAndId()
        {
            Process process = Process.GetCurrentProcess();
            if (process != null)
            {
                ProcessModule module = process.MainModule;
                if (module != null) //Some platforms, notably iOS return null
                {
                    return module.ModuleName + process.Id;
                } else
                {
                    return process.Id.ToString();
                }
            }
            return null;
        }

        private static void ProcessLog()
        {
            try
            {
                while (threadRunning)
                {
                    readyEvent.WaitOne();
                    lock (lockSync)
                    {
                        if (logWriter != null)
                        {
                            while (queue.Count > 0)
                            {
                                logWriter.WriteLine(queue.Dequeue());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString(), "OMTLogging.ProcessLog");
            }
        }

        public static void SetFilename(string filename)
        {
            lock (lockSync)
            {
                initialized = true;
                if (logStream != null)
                {
                    logStream.Close();
                }
                logWriter = null;
                if (!String.IsNullOrEmpty(filename)) {
                    logStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                    logStream.Position = logStream.Length;
                    logWriter = new StreamWriter(logStream);
                    logWriter.AutoFlush = true;
                    OMTLogging.Write("Log Started", "OMTLogging");
                }
            }
        }
        public static void Write(string message, string source)
        {
            try
            {
                string line = DateTime.Now.ToString() + ",[" + source + "]," + message;
                Debug.WriteLine(line);
                lock (lockSync)
                {
                    if (!initialized)
                    {
                        SetDefaultLogFilename();
                    }
                    if (logWriter != null)
                    {
                        queue.Enqueue(line);
                        readyEvent.Set();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
