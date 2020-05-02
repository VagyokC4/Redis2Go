using System;
using System.IO;
using System.Linq;

namespace Redis2Go
{
    public enum RedisTypes
    {
        Redis64,
        Redis32
    }

    public static class RedisTypesExtensions
    {
        private static readonly string CurrentDirectory = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @".nuget\packages\redis2go.alpha\"))
            .GetFileSystemInfos("tools", SearchOption.AllDirectories).OrderByDescending(x => x.LastWriteTimeUtc).First().FullName;

        private static readonly string Redis64 = $@"{CurrentDirectory}\Redis64\";
        private static readonly string Redis32 = $@"{CurrentDirectory}\Redis32\";

        public static string GetBinaryPath( this RedisTypes @this )
        {
            switch ( @this )
            {
                case RedisTypes.Redis64: return Redis64;
                case RedisTypes.Redis32: return Redis32;
                default:                 throw new ArgumentOutOfRangeException();
            }
        }
    }
}
