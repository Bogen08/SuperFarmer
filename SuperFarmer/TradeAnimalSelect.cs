using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SuperFarmer
{
    public partial class TradeAnimalSelect : UserControl
    {
        public event EventHandler TradeAnimalBackButtonPress;
        public event EventHandler TradeAnimalProcess;

        public GroupBox currentPlayerBox;
        public GroupBox otherPlayerBox;
        public GroupBox herdBox;
        public int otherPlayerId;
        public string otherPlayerName;
        public Dictionary<string, int> playerSideOffer;
        public Dictionary<string, int> otherSideOffer;
        Dictionary<string, int> playerSideAnimals;
        Dictionary<string, int> otherSideAnimals;
        Dictionary<string, int> animalValues;
        public TradeAnimalSelect()
        {
            InitializeComponent();
            currentPlayerBox = groupBox1;
            otherPlayerBox = groupBox2;
            animalValues = new Dictionary<string, int>() {
                {"Rabbit", 1},
                {"Sheep", 6},
                {"Pig", 12},
                {"Cow", 36},
                {"Horse", 72},
                {"SmallDog", 6},
                {"BigDog", 36}
            };
            playerSideAnimals = new Dictionary<string, int>() {
                {"Rabbit", 0},
                {"Sheep", 0},
                {"Pig", 0},
                {"Cow", 0},
                {"Horse", 0},
                {"SmallDog", 0},
                {"BigDog", 0}
            };
            otherSideAnimals = new Dictionary<string, int>() {
                {"Rabbit", 0},
                {"Sheep", 0},
                {"Pig", 0},
                {"Cow", 0},
                {"Horse", 0},
                {"SmallDog", 0},
                {"BigDog", 0}
            };
            playerSideOffer = new Dictionary<string, int>() {
                {"Rabbit", 0},
                {"Sheep", 0},
                {"Pig", 0},
                {"Cow", 0},
                {"Horse", 0},
                {"SmallDog", 0},
                {"BigDog", 0}
            };
            otherSideOffer = new Dictionary<string, int>() {
                {"Rabbit", 0},
                {"Sheep", 0},
                {"Pig", 0},
                {"Cow", 0},
                {"Horse", 0},
                {"SmallDog", 0},
                {"BigDog", 0}
            };
        }
        public void SetupTradeWithHerd(string CurrentPlayer, Dictionary<string, int> currentPlayerAnimals, Dictionary<string, int> herdAnimals)
        {
            Label[] playerAnimalCounts = new Label[7] { p1RabbitsCount, p1SheepCount, p1PigCount, p1CowCount, p1HorsesCount, p1SmallDogsCount, p1BigDogsCount };
            Label[] herdAnimalCounts = new Label[7] { p2RabbitsCount, p2SheepCount, p2PigCount, p2CowCount, p2HorsesCount, p2SmallDogsCount, p2BigDogsCount };

            int i = 0;
            foreach (KeyValuePair<string, int> pair in herdAnimals)
            {
                herdAnimalCounts[i].Text = pair.Value.ToString();
                i++;
            }
            i = 0;
            foreach (KeyValuePair<string, int> pair in currentPlayerAnimals)
            {
                playerAnimalCounts[i].Text = pair.Value.ToString();
                i++;
            }
            playerSideAnimals = currentPlayerAnimals;
            otherSideAnimals = herdAnimals;
            currentPlayerBox.Text = ("Player " + CurrentPlayer + " animals");
            otherPlayerBox.Text = ("Main herd animals");
            otherPlayerId = -1;
        }
        public void SetupTradeWithOtherPlayer(string CurrentPlayer, Dictionary<string, int> currentPlayerAnimals, int otherTraderId, string otherTraderName, Dictionary<string, int> otherTraderAnimals)
        {
            Label[] playerAnimalCounts = new Label[7] { p1RabbitsCount, p1SheepCount, p1PigCount, p1CowCount, p1HorsesCount, p1SmallDogsCount, p1BigDogsCount };
            Label[] otherPlayerAnimalCounts = new Label[7] { p2RabbitsCount, p2SheepCount, p2PigCount, p2CowCount, p2HorsesCount, p2SmallDogsCount, p2BigDogsCount };

            int i = 0;
            foreach (KeyValuePair<string, int> pair in currentPlayerAnimals)
            {
                playerAnimalCounts[i].Text = pair.Value.ToString();
                i++;
            }
            i = 0;
            foreach (KeyValuePair<string, int> pair in otherTraderAnimals)
            {
                otherPlayerAnimalCounts[i].Text = pair.Value.ToString();
                i++;
            }

            playerSideAnimals = currentPlayerAnimals;
            otherSideAnimals = otherTraderAnimals;
            currentPlayerBox.Text = ("Player " + CurrentPlayer + " animals");
            otherPlayerBox.Text = ("Player " + otherTraderName + " animals");
            otherPlayerId = otherTraderId;
            otherPlayerName = otherTraderName;
        }
        public void getInputTradeOffer()
        {
            playerSideOffer["Rabbit"] = RabbitsT1.Text.ParseInt();
            playerSideOffer["Sheep"] = SheepT1.Text.ParseInt();
            playerSideOffer["Pig"] = PigsT1.Text.ParseInt();
            playerSideOffer["Cow"] = CowsT1.Text.ParseInt();
            playerSideOffer["Horse"] = HorsesT1.Text.ParseInt();
            playerSideOffer["SmallDog"] = SmallDogsT1.Text.ParseInt();
            playerSideOffer["BigDog"] = BigDogsT1.Text.ParseInt();
            otherSideOffer["Rabbit"] = RabbitsT2.Text.ParseInt();
            otherSideOffer["Sheep"] = SheepT2.Text.ParseInt();
            otherSideOffer["Pig"] = PigsT2.Text.ParseInt();
            otherSideOffer["Cow"] = CowsT2.Text.ParseInt();
            otherSideOffer["Horse"] = HorsesT2.Text.ParseInt();
            otherSideOffer["SmallDog"] = SmallDogsT2.Text.ParseInt();
            otherSideOffer["BigDog"] = BigDogsT2.Text.ParseInt();
        }
        public NumericUpDown[] GetAllNumericUpDowns()
        {
            List<NumericUpDown> numericUpDowns = new List<NumericUpDown>();
            GetNumericUpDowns(this, numericUpDowns);
            return numericUpDowns.ToArray();
        }

        private void GetNumericUpDowns(Control parent, List<NumericUpDown> list)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is NumericUpDown numericUpDown)
                {
                    list.Add(numericUpDown);
                }
                if (control.HasChildren)
                {
                    GetNumericUpDowns(control, list);
                }
            }
        }
        public void resetCounters()
        {
            NumericUpDown[] Counters = GetAllNumericUpDowns();
            foreach (NumericUpDown counter in Counters)
            {
                counter.Value = 0;
            }
        }

        protected virtual void OnTradeAnimalBackButtonPressed(EventArgs e)
        {
            TradeAnimalBackButtonPress?.Invoke(this, e);
        }
        protected virtual void OnTradeAnimalProccesing(EventArgs e)
        {
            TradeAnimalProcess?.Invoke(this, e);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            resetCounters();
            OnTradeAnimalBackButtonPressed(EventArgs.Empty);
        }

        private void tradeButton_Click(object sender, EventArgs e)
        {
            getInputTradeOffer();
            int a = 0;
            int b = 0;
            foreach (KeyValuePair<string, int> pair in playerSideOffer)
            {
                a += pair.Value;
            }
            foreach (KeyValuePair<string, int> pair in otherSideOffer)
            {
                b += pair.Value;
            }

            if (a != 1 && b != 1)
            {
                MessageBox.Show("Invalid Trade Offer");
                resetCounters();
                return;
            }

            a = 0;
            b = 0;
            foreach (KeyValuePair<string, int> pair in playerSideOffer)
            {
                a += pair.Value*animalValues[pair.Key];
            }
            foreach (KeyValuePair<string, int> pair in otherSideOffer)
            {
                b += pair.Value * animalValues[pair.Key];
            }

            if (a != b)
            {
                MessageBox.Show("Unequal Trade Offer");
                resetCounters();
                return;
            }

            int check = 0;

            foreach (KeyValuePair<string, int> pair in playerSideOffer)
            {
                if (playerSideOffer[pair.Key] > playerSideAnimals[pair.Key])
                {
                    check++;
                }
            }
            if (check > 0)
            {
                MessageBox.Show("You don't have enought animals");
                resetCounters();
                return;
            }

            check = 0;

            foreach (KeyValuePair<string, int> pair in otherSideAnimals)
            {
                if (otherSideOffer[pair.Key] > otherSideAnimals[pair.Key])
                {
                    otherSideOffer[pair.Key] = otherSideAnimals[pair.Key];
                    check++;
                }
            }
            if (check > 0)
                if (otherPlayerId == -1)
                {
                    DialogResult dialogResult = MessageBox.Show("The main herd does not have enougth animals, do you want to continue?", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Trade Cancelled");
                        resetCounters();
                        return;
                    }
                    
                }
                else
                {
                    MessageBox.Show("The other player doesn't have enougth animals");
                    resetCounters();
                    return;
                }

            if(otherPlayerId != -1)
            {
                DialogResult dialogResult = MessageBox.Show( "Does player "+otherPlayerName+" accept the trade?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Trade Cancelled");
                    resetCounters();
                    return;
                }
            }
                OnTradeAnimalProccesing(EventArgs.Empty);

        }
    }
}
