using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string testcsv = "C:\\Users\\Channou\\source\\repos\\INF11207_TP1\\INF11207_TP1\\seeds_dataset_test.csv";
            string traincsv = "C:\\Users\\Channou\\source\\repos\\INF11207_TP1\\INF11207_TP1\\seeds_dataset_training.csv";

            List<Grain_ble>test=new List<Grain_ble>();
            List<Grain_ble>train=new List<Grain_ble>();

            File.Exists(testcsv);
            File.Exists(traincsv);

            

            var isHeader = true;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                MissingFieldFound = null
            };

            using (var lecturetest = new StreamReader(testcsv))
            using (var csv = new CsvReader(lecturetest, config))
            { 


                while (csv.Read())
                {
                    if (isHeader)
                    {
                        csv.ReadHeader();
                        isHeader = false;
                    }
                    else
                    {
                        var recordtest = csv.GetRecord<Grain_ble>();
                        test.Add(recordtest);
                    }
                        
                   
                }
            }


            using (var lecturetrain = new StreamReader(traincsv))
            using (var csv = new CsvReader(lecturetrain,config))
            {
                while (csv.Read())
                {
                    if (isHeader)
                    {
                        csv.ReadHeader();
                        isHeader = false;
                    }
                    else
                    {
                        var recordtrain = csv.GetRecord<Grain_ble>();
                        train.Add(recordtrain);
                    }


                }

            }


 

        }
    }
}
