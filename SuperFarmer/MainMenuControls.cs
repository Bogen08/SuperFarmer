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
    public partial class MainMenuControls : UserControl
    {
        public event EventHandler MainMenuStartButtonPress;
        public event EventHandler MainMenuExitButtonPress;
        public MainMenuControls()
        {
            InitializeComponent();
        }

        protected virtual void OnMainMenuStartButtonPressed(EventArgs e)
        {
            MainMenuStartButtonPress?.Invoke(this, e);
        }
        protected virtual void OnMainMenuExitButtonPressed(EventArgs e)
        {
            MainMenuExitButtonPress?.Invoke(this, e);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            OnMainMenuStartButtonPressed(EventArgs.Empty);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            OnMainMenuExitButtonPressed(EventArgs.Empty);
        }
    }
}
