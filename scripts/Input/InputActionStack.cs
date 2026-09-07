using UnityEngine;

public class InputActionStack
{
    public int[] inputActionStack = new int[20];


    public void AddToInputStack(int stackVal)
    {
        if(Contains(stackVal)) return;
        if(inputActionStack[inputActionStack.Length - 1] != 0) return;

        int[] tempStack = new int[20];
        for(int i = 0; i < inputActionStack.Length; i++)
        {
            if(i+1 != tempStack.Length) tempStack[i+1] = inputActionStack[i];
            
        }
        tempStack[0] = stackVal;
        inputActionStack = tempStack;
    }

    public void RemoveFromInputStack(int stackVal)
    {
        if(!Contains(stackVal)) return;
        if(inputActionStack[0] == 0) return;

        for(int i = 0; i < inputActionStack.Length; i++)
        {
            if(inputActionStack[i] == stackVal) inputActionStack[i] = 0;
            if(inputActionStack[i] == 0)
            {
                if(i == inputActionStack.Length-1) return;
                inputActionStack[i] = inputActionStack[i+1];
                inputActionStack[i+1] = 0;
            }
            
        } 
    }

    public int GetFromTop()
    {
        return inputActionStack[0];
    }

    private bool Contains(int stackVal)
    {
        foreach(int i in inputActionStack)
        {
            if(i == stackVal) return true;
        }
        return false;
    }

}
