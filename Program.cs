﻿using LeetCodeTasks;


TwoPointersSol twoPointersSol = new TwoPointersSol();
ArraySol arraySol = new ArraySol();
StringSolution stringSolution = new StringSolution();
HashTableSolution hashTableSolution = new HashTableSolution();
SlidingWindowSolution slidingWindowSolution = new SlidingWindowSolution();
DynamicProgrammingSolution dynamicProgrammingSolution = new DynamicProgrammingSolution();
GreedySolution greedySolution = new GreedySolution();
BinarySearchSolution binarySearchSolution = new BinarySearchSolution();
MathSolution mathSolution = new MathSolution();
PrefixSumSolution prefixSumSolution = new PrefixSumSolution();
IntervalSolution intervalSolution = new IntervalSolution();
StackSolution stackSolution = new StackSolution();
BitManipulationSolution bitManipulation = new BitManipulationSolution();
BacktrackingClass backtrackingClass = new BacktrackingClass();

TreeNode root = new TreeNode(1);
root.left = new TreeNode(2);
root.right = new TreeNode(3);
root.left.right = new TreeNode(5);

TreeNodeSolution treeNodeSolution = new TreeNodeSolution();
treeNodeSolution.BinaryTreePath(root);

int[] nums1 = [1, 2, 2, 1, 1, 3];
int[] nums2 = [2, 4, 6];
//hashTableSolution.FindDifferenceNums(nums1, nums2);
hashTableSolution.UniqueOccurrences(nums1);
//string s = "abcabcbb";
//hashTableSolution.LengthOfLongestSubstringRepeat(s);

uint n = 0x0293F46C;
bitManipulation.ReverseBits(n);
//string input = "/home//foo/";
//stackSolution.SimplifyPath(input);
//int[][] intervals = [[1, 3], [2, 6], [8, 10], [15, 18]];
//intervalSolution.Merge(intervals);
//int[] gain = [-5, 1, 5, 0, -7];
//int[] digits = [1, 2, 3];
//int[] digits2 = [9];
//int[] nums = { 1, 1, 1 };
//int k = 2;
//ListNode listNode = new ListNode();
//string input = "PAYPALISHIRING";
//int numRows = 3;

//prefixSumSolution.SubarraySum(nums, k);
//stringSolution.Convert(input, numRows);
//string s = "barfoothefoobarman";
//string[] words = ["foo", "bar"];
//slidingWindowSolution.FindSubstring(s, words);
//prefixSumSolution.LargestAltitude(gain);
//mathSolution.PlusOne(digits);
//mathSolution.PlusOne(digits2);
//int numToRoman = 3749;
//stringSolution.IntToRoman(numToRoman);
//string[] inputStrs = ["eat", "tea", "tan", "ate", "nat", "bat"];
//hashTableSolution.GroupAnagrams(inputStrs);
//int[] nums3 = [4, 5, 6, 7, 0, 1, 2];
//int target3 = 0;
//int[] nums = [3, 2, 1, 0, 4];
//int[] nums2 = [100, 4, 200, 1, 3, 2];
//int[] nums4 = [11, 13, 15, 17];
//binarySearchSolution.FindMin(nums4);
//string romStr = "XVI";
//stringSolution.RomanToIneger(romStr);
//binarySearchSolution.SearchInRotatedSortedArray(nums3, 0);
//hashTableSolution.LongestConsecutive(nums2);
//greedySolution.CanJump(nums);

string s = "babad";
twoPointersSol.LongestPalindromeSubstring(s);
//int[] prices = [7, 1, 5, 3, 6, 4];
//dynamicProgrammingSolution.MaxProfit(prices);
//dynamicProgrammingSolution.MaxProfit2(prices);
//string s = "egg", t = "add";
//stringSolution.IsIsomorphic(s, t);
//string pattern = "abba", s = "dog cat cat dog";
//string s3 = "the sky is blue";
//twoPointersSol.ReverseWords(s3);
//hashTableSolution.WordPattern(pattern, s);
//int[] nums = [1, 12, -5, -6, 50, 3];
//int k = 4;
//string[] strs = ["flower", "flow", "flight"];
//stringSolution.LongestCommonPrefix(strs);
//twoPointersSol.RotateArray(nums, k);
//slidingWindowSolution.FindMaxAverage(nums, k);

//string word1 = "abc", word2 = "pqr";
//twoPointersSol.MergeAlternately(word1, word2);
//string s = "ABAB";
//int k = 2;
//slidingWindowSolution.CharacterReplacement(s, k);

//int q = 3;
//backtrackingClass.GenerateParenthesis(q);

int[] nums = [1000000000, 1000000000, 1000000000, 1000000000];
int target = -294967296;

twoPointersSol.FourSum(nums, target);

//int[] nums1 = [1, 2, 3, 0, 0, 0];
//int m = 3;
//int[] nums2 = [2, 5, 6];
//int n = 3;
//int[] nums = [3, 2, 2, 3];
//int val = 3;
//arraySol.RemoveDuplicates(nums);
//hashTableSolution.IsHappy(19);
//int[] array = [1, 2, 3, 1];
//twoPointersSol.ContainsNearbyDuplicate(array, 3);
//string s = "anagram";
//string t = "nagaram";
//hashTableSolution.IsAnagram(s, t);
//string s = "abc", t = "ahbgdc";
//twoPointersSol.IsSubSequence(s, t);
//string str = "Hello World";
//string[] s = ["test", "hello"];
//Console.WriteLine(s[1]);
//string s = "abcabcbb";
//twoPointersSol.LengthOfLongestSubstring(s);
//stringSolution.LengthOfLastWord(str);
//arraySol.RemoveElement(nums, val);
//twoPointersSol.Merge(nums1, m, nums2, n);