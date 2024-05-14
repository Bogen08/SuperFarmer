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
    public partial class TradePartnerSelect : UserControl
    {
        public event EventHandler TradePartnerBackButtonPress;
        public event EventHandler TradePartnerProceedButtonPress;

        public RadioButton[] selector;
        Dictionary<int, string> partners;
        int[] playersId;
        public KeyValuePair<int, string> selectedPartner = new KeyValuePair<int, string>(-1, "Herd");
        public TradePartnerSelect()
        {
            InitializeComponent();
            selector = new RadioButton[4] { radioButton1, radioButton2, radioButton3, radioButton4 };
            playersId = new int[4];
        }
        public void LoadData(Dictionary<int, string> partnersData)
        {
            partners = partnersData;
            int i = 1;
            foreach (KeyValuePair<int, string> pair in partners)
            {
                //selector[i].Text = ("Player " + pair.Value + " , ID:" + pair.Key.ToString());
                selector[i].Text = ("Player " + pair.Value);
                playersId[i] = pair.Key;
                selector[i].Show();
                i++;
            }
        }

        public void ClearSelection()
        {
            for (int i = 0; i < selector.Length; i++)
            {
                selector[i].Checked = false;
            }
            proceedTradeButton.Enabled = false;
        }

        protected virtual void OnTradePartnerBackButtonPress(EventArgs e)
        {
            TradePartnerBackButtonPress?.Invoke(this, e);
        }
        protected virtual void OnTradePartnerProceedButtonPress(EventArgs e)
        {
            TradePartnerProceedButtonPress?.Invoke(this, e);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            OnTradePartnerBackButtonPress(EventArgs.Empty);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            selectedPartner = new KeyValuePair<int, string>( -1,"Herd");
            proceedTradeButton.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            selectedPartner = new KeyValuePair<int, string>(playersId[1], partners[playersId[1]]);
            proceedTradeButton.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            selectedPartner = new KeyValuePair<int, string>(playersId[2], partners[playersId[2]]);
            proceedTradeButton.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            selectedPartner = new KeyValuePair<int, string>(playersId[2], partners[playersId[2]]);
            proceedTradeButton.Enabled = true;
        }

        private void proceedTradeButton_Click(object sender, EventArgs e)
        {
            ClearSelection();
            OnTradePartnerProceedButtonPress(EventArgs.Empty);
        }
    }
}
