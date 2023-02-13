using AirPollution.API.Models;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Python.Runtime;

namespace AirPollution.API.Services
{
    public class WeatherService : IWeatherService
    {

        public List<Weather> ProcesWeather(List<Weather> weather)
        {

            RunPython();
            
            List<string> coefs = new List<string>();
            coefs = ReadFromCsv();
            var format = new NumberFormatInfo();
            format.NegativeSign = "-";
            format.NumberDecimalSeparator = ".";

            var a = Double.Parse(coefs[0], format);
            var b = Double.Parse(coefs[1], format);
            var c = Double.Parse(coefs[2], format);
            var d = Double.Parse(coefs[3], format);
            var e = Double.Parse(coefs[4], format);
            var f = Double.Parse(coefs[5], format);
            var g = Double.Parse(coefs[6], format);
            var h = Double.Parse(coefs[7], format);
            var ij = Double.Parse(coefs[8], format);
            var j = Double.Parse(coefs[9], format);
            var k = Double.Parse(coefs[10], format);
            var l = Double.Parse(coefs[11], format);
            var m = Double.Parse(coefs[12], format);
            var n = Double.Parse(coefs[13], format);
            var o = Double.Parse(coefs[14], format);
            for (int i = 0; i < weather.Count; i++)
            {
                var pollution = a + b * weather[i].Temperature + c * weather[i].Humidity +
                   d * weather[i].WindSpeed + e * weather[i].Pressure + f * weather[i].Temperature * weather[i].Temperature +
                   g * weather[i].Temperature * weather[i].Humidity + h * weather[i].Temperature * weather[i].WindSpeed +
                   ij * weather[i].Temperature * weather[i].Pressure + j * weather[i].Humidity * weather[i].Humidity +
                   k * weather[i].Humidity * weather[i].WindSpeed + l * weather[i].Humidity * weather[i].Pressure +
                   m * weather[i].WindSpeed * weather[i].WindSpeed + n * weather[i].WindSpeed * weather[i].Pressure +
                   o * weather[i].Pressure * weather[i].Pressure;
                weather[i].AirPollution = Math.Round(pollution, 2);

            }

            return weather;
        }

        private List<string> ReadFromCsv()
        {
            List<string> listA = new List<string>();
            using (var reader = new StreamReader(@"coefs.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('\n');

                    for (int i = 0; i < values.Length; i++)
                    {
                        listA.Add(values[i]);
                    }

                }
            }
            return listA;
        }

        private void RunPython()
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.WorkingDirectory = Directory.GetCurrentDirectory();
            ps.FileName = "cmd.exe";
            ps.Arguments = "/C PythonNet.exe";
            Process run = Process.Start(ps);
            Thread.Sleep(1000);
            run.Kill();


        }
            

            


            // @"C:\Users\1234\OneDrive\Praca inżynierska\Model kopia\python.exe airPollutionScript.py"
            //System.Diagnostics.Process.Start("CMD.exe", @"C:\Python39\python.exe C:\Users\1234\Downloads\airPollutionScript.py");
            //Process p = new Process();
            //p.StartInfo.FileName = "C:\\Windows\\system32\\cmd.exe";
            //p.StartInfo.WorkingDirectory = @"C:\Users\1234\OneDrive\Praca inżynierska\Model kopia";
            //p.StartInfo.Arguments = "airPollutionScript.py";
            //p.Start();

            //p.WaitForExit();

            //string fileName = @"C:\Users\1234\OneDrive\Praca inżynierska\Model kopia\airPollutionScript.py";

            //Process p = new Process();
            //p.StartInfo = new ProcessStartInfo(@"C:\Python39\python.exe", fileName)
            //{
            //    RedirectStandardOutput = true,
            //    UseShellExecute = false,
            //    CreateNoWindow = true
            //};
            //p.Start();

            //p.WaitForExit();
            //var engine = Python.CreateEngine();
            //var scope = engine.CreateScope();
            //string dir = @"C:\Python39\Lib\site-packages";
            //var paths = engine.GetSearchPaths();
            //var libs = new[] { "C:\\Python39\\Lib\\site-packages",
            //                "C:\\Python39\\Lib\\Lib",
            //                "C:\\Python39\\Lib\\DLLs",
            //                "C:\\Python39\\Lib\\Lib",
            //                "C:\\Python39"
            //};
            //paths.Add("C:\\Python39\\Lib\\site-packages");
            //paths.Add("C:\\Python39\\Lib");
            //paths.Add("C:\\Python39\\DLLs");
            //paths.Add("C:\\Python39");


            //////var libs = new[] {
            //////        //"C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\Common7\\IDE\\Extensions\\Microsoft\\Python Tools for Visual Studio\\2.2",
            //////        //C:\Program Files\IronPython 2.7\Lib
            //////        "C:\\Program File\\IronPython 2.7\\Lib",
            //////        "C:\\Program Files\\IronPython 2.7\\DLLs",
            //////        "C:\\Program Files\\IronPython 2.7",
            //////        "C:\\Program Files\\IronPython 2.7\\lib\\site-packages"
            //////    };
            //engine.SetSearchPaths(paths);
            //engine.ExecuteFile(@"C:\Users\1234\OneDrive\Praca inżynierska\Model kopia\airPollutionScript.py", scope);}
        
    }



}
