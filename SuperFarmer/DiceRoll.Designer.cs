namespace SuperFarmer
{
    partial class DiceRoll
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.rollButton = new System.Windows.Forms.Button();
            this.rollLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.endTurnButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.playerBigDogsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playerSmallDogsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.playerHorsesCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.playerCowsCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.playerPigsCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.playerSheepCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.playerRabbitCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rollButton
            // 
            this.rollButton.Location = new System.Drawing.Point(275, 20);
            this.rollButton.Name = "rollButton";
            this.rollButton.Size = new System.Drawing.Size(110, 41);
            this.rollButton.TabIndex = 0;
            this.rollButton.Text = "Press to roll the dice";
            this.rollButton.UseVisualStyleBackColor = true;
            this.rollButton.Click += new System.EventHandler(this.rollButton_Click);
            // 
            // rollLabel
            // 
            this.rollLabel.AutoSize = true;
            this.rollLabel.Location = new System.Drawing.Point(309, 92);
            this.rollLabel.Name = "rollLabel";
            this.rollLabel.Size = new System.Drawing.Size(46, 13);
            this.rollLabel.TabIndex = 1;
            this.rollLabel.Text = "rollLabel";
            this.rollLabel.Visible = false;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(293, 139);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // endTurnButton
            // 
            this.endTurnButton.Location = new System.Drawing.Point(293, 362);
            this.endTurnButton.Name = "endTurnButton";
            this.endTurnButton.Size = new System.Drawing.Size(75, 23);
            this.endTurnButton.TabIndex = 3;
            this.endTurnButton.Text = "End turn";
            this.endTurnButton.UseVisualStyleBackColor = true;
            this.endTurnButton.Visible = false;
            this.endTurnButton.Click += new System.EventHandler(this.endTurnButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(312, 184);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(37, 13);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Text = "Result";
            this.resultLabel.Visible = false;
            this.resultLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.playerBigDogsCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.playerSmallDogsCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.playerHorsesCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.playerCowsCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.playerPigsCount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.playerSheepCount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.playerRabbitCount);
            this.groupBox1.Location = new System.Drawing.Point(140, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 80);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Animals";
            this.groupBox1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Small Dogs";
            // 
            // playerBigDogsCount
            // 
            this.playerBigDogsCount.AutoSize = true;
            this.playerBigDogsCount.Location = new System.Drawing.Point(322, 49);
            this.playerBigDogsCount.Name = "playerBigDogsCount";
            this.playerBigDogsCount.Size = new System.Drawing.Size(13, 13);
            this.playerBigDogsCount.TabIndex = 14;
            this.playerBigDogsCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rabbits";
            // 
            // playerSmallDogsCount
            // 
            this.playerSmallDogsCount.AutoSize = true;
            this.playerSmallDogsCount.Location = new System.Drawing.Point(261, 50);
            this.playerSmallDogsCount.Name = "playerSmallDogsCount";
            this.playerSmallDogsCount.Size = new System.Drawing.Size(13, 13);
            this.playerSmallDogsCount.TabIndex = 13;
            this.playerSmallDogsCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sheep";
            // 
            // playerHorsesCount
            // 
            this.playerHorsesCount.AutoSize = true;
            this.playerHorsesCount.Location = new System.Drawing.Point(209, 50);
            this.playerHorsesCount.Name = "playerHorsesCount";
            this.playerHorsesCount.Size = new System.Drawing.Size(13, 13);
            this.playerHorsesCount.TabIndex = 12;
            this.playerHorsesCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pigs";
            // 
            // playerCowsCount
            // 
            this.playerCowsCount.AutoSize = true;
            this.playerCowsCount.Location = new System.Drawing.Point(167, 49);
            this.playerCowsCount.Name = "playerCowsCount";
            this.playerCowsCount.Size = new System.Drawing.Size(13, 13);
            this.playerCowsCount.TabIndex = 11;
            this.playerCowsCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cows";
            // 
            // playerPigsCount
            // 
            this.playerPigsCount.AutoSize = true;
            this.playerPigsCount.Location = new System.Drawing.Point(130, 50);
            this.playerPigsCount.Name = "playerPigsCount";
            this.playerPigsCount.Size = new System.Drawing.Size(13, 13);
            this.playerPigsCount.TabIndex = 10;
            this.playerPigsCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Horses";
            // 
            // playerSheepCount
            // 
            this.playerSheepCount.AutoSize = true;
            this.playerSheepCount.Location = new System.Drawing.Point(90, 49);
            this.playerSheepCount.Name = "playerSheepCount";
            this.playerSheepCount.Size = new System.Drawing.Size(13, 13);
            this.playerSheepCount.TabIndex = 9;
            this.playerSheepCount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Big Dogs";
            // 
            // playerRabbitCount
            // 
            this.playerRabbitCount.AutoSize = true;
            this.playerRabbitCount.Location = new System.Drawing.Point(45, 49);
            this.playerRabbitCount.Name = "playerRabbitCount";
            this.playerRabbitCount.Size = new System.Drawing.Size(13, 13);
            this.playerRabbitCount.TabIndex = 8;
            this.playerRabbitCount.Text = "0";
            // 
            // DiceRoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.endTurnButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.rollLabel);
            this.Controls.Add(this.rollButton);
            this.Name = "DiceRoll";
            this.Size = new System.Drawing.Size(660, 420);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rollButton;
        private System.Windows.Forms.Label rollLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button endTurnButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label playerBigDogsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label playerSmallDogsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label playerHorsesCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label playerCowsCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label playerPigsCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label playerSheepCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label playerRabbitCount;
    }
}
