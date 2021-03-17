using System;
using System.Diagnostics;

namespace ClassLibrary
{
    public static class ServiceClass
    {
        public static string Hi(string name)
        {
            return $"Привет, {name}";
        }

        public static bool isProcessExist(int processID)
        {
            foreach (var item in Process.GetProcesses())
            {
                if (item.Id == processID)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isProcessExist(string processName)
        {
            foreach (var item in Process.GetProcesses())
            {
                if (item.ProcessName == processName)
                {
                    return true;
                }
            }
            return false;
        }




    }
}
