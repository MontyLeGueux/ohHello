namespace oh_hello.ui
{
    partial class OhHelloForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OhHelloForm));
            this.HotkeyList = new System.Windows.Forms.ListView();
            this.ActionHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KeyHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loopCheckBox = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.numericCommandIndex = new System.Windows.Forms.NumericUpDown();
            this.numericTabIndex = new System.Windows.Forms.NumericUpDown();
            this.ohHelloToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericCommandIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTabIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // HotkeyList
            // 
            this.HotkeyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ActionHeader,
            this.KeyHeader});
            this.HotkeyList.FullRowSelect = true;
            this.HotkeyList.GridLines = true;
            this.HotkeyList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.HotkeyList.Location = new System.Drawing.Point(12, 12);
            this.HotkeyList.Name = "HotkeyList";
            this.HotkeyList.Size = new System.Drawing.Size(320, 196);
            this.HotkeyList.TabIndex = 0;
            this.HotkeyList.UseCompatibleStateImageBehavior = false;
            this.HotkeyList.View = System.Windows.Forms.View.Details;
            this.HotkeyList.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // ActionHeader
            // 
            this.ActionHeader.Text = "Action";
            this.ActionHeader.Width = 223;
            // 
            // KeyHeader
            // 
            this.KeyHeader.Text = "Key";
            this.KeyHeader.Width = 93;
            // 
            // loopCheckBox
            // 
            this.loopCheckBox.AutoSize = true;
            this.loopCheckBox.Checked = true;
            this.loopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loopCheckBox.Location = new System.Drawing.Point(122, 215);
            this.loopCheckBox.Name = "loopCheckBox";
            this.loopCheckBox.Size = new System.Drawing.Size(50, 17);
            this.loopCheckBox.TabIndex = 1;
            this.loopCheckBox.Text = "Loop";
            this.loopCheckBox.UseVisualStyleBackColor = true;
            this.loopCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(178, 214);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(82, 19);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // numericCommandIndex
            // 
            this.numericCommandIndex.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericCommandIndex.Location = new System.Drawing.Point(12, 214);
            this.numericCommandIndex.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericCommandIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCommandIndex.Name = "numericCommandIndex";
            this.numericCommandIndex.Size = new System.Drawing.Size(49, 20);
            this.numericCommandIndex.TabIndex = 3;
            this.ohHelloToolTip.SetToolTip(this.numericCommandIndex, "The index of the voice command (1 to 5)");
            this.numericCommandIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCommandIndex.ValueChanged += new System.EventHandler(this.NumericCommandIndex_ValueChanged);
            // 
            // numericTabIndex
            // 
            this.numericTabIndex.Location = new System.Drawing.Point(67, 214);
            this.numericTabIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericTabIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTabIndex.Name = "numericTabIndex";
            this.numericTabIndex.Size = new System.Drawing.Size(49, 20);
            this.numericTabIndex.TabIndex = 4;
            this.ohHelloToolTip.SetToolTip(this.numericTabIndex, "The voice command tab (1 to 3).");
            this.numericTabIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTabIndex.ValueChanged += new System.EventHandler(this.NumericTabIndex_ValueChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(266, 215);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(66, 19);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OhHelloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 243);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.numericTabIndex);
            this.Controls.Add(this.numericCommandIndex);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.loopCheckBox);
            this.Controls.Add(this.HotkeyList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OhHelloForm";
            this.Text = "Oh Hello !";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyHandler);
            ((System.ComponentModel.ISupportInitialize)(this.numericCommandIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTabIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView HotkeyList;
        private System.Windows.Forms.ColumnHeader ActionHeader;
        private System.Windows.Forms.ColumnHeader KeyHeader;
        private System.Windows.Forms.CheckBox loopCheckBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.NumericUpDown numericCommandIndex;
        private System.Windows.Forms.NumericUpDown numericTabIndex;
        private System.Windows.Forms.ToolTip ohHelloToolTip;
        private System.Windows.Forms.Button saveButton;
    }
}

