var uintInputArray = new uint[] { 1, 3, 4, 5, 7, 10, 11 };
uint uintTarget = 9;
var expected = (3, 4);

WriteUIntAnswer(uintInputArray, uintTarget, expected);

uintInputArray = new uint[] { 2, 7, 11, 15 };
uintTarget = 9;
expected = (1, 2);

WriteUIntAnswer(uintInputArray, uintTarget, expected);

var intInputArray = new int[] { 2, 7, 11, 15 };
var intTarget = 9;
expected = (1, 2);

WriteIntAnswer(intInputArray, intTarget, expected);

intInputArray = new int[] { 2, 3, 4 };
intTarget = 6;
expected = (1, 3);

WriteIntAnswer(intInputArray, intTarget, expected);

intInputArray = new int[] { -1, 0 };
intTarget = -1;
expected = (1, 2);

WriteIntAnswer(intInputArray, intTarget, expected);

intInputArray = new int[] { -11, -7, -5, -4, -3, -1, 0 };
intTarget = -9;
expected = (3, 4);

WriteIntAnswer(intInputArray, intTarget, expected);

static void WriteUIntAnswer(uint[] inputArray, uint target, (int index1, int index2) expected)
{
    Console.WriteLine($"Name:     {nameof(UnintSolution2)}");
    Console.Write($"Input:    (");
    inputArray.Select((e, i) => (e, i)).ToList()
        .ForEach(ei => Console.Write($"{ei.e}{(ei.i + 1 == inputArray.Length ? string.Empty : ",")}"));
    Console.WriteLine(")");
    Console.WriteLine($"Target:   {target}");
    Console.WriteLine($"Expected: {expected}");
    Console.WriteLine($"Actual:   {UnintSolution2(inputArray, target)}");
    Console.WriteLine();
}

static void WriteIntAnswer(int[] inputArray, int target, (int index1, int index2) expected)
{
    Console.WriteLine($"Name:    {nameof(IntSolution1)}");
    Console.Write($"Input:    (");
    inputArray.Select((e, i) => (e, i)).ToList()
        .ForEach(ei => Console.Write($"{ei.e}{(ei.i + 1 == inputArray.Length ? string.Empty : ",")}"));
    Console.WriteLine(")");
    Console.WriteLine($"Target:   {target}");
    Console.WriteLine($"Expected: {expected}");
    Console.WriteLine($"Actual:   {IntSolution1(inputArray, target)}");
    Console.WriteLine();
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