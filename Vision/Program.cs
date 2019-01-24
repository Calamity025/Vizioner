using System.Drawing;
using System.Windows.Forms;

namespace Vision {
	internal class Program {
		public static void Main(string[] args) {
			CipherForm start = new CipherForm();
			start.Text = "Шифр Віженера";
			start.BackColor = Color.LightGray;
			Application.Run(start);
		}
	}
}