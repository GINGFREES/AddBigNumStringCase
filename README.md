# AddBigNumStringCase

## History

* 2022/04/29
    * Add big number string case example without + operator


## Environment
ViusalStudio for Mac 2019

## Purpose

There is a function to get random big number string as below

        const int MAX_NUMBERS_OF_DIGITS = 9;
        const string chars = "1234567890";

        
        private static string RandomBigNumberStr()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            var strArray = Enumerable.Repeat(chars, MAX_NUMBERS_OF_DIGITS).Select(s =>
            s[r.Next(chars.Length)]).ToArray();
            return new string(strArray).TrimStart('0');
        }

### Request
* Use RandomBigNumberStr to get two random big number.
* Try add this two number without "+" operator

## Algorithm

* To decrease additional BigO(n), we first defined the string match case with the result in dictionary

        private static readonly Dictionary<int, string> dics =
            new Dictionary<int, string>() {
                {0 ,"00" },
                {1, "10,01"},
                {2, "20,02,11"},
                {3, "30,03,12,21"},
                {4, "40,04,22,13,31"},
                {5, "50,05,23,32,14,41"},
                {6 , "60,06,15,51,42,24,33"},
                {7, "70,07,16,61,25,52,34,43" },
                {8, "80,08,17,71,62,26,53,35,44" },
                {9, "90,09,81,18,27,72,36,63,54,45"},
                {10,"91,19,28,82,73,37,46,64,55" },
                {11,"92,29,38,83,74,47,56,65" },
                {12,"93,39,48,84,75,57,66"},
                {13,"94,49,58,85,76,67"},
                {14,"95,59,68,86,77" },
                {15,"96,69,87,78" },
                {16,"97,79,88"},
                {17,"98,89" },
                {18,"99" }
            };

* <p>In the case above, we defined result value as key(0~18), and match numbers string as values("19,91....").</p> <p>Because number for each character in big number string is from 0 to 9, each match string with two character would be found in Dictionary's value.<p>We use the dictionary to find out the result which is the key of Dictionary</p>


* Then we define the fuction as below
        
        private static int GetCarryNum(string numMerge, out int result)
        {
            result = -1;
            int back = -1;
            foreach(var pair in dics)
            {
                if(pair.Value.Contains(numMerge))
                {
                    result = pair.Key % 10;
                    back = pair.Key / 10;
                    break;
                }
            }
            return back;
        }

### Function defined
|Name|return val|out val|parameters|
|:--|:--|:--|:--|
|GetCarryNum|back:int|result:int|numMerge:string|

* GetCarryNum
  * Function use to get two character to return back the result of two chacaters' added result digit, and out the digit carried to add in next numMerge string.

* back
  * the digit that added by two characters in string 'numMerge', not inculuding the number over 9.

* result
  * the digit that if the sum of two characters number is over 10, it would be 1.

* Example:
  * If "95" is numMerge, then
    * back would be 4, because sum is 14
    * result would be 1, beacause sum is 14

* In the example we could know that in each character the result's maximum would be 1.


### BigO

In the function we could know
* BigO(n) for find result in GetCarryNum
* BigO(n) for each number generated from RandomBigNumberStr

* Total BigO about BigO(n^2), but beacause of the limit definition for the Dictionary of result, the BigO(n) in GetCarryNum could be reduce to BigO(1), because of the limited result count. 


## More advance and quick thinking
Although the case is about to less than BigO(n), it still can be more efficiency.

* Hint: use logic gate in dictionary avoid running the Contain's in list

You can see in [Logic.vs](https://github.com/GINGFREES/AddBigNumStringCase/blob/main/TestAdd/TestAdd/Logic.cs)



