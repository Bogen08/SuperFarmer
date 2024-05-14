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
    public partial class GameSettings : UserControl
    {
        public NumericUpDown playerCounter;

        public event EventHandler GameSettingsStartButtonPress;
        public GameSettings()
        {
            InitializeComponent();
            playerCounter = GameSettingsPlayerCounter;
        }

        protected virtual void OnGameSettingsStartButtonPressed(EventArgs e)
        {
            GameSettingsStartButtonPress?.Invoke(this, e);
        }

        private void GameSettingsStartButton_Click(object sender, EventArgs e)
        {
            OnGameSettingsStartButtonPressed(EventArgs.Empty);
        }
    }
}
