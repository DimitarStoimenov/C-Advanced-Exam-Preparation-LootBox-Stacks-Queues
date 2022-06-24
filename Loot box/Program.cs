using System;
using System.Collections.Generic;
using System.Linq;

namespace Loot_box
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootBox = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] seconfLootBox = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> firstQueue = new Queue<int>(firstLootBox);
            Stack<int> secondStack = new Stack<int>(seconfLootBox);
            int claimedItems = 0;

            while (firstQueue.Count > 0 && secondStack.Count > 0)
            {

                int currSum = firstQueue.Peek() + secondStack.Peek();
                if (currSum % 2 == 0)
                {
                    claimedItems += currSum;
                    firstQueue.Dequeue();
                    secondStack.Pop();
                }

                else if (currSum % 2 != 0)
                {
                    int indexToMove = secondStack.Peek();
                    secondStack.Pop();
                    firstQueue.Enqueue(indexToMove);
                }
            }

            if (firstQueue.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            else if (secondStack.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
            
        }
    }
}
