//var uintInputArray = new uint[] { 1, 3, 4, 5, 7, 10, 11 };
//uint uintTarget = 9;
//var expected = (3, 4);

//WriteUIntAnswer(uintInputArray, uintTarget, expected);

//uintInputArray = new uint[] { 2, 7, 11, 15 };
//uintTarget = 9;
//expected = (1, 2);

//WriteUIntAnswer(uintInputArray, uintTarget, expected);

//var intInputArray = new int[] { 2, 7, 11, 15 };
//var intTarget = 9;
//expected = (1, 2);

//WriteIntAnswer(intInputArray, intTarget, expected);

//intInputArray = new int[] { 2, 3, 4 };
//intTarget = 6;
//expected = (1, 3);

//WriteIntAnswer(intInputArray, intTarget, expected);

//intInputArray = new int[] { -1, 0 };
//intTarget = -1;
//expected = (1, 2);

//WriteIntAnswer(intInputArray, intTarget, expected);

//intInputArray = new int[] { -11, -7, -5, -4, -3, -1, 0 };
//intTarget = -9;
//expected = (3, 4);

//WriteIntAnswer(intInputArray, intTarget, expected);

using System.Diagnostics;

var testCases = new (int[] inputArray, int target, (int index1, int index2) expected)[]
{
    (new int[] { 1, 3, 4, 5, 7, 10, 11 }, 9, (3, 4)),
    (new int[] { 2, 7, 11, 15 }, 9, (1, 2)),
    (new int[] { 2, 3, 4 }, 6, (1, 3)),
    (new int[] { -1, 0 }, -1, (1, 2)),
    (new int[] { -11, -7, -5, -4, -3, -1, 0 }, -9, (3, 4)),
    (new int[] { -12, -7, -5, -4, -3, -1, 0, 2, 7, 11, 15 }, 9, (8, 9)),
};
var stopwatch = new Stopwatch();

foreach (var testCase in testCases)
{
    stopwatch.Restart();
    WriteAnswer(IntSolution3, nameof(IntSolution3),
        testCase.inputArray, testCase.target, testCase.expected);
    stopwatch.Stop();
    Console.WriteLine($"Duration: {stopwatch.ElapsedMilliseconds}");
    Console.WriteLine();
}

Console.ReadKey();

//static void WriteUIntAnswer(uint[] inputArray, uint target, (int index1, int index2) expected)
//{
//    Console.WriteLine($"Name:     {nameof(UnintSolution2)}");
//    Console.Write($"Input:    (");
//    inputArray.Select((e, i) => (e, i)).ToList()
//        .ForEach(ei => Console.Write($"{ei.e}{(ei.i + 1 == inputArray.Length ? string.Empty : ", ")}"));
//    Console.WriteLine(")");
//    Console.WriteLine($"Target:   {target}");
//    Console.WriteLine($"Expected: {expected}");
//    Console.WriteLine($"Actual:   {UnintSolution2(inputArray, target)}");
//    Console.WriteLine();
//}

//static void WriteIntAnswer(int[] inputArray, int target, (int index1, int index2) expected)
//{
//    Console.WriteLine($"Name:    {nameof(IntSolution1)}");
//    Console.Write($"Input:    (");
//    inputArray.Select((e, i) => (e, i)).ToList()
//        .ForEach(ei => Console.Write($"{ei.e}{(ei.i + 1 == inputArray.Length ? string.Empty : ", ")}"));
//    Console.WriteLine(")");
//    Console.WriteLine($"Target:   {target}");
//    Console.WriteLine($"Expected: {expected}");
//    Console.WriteLine($"Actual:   {IntSolution1(inputArray, target)}");
//    Console.WriteLine();
//}

