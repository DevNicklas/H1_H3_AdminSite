using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdminSiteClasses
{
    /// <summary>
    /// The class <c>Log</c> provides methods for logging various types of errors in a text file.
    /// </summary>
    internal class Log
    {
        private string _dir;
        private string _path;

        public Log()
        {
            SetLocation();
        }

        private void SetLocation()
        {
            _dir = @"C:\Logs";

            if (!Directory.Exists(_dir))
            {
                Directory.CreateDirectory(_dir);
            }

            _path = _dir + @$"\log {DateTime.Now}.txt";
        }

        private string GetCurrentTime()
        {
            return $"{DateTime.Now}.{DateTime.Now.Millisecond}";
        }

        public void Verbose (string message)
        {
            SendMessage($"{GetCurrentTime()}: VERBOSE: {message} ");
        }

        public void Debug (string message)
        {
            SendMessage($"{GetCurrentTime()}: DEBUG: {message} ");
        }

        public void Information (string message)
        {
            SendMessage($"{GetCurrentTime()}: INFORMATION: {message} ");
        }

        public void Warning (string message)
        {
            SendMessage($"{GetCurrentTime()}: WARNING: {message} ");
        }

        public void Error (string message)
        {
            SendMessage($"{GetCurrentTime()}: ERROR: {message} ");
        }

        public void Fatal (string message)
        {
            SendMessage($"{GetCurrentTime()}: FATAL: {message} ");
        }

        private void SendMessage (string message)
        {
            File.AppendAllText(_path, message + "\n");
        }
    }
}
