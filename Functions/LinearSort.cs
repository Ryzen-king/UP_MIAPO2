namespace ConsoleApp1
{
    internal class LinearSort
    {
        internal void linearSort(IList<int> arr)
        {
            for (var i = 0; i < arr.Count - 1; i++)
            {
                var minIndex = i;
                for (var j = i + 1; j < arr.Count; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                (arr[minIndex], arr[i]) = (arr[i], arr[minIndex]);
            }
        }
    }
}
