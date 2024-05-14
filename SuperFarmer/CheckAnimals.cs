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
    public partial class CheckAnimals : UserControl
    {
        public event EventHandler CheckBackButtonPressed;
        public GroupBox herdGroupBox;
        public GroupBox[] pGroupBoxTab;
        public Label[][] playerAnimalCounts;
        public Label[] herdAnimalCounts;
        public Label[] nameLabels;
        public CheckAnimals()
        {
            InitializeComponent();
            herdGroupBox = groupBoxHerd;
            pGroupBoxTab = new GroupBox[4] { groupBox1, groupBox2, groupBox3, groupBox4 };
            playerAnimalCounts = new Label[4][];
            playerAnimalCounts[0] = new Label[7] { p1RabbitsCount, p1SheepCount, p1PigCount, p1CowCount, p1HorsesCount, p1SmallDogsCount, p1BigDogsCount };
            playerAnimalCounts[1] = new Label[7] { p2RabbitsCount, p2SheepCount, p2PigCount, p2CowCount, p2HorsesCount, p2SmallDogsCount, p2BigDogsCount };
            playerAnimalCounts[2] = new Label[7] { p3RabbitsCount, p3SheepCount, p3PigCount, p3CowCount, p3HorsesCount, p3SmallDogsCount, p3BigDogsCount };
            playerAnimalCounts[3] = new Label[7] { p4RabbitsCount, p4SheepCount, p4PigCount, p4CowCount, p4HorsesCount, p4SmallDogsCount, p4BigDogsCount };
            herdAnimalCounts = new Label[7] { herdRabbitCount, herdSheepCount, herdPigsCount, herdCowsCount, herdHorsesCount, herdSmallDogsCount, herdBigDogsCount };
        }

        protected virtual void OnCheckBackButtonPressed(EventArgs e)
        {
            CheckBackButtonPressed?.Invoke(this, e);
        }

        private void groupBoxHerd_Enter(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            OnCheckBackButtonPressed(EventArgs.Empty);
        }
    }
}
