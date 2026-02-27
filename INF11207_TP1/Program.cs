using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Spectre.Console;
using System.Linq;

using System.Security.Cryptography.X509Certificates;

using System.Runtime.Remoting.Messaging;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace INF11207_TP1
{
    internal class Program
    {
        static void Main(string[] args)

        {//Creation Ferme
            Ferme ferme = new Ferme("Soleil", "50 RUE DANSE LEVIS");
            ferme.Afficher();

            //Creation Fermier
            Fermier fermier = new Fermier(001, "David", "418-524-7521", "fermier@gmail.com");
            //creation des grains
            Grain g1 = new Grain("Rosa", 12, 5, 6, 4, 6, 9);
            Grain g2 = new Grain("Canadian", 12, 9, 5, 8, 6, 3);

            //creer un lot
            LotsGrains lot1 = new LotsGrains(1, DateTime.Now);
            lot1.AjouterGrain(g2);
            lot1.AjouterGrain(g1);
            //Ajouter un lot dans la ferme 
            ferme.AjouterLot(lot1);

            Console.WriteLine($"Quantite de grains = {lot1.CalculerQteGrains()}");

            {


                string testcsv = "C:\\Users\\Channou\\source\\repos\\INF11207_TP1\\INF11207_TP1\\seeds_dataset_test.csv";
                string traincsv = "C:\\Users\\Channou\\source\\repos\\INF11207_TP1\\INF11207_TP1\\seeds_dataset_training.csv";

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
                    new Panel("[bold yellow]CLASSIFIEUR K-NN[/]")
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

                var table = new Table()
                    .AddColumn("K")
                    .AddColumn("Distance")
                    .AddColumn("Exactitude")
                    .AddColumn("Matrice de confusion")
                    .AddRow($"[green]{k}[/]", $"[blue]{choix_distance}[/]", "[green]exactitude[/]", "[blue]matrice[/]");
                AnsiConsole.Write(table);







                //Classes classes = new Classes();










                //for (int i = 0; i < 5; i++)
                //{
                //    Variety prediction = knn.Predire(test[i]);
                //    Console.WriteLine(i + ": " + prediction);
                //    //classes.classe_predite.Add(prediction);
                //    //classes.classe_reelle.Add(test[i].variety);

                //}




            }
        }
    }
}