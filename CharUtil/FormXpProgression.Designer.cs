namespace CharUtil
{
    partial class FormXpProgression
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewXpProgression = new System.Windows.Forms.DataGridView();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxCharLevel = new System.Windows.Forms.TextBox();
            this.textBoxXpRequired = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXpProgression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewXpProgression
            // 
            this.dataGridViewXpProgression.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewXpProgression.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewXpProgression.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewXpProgression.Name = "dataGridViewXpProgression";
            this.dataGridViewXpProgression.ReadOnly = true;
            this.dataGridViewXpProgression.RowHeadersWidth = 5;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewXpProgression.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewXpProgression.Size = new System.Drawing.Size(208, 465);
            this.dataGridViewXpProgression.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(178, 493);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(257, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 112);
            this.label1.TabIndex = 2;
            this.label1.Text = "Here is presented the level\r\nprogression for levels 1 to 20 \r\nonly (just like in " +
    "the Player\'s \r\nHandbook). If you wish to \r\nknow the XP required for\r\nlevels abov" +
    "e 20, inform the\r\ndesired level below.";
            // 
            // textBoxCharLevel
            // 
            this.textBoxCharLevel.Location = new System.Drawing.Point(364, 170);
            this.textBoxCharLevel.Name = "textBoxCharLevel";
            this.textBoxCharLevel.Size = new System.Drawing.Size(81, 20);
            this.textBoxCharLevel.TabIndex = 3;
            this.textBoxCharLevel.Text = "0";
            this.textBoxCharLevel.TextChanged += new System.EventHandler(this.textBoxCharLevel_TextChanged);
            this.textBoxCharLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCharLevel_KeyPress);
            // 
            // textBoxXpRequired
            // 
            this.textBoxXpRequired.Location = new System.Drawing.Point(364, 209);
            this.textBoxXpRequired.Name = "textBoxXpRequired";
            this.textBoxXpRequired.ReadOnly = true;
            this.textBoxXpRequired.Size = new System.Drawing.Size(83, 20);
            this.textBoxXpRequired.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Character Level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "XP Required";
            // 
            // FormXpProgression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 528);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxXpRequired);
            this.Controls.Add(this.textBoxCharLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dataGridViewXpProgression);
            this.Name = "FormXpProgression";
            this.Text = "FormXpProgression";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewXpProgression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewXpProgression;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox textBoxCharLevel;
        private System.Windows.Forms.TextBox textBoxXpRequired;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}