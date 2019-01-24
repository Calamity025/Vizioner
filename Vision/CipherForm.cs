using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vision {
    class CipherForm : Form {
        public TextBox Input, Output, Key;
    
        //конструктор формы
        public CipherForm() {
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(285, 340);
            FormBorderStyle = FormBorderStyle.FixedDialog;
        
            Input = new TextBox();
            Input.Size = new Size(250, 100);
            Input.Location = new Point(10, 10);
            Input.Multiline = true;
            Input.Font = new Font(Input.Font.FontFamily, 14);
            Controls.Add(Input);
      
            Output = new TextBox();
            Output.Location = new Point(10, 185);
            Output.Size = new Size(250, 100);
            Output.Multiline = true;
            Output.Font = new Font(Output.Font.FontFamily, 14);
            Controls.Add(Output); 
      
            Label shiftLb = new Label();
            shiftLb.Location = new Point(10, 130);
            shiftLb.Size = new Size(40, 40);
            shiftLb.TextAlign = ContentAlignment.MiddleCenter;
            shiftLb.Text = "Ключ:";
            Controls.Add(shiftLb);
      
            Key = new TextBox();
            Key.Location = new Point(60, 140);
            Key.Size = new Size(90,40);
            Controls.Add(Key);
      
            Button encryptButton = new Button();
            encryptButton.Location = new Point(160, 115);
            encryptButton.Size = new Size(100,30);
            encryptButton.Text = "Зашифрувати";
            encryptButton.Click += EncryptClick;
            Controls.Add(encryptButton);
      
            Button decryptButton = new Button();
            decryptButton.Location = new Point(160, 150);
            decryptButton.Size = new Size(100,30);
            decryptButton.Text = "Дешифрувати";
            decryptButton.Click += DecryptClick;
            Controls.Add(decryptButton);
        }
        //ивенты нажатий на кнопки
        void DecryptClick(object sender, EventArgs e) {
            Output.Text = Calculus.Decrypt(Input.Text.ToLower(), Key.Text);
        }
        void EncryptClick(object sender, EventArgs e) {
           Output.Text = Calculus.Encrypt(Input.Text.ToLower(), Key.Text);
        }
    }
}
