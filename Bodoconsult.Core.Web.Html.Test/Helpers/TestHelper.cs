﻿using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Bodoconsult.Core.Web.Html.Test.Helpers
{
    public static class TestHelper
    {
        private static string _testDataPath;

        public static string TestDataPath
        {
            get
            {

                if (!string.IsNullOrEmpty(_testDataPath)) return _testDataPath;

                var path = new DirectoryInfo(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName).Parent.Parent.Parent.FullName;

                _testDataPath = Path.Combine(path, "TestData");

                if (!Directory.Exists(_testDataPath)) Directory.CreateDirectory(_testDataPath);

                return _testDataPath;
            }
        }

        /// <summary>
        /// Start an app by file name
        /// </summary>
        /// <param name="fileName"></param>
        public static void StartFile(string fileName)
        {

            if (!Debugger.IsAttached) return;

            Assert.IsTrue(File.Exists(fileName));

            var p = new Process {StartInfo = new ProcessStartInfo {UseShellExecute = true, FileName = fileName}};

            p.Start();

        }




        public static DataTable GetDataTable(string fileName)
        {
            var path = Path.Combine(TestHelper.TestDataPath, fileName);

            return JsonXmlHelper.GetDataTableFromXml(path);
        }
    }
}