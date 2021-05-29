using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        //Read from csv file and call api to write result at new text
        public static void CallingApiAndWriteResult()
        {
            try
            {
                string source = "D:\\DemoWebservice";
              
                if (!(Directory.Exists(source)))
                    return;
                string csvData = File.ReadAllText(source);

                //Execute a loop over the rows.  
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        foreach (string cell in row.Split(','))
                        {
                            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("AddRequest", cell).Result;
                           
                            if (response.IsSuccessStatusCode)
                            {
                                var dto = response.Content.ReadAsAsync<ApiResponseDto>().Result;
                                //write mobileNumber in Duplicate.txt
                                if(dto.Status==2)
                                {
                                    string path = @"Path\Duplicate.txt";
                                    if (!File.Exists(path))
                                    {
                                        //create afile to write
                                        using(StreamWriter sw=File.CreateText(path))
                                        {
                                            sw.WriteLine(cell);
                                        }
                                    }
                                }
                                else if(dto.Status ==3)
                                {
                                    string path = @"Path\Failed.txt";
                                    if (!File.Exists(path))
                                    {
                                        //create afile to write
                                        using (StreamWriter sw = File.CreateText(path))
                                        {
                                            sw.WriteLine(cell);
                                        }
                                    }

                                }
                            }
                           
                          
                           
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        protected override void OnStart(string[] args)
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            if (hour == 23 && minute == 59)
            {
                CallingApiAndWriteResult();
            }
        }

        protected override void OnStop()
        {
            Console.WriteLine("Service is Stopped");
        }
      
    }
}
