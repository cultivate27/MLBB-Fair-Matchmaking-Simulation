using System;
using System.Collections.Generic;

namespace Matchmaking_Scheme;

public static class Program
{
    class Player
    {
        public int identificator;
        public int theHighest;
        public int order;

        public Player()
        {
            Highest();
        }

        static Random random = new Random();

        //Maksimal match terakhir yang dapat direkam paling banyak adalah 50
        int mid = random.Next(1, 50); // Acak antara 1 sampai 50
        int exp = random.Next(1, 50); // Acak antara 1 sampai 50
        int roam = random.Next(1, 50); // Acak antara 1 sampai 50
        int jungle = random.Next(1, 50); // Acak antara 1 sampai 50
        int gold = random.Next(1, 50); // Acak antara 1 sampai 50

        // Midlane = 1
        // Explane = 2
        // Roam = 3
        // Jungle = 4
        // Goldlane = 5 

        public int Highest()
        {
            theHighest = (((mid > exp) ? mid : exp) > ((roam > jungle) ? roam : jungle)) ? ((mid > exp) ? mid : exp) : ((roam > jungle) ? roam : jungle);
            theHighest = (theHighest > gold) ? theHighest : gold;

            //Console.WriteLine(theHighest); //DEBUG

            if (theHighest == mid)
                return identificator = 1 ;

            else if (theHighest == exp)
                return identificator = 2;

            else if (theHighest == roam)
                return identificator = 3;

            else if (theHighest == jungle)
                return identificator = 4;

            else if (theHighest == gold)
                return identificator = 5;
            
            return theHighest;
        }
    }

    static void Fetching(List<Player> listObject)
    {
        Dictionary<int, List<Player>> angkaSamaMap = new Dictionary<int, List<Player>>();

        // Mengelompokkan objek-objek dengan nilai yang sama
        foreach (var imObject in listObject)
        {
            int nilai = imObject.identificator;
            
            if (!angkaSamaMap.ContainsKey(nilai)) //Jika key nilai belum ditambahkan ke dictionary sebelumnya
            {
                angkaSamaMap.Add(nilai, new List<Player>()); //Maka buatkan keynya berisi value list kosong
            }

            angkaSamaMap[nilai].Add(imObject); //Mengisi value dengan imObject yang memiliki nilai identificator yang sama
 
            //DEBUG
            //Console.WriteLine("imObject Identificator: ");
            //Console.WriteLine(imObject.identificator);
            //Console.WriteLine();
        }

        List<Player> listObjekWakil = new List<Player>();

        // Memilih satu wakil dari setiap objek dengan angka identificator yang sama secara acak
        foreach (var pair in angkaSamaMap)
        {
            int indexWakil = new Random().Next(pair.Value.Count); // Misal muncul 6 kali berarti 1 sampai 6
            Player objekWakil = pair.Value[indexWakil]; // pair.Value[hasilRandom dari 1 sampai 6]
            listObjekWakil.Add(objekWakil);

            //DEBUG
            //Console.WriteLine("Pair Key: " + pair.Key); //Key = nilainya
            //Console.WriteLine("Pair value: " + pair.Value.Count); //Value.Count = berapa kali muncul nilainya
            //Console.WriteLine(indexWakil);
        }

        if (listObjekWakil.Count < 5) //Mengecek apakah teradapat 5 role yang saling melengkapi
        {
            int sumLOW = 0;
            foreach (var playerx in listObjekWakil)
            {
                sumLOW += playerx.identificator; // Total 1(Midlaner) + 2(Explaner) + 3(Roamer) + 4(Jungler) + 5(Goldlaner) = 15
            }
            
            if (sumLOW == 10) // Jika 10 maka kurang 5 (Goldlaner)
            {
                Console.Clear();
                Console.WriteLine("Tidak ditemukan player Goldlaner");
                Restart();
            }

            else if (sumLOW == 11) // Jika 11 maka kurang 4 (Jungler)
            {
                Console.Clear();
                Console.WriteLine("Tidak ditemukan player Explaner");
                Restart();
            }

            else if (sumLOW == 12) // Jika 12 maka kurang 3 (Roamer)
            {
                Console.Clear();
                Console.WriteLine("Tidak ditemukan player Jungler");
                Restart();
            }

            else if (sumLOW == 13) // Jika 13 maka kurang 2 (Explaner)
            {
                Console.Clear();
                Console.WriteLine("Tidak ditemukan player Roamer");
                Restart();
            }

            else if (sumLOW == 14) // Jika 14 maka kurang 1 (Midlaner)
            {
                Console.Clear();
                Console.WriteLine("Tidak ditemukan player Midlaner");
                Restart();
            }

            else // Fail-safe
            {
                Console.Clear();
                Console.WriteLine("Tidak ditemukan role yang saling melengkapi");
                Restart();
            }

        }

        int slotCounter = 1;
        foreach (var player in listObjekWakil)
        {
            // Mengakses properti identificator dari objek Player
            Console.WriteLine("Player - " + player.order + " (Slot " + slotCounter + ")");
            Console.WriteLine("Debug Player Identificator: " + player.identificator);

            if (player.identificator == 1)
            {
                Console.WriteLine("Midlaner " + player.theHighest + " Match");
            }

            else if (player.identificator == 2)
            {
                Console.WriteLine("Explaner " + player.theHighest + " Match");
            }

            else if (player.identificator == 3)
            {
                Console.WriteLine("Roamer " + player.theHighest + " Match");
            }

            else if (player.identificator == 4)
            {
                Console.WriteLine("Jungler " + player.theHighest + " Match");
            }

            else if (player.identificator == 5)
            {
                Console.WriteLine("Goldlaner " + player.theHighest + " Match");
            }


            slotCounter++;
            Console.WriteLine();
        }

        int sisa = listObject.Count - listObjekWakil.Count;
        Console.WriteLine("Sisa player yang belum mendapatkan pasangan dan akan melanjutkan matchmaking: " + sisa);
    }

    static void Start()
    {
        // Membuat list untuk object Player
        List<Player> objects = new List<Player>();

        Random random = new Random();
        // Mengisi list Player dengan random. Minimal 15 dan Maksimal 20 objek.
        for (int i = 0; i < random.Next(15, 30); i++)
        {
            //Console.WriteLine($"Player {i + 1} :"); //DEBUG
            objects.Add(new Player());
            objects[i].order = i + 1; //Agar bisa disusun dan diketahui urutan playernya
        }

        Fetching(objects);

        Console.WriteLine();
    }

    public static void Restart()
    {
        string input;
        do
        {
            Console.WriteLine("Ingin mengulang matchmaking? [y] / [n]");
            input = Console.ReadLine();
            input.ToLower();

            if (input == "y")
            {
                Console.Clear();
                Start();
                Restart();
            }

            else if (input == "n")
            {
                Environment.Exit(0);
            }

        } while (input != "y" && input != "n");
    }

    public static void Main()
    {
        /*
        //15 Random Player Sample
        Player playerOne = new Player();
        Player playerTwo = new Player();
        Player playerThree = new Player();
        Player playerFour = new Player();
        Player playerFive = new Player();
        Player playerSix = new Player();
        Player playerSeven = new Player();
        Player playerEight = new Player();
        Player playerNine = new Player();
        Player playerTen = new Player();
        Player playerEleven = new Player();
        Player playerTwelve = new Player();
        Player playerThirteen = new Player();
        Player playerFourteen = new Player();
        Player playerFifteen = new Player();
        */

        Console.Title = "Matchmaking Simulation";
        Start();
        Restart();

        Console.WriteLine();
    }  
}