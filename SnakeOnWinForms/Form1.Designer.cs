namespace SnakeOnWinForms
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
            this.components = new System.ComponentModel.Container();
            this.snakeBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.snakeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // snakeBox
            // 
            this.snakeBox.BackColor = System.Drawing.Color.Green;
            this.snakeBox.Location = new System.Drawing.Point(200, 200);
            this.snakeBox.Name = "snakeBox";
            this.snakeBox.Size = new System.Drawing.Size(40, 40);
            this.snakeBox.TabIndex = 0;
            this.snakeBox.TabStop = false;
            this.snakeBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 482);
            this.Controls.Add(this.snakeBox);
            this.Name = "Form1";
            this.Text = "Snake The Game";
            ((System.ComponentModel.ISupportInitialize)(this.snakeBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox snakeBox;
        private System.Windows.Forms.Timer timer;
    }
}

