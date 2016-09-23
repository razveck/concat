Concat is a simple command line tool that searches for text files and concatenates them (joins them) in one single file.

Instructions:

- Place the concat.exe file in the folder you want to work with, or add its current location to the system path.
- Run the command line.
- Type in "concat <file name> <target extension> <extensions to search>" without any punctuation.

Example: concat script js //outputs a JavaScript file called script.js that contains all text from all JavaScript files in children folders.
Example: concat main py //outputs a Python file called main.py that contains all text from all JavaScript files in children folders (no <extensions to search> were provided, so it defaults to js files.
Example: concat myFile txt txt py js cpp rb //outputs a text file called myFile.txt that contains all text from all the Text, Python, JavaScript, C++ and Ruby files in children folders.

There is no limit to the number of extensions to search, the text will be output into the final file specified as <filename>.<target extension>.
If no arguments are passed, the program will search for .js files. The default file name is default_concat.js".

Feel free to fork, improve and contribute to the repository if you will.
