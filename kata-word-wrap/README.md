# Word wrap kata

## Problem Description

Write a function that receives a string and a number N and returns
the string with line breaks inserted at the right places to make 
sure no line is longer than N characters.

## Examples using priority premise principle

- Given "" and 1, it should return ""
- Given "a" and 1, it should return "a"
- Given "Hello, world!" and 0, it should return "Hello, world!"
- Given "a b" and 1, it should return "a\nb"
- Given "a b c" and 1, it should return "a\nb\nc"
- Given "a b c" and 3, it should return "a b\nc"
- Given "Hello, world!" and 5, it should return "Hello,\nworld!"
- Given "Hello, world!" and 7, it should return "Hello,\nworld!"
- Given "Hello, world!" and -1, it should return "Hello, world!"