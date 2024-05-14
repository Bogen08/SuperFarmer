using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperFarmer
{
    public partial class DiceRoll : UserControl
    {
        public event EventHandler DiceRollBackButtonPress;
        public event EventHandler DiceRollButtonPress;
        public event EventHandler DiceEndButtonPress;

        public Button rollDiceButton;
        public Button backDiceButton;
        public Button endButton;
        public Label diceResult;
        public Label description;
        public GroupBox groupBox;
        public DiceRoll()
        {
            InitializeComponent();
            rollDiceButton = rollButton;
            backDiceButton = backButton;
            endButton = endTurnButton;
            diceResult = rollLabel;
            description = resultLabel;
            groupBox = groupBox1;
        }

        protected virtual void OnDiceRollBackButtonPressed(EventArgs e)
        {
            DiceRollBackButtonPress?.Invoke(this, e);
        }
        protected virtual void OnDiceRollButtonPressed(EventArgs e)
        {
            DiceRollButtonPress?.Invoke(this, e);
        }
        protected virtual void OnDiceEndButtonPressed(EventArgs e)
        {
            DiceEndButtonPress?.Invoke(this, e);
        }

        public void LoadData(string playerName, Dictionary<string, int> animals, bool traded)
        {
            playerRabbitCount.Text = animals["Rabbit"].ToString();
            playerSheepCount.Text = animals["Sheep"].ToString();
            playerPigsCount.Text = animals["Pig"].ToString();
            playerCowsCount.Text = animals["Cow"].ToString();
            playerHorsesCount.Text = animals["Horse"].ToString();
            playerSmallDogsCount.Text = animals["SmallDog"].ToString();
            playerBigDogsCount.Text = animals["BigDog"].ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            OnDiceRollBackButtonPressed(EventArgs.Empty);
        }

        private void rollButton_Click(object sender, EventArgs e)
        {
            OnDiceRollButtonPressed(EventArgs.Empty);
        }

        private void endTurnButton_Click(object sender, EventArgs e)
        {
            OnDiceEndButtonPressed(EventArgs.Empty);
        }
    }
}
