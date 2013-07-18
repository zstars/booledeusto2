namespace BooleDeustoTwo
{
    partial class CompleteTruthTableForm
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
            this.inputsGrid = new System.Windows.Forms.DataGridView();
            this.outputsGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.anyButton = new System.Windows.Forms.Button();
            this.zerosButton = new System.Windows.Forms.Button();
            this.onesButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputsGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputsGrid
            // 
            this.inputsGrid.AllowUserToAddRows = false;
            this.inputsGrid.AllowUserToDeleteRows = false;
            this.inputsGrid.AllowUserToResizeColumns = false;
            this.inputsGrid.AllowUserToResizeRows = false;
            this.inputsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.inputsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputsGrid.Location = new System.Drawing.Point(12, 121);
            this.inputsGrid.Name = "inputsGrid";
            this.inputsGrid.ReadOnly = true;
            this.inputsGrid.Size = new System.Drawing.Size(491, 483);
            this.inputsGrid.TabIndex = 0;
            // 
            // outputsGrid
            // 
            this.outputsGrid.AllowUserToAddRows = false;
            this.outputsGrid.AllowUserToDeleteRows = false;
            this.outputsGrid.AllowUserToResizeColumns = false;
            this.outputsGrid.AllowUserToResizeRows = false;
            this.outputsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.outputsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputsGrid.Location = new System.Drawing.Point(595, 121);
            this.outputsGrid.Name = "outputsGrid";
            this.outputsGrid.ReadOnly = true;
            this.outputsGrid.Size = new System.Drawing.Size(491, 483);
            this.outputsGrid.TabIndex = 1;
            this.outputsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.onCellClicked);
            this.outputsGrid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.onCellMouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inputs:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Outputs:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearButton);
            this.groupBox1.Controls.Add(this.anyButton);
            this.groupBox1.Controls.Add(this.zerosButton);
            this.groupBox1.Controls.Add(this.onesButton);
            this.groupBox1.Location = new System.Drawing.Point(595, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 69);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fill outputs table";
            // 
            // anyButton
            // 
            this.anyButton.Location = new System.Drawing.Point(248, 28);
            this.anyButton.Name = "anyButton";
            this.anyButton.Size = new System.Drawing.Size(75, 23);
            this.anyButton.TabIndex = 2;
            this.anyButton.Text = "Any (X)";
            this.anyButton.UseVisualStyleBackColor = true;
            this.anyButton.Click += new System.EventHandler(this.anyButton_Click);
            // 
            // zerosButton
            // 
            this.zerosButton.Location = new System.Drawing.Point(329, 28);
            this.zerosButton.Name = "zerosButton";
            this.zerosButton.Size = new System.Drawing.Size(75, 23);
            this.zerosButton.TabIndex = 1;
            this.zerosButton.Text = "Zeros";
            this.zerosButton.UseVisualStyleBackColor = true;
            this.zerosButton.Click += new System.EventHandler(this.zerosButton_Click);
            // 
            // onesButton
            // 
            this.onesButton.Location = new System.Drawing.Point(410, 28);
            this.onesButton.Name = "onesButton";
            this.onesButton.Size = new System.Drawing.Size(75, 23);
            this.onesButton.TabIndex = 0;
            this.onesButton.Text = "Ones";
            this.onesButton.UseVisualStyleBackColor = true;
            this.onesButton.Click += new System.EventHandler(this.onesButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(6, 28);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // CompleteTruthTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 616);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputsGrid);
            this.Controls.Add(this.inputsGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CompleteTruthTableForm";
            this.Text = "Complete Truth Table";
            this.Load += new System.EventHandler(this.CompleteTruthTableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputsGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView inputsGrid;
        private System.Windows.Forms.DataGridView outputsGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button anyButton;
        private System.Windows.Forms.Button zerosButton;
        private System.Windows.Forms.Button onesButton;
        private System.Windows.Forms.Button clearButton;
    }
}