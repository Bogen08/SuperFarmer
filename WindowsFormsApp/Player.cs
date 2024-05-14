using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    internal class Player
    {
        public string Name;
        public Dictionary<string, int> animals = new Dictionary<string, int>() {
                {"Rabbit", 1},
                {"Sheep", 0},
                {"Pig", 0},
                {"Cow", 0},
                {"Horse", 0},
                {"SmallDog", 0},
                {"BigDog", 0}
            };

        public Player(string playerName)
        {
            Name = playerName;
        }
        public void AnimalTransfer(string animalName, int ammount)
        {
            animals[animalName] += ammount;
        }

        public void printAnimals()
        {
            Console.WriteLine("Player {0} animals:", Name);
            Console.Write("Rabbits: {0} | ", animals["Rabbit"]);
            Console.Write("Sheep: {0} | ", animals["Sheep"]);
            Console.Write("Pigs: {0} | ", animals["Pig"]);
            Console.Write("Cows: {0} | ", animals["Cow"]);
            Console.Write("Horses: {0} | ", animals["Horse"]);
            Console.Write("Small Dogs: {0} | ", animals["SmallDog"]);
            Console.Write("Big Dogs: {0} | ", animals["BigDog"]);
            Console.WriteLine("");
        }
    }
}
