using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperFarmer
{
    public partial class GameControls : UserControl
    {
        public DataGridView DataGrid;
        public event EventHandler ControlsRollButtonPress;
        public event EventHandler ControlsCheckButtonPress;
        public event EventHandler ControlsTradeButtonPress;
        public GameControls()
        {
            InitializeComponent();
            
        }
        public void LoadData(string playerName, Dictionary<string, int> animals, bool traded)
        {
            playerLabel.Text = ("Player "+playerName+" turn");
            playerRabbitCount.Text = animals["Rabbit"].ToString();
            playerSheepCount.Text = animals["Sheep"].ToString();
            playerPigsCount.Text = animals["Pig"].ToString();
            playerCowsCount.Text = animals["Cow"].ToString();
            playerHorsesCount.Text = animals["Horse"].ToString();
            playerSmallDogsCount.Text = animals["SmallDog"].ToString();
            playerBigDogsCount.Text = animals["BigDog"].ToString();

            if (traded)
                tradeButton.Enabled = false;
            else
                tradeButton.Enabled = true;
        }

        protected virtual void OnControllsRollButtonPressed(EventArgs e)
        {
            ControlsRollButtonPress?.Invoke(this, e);
        }
        protected virtual void OnControllsCheckButtonPressed(EventArgs e)
        {
            ControlsCheckButtonPress?.Invoke(this, e);
        }
        protected virtual void OnControllsTradeButtonPressed(EventArgs e)
        {
            ControlsTradeButtonPress?.Invoke(this, e);
        }

        private void rollButton_Click(object sender, EventArgs e)
        {
            OnControllsRollButtonPressed(EventArgs.Empty);
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            OnControllsCheckButtonPressed(EventArgs.Empty);
        }

        private void tradeButton_Click(object sender, EventArgs e)
        {
            OnControllsTradeButtonPressed(EventArgs.Empty);
        }
    }
}
