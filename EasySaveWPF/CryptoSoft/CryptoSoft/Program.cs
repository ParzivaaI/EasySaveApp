using CryptoSoft;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace CryptoSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path du chemin à copier
            string sourceFilePath = "";

            // Path du chemin où faire la copie
            string destFilePath = "";

            // Clé de cryptage
            string key;

            //Clé au format tableau
            byte[] keyInBytes = new byte[0];

            //Création du timer pour le temps d'encryption
            Stopwatch timer = new Stopwatch();

            // Chemin de la clé et du fichier de configuration
            string configFolderPath = Path.GetFullPath(@"Config");
            string cryptoKeyPath = Path.GetFullPath(@"Config\cryptoKey.txt");

            // chemin du fichier json de config de EasySave
            string configFilePath = Path.GetFullPath(@"Config\config.json");
            ConfigFileJson configFileJson;
            string Data;

            configFileJson = new ConfigFileJson();
            //Lire le fichier avec la clé, le créer avec une clé aléatoire si il n'existe pas
            try
            {
                if (File.Exists(configFilePath))
                {
                    Data = File.ReadAllText(configFilePath);

                    configFileJson = JsonConvert.DeserializeObject<ConfigFileJson>(Data);

                    key = configFileJson.cryptoKey;
                }
                else
                {
                    key = File.ReadAllText(cryptoKeyPath);
                }
            }
            catch (Exception)
            {
                // Créer l'instance où stocker la clé
                StringBuilder strbuilder = new StringBuilder();
                Random random = new Random();

                for (int i = 0; i < 64; i++)
                {
                    // Créer un nombre aléatoire
                    double myFloat = random.NextDouble();
                    var myChar = Convert.ToChar(Convert.ToInt32(Math.Floor(25 * myFloat) + 65));
                    strbuilder.Append(myChar);
                }

                key = strbuilder.ToString();

                //Créer le dossier si il n'existe pas
                Directory.CreateDirectory(configFolderPath);

                //Créer le fichier dans le dossier avec la clé
                File.WriteAllText(cryptoKeyPath, key);
            }

            if (args[0] == "source")
            {
                sourceFilePath = args[1];
            }
            else
            {
                Environment.Exit(-1);
            }

            if (args[2] == "destination")
            {
                destFilePath = args[3];
            }
            else
            {
                Environment.Exit(-2);
            }

            // Lancer le timer de temps d'encryption
            timer.Start();

            // Mettre la clé dans un tableau
            try
            {
                keyInBytes = Encoding.ASCII.GetBytes(key);

                if (keyInBytes.Length < 64)
                {
                    Environment.Exit(-1);
                }
            }
            catch (Exception)
            {
                Environment.Exit(-3);
            }

            try
            {
                // Cryptage/Decryptage en XOR
                using (FileStream fsOut = new FileStream(destFilePath, FileMode.Create))
                {
                    using (FileStream fsIn = new FileStream(sourceFilePath, FileMode.Open))
                    {
                        int data;
                        int i = 0;

                        while ((data = fsIn.ReadByte()) != -1)
                        {
                            if (i >= key.Length)
                            {
                                i = 0;
                            }

                            byte bitetowrite = (byte)((byte)data ^ (byte)keyInBytes[i]);

                            fsOut.WriteByte(bitetowrite);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Environment.Exit(-4);
            }


            // Arreter le timer et indiquer le temps mis a crypter
            timer.Stop();
            Environment.Exit((int)timer.ElapsedMilliseconds);
        }
    }
}