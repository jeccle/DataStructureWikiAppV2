namespace DataStructureWikiAppV2
{
    partial class WikiForm
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
            this.catBox = new System.Windows.Forms.ComboBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.linRadioButton = new System.Windows.Forms.RadioButton();
            this.nonLinRadioButton = new System.Windows.Forms.RadioButton();
            this.descBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewDisplay = new System.Windows.Forms.ListView();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // catBox
            // 
            this.catBox.FormattingEnabled = true;
            this.catBox.Location = new System.Drawing.Point(11, 66);
            this.catBox.Name = "catBox";
            this.catBox.Size = new System.Drawing.Size(121, 21);
            this.catBox.TabIndex = 0;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(12, 24);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 1;
            // 
            // linRadioButton
            // 
            this.linRadioButton.AutoSize = true;
            this.linRadioButton.Location = new System.Drawing.Point(146, 54);
            this.linRadioButton.Name = "linRadioButton";
            this.linRadioButton.Size = new System.Drawing.Size(54, 17);
            this.linRadioButton.TabIndex = 2;
            this.linRadioButton.TabStop = true;
            this.linRadioButton.Text = "Linear";
            this.linRadioButton.UseVisualStyleBackColor = true;
            // 
            // nonLinRadioButton
            // 
            this.nonLinRadioButton.AutoSize = true;
            this.nonLinRadioButton.Location = new System.Drawing.Point(146, 74);
            this.nonLinRadioButton.Name = "nonLinRadioButton";
            this.nonLinRadioButton.Size = new System.Drawing.Size(77, 17);
            this.nonLinRadioButton.TabIndex = 3;
            this.nonLinRadioButton.TabStop = true;
            this.nonLinRadioButton.Text = "Non-Linear";
            this.nonLinRadioButton.UseVisualStyleBackColor = true;
            // 
            // descBox
            // 
            this.descBox.Location = new System.Drawing.Point(11, 110);
            this.descBox.Multiline = true;
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(301, 124);
            this.descBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Structure Description";
            // 
            // listViewDisplay
            // 
            this.listViewDisplay.HideSelection = false;
            this.listViewDisplay.Location = new System.Drawing.Point(320, 40);
            this.listViewDisplay.Name = "listViewDisplay";
            this.listViewDisplay.Size = new System.Drawing.Size(135, 223);
            this.listViewDisplay.TabIndex = 9;
            this.listViewDisplay.UseCompatibleStateImageBehavior = false;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(11, 240);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(70, 23);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(88, 240);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(70, 23);
            this.editButton.TabIndex = 11;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(165, 240);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(70, 23);
            this.delButton.TabIndex = 12;
            this.delButton.Text = "Delete";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(392, 11);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(65, 23);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(320, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(66, 20);
            this.searchBox.TabIndex = 14;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(247, 71);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(65, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(247, 45);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(65, 23);
            this.button6.TabIndex = 16;
            this.button6.Text = "Load";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(242, 240);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(70, 23);
            this.clearButton.TabIndex = 17;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(139, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 54);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Structure Type";
            // 
            // WikiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 270);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.listViewDisplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.nonLinRadioButton);
            this.Controls.Add(this.linRadioButton);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.catBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "WikiForm";
            this.Text = "My Data Structure Wiki";
            this.Load += new System.EventHandler(this.WikiForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox catBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.RadioButton linRadioButton;
        private System.Windows.Forms.RadioButton nonLinRadioButton;
        private System.Windows.Forms.TextBox descBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewDisplay;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

