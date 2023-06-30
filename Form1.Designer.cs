namespace NavyCraft
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvmy = new System.Windows.Forms.DataGridView();
            this.dgvcomp = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butStart = new System.Windows.Forms.Button();
            this.labStep = new System.Windows.Forms.Label();
            this.labMyInfo = new System.Windows.Forms.Label();
            this.labCompInfo = new System.Windows.Forms.Label();
            this.LabCompFired = new System.Windows.Forms.Label();
            this.LabFiredAI = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcomp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvmy
            // 
            this.dgvmy.AllowUserToAddRows = false;
            this.dgvmy.AllowUserToDeleteRows = false;
            this.dgvmy.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvmy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvmy.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvmy.Location = new System.Drawing.Point(52, 45);
            this.dgvmy.Margin = new System.Windows.Forms.Padding(4);
            this.dgvmy.Name = "dgvmy";
            this.dgvmy.ReadOnly = true;
            this.dgvmy.RowHeadersWidth = 51;
            this.dgvmy.Size = new System.Drawing.Size(424, 365);
            this.dgvmy.TabIndex = 0;
            this.dgvmy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvmy_CellContentClick);
            // 
            // dgvcomp
            // 
            this.dgvcomp.AllowUserToAddRows = false;
            this.dgvcomp.AllowUserToDeleteRows = false;
            this.dgvcomp.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvcomp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcomp.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvcomp.Location = new System.Drawing.Point(657, 45);
            this.dgvcomp.Margin = new System.Windows.Forms.Padding(4);
            this.dgvcomp.MultiSelect = false;
            this.dgvcomp.Name = "dgvcomp";
            this.dgvcomp.ReadOnly = true;
            this.dgvcomp.RowHeadersWidth = 51;
            this.dgvcomp.Size = new System.Drawing.Size(424, 365);
            this.dgvcomp.TabIndex = 1;
            this.dgvcomp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcomp_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(205, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ваше поле";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(796, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Поле противника";
            // 
            // butStart
            // 
            this.butStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butStart.Location = new System.Drawing.Point(734, 507);
            this.butStart.Margin = new System.Windows.Forms.Padding(4);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(347, 38);
            this.butStart.TabIndex = 4;
            this.butStart.Text = "Начать / перезапустить игру";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // labStep
            // 
            this.labStep.AutoSize = true;
            this.labStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labStep.Location = new System.Drawing.Point(51, 520);
            this.labStep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labStep.Name = "labStep";
            this.labStep.Size = new System.Drawing.Size(52, 25);
            this.labStep.TabIndex = 5;
            this.labStep.Text = "Ход";
            // 
            // labMyInfo
            // 
            this.labMyInfo.AutoSize = true;
            this.labMyInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labMyInfo.Location = new System.Drawing.Point(48, 453);
            this.labMyInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labMyInfo.Name = "labMyInfo";
            this.labMyInfo.Size = new System.Drawing.Size(55, 20);
            this.labMyInfo.TabIndex = 6;
            this.labMyInfo.Text = "Счет";
            // 
            // labCompInfo
            // 
            this.labCompInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labCompInfo.Location = new System.Drawing.Point(693, 453);
            this.labCompInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labCompInfo.Name = "labCompInfo";
            this.labCompInfo.Size = new System.Drawing.Size(388, 20);
            this.labCompInfo.TabIndex = 7;
            this.labCompInfo.Text = "Счет";
            this.labCompInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabCompFired
            // 
            this.LabCompFired.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabCompFired.Location = new System.Drawing.Point(693, 569);
            this.LabCompFired.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabCompFired.Name = "LabCompFired";
            this.LabCompFired.Size = new System.Drawing.Size(388, 20);
            this.LabCompFired.TabIndex = 8;
            this.LabCompFired.Text = "Поцент попаданий Игрока";
            this.LabCompFired.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabFiredAI
            // 
            this.LabFiredAI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabFiredAI.Location = new System.Drawing.Point(48, 578);
            this.LabFiredAI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabFiredAI.Name = "LabFiredAI";
            this.LabFiredAI.Size = new System.Drawing.Size(388, 20);
            this.LabFiredAI.TabIndex = 9;
            this.LabFiredAI.Text = "Поцент попаданий AI";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 635);
            this.Controls.Add(this.LabFiredAI);
            this.Controls.Add(this.LabCompFired);
            this.Controls.Add(this.labCompInfo);
            this.Controls.Add(this.labMyInfo);
            this.Controls.Add(this.labStep);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvcomp);
            this.Controls.Add(this.dgvmy);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Морской бой";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcomp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvmy;
        private System.Windows.Forms.DataGridView dgvcomp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Label labStep;
        private System.Windows.Forms.Label labMyInfo;
        private System.Windows.Forms.Label labCompInfo;
        private System.Windows.Forms.Label LabCompFired;
        private System.Windows.Forms.Label LabFiredAI;
        // private System.Windows.Forms.Label 
    }
}

