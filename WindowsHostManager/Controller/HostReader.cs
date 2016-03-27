using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WindowsHostManager.Model;

namespace WindowsHostManager.Controller
{
    public class HostReader
    {
        static private string getSystemHostPath()
        {
            string host_dir = Environment.SystemDirectory;
            host_dir = System.IO.Path.Combine(host_dir, @"drivers\etc\hosts");
            if (System.IO.File.Exists(host_dir))
            {
                return host_dir;
            }
            throw new System.IO.FileNotFoundException(host_dir);
        }

        static private string getHostPattern()
        {
            string ip = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
            string host = @"\b\S+\b";
            string comment = @".+";

            var sb = new StringBuilder();

            sb.AppendFormat(@"({0})\s+({1})[\s#]*({2})?",
                new string[] { ip, host, comment });

            return sb.ToString();
        }

        static private async Task<ObservableCollection<Model.HostItem>>
            readHostFileAsync(string host_path)
        {
            string lines = null;

            using (var freader = new System.IO.StreamReader(host_path))
            {

                if (freader.Peek() >= 0)
                {
                    lines = await freader.ReadToEndAsync();
                }

                if (lines == null
                    || (lines.Length == 0))
                {
                    throw new System.IO.IOException();
                }

            }

            using (var sreader = new System.IO.StringReader(lines))
            {
                var pattern = new Regex(getHostPattern(), RegexOptions.Compiled);
                var collections = new ObservableCollection<Model.HostItem>();

                while (sreader.Peek() >= 0)
                {
                    string line = sreader.ReadLine();
                    line.Trim();

                    var result = pattern.Match(line);
                    if (result.Success)
                    {
                        var item = new Model.HostItem()
                        {
                            Activated = !line.StartsWith("#"),
                            IP = result.Groups[1].Value,
                            Host = result.Groups[2].Value,
                            Comment = result.Groups[3].Value,
                            GroupName = WindowsHostManager.Properties.Resources.LocalGroupName
                        };
                        collections.Add(item);
                    }
                }
                return collections;
            }
        }

        static public ObservableCollection<Model.HostItem> ReadHostFile(string host_path)
        {
            try
            {
                ObservableCollection<Model.HostItem> items = null;
                Task.Run(async () => items = await readHostFileAsync(host_path)).Wait();
                return items;
                
            }
            catch (Exception exp)
            when (
                exp is System.IO.IOException
                || exp is UnauthorizedAccessException)
            {
                throw new System.IO.IOException(exp.Message);
            }
        }

        static public async Task<ObservableCollection<Model.HostItem>>
            ReadHostFileAsync(string host_path)
        {
            try
            {
                return await readHostFileAsync(host_path);
            }
            catch (Exception exp)
            when (
                exp is System.IO.IOException
                || exp is UnauthorizedAccessException)
            {
                throw new System.IO.IOException(exp.Message);
            }
        }

        static public ObservableCollection<Model.HostItem> ReadSystemHostFile()
        {
            string host_path = getSystemHostPath();
            return ReadHostFile(host_path);
        }

        static public async Task<ObservableCollection<Model.HostItem>>
            ReadSystemHostFileAsync()
        {
            string host_path = getSystemHostPath();
            return await ReadHostFileAsync(host_path);
        }

    }
}
