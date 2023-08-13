using System;
namespace PalindromeCheck{
    public class Palindrome{
        public static bool CheckPalindrome(string s){

            int left, right;
            left = 0;
            right = s.Length-1;
            while (left<right){
                if (s[left]!=s[right]){
                    return false;
                }
                left+=1;
                right-=1;
            }
            return true;
        }
        
    }
}