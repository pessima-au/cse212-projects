public static class MysteryStack1
{
    public static string Run(string text)
    {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}

// input 1: racecar output = 'racecar'
//input 2: stressed ouput = 'desserts'
//input 3: a nut for a jar of tuna output = 'anut fo raj a rof atun a'