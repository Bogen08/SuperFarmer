using SuperFarmer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MainForm : Form
    {
        //Initialising Values
        private MainMenuControls mainMenu;
        private GameSettings gameSettings;
        private GameControls gameControls;
        private CheckAnimals checkAnimals;
        private DiceRoll diceRoll;
        private TradePartnerSelect tradePartnerSelect;
        private TradeAnimalSelect tradeAnimalSelect;


        private Random random;

        private Game GameEngine;
        

        private string[] rules;
        public MainForm()
        {
            InitializeComponent();

            //Game rules description
            rules = File.ReadAllLines("Rules.txt");
            random = new Random();


            //Assigning objects
            mainMenu = new MainMenuControls();
            gameSettings = new GameSettings();
            gameControls = new GameControls();
            checkAnimals = new CheckAnimals();
            diceRoll = new DiceRoll();
            tradePartnerSelect = new TradePartnerSelect();
            tradeAnimalSelect = new TradeAnimalSelect();

            //Docking User Controls
            mainMenu.Dock = DockStyle.Fill;
            gameSettings.Dock = DockStyle.Fill;
            gameControls.Dock = DockStyle.Fill;
            checkAnimals.Dock = DockStyle.Fill;
            diceRoll.Dock = DockStyle.Fill;
            tradePartnerSelect.Dock = DockStyle.Fill;
            tradeAnimalSelect.Dock = DockStyle.Fill;

            //Event Liseners
            mainMenu.MainMenuStartButtonPress += MainMenu_MainMenuStartButtonPress;
            mainMenu.MainMenuExitButtonPress += MainMenu_MainMenuExitButtonPress;
            gameSettings.GameSettingsStartButtonPress += GameSettings_GameSettingsStartButtonPress;
            gameControls.ControlsRollButtonPress += GameControls_ControlsRollButtonPress;
            gameControls.ControlsCheckButtonPress += GameControls_ControlsCheckButtonPress;
            gameControls.ControlsTradeButtonPress += GameControls_ControlsTradeButtonPress;
            checkAnimals.CheckBackButtonPressed += CheckAnimals_CheckBackButtonPressed;
            diceRoll.DiceRollBackButtonPress += DiceRoll_DiceRollBackButtonPress;
            diceRoll.DiceRollButtonPress += DiceRoll_DiceRollButtonPress;
            diceRoll.DiceEndButtonPress += DiceRoll_DiceEndButtonPress;
            tradePartnerSelect.TradePartnerBackButtonPress += TradePartnerSelect_TradePartnerBackButtonPress;
            tradePartnerSelect.TradePartnerProceedButtonPress += TradePartnerSelect_TradePartnerProceedButtonPress;
            tradeAnimalSelect.TradeAnimalBackButtonPress += TradeAnimalSelect_TradeAnimalBackButtonPress;
            tradeAnimalSelect.TradeAnimalProcess += TradeAnimalSelect_TradeAnimalProcess;
        

            //Show starting user control
            ShowControl(mainMenu);
        }

        private void TradeAnimalSelect_TradeAnimalProcess(object sender, EventArgs e)
        {
            GameEngine.Trade(GameEngine.currentPlayer, tradeAnimalSelect.playerSideOffer, tradeAnimalSelect.otherPlayerId, tradeAnimalSelect.otherSideOffer);
            GameEngine.currentPlayerTraded = true;
            tradeAnimalSelect.resetCounters();
            LoadGameControlls();
        }

        private void TradeAnimalSelect_TradeAnimalBackButtonPress(object sender, EventArgs e)
        {
            LoadGameControlls();
        }

        private void TradePartnerSelect_TradePartnerProceedButtonPress(object sender, EventArgs e)
        {
            if (tradePartnerSelect.selectedPartner.Key == -1)
            {
                tradeAnimalSelect.SetupTradeWithHerd(GameEngine.players[GameEngine.currentPlayer].Name, GameEngine.players[GameEngine.currentPlayer].animals,GameEngine.herdAnimals);
            }
            else
                tradeAnimalSelect.SetupTradeWithOtherPlayer(GameEngine.players[GameEngine.currentPlayer].Name, GameEngine.players[GameEngine.currentPlayer].animals, tradePartnerSelect.selectedPartner.Key, tradePartnerSelect.selectedPartner.Value, GameEngine.players[tradePartnerSelect.selectedPartner.Key].animals);
            ShowControl(tradeAnimalSelect);
        }

        private void TradePartnerSelect_TradePartnerBackButtonPress(object sender, EventArgs e)
        {
            LoadGameControlls();
            tradePartnerSelect.ClearSelection();
        }

        private void DiceRoll_DiceEndButtonPress(object sender, EventArgs e)
        {
            diceRoll.rollDiceButton.Show();
            diceRoll.backDiceButton.Show();
            diceRoll.diceResult.Hide();
            diceRoll.description.Hide();
            diceRoll.endButton.Hide();
            diceRoll.groupBox.Hide();

            if (GameEngine.currentPlayer + 1 < GameEngine.players.Length)
            {
                GameEngine.currentPlayer++;
            }
            else
            {
                GameEngine.currentPlayer = 0;
            }
            GameEngine.currentPlayerTraded = false;
            LoadGameControlls();
        }

        private void DiceRoll_DiceRollButtonPress(object sender, EventArgs e)
        {
            string[] result = new string[3];
            int a = random.Next(12)+1;
            int b = random.Next(12)+1;
            result = GameEngine.ChandleRolls(GameEngine.currentPlayer, a, b);
            diceRoll.diceResult.Text = result[0];
            diceRoll.description.Text = (result[1] + "\n" + result[2]);
            diceRoll.LoadData(GameEngine.players[GameEngine.currentPlayer].Name, GameEngine.players[GameEngine.currentPlayer].animals, GameEngine.currentPlayerTraded);
            
            diceRoll.rollDiceButton.Hide();
            diceRoll.backDiceButton.Hide();
            diceRoll.diceResult.Show();
            diceRoll.description.Show();
            diceRoll.endButton.Show();
            diceRoll.groupBox.Show();
        }

        private void DiceRoll_DiceRollBackButtonPress(object sender, EventArgs e)
        {
            LoadGameControlls();
        }

        private void CheckAnimals_CheckBackButtonPressed(object sender, EventArgs e)
        {
            LoadGameControlls();
        }

        private void GameControls_ControlsTradeButtonPress(object sender, EventArgs e)
        {
            Dictionary<int,string> partners = new Dictionary<int, string> { };
            for (int i = 0; i < GameEngine.players.Length; i++)
            {
                if (i == GameEngine.currentPlayer)
                    continue;
                partners.Add(i, GameEngine.players[i].Name);
            }
            tradePartnerSelect.LoadData(partners);
            ShowControl(tradePartnerSelect);
        }

        private void GameControls_ControlsCheckButtonPress(object sender, EventArgs e)
        {
            int i = 0;
            foreach(KeyValuePair<string, int> pair in GameEngine.herdAnimals)
            {
                checkAnimals.herdAnimalCounts[i].Text = pair.Value.ToString();
                i++;
            }
            for (i = 0; i < GameEngine.players.Length; i++)
            {
                checkAnimals.pGroupBoxTab[i].Show();
                checkAnimals.pGroupBoxTab[i].Text= ("Player "+GameEngine.players[i].Name+" animals");
                int j = 0;
                foreach (KeyValuePair<string, int> pair in GameEngine.players[i].animals)
                {
                    checkAnimals.playerAnimalCounts[i][j].Text = pair.Value.ToString();
                    j++;
                }
            }
            ShowControl(checkAnimals);
        }

        private void GameControls_ControlsRollButtonPress(object sender, EventArgs e)
        {
            ShowControl(diceRoll);
        }

        private void GameSettings_GameSettingsStartButtonPress(object sender, EventArgs e)
        {
            int playerCounter = (int)gameSettings.playerCounter.Value;
            GameEngine = new Game(playerCounter);
            for (int i = 0; i < playerCounter; i++)
            {
                string test = InputBox("Add player", "Enter player " + (i+1) + " name");
                GameEngine.AddPlayer(test);
            }
            LoadGameControlls();
        }

        private void MainMenu_MainMenuExitButtonPress(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainMenu_MainMenuStartButtonPress(object sender, EventArgs e)
        {
            ShowControl(gameSettings);
        }

        private void ShowControl(Control control)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(control);
        }

        private void LoadGameControlls()
        {
            if (GameEngine.CheckVictory(GameEngine.currentPlayer))
                this.Close();
            ShowControl(gameControls);
            gameControls.LoadData(GameEngine.players[GameEngine.currentPlayer].Name, GameEngine.players[GameEngine.currentPlayer].animals, GameEngine.currentPlayerTraded);
        }

        public static String InputBox(string title, string promptText)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonOk.Text = "OK";
            buttonOk.DialogResult = DialogResult.OK;

            label.SetBounds(16, 16, 100, 13);
            textBox.SetBounds(16, 36, 100, 20);
            buttonOk.SetBounds(26, 60, 60, 30);

            label.AutoSize = true;
            form.ClientSize = new Size(150, 100);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            form.Controls.AddRange(new Control[] { label, textBox, buttonOk});
            form.AcceptButton = buttonOk;

            DialogResult dialogResult = form.ShowDialog();

            string value = textBox.Text;
            return value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Join("\n", rules),"Game Rules");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exchange table:\n" +
                "1 Sheep = 6 Rabbits\n" +
                "1 Pig = 2 Sheep\n" +
                "1 Cow = 3 Pigs\n" +
                "1 Horse = 2 Cows\n" +
                "1 Small Dog = 1 Sheep\n" +
                "1 Big Dog = 1 Cow","Exchange Values");
        }
    }
}
