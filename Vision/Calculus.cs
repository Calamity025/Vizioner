using System.Windows.Forms;

namespace Vision {
	public static class Calculus {
		//алфавиты
		private static char[] alph;
		private static char[] alphEng = {
			'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 
			's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
		private static char[] alphUkr = {
			'а', 'б', 'в', 'г', 'ґ', 'д', 'е', 'є', 'ж', 'з', 'и', 'і', 'ї', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
			'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ю', 'я'
		};
		//методы проверки на принадлежность языку
		private static bool IsUkr(string text) {
			bool isTextUkr = true;
			for (int i = 0; i < text.Length; i++) {
				bool isCharUkr = false;
				for (int j = 0; j < alphUkr.Length; j++) {
					if (text[i] == alphUkr[j] || text[i] == ' ' || text[i] == '\r' || text[i] == '\n'|| text[i] == ',' ||
					    text[i] == '.') {
						isCharUkr = true;
					}
				}
				isTextUkr &= isCharUkr;
			}
			return isTextUkr;
		}

		private static bool IsEn(string text) {
			bool isTextEn = true;
			for (int i = 0; i < text.Length; i++) {
				bool isCharEn = false;
				for (int j = 0; j < alphEng.Length; j++) {
					if (text[i] == alphEng[j] || text[i] == ' '|| text[i] == '\r' || text[i] == '\n' || text[i] == ',' ||
					    text[i] == '.') {
						isCharEn = true;
					}
				}
				isTextEn &= isCharEn;
			}
			return isTextEn;
		}
		//метод установки нужного для данного случая алфавита
		private static void CheckAndSetAlph(string text) {
			if (IsUkr(text)) {
				alph = alphUkr;
			} 
			else if (IsEn(text)) {
				alph = alphEng;
			} else { //если введенный текст не соответствует алфавитам, которые есть 
				MessageBox.Show("Введіть відкритий текст та ключ українською чи англійською мовою без спецсимволів");
				alph = null;
			}
		}

		private static char GetKeyChar(string key, int i) {
			return key[i % key.Length];
		}
		//метод шифровки
		private static string VizinerEncr(string text, string key) {
			string outputText = "";
			int iteration = 0;
			for (int j = 0; j < text.Length; j++) {
				if (text[j] == ' ') {
					outputText += ' ';
				} else if (text[j] == ',') {
					outputText += ',';
				} else if (text[j] == '\n' || text[j] == '\r') {
					outputText += "\r\n";
				} else if (text[j] == '.') {
					outputText += '.';
				} else {
					int keyPosition = 0;
					int textCharPosition = 0;
					char tempKeyChar = GetKeyChar(key, iteration);
					iteration++;
					for (int i = 0; i < alph.Length; i++) {
						if (tempKeyChar == alph[i]) {
							keyPosition = i;
						}
						if (text[j] == alph[i]) {
							textCharPosition = i;
						}
					}
					outputText += alph[(textCharPosition + keyPosition) % alph.Length];
				}
			}
			return outputText;
		}
		//метод расшифровки
		private static string VizinerDecr(string text, string key) {
			string outputText = "";
			int iteration = 0;
			for (int j = 0; j < text.Length; j++) {
				if (text[j] == ' ') {
					outputText += ' ';
				} else if (text[j] == ',') {
					outputText += ',';
				} else if (text[j] == '\n' || text[j] == '\r') {
					outputText += "\r\n";
				} else if (text[j] == '.') {
					outputText += '.';
				} else {
					int keyPosition = 0;
					int textCharPosition = 0;
					char tempKeyChar = GetKeyChar(key, iteration);
					iteration++;
					for (int i = 0; i < alph.Length; i++) {
						if (tempKeyChar == alph[i]) {
							keyPosition = i;
						}
						if (text[j] == alph[i]) {
							textCharPosition = i;
						}
					}

					if ((textCharPosition - keyPosition) % alph.Length < 0) {
						outputText += alph[alph.Length + ((textCharPosition - keyPosition) % alph.Length)];
					}
					else {
						outputText += alph[(textCharPosition - keyPosition) % alph.Length];
					}
				}
			}
			return outputText;
		}
		//методы с порядком выполнения операций и проверок сразу после нажатия кнопки
		public static string Encrypt(string text, string key) {
			CheckAndSetAlph(text);
			CheckAndSetAlph(key);
			string output = "";
			if (!(alph is null)) {
				output = VizinerEncr(text, key);
			}
			return output;
		}

		public static string Decrypt(string text, string key) {
			CheckAndSetAlph(text);
			CheckAndSetAlph(key);
			string output = "";
			if (!(alph is null)) {
				output = VizinerDecr(text, key);
			}
			return output;
		}
	}
}
