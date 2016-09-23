using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace concat {
	class Program {
		static void Main(string[] args) {
			if(args.Length > 0 && (args[0] == "-help" || args?[0] == "?")) {
				Console.WriteLine("\nFormat: concat <file name> <target extension> <extensions to search>\n\nExample: concat script js\nExample: concat main py\nExample: concat myFile txt txt py js cpp rb\n\nThere is no limit to the number of extensions to search, the text will be output into the final file.\nIf no arguments are passed, the program will search for .js files. The default file name is \"default_concat.js\"");
				return;
			}

			string targetName = "default_concat";
			string targetExtension = "js";
			string[] extensionsToSearch = new string[1];

			if(args.Length > 2) {
				extensionsToSearch = new string[args.Length - 2];
				for(int i = 2;i < args.Length;i++) {
					extensionsToSearch[i - 2] = args[i];
				}
			} else {
				extensionsToSearch[0] = targetExtension;
			}

			switch(args.Length) {
				case 1:
					targetName = args[0];
					break;
				case 2:
					targetExtension = args[1];
					goto case 1;
			}


			///------------------------------------------------------------------------------------------------------------\\\
			
			string home = AppDomain.CurrentDomain.BaseDirectory;

			string targetPath = home + "\\" + targetName + "." + targetExtension;
			CheckForExistingFile(targetPath);

			List<string> allFiles = new List<string>();
			for(int i = 0;i < extensionsToSearch.Length;i++) {
				allFiles.AddRange(Directory.GetFiles(home,"*." + extensionsToSearch[i],SearchOption.AllDirectories));
			}
						

			StringBuilder sb = new StringBuilder();

			for(int i = 0;i < allFiles.Count;i++) {
				string[] Y = allFiles[i].Split('\\');
				sb.Append("//" + Y[Y.Length - 1] + "\n\n");
				sb.Append(File.ReadAllText(allFiles[i]));
				sb.Append("\n\n");
			}

			using(TextWriter writer = File.CreateText(targetPath)) {				
				writer.Write(sb);
			}

		}

		static bool CheckForExistingFile(string path){

			if(File.Exists(path)) {
				if(CheckForExistingFile(path + ".previous")) {
					return true;
				} else {
					File.Copy(path,path + ".previous");
					File.Delete(path);
					return false;
				}
				//
			} else {
				return false;
			}
			
		}
	}	
}