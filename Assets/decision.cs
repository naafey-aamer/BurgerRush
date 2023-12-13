using System;

public class ArrayComparer
{
    public static bool CompareArrays()
    {
        if (gameFlow.plateValue.Length != SampleOrderManager.orderValue.Length)
        {
            throw new ArgumentException("Arrays must be of the same length");
        }

        int matchingCount = 0;
        int arrayLength = gameFlow.plateValue.Length;

        for (int i = 0; i < arrayLength; i++)
        {
            if (gameFlow.plateValue[i] == SampleOrderManager.orderValue[i])
            {
                matchingCount++;
            }
        }

        double similarityPercentage = (double)matchingCount / arrayLength * 100;

        return similarityPercentage > 70;
    }
}

