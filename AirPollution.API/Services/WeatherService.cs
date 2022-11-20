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
            Thread.Sleep(1000);
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
            //var x = Convert.ToDouble(coefs[0]);
            for (int i = 0; i < weather.Count; i++)
            {
                var pollution = a + b * weather[i].Temperature + c * weather[i].Humidity +
                   d * weather[i].WindSpeed + e * weather[i].Pressure + f * weather[i].Temperature * weather[i].Temperature +
                   g * weather[i].Temperature * weather[i].Humidity + h * weather[i].Temperature * weather[i].WindSpeed +
                   ij * weather[i].Temperature * weather[i].Pressure + j * weather[i].Humidity * weather[i].Humidity +
                   k * weather[i].Humidity * weather[i].WindSpeed + l * weather[i].Humidity * weather[i].Pressure +
                   m * weather[i].WindSpeed * weather[i].WindSpeed + n * weather[i].WindSpeed * weather[i].Pressure +
                   o * weather[i].Pressure * weather[i].Pressure;
                //var pollution2 = 5024.301412231013 - 7.339425651482356 * weather[i].Temperature + 10.263605859685386 * weather[i].Humidity +
                //   2.0820297529109673 * weather[i].WindSpeed - 10.855031734371348 * weather[i].Pressure + 0.03213986421118295 * weather[i].Temperature * weather[i].Temperature -
                //   0.025099344879074614 * weather[i].Temperature * weather[i].Humidity + 0.06681425395830656 * weather[i].Temperature * weather[i].WindSpeed +
                //   0.006129988781735207 * weather[i].Temperature * weather[i].Pressure + 0.005267615168560225 * weather[i].Humidity * weather[i].Humidity -
                //   0.011370299638924747 * weather[i].Humidity * weather[i].WindSpeed - 0.010215669240611014 * weather[i].Humidity * weather[i].Pressure +
                //   0.02217828630041639 * weather[i].WindSpeed * weather[i].WindSpeed - 0.0034355757843065327 * weather[i].WindSpeed * weather[i].Pressure +
                //   0.005861825184940717 * weather[i].Pressure * weather[i].Pressure;
                weather[i].AirPollution = Math.Round(pollution, 2);

            }

            return weather;
        }

        private List<string> ReadFromCsv()
        {
            List<string> listA = new List<string>();
            using (var reader = new StreamReader(@"C:\Users\1234\OneDrive\Praca inżynierska\Apka Pytong\coefs.csv"))
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
            string navigate = @"C:\\Users\\1234\\OneDrive\\Praca inżynierska\\Apka Pytong";
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.WorkingDirectory = navigate;
            ps.FileName = "cmd.exe";
            ps.Arguments = "/C Testy_PythonNet.exe";
            //ps.CreateNoWindow = true;
            Process.Start(ps);

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
