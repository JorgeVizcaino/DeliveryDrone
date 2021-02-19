using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Delivery.Interface;

namespace Delivery.Extension
{
    public class CommandCalculate
    {
        private readonly ICommonClass _commonClass;
        public CommandCalculate()
        {
            _commonClass = new CommonClass();
        }
        public string CalculateRoute(string pathFiles)
        {
            try
            {
                var di = new DirectoryInfo(pathFiles);
                foreach (var fi in di.GetFiles())
                {
                    ProcessDrone(fi.FullName, fi.Directory.ToString());
                }
                return "Process successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        private async Task ProcessDrone(string fileName, string directory)
        {
            var response = new StringBuilder();
            var d = 1;
            using (var streamReader = new StreamReader(fileName, Encoding.UTF8))
            {
                string line;
                var i = 1;
                var step = new Response() { x = 0, y = 0, Move = "Y" };
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (i > 3)
                    {
                        throw new DroneExecption("The maximum lunch is 3");
                    }
                    foreach (var item in line)
                    {
                        step = _commonClass.NextStep(item + step.Move, step.x, step.y);
                    }
                    response.AppendLine(step.x + "," + step.y + "," + step.Move.ToResponse());
                    i++;
                }
            }
            ExportFile(directory, d, response);
            d++;
        }
        private void ExportFile(string mainPath, int droneId, StringBuilder responseRoute)
        {
            File.WriteAllText(mainPath + "\\in" + droneId.ToString().PadLeft(2, '0') + ".txt", responseRoute.ToString());
        }
    }
}