static void WriteAnswer(Func<int[], int, (int index1, int index2)> solution, string solutionName, int[] inputArray, int target, (int index1, int index2) expected)
{
    Console.WriteLine($"Name:    {solutionName}");
    Console.Write($"Input:    (");
    inputArray.Select((e, i) => (e, i)).ToList()
        .ForEach(ei => Console.Write($"{ei.e}{(ei.i + 1 == inputArray.Length ? string.Empty : ", ")}"));
    Console.WriteLine(")");
    Console.WriteLine($"Target:   {target}");
    Console.WriteLine($"Expected: {expected}");
    Console.WriteLine($"Actual:   {solution(inputArray, target)}");
}

//static (uint index1, uint index2) UnintSolution(IEnumerable<uint> inputArray, uint target)
//{
//    var differencesWithIndex = new List<(uint index, uint difference)>();
//    foreach (var elementWithIndex in
//        inputArray.Select((e, i) => (index: (uint)i, element: e))
//        .Reverse()
//        .Where(ei => ei.element <= target))
//    {
//        if (differencesWithIndex.FirstOrDefault(di => di.difference == elementWithIndex.element) is
//            (uint index, uint difference) result)
//        {
//            return (elementWithIndex.index, result.index);
//        }
//    }
//}

//static (uint index1, uint index2) UnintSolution(IEnumerable<uint> inputArray, uint target)
//{
//    var differencesWithIndex = new Stack<(uint index, uint difference)>();
//    foreach (var elementWithIndex in
//        inputArray.Select((e, i) => (index: (uint)i, element: e))
//        .Reverse()
//        .Where(ei => ei.element <= target)
//        .Select(ei => differencesWithIndex.FirstOrDefault(di => di.difference == ei.element) is (uint index, uint difference) result))
//    {
//        if (differencesWithIndex.FirstOrDefault(di => di.difference == elementWithIndex.element) is
//            (uint index, uint difference) result)
//        {
//            return (elementWithIndex.index, result.index);
//        }
//    }
//}

//static (uint index1, uint index2) UnintSolution(IEnumerable<uint> inputArray, uint target)
//{
//    var differencesWithIndex = new Stack<(uint index, uint difference)>();
//    foreach (var elementWithIndex in
//        inputArray.Select((e, i) => (index: (uint)i, element: e))
//        .Reverse()
//        .Where(ei => ei.element <= target))
//    {
//        if (differencesWithIndex.FirstOrDefault(di => di.difference == elementWithIndex.element) is
//            ValueTuple<uint, uint> result)
//        {
//            return (elementWithIndex.index + 1, result.ToTuple().Item1 + 1);
//        }

//        differencesWithIndex.Push((elementWithIndex.index, target - elementWithIndex.element));
//    }

//    throw new InvalidDataException();
//}

//static (uint index1, uint index2) UnintSolution(IEnumerable<uint> inputArray, uint target)
//{
//    var differencesWithIndex = new Stack<(uint index, uint difference)>();
//    foreach (var elementWithIndex in
//        inputArray.Select((e, i) => ((uint index, uint element)?)(index: (uint)i, element: e))
//        .Reverse()
//        .Where(ei => ei?.element <= target))
//    {
//        if (differencesWithIndex.FirstOrDefault(di => di.difference == elementWithIndex.element) is
//            ValueTuple<uint, uint> result)
//        {
//            return (elementWithIndex.index + 1, result.ToTuple().Item1 + 1);
//        }

//        differencesWithIndex.Push((elementWithIndex.index, target - elementWithIndex.element));
//    }

//    throw new InvalidDataException();
//}

static (uint index1, uint index2) UnintSolution1(IEnumerable<uint> inputArray, uint target)
{
    var differencesWithIndex = new Stack<(uint index, uint difference)?>();
    foreach (var elementWithIndex in
        inputArray.Select((e, i) => (index: (uint)i, element: e))
        .Reverse()
        .Where(ei => ei.element <= target))
    {
        if (differencesWithIndex.FirstOrDefault(di => di?.difference == elementWithIndex.element) is
             (uint index, uint) result)
        {
            return (elementWithIndex.index + 1, result.index + 1);
        }

        differencesWithIndex.Push((elementWithIndex.index, target - elementWithIndex.element));
    }

    throw new InvalidDataException();
}

