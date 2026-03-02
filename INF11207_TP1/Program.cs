using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //csv
            string testcsv = "seeds_dataset_test.csv";
            string traincsv = "seeds_dataset_training.csv";

            List<Grain_ble> test = new List<Grain_ble>();
            List<Grain_ble> train = new List<Grain_ble>();

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
            using (var csv = new CsvReader(lecturetrain, config))
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

            IDistance Distance;
            
            AnsiConsole.Write(
                    new Panel("[bold yellow]INTERFACE CLASSIFIEUR K-NN[/]")
                    .Border(BoxBorder.Double)
                    .BorderColor(Color.Green));



            int k = AnsiConsole.Ask<int>("Entrer la valeur de k:");

                while (k <= 0)
                {
                    AnsiConsole.MarkupLine($"[red]impossible[/]");
                    AnsiConsole.MarkupLine($"Veuillez choisir une valeur de k superieure à 0");
                    k = AnsiConsole.Ask<int>("Entrer une autre valeur de k:");

                }

                string choix_distance = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Choisir le distance à implementer")
                    .AddChoices("Distance_Euclidienne", "Distance_Manhattan"));

                AnsiConsole.MarkupLine($"[green]{choix_distance}[/]");
                if (choix_distance == "Distance_euclidienne")
                {
                    Distance = new Distance_euclidienne();
                }
                else
                {
                    Distance = new Distance_manhattan();
                }

            KnnClassifieur knn = new KnnClassifieur(k, Distance, train, new Trie());

            AnsiConsole.Progress()
                    .Start(ctx =>
                    {
                        var task = ctx.AddTask("Classification en cours...", maxValue: test.Count);
                        foreach (var grain in test)
                        {
                            knn.Predire(grain);
                            task.Increment(1);

                        }

                    });

               

            int[,] matrix = new int[3, 3];
            int compteur = 0;
            foreach (var grain in test)
            {
                Variety reelle = grain.variety;
                Variety prediction = knn.Predire(grain);
                if (reelle == prediction)
                {
                    compteur++;
                }
                matrix[(int)reelle, (int)prediction]++;

            }
            double exactitude = Math.Round(((Double)compteur / test.Count) * 100,2);

            string[] Classes = Enum.GetNames(typeof(Variety));

           


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //Console.Write(matrix[i, j] + " ");
                    //Console.WriteLine();

                    //Etat global
                    EtatGlobal etat = new EtatGlobal()
                    {
                        K = k,
                        distance = choix_distance,
                        DateTime = DateTime.Now,
                        TrainCount = train.Count,
                        TestCount = test.Count,
                        Exactitude = exactitude,
                        MatriceConfusion =matrix,

                    };
                    //serialisation

                    string json = JsonConvert.SerializeObject(etat, Formatting.Indented);

                    //sauvegarde
                    File.WriteAllText("etat_global.json", json);

                }
            }
            var table = new Table()
                   .AddColumn("K")
                   .AddColumn("Distance")
                   .AddColumn("Exactitude")
                   .AddRow($"[green]{k}[/]", $"[blue]{choix_distance}[/]", $"[green]{exactitude}%[/]");
            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine($"[green]Matrice de confusion[/]");
            var matrice_confusion = new Table();
            matrice_confusion.AddColumn("reelle/predite");
            matrice_confusion.AddColumn("kama");
            matrice_confusion.AddColumn("rosa");
            matrice_confusion.AddColumn("canadian");

            for (int i = 0; i < 3; i++)
            {

                matrice_confusion.AddRow(Classes[i], matrix[i, 0].ToString(), matrix[i, 1].ToString(), matrix[i, 2].ToString());

            }
            AnsiConsole.Write(matrice_confusion);
            












        }
            
        }
    }
