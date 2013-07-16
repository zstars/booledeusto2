namespace BooleDeustoTwo
{
    partial class CombinationalCircuitForm
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.systemPropertiesTab = new System.Windows.Forms.TabPage();
            this.outputsGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputsGrid = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outputsNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.test = new System.Windows.Forms.Button();
            this.inputsNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.operationsTab = new System.Windows.Forms.TabPage();
            this.codeTab = new System.Windows.Forms.TabPage();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.completeTruthTableButton = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.systemPropertiesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputsNumber)).BeginInit();
            this.operationsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(55, 12);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(269, 20);
            this.nameBox.TabIndex = 1;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.systemPropertiesTab);
            this.tabs.Controls.Add(this.operationsTab);
            this.tabs.Controls.Add(this.codeTab);
            this.tabs.Location = new System.Drawing.Point(14, 67);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(734, 521);
            this.tabs.TabIndex = 2;
            // 
            // systemPropertiesTab
            // 
            this.systemPropertiesTab.Controls.Add(this.outputsGrid);
            this.systemPropertiesTab.Controls.Add(this.inputsGrid);
            this.systemPropertiesTab.Controls.Add(this.outputsNumber);
            this.systemPropertiesTab.Controls.Add(this.label3);
            this.systemPropertiesTab.Controls.Add(this.test);
            this.systemPropertiesTab.Controls.Add(this.inputsNumber);
            this.systemPropertiesTab.Controls.Add(this.label2);
            this.systemPropertiesTab.Location = new System.Drawing.Point(4, 22);
            this.systemPropertiesTab.Name = "systemPropertiesTab";
            this.systemPropertiesTab.Size = new System.Drawing.Size(726, 495);
            this.systemPropertiesTab.TabIndex = 0;
            this.systemPropertiesTab.Text = "System Properties";
            this.systemPropertiesTab.UseVisualStyleBackColor = true;
            this.systemPropertiesTab.Click += new System.EventHandler(this.systemPropertiesTab_Click);
            // 
            // outputsGrid
            // 
            this.outputsGrid.AllowUserToAddRows = false;
            this.outputsGrid.AllowUserToDeleteRows = false;
            this.outputsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.outputsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.outputsGrid.Location = new System.Drawing.Point(449, 64);
            this.outputsGrid.Name = "outputsGrid";
            this.outputsGrid.RowHeadersWidth = 55;
            this.outputsGrid.Size = new System.Drawing.Size(259, 410);
            this.outputsGrid.TabIndex = 13;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // inputsGrid
            // 
            this.inputsGrid.AllowUserToAddRows = false;
            this.inputsGrid.AllowUserToDeleteRows = false;
            this.inputsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn});
            this.inputsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.inputsGrid.Location = new System.Drawing.Point(18, 64);
            this.inputsGrid.Name = "inputsGrid";
            this.inputsGrid.RowHeadersWidth = 55;
            this.inputsGrid.Size = new System.Drawing.Size(259, 410);
            this.inputsGrid.TabIndex = 12;
            this.inputsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.Width = 200;
            // 
            // outputsNumber
            // 
            this.outputsNumber.Location = new System.Drawing.Point(612, 20);
            this.outputsNumber.Name = "outputsNumber";
            this.outputsNumber.Size = new System.Drawing.Size(61, 20);
            this.outputsNumber.TabIndex = 11;
            this.outputsNumber.ValueChanged += new System.EventHandler(this.onOutputsNumberChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(527, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "# of output lines:";
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(188, 12);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(75, 23);
            this.test.TabIndex = 3;
            this.test.Text = "test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // inputsNumber
            // 
            this.inputsNumber.Location = new System.Drawing.Point(100, 18);
            this.inputsNumber.Name = "inputsNumber";
            this.inputsNumber.Size = new System.Drawing.Size(61, 20);
            this.inputsNumber.TabIndex = 9;
            this.inputsNumber.ValueChanged += new System.EventHandler(this.onInputsNumberChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "# of input lines:";
            // 
            // operationsTab
            // 
            this.operationsTab.Controls.Add(this.completeTruthTableButton);
            this.operationsTab.Location = new System.Drawing.Point(4, 22);
            this.operationsTab.Name = "operationsTab";
            this.operationsTab.Padding = new System.Windows.Forms.Padding(3);
            this.operationsTab.Size = new System.Drawing.Size(726, 495);
            this.operationsTab.TabIndex = 1;
            this.operationsTab.Text = "Operations";
            this.operationsTab.UseVisualStyleBackColor = true;
            // 
            // codeTab
            // 
            this.codeTab.Location = new System.Drawing.Point(4, 22);
            this.codeTab.Name = "codeTab";
            this.codeTab.Size = new System.Drawing.Size(726, 495);
            this.codeTab.TabIndex = 2;
            this.codeTab.Text = "Code";
            this.codeTab.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(14, 606);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(118, 29);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(151, 606);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(118, 29);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(630, 606);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(118, 29);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // completeTruthTableButton
            // 
            this.completeTruthTableButton.Location = new System.Drawing.Point(281, 225);
            this.completeTruthTableButton.Name = "completeTruthTableButton";
            this.completeTruthTableButton.Size = new System.Drawing.Size(130, 40);
            this.completeTruthTableButton.TabIndex = 0;
            this.completeTruthTableButton.Text = "Complete Truth Table";
            this.completeTruthTableButton.UseVisualStyleBackColor = true;
            this.completeTruthTableButton.Click += new System.EventHandler(this.completeTruthTableButton_Click);
            // 
            // CombinationalCircuitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 647);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Name = "CombinationalCircuitForm";
            this.Text = "New combinational circuit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClosed);
            this.Load += new System.EventHandler(this.onFormLoad);
            this.tabs.ResumeLayout(false);
            this.systemPropertiesTab.ResumeLayout(false);
            this.systemPropertiesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputsNumber)).EndInit();
            this.operationsTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TabPage systemPropertiesTab;
        private System.Windows.Forms.DataGridView inputsGrid;
        private System.Windows.Forms.NumericUpDown outputsNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown inputsNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage operationsTab;
        private System.Windows.Forms.TabPage codeTab;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridView outputsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button completeTruthTableButton;
    }
}