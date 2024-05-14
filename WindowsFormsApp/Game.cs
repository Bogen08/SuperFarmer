using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp
{
    internal class Game
    {
        public Player[] players;
        public Dictionary<string, int> herdAnimals = new Dictionary<string, int>() {
                {"Rabbit", 60},
                {"Sheep", 24},
                {"Pig", 20},
                {"Cow", 12},
                {"Horse", 6},
                {"SmallDog", 4},
                {"BigDog", 2}
            };

        Dictionary<string, int> animalValues = new Dictionary<string, int>() {
                {"Rabbit", 1},
                {"Sheep", 6},
                {"Pig", 12},
                {"Cow", 36},
                {"Horse", 72},
                {"SmallDog", 6},
                {"BigDog", 36}
            };
        public int currentPlayer = 0;
        public bool currentPlayerTraded = false;

        public Game(int numberOfPlayers)
        {
            players = new Player[numberOfPlayers];
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players[i] = null;
            }
            herdAnimals["Rabbit"] -= numberOfPlayers;
        }
        public void AddPlayer(String name)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == null)
                {
                    players[i] = new Player(name);
                    break;
                }
            }
            
        }
        public void PrintAnimalVaules()
        {
            foreach (KeyValuePair<string, int> pair in animalValues)
            {
                Console.WriteLine("{0} = {1}", pair.Key, pair.Value);
            }
        }
        public void AnimalTransfer(int playerId, string animalName, int ammount)
        {
            if (herdAnimals[animalName] < ammount)
            {
                ammount = herdAnimals[animalName];
                Console.WriteLine("Not enought animals in the main herd");
            }
            herdAnimals[animalName] -= ammount;
            players[playerId].AnimalTransfer(animalName, ammount);
        }

        public string WolfAttack(int playerId)
        {
            string result;
            if (players[playerId].animals["BigDog"] > 0)
            {
                result = "Big dog defends against the wolf";
                AnimalTransfer(playerId, "BigDog", -1);
            }
            else
            {
                result = "Wolf attacks!";
                AnimalTransfer(playerId, "Sheep", -players[playerId].animals["Sheep"]);
                AnimalTransfer(playerId, "Pig", -players[playerId].animals["Pig"]);
                AnimalTransfer(playerId, "Cow", -players[playerId].animals["Cow"]);
            }
            return result;
        }
        public string FoxAttack(int playerId)
        {
            string result;
            if (players[playerId].animals["SmallDog"] > 0)
            {
                result = "Small dog defends against the fox";
                AnimalTransfer(playerId, "SmallDog", -1);
            }
            else
            {
                result = "Fox attacks!";
                if (players[playerId].animals["Rabbit"] != 0)
                {
                    AnimalTransfer(playerId, "Rabbit", -(players[playerId].animals["Rabbit"] - 1));
                }
            }
            return result;
        }

        public string AnimalMultiplication(int playerId, string animalName)
        {
            //Console.WriteLine("+ {0} {1}", players[playerId].animals[animalName] / 2, animalName);
            AnimalTransfer(playerId, animalName, players[playerId].animals[animalName] / 2);
            return ("+ "+(players[playerId].animals[animalName]/2)+" "+animalName);
        }

        public void printHerdAnimals()
        {
            Console.WriteLine("Main herd animals:");
            Console.Write("Rabbits: {0} | ", herdAnimals["Rabbit"]);
            Console.Write("Sheep: {0} | ", herdAnimals["Sheep"]);
            Console.Write("Pigs: {0} | ", herdAnimals["Pig"]);
            Console.Write("Cows: {0} | ", herdAnimals["Cow"]);
            Console.Write("Horses: {0} | ", herdAnimals["Horse"]);
            Console.Write("Small Dogs: {0} | ", herdAnimals["SmallDog"]);
            Console.Write("Big Dogs: {0} | ", herdAnimals["BigDog"]);
            Console.WriteLine();
            Console.WriteLine();
        }
        public void printPlayerAnimals()
        {
            foreach (Player p in players)
            {
                p.printAnimals();
                Console.WriteLine();
            }
        }

        public string[] ChandleRolls(int playerId, int a, int b)
        {
            string[] result = new string[3] { "", "", "" };
            if (a < 7)
            {
                result[0] = "Rabbit + ";
                if (b < 7)
                {
                    result[0] += "Rabbit";
                    AnimalTransfer(playerId, "Rabbit", 1);
                    result[1] = "Gained 1 Rabbit";
                    result[2] = AnimalMultiplication(playerId, "Rabbit");
                }
                else if (b < 9)
                {
                    result[0] += "Sheep";
                    result[1] = AnimalMultiplication(playerId, "Rabbit");
                    result[2] = AnimalMultiplication(playerId, "Sheep");
                }
                else if (b < 11)
                {
                    result[0] += "Pig";
                    result[1] = AnimalMultiplication(playerId, "Rabbit");
                    result[2] = AnimalMultiplication(playerId, "Pig");
                }
                else if (b == 11)
                {
                    result[0] += "Horse";
                    result[1] = AnimalMultiplication(playerId, "Rabbit");
                    result[2] = AnimalMultiplication(playerId, "Horse");
                }
                else
                {
                    result[0] += "Fox";
                    result[1] = AnimalMultiplication(playerId, "Rabbit");
                    result[2] = FoxAttack(playerId);
                }
            }
            else if (a < 10)
            {
                result[0] = "Sheep + ";
                if (b < 7)
                {
                    result[0] += "Rabbit";
                    result[1] = AnimalMultiplication(playerId, "Sheep");
                    result[2] = AnimalMultiplication(playerId, "Rabbit");
                }
                else if (b < 9)
                {
                    result[0] += "Sheep";
                    AnimalTransfer(playerId, "Sheep", 1);
                    result[1] = "Gained 1 Sheep";
                    result[2] = AnimalMultiplication(playerId, "Sheep");
                }
                else if (b < 11)
                {
                    result[0] += "Pig";
                    result[1] = AnimalMultiplication(playerId, "Sheep");
                    result[2] = AnimalMultiplication(playerId, "Pig");
                }
                else if (b == 11)
                {
                    result[0] += "Horse";
                    result[1] = AnimalMultiplication(playerId, "Sheep");
                    result[2] = AnimalMultiplication(playerId, "Horse");
                }
                else
                {
                    result[0] += "Fox";
                    result[1] = AnimalMultiplication(playerId, "Sheep");
                    result[2] = FoxAttack(playerId);
                }
            }
            else if (a == 10)
            {
                result[0] = "Pig + ";
                if (b < 7)
                {
                    result[0] += "Rabbit";
                    result[1] = AnimalMultiplication(playerId, "Pig");
                    result[2] = AnimalMultiplication(playerId, "Rabbit");
                }
                else if (b < 9)
                {
                    result[0] += "Sheep";
                    result[1] = AnimalMultiplication(playerId, "Pig");
                    result[2] = AnimalMultiplication(playerId, "Sheep");
                }
                else if (b < 11)
                {
                    result[0] += "Pig";
                    AnimalTransfer(playerId, "Pig", 1);
                    result[1] = "Gained 1 Pig";
                    result[2] = AnimalMultiplication(playerId, "Pig");
                }
                else if (b == 11)
                {
                    result[0] += "Horse";
                    result[1] = AnimalMultiplication(playerId, "Pig");
                    result[2] = AnimalMultiplication(playerId, "Horse");
                }
                else
                {
                    result[0] += "Fox";
                    result[1] = AnimalMultiplication(playerId, "Pig");
                    result[2] = FoxAttack(playerId);
                }
            }
            else if (a == 11)
            {
                result[0] = "Cow + ";
                if (b < 7)
                {
                    result[0] += "Rabbit";
                    result[1] = AnimalMultiplication(playerId, "Cow");
                    result[2] = AnimalMultiplication(playerId, "Rabbit");
                }
                else if (b < 9)
                {
                    result[0] += "Sheep";
                    result[1] = AnimalMultiplication(playerId, "Cow");
                    result[2] = AnimalMultiplication(playerId, "Sheep");
                }
                else if (b < 11)
                {
                    result[0] += "Pig";
                    result[1] = AnimalMultiplication(playerId, "Cow");
                    result[2] = AnimalMultiplication(playerId, "Pig");
                }
                else if (b == 11)
                {
                    result[0] += "Horse";
                    result[1] = AnimalMultiplication(playerId, "Cow");
                    result[2] = AnimalMultiplication(playerId, "Horse");
                }
                else
                {
                    result[0] += "Fox";
                    result[1] = AnimalMultiplication(playerId, "Cow");
                    result[2] = FoxAttack(playerId);
                }
            }
            else
            {
                result[0] = "Wolf + ";
                if (b < 7)
                {
                    result[0] += "Rabbit";
                    result[1] = AnimalMultiplication(playerId, "Rabbit");
                    result[2] = WolfAttack(playerId);
                }
                else if (b < 9)
                {
                    result[0] += "Sheep";
                    result[1] = AnimalMultiplication(playerId, "Sheep");
                    result[2] = WolfAttack(playerId);
                }
                else if (b < 11)
                {
                    result[0] += "Pig";
                    result[1] = AnimalMultiplication(playerId, "Pig");
                    result[2] = WolfAttack(playerId);
                }
                else if (b == 11)
                {
                    result[0] += "Horse";
                    result[1] = AnimalMultiplication(playerId, "Horse");
                    result[2] = WolfAttack(playerId);
                }
                else
                {
                    result[0] += "Fox";
                    result[1] = FoxAttack(playerId);
                    result[2] = WolfAttack(playerId);
                }
            }
            return result;
        }

        public void Trade(int playerId, Dictionary<string, int> playerSideOffer, int otherTraderId, Dictionary<string, int> otherTraderSideOffer)
        {
            if(otherTraderId == -1)
            {
                foreach (KeyValuePair<string, int> pair in playerSideOffer)
                {
                    AnimalTransfer(playerId, pair.Key, -pair.Value);
                }
                foreach (KeyValuePair<string, int> pair in otherTraderSideOffer)
                {
                    AnimalTransfer(playerId, pair.Key, pair.Value);
                }
            }
            else
            {
                foreach (KeyValuePair<string, int> pair in playerSideOffer)
                {
                    AnimalTransfer(playerId, pair.Key, -pair.Value);
                    AnimalTransfer(otherTraderId, pair.Key, pair.Value);
                }
                foreach (KeyValuePair<string, int> pair in otherTraderSideOffer)
                {
                    AnimalTransfer(otherTraderId, pair.Key, -pair.Value);
                    AnimalTransfer(playerId, pair.Key, pair.Value);
                }
            }
            MessageBox.Show("Trade Succesfull");
        }

        public bool CheckVictory(int playerId)
        {
            if (players[playerId].animals["Rabbit"] > 0 && players[playerId].animals["Sheep"] > 0 && players[playerId].animals["Pig"] > 0 && players[playerId].animals["Cow"] > 0 && players[playerId].animals["Horse"] > 0)
            {
                MessageBox.Show("Player " + players[currentPlayer].Name+" has become a SUPER FARMER!");
                if (players.Length > 2)
                {
                    DialogResult dialogResult = MessageBox.Show("\"Do other players wish to continue playing?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Player[] holder = new Player[players.Length - 1];
                        for (int i = 0, j = 0; i < players.Length; i++, j++)
                        {
                            if (i == currentPlayer)
                            {
                                i++;
                                if (i == players.Length)
                                    break;
                            }
                            holder[j] = players[i];
                        }
                        players = new Player[players.Length - 1];

                        for (int i = 0; i < players.Length; i++)
                        {
                            players[i] = holder[i];
                        }
                        holder = null;
                        if (currentPlayer >= players.Length)
                            currentPlayer = 0;
                        return false;
                    }
                    else
                        return true;
                }
                else
                    return true;
            }   
            return false;
        }
    }
}
