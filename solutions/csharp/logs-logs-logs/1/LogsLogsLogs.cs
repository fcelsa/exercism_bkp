
    // TODO: define the 'LogLevel' enum
    public enum LogLevel { Unknown = 0, Trace = 1, Debug = 2, Info = 4, Warning = 5, Error = 6, Fatal = 42 };
    static class LogLine
    {
        public static LogLevel ParseLogLevel(string logLine) =>
                logLine switch
                {
                    string s when s.Contains("[TRC]") => LogLevel.Trace,
                    string s when s.Contains("[DBG]") => LogLevel.Debug,
                    string s when s.Contains("[INF]") => LogLevel.Info,
                    string s when s.Contains("[WRN]") => LogLevel.Warning,
                    string s when s.Contains("[ERR]") => LogLevel.Error,
                    string s when s.Contains("[FTL]") => LogLevel.Fatal,
                    _ => LogLevel.Unknown,
                };

        public static string OutputForShortLog(LogLevel logLevel, string message)
        {
            return logLevel switch
            {
                LogLevel.Trace => $"{(int)LogLevel.Trace}:{message}",
                LogLevel.Debug => $"{(int)LogLevel.Debug}:{message}",
                LogLevel.Info => $"{(int)LogLevel.Info}:{message}",
                LogLevel.Warning => $"{(int)LogLevel.Warning}:{message}",
                LogLevel.Error => $"{(int)LogLevel.Error}:{message}",
                LogLevel.Fatal => $"{(int)LogLevel.Fatal}:{message}",
                _ => $"{(int)LogLevel.Unknown}:{message}",
            };
        }
    }