Hey there!
This README.md belongs to https://github.com/kascodingNL/FastParser-EvenFaster

This project is initiated to be for an friend.
Initially I was writing one myself, but gave up on it when I was so close because I didn't know how to put an 10 behind 5 for example, to get 510.

This friend his page is: https://github.com/caderikor


Use of this project:

It is very simple to use, to benchmark, open cmd, cd to the bin\Debug folder, and do Parser2.0.exe {ITERATIONCOUNT}

ITERATIONCOUNT is an value between 0 and 2147483647(will take a long time).

On my CPU, I saw an decrease of time needed of 0.002526 on the default iteration count(50000), this may not seem much, but in high performance applications, or higher iterations, it is much(I saw up to 18 seconds!).

Please remember that this method is not really checking if the string is 100% integer values, to safe performance(something that the original project does, which actually makes 
performance worse then int.Parse).



Original gist: https://gist.github.com/mdfarragher/0dc1e79079c00cb207fb823d3044fb89#file-c-_parsing_performance-cs