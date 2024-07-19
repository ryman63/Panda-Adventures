using UnityEngine;

public class PlayerCounter : MonoBehaviour
{
    public static uint BambooCount { get; private set; }

    public static uint BoosterCount { get; private set; }

    public static void BambooCounter()
    {
        BambooCount++;

        Debug.Log("Кол-во бамбука: " + BambooCount);
    }

    public static void BoosterCounter()
    {
        BoosterCount++;

        Debug.Log("Кол-во бустеров: " + BoosterCount);
    }
}
