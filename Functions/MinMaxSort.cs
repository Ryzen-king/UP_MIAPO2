namespace ConsoleApp1
{
    internal class MinMaxSort
    {
        internal void minMaxSort(IList<int> arr, bool isAscending = true)
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                int extremum = i;

                for (int j = i + 1; j < arr.Count; j++)
                {
                    if ((isAscending && arr[j] < arr[extremum]) || (!isAscending && arr[j] > arr[extremum]))
                    {
                        extremum = j;
                    }
                }

                (arr[i], arr[extremum]) = (arr[extremum], arr[i]);
            }
        }
    }
}
