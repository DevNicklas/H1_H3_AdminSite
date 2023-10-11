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

        /// <summary>
        /// Create an instance of the Log class and sets the file locaiton.
        /// </summary>
        public Log()
        {
            SetLocation();
        }

        /// <summary>
        /// Set the path and name of the log file.
        /// </summary>
        private void SetLocation()
        {
            DateTime currentDate = DateTime.Now;

            _dir = @"C:\Logs";

            if (!Directory.Exists(_dir))
            {
                Directory.CreateDirectory(_dir);
            }

            _path = _dir + @$"\log {currentDate.ToShortDateString()}.txt";
        }

        /// <summary>
        /// get the current time, including miliseconds.
        /// </summary>
        /// <returns></returns>
        private string GetCurrentTime()
        {
            return $"{DateTime.Now.TimeOfDay}.{DateTime.Now.Millisecond}";
        }

        /// <summary>
        /// Logs a verbose message with a timestamp.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Verbose (string message)
        {
            SendMessage($"{GetCurrentTime()}: VERBOSE: {message} ");
        }

        /// <summary>
        /// Logs a debug message with a timestamp.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Debug (string message)
        {
            SendMessage($"{GetCurrentTime()}: DEBUG: {message} ");
        }

        /// <summary>
        /// Logs an information message with a timestamp.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Information (string message)
        {
            SendMessage($"{GetCurrentTime()}: INFORMATION: {message} ");
        }

        /// <summary>
        /// Logs a warning message with a timestamp.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Warning (string message)
        {
            SendMessage($"{GetCurrentTime()}: WARNING: {message} ");
        }

        /// <summary>
        /// Logs an error message with a timestamp.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Error (string message)
        {
            SendMessage($"{GetCurrentTime()}: ERROR: {message} ");
        }

        /// <summary>
        /// Logs a fatal message with a timestamp.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Fatal (string message)
        {
            SendMessage($"{GetCurrentTime()}: FATAL: {message} ");
        }

        /// <summary>
        /// a message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        private void SendMessage (string message)
        {
            File.AppendAllText(_path, message + "\n");
        }
    }
}
