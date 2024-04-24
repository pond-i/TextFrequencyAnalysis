
## Frequency Analysis Documentation

**Application requirements**:


- Analyse via command line argument

- Ignore count of non A-Z, a-z and 0-9 characters (Space, white space, symbols, etc)

- Have optional switch for Case sensitivity (On by default)

- Output total number of read characters excluding illegal characters

- Display most frequently used characters with the pair value of number of occurrences
  

Sample input file - Sample.txt

"*The three did feed the deer The quick brown fox jumped over the lazy dog*"

Example of application execution C:\Test\> frequency.exe sample.txt

Total characters: 58

e (12)

d (6)

h (5)

r (4)

o (4)

t (3)

u (2)

f (2)

i (2)

T (2)

  

### Application Start

Application can be launched via cmd line operation with selected dataset :

  
> C:\FrequencyAnalysis\FrequencyAnalysisComplete\FrequencyAnalysis.exe SampleDataSet.txt

### Application Usage / Input

The application will give the user an option for case sensitivity, this can be selected with a simple "Y" or "N", "yes" or "no" any case. Any other option will continue the program as default which follows the PDF document will be case sensitive.

  

After the user has selected an option, assuming the given input is valid, the text process will begin.

Once completed the output will display an array of items for the user and finish operation.

These items include:

  

**Time Elapsed**

Not on the criteria but interesting to have a timer to have an immediate idea of performance to perform tasks, especially useful for larger datasets. Time elapsed output is in milliseconds.

  

**Total Characters**

As per spec, this is the output display of the total number of characters counter after filtering past symbols, white space, spaces, carriage returns etc.

  

**Total Ignored Characters**

Another field that is not on the criteria but interesting to have a gauge of the amount of characters that were illegal within the input. Added just for some fun.

  

**Top 10 Most Used Characters**

The top 10 most frequently occurring characters along with the number of occurrences of each.

  

## Datasets

### SampleDataSet.txt

This dataset has the basic text given in the PDF document

it contains a balanced amount of characters, mostly used for testing fonts as it contains every alphabet character.

  

### IllegalCharacterDataSet.txt

This dataset is made to test out the second criteria of making sure the application does not count illegal characters such as spaces, and white space as valid characters.

  

### LargeDataSet.txt

As the title suggests this is a large scale data set, generated with a mix of lowercase, uppercase, punctuation and symbols this dataset has over 185k lines of text. Running a test results in this having a total amount of valid characters being over 58 million characters. This dataset is used to stress test optimisation and performance of the main iteration method.


Tests for each dataset can be found in this directory from my own testing.
