namespace SuperFarmer
{
    partial class GameSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.GameSettingsPlayerCounter = new System.Windows.Forms.NumericUpDown();
            this.GameSettingsStartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GameSettingsPlayerCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select number of players";
            // 
            // GameSettingsPlayerCounter
            // 
            this.GameSettingsPlayerCounter.Location = new System.Drawing.Point(314, 122);
            this.GameSettingsPlayerCounter.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.GameSettingsPlayerCounter.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.GameSettingsPlayerCounter.Name = "GameSettingsPlayerCounter";
            this.GameSettingsPlayerCounter.Size = new System.Drawing.Size(32, 20);
            this.GameSettingsPlayerCounter.TabIndex = 1;
            this.GameSettingsPlayerCounter.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // GameSettingsStartButton
            // 
            this.GameSettingsStartButton.Location = new System.Drawing.Point(293, 188);
            this.GameSettingsStartButton.Name = "GameSettingsStartButton";
            this.GameSettingsStartButton.Size = new System.Drawing.Size(75, 23);
            this.GameSettingsStartButton.TabIndex = 2;
            this.GameSettingsStartButton.Text = "Start game";
            this.GameSettingsStartButton.UseVisualStyleBackColor = true;
            this.GameSettingsStartButton.Click += new System.EventHandler(this.GameSettingsStartButton_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GameSettingsStartButton);
            this.Controls.Add(this.GameSettingsPlayerCounter);
            this.Controls.Add(this.label1);
            this.Name = "GameSettings";
            this.Size = new System.Drawing.Size(660, 420);
            ((System.ComponentModel.ISupportInitialize)(this.GameSettingsPlayerCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown GameSettingsPlayerCounter;
        private System.Windows.Forms.Button GameSettingsStartButton;
    }
}