static (int index1, int index2) UnintSolution2(uint[] inputArray, uint target)
{
    var differencesWithIndex = new Stack<(int index, uint difference)?>();
    for (var i = inputArray.Length - 1; i >= 0; i--)
    {
        var element = inputArray[i];
        if (element > target)
        {
            continue;
        }

        if (differencesWithIndex.FirstOrDefault(di => di?.difference == element) is (int index, uint) result)
        {
            return (i + 1, result.index + 1);
        }

        differencesWithIndex.Push((i, target - element));
    }

    throw new InvalidDataException();
}

static (int index1, int index2) IntSolution1(int[] inputArray, int target)
{
    var differencesWithIndex = new Stack<(int index, int difference)?>();
    for (var i = inputArray.Length - 1; i >= 0; i--)
    {
        var element = inputArray[i];
        if (differencesWithIndex.FirstOrDefault(di => di?.difference == element) is (int index, int) result)
        {
            return (i + 1, result.index + 1);
        }

        differencesWithIndex.Push((i, target - element));
    }

    throw new InvalidDataException();
}

static (int index1, int index2) IntSolution2(int[] inputArray, int target)
{
    var differences = new Stack<int>();
    for (var i = inputArray.Length - 1; i >= 0; i--)
    {
        var element = inputArray[i];
        var index2 = i;
        foreach(var difference in differences)
        {
            index2++;
            if(difference == element)
            {
                return (i + 1, index2 + 1);
            }
        }

        differences.Push(target - element);
    }

    throw new InvalidDataException();
}

static (int index1, int index2) IntSolution3(int[] inputArray, int target)
{
    for (var i = inputArray.Length - 1; i >= 0; i--)
    {
        var element = inputArray[i];
        for (var j = i + 1; j < inputArray.Length; j++)
        {
            if(inputArray[j] == element)
            {
                return (i + 1, j + 1);
            }
        }

        inputArray[i] = target - element;
    }

    throw new InvalidDataException();
}

static (int index1, int index2) VideoSolution(int[] inputArray, int target)
{
    var leftIndex = 0;
    var rightIndex = inputArray.Length - 1;

    while (leftIndex < rightIndex)
    {
        var sum = inputArray[leftIndex] + inputArray[rightIndex];
        if (sum > target)
        {
            rightIndex--;
        }
        else if (sum < target)
        {
            leftIndex++;
        }
        else
        {
            return (leftIndex + 1, rightIndex + 1);
        }
    }
    throw new InvalidDataException();
}

static (int index1, int index2) MidpointSolution(int[] inputArray, int target)
{
    var leftIndex = 0;
    var rightIndex = inputArray.Length - 1;
    var midIndex = inputArray.Length / 2;

    while (leftIndex < rightIndex)
    {
        var sum = inputArray[leftIndex] + inputArray[rightIndex];
        if (sum > target)
        {
            rightIndex--;
            var midSum = inputArray[leftIndex] + inputArray[midIndex];
            if(midSum > target)
            {
                leftIndex = midIndex - 1;
                midIndex = (leftIndex + rightIndex) / 2;
                continue;
            }
            if (midSum < target)
            {
                rightIndex = midIndex + 1;
                midIndex = (leftIndex + rightIndex) / 2;
                continue;
            }

            return (leftIndex + 1, midIndex + 1);
        }
        if (sum < target)
        {
            leftIndex++;
            var midSum = inputArray[midIndex] + inputArray[rightIndex];
            if (midSum > target)
            {
                leftIndex = midIndex - 1;
                midIndex = (leftIndex + rightIndex) / 2;
                continue;
            }
            if (midSum < target)
            {
                rightIndex = midIndex + 1;
                midIndex = (leftIndex + rightIndex) / 2;
                continue;
            }

            return (midIndex + 1, rightIndex + 1);
        }

        return (leftIndex + 1, rightIndex + 1);
    }
    throw new InvalidDataException();
}