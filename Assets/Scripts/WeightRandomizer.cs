using UnityEngine;
public class WeightRandomizer
{
    public static int RandomWeighted(int[] Weights)
    {
        int weightTotal = 0;
        foreach (int w in Weights)
        {
            weightTotal += w;
        }
        int result = 0, total = 0;
        int randVal = Random.Range(0, weightTotal + 1);
        for (result = 0; result < Weights.Length; result++)
        {
            total += Weights[result];
            if (total >= randVal) break;
        }
        return result;
    }
}
