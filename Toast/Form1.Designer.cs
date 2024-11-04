namespace Toast
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnToastInCenter = new System.Windows.Forms.Button();
            this.btnToastAtMousePointer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnToastInCenter
            // 
            this.btnToastInCenter.Location = new System.Drawing.Point(222, 45);
            this.btnToastInCenter.Name = "btnToastInCenter";
            this.btnToastInCenter.Size = new System.Drawing.Size(281, 23);
            this.btnToastInCenter.TabIndex = 0;
            this.btnToastInCenter.Text = "중앙하단에 토스트";
            this.btnToastInCenter.UseVisualStyleBackColor = true;
            this.btnToastInCenter.Click += new System.EventHandler(this.btnToastInCenter_Click);
            // 
            // btnToastAtMousePointer
            // 
            this.btnToastAtMousePointer.Location = new System.Drawing.Point(222, 86);
            this.btnToastAtMousePointer.Name = "btnToastAtMousePointer";
            this.btnToastAtMousePointer.Size = new System.Drawing.Size(281, 23);
            this.btnToastAtMousePointer.TabIndex = 1;
            this.btnToastAtMousePointer.Text = "마우스위치에 토스트";
            this.btnToastAtMousePointer.UseVisualStyleBackColor = true;
            this.btnToastAtMousePointer.Click += new System.EventHandler(this.btnToastAtMousePointer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnToastAtMousePointer);
            this.Controls.Add(this.btnToastInCenter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnToastInCenter;
        private System.Windows.Forms.Button btnToastAtMousePointer;
    }
}

