using System.Drawing;

public static class MysteryStack2
{
    private static bool IsFloat(string text)
    {
        return float.TryParse(text, out _);
    }

    public static float Run(string text)
    {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' '))
        {
            if (item == "+" || item == "-" || item == "*" || item == "/")
            {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;
                if (item == "+")
                {
                    res = op1 + op2;
                }
                else if (item == "-")
                {
                    res = op1 - op2;
                }
                else if (item == "*")
                {
                    res = op1 * op2;
                }
                else
                {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item))
            {
                stack.Push(float.Parse(item));
            }
            else if (item == "")
            {
            }
            else
            {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}

//Input 1: 5 3 7 + * 
//Breakdown:
//Push 5 onto stack [5]
//Push 3 onto stack [5, 3]
//Push 7 onto stack [5, 3, 7]
//Pop 7 and 3, add them to get 10, push 10 onto [5, 10]
//Pop 10 and 5, multiply them to get 50, push 50 onto stack [50]
//Output: 50


//Input 2: 6 2 + 5 3 - /
//Breakdown:
//Push 6 onto stack [6]
//Push 2 onto stack [6, 2]
//Pop 2 and 6, add them to get 8, push 8 onto stack [8]
//Push 5 onto stack [8, 5]
//Push 3 onto stack [8, 5, 3]
//Pop 3 and 5, subtract them to get 2, push 2 onto stack [8, 2]
//Pop 2 and 8, divide them to get 4, push 4 onto stack [4]
//Output: 4

