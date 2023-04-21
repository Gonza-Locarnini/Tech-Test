using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Sat.Recruitment.Db.Models
{
    internal static class ProjectSource
    {
        private static string CallerFilePath([CallerFilePath] string? callerFilePath = null) =>
            callerFilePath ?? throw new ArgumentNullException(nameof(callerFilePath));

        public static string ProjectDirectory() => Path.GetDirectoryName(CallerFilePath())!;
    }
}
