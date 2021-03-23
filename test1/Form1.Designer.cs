
namespace test1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListView1 = new System.Windows.Forms.ListView();
            this.ButtonBack = new System.Windows.Forms.Button();
            this.MainTxt = new System.Windows.Forms.RichTextBox();
            this.PanelPics = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ListView1
            // 
            this.ListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView1.BackColor = System.Drawing.SystemColors.Window;
            this.ListView1.FullRowSelect = true;
            this.ListView1.HideSelection = false;
            this.ListView1.Location = new System.Drawing.Point(12, 13);
            this.ListView1.MultiSelect = false;
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(1476, 676);
            this.ListView1.TabIndex = 2;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged_UsingItems);
            // 
            // ButtonBack
            // 
            this.ButtonBack.Location = new System.Drawing.Point(1328, 628);
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(160, 60);
            this.ButtonBack.TabIndex = 3;
            this.ButtonBack.Text = "Back to recipes";
            this.ButtonBack.UseVisualStyleBackColor = true;
            this.ButtonBack.Visible = false;
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // MainTxt
            // 
            this.MainTxt.Location = new System.Drawing.Point(1328, 298);
            this.MainTxt.Name = "MainTxt";
            this.MainTxt.Size = new System.Drawing.Size(100, 96);
            this.MainTxt.TabIndex = 4;
            this.MainTxt.Text = "";
            // 
            // PanelPics
            // 
            this.PanelPics.Location = new System.Drawing.Point(107, 143);
            this.PanelPics.Name = "PanelPics";
            this.PanelPics.Size = new System.Drawing.Size(383, 203);
            this.PanelPics.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1500, 700);
            this.Controls.Add(this.PanelPics);
            this.Controls.Add(this.MainTxt);
            this.Controls.Add(this.ButtonBack);
            this.Controls.Add(this.ListView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Recipes";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView ListView1;
        private System.Windows.Forms.Button ButtonBack;
        private System.Windows.Forms.RichTextBox MainTxt;
        private System.Windows.Forms.Panel PanelPics;
    }
}

