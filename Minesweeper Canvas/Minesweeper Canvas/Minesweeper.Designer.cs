namespace Minesweeper_Canvas
{
    partial class Minesweeper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newGame = new System.Windows.Forms.Button();
            this.setSize = new System.Windows.Forms.NumericUpDown();
            this.setMines = new System.Windows.Forms.NumericUpDown();
            this.checkWin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.setSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setMines)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Board size:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 465);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total mines:";
            // 
            // newGame
            // 
            this.newGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newGame.Location = new System.Drawing.Point(141, 478);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(75, 23);
            this.newGame.TabIndex = 2;
            this.newGame.Text = "Generate";
            this.newGame.UseVisualStyleBackColor = true;
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // setSize
            // 
            this.setSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setSize.Location = new System.Drawing.Point(15, 442);
            this.setSize.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.setSize.Name = "setSize";
            this.setSize.Size = new System.Drawing.Size(120, 20);
            this.setSize.TabIndex = 3;
            this.setSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.setSize.ValueChanged += new System.EventHandler(this.setSize_ValueChanged);
            // 
            // setMines
            // 
            this.setMines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setMines.Location = new System.Drawing.Point(15, 481);
            this.setMines.Name = "setMines";
            this.setMines.Size = new System.Drawing.Size(120, 20);
            this.setMines.TabIndex = 3;
            this.setMines.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // checkWin
            // 
            this.checkWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkWin.Location = new System.Drawing.Point(387, 478);
            this.checkWin.Name = "checkWin";
            this.checkWin.Size = new System.Drawing.Size(129, 23);
            this.checkWin.TabIndex = 4;
            this.checkWin.Text = "Check For Win";
            this.checkWin.UseVisualStyleBackColor = true;
            this.checkWin.Click += new System.EventHandler(this.checkWin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 516);
            this.Controls.Add(this.checkWin);
            this.Controls.Add(this.setMines);
            this.Controls.Add(this.setSize);
            this.Controls.Add(this.newGame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.setSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setMines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button newGame;
        private System.Windows.Forms.NumericUpDown setSize;
        private System.Windows.Forms.NumericUpDown setMines;
        private System.Windows.Forms.Button checkWin;
    }
}

