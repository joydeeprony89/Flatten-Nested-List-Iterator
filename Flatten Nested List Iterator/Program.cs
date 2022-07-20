using System;
using System.Collections.Generic;

namespace Flatten_Nested_List_Iterator
{
  class Program
  {
    static void Main(string[] args)
    {
      var nestedList = new List<NestedInteger>();
      NestedIterator i = new NestedIterator(nestedList);
      while (i.HasNext()) _ = i.Next();
    }
  }



  // This is the interface that allows for creating nested lists.
  // You should not implement it, or speculate about its implementation
  public interface NestedInteger
  {

    // @return true if this NestedInteger holds a single integer, rather than a nested list.
    bool IsInteger();

    // @return the single integer that this NestedInteger holds, if it holds a single integer
    // Return null if this NestedInteger holds a nested list
    int GetInteger();

    // @return the nested list that this NestedInteger holds, if it holds a nested list
    // Return null if this NestedInteger holds a single integer
    IList<NestedInteger> GetList();
  }

  public class NestedIterator
  {
    Stack<NestedInteger> stk;
    public NestedIterator(IList<NestedInteger> nestedList)
    {
      stk = new Stack<NestedInteger>();
      Helper(nestedList);
    }

    public bool HasNext()
    {
      while (stk.Count > 0)
      {
        if (stk.Peek().IsInteger()) return true;
        Helper(stk.Peek().GetList());
      }
      return stk.Count > 0;
    }

    public int Next()
    {
      if (!HasNext())
      {
        return 0;
      }
      return stk.Peek().GetInteger();
    }

    private void Helper(IList<NestedInteger> nestedList)
    {
      for (int i = nestedList.Count - 1; i >= 0; i--)
      {
        stk.Push(nestedList[i]);
      }
    }
  }
}
